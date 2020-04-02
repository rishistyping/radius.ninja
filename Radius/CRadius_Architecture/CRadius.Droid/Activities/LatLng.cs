namespace CRadius.Droid
{
    class LatLng
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public LatLng(double lat, double lng)
        {
            this.Latitude = lat;
            this.Longitude = lng;
        }
    }
}