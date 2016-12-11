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
   
    protected void saveButton_Click(object sender, EventArgs e)
    {
        String prdName = prName.Text;
        String prdType = prTypeDropDownList.SelectedValue;
        String prdImageURL = "";

        if (Page.IsPostBack)
        {
            Boolean oak = false;
            String path = Server.MapPath("~/Images/");

            if (picFileUpload.HasFile)
            {
                String fileExt = System.IO.Path.GetExtension(picFileUpload.FileName).ToLower();
                String[] allowedExtensions = { ".gif", ".png", ".jpg", ".jpeg" };

                for (int v = 0; v < allowedExtensions.Length; v++)
                {
                    if (fileExt == allowedExtensions[v])
                        oak = true;
                }
            }

            if (oak)
            {
                try
                {
                    picFileUpload.PostedFile.SaveAs(path + picFileUpload.FileName);
                    picUpLabel.Text = "Image uploaded to " + "~/Images/" + picFileUpload.FileName;
                    inImage.ImageUrl = "~/Images/" + picFileUpload.FileName;
                    prdImageURL = "~/Images/" + picFileUpload.FileName;
                }
                catch (Exception promotions)
                {
                    picUpLabel.Text = promotions.Message;
                }

            }
            else
            {
                picUpLabel.Text = "Image file upload failed";
            }

            TableRow rw = new TableRow();
            TableCell nCell = new TableCell();
            TableCell typCell = new TableCell();
            TableCell picCell = new TableCell();

            nCell.Text = prdName;
            typCell.Text = prdType;

            Image PrdImage = new Image();
            PrdImage.ImageUrl = prdImageURL;
            PrdImage.Height = 130;
            PrdImage.Width = 130;

            picCell.Controls.Add(PrdImage);
            rw.Cells.Add(nCell);
            rw.Cells.Add(typCell);
            rw.Cells.Add(picCell);

            Table1.Rows.Add(rw);
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {

    }
}
