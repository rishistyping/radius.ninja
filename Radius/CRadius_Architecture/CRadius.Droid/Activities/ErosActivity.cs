using Android.App;
using Android.OS;
using Android.Util;
using Android.Widget;
using CRadius.Droid.ninja.radius;
using System;
using System.Threading.Tasks;

namespace CRadius.Droid
{
    [Activity(Label = "Eros", Theme = "@style/MyTheme")]
    public class ErosActivity : Activity
    {
        static readonly string TAG = "X:" + typeof(ErosActivity).Name;

        Button _buttonExit;
        TextView _textViewMessage;
        TextView _textViewStackTrace;

        Radius _proxy = new Radius();

        protected override void OnCreate(Bundle bundle)
        {
            try
            {
                base.OnCreate(bundle);

                SetContentView(Resource.Layout.Eros);

                _buttonExit = FindViewById<Button>(Resource.Id.buttonExit);
                _textViewMessage = FindViewById<TextView>(Resource.Id.textViewMessage);
                _textViewStackTrace = FindViewById<TextView>(Resource.Id.textViewStackTrace);

                _textViewMessage.Text = Utils.Eros.Message;

                _textViewStackTrace.Text = Utils.Eros.StackTrace;

                Log.Debug(TAG, "*** Error: " + Utils.Eros.Message);
                Log.Debug(TAG, "*** Stack Trace: " + Utils.Eros.StackTrace);

                _buttonExit.Click += HandleButtonExit;

                Task.Run(() =>
                {
                    DoError();
                });

            }
            catch
            {
            }
        }

        protected override void OnResume()
        {
            base.OnResume();
        }

        void DoError()
        {
            try
            {
                //_proxy.DoErrorAsync(
                //    Utils.Username,
                //    Utils.Password,
                //    Utils.Eros.Message,
                //    string.Empty,
                //    Utils.Eros.StackTrace);
            }
            catch
            {
            }
        }

        void HandleButtonExit(object sender, EventArgs ea)
        {
            System.Environment.Exit(0);
        }
    }
}