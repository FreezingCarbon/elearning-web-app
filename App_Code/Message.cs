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
        cmd.CommandText = @"insert into Message  ([senderID],[subject],[body],[time]) 	OUTPUT INSERTED.id values( " + 
                            senderID + " , '" + 
                            subject + "' , '" + 
                            body + "' , '" + 
                            time + "'  )";
        messageID = Convert.ToInt32( cmd.ExecuteScalar());
        
        foreach (int usr in recieverIDs)
        {
            SqlCommand cmd2 = new SqlCommand();
            cmd2.Connection = con;
            cmd2.CommandText = @"INSERT INTO [dbo].[Recieve]([recipientID],[messageID]) VALUES("+usr+","+messageID+")";
            cmd2.ExecuteNonQuery();
        }
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
            cmd2.CommandText = "select recipientId from [Recieve] where messageId = " + dataReader["id"].ToString();
            SqlDataReader dataReader2 = cmd2.ExecuteReader();
            List<int> recieverIDs = new List<int>();
            while (dataReader2.Read())
                recieverIDs.Add(Convert.ToInt32(dataReader.GetValue(0)));

            Message message = new Message(dataReader["subject"].ToString(),
                                          dataReader["body"].ToString(),
                                          Convert.ToDateTime(dataReader["time"]),
                                          Convert.ToInt32(dataReader["senderID"]),
                                          recieverIDs);
            message.messageID = Convert.ToInt32(dataReader["id"]);
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
        cmd.CommandText = "select messageID from Recieve where [recipientID] = " + recieverID;
        SqlDataReader dataReader = cmd.ExecuteReader();
        List<Message> messages = new List<Message>();

        while(dataReader.Read()){
            SqlCommand cmd2 = new SqlCommand();
            cmd2.Connection = con;
            cmd2.CommandText = "select * from Message where id = " + dataReader["messageID"].ToString();
            SqlDataReader dataReader2 = cmd2.ExecuteReader();
            if (dataReader2.Read()) { 
            Message message = new Message(dataReader2["subject"].ToString(),
                                          dataReader2["body"].ToString(),
                                          Convert.ToDateTime(dataReader2["time"]),
                                          Convert.ToInt32(dataReader2["senderID"])
                                          );
            message.messageID = Convert.ToInt32(dataReader2["id"]);
            messages.Add(message);
            }
        }

        cmd.Connection.Close();
        return messages;
    }
}