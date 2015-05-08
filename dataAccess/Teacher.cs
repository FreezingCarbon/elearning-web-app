using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project
{
    class Teacher
    {
        List<ClassRoom> Classes;
        List<Subject> Subjects;
        Teacher() {
            Classes = new List<ClassRoom>();
            Subjects = new List<Subject>();
        }
        void AddClass(ClassRoom cr) {
            Classes.Add(cr);
        }
        void AddSubject(Subject s) {
            Subjects.Add(s);
        }
        ClassRoom GetClass() {
            ClassRoom c = new ClassRoom();

            return c;
        }
        Subject GetSubject(){
            Subject s = new Subject();
    
            return s;
        }
        void Register(int id, string userName, string name, string pass, string mail)
        { 
            
        }
        void Login(string name, string pass)
        {

        }
        void SignOut(string name)
        {

        }
        void ViewScheduleWeekly(User u, DateTime week)
        {

        }
        void ViewInbox(User u)
        {
            //get by User ID
        }
        void ViewSent(User u)
        {
            //get by User ID
        }
        void CreateNewSession(int i, DateTime d, string v, string n, Subject sub, Teacher t)
        {
            //Session s = new Session(i,d,v,n,sub,this);
        }
        void SendMessageToStudent(Student s, User u)
        {

        }
    }
}

