using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Sql;
using System.Data.SqlClient;

/// <summary>
/// Summary description for DatabaseConnectionFactory
/// </summary>
public class DatabaseConnectionFactory
{
    private DatabaseConnectionFactory()
    {
    }

    static public SqlConnection GetConnection()
    {
        SqlConnection con = new SqlConnection(@"server = .; Database = ELearning_ERP; trusted_connection=true; MultipleActiveResultSets=True");
        con.Open();
        return con;
    }
}