﻿
using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

public partial class Memberspage : System.Web.UI.Page
{

    protected void Page_Init(object sender, EventArgs e)
    {
    //    foreach (TableRow row in this.Table1.Rows)
    //    {
    //        foreach (TableCell cell in row.Cells)
    //        {
    //            if (cell.Text == "button")
    //            {
    //                Button btn = new Button();
    //                btn.Text = "Delete";
    //                btn.Click += new EventHandler(btn_Click);
    //                cell.Controls.Add(btn);
    //            }
    //        }
    //    }
    }
    void btn_Click(object sender, EventArgs e)
    {
        //((Button)sender).Text = "Just Clicked";

        if (Page.IsPostBack)
        {
            //var conn =
            //    new SqlConnection(
            //        "Data Source=(LocalDB)\\v11.0;AttachDbFilename=|DataDirectory|\\Database.mdf;Integrated Security=True");
            //conn.Open();
            //var delProduct = "delete from Products where prodName ='" + ((Button)sender).Text + "'";
            //var cmd = new SqlCommand(delProduct, conn);
            //cmd.ExecuteNonQuery();
            //conn.Close();
        }
    }
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
        var cnct =
                new SqlConnection(
                    "Data Source=(LocalDB)\\v11.0;AttachDbFilename=|DataDirectory|\\Database.mdf;Integrated Security=True");
        cnct.Open();
        var checkUser = "select * from Products where seller='" + Session["user"] + "'";
        var prodNames = "select prodName from Products";
        var buyProduct = "delete from Products where prodName ='" +  DropDownList1.SelectedValue + "'";//change me

        var cmnd = new SqlCommand(checkUser, cnct);
        var cmd2 = new SqlCommand(prodNames, cnct);

        try
        {
            var reader = cmnd.ExecuteReader();

            while (reader.Read())
            {
                int rem = 0;
                var row = new TableRow();
                var cellName = new TableCell();
                var cellType = new TableCell();

                var cellPrice = new TableCell();
                var cellImage = new TableCell();
                var remove = new TableCell();
                

                cellName.Text = reader["prodName"].ToString();
                cellType.Text = reader["prodType"].ToString();
                cellPrice.Text = "$" + reader["prodPrice"].ToString();
                String url = reader["prodImage"].ToString();
                String remTarget = reader["prodName"].ToString();
                Button btn = new Button();
                btn.Text = reader["prodName"].ToString(); ;
                btn.Click += new EventHandler(btn_Click);
                remove.Text = "Delete";
                remove.Controls.Add(btn);
                    

                Image prodImage = new Image();
                //ButtonField
                    Button del = new Button();
                prodImage.ImageUrl = url;
                prodImage.Width = 100;
                prodImage.Height = 100;

                cellImage.Controls.Add(prodImage);
                //delProd.Text = "Delete";
                row.Cells.Add(cellName);
                row.Cells.Add(cellType);
                row.Cells.Add(cellPrice);
                row.Cells.Add(cellImage);
                //row.Cells.Add(remove);

                Table1.Rows.Add(row);

            }

            cnct.Close();
        }


        catch (Exception ex)
        {
            Response.Write(ex.Message);
        }
        cnct.Open();
        try
        {
            var reader = cmd2.ExecuteReader();

            while (reader.Read())
            {
                DropDownList1.Items.Add(reader[0].ToString());
            }
            cnct.Close();
        }

