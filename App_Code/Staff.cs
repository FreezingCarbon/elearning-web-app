using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Sql;
using System.Data.SqlClient;

public class Staff : User
{
    public bool isAdmin;

    public Staff(int userID, string username, string password, string name, string mail,
        DateTime lastSeen, bool isAdmin) : base(userID, username, password, name, mail, lastSeen)
    {
        this.isAdmin = isAdmin;
    }

    static public Staff GetUserById(int staffId)
    {
        SqlCommand cmd = new SqlCommand();
        SqlConnection con = DatabaseConnectionFactory.GetConnection();
        cmd.Connection = con;
        cmd.CommandText = "select * from [User] where  id = " + staffId;
        SqlDataReader dataReader = cmd.ExecuteReader();
        Staff staff = null;
        if (dataReader.Read())
        {
            if (!dataReader.GetValue(6).ToString().Equals("staff"))
                throw new Exception("the user with the specified id is not a staff");

            staff = new Staff(Convert.ToInt32(dataReader.GetValue(0)),
                              dataReader.GetValue(1).ToString(),
                              dataReader.GetValue(2).ToString(),
                              dataReader.GetValue(3).ToString(),
                              dataReader.GetValue(4).ToString(),
                              Convert.ToDateTime(dataReader.GetValue(5)),
                              Convert.ToBoolean(dataReader.GetValue(7)));
        }
        cmd.Connection.Close();
        return staff;
    }

    public override List<List<string>> GetSchedule()
    {
        throw new NotSupportedException("GetSchedule() is not supported by type Staff");
    }
}