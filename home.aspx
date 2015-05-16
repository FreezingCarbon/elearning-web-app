<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage1.master" AutoEventWireup="true" CodeFile="home.aspx.cs" Inherits="home" %>

<asp:Content ID="Content2" ContentPlaceHolderID="Stylesheets" runat="server"></asp:Content>
<asp:Content ID="menu" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">

    <div class="menu_nav">
        <ul>
            <li><a href="home.aspx">Home</a></li>
            <li><a href="schedule.aspx">Schedule</a></li>
            <li><a href="Messages.aspx">Messages</a></li>
            <li><a href="user.aspx"><%=((ELearn.User)Session["user"]).username %></a></li>
            <li><a href="logout.aspx">Logout</a></li>
        </ul>
        <div class="clr"></div>
    </div>

</asp:Content>
<%-- Add content controls here --%>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <div class="content">
        <div class="content_resize">
            <div class="mainbar">
                <%if ((string)Session["userType"] == "staff") // admin see all levels all subjects
                  {
                      Response.Redirect("admin.aspx");
                  }
                  else if (((string)Session["userType"]).Equals("student")) // student see his class his subjects
                  {
                      ClassRoom classRoom = ((Student)Session["user"]).GetClassRoom();  %>
                <div class="article">
                    <h2><span>Class <%=classRoom.classRoomID%></span></h2>
                    <div class="clr"></div>
                    <h3><span>Your Subjects:</span></h3>
                    <ul>
                        <%foreach (Subject subject in classRoom.GetSubjects())
                          {%>
                        <li><a href="subject.aspx?subjectId=<%=subject.subjectID %>&classId=<%=classRoom.classRoomID %>"><%=subject.title%></a></li>
                        <%}
                        %>
                    </ul>
                </div>
                <%}
                  else if ((string)Session["userType"] == "teacher") // teacher see his subjects his classes
                  {
                      foreach (Tuple<Subject, List<ClassRoom>> subjectClasses in ((Teacher)Session["user"]).GetSubjects())
                      {%>
                <div class="article">
                    <h2><span><%=subjectClasses.Item1.title%></span></h2>
                    <div class="clr"></div>
                    <%foreach (ClassRoom classRoom in subjectClasses.Item2)
                      {%>

                    <p><a href="subject.aspx?subjectId=<%=subjectClasses.Item1.subjectID %>&classId=<%=classRoom.classRoomID %>">Class <%=classRoom.classRoomID%></a></p>
                    <%}%>
                </div>
                <%}
                  }
                  else
                  {
                      Response.Redirect("Default.aspx");
                  }%>
            </div>

            <div class="clr"></div>
        </div>
    </div>
</asp:Content>
