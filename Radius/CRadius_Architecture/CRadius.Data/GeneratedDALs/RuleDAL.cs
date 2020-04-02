using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using Sodium.Data;
using Sodium.Utilities;

namespace CRadius.Data.DAL
{
	public class RuleDAL
	{
		#region Fields

		protected string connectionStringName;

		#endregion

		#region Constructors

		public RuleDAL(string connectionStringName)
		{
			ValidationUtility.ValidateArgument("connectionStringName", connectionStringName);

			this.connectionStringName = connectionStringName;
		}

		#endregion

		#region Methods

		/// <summary>
		/// Saves a record to the Rule table.
		/// </summary>
		public virtual void Insert(Rule rule)
		{
			ValidationUtility.ValidateArgument("rule", rule);

			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@Code", rule.Code),
				new SqlParameter("@Name", rule.Name),
				new SqlParameter("@IsActive", rule.IsActive),
				new SqlParameter("@RadiusK", rule.RadiusK),
				new SqlParameter("@WarnK", rule.WarnK),
				new SqlParameter("@Direction", rule.Direction),
				new SqlParameter("@Message", rule.Message),
				new SqlParameter("@Comments", rule.Comments),
				new SqlParameter("@InternalComment", rule.InternalComment),
				new SqlParameter("@CreatedBy", rule.CreatedBy),
				new SqlParameter("@CreatedOn", rule.CreatedOn),
				new SqlParameter("@AuditActionBy", rule.AuditActionBy),
				new SqlParameter("@AuditActionOn", rule.AuditActionOn)
			};

			rule.ID = Convert.ToInt32(SqlClientUtility.ExecuteScalar(connectionStringName, CommandType.StoredProcedure, "RuleInsert", parameters));
		}

		/// <summary>
		/// Updates a record in the Rule table.
		/// </summary>
		public virtual void Update(Rule rule)
		{
			ValidationUtility.ValidateArgument("rule", rule);

			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@ID", rule.ID),
				new SqlParameter("@Code", rule.Code),
				new SqlParameter("@Name", rule.Name),
				new SqlParameter("@IsActive", rule.IsActive),
				new SqlParameter("@RadiusK", rule.RadiusK),
				new SqlParameter("@WarnK", rule.WarnK),
				new SqlParameter("@Direction", rule.Direction),
				new SqlParameter("@Message", rule.Message),
				new SqlParameter("@Comments", rule.Comments),
				new SqlParameter("@InternalComment", rule.InternalComment),
				new SqlParameter("@CreatedBy", rule.CreatedBy),
				new SqlParameter("@CreatedOn", rule.CreatedOn),
				new SqlParameter("@AuditActionBy", rule.AuditActionBy),
				new SqlParameter("@AuditActionOn", rule.AuditActionOn)
			};

			SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "RuleUpdate", parameters);
		}

		/// <summary>
		/// Deletes a record from the Rule table by its primary key.
		/// </summary>
		public virtual void Delete(int iD)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@ID", iD)
			};

			SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "RuleDelete", parameters);
		}

		/// <summary>
		/// Selects a single record from the Rule table.
		/// </summary>
		public virtual Rule Select(int iD)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@ID", iD)
			};

			using (SqlDataReader dataReader = SqlClientUtility.ExecuteReader(connectionStringName, CommandType.StoredProcedure, "RuleSelect", parameters))
			{
				if (dataReader.Read())
				{
					return MakeRule(dataReader);
				}
				else
				{
					return null;
				}
			}
		}

		/// <summary>
		/// Selects all records from the Rule table.
		/// </summary>
		public virtual List<Rule> SelectAll()
		{
			using (SqlDataReader dataReader = SqlClientUtility.ExecuteReader(connectionStringName, CommandType.StoredProcedure, "RuleSelectAll"))
			{
				List<Rule> ruleList = new List<Rule>();
				while (dataReader.Read())
				{
					Rule rule = MakeRule(dataReader);
					ruleList.Add(rule);
				}
				dataReader.Close();

				return ruleList;
			}
		}

		/// <summary>
		/// Creates a new instance of the Rule class and populates it with data from the specified SqlDataReader.
		/// </summary>
		protected virtual Rule MakeRule(SqlDataReader dataReader)
		{
			Rule rule = new Rule();
			rule.ID = SqlClientUtility.GetInt32(dataReader, "ID", 0);
			rule.Code = SqlClientUtility.GetString(dataReader, "Code", String.Empty);
			rule.Name = SqlClientUtility.GetString(dataReader, "Name", String.Empty);
			rule.IsActive = SqlClientUtility.GetBoolean(dataReader, "IsActive", false);
			rule.RadiusK = SqlClientUtility.GetDecimal(dataReader, "RadiusK", Decimal.Zero);
			rule.WarnK = SqlClientUtility.GetDecimal(dataReader, "WarnK", Decimal.Zero);
			rule.Direction = SqlClientUtility.GetInt32(dataReader, "Direction", 0);
			rule.Message = SqlClientUtility.GetString(dataReader, "Message", String.Empty);
			rule.Comments = SqlClientUtility.GetString(dataReader, "Comments", String.Empty);
			rule.InternalComment = SqlClientUtility.GetString(dataReader, "InternalComment", String.Empty);
			rule.CreatedBy = SqlClientUtility.GetString(dataReader, "CreatedBy", String.Empty);
			rule.CreatedOn = SqlClientUtility.GetDateTime(dataReader, "CreatedOn", DateTime.Now);
			rule.AuditActionBy = SqlClientUtility.GetString(dataReader, "AuditActionBy", String.Empty);
			rule.AuditActionOn = SqlClientUtility.GetDateTime(dataReader, "AuditActionOn", DateTime.Now);

			return rule;
		}

		#endregion
	}
}
