using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
          
            Response.Redirect("Unauthorizedpage.aspx");
        }
        else
        {
            Response.Write("<h3> Hello " + Session["user"].ToString() + " </h3>");
            Response.Write("<br/><a href='logout.aspx'>Logout</a>");

        }


        try
        {
            var conn =
                new SqlConnection(
                    "Data Source=(LocalDB)\\v11.0;AttachDbFilename=|DataDirectory|\\Database.mdf;Integrated Security=True");
            conn.Open();
            var query =
                "select * from [Users] where userName='" + Session["user"] + "'";
            var cmd = new SqlCommand(query, conn);

            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                name.Text = reader["name"].ToString();
                surname.Text = reader["surname"].ToString();
                username.Text = reader["userName"].ToString();
                password.Text = reader["pwd"].ToString();
                gender.Text = reader["gender"].ToString();
                emailAddress.Text = reader["emailAdd"].ToString();
                userImg.ImageUrl = reader["image"].ToString();
            }
               
          

            conn.Close();
        }
        catch (Exception ex)
        {
            Response.Write("Error:" + ex);
        }
    
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("SubmitDeal.aspx");
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        Response.Redirect("PrDeal.aspx");
    }
}