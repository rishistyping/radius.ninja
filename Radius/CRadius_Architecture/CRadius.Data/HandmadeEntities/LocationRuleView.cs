using System;

namespace CRadius.Data
{
    [Serializable]
    public class LocationRuleView : LocationRule
    {
        #region Fields

        decimal mapLatitude;
        decimal mapLongitude;
        decimal radiusK;
        decimal warnK;
        int direction;
        string message;
        string locationName;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the LocationRuleView.
        /// </summary>
        public LocationRuleView()
		{
		}

        #endregion

        #region Properties

        public virtual string LocationName
        {
            get { return locationName; }
            set { locationName = value; }
        }

        public virtual int Direction
        {
            get { return direction; }
            set { direction = value; }
        }

        public virtual string Message
        {
            get { return message; }
            set { message = value; }
        }

        public virtual decimal MapLatitude
        {
            get { return mapLatitude; }
            set { mapLatitude = value; }
        }

        public virtual decimal MapLongitude
        {
            get { return mapLongitude; }
            set { mapLongitude = value; }
        }

        public virtual decimal RadiusK
        {
            get { return radiusK; }
            set { radiusK = value; }
        }

        public virtual decimal WarnK
        {
            get { return warnK; }
            set { warnK = value; }
        }

        #endregion
    }
}
