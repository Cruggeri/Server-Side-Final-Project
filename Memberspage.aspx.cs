using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Memberspage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["user"] == null)
        {
            Response.Write("You must be logged in to view the Members area - Please sign in");
            Response.Write("<a href='Loginpage.aspx'> sign in</a>");
            Response.Redirect("Unauthorizedpage.aspx");
        }
        else
        {
            Response.Write("<h3> Hello " + Session["user"].ToString() + " </h3>");
            Response.Write("<br/><a href='logout.aspx'>Logout</a>");

        }
    }
}
