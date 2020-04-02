using Sodium.Data;
using Sodium.Utilities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace ITree.Data.DAL
{
    public class MgtLegislationExtensionsDAL : MgtLegislationDAL
	{
		#region Fields

		protected string connectionStringName;

		#endregion

		#region Constructors

        public MgtLegislationExtensionsDAL(string connectionStringName) : base(connectionStringName)
		{
			ValidationUtility.ValidateArgument("connectionStringName", connectionStringName);

			this.connectionStringName = connectionStringName;
		}

		#endregion

		#region Methods

        public virtual List<MgtLegislation> Report(DateTime dateFrom, DateTime dateTo)
        {
            SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@DateFrom", dateFrom),
				new SqlParameter("@DateTo", dateTo)
			};

            using (SqlDataReader dataReader = SqlClientUtility.ExecuteReader(connectionStringName, CommandType.StoredProcedure, "__ReportMgtLegislation", parameters))
            {
                List<MgtLegislation> mgtLegislations = new List<MgtLegislation>();
                while (dataReader.Read())
                {
                    MgtLegislation mgtLegislation = MakeMgtLegislation(dataReader);
                    mgtLegislations.Add(mgtLegislation);
                }

                return mgtLegislations;
            }
        }

        #endregion
	}
}
