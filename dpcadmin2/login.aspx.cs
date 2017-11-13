using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Mail;
using System.Reflection;
using System.Web;
using System.Web.Configuration;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;




public partial class login : System.Web.UI.Page
{
    static readonly string scriptVoted =
"<script language=\"javascript\">\n" +
"alert(\"Submission Accepted!\");\n" +
"</script>";
  
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }

    protected void loginBtn_Click(object sender, EventArgs e)
    {

        if (UserName.Text == null)
        {
            UserNameRequired.Text = "UserName is required!";
        }
        else if (Password.Text == null)
        {
            PasswordRequired.Text = "Password is required!";
        }
        if (UserName.Text != null && Password.Text != null)
        {

            if (UserName.Text.Equals("admindng") && Password.Text.Equals("AdminDNG"))
            {
                if (RememberMe.Checked)
                {
                    FormsAuthenticationTicket authTicket = new FormsAuthenticationTicket(UserName.Text, true, 12 * 60);
                    string encryptedTicket = FormsAuthentication.Encrypt(authTicket);
                    HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
                    cookie.Expires = authTicket.Expiration;
                    HttpContext.Current.Response.Cookies.Set(cookie);
                }
                else
                {
                    FormsAuthentication.SetAuthCookie(UserName.Text, false);
                }
                Response.Redirect("Default.aspx");
            }
            else
            {
                FailureText.Text = "Wrong Username or Password";
            }
        }

    }

   
}