using Android;
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Gms.Location;
using Android.Graphics;
using Android.Locations;
using Android.Media;
using Android.OS;
using Android.Preferences;
using Android.Support.Design.Widget;
using Android.Support.V4.Content;
using Android.Telephony;
using Android.Views;
using Android.Widget;
using CRadius.Droid.ninja.radius;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Environment = System.Environment;

namespace CRadius.Droid
{
    [Activity(Label = "Main",
        Icon = "@drawable/icon",
        Theme = "@style/MyTheme",
        ScreenOrientation = ScreenOrientation.Portrait)]

    public class MainActivity : Activity
    {
        static Timer _barpTime = null;

        static MediaPlayer _barp;
        MediaPlayer _beep;

        string _txtTag;
        string _txtLocation;
        string _txtStartLocation;
        string _txtStartAddress;

        TextView _txtRemarks;
        TextView _txtDistance;
        TextView _txtLog;

        ImageView _imageViewInOut;

        Button _buttonMute;

        Toolbar _toolbar;

        public static MainActivity _instance;

        static void TickTimer(object state)
        {
            Thread.Sleep(1000);
            _barp.Start();
        }

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            try
            {
                _instance = this;

                SetContentView(Resource.Layout.Main);

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
                _txtStartAddress = Utils.GetAddress(_instance);
                _txtRemarks.Text = string.Empty;

                _buttonMute = FindViewById<Button>(Resource.Id.buttonMute);
                _buttonMute.Click += delegate
                {
                    if (_barpTime != null)
                    {
                        _barpTime.Change(Timeout.Infinite, Timeout.Infinite);
                    }
                    _buttonMute.Visibility = ViewStates.Gone;
                };

                Utils.SMSSent = false;

                DoStart();

                _buttonMute.Visibility = ViewStates.Invisible;

                _txtDistance.Text = " ";

                Task.Run(() =>
                {
                    _ = TryGetLocationAsync();
                });
            }
            catch (Exception ex)
            {
                DoEros(ex);
            }
        }

        readonly string[] Permissions =
        {
            Manifest.Permission.AccessCoarseLocation,
            Manifest.Permission.AccessFineLocation,
            Manifest.Permission.SendSms
        };

        const int RequestLocationId = 0;

        async Task TryGetLocationAsync()
        {
            if ((int)Build.VERSION.SdkInt < 23)
            {
                await Task.Run(() =>
                {
                    StartLocationUpdates();
                });
                return;
            }

            await GetPermissionAsync();
        }

        async Task GetPermissionAsync()
        {
            if (CheckSelfPermission(Manifest.Permission.AccessFineLocation) == (int)Android.Content.PM.Permission.Granted &&
                CheckSelfPermission(Manifest.Permission.AccessCoarseLocation) == (int)Android.Content.PM.Permission.Granted &&
                CheckSelfPermission(Manifest.Permission.SendSms) == (int)Android.Content.PM.Permission.Granted)
            {
                await Task.Run(() =>
                {
                    StartLocationUpdates();
                });
                return;
            }

            //need to request permission
            if (ShouldShowRequestPermissionRationale(Manifest.Permission.AccessFineLocation) ||
                ShouldShowRequestPermissionRationale(Manifest.Permission.AccessCoarseLocation) ||
                ShouldShowRequestPermissionRationale(Manifest.Permission.SendSms))
            {
                var layout = (LinearLayout)FindViewById(Resource.Id.action_bar_root);

                Snackbar.Make(layout, "Location access is required to show location alerts.", Snackbar.LengthIndefinite)
                        .SetAction("OK", v => RequestPermissions(Permissions, RequestLocationId))
                        .Show();
                return;
            }

            //Finally request permissions with the list of permissions and Id
            RequestPermissions(Permissions, RequestLocationId);

        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, Permission[] grantResults)
        {
            if (requestCode == RequestLocationId)
            {
                if (grantResults[0] == Permission.Granted &&
                    grantResults[1] == Permission.Granted &&
                    grantResults[2] == Permission.Granted)
                {
                    StartLocationUpdates();
                }
            }
            else
            {
                base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
            }
        }

