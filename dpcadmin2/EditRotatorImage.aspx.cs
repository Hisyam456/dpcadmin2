using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class EditRotatorImage : System.Web.UI.Page
{
    static readonly string scriptProdAdded =
    "<script language=\"javascript\">\n" +
    "alert(\"Success - New Product added!\");\n" +
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

    string currentID;
    string pName;
    string pDescription;
    string pStatus;
    string pNotes;
    string pCat;

    static Database db = new Database();
    

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!User.Identity.IsAuthenticated)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "NOT AUTHORIZED" + "');", true);
            Response.Redirect("login.aspx");

        }

        currentID = Request.QueryString["rotatorID"];

        try
        {

            if (!Page.IsPostBack)
            {
                using (SqlConnection conn = db.getDBConnection())
                {
                    conn.Open();
                    SqlCommand com = new SqlCommand("Select * from dpcrImages Where rmID = @currentID", conn);
                    com.Parameters.AddWithValue("@currentID", currentID);

                    SqlDataReader dr = com.ExecuteReader();

                    while (dr.Read())
                    {
                        if (dr.HasRows == true)
                        {

                            itemname.Text = dr[1].ToString();
                            itemcat.Text = dr[2].ToString();
                            itemstatus.Text = dr[3].ToString();
                            txtDesc.Text = dr[4].ToString();
                            txtNotes.Text = dr[5].ToString();
                            im1.Value = dr[6].ToString();
                            im2.Value = dr[7].ToString();
                            im3.Value = dr[8].ToString();
                            im4.Value = dr[9].ToString();
                            im5.Value = dr[10].ToString();
                            im6.Value = dr[11].ToString();
                            dr.Close();
                            conn.Close();
                            return;
                        }

                    }
                    if (dr.HasRows == false)
                    {
                        dr.Close();
                        conn.Close();
                        Response.Redirect("EditRotator.aspx");

                    }
                }

            }
        }

        catch
        {
            Response.Redirect("EditRotator.aspx");
        }
    }

    protected void updatePic_Click(object sender, EventArgs e)
    {
        string img1, img2, img3, img4, img5, img6; 

        Type csType = this.GetType();
        //check image uploaded
        if (FileUpload1.HasFile == false)
        {
            img1 = im1.Value; 
        }
        else
        {
            FileUpload1.SaveAs(Server.MapPath("RotatorImages\\" + FileUpload1.FileName));
            img1 = "RotatorImages/" + FileUpload1.FileName;
        }
        if (FileUpload2.HasFile == false)
        {
            img2 = im2.Value;
        }
        else
        {
            FileUpload2.SaveAs(Server.MapPath("RotatorImages\\" + FileUpload2.FileName));
            img2 = "RotatorImages/" + FileUpload2.FileName;
        }
        if (FileUpload3.HasFile == false)
        {
            img3 = im3.Value;
        }
        else
        {
            FileUpload3.SaveAs(Server.MapPath("RotatorImages\\" + FileUpload3.FileName));
            img3 = "RotatorImages/" + FileUpload3.FileName;
        }
        if (FileUpload4.HasFile == false)
        {
            img4 = im4.Value;
        }
        else
        {
            FileUpload4.SaveAs(Server.MapPath("RotatorImages\\" + FileUpload4.FileName));
            img4 = "RotatorImages/" + FileUpload4.FileName;
        }
        if (FileUpload5.HasFile == false)
        {
            img5 = im5.Value;
        }
        else
        {
            FileUpload5.SaveAs(Server.MapPath("RotatorImages\\" + FileUpload5.FileName));
            img5 = "RotatorImages/" + FileUpload5.FileName;
        }
        if (FileUpload6.HasFile == false)
        {
            img6 = im6.Value;

        }
        else
        {
            FileUpload6.SaveAs(Server.MapPath("RotatorImages\\" + FileUpload6.FileName));
            img6 = "RotatorImages/" + FileUpload6.FileName;
        }

      

            using (SqlConnection conn = db.getDBConnection())
            {
                conn.Open();
                SqlCommand com = new SqlCommand("Update dpcrImages SET rmImage1=@image1, rmImage2=@image2, rmImage3=@image3, rmImage4=@image4, rmImage5=@image5, rmImage6=@image6 Where rmID=@ID", conn);

                com.Parameters.AddWithValue("@ID", currentID);
                com.Parameters.AddWithValue("@image1", img1);
                com.Parameters.AddWithValue("@image2", img2);
                com.Parameters.AddWithValue("@image3", img3);
                com.Parameters.AddWithValue("@image4", img4);
                com.Parameters.AddWithValue("@image5", img5);
                com.Parameters.AddWithValue("@image6", img6);
                
                com.ExecuteNonQuery();

                conn.Close();

            }
            ClientScript.RegisterStartupScript(csType, "Updated", scriptPicUpdated);
            return;
        
    }

    protected void updateDetailsBtn_Click(object sender, EventArgs e)
    {
        Type csType = this.GetType();


        using (SqlConnection conn = db.getDBConnection())
        {
            conn.Open();

            SqlCommand com = new SqlCommand("Update dpcrImages SET rmName = @name, rmCat=@cat, rmStatus=@status, rmDesc=@desc, rmNotes=@notes, rmEditedOn=@edited Where rmID=@ID", conn);
            com.Parameters.AddWithValue("@ID", currentID);
            com.Parameters.AddWithValue("@name", itemname.Text);
            com.Parameters.AddWithValue("@cat", itemcat.SelectedValue.ToString());
            com.Parameters.AddWithValue("@status", itemstatus.SelectedValue.ToString());
            com.Parameters.AddWithValue("@desc", txtDesc.Text);
            com.Parameters.AddWithValue("@notes", txtNotes.Text);
            com.Parameters.AddWithValue("@edited", DateTime.Now);


            com.ExecuteNonQuery();

            conn.Close();
            ClientScript.RegisterStartupScript(csType, "Update Complete", scriptUpdateSuccess);


        }

    }
}