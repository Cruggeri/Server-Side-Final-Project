using System;
using System.Data.SqlClient;
using System.Web.UI;

public partial class Registerpage : Page
{
    Int32 x = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack)
        {
            var conn =
                new SqlConnection(
                    "Data Source=(LocalDB)\\v11.0;AttachDbFilename=|DataDirectory|\\Database.mdf;Integrated Security=True");
            conn.Open();
            var checkUser = "select count(*) from [Users] where userName='" + Username.Text + "'";
            var cmd = new SqlCommand(checkUser, conn);
            x = Convert.ToInt32(cmd.ExecuteScalar().ToString());
            if (x == 1) ;
            {
                Response.Write("User Already Exists");
            }

            conn.Close();
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            var conn =
                new SqlConnection(
                    "Data Source=(LocalDB)\\v11.0;AttachDbFilename=|DataDirectory|\\Database.mdf;Integrated Security=True");
            conn.Open();
            var query = "insert into [users](userName,pwd) values (@username ,@password)";
            var cmd = new SqlCommand(query, conn);

            var checkUser = "select count(*) from [Users] where userName='" + Username.Text + "'";
            var checkUserCmd = new SqlCommand(checkUser, conn);
            x = Convert.ToInt32(checkUserCmd.ExecuteScalar().ToString());
            if (x == 1)
            {
    
            }
            else 
            {

                cmd.Parameters.AddWithValue("@username", Username.Text);
                cmd.Parameters.AddWithValue("@password", Password.Text);
                cmd.ExecuteNonQuery();
                Response.Redirect("Loginpage.aspx");
                Response.Write("Registration is successfull");
            }

            
            conn.Close();
        }
        catch (Exception ex)
        {
            Response.Write("Error:" + ex);
        }
    }
}