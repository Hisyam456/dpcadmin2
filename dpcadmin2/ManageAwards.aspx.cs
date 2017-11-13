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

public partial class ManageAwards : System.Web.UI.Page
{
    static awardForm form = new awardForm();
    static Database db = new Database();

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

    protected void submitaward_Click(object sender, EventArgs e)
    {
        string itemName, itemDesc, itemPic;
        DateTime createdOn, editedOn;

        itemName = awardname.Text;
        itemDesc = txtDesc.Text;
        FileUpload1.SaveAs(Server.MapPath("AwardImages\\" + FileUpload1.FileName));
        itemPic = "AwardImages/" + FileUpload1.FileName;
        createdOn = DateTime.Now;
        editedOn = DateTime.Now;


        form.submitAward(itemName, itemDesc, itemPic, createdOn, editedOn); 
        Debug.WriteLine("Submitted Award Form");
        fillGrid(); 
    }

    private void fillGrid()
    {
        SqlConnection connection = db.getDBConnection();


        SqlCommand retrieve = new SqlCommand("Select * from dpcAwards", connection);

        connection.Open();


        DataSet ds = new DataSet();

        SqlDataAdapter sda = new SqlDataAdapter(retrieve);
        sda.Fill(ds);
        connection.Close();

        gvAwardState.DataSource = ds;
        gvAwardState.DataBind();
    }

    protected void gvAwardState_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {


        Label L1 = gvAwardState.Rows[e.RowIndex].FindControl("lblawID") as Label;
        //Label L2 = gvProductState.Rows[e.RowIndex].FindControl("Image1") as Label;
        //File.Delete(Server.MapPath("~/" + L2)); 


        SqlConnection connection = db.getDBConnection();
        connection.Open();

        SqlCommand cmd = new SqlCommand("Delete from dpcAwards where awID=@id");
        cmd.Connection = connection;
        cmd.Parameters.AddWithValue("@id", L1.Text);


        cmd.ExecuteNonQuery();
        Debug.WriteLine("Award Deleted");
        fillGrid();


    }
}