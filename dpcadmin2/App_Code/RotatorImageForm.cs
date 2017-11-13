using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for RotatorImageForm
/// </summary>
public class RotatorImageForm
{
	public RotatorImageForm()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    static Database db = new Database(); 

    public bool submitRotatorImage(string rmname, string rmcat, string rmstatus, string rmdesc, string rmnotes, string rmimage1, string rmImage2, string rmImage3, string rmImage4, string rmImage5, string rmImage6, DateTime rmcreatedon, DateTime rmeditedon)
    {
        try
        {
            using (SqlConnection connection = db.getDBConnection())
            {
                // Write insert statement 
                SqlCommand cmd = new SqlCommand("INSERT INTO dpcrImages (rmID, rmName, rmCat, rmStatus, rmDesc, rmNotes, rmImage1,rmImage2, rmImage3, rmImage4, rmImage5, rmImage6, rmCreatedOn, rmEditedOn) VALUES (@id, @name, @cat, @status, @desc, @notes, @image1, @image2, @image3, @image4, @image5, @image6,  @createdon, @editedon)");
                cmd.CommandType = CommandType.Text;
                cmd.Connection = connection;
                cmd.Parameters.AddWithValue("@id", RandomString());
                cmd.Parameters.AddWithValue("@name", rmname);
                cmd.Parameters.AddWithValue("@cat", rmcat);
                cmd.Parameters.AddWithValue("@status", rmstatus);
                cmd.Parameters.AddWithValue("@desc", rmdesc);
                cmd.Parameters.AddWithValue("@notes", rmnotes);
                cmd.Parameters.AddWithValue("@image1", rmimage1);
                cmd.Parameters.AddWithValue("@image2", rmImage2);
                cmd.Parameters.AddWithValue("@image3", rmImage3);
                cmd.Parameters.AddWithValue("@image4", rmImage4);
                cmd.Parameters.AddWithValue("@image5", rmImage5);
                cmd.Parameters.AddWithValue("@image6", rmImage6);
                cmd.Parameters.AddWithValue("@createdon", rmcreatedon);
                cmd.Parameters.AddWithValue("@editedon", rmeditedon);

                connection.Open();
                cmd.ExecuteNonQuery();
                Debug.WriteLine("Rotator Image Submitted");
                return true;
            }
        }

        catch (SqlException ex)
        {
            Debug.WriteLine(ex.Message);
            
            return false;
        }
    }

    private static Random random = new Random();
    //Create a new random string for dngrPackages rpID
    // Create a salt to add with a password string for md5hash password
    public static string RandomString()
    {
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        return new string(Enumerable.Repeat(chars, 16)
          .Select(s => s[random.Next(s.Length)]).ToArray());
    }
}