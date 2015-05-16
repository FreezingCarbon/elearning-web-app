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
    public Level( string levelName)
    {
        this.levelName = levelName;
    }
    public void insert()
    {
        SqlCommand cmd = new SqlCommand();
        SqlConnection con = DatabaseConnectionFactory.GetConnection();
        cmd.Connection = con;
        cmd.CommandText = "insert into [level] (name) OUTPUT INSERTED.id values ('" + levelName + "')";
        levelID = Convert.ToInt32(cmd.ExecuteScalar());
        cmd.Connection.Close();
   
    }
    static public Level GetLevelById(int levelId)
    {
        SqlCommand cmd = new SqlCommand();
        SqlConnection con = DatabaseConnectionFactory.GetConnection();
        cmd.Connection = con;
        cmd.CommandText = "select * from [Level] where id = " + levelId;
        SqlDataReader dataReader = cmd.ExecuteReader();
        Level level = null;
        if (dataReader.Read())
        {
            level = new Level(Convert.ToInt32(dataReader["id"]),
                                  dataReader["name"].ToString());
        }
        cmd.Connection.Close();
        return level;
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
            Level level = new Level(Convert.ToInt32(dataReader["id"]),
                                  dataReader["name"].ToString());
            allLevels.Add(level);
        }
        //cmd.Connection.Close();

        return allLevels;
    }

    static public List<Subject> GetSubjects(int levelID)
    {
        SqlCommand cmd = new SqlCommand();
        SqlConnection con = DatabaseConnectionFactory.GetConnection();
        cmd.Connection = con;
        cmd.CommandText = "select * from Subject where levelID = " + levelID + " ";
        SqlDataReader dataReader = cmd.ExecuteReader();
        List<Subject> subjects = new List<Subject>();
        while (dataReader.Read())
        {
            Subject subject = new Subject(Convert.ToInt32(dataReader["id"]),
                                          dataReader["title"].ToString(),
                                          levelID);
            subjects.Add(subject);
        }
        cmd.Connection.Close();

        return subjects;
    }
}