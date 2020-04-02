using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Gms.Location;
using Android.Locations;
using Android.Media;
using Android.Nfc;
using Android.OS;
using Android.Widget;
using System;
using System.Threading.Tasks;
using System.Timers;
using Android.Preferences;
using Android.Views;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Globalization;
using Android.Telephony;
using Android.Graphics;
using CRadius.Droid.ninja.radius;

namespace CRadius.Droid
{
    [Activity(Label = "Main",
        Icon = "@drawable/icon",
        Theme = "@style/MyTheme",
        ScreenOrientation = ScreenOrientation.Portrait)]

    public class MainActivity : Activity
    {
        MediaPlayer _barp;
        MediaPlayer _beep;

        string _txtTag;
        string _txtLocation;
        string _txtAddress;
        string _txtStartLocation;
        string _txtStartAddress;

        TextView _txtRemarks;
        TextView _txtDistance;

        ImageView _imageViewInOut;

        Button _buttonSnaptoHere;
        Button _buttonStart;

        Toolbar _toolbar;

        public static MainActivity _instance;

        private NfcAdapter _nfcAdapter;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            _instance = this;

            SetContentView(Resource.Layout.Main);

            _nfcAdapter = NfcAdapter.GetDefaultAdapter(this);

            _toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
            _toolbar.Title = string.Empty;
            SetActionBar(_toolbar);

            _txtDistance = FindViewById<TextView>(Resource.Id.txtDistance);
            _txtRemarks = FindViewById<TextView>(Resource.Id.txtRemarks);
            _imageViewInOut = FindViewById<ImageView>(Resource.Id.imageViewInOut);

            var font = Typeface.CreateFromAsset(Assets, "MontserratBold.ttf");
            _txtDistance.Typeface = font;

            _barp = MediaPlayer.Create(this, Resource.Raw.barp);
            _beep = MediaPlayer.Create(this, Resource.Raw.beep);

            ISharedPreferences prefs = PreferenceManager.GetDefaultSharedPreferences(this);

            _txtTag = prefs.GetString("TagId", string.Empty);

            _txtStartLocation = String.Format("{0:0.####},{1:0.####}", Utils.StartLocation.Latitude, Utils.StartLocation.Longitude);
            _txtStartAddress = GetAddress(Utils.StartLocation.Latitude, Utils.StartLocation.Longitude);
            _txtRemarks.Text = string.Empty;

            _buttonSnaptoHere = FindViewById<Button>(Resource.Id.buttonSnaptoHere);
            _buttonSnaptoHere.Click += delegate
            {
                DoSnap(prefs);
            };

            Utils.Started = true; // false;
            Utils.SMSSent = false;
            Utils.EmailSent = false;

            _buttonStart = FindViewById<Button>(Resource.Id.buttonStart);
            _buttonStart.Click += delegate
            {
                Utils.Started = !Utils.Started;

                // We only reset the SMS flag on deliberate restarts
                if (!Utils.Started)
                {
                    Utils.SMSSent = false;
                    Utils.EmailSent = false;
                }

                DoStart();
            };

            DoStart();

            _buttonStart.Visibility = ViewStates.Invisible;
            _buttonSnaptoHere.Visibility = ViewStates.Invisible;

            _txtDistance.Text = "SCANNING";

            Task.Run(() =>
            {
                StartLocationUpdates();
            });
        }

        void DoStart()
        {

            if (Utils.Started)
            {
                _buttonStart.Text = "Sleep";
                ShowState();
            }
            else
            {
                _buttonStart.Text = "Wake";
                _txtRemarks.Text = string.Empty;
                Alert((int)Utils.WarningState.Safe, null, string.Empty, false);
            }
        }

        protected override void OnResume()
        {
            base.OnResume();

            if (_nfcAdapter == null)
            {
                Toast.MakeText(this, "NFC is not supported on this device. You may continue, without NFC.", ToastLength.Long).Show();
            }
            else
            {
                var filters = new[]
                {
                    new IntentFilter(NfcAdapter.ActionTagDiscovered)
                };
                var intent = new Intent(this, this.GetType()).AddFlags(ActivityFlags.SingleTop);
                var pendingIntent = PendingIntent.GetActivity(this, 0, intent, 0);

                _nfcAdapter.EnableForegroundDispatch(this, pendingIntent, filters, null);
            }
        }

        void ShowState2()
        {

        }

