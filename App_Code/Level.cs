using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Sql;
using System.Data.SqlClient;

public class Level
{
    public int levelID;
    public string levelName;

    public Level(int levelID, string levelName)
    {
        this.levelID = levelID;
        this.levelName = levelName;
    }

    static public Level GetLevelById(int levelId)
    {
        // todo
        return null;
    }

    static public List<Level> GetAllLevels()
    {
        SqlCommand cmd = new SqlCommand();
        SqlConnection con = DatabaseConnectionFactory.GetConnection();
        cmd.Connection = con;
        cmd.CommandText = "select * from Level";
        SqlDataReader dataReader = cmd.ExecuteReader();
        List<Level> allLevels = new List<Level>();
        while (dataReader.Read())
        {
            Level level = new Level(Convert.ToInt32(dataReader.GetValue(0)), dataReader.GetValue(1).ToString());
            allLevels.Add(level);
        }
        cmd.Connection.Close();

        return allLevels;
    }

    public List<Subject> GetSubjects()
    {
        SqlCommand cmd = new SqlCommand();
        SqlConnection con = DatabaseConnectionFactory.GetConnection();
        cmd.Connection = con;
        cmd.CommandText = "select * from Subject where levelID = " + levelID + " ";
        SqlDataReader dataReader = cmd.ExecuteReader();
        List<Subject> subjects = new List<Subject>();
        while (dataReader.Read())
        {
            Subject subject = new Subject(Convert.ToInt32(dataReader.GetValue(0)), dataReader.GetValue(2).ToString(), this);
            subjects.Add(subject);
        }
        cmd.Connection.Close();

        return subjects;
    }
}