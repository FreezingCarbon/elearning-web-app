using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Sql;
using System.Data.SqlClient;

public class Message
{
    public int messageID;
    public int senderID;
    public List<int> recieverIDs=new List<int>();
    public string subject;
    public string body;
    public DateTime time;

    public Message(int messageID, string subject, string body, DateTime time, ELearn.User sender, ELearn.User reciever)
    {
        this.messageID = messageID;
        this.subject = subject;
        this.body = body;
        this.time = time;
        this.senderID = sender.userID;
        this.recieverIDs.Add (reciever.userID);
    }

    public Message(int messageID, string subject, string body, DateTime time, int senderID, int recieverID)
    {
        this.messageID = messageID;
        this.subject = subject;
        this.body = body;
        this.time = time;
        this.senderID = senderID;
        this.recieverIDs.Add(recieverID);
    }
    public Message(string subject, string body, DateTime time, int senderID)
    {
        this.subject = subject;
        this.body = body;
        this.time = time;
        this.senderID = senderID;
    }
    public Message(string subject, string body, DateTime time, int senderID, List<int> receiverIDs)
    {
        this.subject = subject;
        this.body = body;
        this.time = time;
        this.senderID = senderID;
        this.recieverIDs = receiverIDs;
    }
    public int sendMessage()
    {
        // todo
        return messageID;
    }
    static public List<Message> GetMessagesBySenderId(int senderID)
    {
        // todo
        return null;
    }
    static public List<Message> GetMessagesByRecieverId(int recieverID)
    {
        // todo
        return null;
    }
}