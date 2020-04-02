using Android.Content;
using Android.Locations;
using CRadius.Droid.ninja.radius;
using System;
using System.Collections.Generic;
using System.IO;

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
        public static bool Started;
        public static double Distance;
        public static string Username;
        public static string Radius = "0";
        public static bool SMSSent;
        public static bool EmailSent;
        public static string Mobile;
        public static string Email;
        public static string Name;
        public static string TagId;
        public static Exception Eros;

        public static List<Rule> Rules;

        public static readonly string MasterIdentity = "Radius";

        public static string Password { get; set; }

        public enum DistanceUnit { Miles, Kilometers };

        public static void Initialize()
        {
        }

        public static string DbPath
        {
            get { return Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "radius.db3"); }
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