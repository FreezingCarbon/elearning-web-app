using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project
{
    class Schedule
    {
        int ID;
        ClassRoom cr;
        List<Session> Sessions;
        string Day;
        DateTime start;
        DateTime end;
        Schedule() {
            Sessions = new List<Session>();
        }
        Schedule(int i, string d, DateTime s, DateTime e,  ClassRoom c) {
            Sessions = new List<Session>();
            ID = i;
            Day = d;
            start = s;
            end = e;
            cr = c;
        }
        void AddSession(Session s) {
            Sessions.Add(s);
        }
    }
}
