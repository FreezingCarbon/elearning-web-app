using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project
{
    class ClassRoom
    {
        Level level;
        public ClassRoom() { }
        public ClassRoom(Level l) {
            level = new Level();
            level = l;
        }
    }
}
