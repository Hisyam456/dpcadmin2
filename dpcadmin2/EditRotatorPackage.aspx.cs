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

public partial class EditRotatorPackage : System.Web.UI.Page
{
    static Database db = new Database();

    static readonly string scriptProdDeleted =
 "<script language=\"javascript\">\n" +
 "alert(\"Rotator Image has been deleted from package!\");\n" +
 "</script>";

    static readonly string scriptRotatorDeleted =
  "<script language=\"javascript\">\n" +
  "alert(\"Rotator Package Deleted!\");\n" +
  "</script>";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!User.Identity.IsAuthenticated)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "NOT AUTHORIZED" + "');", true);
            Response.Redirect("login.aspx");

        }

        if (!Page.IsPostBack)
        {
            fillGrid();
        }
    }

    private void fillGrid()
    {
        SqlConnection connection = db.getDBConnection();


        SqlCommand retrieve = new SqlCommand("Select * from dpcrPackages", connection);

        connection.Open();


        DataSet ds = new DataSet();

        SqlDataAdapter sda = new SqlDataAdapter(retrieve);
        sda.Fill(ds);
        connection.Close();

        gvPackagestate.DataSource = ds;
        gvPackagestate.DataBind();
    }

    protected void gvPackagestate_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            Label L1 = gvPackagestate.Rows[e.RowIndex].FindControl("lblrpID") as Label;
            //Label L2 = gvProductState.Rows[e.RowIndex].FindControl("Image1") as Label;
            //File.Delete(Server.MapPath("~/" + L2)); 
            SqlConnection connection = db.getDBConnection();

            SqlCommand retrieve = new SqlCommand("Select * from dpcRotatorCart where rotatorPackageID=@id", connection);
            retrieve.Parameters.AddWithValue("@id", L1.Text);
            connection.Open();

            SqlDataReader dr = retrieve.ExecuteReader();


            if (dr.HasRows == true)
            {
                Debug.WriteLine("Has rows");
                while (dr.HasRows)
                {
                    Debug.WriteLine("Iterating through rows");
                    Debug.WriteLine("Deleting rpID row" + L1.Text);
                    SqlCommand cmr = new SqlCommand("Delete from dpcRotatorCart where rotatorPackageID=@id");
                    cmr.Connection = db.getDBConnection();
                    ;
                    cmr.Parameters.AddWithValue("id", L1.Text);
                    (cmr.Connection).Open();

                    cmr.ExecuteNonQuery();
                    (cmr.Connection).Close();

                    Debug.WriteLine("Deleting dpcPackage row" + L1.Text);
                    SqlCommand cmrd = new SqlCommand("Delete from dpcrPackages where rpID=@id");
                    cmrd.Connection = db.getDBConnection();
                    cmrd.Parameters.AddWithValue("@id", L1.Text);
                    (cmrd.Connection).Open();
                    cmrd.ExecuteNonQuery();
                    (cmrd.Connection).Close();                   
                    //return;
                    
                }

            }

            else
            {
                Debug.WriteLine("Has no rows");


                SqlCommand cmd = new SqlCommand("Delete from dpcrPackages where rpID=@id");
                cmd.Connection = db.getDBConnection();
                cmd.Parameters.AddWithValue("@id", L1.Text);
                (cmd.Connection).Open();
                cmd.ExecuteNonQuery();
                (cmd.Connection).Close();
            }


            Debug.WriteLine("Package Deleted");
            fillGrid();
            //Type csType = this.GetType();
            //ClientScript.RegisterStartupScript(csType, "Deleted", scriptRotatorDeleted);
            Response.Redirect("EditRotatorPackage.aspx");
        }

        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
        }


    }
}