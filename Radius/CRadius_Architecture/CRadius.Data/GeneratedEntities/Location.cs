using System;

namespace CRadius.Data
{
	[Serializable]
	public class Location
	{
		#region Fields

		private int iD;
		private string code;
		private string name;
		private decimal mapLatitude;
		private decimal mapLongitude;
		private bool isApproved;
		private bool isActive;
		private string authorComments;
		private string approverComments;
		private string comments;
		private string internalComment;
		private string createdBy;
		private DateTime createdOn;
		private string auditActionBy;
		private DateTime auditActionOn;

		#endregion

		#region Constructors

		/// <summary>
		/// Initializes a new instance of the Location class.
		/// </summary>
		public Location()
		{
		}

		/// <summary>
		/// Initializes a new instance of the Location class.
		/// </summary>
		public Location(string code, string name, decimal mapLatitude, decimal mapLongitude, bool isApproved, bool isActive, string authorComments, string approverComments, string comments, string internalComment, string createdBy, DateTime createdOn, string auditActionBy, DateTime auditActionOn)
		{
			this.code = code;
			this.name = name;
			this.mapLatitude = mapLatitude;
			this.mapLongitude = mapLongitude;
			this.isApproved = isApproved;
			this.isActive = isActive;
			this.authorComments = authorComments;
			this.approverComments = approverComments;
			this.comments = comments;
			this.internalComment = internalComment;
			this.createdBy = createdBy;
			this.createdOn = createdOn;
			this.auditActionBy = auditActionBy;
			this.auditActionOn = auditActionOn;
		}

		/// <summary>
		/// Initializes a new instance of the Location class.
		/// </summary>
		public Location(int iD, string code, string name, decimal mapLatitude, decimal mapLongitude, bool isApproved, bool isActive, string authorComments, string approverComments, string comments, string internalComment, string createdBy, DateTime createdOn, string auditActionBy, DateTime auditActionOn)
		{
			this.iD = iD;
			this.code = code;
			this.name = name;
			this.mapLatitude = mapLatitude;
			this.mapLongitude = mapLongitude;
			this.isApproved = isApproved;
			this.isActive = isActive;
			this.authorComments = authorComments;
			this.approverComments = approverComments;
			this.comments = comments;
			this.internalComment = internalComment;
			this.createdBy = createdBy;
			this.createdOn = createdOn;
			this.auditActionBy = auditActionBy;
			this.auditActionOn = auditActionOn;
		}

		#endregion

		#region Properties
		/// <summary>
		/// Gets or sets the ID value.
		/// </summary>
		public virtual int ID
		{
			get { return iD; }
			set { iD = value; }
		}

		/// <summary>
		/// Gets or sets the Code value.
		/// </summary>
		public virtual string Code
		{
			get { return code; }
			set { code = value; }
		}

		/// <summary>
		/// Gets or sets the Name value.
		/// </summary>
		public virtual string Name
		{
			get { return name; }
			set { name = value; }
		}

		/// <summary>
		/// Gets or sets the MapLatitude value.
		/// </summary>
		public virtual decimal MapLatitude
		{
			get { return mapLatitude; }
			set { mapLatitude = value; }
		}

		/// <summary>
		/// Gets or sets the MapLongitude value.
		/// </summary>
		public virtual decimal MapLongitude
		{
			get { return mapLongitude; }
			set { mapLongitude = value; }
		}

		/// <summary>
		/// Gets or sets the IsApproved value.
		/// </summary>
		public virtual bool IsApproved
		{
			get { return isApproved; }
			set { isApproved = value; }
		}

		/// <summary>
		/// Gets or sets the IsActive value.
		/// </summary>
		public virtual bool IsActive
		{
			get { return isActive; }
			set { isActive = value; }
		}

		/// <summary>
		/// Gets or sets the AuthorComments value.
		/// </summary>
		public virtual string AuthorComments
		{
			get { return authorComments; }
			set { authorComments = value; }
		}

		/// <summary>
		/// Gets or sets the ApproverComments value.
		/// </summary>
		public virtual string ApproverComments
		{
			get { return approverComments; }
			set { approverComments = value; }
		}

		/// <summary>
		/// Gets or sets the Comments value.
		/// </summary>
		public virtual string Comments
		{
			get { return comments; }
			set { comments = value; }
		}

		/// <summary>
		/// Gets or sets the InternalComment value.
		/// </summary>
		public virtual string InternalComment
		{
			get { return internalComment; }
			set { internalComment = value; }
		}

		/// <summary>
		/// Gets or sets the CreatedBy value.
		/// </summary>
		public virtual string CreatedBy
		{
			get { return createdBy; }
			set { createdBy = value; }
		}

		/// <summary>
		/// Gets or sets the CreatedOn value.
		/// </summary>
		public virtual DateTime CreatedOn
		{
			get { return createdOn; }
			set { createdOn = value; }
		}

		/// <summary>
		/// Gets or sets the AuditActionBy value.
		/// </summary>
		public virtual string AuditActionBy
		{
			get { return auditActionBy; }
			set { auditActionBy = value; }
		}

		/// <summary>
		/// Gets or sets the AuditActionOn value.
		/// </summary>
		public virtual DateTime AuditActionOn
		{
			get { return auditActionOn; }
			set { auditActionOn = value; }
		}

		#endregion
	}
}
