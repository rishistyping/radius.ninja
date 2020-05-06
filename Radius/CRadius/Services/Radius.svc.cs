using CRadius.Business;
using CRadius.Data;
using System;
using System.Collections.Generic;

namespace CRadius
{
    public class Radius : IRadius
    {
        const string _connectionStringName = "LiveConnectionString";
        //const string _connectionStringName = "LocalConnectionString";


        public void DoError(
            string errorMessage,
            string innerException,
            string stackTrace)
        {
            try
            {
                List<string> lines = new List<string>();

                Messaging messaging = new Messaging(_connectionStringName);

                lines.Add("<html xmlns='http://www.w3.org/1999/xhtml'>");
                lines.Add("<head>");
                lines.Add("    <style type='text/css'>");
                lines.Add("        p {font-family: Consolas, 'Lucida Console', 'DejaVu Sans Mono', monospace; font-size: medium; }");
                lines.Add("    </style>");
                lines.Add("</head>");
                lines.Add("<body>");

                lines.Add("<p>The following Coronalert app error was logged at " + System.DateTime.Now.ToString() + " </p>");
                lines.Add("<p>Exception.Message:</p>");
                lines.Add("<p>" + errorMessage + "</p>");
                lines.Add("<p>Exception.InnerException:</p>");
                lines.Add("<p>" + innerException + "</p>");
                lines.Add("<p>Exception.StackTrace:</p>");
                lines.Add("<p>" + stackTrace + "</p>");

                messaging.SendErrorEmail(
                    lines,
                    "Coronalert app app");
            }
            catch
            {
            }
        }

        public Payload Handshake()
        {
            Payload payload = new Payload();

            try
            {
                LocationRuleBL locationRuleBL = new LocationRuleBL(_connectionStringName);
                List<LocationRuleView> locationRuleViews = locationRuleBL.LocationRuleViewSelectCurrent();

                payload.Rules = new List<Rule>();

                foreach (LocationRuleView locationRuleView in locationRuleViews)
                {
                    payload.Rules.Add(new Rule(locationRuleView.ID,
                        locationRuleView.MapLatitude,
                        locationRuleView.MapLongitude,
                        locationRuleView.RadiusK,
                        locationRuleView.WarnK,
                        locationRuleView.Direction,
                        locationRuleView.Message,
                        locationRuleView.LocationName,
                        locationRuleView.LocationType,
                        locationRuleView.Polygon));
                }
            }
            catch (Exception ex)
            {
                payload.Showstopper = true;
                payload.Error = true;
                payload.Message = ex.Message + Environment.NewLine + ex.StackTrace;
            }

            return payload;
        }
    }
}

