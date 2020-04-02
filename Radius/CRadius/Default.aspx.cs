using CRadius.Business;
using CRadius.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Web;
using System.Web.UI;

public partial class Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LocationRuleBL locationRuleBL = new LocationRuleBL(Application["ConnectionStringName"].ToString());
            List<LocationRuleView> locationRuleViews = locationRuleBL.LocationRuleViewSelectCurrent();
        }
    }

    protected void ButtonSignIn_Click(object sender, EventArgs e)
    {
    }
}