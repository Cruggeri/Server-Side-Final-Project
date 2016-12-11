using System;
using System.Data.SqlClient;
using System.Web.UI;

public partial class Adminspage : Page
{
    String selected = "";
    String pwd = "";
    Int32 x = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        int v = 0;
        //("john" == (String)(Session["user"])) || ("chris" == (String)(Session["user"])))

        if (Session["user"] != null)
        {
            try
            {
                if (v == (Int32)(Session["admin"]))
                {
                    Response.Write("Welcome admin");
                    Response.Write("<br/><a href='logout.aspx'>Logout</a>");
                }


            }
            catch (Exception ex)
            {
                Response.Write
                ("Error:" + ex);
            }
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
            ("Error:" + ex
            );
        }
    }

    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        selected = GridView1.SelectedRow.Cells[2].Text;
        pwd = GridView1.SelectedRow.Cells[2].Text;
        Response.Write(selected);
    }

    protected void createAdminButton_Click(object sender, EventArgs e)
    {
        String Username = selected;
        String Password = pwd;
        int z = 0;
        try
        {
            var conn =
                new SqlConnection(
                    "Data Source=(LocalDB)\\v11.0;AttachDbFilename=|DataDirectory|\\Database.mdf;Integrated Security=True");
            conn.Open();
            var query = "insert into[admins](userName, pwd) select userName, pwd from [Users]";
                //[admins](userName,pwd) values (@username ,@password)";
            var cmd = new SqlCommand(query, conn);

            //var quer = "update [Users] set admin=0 where userName='" + Username + "'";         
            //var comd = new SqlCommand(quer, conn);
           

            var checkUser = "select count(*) from [admins] where userName='" + Username + "'";
            var checkUserCmd = new SqlCommand(checkUser, conn);
            x = Convert.ToInt32(checkUserCmd.ExecuteScalar().ToString());
            if (x == 1)
            {

            }
            else
            {

                cmd.Parameters.AddWithValue("@username", Username);
                cmd.Parameters.AddWithValue("@password", Password);
                //comd.Parameters.AddWithValue("@admin", z);
                cmd.ExecuteNonQuery();
                cmd.ExecuteNonQuery();                
                Response.Write(Username +" is now an admin");
            }


            conn.Close();
        }
        catch (Exception ex)
        {
            Response.Write("Error:" + ex);
      }
    }
   
}