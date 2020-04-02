using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using Sodium.Data;
using Sodium.Utilities;

namespace ITree.Data.DAL
{
	public class QtiRowViewDAL
	{
		#region Fields

		protected string connectionStringName;

		#endregion

		#region Constructors

        public QtiRowViewDAL(string connectionStringName)
		{
			ValidationUtility.ValidateArgument("connectionStringName", connectionStringName);

			this.connectionStringName = connectionStringName;
		}

		#endregion

		#region Methods

        public virtual List<QtiRowView> SelectAllByTimesheetID(int subscriberID)
        {
            SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@TimesheetID", subscriberID)
			};

            using (SqlDataReader dataReader = SqlClientUtility.ExecuteReader(connectionStringName, CommandType.StoredProcedure, "_QtiRowViewSelectByTimesheetID", parameters))
            {
                List<QtiRowView> qtiRowViews = new List<QtiRowView>();
                while (dataReader.Read())
                {
                    QtiRowView qtiRowView = MakeQtiRowView(dataReader);
                    qtiRowViews.Add(qtiRowView);
                }

                return qtiRowViews;
            }
        }

        protected virtual QtiRowView MakeQtiRowView(SqlDataReader dataReader)
		{
            QtiRowView qtiRow = new QtiRowView();

            // Table columns
            qtiRow.ID = SqlClientUtility.GetInt32(dataReader, "ID", 0);
            qtiRow.ID = SqlClientUtility.GetInt32(dataReader, "ID", 0);
            qtiRow.TimesheetID = SqlClientUtility.GetInt32(dataReader, "TimesheetID", 0);
            qtiRow.TimeFrom = SqlClientUtility.GetDateTime(dataReader, "TimeFrom", DateTime.Now);
            qtiRow.TimeTo = SqlClientUtility.GetDateTime(dataReader, "TimeTo", DateTime.Now);
            qtiRow.BreakHours = SqlClientUtility.GetDecimal(dataReader, "BreakHours", Decimal.Zero);
            qtiRow.Hours = SqlClientUtility.GetDecimal(dataReader, "Hours", Decimal.Zero);
            qtiRow.Activity = SqlClientUtility.GetString(dataReader, "Activity", String.Empty);
            qtiRow.OvernightStay = SqlClientUtility.GetBoolean(dataReader, "OvernightStay", false);
            qtiRow.Comments = SqlClientUtility.GetString(dataReader, "Comments", String.Empty);
            qtiRow.ProjectPersonID = SqlClientUtility.GetInt32(dataReader, "ProjectPersonID", 0);
            qtiRow.ExpensesAmount = SqlClientUtility.GetDecimal(dataReader, "ExpensesAmount", Decimal.Zero);
            qtiRow.Mileage = SqlClientUtility.GetDecimal(dataReader, "Mileage", Decimal.Zero);
            qtiRow.FromLocationID = SqlClientUtility.GetInt32(dataReader, "FromLocationID", 0);
            qtiRow.ToLocationID = SqlClientUtility.GetInt32(dataReader, "ToLocationID", 0);
            qtiRow.InternalComment = SqlClientUtility.GetString(dataReader, "InternalComment", String.Empty);
            qtiRow.CreatedBy = SqlClientUtility.GetString(dataReader, "CreatedBy", String.Empty);
            qtiRow.CreatedOn = SqlClientUtility.GetDateTime(dataReader, "CreatedOn", DateTime.Now);
            qtiRow.AuditActionBy = SqlClientUtility.GetString(dataReader, "AuditActionBy", String.Empty);
            qtiRow.AuditActionOn = SqlClientUtility.GetDateTime(dataReader, "AuditActionOn", DateTime.Now);
            qtiRow.ExpensesDetails = SqlClientUtility.GetString(dataReader, "ExpensesDetails", String.Empty);

            // Extended columns from view
            qtiRow.ProjectCode = SqlClientUtility.GetString(dataReader, "ProjectCode", String.Empty);
            qtiRow.ProjectName = SqlClientUtility.GetString(dataReader, "ProjectName", String.Empty);
            qtiRow.CustomerCode = SqlClientUtility.GetString(dataReader, "CustomerCode", String.Empty);
            qtiRow.CustomerName = SqlClientUtility.GetString(dataReader, "CustomerName", String.Empty);
            qtiRow.FromLocationName = SqlClientUtility.GetString(dataReader, "FromLocationName", String.Empty);
            qtiRow.ToLocationName = SqlClientUtility.GetString(dataReader, "ToLocationName", String.Empty);
            qtiRow.MaxDailyHours = SqlClientUtility.GetDecimal(dataReader, "MaxDailyHours", Decimal.Zero);

            qtiRow.ProjectFullName = (qtiRow.ProjectCode.Length > 0 ? qtiRow.ProjectCode + " - " : String.Empty) + qtiRow.ProjectName;
            qtiRow.CustomerFullName = (qtiRow.CustomerCode.Length > 0 ? qtiRow.CustomerCode + " - " : String.Empty) + qtiRow.CustomerName;

            return qtiRow;
		}

		#endregion
    }
}
