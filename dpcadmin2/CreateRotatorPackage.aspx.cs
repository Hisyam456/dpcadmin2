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

public partial class CreateRotatorPackage : System.Web.UI.Page
{
    static RotatorPackageForm rotatorPform = new RotatorPackageForm();
    static addtoCart addcartform = new addtoCart();
    static Database db = new Database();

    static readonly string scriptError =
   "<script language=\"javascript\">\n" +
   "alert(\"Something went wrong, Internal Error: Please contact Tech Department!\");\n" +
   "</script>";

    static readonly string scriptImageAdded =
  "<script language=\"javascript\">\n" +
  "alert(\"Rotator Image Succesfully Added to Rotator Package\");\n" +
  "</script>";

    static readonly string scriptProdAdded =
  "<script language=\"javascript\">\n" +
  "alert(\"Rotator Package Has been added!\");\n" +
  "</script>";


    static readonly string scriptProdDeleted =
  "<script language=\"javascript\">\n" +
  "alert(\"Please fill up the form completely!\");\n" +
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

    protected void submitrp_Click(object sender, EventArgs e)
    {
        try
        {

            string rpName, rpEmail, rpStatus, rpPass;
            DateTime rpCTime;
            int rpaccess;

            rpName = txtPname.Text;
            rpEmail = rtPemail.Text;
            rpStatus = rtPstatus.SelectedValue.ToString();
            rpPass = adminPass.Text;
            rpCTime = DateTime.Now;
            rpaccess = int.Parse(rtaccess.SelectedValue);


            rotatorPform.submitRotatorPackage(rpEmail, rpStatus, rpPass, rpaccess, rpCTime, rpName);

            // rotatorPform.submitRotatorPackage(itemName, itemCat, itemStatus, itemDesc, itemNotes, itemImage1, itemImage2, itemImage3, itemImage4, itemImage5, itemImage6, itemCode, expdate, createdOn, editedOn);
            Debug.WriteLine("Submitted Rotator Package Form");

        }
        catch
        {
            Type csType = this.GetType();
            ClientScript.RegisterStartupScript(csType, "Error", scriptError);

        }

        if (Page.IsPostBack == true)
        {
            Type csType = this.GetType();
            txtPname.Text = "";
            rtPemail.Text = "";
            rtPstatus.SelectedIndex = 0;
            rtaccess.SelectedIndex = 0;
            adminPass.Text = "";
            ClientScript.RegisterStartupScript(csType, "Success", scriptProdAdded);
           // Response.Redirect("CreateRotatorPackage.aspx");

        }

    }

     protected void submitIP_Click(object sender, EventArgs e)
    {
        try
        {
            Type csType = this.GetType();
            string imageID, rpID;
            DateTime createdon;

            imageID = ddlrimID.SelectedValue.ToString();
            rpID = ddlrpID.SelectedValue.ToString();
            createdon = DateTime.Now;

            addcartform.submitImagerPackage(imageID, rpID, createdon);
            ClientScript.RegisterStartupScript(csType, "Success", scriptImageAdded);
        }
       catch
        {
            Type csType = this.GetType();
            ClientScript.RegisterStartupScript(csType, "Error", scriptError);
        }
     }
}