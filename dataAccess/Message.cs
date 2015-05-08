using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project
{
    class Message
    {
        User sender;
        User reciever;
        int ID;
        string Subject;
        string Body;
        DateTime Time;
        Message() { 
            
        }
        Message(User s, User r, int i, string sub, string b, DateTime t) {
            sender = new User();
            reciever = new User();
            ID = i;
            Subject = sub;
            Body = b;
            Time = t;
            sender = s;
            reciever = r;
        }
    }
}
