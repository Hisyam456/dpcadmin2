using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
/// <summary>
/// Summary description for RotatorPackageForm
/// </summary>
public class RotatorPackageForm
{
	public RotatorPackageForm()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    static Database db = new Database();

    public bool submitRotatorPackage(string rpemail, string rpstatus, string rpPass, int accessno, DateTime rpTime, string rpName)
    {

        try
        {
            using (SqlConnection connection = db.getDBConnection())
            {
                // Write insert statement 
                string salt = RandomString();
                SqlCommand cmd = new SqlCommand("INSERT INTO dpcrPackages (rpID, rpEmail, rpStatus, rpCreationTime, adminPass, rpAccess, rpName, rpSalt, rpUpdatedTime) VALUES (@id, @email, @status, @creationtime, @password, @accessno, @name, @salt, @time)");
                cmd.CommandType = CommandType.Text;
                cmd.Connection = connection;
                cmd.Parameters.AddWithValue("@id", RandomString());
                cmd.Parameters.AddWithValue("@email", rpemail);
                cmd.Parameters.AddWithValue("@status", rpstatus);
                cmd.Parameters.AddWithValue("@creationtime", rpTime);
                cmd.Parameters.AddWithValue("@password", RandomPass(salt, rpPass));                
                cmd.Parameters.AddWithValue("@accessno", accessno);
                cmd.Parameters.AddWithValue("@name", rpName);
                cmd.Parameters.AddWithValue("@salt", salt);
                cmd.Parameters.AddWithValue("@time", DateTime.Now);

                connection.Open();
                cmd.ExecuteNonQuery();
                Debug.WriteLine("Package Submitted");
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


}