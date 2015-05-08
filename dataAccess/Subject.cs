using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project
{
    class Subject
    {
        int SubjectID;
        string Title;
        Level level;
        public Subject() { 
            
        }
        Subject(int id, string title, Level l) {
            SubjectID = id;
            Title = title;
            level = l;
        }
    }
}
