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

public partial class EditProducts : System.Web.UI.Page
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

        currentID = Request.QueryString["productID"];

        try
        {

            if (!Page.IsPostBack)
            {
                using (SqlConnection conn = db.getDBConnection())
                {
                    conn.Open();
                    SqlCommand com = new SqlCommand("Select * from dpcProducts Where pID = @currentID", conn);
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
                            
                            dr.Close();
                            conn.Close();
                            return;
                        }

                    }
                    if (dr.HasRows == false)
                    {
                        dr.Close();
                        conn.Close();
                        Response.Redirect("ManageProducts.aspx");

                    }
                }

            }
        }

        catch
        {
            Response.Redirect("ManageProducts.aspx");
        }
    }

    protected void updatePic_Click(object sender, EventArgs e)
    {
        Type csType = this.GetType();

        if (FileUpload1.HasFile == false)
        {
            ClientScript.RegisterStartupScript(csType, "No Picture Selected", scriptpicError);
            return; 
        }

        FileUpload1.SaveAs(Server.MapPath("ProductImages\\" + FileUpload1.FileName));
        string img1 = "ProductImages/" + FileUpload1.FileName;

        using (SqlConnection conn = db.getDBConnection())
        {
            conn.Open();
            SqlCommand com = new SqlCommand("Update dpcProducts SET pImage=@image1 Where pID=@ID", conn);

            com.Parameters.AddWithValue("@ID", currentID);
            com.Parameters.AddWithValue("@image1", img1);
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

            SqlCommand com = new SqlCommand("Update dpcProducts SET pName = @name, pCat=@cat, pStatus=@status, pDesc=@desc, pNotes=@notes, pEditedOn=@edited Where pID=@ID", conn);
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