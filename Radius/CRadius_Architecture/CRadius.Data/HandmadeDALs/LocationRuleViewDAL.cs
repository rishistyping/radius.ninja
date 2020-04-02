using Sodium.Data;
using Sodium.Utilities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

namespace CRadius.Data.DAL
{
	public class LocationRuleViewDAL
	{
		#region Fields

		protected string connectionStringName;

		#endregion

		#region Constructors

        public LocationRuleViewDAL(string connectionStringName)
		{
			ValidationUtility.ValidateArgument("connectionStringName", connectionStringName);

			this.connectionStringName = connectionStringName;
		}

		#endregion

        #region Methods

        public virtual List<LocationRuleView> LocationRuleViewSelectCurrent()
        {
            using (SqlDataReader dataReader = SqlClientUtility.ExecuteReader(connectionStringName, CommandType.StoredProcedure, "_LocationRuleViewSelectCurrent"))
            {
                List<LocationRuleView> locationRuleList = new List<LocationRuleView>();
                while (dataReader.Read())
                {
                    LocationRuleView locationRule = MakeLocationRuleView(dataReader);
                    locationRuleList.Add(locationRule);
                }

                return locationRuleList;
            }
        }

        protected virtual LocationRuleView MakeLocationRuleView(SqlDataReader dataReader)
        {
            LocationRuleView locationRule = new LocationRuleView();

            // Table columns
            locationRule.ID = SqlClientUtility.GetInt32(dataReader, "ID", 0);
            locationRule.Code = SqlClientUtility.GetString(dataReader, "Code", String.Empty);
            locationRule.LocationID = SqlClientUtility.GetInt32(dataReader, "LocationID", 0);
            locationRule.RuleID = SqlClientUtility.GetInt32(dataReader, "RuleID", 0);
            locationRule.IsActive = SqlClientUtility.GetBoolean(dataReader, "IsActive", false);
            locationRule.Comments = SqlClientUtility.GetString(dataReader, "Comments", String.Empty);
            locationRule.InternalComment = SqlClientUtility.GetString(dataReader, "InternalComment", String.Empty);
            locationRule.CreatedBy = SqlClientUtility.GetString(dataReader, "CreatedBy", String.Empty);
            locationRule.CreatedOn = SqlClientUtility.GetDateTime(dataReader, "CreatedOn", DateTime.Now);
            locationRule.AuditActionBy = SqlClientUtility.GetString(dataReader, "AuditActionBy", String.Empty);
            locationRule.AuditActionOn = SqlClientUtility.GetDateTime(dataReader, "AuditActionOn", DateTime.Now);

            // Extended columns from view
            locationRule.MapLatitude = SqlClientUtility.GetDecimal(dataReader, "MapLatitude", 0);
            locationRule.MapLongitude = SqlClientUtility.GetDecimal(dataReader, "MapLongitude", 0);
            locationRule.RadiusK = SqlClientUtility.GetDecimal(dataReader, "RadiusK", 0);
            locationRule.WarnK = SqlClientUtility.GetDecimal(dataReader, "WarnK", 0);
            locationRule.Direction = SqlClientUtility.GetInt32(dataReader, "Direction", 0);
            locationRule.Message = SqlClientUtility.GetString(dataReader, "Message", String.Empty);
            locationRule.LocationName = SqlClientUtility.GetString(dataReader, "LocationName", String.Empty);

            return locationRule;
        }

        #endregion
	}
}
