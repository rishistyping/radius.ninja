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
                        locationRuleView.LocationName));
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

