using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Sql;
using System.Data.SqlClient;

public class Staff : ELearn.User
{
    public bool isAdmin;

    public Staff(int userID, string username, string password, string name, string mail,
        DateTime lastSeen, bool isAdmin) : base(userID, username, password, name, mail, lastSeen)
    {
        this.isAdmin = isAdmin;
    }
    public override void update(String nName, string nUser, string nMail, string nPass)
    {
        SqlCommand cmd = new SqlCommand();
        SqlConnection con = DatabaseConnectionFactory.GetConnection();
        cmd.Connection = con;
        cmd.CommandText = "update [User] set userName='" + nUser + "',password ='"
                            + nPass + "',name= '"
                            + nName + "',mail='"
                            + nMail + "' where id=" + userID;
        ;
        cmd.ExecuteNonQuery();


        this.username = nUser;
        this.name = nName;
        this.mail = nMail;
        this.password = nPass;
    }

    public void Insert()
    {
        SqlCommand cmd = new SqlCommand();
        SqlConnection con = DatabaseConnectionFactory.GetConnection();
        cmd.Connection = con;
        cmd.CommandText = "insert into [User]  ([username],[password],[name],[mail],[lastSeen]"
           + ",[userType],[isAdmin],[classID])	OUTPUT INSERTED.id values ( '"
                          + username + "','"
                          + password + "','"
                          + name + "','"
                          + mail + "' , '"
                          + lastSeen.ToString()
                          + "','staff', 1 , null)";
        userID = Convert.ToInt32(cmd.ExecuteScalar());
        cmd.Connection.Close();
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
                              dataReader.GetString(1),
                              dataReader.GetString(2),
                              dataReader.GetString(3),
                              dataReader.GetString(4),
                              dataReader.GetDateTime(5),
                              dataReader.GetBoolean(7));
        }
        cmd.Connection.Close();
        return staff;
    }

    public override List<List<string>> GetSchedule()
    {
        throw new NotSupportedException("GetSchedule() is not supported by type Staff");
    }
}