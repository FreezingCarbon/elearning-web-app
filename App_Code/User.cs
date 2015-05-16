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
        public abstract void update(String nName,string nUser,string nMail,string nPass);
        public abstract List<List<string>> GetSchedule();
        public static User getUserByID(int userID)
        {
            SqlCommand cmd = new SqlCommand();
            SqlConnection con = DatabaseConnectionFactory.GetConnection();
            cmd.Connection = con;
            cmd.CommandText = "Select * from [User] where id= "+userID.ToString();
             SqlDataReader dr = cmd.ExecuteReader();
             if (dr.Read())
             {
                 ELearn.User usr = null;
                 if (dr["userType"].ToString().Equals("student"))
                 {
                     usr = new Student(Convert.ToInt32(dr["id"]), dr["userName"].ToString(), "", dr["name"].ToString(), dr["mail"].ToString(), DateTime.Now, Convert.ToInt32(dr["classID"]));
                 }
                 else if (dr["userType"].ToString().Equals("teacher"))
                 {
                     usr = new Teacher(Convert.ToInt32(dr["id"]), dr["userName"].ToString(), "", dr["name"].ToString(), dr["mail"].ToString(), DateTime.Now);

                 }
                 else if (dr["userType"].ToString().Equals("staff"))
                 {
                     usr = new Staff(Convert.ToInt32(dr["id"]), dr["userName"].ToString(), "", dr["name"].ToString(), dr["mail"].ToString(), DateTime.Now, true);
                 }
                 dr.Close();
                 return usr;
             }
             return null;

        }
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
            ELearn.User usr=null ;
                if (dr["userType"].ToString().Equals("student"))
                {
                    usr = new Student(Convert.ToInt32(dr["id"]), userName, dr["password"].ToString(), dr["name"].ToString(), dr["mail"].ToString(), DateTime.Now, Convert.ToInt32(dr["classID"]));
                }
                else if (dr["userType"].ToString().Equals("teacher"))
                {
                    usr = new Teacher(Convert.ToInt32(dr["id"]), userName, dr["password"].ToString(), dr["name"].ToString(), dr["mail"].ToString(), DateTime.Now);

                }
                else if (dr["userType"].ToString().Equals("staff"))
                {
                    usr = new Staff(Convert.ToInt32(dr["id"]), userName, dr["password"].ToString(), dr["name"].ToString(), dr["mail"].ToString(), DateTime.Now, true);
                }
                dr.Close();
                SqlCommand newCMD = new SqlCommand();
                newCMD.Connection = con;
                newCMD.CommandText = "update [User] set lastSeen = '" + DateTime.Now.ToString() + "' where userName= '" + userName + "'";
                newCMD.ExecuteNonQuery();
                return usr;
            }
            return null;
        }
        static public List<User> getAllUsers()
        {
            List<User> users = new List<User>();
            SqlCommand cmd = new SqlCommand();
            SqlConnection con = DatabaseConnectionFactory.GetConnection();
            cmd.Connection = con;
            cmd.CommandText = "select * from [User] ";
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                if (dr["userType"].ToString().Equals("student"))
                {
                    users.Add(new Student(Convert.ToInt32(dr["id"]), dr["userName"].ToString(), "", dr["name"].ToString(), dr["mail"].ToString(), DateTime.Now, Convert.ToInt32(dr["classID"])));
                }
                else if (dr["userType"].ToString().Equals("teacher"))
                {
                    users.Add(new Teacher(Convert.ToInt32(dr["id"]), dr["userName"].ToString(), "", dr["name"].ToString(), dr["mail"].ToString(), Convert.ToDateTime(dr["lastSeen"])));

                }
                else if (dr["userType"].ToString().Equals("staff"))
                {
                    users.Add(new Staff(Convert.ToInt32(dr["id"]), dr["userName"].ToString(), "", dr["name"].ToString(), dr["mail"].ToString(), DateTime.Now, true));
                }

            }
            return users;

        }
    }
}