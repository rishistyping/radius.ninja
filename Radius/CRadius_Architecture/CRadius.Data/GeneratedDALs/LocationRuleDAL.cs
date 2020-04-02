using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using Sodium.Data;
using Sodium.Utilities;

namespace CRadius.Data.DAL
{
	public class LocationRuleDAL
	{
		#region Fields

		protected string connectionStringName;

		#endregion

		#region Constructors

		public LocationRuleDAL(string connectionStringName)
		{
			ValidationUtility.ValidateArgument("connectionStringName", connectionStringName);

			this.connectionStringName = connectionStringName;
		}

		#endregion

		#region Methods

		/// <summary>
		/// Saves a record to the LocationRule table.
		/// </summary>
		public virtual void Insert(LocationRule locationRule)
		{
			ValidationUtility.ValidateArgument("locationRule", locationRule);

			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@Code", locationRule.Code),
				new SqlParameter("@LocationID", locationRule.LocationID),
				new SqlParameter("@RuleID", locationRule.RuleID),
				new SqlParameter("@IsActive", locationRule.IsActive),
				new SqlParameter("@Comments", locationRule.Comments),
				new SqlParameter("@InternalComment", locationRule.InternalComment),
				new SqlParameter("@CreatedBy", locationRule.CreatedBy),
				new SqlParameter("@CreatedOn", locationRule.CreatedOn),
				new SqlParameter("@AuditActionBy", locationRule.AuditActionBy),
				new SqlParameter("@AuditActionOn", locationRule.AuditActionOn)
			};

			locationRule.ID = Convert.ToInt32(SqlClientUtility.ExecuteScalar(connectionStringName, CommandType.StoredProcedure, "LocationRuleInsert", parameters));
		}

		/// <summary>
		/// Updates a record in the LocationRule table.
		/// </summary>
		public virtual void Update(LocationRule locationRule)
		{
			ValidationUtility.ValidateArgument("locationRule", locationRule);

			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@ID", locationRule.ID),
				new SqlParameter("@Code", locationRule.Code),
				new SqlParameter("@LocationID", locationRule.LocationID),
				new SqlParameter("@RuleID", locationRule.RuleID),
				new SqlParameter("@IsActive", locationRule.IsActive),
				new SqlParameter("@Comments", locationRule.Comments),
				new SqlParameter("@InternalComment", locationRule.InternalComment),
				new SqlParameter("@CreatedBy", locationRule.CreatedBy),
				new SqlParameter("@CreatedOn", locationRule.CreatedOn),
				new SqlParameter("@AuditActionBy", locationRule.AuditActionBy),
				new SqlParameter("@AuditActionOn", locationRule.AuditActionOn)
			};

			SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "LocationRuleUpdate", parameters);
		}

		/// <summary>
		/// Deletes a record from the LocationRule table by its primary key.
		/// </summary>
		public virtual void Delete(int iD)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@ID", iD)
			};

			SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "LocationRuleDelete", parameters);
		}

		/// <summary>
		/// Deletes a record from the LocationRule table by a foreign key.
		/// </summary>
		public virtual void DeleteAllByLocationID(int locationID)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@LocationID", locationID)
			};

			SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "LocationRuleDeleteAllByLocationID", parameters);
		}

		/// <summary>
		/// Deletes a record from the LocationRule table by a foreign key.
		/// </summary>
		public virtual void DeleteAllByRuleID(int ruleID)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@RuleID", ruleID)
			};

			SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "LocationRuleDeleteAllByRuleID", parameters);
		}

		/// <summary>
		/// Selects a single record from the LocationRule table.
		/// </summary>
		public virtual LocationRule Select(int iD)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@ID", iD)
			};

			using (SqlDataReader dataReader = SqlClientUtility.ExecuteReader(connectionStringName, CommandType.StoredProcedure, "LocationRuleSelect", parameters))
			{
				if (dataReader.Read())
				{
					return MakeLocationRule(dataReader);
				}
				else
				{
					return null;
				}
			}
		}

		/// <summary>
		/// Selects all records from the LocationRule table.
		/// </summary>
		public virtual List<LocationRule> SelectAll()
		{
			using (SqlDataReader dataReader = SqlClientUtility.ExecuteReader(connectionStringName, CommandType.StoredProcedure, "LocationRuleSelectAll"))
			{
				List<LocationRule> locationRuleList = new List<LocationRule>();
				while (dataReader.Read())
				{
					LocationRule locationRule = MakeLocationRule(dataReader);
					locationRuleList.Add(locationRule);
				}
				dataReader.Close();

				return locationRuleList;
			}
		}

		/// <summary>
		/// Selects all records from the LocationRule table by a foreign key.
		/// </summary>
		public virtual List<LocationRule> SelectAllByLocationID(int locationID)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@LocationID", locationID)
			};

			using (SqlDataReader dataReader = SqlClientUtility.ExecuteReader(connectionStringName, CommandType.StoredProcedure, "LocationRuleSelectAllByLocationID", parameters))
			{
				List<LocationRule> locationRuleList = new List<LocationRule>();
				while (dataReader.Read())
				{
					LocationRule locationRule = MakeLocationRule(dataReader);
					locationRuleList.Add(locationRule);
				}

				return locationRuleList;
			}
		}

		/// <summary>
		/// Selects all records from the LocationRule table by a foreign key.
		/// </summary>
		public virtual List<LocationRule> SelectAllByRuleID(int ruleID)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@RuleID", ruleID)
			};

			using (SqlDataReader dataReader = SqlClientUtility.ExecuteReader(connectionStringName, CommandType.StoredProcedure, "LocationRuleSelectAllByRuleID", parameters))
			{
				List<LocationRule> locationRuleList = new List<LocationRule>();
				while (dataReader.Read())
				{
					LocationRule locationRule = MakeLocationRule(dataReader);
					locationRuleList.Add(locationRule);
				}

				return locationRuleList;
			}
		}

		/// <summary>
		/// Creates a new instance of the LocationRule class and populates it with data from the specified SqlDataReader.
		/// </summary>
		protected virtual LocationRule MakeLocationRule(SqlDataReader dataReader)
		{
			LocationRule locationRule = new LocationRule();
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

			return locationRule;
		}

		#endregion
	}
}
