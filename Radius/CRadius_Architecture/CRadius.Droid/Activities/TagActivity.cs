using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Preferences;
using Android.Views;
using Android.Widget;
using System;
using System.Threading;

namespace CRadius.Droid
{
    [Activity(Label = "Tag Contents", 
        Icon = "@drawable/icon", 
        Theme = "@style/MyTheme", 
        ScreenOrientation = ScreenOrientation.Portrait)]

    public class TagActivity : Activity
    {
        EditText _txtTagId;

        public static TagActivity _instance;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            _instance = this;

            SetContentView(Resource.Layout.Settings);

            var toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
            toolbar.Title = string.Empty;
            SetActionBar(toolbar);

            _txtTagId = FindViewById<EditText>(Resource.Id.txtTagId);

            try
            {
                _txtTagId.Text = Utils.TagId;
            }
            catch { }
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
                else if (item.ItemId == Resource.Id.menu_settings)
                {
                    StartActivity(new Intent(Application.Context, typeof(SettingsActivity)));
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