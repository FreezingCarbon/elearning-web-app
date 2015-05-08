using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project
{
    class Session
    {
        int ID;
        Subject subject;
        List<Teacher> teachers;
        DateTime date;
        string VideoLink;
        string NotesLink;
        public Session() {
            subject = new Subject();
            teachers = new List<Teacher>();
        }
        public Session(int i, DateTime d, string v, string n, Subject s, Teacher t) {
            subject = new Subject();
            teachers = new List<Teacher>();
            ID = i;
            subject = s;
            date = d;
            VideoLink = v;
            NotesLink = n;
            teachers.Add(t);
        }
        void AddTeacher(Teacher t) {
            teachers.Add(t);
        }
    }
}
