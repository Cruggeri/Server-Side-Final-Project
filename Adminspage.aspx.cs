﻿using System;
using System.Data.SqlClient;
using System.Web.UI;

public partial class Adminspage : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (("john" == (String)(Session["user"])) || ("chris" == (String)(Session["user"])))
        {
            Response.Write("Welcome admin");
            Response.Write("<br/><a href='logout.aspx'>Logout</a>");
        }
        else
        {
            Response.Redirect("Unauthorizedpage.aspx");

        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
       
        var conn =
                new SqlConnection(
                    "Data Source=(LocalDB)\\v11.0;AttachDbFilename=|DataDirectory|\\Database.mdf;Integrated Security=True");

           
        var query = "truncate table Users";

            
        var cmd = new SqlCommand(query, conn);
        try

        {
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        catch (
            Exception ex)
        {
            Response.Write
            ("Error:" +
             ex
            );
        }
    }
}