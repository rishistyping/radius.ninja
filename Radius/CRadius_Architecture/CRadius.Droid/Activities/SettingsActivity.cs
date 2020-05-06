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
        EditText _editTextMobile;
        EditText _editTextName;

        Button _buttonSave;

        public static SettingsActivity _instance;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            _instance = this;

            SetContentView(Resource.Layout.Settings);

            var toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
            toolbar.Title = string.Empty;
            SetActionBar(toolbar);

            _editTextMobile = FindViewById<EditText>(Resource.Id.editTextMobile);
            _editTextMobile.Text = Utils.Mobile;

            //_editTextEmail = FindViewById<EditText>(Resource.Id.editTextEmail);
            //_editTextEmail = Utils.Email;

            _editTextName = FindViewById<EditText>(Resource.Id.editTextName);
            _editTextName.Text = Utils.Name;

            _buttonSave = FindViewById<Button>(Resource.Id.buttonSave);
            _buttonSave.Click += delegate {
                SavePreferences();
            };
        }

        void SavePreferences()
        {
            new Thread(() =>
            {
                ISharedPreferences prefs = PreferenceManager.GetDefaultSharedPreferences(this);
                ISharedPreferencesEditor editor = prefs.Edit();

                Utils.Mobile = _editTextMobile.Text;
                Utils.Name = _editTextName.Text;

                editor.PutString("Mobile", _editTextMobile.Text);
                editor.PutString("Name", _editTextName.Text);

                editor.Apply();

                RunOnUiThread(() =>
                {
                    Toast.MakeText(this, "Saved", ToastLength.Short).Show();
                    Utils.SMSSent = false;
                    StartActivity(new Intent(Application.Context, typeof(MainActivity)));
                });
            }).Start();

            StartActivity(new Intent(Application.Context, typeof(MainActivity)));
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
                else if (item.ItemId == Resource.Id.menu_snap)
                {
                    ISharedPreferences prefs = PreferenceManager.GetDefaultSharedPreferences(this);
                    Utils.DoSnap(prefs);
                    Toast.MakeText(this, "Saved", ToastLength.Short).Show();
                    StartActivity(new Intent(Application.Context, typeof(MainActivity)));
                }
            }
            catch (Exception ex)
            {
                Toast.MakeText(this, ex.Message, ToastLength.Long).Show();
            }

            return base.OnOptionsItemSelected(item);
        }
    }
}