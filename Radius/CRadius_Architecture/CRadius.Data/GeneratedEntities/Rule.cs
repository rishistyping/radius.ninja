using System;

namespace CRadius.Data
{
	[Serializable]
	public class Rule
	{
		#region Fields

		private int iD;
		private string code;
		private string name;
		private bool isActive;
		private decimal radiusK;
		private decimal warnK;
		private int direction;
		private string message;
		private string comments;
		private string internalComment;
		private string createdBy;
		private DateTime createdOn;
		private string auditActionBy;
		private DateTime auditActionOn;

		#endregion

		#region Constructors

		/// <summary>
		/// Initializes a new instance of the Rule class.
		/// </summary>
		public Rule()
		{
		}

		/// <summary>
		/// Initializes a new instance of the Rule class.
		/// </summary>
		public Rule(string code, string name, bool isActive, decimal radiusK, decimal warnK, int direction, string message, string comments, string internalComment, string createdBy, DateTime createdOn, string auditActionBy, DateTime auditActionOn)
		{
			this.code = code;
			this.name = name;
			this.isActive = isActive;
			this.radiusK = radiusK;
			this.warnK = warnK;
			this.direction = direction;
			this.message = message;
			this.comments = comments;
			this.internalComment = internalComment;
			this.createdBy = createdBy;
			this.createdOn = createdOn;
			this.auditActionBy = auditActionBy;
			this.auditActionOn = auditActionOn;
		}

		/// <summary>
		/// Initializes a new instance of the Rule class.
		/// </summary>
		public Rule(int iD, string code, string name, bool isActive, decimal radiusK, decimal warnK, int direction, string message, string comments, string internalComment, string createdBy, DateTime createdOn, string auditActionBy, DateTime auditActionOn)
		{
			this.iD = iD;
			this.code = code;
			this.name = name;
			this.isActive = isActive;
			this.radiusK = radiusK;
			this.warnK = warnK;
			this.direction = direction;
			this.message = message;
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
		/// Gets or sets the IsActive value.
		/// </summary>
		public virtual bool IsActive
		{
			get { return isActive; }
			set { isActive = value; }
		}

		/// <summary>
		/// Gets or sets the RadiusK value.
		/// </summary>
		public virtual decimal RadiusK
		{
			get { return radiusK; }
			set { radiusK = value; }
		}

		/// <summary>
		/// Gets or sets the WarnK value.
		/// </summary>
		public virtual decimal WarnK
		{
			get { return warnK; }
			set { warnK = value; }
		}

		/// <summary>
		/// Gets or sets the Direction value.
		/// </summary>
		public virtual int Direction
		{
			get { return direction; }
			set { direction = value; }
		}

		/// <summary>
		/// Gets or sets the Message value.
		/// </summary>
		public virtual string Message
		{
			get { return message; }
			set { message = value; }
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
