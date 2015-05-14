using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Sql;
using System.Data.SqlClient;

public class Subject
{
    public int subjectID;
    public int levelID;
    public string title;

    public Subject(int subjectID, string title, Level level)
    {
        this.subjectID = subjectID;
        this.title = title;
        this.levelID = level.levelID;
    }

    private Subject(int subjectID, string title, int levelID)
    {
        this.subjectID = subjectID;
        this.title = title;
        this.levelID = levelID;
    }

    static public Subject GetSubjectById(int subjectId)
    {
        // todo
        return null;
    }

    void Insert()
    {
        SqlCommand cmd = new SqlCommand();
        SqlConnection con = DatabaseConnectionFactory.GetConnection();
        cmd.Connection = con;
        cmd.CommandText = "insert into Subject values ( " 
                          + this.subjectID + " , "
                          + this.levelID + " , '"
                          + this.title + "'  )";
        cmd.ExecuteNonQuery();
        cmd.Connection.Close();
    }
}