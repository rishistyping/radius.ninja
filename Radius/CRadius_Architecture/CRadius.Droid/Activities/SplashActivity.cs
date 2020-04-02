using Android.App;
using Android.Content;
using Android.Locations;
using Android.OS;
using Android.Preferences;
using Android.Widget;
using System;
using System.Threading;
using CRadius.Droid.ninja.radius;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace CRadius.Droid
{
    [Activity(Theme = "@style/MyTheme.Splash", NoHistory = true, MainLauncher = true)]
    public class SplashActivity : Activity
    {
        static readonly string TAG = "X:" + typeof (SplashActivity).Name;

        const int _wait = 30;
        bool _serverHasResponded = false;

        Radius _proxy = new Radius();

        public override void OnCreate(Bundle savedInstanceState, PersistableBundle persistentState)
        {
            base.OnCreate(savedInstanceState, persistentState);
        }

        protected override void OnResume()
        {
            base.OnResume();

            Thread myThread = new Thread(delegate ()
            {
                string message = string.Empty; // IsInternetAvailable();
                Utils.Rules = new List<Rule>();

                _proxy.HandshakeCompleted += new HandshakeCompletedEventHandler(HandshakeCompleted);

                if (message.Length > 0)
                {
                    RunOnUiThread(() => {
                        Toast.MakeText(this, message, ToastLength.Long).Show();
                        System.Environment.Exit(0);
                    });
                }
                else
                {
                    RunOnUiThread(() => {
                        if (message.Length > 0)
                        {
                            Toast.MakeText(this, message, ToastLength.Long).Show();
                            System.Environment.Exit(0);
                        }
                        else
                        {
                            Utils.Initialize();

                            try
                            {
                                Utils.Username = string.Empty;
                                Utils.Password = string.Empty;

                                ISharedPreferences prefs = PreferenceManager.GetDefaultSharedPreferences(this);
                                ISharedPreferencesEditor editor = prefs.Edit();

                                Utils.Radius = prefs.GetString("Radius", string.Empty);
                                Utils.Mobile = prefs.GetString("Mobile", string.Empty);
                                Utils.Email = prefs.GetString("Email", string.Empty);
                                Utils.Name = prefs.GetString("Name", string.Empty);

                                Utils.StartLocation = new Location("")
                                {
                                    Latitude = prefs.GetFloat("StartLatitude", (float)51.476852), // Greenwich
                                    Longitude = prefs.GetFloat("StartLongitude", (float)-0.000500)
                                };
                                Utils.Location = new Location("");

                                Task.Run(() =>
                                {
                                    HandshakeAsync();
                                });

                                StartActivity(new Intent(Application.Context, typeof(MainActivity)));
                            }
                            catch (Exception ex)
                            {
                                RunOnUiThread(() =>
                                {
                                    DoEros(ex);
                                });
                            }
                        }
                    });
                }
            });
            myThread.Start();
        }

        void DoEros(Exception ex)
        {
            Utils.Eros = ex;
            StartActivity(new Intent(Application.Context, typeof(ErosActivity)));
        }

        // Prevent the back button from canceling the startup process
        public override void OnBackPressed() { }

        async void HandshakeAsync()
        {
            try
            {
                _serverHasResponded = false;

                _proxy.HandshakeAsync();

                await Task.Delay(TimeSpan.FromSeconds(_wait));

                RunOnUiThread(() =>
                {
                    if (!_serverHasResponded)
                    {
                        Toast.MakeText(this, "Working...", ToastLength.Long).Show();
                    }
                });
            }
            catch (Exception ex)
            {
                RunOnUiThread(() =>
                {
                    DoEros(ex);
                });
            }
        }

        void HandshakeCompleted(object sender, HandshakeCompletedEventArgs e)
        {
            try
            {
                _serverHasResponded = true;

                Payload payload = e.Result;

                if (payload.Error)
                {
                    RunOnUiThread(() =>
                    {
                        Toast.MakeText(this, payload.Message, ToastLength.Long).Show();
                    });
                }
                else
                {
                    Utils.Rules = new System.Collections.Generic.List<Rule>();
                    foreach (Rule rule in payload.Rules)
                    {
                        Utils.Rules.Add(rule);
                    }
                }
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
}