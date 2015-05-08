using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project
{
    class Student
    {
        List<ClassRoom> Class_Room;
        Student() { 
            Class_Room = new List<ClassRoom>();
        }
        Student(ClassRoom c) { 
            Class_Room = new List<ClassRoom>();
            Class_Room.Add(c);
        }
        User register(int id, string userName, string name, string pass, string mail,int classID)
        {
            User u = new User();

            return u;
        }
        void Login(string name, string pass) { 
            
        }
        void SignOut(string name) { 
            
        }
        void ViewScheduleWeekly(User u,DateTime week) { 
            
        }
        void ViewInbox(User u) { 
            //get by User ID
        }
        void ViewSent(User u) { 
            //get by User ID
        }
        void ViewMissedSession(Session s , User u) { 
            //User u; is optional    
        }
        void DownloadSessionFiles(Session s) { 
            
        }
        void SendMessageToTeacher(Teacher t, User u) { 
            
        }

    }
}
