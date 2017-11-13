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

public partial class EditRotator : System.Web.UI.Page
{
    
    static Database db = new Database();

    static readonly string scriptRotatorDeleted =
   "<script language=\"javascript\">\n" +
   "alert(\"Rotator Image Deleted!\");\n" +
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

        DateTime now = DateTime.Now;
    }

    private void fillGrid()
    {
        SqlConnection connection = db.getDBConnection();


        SqlCommand retrieve = new SqlCommand("Select * from dpcrImages", connection);

        connection.Open();


        DataSet ds = new DataSet();

        SqlDataAdapter sda = new SqlDataAdapter(retrieve);
        sda.Fill(ds);
        connection.Close();

        gvrtImageState.DataSource = ds;
        gvrtImageState.DataBind();
    }

    protected void gvrtImageState_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

        Label L1 = gvrtImageState.Rows[e.RowIndex].FindControl("lblrmId") as Label;
        //Label L2 = gvProductState.Rows[e.RowIndex].FindControl("Image1") as Label;
        //File.Delete(Server.MapPath("~/" + L2)); 


        SqlConnection connection = db.getDBConnection();
        connection.Open();

        SqlCommand cmd = new SqlCommand("Delete from dpcrImages where rmID=@id");
        cmd.Connection = connection;
        cmd.Parameters.AddWithValue("@id", L1.Text);


        cmd.ExecuteNonQuery();
        Debug.WriteLine("Product Deleted");
        //Type csType = this.GetType();
        //ClientScript.RegisterStartupScript(csType, "Deleted", scriptRotatorDeleted);
        fillGrid();
        Response.Redirect("EditRotator.aspx");


    }
}