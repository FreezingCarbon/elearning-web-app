using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ClassRoom
/// </summary>
public class ClassRoom
{
    public int classRoomID;
    public int levelID;

	public ClassRoom()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public ClassRoom(int classRoomID, Level level)
    {
        this.classRoomID = classRoomID;
        this.levelID = level.levelID;
    }

    private ClassRoom(int classRoomID, int levelID)
    {
        this.classRoomID = classRoomID;
        this.levelID = levelID;
    }

    public List<Subject> getSubjects()
    {
        // static data
        Level l1 = new Level(1, "first grade");
        return l1.getSubjects();
    }
}