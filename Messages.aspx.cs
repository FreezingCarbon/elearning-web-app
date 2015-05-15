using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Messages : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void button1OnClick(object sender, EventArgs e)
    {
        string message = message1.Text,subject=subject1.Text;
        List<int> recivers = new List<int>();
        foreach (var index in list1.GetSelectedIndices())
        {
            var itemText = list1.Items[index].Value;
            recivers.Add(Convert.ToInt32(itemText.ToString()));
           
        }
        Message newMessage = new Message(subject,message,DateTime.Now,((ELearn.User)Session["user"]).userID,recivers);
        newMessage.sendMessage();
    }
 
}