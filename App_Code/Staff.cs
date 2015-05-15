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

    static public Staff GetUserById(int staffId)
    {
        // todo
        return null;
    }

    public override List<List<string>> GetSchedule()
    {
        // todo
        return null;
    }
}