        void DoEros(Exception ex)
        {
            Utils.Eros = ex;
            StartActivity(new Intent(Application.Context, typeof(ErosActivity)));
        }

        void DoStart()
        {
            _txtRemarks.Text = string.Empty;
            _buttonMute.Visibility = ViewStates.Gone;
            Alert((int)Utils.WarningState.Safe, null, string.Empty, false);
        }

        protected override void OnResume()
        {
            base.OnResume();
        }

        private void ShowState()
        {
            _toolbar.SetBackgroundColor(Color.ParseColor("#2196f3"));
            _txtDistance.SetTextColor(Color.ParseColor("#333333"));

            //double radius = Utils.DblParse(Utils.Radius);

            bool alarm = false;

            // This code implements rules
            foreach (Rule rule in Utils.Rules)
            {
                int oldLocationState = rule == null ? (int)Utils.LocationState.Out : rule.LocationState;

                // In this version we just do the first undismissed alarm in series
                if (rule.Dismissed)
                {
                    //Alert((int)Utils.WarningState.Safe, rule);
                }
                else
                { 
                    string a = "{action}";

                    if (rule.LocationType == (int)Utils.LocationType.Radius)
                    {
                        ////Log("Consuming rule " + rule.LocationName);

                        rule.LocationState = rule.Distance > rule.RadiusK ? (int)Utils.LocationState.Out : (int)Utils.LocationState.In;

                        // Possible state changes:
                        // Out to Inbound
                        // In to Outbound
                        // In
                        // Safe
                        if (oldLocationState == (int)Utils.LocationState.Out &&
                            rule.Distance > rule.RadiusK &&
                            rule.Distance < rule.RadiusK + rule.WarnK) // Inbound
                        {
                            string b = "are within " + rule.WarnK.ToString("0.###") + " km of entering " + rule.LocationName;
                            string message = rule.Message.Replace(a, b);
                            message += Environment.NewLine +
                                Environment.NewLine +
                                "Coronalert will continue to monitor your position, and tell you when you enter.";
                            alarm = true;
                            Alert((int)Utils.WarningState.Warning, rule, message);
                        }
                        else if (oldLocationState == (int)Utils.LocationState.Out &&
                            rule.Distance < rule.RadiusK) // Entered
                        {
                            string b = " have entered " + rule.LocationName;
                            string c = rule.Message.Replace(a, b);

                            decimal edgeDistance = rule.RadiusK - rule.Distance;
                            if (edgeDistance > 0)
                            {
                                c +=
                                    Environment.NewLine +
                                    Environment.NewLine +
                                    "You are " + edgeDistance.ToString("0.###") + " km from the edge.";
                            }

                            alarm = true;
                            Alert((int)Utils.WarningState.Alert, rule, c);
                        }
                        else if (oldLocationState == (int)Utils.LocationState.In &&
                            rule.Distance < rule.RadiusK &&
                            rule.Distance > rule.RadiusK - rule.WarnK) // Outbound
                        {
                            string b = "are within " + rule.WarnK.ToString("0.###") + " km of exiting " + rule.LocationName +
                                    ". Coronalert will continue to monitor your position, and tell you when you leave.";
                            string c = rule.Message.Replace(a, b);
                            alarm = true;
                            Alert((int)Utils.WarningState.Warning, rule, c);
                        }
                        else if (oldLocationState == (int)Utils.LocationState.In &&
                            rule.Distance > rule.RadiusK) // Left
                        {
                            string b = " have left " + rule.LocationName +
                                    ". Coronalert will continue to monitor your position, and tell you if you re-enter.";
                            string c = rule.Message.Replace(a, b);
                            alarm = true;
                            Alert((int)Utils.WarningState.Alert, rule, c);
                        }
                        else if (rule.Distance < rule.RadiusK) // In
                        {
                            string b = "are inside " + rule.LocationName;
                            string c = rule.Message.Replace(a, b);

                            decimal edgeDistance = rule.RadiusK - rule.Distance;
                            if (edgeDistance > 0)
                            {
                                c +=
                                    Environment.NewLine +
                                    Environment.NewLine +
                                    "You are " + edgeDistance.ToString("0.###") + " km from the edge.";
                            }

                            alarm = true;
                            Alert((int)Utils.WarningState.Warning, rule, c);
                        }
                        else if (rule.LocationState == (int)Utils.LocationState.Out)
                        {
                            alarm = true;
                            Alert((int)Utils.WarningState.Safe, rule);
                        }
                    }
                    else if (rule.LocationType == (int)Utils.LocationType.Polygon)
                    {
                        rule.LocationState = rule.Distance > 0 ? (int)Utils.LocationState.Out : (int)Utils.LocationState.In;

                        if (oldLocationState == (int)Utils.LocationState.Out &&
                            rule.Distance < 0)
                        {
                            string b = "have entered " + rule.LocationName;
                            string c = rule.Message.Replace(a, b);
                            //Log(b);
                            alarm = true;
                            Alert((int)Utils.WarningState.Alert, rule, c);
                        }
                        else if (oldLocationState == (int)Utils.LocationState.In &&
                            rule.Distance > 0)
                        {
                            string b = "have left " + rule.LocationName;
                            string c = rule.Message.Replace(a, b);
                            //Log(b);
                            alarm = true;
                            Alert((int)Utils.WarningState.Alert, rule, c);
                        }
                        else if (rule.Distance < 0)
                        {
                            string b = "are inside " + rule.LocationName;
                            string c = rule.Message.Replace(a, b);
                            //Log(b);
                            alarm = true;
                            Alert((int)Utils.WarningState.Warning, rule, c);
                        }
                        else
                        {
                            ////Log("Safe");
                            Alert((int)Utils.WarningState.Safe, rule);
                        }
                    }
                    else
                    {
                        alarm = true;
                        Alert((int)Utils.WarningState.Safe, rule);
                    }
                }

                if (alarm)
                {
                    break;
                }
            }

            // This code implements the origin - if there's no other alarm
            //if (!alarm && Utils.Distance > radius && radius > 0)
            //{
            //    Alert((int)Utils.WarningState.Warning, null);
            //}

            if (!alarm)
            {
                StopBarp();
            }
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
                _txtDistance.Text = Utils.Distance.ToString("#.###");
                _txtDistance.SetTextColor(Color.ParseColor("#333333"));
                _imageViewInOut.SetImageResource(Resource.Drawable.Gray);
                _toolbar.SetBackgroundColor(Color.ParseColor("#2196f3"));
                Utils.BarpLooped = false;
                Utils.SMSSent = false;
                StopBarp();
            }
            else if (warningState == (int)Utils.WarningState.Warning)
            {
                _imageViewInOut.SetImageResource(Resource.Drawable.Orange);
                _toolbar.SetBackgroundColor(Color.ParseColor("#ff9a15"));
                _txtDistance.SetTextColor(Color.ParseColor("#ff9a15"));
                _txtDistance.Text = "WARNING";
                Utils.SMSSent = false;

                if (!Utils.BarpPlayed)
                {
                    Utils.BarpPlayed = true;
                    _barp.Start();
                }

                StopBarp();
            }
            else if (warningState == (int)Utils.WarningState.Alert)
            {
                _imageViewInOut.SetImageResource(Resource.Drawable.Red);
                _toolbar.SetBackgroundColor(Color.ParseColor("#ff0909"));
                _txtDistance.SetTextColor(Color.ParseColor("#ff0909"));
                _txtDistance.Text = "ALERT";
                if (!Utils.BarpLooped)
                {
                    Utils.BarpLooped = true;

                    _barpTime = new Timer(
                        new TimerCallback(TickTimer),
                        null,
                        1000,
                        1000);

                    _buttonMute.Visibility = ViewStates.Visible;
                }
                Utils.BarpPlayed = false;

                // Send an SMS
                if (Utils.Mobile.Length > 0 && !Utils.SMSSent)
                {
                    //double radius = Utils.DblParse(Utils.Radius);

                    //if (Utils.Distance > radius && radius > 0) // Radius alert
                    //{
                    //    PendingIntent sentPI;
                    //    String SENT = "SMS_SENT";
                    //    sentPI = PendingIntent.GetBroadcast(this, 0, new Intent(SENT), 0);

                    //    string smsContent = "Coronalert alert. " + Utils.Name +
                    //        " is " +
                    //        Utils.Distance.ToString("0.###") +
                    //        " km from " +
                    //        _txtStartLocation + " " +
                    //        _txtStartAddress;

                    //    SmsManager.Default.SendTextMessage(
                    //        Utils.Mobile.Replace(" ", string.Empty),
                    //        null,
                    //        smsContent,
                    //        sentPI,
                    //        null);

                    //    Utils.SMSSent = true;
                    //}
                }
            }
        }

        void StopBarp()
        {
            if (_barpTime != null)
            {
                _barpTime.Change(Timeout.Infinite, Timeout.Infinite);
            }
            _buttonMute.Visibility = ViewStates.Gone;
        }

        //public string GetAddress(double latitude, double longitude)
        //{
        //    string address = string.Empty;

        //    try
        //    {
        //        Geocoder geocoder = new Geocoder(this);

        //        IList<Address> addressList = geocoder.GetFromLocation(latitude, longitude, 1);

        //        Address addressCurrent = addressList.FirstOrDefault();

        //        if (addressCurrent != null)
        //        {
        //            StringBuilder deviceAddress = new StringBuilder();

        //            for (int i = 0; i <= addressCurrent.MaxAddressLineIndex; i++)
        //            {
        //                if (addressCurrent.GetAddressLine(i).Length > 0)
        //                {
        //                    deviceAddress.Append(addressCurrent.GetAddressLine(i)).AppendLine(",");
        //                }
        //            }

        //            address = deviceAddress.ToString().Replace(System.Environment.NewLine, string.Empty).TrimEnd(',');
        //        }
        //    }
        //    catch
        //    {
        //        address = "Can't get address. Are you online?";
        //    }

        //    return address;
        //}

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
                        // First time in, set some defaults $$$
                        if (Utils.StartLocation.Latitude == 0 && Utils.StartLocation.Longitude == 0)
                        {
                            ISharedPreferences prefs = PreferenceManager.GetDefaultSharedPreferences(this);
                            Utils.StartLocation = Utils.Location;

                            ISharedPreferencesEditor editor = prefs.Edit();

                            editor.PutFloat("StartLatitude", (float)Utils.StartLocation.Latitude);
                            editor.PutFloat("StartLongitude", (float)Utils.StartLocation.Longitude);
                            editor.Apply();

                            _txtStartAddress = Utils.GetAddress(_instance);
                        }
                        
                        _txtLocation = String.Format("{0:0.####},{1:0.####}", Utils.StartLocation.Latitude, Utils.StartLocation.Longitude);

                        // This code measures distance from the origin
                        var coord1 = new LatLng(Utils.StartLocation.Latitude, Utils.StartLocation.Longitude);
                        var coord2 = new LatLng(Utils.Location.Latitude, Utils.Location.Longitude);

                        Utils.HaversineDistance(coord1, coord2, Utils.DistanceUnit.Kilometers);

                        //Utils.Distance = 10; // Hack

                        _txtDistance.Text = Utils.Distance.ToString("#.###");

                        if (Utils.Distance == 0)
                        {
                            _txtRemarks.Text = string.Format("You are at your origin, ");
                        }
                        else
                        {
                            _txtRemarks.Text = "You are " + Utils.Distance.ToString("0.###") + " km from your origin, ";
                        }

                        _txtRemarks.Text += _txtStartAddress;

                        Utils.PreviousLocation = location;

                        // This code measures distance wrt rules
                        foreach (Rule rule in Utils.Rules)
                        {
                            if (rule.LocationType == (int)Utils.LocationType.Radius)
                            {
                                coord1 = new LatLng((double)rule.MapLatitude, (double)rule.MapLongitude);
                                rule.Distance = Utils.HaversineDistance(coord1, coord2);
                            }
                            else if (rule.LocationType == (int)Utils.LocationType.Polygon && rule.Polygon.Length > 0)
                            {
                                string payload = new string(rule.Polygon.Where(c => !char.IsControl(c)).ToArray());
                                int startIndex = payload.IndexOf("<coordinates>");
                                int endIndex = payload.IndexOf("</coordinates>");
                                payload = payload.Substring(startIndex + 13, endIndex - startIndex - 13)
                                    .Replace(",0", ",")
                                    .Replace(" ", "")
                                    .Trim(',');

                                double[] doubles = Array.ConvertAll(payload.Split(','), double.Parse);

                                List<GeographicalPoint> points = new List<GeographicalPoint>();

                                for (int i = 0; i <= doubles.Length - 1; i += 2)
                                {
                                    points.Add(new GeographicalPoint(doubles[i + 1], doubles[i]));
                                }

                                Polygon polygon = new Polygon(points);
                                GeographicalPoint point = new GeographicalPoint(coord2.Latitude, coord2.Longitude);

                                // Negative int.MaxValue distance in a polygon rule means we're inside the shape $$$ we need code for nested polygons
                                // Otherwise we point it at space
                                // That means [for now] polygons get processed before radius rules
                                // We'll move to a system where all the trigered rules are processed
                                rule.Distance = polygon.Contains(point) ? int.MaxValue * -1 : int.MaxValue;
                            }
                            else
                            {
                                rule.Distance = int.MaxValue;
                            }
                        }

                        // Reduce the rules to undismissed ones
                        Utils.Rules = Utils.Rules.Where(x => !x.Dismissed).ToList();

                        if (Utils.Rules.Count > 0)
                        {
                            Utils.Rules = Utils.Rules.OrderBy(x => x.Distance - x.RadiusK).ToList();

                            if (Utils.Rules[0].LocationType == (int)Utils.LocationType.Radius)
                            {
                                decimal realDistance = Utils.Rules[0].Distance - Utils.Rules[0].RadiusK;
                                if (realDistance > 0)
                                {
                                    _txtRemarks.Text +=
                                        Environment.NewLine +
                                        Environment.NewLine +
                                        "You are " +
                                        realDistance.ToString("0") +
                                        " km from the closest exclusion zone, " +
                                        Utils.Rules[0].LocationName +
                                        ". Coronalert will continue to monitor your position, and tell you when you are within " +
                                        Utils.Rules[0].WarnK.ToString("0.###") +
                                        " km of its " +
                                        Utils.Rules[0].RadiusK.ToString("0.###") +
                                        " km radius.";
                                }
                            }
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
                else if (item.ItemId == Resource.Id.menu_snap)
                {
                    ISharedPreferences prefs = PreferenceManager.GetDefaultSharedPreferences(this);
                    Utils.DoSnap(prefs);
                    _txtStartAddress = Utils.GetAddress(_instance);
                    if (Utils.Distance == 0)
                    {
                        _txtRemarks.Text = string.Format("You are at your origin, ");
                    }
                    else
                    {
                        _txtRemarks.Text = "You are " + Utils.Distance.ToString("0.###") + " km from your origin, ";
                    }
                    _txtRemarks.Text += _txtStartAddress;
                    Toast.MakeText(this, "Saved", ToastLength.Short).Show();
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

