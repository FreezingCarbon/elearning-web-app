using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project
{
    class Level
    {
        int LevelID;
        string LevelName;
        public Level() { 
        
        }
        public Level(int levelID, string name) {
            LevelID = levelID;
            LevelName = name;
        }
    }
}
