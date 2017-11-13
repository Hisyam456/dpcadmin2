using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for addtoCart
/// </summary>
public class addtoCart
{
	public addtoCart()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    static Database db = new Database();

    public bool submitImagerPackage(string imageID, string rpID, DateTime rpTime)
    {
        try
        {
            using (SqlConnection connection = db.getDBConnection())
            {
                // Write insert statement 
                SqlCommand cmd = new SqlCommand("INSERT INTO dpcRotatorCart(rotatorImageID, rotatorPackageID, createdOn) VALUES (@imageid, @packageid, @createdon)");
                cmd.CommandType = CommandType.Text;
                cmd.Connection = connection;
                cmd.Parameters.AddWithValue("@imageid", imageID);
                cmd.Parameters.AddWithValue("@packageid", rpID);
                cmd.Parameters.AddWithValue("@createdon", rpTime);

                connection.Open();
                cmd.ExecuteNonQuery();
                Debug.WriteLine("Image Added to Package ");
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