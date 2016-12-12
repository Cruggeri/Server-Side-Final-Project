using System;
using System.Data.SqlClient;
using System.IO;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Products : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        var conn =
            new SqlConnection(
                "Data Source=(LocalDB)\\v11.0;AttachDbFilename=|DataDirectory|\\Database.mdf;Integrated Security=True");
        conn.Open();
        var checkUser = "select * from Products";
        var cmd = new SqlCommand(checkUser, conn);
        try
        {
            var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                var row = new TableRow();
                var cellName = new TableCell();
                var cellType = new TableCell();

                var cellPrice = new TableCell();
                var cellImage = new TableCell();


                cellName.Text = reader["prodName"].ToString();
                cellType.Text = reader["prodType"].ToString();
                cellPrice.Text = reader["prodPrice"].ToString();
                String url = reader["prodImage"].ToString();

                Image prodImage = new Image();
                prodImage.ImageUrl = url;
                prodImage.Width = 100;
                prodImage.Height = 100;

                cellImage.Controls.Add(prodImage);

                row.Cells.Add(cellName);
                row.Cells.Add(cellType);
                row.Cells.Add(cellPrice);
                row.Cells.Add(cellImage);

                Table1.Rows.Add(row);

            }

            conn.Close();
        }


        catch (Exception ex)
        {
            Response.Write(ex.Message);
        }
    }
}
