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

    public Subject(int subjectID, string title, int levelID)
    {
        this.subjectID = subjectID;
        this.title = title;
        this.levelID = levelID;
    }

    static public Subject GetSubjectById(int subjectId)
    {
        SqlCommand cmd = new SqlCommand();
        SqlConnection con = DatabaseConnectionFactory.GetConnection();
        cmd.Connection = con;
        cmd.CommandText = "select * from Subject where id = " + subjectId;
        SqlDataReader dataReader = cmd.ExecuteReader();
        Subject subject = null;
        if (dataReader.Read())
            subject = new Subject(subjectId,
                                  dataReader["title"].ToString(),
                                  Convert.ToInt32(dataReader["levelID"]));
        cmd.Connection.Close();
        return subject;
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

    static public List<Subject> getAllSubjects()
    {
        SqlCommand cmd = new SqlCommand();
        SqlConnection con = DatabaseConnectionFactory.GetConnection();
        cmd.Connection = con;
        cmd.CommandText = "select * from Subject";
        SqlDataReader dataReader = cmd.ExecuteReader();
        List<Subject> subjects = new List<Subject>();
        while (dataReader.Read())
        {
            subjects.Add(new Subject(Convert.ToInt32(dataReader["id"]), 
                                     dataReader["title"].ToString(),
                                     Convert.ToInt32(dataReader["levelID"])));
        }

        cmd.Connection.Close();
        return subjects;
    }
}