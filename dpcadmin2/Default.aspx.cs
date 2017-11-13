using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;



public partial class Default : System.Web.UI.Page
{
    static readonly string scriptSuccess =
   "<script language=\"javascript\">\n" +
   "alert(\"Thank You! You have submmitted successfully.\");\n" +
   "</script>";

    static readonly string scriptFail =
  "<script language=\"javascript\">\n" +
  "alert(\"Sorry! You have encountered an error. Please contact us a imagines@microsoft.com with your error details.\");\n" +
  "</script>";
  
  static readonly string scriptFailEmail =
  "<script language=\"javascript\">\n" +
  "alert(\"Sorry! Your email has already been used to submit an entry previously.\");\n" +
  "</script>";
  static readonly string scriptFailEmail2 =
  "<script language=\"javascript\">\n" +
  "alert(\"Sorry! Your email is not a valid educational e-mail.\");\n" +
  "</script>";
 
   static readonly string scriptFailURL =
  "<script language=\"javascript\">\n" +
  "alert(\"Sorry! You have already submitted this URL.\");\n" +
  "</script>";
   static readonly string scriptFailURL2 =
  "<script language=\"javascript\">\n" +
  "alert(\"Sorry! Please submit an azurewebsites.net related domain.\");\n" +
  "</script>";
   static readonly string scriptFailHP =
 "<script language=\"javascript\">\n" +
 "alert(\"Sorry! Your Handphone number has already been used to submit an entry previously.\");\n" +
 "</script>";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!User.Identity.IsAuthenticated)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "NOT AUTHORIZED" + "');", true);
            Response.Redirect("login.aspx");

        }

    }

   
}