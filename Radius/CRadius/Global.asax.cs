using System;
using System.Web;

namespace CRadius
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            string path = Server.MapPath(String.Empty);

            Application["Path"] = path;

            if (path.Contains(@"radius.ninja"))
            {
                Application["ConnectionStringName"] = "LiveConnectionString";
            }
            else
            {
                Application["ConnectionStringName"] = "LocalConnectionString";
            }
        }
    }
}