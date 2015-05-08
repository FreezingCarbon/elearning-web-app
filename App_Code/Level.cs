using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public class Level
{
    public int levelID;
    public string levelName;

    public Level()
    {

    }

    public Level(int levelID, string levelName)
    {
        this.levelID = levelID;
        this.levelName = levelName;
    }

    static public List<Level> getAllLevels()
    {
        // static data
        Level l1 = new Level(1, "first grade");
        Level l2 = new Level(2, "second grade");
        Level l3 = new Level(3, "third grade");
        List<Level> allLevels = new List<Level>();
        allLevels.Add(l1);
        allLevels.Add(l2);
        allLevels.Add(l3);
        //////////////


        return allLevels;
    }

    public List<Subject> getSubjects()
    {
        // static data
        Subject s1 = new Subject(1,"english",this);
        Subject s2 = new Subject(1,"arabic",this);
        Subject s3 = new Subject(1,"math",this);
        List<Subject> subjects = new List<Subject>();
        subjects.Add(s1);
        subjects.Add(s2);
        subjects.Add(s3);
        //////////////

        return subjects;
    }
}