        private void ShowState()
        {
            _buttonStart.Visibility = ViewStates.Visible;
            _buttonSnaptoHere.Visibility = ViewStates.Visible;

            _toolbar.SetBackgroundColor(Color.ParseColor("#2196f3"));
            _txtDistance.SetTextColor(Color.ParseColor("#666666"));

            double radius = Utils.DblParse(Utils.Radius);

            if (Utils.Started)
            {
                bool alarm = false;

                // This code implements rules
                foreach (Rule rule in Utils.Rules)
                {
                    int oldLocationState = rule == null ? (int)Utils.LocationState.Out : rule.LocationState;

                    // In this version we just do the first alarm in series
                    if (rule.Distance > 0 && !rule.Dismissed)
                    {
                        //if (rule.Direction == (int)Utils.Direction.Cross) // Directions not implemented yet but plumbing is there
                        //{
                            string a = "{action}";

                            // Possible state changes:
                            // Out to Inbound
                            // In to Outbound
                            // In
                            // Safe
                            if (oldLocationState == (int)Utils.LocationState.Out &&
                                rule.Distance > rule.RadiusK &&
                                rule.Distance < rule.RadiusK + rule.WarnK) // Inbound
                            {
                                string b = "are within " + rule.WarnK + " of entering " + rule.LocationName;
                                rule.Message = rule.Message.Replace(a, b);
                                alarm = true;
                                Alert((int)Utils.WarningState.Warning, rule, rule.Message);
                            }
                            else if (oldLocationState == (int)Utils.LocationState.In &&
                                rule.Distance < rule.RadiusK &&
                                rule.Distance > rule.RadiusK - rule.WarnK) // Outbound
                            {
                                string b = "are within " + rule.WarnK + " of exiting " + rule.LocationName;
                                rule.Message = rule.Message.Replace(a, b);
                                alarm = true;
                                Alert((int)Utils.WarningState.Warning, rule, rule.Message);
                            }
                            else if (rule.Distance < rule.RadiusK) // In
                            {
                                string b = "are inside " + rule.LocationName;
                                rule.Message = rule.Message.Replace(a, b);
                                alarm = true;
                                Alert((int)Utils.WarningState.Alert, rule, rule.Message);
                            }
                            else
                            {
                                Alert((int)Utils.WarningState.Safe, rule);
                            }
                        //}
                        //else
                        //{
                        //    Alert((int)Utils.WarningState.Safe, rule);
                        //}
                    }
                    else
                    {
                        Alert((int)Utils.WarningState.Safe, rule);
                    }
                }

                // This code implements the origin - if there's no other alarm
                if (!alarm && Utils.Distance > radius && radius > 0)
                {
                    Alert((int)Utils.WarningState.Warning, null);

                    // Send an SMS and / or email, once per session
                    if ((Utils.Mobile.Length > 0 && !Utils.SMSSent) || (Utils.Email.Length > 0 && !Utils.EmailSent))
                    {
                        PendingIntent sentPI;
                        String SENT = "SMS_SENT";

                        sentPI = PendingIntent.GetBroadcast(this, 0, new Intent(SENT), 0);

                        int count = BitConverter.GetBytes(decimal.GetBits((decimal)radius)[3])[2];
                        string distance = string.Format(new NumberFormatInfo() { NumberDecimalDigits = count }, "{0:F}", (decimal)Utils.Distance);

                        string message = Utils.Name +
                            " is " +
                            distance +
                            " km from " +
                            _txtStartLocation + " " +
                            _txtStartAddress;

                        if (Utils.Mobile.Length > 0 && !Utils.SMSSent)
                        {
                            SmsManager.Default.SendTextMessage(
                                Utils.Mobile.Replace(" ", string.Empty),
                                null,
                                "Radius alert. " + message,
                                sentPI,
                                null);

                            Utils.SMSSent = true;
                        }
                    }
                }
            }
            else
            {
                Alert((int)Utils.WarningState.Safe, null);
            }
        }

        protected override void OnNewIntent(Intent intent)
        {
            base.OnNewIntent(intent);

            RunOnUiThread(() =>
            {
                Utils.TagId = TagParser.GetTagId(intent);

                Toast.MakeText(this, "Tag " +
                    Utils.TagId +
                    (_txtTag.Length > 0 ? System.Environment.NewLine + _txtTag : string.Empty), ToastLength.Short).Show();

                if (_txtTag == Utils.TagId)
                {
                    Utils.Started = !Utils.Started;
                }
                else
                {
                    Utils.Started = true;

                    DoSnap(PreferenceManager.GetDefaultSharedPreferences(this));

                    ISharedPreferences prefs = PreferenceManager.GetDefaultSharedPreferences(this);
                    ISharedPreferencesEditor editor = prefs.Edit();
                    editor.PutString("TagId", Utils.TagId);
                    editor.Apply();
                }

                _txtTag = Utils.TagId;

                DoStart();
            });
        }

