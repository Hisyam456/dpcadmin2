using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UploadRotator : System.Web.UI.Page
{
    static RotatorImageForm rotatorform = new RotatorImageForm();
    static Database db = new Database();

    static readonly string scriptRotatorAdded =
   "<script language=\"javascript\">\n" +
   "alert(\"Success - New Rotator Images added!\");\n" +
   "</script>";

    static readonly string scriptError =
   "<script language=\"javascript\">\n" +
   "alert(\"Internal Error: Please contact Tech Department!\");\n" +
   "</script>";

    static readonly string scriptadError =
  "<script language=\"javascript\">\n" +
  "alert(\"Please fill up the form completely!\");\n" +
  "</script>";

    static readonly string scriptpicError =
  "<script language=\"javascript\">\n" +
  "alert(\"No Picture Selected!\");\n" +
  "</script>";

    static readonly string scriptPicUpdated =
  "<script language=\"javascript\">\n" +
  "alert(\"Picture Successfully Updated!\");\n" +
  "</script>";

    static readonly string scriptBrandError =
"<script language=\"javascript\">\n" +
"alert(\"Please select a Brand!\");\n" +
"</script>";

    static readonly string scriptUpdateSuccess =
"<script language=\"javascript\">\n" +
"alert(\"Successfully Updated Product!\");\n" +
"</script>";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!User.Identity.IsAuthenticated)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "NOT AUTHORIZED" + "');", true);
            Response.Redirect("login.aspx");

        }

        DateTime now = DateTime.Now;
    }

    protected void submitrti_Click(object sender, EventArgs e)
    {
        Type csType = this.GetType();

        try
        {
            string itemName, itemCat, itemStatus, itemDesc, itemNotes, itemImage1, itemImage2, itemImage3, itemImage4, itemImage5, itemImage6;
            Debug.WriteLine("Files posted: " + Request.Files.Count);

            string[] images = new string[6];

            for (int i = 0; i < Request.Files.Count; i++)
            {

                HttpPostedFile PostedFile = Request.Files[i];

                if (PostedFile.ContentLength > 0)
                {
                    var FileExtension = Path.GetExtension(PostedFile.FileName).Substring(1);
                    //Checking if file is picture, then save in maid folder
                    if (FileExtension.Equals("png") || FileExtension.Equals("jpg") || FileExtension.Equals("PNG"))
                    {

                        //this entire line - filename of posted file
                        string FileName = System.IO.Path.GetFileName(PostedFile.FileName);
                        Debug.WriteLine(FileName);

                        // save file to folder
                        PostedFile.SaveAs(Server.MapPath("RotatorImages\\" + FileName));
                        images[i] = "RotatorImages/" + FileName;

                    }

                }

            }


            DateTime createdOn, editedOn;


            itemName = rtIname.Text;
            itemCat = rtiCat.SelectedValue.ToString();
            itemStatus = rtiStats.SelectedValue.ToString();
            itemDesc = rtiDesc.Text;
            itemNotes = rtiNotes.Text;            
            itemImage1 = images[0];
            itemImage2 = images[1];
            itemImage3 = images[2];
            itemImage4 = images[3];
            itemImage5 = images[4];
            itemImage6 = images[5]; 
            createdOn = DateTime.Now;
            editedOn = DateTime.Now;


            rotatorform.submitRotatorImage(itemName, itemCat, itemStatus, itemDesc, itemNotes, itemImage1, itemImage2, itemImage3, itemImage4, itemImage5, itemImage6, createdOn, editedOn);
            Debug.WriteLine("Submitted Rotator Image Form");
            ClientScript.RegisterStartupScript(csType, "Rotator Images Added", scriptRotatorAdded);

        }

        catch (SqlException ex)
        {
            Debug.WriteLine(ex.Message);         
        }
    }
}