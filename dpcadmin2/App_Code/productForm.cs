using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for productForm
/// </summary>
public class productForm
{
	public productForm()
	{
		
	}

    static Database db = new Database(); 

    public bool submitProduct(string pname, string pcat, string pstatus, string pdesc, string pnotes, string pimage, DateTime pcreatedon, DateTime peditedon)
    { 
        try
        {
            using (SqlConnection connection = db.getDBConnection())
            {
                // Write insert statement 
                SqlCommand cmd = new SqlCommand("INSERT INTO dpcProducts (pName, pCat, pStatus, pDesc, pNotes, pImage, pCreatedOn, pEditedOn) VALUES (@name, @cat, @status, @desc, @notes, @image, @createdon, @editedon)");
                cmd.CommandType = CommandType.Text;
                cmd.Connection = connection;
                cmd.Parameters.AddWithValue("@name", pname);
                cmd.Parameters.AddWithValue("@cat", pcat);
                cmd.Parameters.AddWithValue("@status", pstatus);
                cmd.Parameters.AddWithValue("@desc", pdesc);
                cmd.Parameters.AddWithValue("@notes", pnotes);
                cmd.Parameters.AddWithValue("@image", pimage);
                cmd.Parameters.AddWithValue("@createdon", pcreatedon);
                cmd.Parameters.AddWithValue("@editedon", peditedon);
               
                connection.Open();
                cmd.ExecuteNonQuery();
                Debug.WriteLine("Product Submitted");
                return true; 
            }
        }

        catch (SqlException ex)
        {
            Debug.WriteLine(ex.Message);
            return false; 
        }
    }

  
}