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

public partial class ManageProducts : System.Web.UI.Page
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

    static productForm form = new productForm();
    static Database db = new Database();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!User.Identity.IsAuthenticated)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "NOT AUTHORIZED" + "');", true);
            Response.Redirect("login.aspx");

        }

        DateTime now = DateTime.Now;

        if(!Page.IsPostBack)
        {
            fillGrid();
        }

    }


    protected void submitbtn_Click(object sender, EventArgs e)
    {
        Type csType = this.GetType();
        string itemName, itemCat, itemStatus, itemDesc, itemNotes, itemPic; 
        DateTime createdOn, editedOn; 
        
        itemName = itemname.Text;
        itemCat = itemcat.SelectedValue.ToString();
        itemStatus = itemstatus.SelectedValue.ToString();
        itemDesc = txtDesc.Text;
        itemNotes = txtNotes.Text; 
        FileUpload1.SaveAs(Server.MapPath("ProductImages\\" + FileUpload1.FileName));
        itemPic = "ProductImages/" + FileUpload1.FileName;
        createdOn = DateTime.Now; 
        editedOn = DateTime.Now;


        form.submitProduct(itemName, itemCat, itemStatus, itemDesc, itemNotes, itemPic, createdOn, editedOn);
        Debug.WriteLine("Submitted Product Form");

        ClientScript.RegisterStartupScript(csType, "Updated", scriptProdAdded);

        Response.Redirect("ManageProducts.aspx"); 

    }

    private void fillGrid()
    {
        SqlConnection connection = db.getDBConnection();


        SqlCommand retrieve = new SqlCommand("Select * from dpcProducts", connection);

        connection.Open();


        DataSet ds = new DataSet();

        SqlDataAdapter sda = new SqlDataAdapter(retrieve);
        sda.Fill(ds);
        connection.Close();

        gvProductState.DataSource = ds;
        gvProductState.DataBind();
    }

    protected void gvProductState_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
       

            Label L1 = gvProductState.Rows[e.RowIndex].FindControl("lblId") as Label;
            //Label L2 = gvProductState.Rows[e.RowIndex].FindControl("Image1") as Label;
            //File.Delete(Server.MapPath("~/" + L2)); 
            

            SqlConnection connection = db.getDBConnection();
            connection.Open();

            SqlCommand cmd = new SqlCommand("Delete from dpcProducts where pID=@id");
            cmd.Connection = connection;
            cmd.Parameters.AddWithValue("@id", L1.Text);
            

            cmd.ExecuteNonQuery();
            Debug.WriteLine("Product Deleted");
            fillGrid();
      
          
    }
}