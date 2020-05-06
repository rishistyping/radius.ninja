using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using Sodium.Data;
using Sodium.Utilities;

namespace CRadius.Data.DAL
{
	public class LocationDAL
	{
		#region Fields

		protected string connectionStringName;

		#endregion

		#region Constructors

		public LocationDAL(string connectionStringName)
		{
			ValidationUtility.ValidateArgument("connectionStringName", connectionStringName);

			this.connectionStringName = connectionStringName;
		}

		#endregion

		#region Methods

		/// <summary>
		/// Saves a record to the Location table.
		/// </summary>
		public virtual void Insert(Location location)
		{
			ValidationUtility.ValidateArgument("location", location);

			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@Code", location.Code),
				new SqlParameter("@Name", location.Name),
				new SqlParameter("@MapLatitude", location.MapLatitude),
				new SqlParameter("@MapLongitude", location.MapLongitude),
				new SqlParameter("@IsApproved", location.IsApproved),
				new SqlParameter("@IsActive", location.IsActive),
				new SqlParameter("@AuthorComments", location.AuthorComments),
				new SqlParameter("@ApproverComments", location.ApproverComments),
				new SqlParameter("@Comments", location.Comments),
				new SqlParameter("@LocationType", location.LocationType),
				new SqlParameter("@Polygon", location.Polygon),
				new SqlParameter("@InternalComment", location.InternalComment),
				new SqlParameter("@CreatedBy", location.CreatedBy),
				new SqlParameter("@CreatedOn", location.CreatedOn),
				new SqlParameter("@AuditActionBy", location.AuditActionBy),
				new SqlParameter("@AuditActionOn", location.AuditActionOn)
			};

			location.ID = Convert.ToInt32(SqlClientUtility.ExecuteScalar(connectionStringName, CommandType.StoredProcedure, "LocationInsert", parameters));
		}

		/// <summary>
		/// Updates a record in the Location table.
		/// </summary>
		public virtual void Update(Location location)
		{
			ValidationUtility.ValidateArgument("location", location);

			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@ID", location.ID),
				new SqlParameter("@Code", location.Code),
				new SqlParameter("@Name", location.Name),
				new SqlParameter("@MapLatitude", location.MapLatitude),
				new SqlParameter("@MapLongitude", location.MapLongitude),
				new SqlParameter("@IsApproved", location.IsApproved),
				new SqlParameter("@IsActive", location.IsActive),
				new SqlParameter("@AuthorComments", location.AuthorComments),
				new SqlParameter("@ApproverComments", location.ApproverComments),
				new SqlParameter("@Comments", location.Comments),
				new SqlParameter("@LocationType", location.LocationType),
				new SqlParameter("@Polygon", location.Polygon),
				new SqlParameter("@InternalComment", location.InternalComment),
				new SqlParameter("@CreatedBy", location.CreatedBy),
				new SqlParameter("@CreatedOn", location.CreatedOn),
				new SqlParameter("@AuditActionBy", location.AuditActionBy),
				new SqlParameter("@AuditActionOn", location.AuditActionOn)
			};

			SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "LocationUpdate", parameters);
		}

		/// <summary>
		/// Deletes a record from the Location table by its primary key.
		/// </summary>
		public virtual void Delete(int iD)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@ID", iD)
			};

			SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "LocationDelete", parameters);
		}

		/// <summary>
		/// Selects a single record from the Location table.
		/// </summary>
		public virtual Location Select(int iD)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@ID", iD)
			};

			using (SqlDataReader dataReader = SqlClientUtility.ExecuteReader(connectionStringName, CommandType.StoredProcedure, "LocationSelect", parameters))
			{
				if (dataReader.Read())
				{
					return MakeLocation(dataReader);
				}
				else
				{
					return null;
				}
			}
		}

		/// <summary>
		/// Selects all records from the Location table.
		/// </summary>
		public virtual List<Location> SelectAll()
		{
			using (SqlDataReader dataReader = SqlClientUtility.ExecuteReader(connectionStringName, CommandType.StoredProcedure, "LocationSelectAll"))
			{
				List<Location> locationList = new List<Location>();
				while (dataReader.Read())
				{
					Location location = MakeLocation(dataReader);
					locationList.Add(location);
				}
				dataReader.Close();

				return locationList;
			}
		}

		/// <summary>
		/// Creates a new instance of the Location class and populates it with data from the specified SqlDataReader.
		/// </summary>
		protected virtual Location MakeLocation(SqlDataReader dataReader)
		{
			Location location = new Location();
			location.ID = SqlClientUtility.GetInt32(dataReader, "ID", 0);
			location.Code = SqlClientUtility.GetString(dataReader, "Code", String.Empty);
			location.Name = SqlClientUtility.GetString(dataReader, "Name", String.Empty);
			location.MapLatitude = SqlClientUtility.GetDecimal(dataReader, "MapLatitude", Decimal.Zero);
			location.MapLongitude = SqlClientUtility.GetDecimal(dataReader, "MapLongitude", Decimal.Zero);
			location.IsApproved = SqlClientUtility.GetBoolean(dataReader, "IsApproved", false);
			location.IsActive = SqlClientUtility.GetBoolean(dataReader, "IsActive", false);
			location.AuthorComments = SqlClientUtility.GetString(dataReader, "AuthorComments", String.Empty);
			location.ApproverComments = SqlClientUtility.GetString(dataReader, "ApproverComments", String.Empty);
			location.Comments = SqlClientUtility.GetString(dataReader, "Comments", String.Empty);
			location.LocationType = SqlClientUtility.GetInt32(dataReader, "LocationType", 0);
			location.Polygon = SqlClientUtility.GetString(dataReader, "Polygon", String.Empty);
			location.InternalComment = SqlClientUtility.GetString(dataReader, "InternalComment", String.Empty);
			location.CreatedBy = SqlClientUtility.GetString(dataReader, "CreatedBy", String.Empty);
			location.CreatedOn = SqlClientUtility.GetDateTime(dataReader, "CreatedOn", DateTime.Now);
			location.AuditActionBy = SqlClientUtility.GetString(dataReader, "AuditActionBy", String.Empty);
			location.AuditActionOn = SqlClientUtility.GetDateTime(dataReader, "AuditActionOn", DateTime.Now);

			return location;
		}

		#endregion
	}
}
