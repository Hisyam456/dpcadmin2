using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class EditPackage : System.Web.UI.Page
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

    static readonly string scriptPassSuccess =
"<script language=\"javascript\">\n" +
"alert(\"Password Updated Succesfully \");\n" +
"</script>";

    static readonly string scriptUpdateSuccess =
"<script language=\"javascript\">\n" +
"alert(\"Successfully Updated Rotator Package!\");\n" +
"</script>";

    static readonly string scriptRotatorDeleted =
  "<script language=\"javascript\">\n" +
  "alert(\"Rotator Image Deleted!\");\n" +
  "</script>";

    string currentID;

    static Database db = new Database(); 

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!User.Identity.IsAuthenticated)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "NOT AUTHORIZED" + "');", true);
            Response.Redirect("login.aspx");

        }

        currentID = Request.QueryString["packageID"];

        

        try
        {

            if (!Page.IsPostBack)
            {
                fillGrid();
                using (SqlConnection conn = db.getDBConnection())
                {

                    conn.Open();
                    SqlCommand com = new SqlCommand("Select * from dpcrPackages Where rpID = @currentID", conn);
                    com.Parameters.AddWithValue("@currentID", currentID);

                    SqlDataReader dr = com.ExecuteReader();

                    while (dr.Read())
                    {
                        if (dr.HasRows == true)
                        {

                            rtPemail.Text = dr[1].ToString();
                            rtPstatus.Text = dr[2].ToString();
                            rtaccess.Text = dr[5].ToString();
                            txtPname.Text = dr[6].ToString();
                            

                            dr.Close();
                            conn.Close();
                            return;
                        }

                    }
                    if (dr.HasRows == false)
                    {
                        dr.Close();
                        conn.Close();
                        Response.Redirect("EditRotatorPackage.aspx");

                    }
                }

            }
        }

        catch
        {
            Response.Redirect("EditRotatorPackage.aspx");
        }

    }

    protected void submitdetails_Click(object sender, EventArgs e)
    {
        Type csType = this.GetType();
        string rpName, rpEmail, rPStatus;
        int rpraccess;
        DateTime rpUpdated; 

        rpName = txtPname.Text;
        rPStatus = rtPstatus.SelectedValue.ToString();
        rpEmail = rtPemail.Text;
        rpraccess = int.Parse(rtaccess.SelectedValue.ToString());
        rpUpdated = DateTime.Now;

        try
        {
            using (SqlConnection conn = db.getDBConnection())
            {
                conn.Open();

                SqlCommand com = new SqlCommand("Update dpcrPackages SET rpName = @name, rpStatus=@status, rpEmail=@email, rpAccess=@access, rpUpdatedTime=@updated Where rpID=@ID", conn);
                com.Parameters.AddWithValue("@ID", currentID);
                com.Parameters.AddWithValue("@name", rpName);
                com.Parameters.AddWithValue("@status", rPStatus);
                com.Parameters.AddWithValue("@email", rpEmail);
                com.Parameters.AddWithValue("@access", rpraccess);
                com.Parameters.AddWithValue("@updated", rpUpdated);

                com.ExecuteNonQuery();

                conn.Close();
                Debug.WriteLine("Rotator Package Updated!");
                ClientScript.RegisterStartupScript(csType, "Update Complete", scriptUpdateSuccess);

            }
        }

        catch(Exception ex)
        {
            Debug.WriteLine(ex.Message);
        }
    }


    protected void submitPass_Click(object sender, EventArgs e)
    {
        Type csType = this.GetType();

        try
        {
            using (SqlConnection conn = db.getDBConnection())
            {
                conn.Open();
                string salted = RandomString();
                SqlCommand com = new SqlCommand("Update dpcrPackages SET rpSalt=@salt, adminPass=@pass Where rpID=@ID", conn);
                com.Parameters.AddWithValue("ID", currentID); 
                com.Parameters.AddWithValue("@salt", salted);
                com.Parameters.AddWithValue("@pass", RandomPass(salted, txtPass.Text));
                com.ExecuteNonQuery();

                conn.Close();
                Debug.WriteLine("Rotator Package Password Updated!");
                ClientScript.RegisterStartupScript(csType, "Update Password Complete", scriptPassSuccess);

            }
        }

        catch(Exception ex)
        {
            Debug.WriteLine(ex.Message); 
        }
    }

    private static Random random = new Random();

    public static string RandomString()
    {
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        return new string(Enumerable.Repeat(chars, 16)
          .Select(s => s[random.Next(s.Length)]).ToArray());
    }

    public static string RandomPass(string salt, string password)
    {
        var saltt = System.Text.Encoding.UTF8.GetBytes(salt);
        var passwordt = System.Text.Encoding.UTF8.GetBytes(password);

        var hmacSHA1 = new HMACSHA1(saltt);
        var saltedHash = hmacSHA1.ComputeHash(passwordt);

        return System.Text.Encoding.UTF8.GetString(saltedHash);

    }

    private void fillGrid()
    {
        SqlConnection connection = db.getDBConnection();


        SqlCommand retrieve = new SqlCommand("Select * from dpcRotatorCart where rotatorPackageID=@id", connection);
        retrieve.Parameters.AddWithValue("@id", currentID); 
        connection.Open();

        SqlDataReader dr = retrieve.ExecuteReader();

        while (dr.Read())
        {
            if (dr.HasRows == true)
            {
                connection.Close();
                connection.Open();
                DataSet ds = new DataSet();
                SqlDataAdapter sda = new SqlDataAdapter(retrieve);
                sda.Fill(ds);
                connection.Close();

                gvCartState.DataSource = ds;
                gvCartState.DataBind();
                return;
            }

        }
        if (dr.HasRows == false)
        {
            dr.Close();
            connection.Close();
        }

    }

    protected void gvCartState_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

        Label L1 = gvCartState.Rows[e.RowIndex].FindControl("lblCart") as Label;
        //Label L2 = gvProductState.Rows[e.RowIndex].FindControl("Image1") as Label;
        //File.Delete(Server.MapPath("~/" + L2)); 
        SqlConnection connection = db.getDBConnection();
        connection.Open();

        SqlCommand cmr = new SqlCommand("Delete from dpcRotatorCart where rcartID=@id");
        cmr.Connection = connection;
        cmr.Parameters.AddWithValue("id", L1.Text);
        cmr.ExecuteNonQuery();

        Debug.WriteLine("Rotator Cart Deleted");
        fillGrid();
        //Type csType = this.GetType();
        //ClientScript.RegisterStartupScript(csType, "Deleted", scriptRotatorDeleted);
        Response.Redirect("EditPackage.aspx");


    }
}