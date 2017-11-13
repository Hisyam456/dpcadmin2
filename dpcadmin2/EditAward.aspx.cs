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

public partial class EditAward : System.Web.UI.Page
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
  "alert(\"Award Picture Successfully Updated!\");\n" +
  "</script>";

    static readonly string scriptBrandError =
"<script language=\"javascript\">\n" +
"alert(\"Please select a Brand!\");\n" +
"</script>";

    static readonly string scriptUpdateSuccess =
"<script language=\"javascript\">\n" +
"alert(\"Successfully Updated Award!\");\n" +
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

        currentID = Request.QueryString["awardID"];

        try
        {

            if (!Page.IsPostBack)
            {
                using (SqlConnection conn = db.getDBConnection())
                {
                    conn.Open();
                    SqlCommand com = new SqlCommand("Select * from dpcAwards Where awID = @currentID", conn);
                    com.Parameters.AddWithValue("@currentID", currentID);

                    SqlDataReader dr = com.ExecuteReader();

                    while (dr.Read())
                    {
                        if (dr.HasRows == true)
                        {

                            txtDesc.Text = dr[1].ToString();
                            awardname.Text = dr[3].ToString();

                            dr.Close();
                            conn.Close();
                            return;
                        }

                    }
                    if (dr.HasRows == false)
                    {
                        dr.Close();
                        conn.Close();
                        Response.Redirect("ManageAwards.aspx");

                    }
                }

            }
        }

        catch
        {
            Response.Redirect("ManageAwards.aspx");
        }
    }

    protected void updateawardPic_Click(object sender, EventArgs e)
    {
        Type csType = this.GetType();

        if (FileUpload1.HasFile == false)
        {
            ClientScript.RegisterStartupScript(csType, "No Picture Selected", scriptpicError);
            return;
        }

        FileUpload1.SaveAs(Server.MapPath("AwardImages\\" + FileUpload1.FileName));
        string img1 = "AwardImages/" + FileUpload1.FileName;

        using (SqlConnection conn = db.getDBConnection())
        {
            conn.Open();
            SqlCommand com = new SqlCommand("Update dpcAwards SET awPic=@image1, editedOn=@edited Where awID=@ID", conn);

            com.Parameters.AddWithValue("@ID", currentID);
            com.Parameters.AddWithValue("@image1", img1);
            com.Parameters.AddWithValue("@edited", DateTime.Now);

            com.ExecuteNonQuery();

            conn.Close();

        }

        ClientScript.RegisterStartupScript(csType, "Updated", scriptPicUpdated);
        return;
    }

    protected void updateDetailsaward_Click(object sender, EventArgs e)
    {
        Type csType = this.GetType();


        using (SqlConnection conn = db.getDBConnection())
        {
            conn.Open();

            SqlCommand com = new SqlCommand("Update dpcAwards SET awName = @name, awDesc=@desc, editedOn=@edited Where awID=@ID", conn);
            com.Parameters.AddWithValue("@ID", currentID);
            com.Parameters.AddWithValue("@name", awardname.Text);
            com.Parameters.AddWithValue("@desc", txtDesc.Text);
            com.Parameters.AddWithValue("@edited", DateTime.Now);


            com.ExecuteNonQuery();

            conn.Close();
            ClientScript.RegisterStartupScript(csType, "Update Complete", scriptUpdateSuccess);


        }

    }
}