        void Alert(int warningState, Rule rule, string message = "", bool showDistance = true)
        {
            Utils.Rule = rule;

            if (message.Length > 0)
            {
                _txtRemarks.Text = message;
            }

            if (warningState == (int)Utils.WarningState.Safe)
            {
                if (!Utils.Started)
                {
                    _txtDistance.Text = "SLEEPING"; // string.Empty;
                    _txtDistance.SetTextColor(Color.ParseColor("#b2b2b2"));
                }
                else if (showDistance || Utils.Distance > 0)
                {
                    _txtDistance.Text = Utils.Distance.ToString("0.###");
                    _txtDistance.SetTextColor(Color.ParseColor("#666666"));
                }

                //if (Utils.Started)
                //{
                //    _imageViewInOut.SetImageResource(Resource.Drawable.Green);
                //    _toolbar.SetBackgroundColor(Color.ParseColor("#00bf02"));
                //}
                //else
                //{
                _imageViewInOut.SetImageResource(Resource.Drawable.Gray);
                    _toolbar.SetBackgroundColor(Color.ParseColor("#2196f3"));
                //}

            }
            else if (warningState == (int)Utils.WarningState.Warning)
            {
                _imageViewInOut.SetImageResource(Resource.Drawable.Orange);
                _toolbar.SetBackgroundColor(Color.ParseColor("#f2c50e"));
                _txtDistance.SetTextColor(Color.ParseColor("#f2c50e"));
                _txtDistance.Text = "CAUTION";
                //_barp.Start();
            }
            else if (warningState == (int)Utils.WarningState.Alert)
            {
                _imageViewInOut.SetImageResource(Resource.Drawable.Red);
                _toolbar.SetBackgroundColor(Color.ParseColor("#bf0000"));
                _txtDistance.SetTextColor(Color.ParseColor("#bf0000"));
                _txtDistance.Text = "ALERT";
            }
        }

        void DoSnap(ISharedPreferences prefs)
        {
            Utils.StartLocation = Utils.Location;
            Utils.Distance = 0;

            _txtStartLocation = String.Format("{0:0.####},{1:0.####}", Utils.StartLocation.Latitude, Utils.StartLocation.Longitude);
            _txtStartAddress = GetAddress(Utils.StartLocation.Latitude, Utils.StartLocation.Longitude);
            _txtLocation = _txtStartLocation;
            _txtAddress = _txtStartAddress;
            _txtRemarks.Text = "You are at your origin.";

            Alert((int)Utils.WarningState.Safe, null);

            // Persist the new origin
            ISharedPreferencesEditor editor = prefs.Edit();
            editor.PutFloat("StartLatitude", (float)Utils.StartLocation.Latitude);
            editor.PutFloat("StartLongitude", (float)Utils.StartLocation.Longitude);
            editor.PutString("TagId", string.Empty);
            editor.Apply();

            _txtTag = string.Empty;
        }

        public string GetAddress(double latitude, double longitude)
        {
            string address = string.Empty;

            try
            {
                Geocoder geocoder = new Geocoder(this);

                IList<Address> addressList = geocoder.GetFromLocation(latitude, longitude, 1);

                Address addressCurrent = addressList.FirstOrDefault();

                if (addressCurrent != null)
                {
                    StringBuilder deviceAddress = new StringBuilder();

                    for (int i = 0; i <= addressCurrent.MaxAddressLineIndex; i++)
                    {
                        if (addressCurrent.GetAddressLine(i).Length > 0)
                        {
                            deviceAddress.Append(addressCurrent.GetAddressLine(i)).AppendLine(",");
                        }
                    }

                    address = deviceAddress.ToString().Replace(System.Environment.NewLine, string.Empty).TrimEnd(',');
                }
            }
            catch
            {
                address = "Can't get address. Are you online?";
            }

            return address;
        }

