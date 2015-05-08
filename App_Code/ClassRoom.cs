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
}