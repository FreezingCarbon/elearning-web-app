using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public class Message
{
    public int messageID;
    public int senderID;
    public int recieverID;
    public string subject;
    public string body;
    public DateTime time;

    public Message()
    {

    }

    public Message(int messageID, string subject, string body, DateTime time, User sender, User reciever)
    {
        this.messageID = messageID;
        this.subject = subject;
        this.body = body;
        this.time = time;
        this.senderID = sender.userID;
        this.recieverID = reciever.userID;
    }

    private Message(int messageID, string subject, string body, DateTime time, int senderID, int recieverID)
    {
        this.messageID = messageID;
        this.subject = subject;
        this.body = body;
        this.time = time;
        this.senderID = senderID;
        this.recieverID = recieverID;
    }
}