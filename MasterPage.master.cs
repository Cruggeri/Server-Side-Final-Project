using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["user"] != null)
        { 
            logoutLink.Visible = true;

            if ((Int32)(Session["admin"]) == (Int32)0) //hides the admin page link if one is not in an admin session
            {
                adminLog.Visible = true;
            }
        }
    }
}
