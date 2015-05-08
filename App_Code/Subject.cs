using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Subject
/// </summary>
public class Subject
{
    public int subjectID;
    public int levelID;
    public string title;

	public Subject()
	{
		//
		// TODO: Add constructor logic here
		//
	}

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
}