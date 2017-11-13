using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Database
/// </summary>
public class Database
{
    string connectionString = "Server='axensionsqlone.database.windows.net';Database=DesignPackagingConcept;User ID=axension88;Password=DonkeyE!ephant;";
    public Database()
    {
       
    }

    public SqlConnection getDBConnection()
    {
        SqlConnection connection = new SqlConnection(connectionString);
        return connection;
    }
}