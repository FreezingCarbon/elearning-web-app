using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project
{
    class User
    {
        int ID;
        string UserName;
        string Password;
        string Name;
        string Mail;
        DateTime LastSeen;
        string UserType;
        Boolean IsAdmin;
        int ClassID;
        Boolean IsActive;
        public User() { 
            
        }
        User(int id, string userName, string name, string pass,string mail, DateTime lastSeen, string type, Boolean isAdmin, int classID, Boolean isActive) {
            ID = id;
            UserName = userName;
            Name = name;
            Password = pass;
            Mail = mail;
            LastSeen = lastSeen;
            UserType = type;
            IsAdmin = isAdmin;
            ClassID = classID;
            IsActive = isActive;
        }
        void CreateStudent(int id, string userName, string name, string pass, string mail, int classID) { }
        void CreateTeacher(int id, string userName, string name, string pass, string mail) { }
        void Login(string name,string pass) { }
        void SignOut(string name) { }
        void CreateClassRoom(int levelID,string LevelName) {
            Level l = new Level(levelID, LevelName);
            ClassRoom cr = new ClassRoom(l); 
        }
        void CreateGrade(int levelID, string LevelName) { 
            
        }
        void CreateClassSchedule(int i, string d, DateTime s, DateTime e, ClassRoom c) { }
        void CreateTeacherSchedule(int i, string d, DateTime s, DateTime e, ClassRoom c) { }
        void UpdateName(string n) { }
        void UpdatePass(string p) { }
        void UpdateAttendance(User u) { }
        void UpdateClassSchedule(Schedule c) { }
        void UpdateTeacherSchedule(Schedule c) { }
        List<Student> ViewActivatedStudent(ClassRoom s) {
            List<Student> students = new List<Student>();

            return students;
        }

    }
}