        catch (Exception ex)
        {
            Response.Write(ex.Message);
        }
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        if (Page.IsPostBack)
        {
            var fileOK = false;
            var path = Server.MapPath("~/images/");

            if (FileUpload1.HasFile)
            {
                var fileExtensions = Path.GetExtension(FileUpload1.FileName).ToLower();
                string[] allowedExtensions = { ".gif", ".png", ".jpeg", ".jpg" };

                foreach (var x in allowedExtensions)
                    if (fileExtensions == x)
                        fileOK = true;
                if (fileOK)
                    try
                    {
                        FileUpload1.PostedFile.SaveAs(path + FileUpload1.FileName);
                        ProdImage.ImageUrl = "~/images/" + FileUpload1.FileName;
                    }
                    catch (Exception ex)
                    {
                        Response.Write(ex.Message);
                    }
            }
        }
    }

    protected void saveButton_Click(object sender, EventArgs e)
    {
        try
        {
            var conn =
                new SqlConnection(
                    "Data Source=(LocalDB)\\v11.0;AttachDbFilename=|DataDirectory|\\Database.mdf;Integrated Security=True");
            conn.Open();
            var query =
                "insert into [products](prodName,prodType,prodPrice,prodImage,seller) values (@name,@type,@price,@image,@seller)";
            var cmd = new SqlCommand(query, conn);

            cmd.Parameters.AddWithValue("@name", prodName.Text);
            cmd.Parameters.AddWithValue("@type", prodType.Text);
            cmd.Parameters.AddWithValue("@price", prodPrice.Text);
            cmd.Parameters.AddWithValue("@image", ProdImage.ImageUrl);
            cmd.Parameters.AddWithValue("seller", Session["user"].ToString());


            cmd.ExecuteNonQuery();
            
        }
        catch (Exception ex)
        {
            Response.Write("Error:" + ex);
        }
    }


    //protected void saveButton_Click(object sender, EventArgs e)
    //{
    //    String prdName = prName.Text;
    //    String prdType = prTypeDropDownList.SelectedValue;
    //    String prdImageURL = "";

    //    if (Page.IsPostBack)
    //    {
    //        Boolean oak = false;
    //        String path = Server.MapPath("~/Images/");

    //        if (picFileUpload.HasFile)
    //        {
    //            String fileExt = System.IO.Path.GetExtension(picFileUpload.FileName).ToLower();
    //            String[] allowedExtensions = { ".gif", ".png", ".jpg", ".jpeg" };

    //            for (int v = 0; v < allowedExtensions.Length; v++)
    //            {
    //                if (fileExt == allowedExtensions[v])
    //                    oak = true;
                    
    //            }
    //        }

    //        if (oak)
    //        {
    //            try
    //            {
    //                picFileUpload.PostedFile.SaveAs(path + picFileUpload.FileName);
    //                picUpLabel.Text = "Image uploaded to " + "~/Images/" + picFileUpload.FileName;
    //                inImage.ImageUrl = "~/Images/" + picFileUpload.FileName;
    //                prdImageURL = "~/Images/" + picFileUpload.FileName;
    //            }
    //            catch (Exception promotions)
    //            {
    //                picUpLabel.Text = promotions.Message;
    //            }

    //        }
    //        else
    //        {
    //            picUpLabel.Text = "Image file upload failed";
    //        }

    //        TableRow rw = new TableRow();
    //        TableCell nCell = new TableCell();
    //        TableCell typCell = new TableCell();
    //        TableCell picCell = new TableCell();

    //        nCell.Text = prdName;
    //        typCell.Text = prdType;

    //        Image PrdImage = new Image();
    //        PrdImage.ImageUrl = prdImageURL;
    //        PrdImage.Height = 130;
    //        PrdImage.Width = 130;

    //        picCell.Controls.Add(PrdImage);
    //        rw.Cells.Add(nCell);
    //        rw.Cells.Add(typCell);
    //        rw.Cells.Add(picCell);

    //        Table1.Rows.Add(rw);
    //    }
    //}


    protected void submitButton_Click(object sender, EventArgs e)
    {
        Response.Redirect("SubmitDeal.aspx");
    }
    protected void prButton_Click(object sender, EventArgs e)
    {
        Response.Redirect("PrDeal.aspx");
    }
    protected void editSelfButton_Click(object sender, EventArgs e)
    {

    }
    protected void delProductButton_Click(object sender, EventArgs e)
    {
        if (Page.IsPostBack)
        {
            var conn =
                new SqlConnection(
                    "Data Source=(LocalDB)\\v11.0;AttachDbFilename=|DataDirectory|\\Database.mdf;Integrated Security=True");
            conn.Open();
            var delProduct = "delete from Products where prodName ='" + DropDownList1 + "'"; //argh
            var cmd = new SqlCommand(delProduct, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
        }
    }
}