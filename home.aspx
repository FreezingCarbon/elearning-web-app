<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage1.master" AutoEventWireup="true" CodeFile="home.aspx.cs" Inherits="home" %>

<asp:Content ID="Content2" ContentPlaceHolderID="Stylesheets" runat="server"></asp:Content>
<asp:Content ID="menu" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
    <div class="menu_nav">
        <ul>
            <li><a href="home.aspx">Home</a></li>
            <li><a href="schedule.aspx">My Schedule</a></li>
            <li><a href="user.aspx">Ahmed</a></li>
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
                <%if (Request.Form["type"] == "Admin" || (true)) // admin see all levels all subjects
                  {
                      foreach (Level level in Level.getAllLevels())
                      {%>
                <div class="article">
                    <h2><span><%=level.levelName%></span></h2>
                    <div class="clr"></div>
                    <%foreach (Subject subject in level.getSubjects())
                      {%>
                    <p><a href="subject.aspx"><%=subject.title%></a></p>
                    <%}%>
                </div>
                <%}%>
                <%}
                  else if (Request.Form["type"] == "Student") // student see his class his subjects
                  {%>
                <div class="article">
                    <h2><span>Class : 4-B</span></h2>
                    <div class="clr"></div>
                    <h3><span>Your Subjects:</span></h3>
                    <ul>
                        <li><a href="subject.aspx">Arabic</a></li>
                        <li><a href="subject.aspx">English</a></li>
                        <li><a href="subject.aspx">Math</a></li>
                    </ul>
                </div>
                <%}
                  else if (Request.Form["type"] == "Teacher") // teacher see his subjects his classes
                  {%>
                <div class="article">
                    <h2><span>Subject: Math</span></h2>
                    <div class="clr"></div>
                    <p><a href="subject.aspx?type=Teacher">Class: 2A</a></p>
                    <p><a href="subject.aspx?type=Teacher">Class: 2B</a></p>
                    <p><a href="subject.aspx?type=Teacher">Class: 4A</a></p>
                </div>
                <div class="article">
                    <h2><span>Subject: English</span></h2>
                    <div class="clr"></div>
                    <p><a href="subject.aspx?type=Teacher">Class: 2A</a></p>
                    <p><a href="subject.aspx?type=Teacher">Class: 3B</a></p>
                    <p><a href="subject.aspx?type=Teacher">Class: 4A</a></p>
                </div>

                <%} %>
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
