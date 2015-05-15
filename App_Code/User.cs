using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
namespace ELearn
{
    public abstract class User
    {
        public int userID;
        public string username;
        public string password;
        public string name;
        public string mail;
        public DateTime lastSeen;

        public User(int userID, string username, string password, string name, string mail, DateTime lastSeen)
        {
            this.userID = userID;
            this.username = username;
            this.password = password;
            this.name = name;
            this.mail = mail;
            this.lastSeen = lastSeen;
        }

        public abstract List<List<string>> GetSchedule();
        public static User loginUser(String userName, String password)
        {
            SqlCommand cmd = new SqlCommand();
            SqlConnection con = DatabaseConnectionFactory.GetConnection();
            cmd.Connection = con;
            cmd.CommandText = "Select * from [User] where username=  @User_name and password=  @pass";
            cmd.Parameters.Add("User_name", System.Data.SqlDbType.VarChar, 128).Value = userName;
            cmd.Parameters.Add("pass", System.Data.SqlDbType.VarChar, 128).Value = password;
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {   dr.Read();
                if (dr["userType"].ToString().Equals("student"))
                {
                    return new Student(Convert.ToInt32(dr["id"]), userName, "", dr["name"].ToString(), dr["mail"].ToString(), DateTime.Now, Convert.ToInt32(dr["classID"]));
                }
                else if (dr["userType"].ToString().Equals("teacher"))
                {
                    return new Teacher(Convert.ToInt32(dr["id"]), userName, "", dr["name"].ToString(), dr["mail"].ToString(), DateTime.Now);

                }
                else if (dr["userType"].ToString().Equals("staff"))
                {
                    return new Staff(Convert.ToInt32(dr["id"]), userName, "", dr["name"].ToString(), dr["mail"].ToString(), DateTime.Now, true);
                }
            }
            return null;
        }

    }
}