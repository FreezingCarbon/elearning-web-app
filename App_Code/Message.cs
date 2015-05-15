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
        SqlCommand cmd = new SqlCommand();
        SqlConnection con = DatabaseConnectionFactory.GetConnection();
        cmd.Connection = con;
        cmd.CommandText = "insert into Message values( " + messageID + " , " + senderID + " , '" + subject + "' , '" + body + "' , " + time + "  )";
        cmd.ExecuteNonQuery();
        con.Close();

        return messageID;
    }
    static public List<Message> GetMessagesBySenderId(int senderID)
    {
        SqlCommand cmd = new SqlCommand();
        SqlConnection con = DatabaseConnectionFactory.GetConnection();
        cmd.Connection = con;
        cmd.CommandText = "select * from Message where senderId = " + senderID;
        SqlDataReader dataReader = cmd.ExecuteReader();
        List<Message> messages = new List<Message>();
        while (dataReader.Read())
        {
            SqlCommand cmd2 = new SqlCommand();
            cmd2.Connection = con;
            cmd2.CommandText = "select recipientId from receive where messageId = " + dataReader.GetString(0);
            SqlDataReader dataReader2 = cmd.ExecuteReader();
            List<int> recieverIDs = new List<int>();
            while (dataReader2.Read())
                recieverIDs.Add(Convert.ToInt32(dataReader2.GetValue(0)));

            Message message = new Message(dataReader.GetString(2),
                                          dataReader.GetString(3),
                                          dataReader.GetDateTime(4),
                                          dataReader.GetInt32(1),
                                          recieverIDs);
            message.messageID = dataReader.GetInt32(0);
            messages.Add(message);
        }
        cmd.Connection.Close();
        return messages;
    }

    static public List<Message> GetMessagesByRecieverId(int recieverID)
    {
        SqlCommand cmd = new SqlCommand();
        SqlConnection con = DatabaseConnectionFactory.GetConnection();
        cmd.Connection = con;
        cmd.CommandText = "select messageID from Recieve where recipientID = " + recieverID;
        SqlDataReader dataReader = cmd.ExecuteReader();
        List<Message> messages = new List<Message>();
        while(dataReader.Read()){
            SqlCommand cmd2 = new SqlCommand();
            cmd2.Connection = con;
            cmd2.CommandText = "select * from Message where messageID = " + Convert.ToInt32(dataReader.GetValue(1));
            SqlDataReader dataReader2 = cmd2.ExecuteReader();

            Message mess = new Message(dataReader2.GetValue(2).ToString(),
                                          dataReader2.GetValue(3).ToString(),
                                          Convert.ToDateTime(dataReader2.GetValue(4)),
                                          Convert.ToInt32(dataReader2.GetValue(1)));
            
            messages.Add(mess);
        }
        con.Close();
        return messages;
    }
}