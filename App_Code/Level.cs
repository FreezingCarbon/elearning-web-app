using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

class Level
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
}