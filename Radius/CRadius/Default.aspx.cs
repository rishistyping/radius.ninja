using CRadius.Business;
using CRadius.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Xml.Linq;

public partial class Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //string kml2 = File.ReadAllText(@"C:\Users\wu\OneDrive\Documents\_Radius\Peoples Republic of Mandurah.kml", Encoding.UTF8);

        if (!IsPostBack)
        {
            LocationRuleBL locationRuleBL = new LocationRuleBL(Application["ConnectionStringName"].ToString());
            List<LocationRuleView> locationRuleViews = locationRuleBL.LocationRuleViewSelectCurrent();

            foreach(LocationRuleView locationRuleView in locationRuleViews)
            {
                if (locationRuleView.LocationType == (int)Enumerators.LocationType.Polygon &&
                    locationRuleView.Polygon.Length > 0)
                {
                    locationRuleView.Polygon = new string(locationRuleView.Polygon.Where(c => !char.IsControl(c)).ToArray());
                    int startIndex = locationRuleView.Polygon.IndexOf("<coordinates>");
                    int endIndex = locationRuleView.Polygon.IndexOf("</coordinates>");
                    locationRuleView.Polygon = locationRuleView.Polygon.Substring(startIndex + 13, endIndex - startIndex - 13)
                        .Replace(",0", ",")
                        .Replace(" ", "")
                        .Trim(',');

                    double[] doubles = Array.ConvertAll(locationRuleView.Polygon.Split(','), double.Parse);

                    List<GeographicalPoint> points = new List<GeographicalPoint>();

                    for (int i = 0; i <= doubles.Length - 1; i += 2)
                    {
                        points.Add(new GeographicalPoint(doubles[i + 1], doubles[i]));
                    }

                    Polygon polygon = new Polygon(points);
                    GeographicalPoint location = new GeographicalPoint(-32.521050, 115.716910); // my house
                    bool contains = polygon.Contains(location);
                }
            }

            string kml = File.ReadAllText(@"C:\Users\wu\OneDrive\Documents\_Radius\Peoples Republic of Mandurah.kml", Encoding.UTF8);
            string pairs2 = new string(kml.Where(c => !char.IsControl(c)).ToArray());

            //int startIndex = kml.IndexOf("<coordinates>");
            //int endIndex = kml.IndexOf("</coordinates>");
            //string pairs = kml.Substring(startIndex + 13, endIndex - startIndex - 13);
            //pairs = pairs.Replace(",0", ",").Trim(',');
            //pairs = pairs.Replace(" ", "");
            ////pairs = pairs.Replace(@"\n", "");
            ////pairs = pairs.Replace(@"\t", "");
            //pairs2 = new string(pairs.Where(c => !char.IsControl(c)).ToArray());
        }
    }

    protected void ButtonSignIn_Click(object sender, EventArgs e)
    {
    }
}