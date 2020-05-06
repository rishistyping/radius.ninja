using Android.App;
using Android.Content;
using Android.Locations;
using CRadius.Droid.ninja.radius;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace CRadius.Droid
{
    static class Utils
    {
        public static string Version = "Version 0.6";

        public static Rule Rule;
        public static Location Location;
        public static Location PreviousLocation;
        public static Location StartLocation;
        public static bool Registered = false;
        public static double Distance;
        public static string Username;
        public static bool SMSSent;
        public static bool BarpPlayed;
        public static bool BarpLooped;
        public static string Mobile;
        public static string Name;
        public static Exception Eros;
        public static string StartAddress;

        public static List<Rule> Rules;

        public static readonly string MasterIdentity = "Coronalert";

        public static string Password { get; set; }

        public enum DistanceUnit { Miles, Kilometers };

        public static void Initialize()
        {
        }

        public static void DoSnap(ISharedPreferences prefs)
        {
            Utils.StartLocation = Utils.Location;
            Utils.Distance = 0;

            ISharedPreferencesEditor editor = prefs.Edit();

            editor.PutFloat("StartLatitude", (float)Utils.StartLocation.Latitude);
            editor.PutFloat("StartLongitude", (float)Utils.StartLocation.Longitude);
            editor.PutString("TagId", string.Empty);
            editor.Apply();

            Utils.BarpPlayed = false;
            Utils.BarpLooped = false;
            Utils.SMSSent = false;
        }

        public static string GetAddress(Activity instance)
        {
            string address = string.Empty;

            try
            {
                Geocoder geocoder = new Geocoder(instance);

                IList<Address> addressList = geocoder.GetFromLocation(StartLocation.Latitude, StartLocation.Longitude, 1);

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

                    address = deviceAddress.ToString().Replace(System.Environment.NewLine, string.Empty).TrimEnd(',') + ".";
                }
            }
            catch
            {
                address = "Can't get address. Are you online?";
            }

            StartAddress = address;
            return address;
        }

        public static string DbPath
        {
            get { return Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "coronalert.db3"); }
        }

        public static double DblParse(string instring)
        {
            double outDouble = 0;
            if (Double.TryParse(instring, out outDouble)) return outDouble;
            if (Double.TryParse(instring, System.Globalization.NumberStyles.Currency, null, out outDouble)) return outDouble;
            return 0;
        }

        public static double ToRadian(this double value)  
        {  
            return (Math.PI / 180) * value;  
        }  

        public static void HaversineDistance(LatLng coord1, LatLng coord2, DistanceUnit unit)  
        {  
            double R = (unit == DistanceUnit.Miles) ? 3960 : 6371;  
            var lat = (coord2.Latitude - coord1.Latitude).ToRadian();  
            var lng = (coord2.Longitude - coord1.Longitude).ToRadian();  
  
            var h1 = Math.Sin(lat / 2) * Math.Sin(lat / 2) +  
                     Math.Cos(coord1.Latitude.ToRadian()) * Math.Cos(coord2.Latitude.ToRadian()) *  
                     Math.Sin(lng / 2) * Math.Sin(lng / 2);  
  
            var h2 = 2 * Math.Asin(Math.Min(1, Math.Sqrt(h1)));

            Distance = R * h2;
        }

        public static decimal HaversineDistance(LatLng coord1, LatLng coord2)
        {
            DistanceUnit unit = Utils.DistanceUnit.Kilometers;

            double R = (unit == DistanceUnit.Miles) ? 3960 : 6371; // Redundant
            var lat = (coord2.Latitude - coord1.Latitude).ToRadian();
            var lng = (coord2.Longitude - coord1.Longitude).ToRadian();

            var h1 = Math.Sin(lat / 2) * Math.Sin(lat / 2) +
                     Math.Cos(coord1.Latitude.ToRadian()) * Math.Cos(coord2.Latitude.ToRadian()) *
                     Math.Sin(lng / 2) * Math.Sin(lng / 2);

            var h2 = 2 * Math.Asin(Math.Min(1, Math.Sqrt(h1)));

            decimal d = (decimal)(R * h2);

            return d;
        }

        public enum LocationType
        {
            None = 0,
            Radius = 1,
            Polygon = 2,
        }

        public enum Direction
        {
            Cross = 0,
            Enter = 1,
            Leave = 2,
        }

        public enum LocationState
        {
            Out = 0,
            In = 1,
            Outbound = 2,
            Inbound = 3,
        }

        public enum WarningState
        {
            None = 0,
            Safe = 1,
            Warning = 2,
            Alert = 3,
        }
    }
}