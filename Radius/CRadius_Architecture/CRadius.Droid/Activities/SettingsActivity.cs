using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Preferences;
using Android.Views;
using Android.Widget;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CRadius.Droid
{
    [Activity(Label = "Settings", 
        Icon = "@drawable/icon", 
        Theme = "@style/MyTheme", 
        ScreenOrientation = ScreenOrientation.Portrait)]
    public class SettingsActivity : Activity
    {
        EditText _editTextRadius;
        EditText _editTextMobile;
        EditText _editTextEmail;
        EditText _editTextName;

        Button _buttonSave;
        Button _buttonCancel;

        public static SettingsActivity _instance;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            _instance = this;

            SetContentView(Resource.Layout.Settings);

            var toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
            toolbar.Title = string.Empty;
            SetActionBar(toolbar);

            _editTextRadius = FindViewById<EditText>(Resource.Id.editTextRadius);
            _editTextRadius.Text = Utils.Radius;

            _editTextRadius.SetSelection(_editTextRadius.Text.Length);

            _editTextMobile = FindViewById<EditText>(Resource.Id.editTextMobile);
            _editTextMobile.Text = Utils.Mobile;

            _editTextEmail = FindViewById<EditText>(Resource.Id.editTextEmail);
            _editTextEmail.Text = Utils.Email;

            _editTextName = FindViewById<EditText>(Resource.Id.editTextName);
            _editTextName.Text = Utils.Name;

            _buttonSave = FindViewById<Button>(Resource.Id.buttonSave);
            _buttonSave.Click += delegate {
                SavePreferences();
            };

            _buttonCancel = FindViewById<Button>(Resource.Id.buttonCancel);
            _buttonCancel.Click += delegate {
                this.Finish();
                //StartActivity(new Intent(Application.Context, typeof(MainActivity)));
            };
        }

        void SavePreferences()
        {
            new Thread(() =>
            {
                ISharedPreferences prefs = PreferenceManager.GetDefaultSharedPreferences(this);
                ISharedPreferencesEditor editor = prefs.Edit();

                Utils.Radius = _editTextRadius.Text;
                Utils.Mobile = _editTextMobile.Text;
                Utils.Email = _editTextEmail.Text;
                Utils.Name = _editTextName.Text;

                editor.PutString("Radius", _editTextRadius.Text);
                editor.PutString("Mobile", _editTextMobile.Text);
                editor.PutString("Email", _editTextEmail.Text);
                editor.PutString("Name", _editTextName.Text);

                editor.Apply();

                RunOnUiThread(() =>
                {
                    Toast.MakeText(this, "Saved", ToastLength.Short).Show();
                    StartActivity(new Intent(Application.Context, typeof(MainActivity)));
                });
            }).Start();
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
                if (item.ItemId == Resource.Id.menu_console)
                {
                    StartActivity(new Intent(Application.Context, typeof(MainActivity)));
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

        //async void HandshakeAsync()
        //{
        //    try
        //    {
        //        _serverHasResponded = false;

        //        _proxy.HandshakeAsync(
        //            Utils.Username,
        //            ApplicationInfo.LoadLabel(PackageManager));

        //        await Task.Delay(TimeSpan.FromSeconds(_wait));

        //        RunOnUiThread(() =>
        //        {
        //            if (!_serverHasResponded)
        //            {
        //                Toast.MakeText(this, "Slow web service response.", ToastLength.Long).Show();
        //            }
        //        });
        //    }
        //    catch (Exception ex)
        //    {
        //        RunOnUiThread(() =>
        //        {
        //            Utils.Eros = ex;
        //            StartActivity(new Intent(Application.Context, typeof(ErosActivity)));
        //        });
        //    }
        //}

        //void HandshakeCompleted(object sender, HandshakeCompletedEventArgs e)
        //{
        //    try
        //    {
        //        _serverHasResponded = true;

        //        RadiusPayload payload = e.Result;

        //        if (payload.Error)
        //        {
        //            Utils.Username = string.Empty;

        //            ISharedPreferences prefs = PreferenceManager.GetDefaultSharedPreferences(this);
        //            ISharedPreferencesEditor editor = prefs.Edit();
        //            editor.PutString("Username", string.Empty);
        //            editor.Apply();

        //            RunOnUiThread(() =>
        //            {
        //                if (payload.Fatal)
        //                {
        //                    Utils.Eros = new Exception(payload.Message);
        //                    StartActivity(new Intent(Application.Context, typeof(ErosActivity)));
        //                }
        //                else
        //                {
        //                    Toast.MakeText(this, payload.Message, ToastLength.Long).Show();
        //                }
        //            });
        //        }
        //        else
        //        {
        //            Utils.Radius = payload.Radius.ToString("0.#");
        //            Utils.Mobile = payload.Phone;
        //            Utils.Email = payload.Email;
        //            Utils.Name = payload.FriendlyName;

        //            ISharedPreferences prefs = PreferenceManager.GetDefaultSharedPreferences(this);
        //            ISharedPreferencesEditor editor = prefs.Edit();

        //            editor.PutString("Radius", _editTextRadius.Text);
        //            editor.PutString("Mobile", _editTextMobile.Text);
        //            editor.PutString("Email", _editTextEmail.Text);
        //            editor.PutString("Name", _editTextName.Text);

        //            editor.Apply();

        //            RunOnUiThread(() =>
        //            {
        //                _editTextRadius.Text = Utils.Radius;
        //                _editTextMobile.Text = Utils.Mobile;
        //                _editTextEmail.Text = Utils.Email;
        //                _editTextName.Text = Utils.Name;

        //                Toast.MakeText(this, "Saved", ToastLength.Short).Show();

        //                StartActivity(new Intent(Application.Context, typeof(MainActivity)));
        //            });
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        RunOnUiThread(() =>
        //        {
        //            Utils.Eros = ex;
        //            StartActivity(new Intent(Application.Context, typeof(ErosActivity)));
        //        });
        //    }
        //}
    }
}