        void OnLocationResult(object sender, Location location)
        {
            try
            {
                RunOnUiThread(() =>
                {
                    Utils.Location = location;

                    if (Utils.Location == null)
                    {
                        _txtLocation = "Unable to determine your location.";
                    }
                    else
                    {
                        _txtLocation = String.Format("{0:0.####},{1:0.####}", Utils.Location.Latitude, Utils.Location.Longitude);

                        //The Geocoder class retrieves a list of addresses from Google over the internet  
                        //if (Utils.PreviousLocation == null ||
                        //    Utils.Location.Latitude != Utils.PreviousLocation.Latitude ||
                        //    Utils.Location.Longitude != Utils.PreviousLocation.Longitude)
                        //{
                        //    _txtAddress = GetAddress(Utils.Location.Latitude, Utils.Location.Longitude);
                        //}

                        _txtLocation = String.Format("{0:0.####},{1:0.####}", Utils.StartLocation.Latitude, Utils.StartLocation.Longitude);

                        // This code measures distance from the origin
                        var coord1 = new LatLng(Utils.StartLocation.Latitude, Utils.StartLocation.Longitude);
                        var coord2 = new LatLng(Utils.Location.Latitude, Utils.Location.Longitude);

                        Utils.HaversineDistance(coord1, coord2, Utils.DistanceUnit.Kilometers);

                        string distance = ((decimal)Utils.Distance).ToString("0.#####");

                        _txtDistance.Text = Utils.Distance.ToString("0.###");

                        if (Utils.Distance == 0)
                        {
                            _txtRemarks.Text = string.Format("You are at your origin.");
                        }
                        else if (Utils.Started)
                        {
                            _txtRemarks.Text = string.Format("You are {0} km from your origin.",
                            ((decimal)Utils.Distance).ToString("0.#####"));
                        }

                        Utils.PreviousLocation = location;

                        // This code measures distance wrt rules
                        foreach (Rule rule in Utils.Rules)
                        {
                            coord1 = new LatLng(Utils.StartLocation.Latitude, Utils.StartLocation.Longitude);
                            coord2 = new LatLng(Utils.Location.Latitude, Utils.Location.Longitude);

                            rule.Distance = Utils.HaversineDistance(coord1, coord2);
                        }

                        ShowState();
                    }
                });
            }
            catch (Exception ex)
            {
                Toast.MakeText(this, ex.Message, ToastLength.Long).Show();
            }
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.home, menu);
            return base.OnCreateOptionsMenu(menu);
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            try
            {
                if (item.ItemId == Resource.Id.menu_settings)
                {
                    StartActivity(new Intent(Application.Context, typeof(SettingsActivity)));
                }
                else if (item.ItemId == Resource.Id.menu_tag)
                {
                    StartActivity(new Intent(Application.Context, typeof(TagActivity)));
                }
            }
            catch (Exception ex)
            {
                Toast.MakeText(this, ex.Message, ToastLength.Long).Show();
            }

            return base.OnOptionsItemSelected(item);
        }

        MyLocationCallback locationCallback;
        FusedLocationProviderClient client;

        void StartLocationUpdates()
        {
            try
            {
                // Create a callback that will get the location updates
                if (locationCallback == null)
                {
                    locationCallback = new MyLocationCallback();
                    locationCallback.LocationUpdated += OnLocationResult;
                }

                // Get the current client
                if (client == null)
                {
                    client = LocationServices.GetFusedLocationProviderClient(this);
                }

                //Create request and set intervals:
                //Interval: Desired interval for active location updates, it is inexact and you may not receive upates at all if no location servers are available
                //Fastest: Interval is exact and app will never receive updates faster than this value
                var locationRequest = new LocationRequest()
                    .SetInterval(10000)
                    .SetFastestInterval(5000)
                    .SetPriority(LocationRequest.PriorityHighAccuracy);

                RunOnUiThread(async () =>
                {
                    try
                    {
                        await client.RequestLocationUpdatesAsync(locationRequest, locationCallback);
                    }
                    catch (Exception ex)
                    {
                        Utils.Eros = ex;
                        StartActivity(new Intent(Application.Context, typeof(ErosActivity)));
                    }
                });
            }
            catch (Exception ex)
            {
                RunOnUiThread(() =>
                {
                    Utils.Eros = ex;
                    StartActivity(new Intent(Application.Context, typeof(ErosActivity)));
                });
            }
        }
    }

    class MyLocationCallback : LocationCallback
    {
        public EventHandler<Location> LocationUpdated;
        public override void OnLocationResult(LocationResult result)
        {
            base.OnLocationResult(result);
            LocationUpdated?.Invoke(this, result.LastLocation);
        }
    }
}

