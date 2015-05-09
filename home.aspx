<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage1.master" AutoEventWireup="true" CodeFile="home.aspx.cs" Inherits="home" %>

<asp:Content ID="Content2" ContentPlaceHolderID="Stylesheets" runat="server"></asp:Content>
<asp:Content ID="menu" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
    <%
        if(((User)Session["user"]) == null)
            Response.Redirect("Default.aspx");
         %>
    <div class="menu_nav">
        <ul>
            <li><a href="schedule.aspx">Schedule</a></li>
            <li><a href="Messages.aspx">Messages</a></li>

            <li><a href="user.aspx"><%=((User)Session["user"]).username %></a></li>
            <li><a href="logout.aspx">Logout</a></li>
        </ul>
        <div class="clr"></div>
    </div>

</asp:Content>
<%-- Add content controls here --%>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <%
        // temp data for testing
        //Level tempLevel = new Level(1, "first grade");
        //ClassRoom tempClassRoom = new ClassRoom(1, tempLevel);
        //Student tempStudent = new Student(1, "username", "password", "name", "mail", DateTime.UtcNow, tempClassRoom);
        //Teacher tempTeacher = new Teacher(2, "username", "password", "name", "mail", DateTime.UtcNow);
        //Session.Add("userType", "teacher");
        //Session.Add("user", tempTeacher);
    %>

    <div class="content">
        <div class="content_resize">
            <div class="mainbar">
                <%if ((string)Session["userType"] == "staff") // admin see all levels all subjects
                  {
                      foreach (Level level in Level.GetAllLevels())
                      {%>
                <div class="article">
                    <h2><span><%=level.levelName%></span></h2>
                    <div class="clr"></div>
                    <%foreach (Subject subject in level.GetSubjects())
                      {%>
                    <p><a href="subject.aspx"><%=subject.title%></a></p>
                    <%}%>
                </div>
                <%}
                  }
                  else if ((string)Session["userType"] == "student") // student see his class his subjects
                  {
                      ClassRoom classRoom = ((Student)Session["user"]).GetClassRoom(); %>
                <div class="article">
                    <h2><span>Class <%=classRoom.classRoomID%></span></h2>
                    <div class="clr"></div>
                    <h3><span>Your Subjects:</span></h3>
                    <ul>
                        <%foreach (Subject subject in classRoom.GetSubjects())
                          {%>
                        <li><a href="subject.aspx"><%=subject.title%></a></li>
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
                    <p><a href="subject.aspx">Class <%=classRoom.classRoomID%></a></p>
                    <%}%>
                </div>
                <%}
                  }
                  else
                  {
                      Response.Redirect("Default.aspx");
                  }%>
            </div>
            <div class="sidebar">
                <div class="search">
                    <form id="form" name="form" method="post" action="#">
                        <span>
                            <input name="q" type="text" class="keywords" id="textfield" maxlength="50" value="Search..." />
                            <input name="b" type="image" src="images/search.gif" class="button" />
                        </span>
                    </form>
                </div>
            </div>
            <div class="clr"></div>
        </div>
    </div>
</asp:Content>
