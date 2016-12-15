﻿using System;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;

public partial class Loginpage : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.Cookies["UserInfo"] != null)
            {
                Username.Text = Request.Cookies["UserInfo"]["loginUN"].ToString();
                //Password.Text = Request.Cookies["UserInfo"]["loginPW"].ToString();
            }
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        var conn =
            new SqlConnection(
                "Data Source=(LocalDB)\\v11.0;AttachDbFilename=|DataDirectory|\\Database.mdf;Integrated Security=True");
        var query = new SqlCommand("select pwd from Users where userName='" + Username.Text + "'");
        query.Connection = conn;


        try
        {
            conn.Open();
            var reader = query.ExecuteReader();

            var password = "";

            while (reader.Read())
                password = reader["pwd"].ToString().Trim();
            if (Password.Text == password)
            {
                Session["user"] = Username.Text;
                Response.Cookies["UserInfo"]["loginUN"] = Session["user"].ToString();
                Response.Cookies["UserInfo"].Expires = DateTime.Now.AddDays(3d);
                //if (loginChckBox.Checked = true)
                //    Response.Cookies["UserInfo"]["loginPW"] = password;
                Response.Redirect("Memberspage.aspx");
            }
            else
            {
                errorLabel.Visible = true;
                errorLabel.Text = "Username and Password do not match";
            }
            conn.Close();
        }
        catch (Exception ex)
        {
            Response.Write("Error:" + ex);
        }
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        var conn =
            new SqlConnection(
                "Data Source=(LocalDB)\\v11.0;AttachDbFilename=|DataDirectory|\\Database.mdf;Integrated Security=True");
        var query = new SqlCommand("select pwd from admins where userName='" + adminUsername.Text + "'");
        query.Connection = conn;


        try
        {
            conn.Open();
            var reader = query.ExecuteReader();

            var password = "";

            while (reader.Read())
                password = reader["pwd"].ToString().Trim();
            if (adminPassword.Text == password)
            {
                Session["user"] = adminUsername.Text;

                Response.Redirect("Adminspage.aspx");
            }
            else
            {
                adminErrorLabel.Visible = true;
                adminErrorLabel.Text = "Username and Password do not match";
            }
            conn.Close();
        }
        catch (Exception ex)
        {
            Response.Write("Error:" + ex);
        }
    }
}
   