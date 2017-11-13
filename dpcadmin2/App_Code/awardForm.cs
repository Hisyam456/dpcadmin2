using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for awardForm
/// </summary>
public class awardForm
{
	public awardForm()
	{

	}

    static Database db = new Database();

    public bool submitAward(string awname, string awDesc, string awimage, DateTime awcreatedon, DateTime aweditedon)
    {
        try
        {
            using (SqlConnection connection = db.getDBConnection())
            {
                // Write insert statement 
                SqlCommand cmd = new SqlCommand("INSERT INTO dpcAwards (awName, awDesc, awPic, createdOn, editedOn) VALUES (@name, @desc, @image, @createdon, @editedon)");
                cmd.CommandType = CommandType.Text;
                cmd.Connection = connection;
                cmd.Parameters.AddWithValue("@name", awname);
                cmd.Parameters.AddWithValue("@desc", awDesc);
                cmd.Parameters.AddWithValue("@image", awimage);
                cmd.Parameters.AddWithValue("@createdon", awcreatedon);
                cmd.Parameters.AddWithValue("@editedon", aweditedon);

                connection.Open();
                cmd.ExecuteNonQuery();
                Debug.WriteLine("Award Submitted");
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