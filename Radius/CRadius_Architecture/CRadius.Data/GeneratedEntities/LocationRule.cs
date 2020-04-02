using System;

namespace CRadius.Data
{
	[Serializable]
	public class LocationRule
	{
		#region Fields

		private int iD;
		private string code;
		private int locationID;
		private int ruleID;
		private bool isActive;
		private string comments;
		private string internalComment;
		private string createdBy;
		private DateTime createdOn;
		private string auditActionBy;
		private DateTime auditActionOn;

		#endregion

		#region Constructors

		/// <summary>
		/// Initializes a new instance of the LocationRule class.
		/// </summary>
		public LocationRule()
		{
		}

		/// <summary>
		/// Initializes a new instance of the LocationRule class.
		/// </summary>
		public LocationRule(string code, int locationID, int ruleID, bool isActive, string comments, string internalComment, string createdBy, DateTime createdOn, string auditActionBy, DateTime auditActionOn)
		{
			this.code = code;
			this.locationID = locationID;
			this.ruleID = ruleID;
			this.isActive = isActive;
			this.comments = comments;
			this.internalComment = internalComment;
			this.createdBy = createdBy;
			this.createdOn = createdOn;
			this.auditActionBy = auditActionBy;
			this.auditActionOn = auditActionOn;
		}

		/// <summary>
		/// Initializes a new instance of the LocationRule class.
		/// </summary>
		public LocationRule(int iD, string code, int locationID, int ruleID, bool isActive, string comments, string internalComment, string createdBy, DateTime createdOn, string auditActionBy, DateTime auditActionOn)
		{
			this.iD = iD;
			this.code = code;
			this.locationID = locationID;
			this.ruleID = ruleID;
			this.isActive = isActive;
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
		/// Gets or sets the LocationID value.
		/// </summary>
		public virtual int LocationID
		{
			get { return locationID; }
			set { locationID = value; }
		}

		/// <summary>
		/// Gets or sets the RuleID value.
		/// </summary>
		public virtual int RuleID
		{
			get { return ruleID; }
			set { ruleID = value; }
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
