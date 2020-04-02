using CRadius.Data;
using CRadius.Data.DAL;
using Sodium.Utilities;
using System.Collections.Generic;

namespace CRadius.Business
{
    public class LocationRuleBL
    {
        #region Fields

        private string connectionStringName;

        #endregion
        
		#region Constructors

        public LocationRuleBL(string connectionStringName)
		{
			ValidationUtility.ValidateArgument("connectionStringName", connectionStringName);
			this.connectionStringName = connectionStringName;
        }

        #endregion

        #region Methods

        public virtual List<LocationRuleView> LocationRuleViewSelectCurrent()
        {
            return (new LocationRuleViewDAL(connectionStringName)).LocationRuleViewSelectCurrent();
        }

        #endregion
    }
}
