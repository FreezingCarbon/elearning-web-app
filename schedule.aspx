<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage1.master" AutoEventWireup="true" CodeFile="schedule.aspx.cs" Inherits="schedule" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Stylesheets" runat="Server">
    <link href="timetablestyle.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder3" runat="Server">
    <%
        List<List<string>> schedule;
        if ((string)Session["userType"] == "student")
            schedule = ((Student)Session["user"]).getSchedule();
        else if ((string)Session["userType"] == "teacher")
            schedule = ((Teacher)Session["user"]).getSchedule();
    %>
    <div class="menu_nav">
        <ul>
            <li><a href="home.aspx">Home</a></li>
            <li><a href="Messages.aspx">Messages</a></li>
            <li><a href="user.aspx">Ahmed</a></li>
            <li><a href="logout.aspx">Logout</a></li>
        </ul>
        <div class="clr"></div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <table width="80%" align="center">
        <div id="head_nav">
            <tr>
                <th>Time</th>
                <th>Monday</th>
                <th>Tuesday</th>
                <th>Wednesday</th>
                <th>Thrusday</th>
                <th>Friday</th>
                <th>Saturday</th>
            </tr>
        </div>

        <tr>
            <th>10:00 - 11:00</th>
            <%foreach (string entry in schedule[0])
              {%>
            <td><%=entry%></td>
            <%} %>
        </tr>

        <tr>
            <th>11:00 - 12:00</td>
        
            <%foreach (string entry in schedule[1])
              {%>
                <td><%=entry%></td>
                <%} %>
        </tr>

        <tr>
            <th>12:00 - 01:00</td>
        
            <%foreach (string entry in schedule[2])
              {%>
                <td><%=entry%></td>
                <%} %>
        </tr>

        <tr>
            <th>01:00 - 02:00</td>
        
            <%foreach (string entry in schedule[3])
              {%>
                <td><%=entry%></td>
                <%} %>
        </tr>

        <tr>
            <th>02:00 - 03:00</td>
        
            <%foreach (string entry in schedule[4])
              {%>
                <td><%=entry%></td>
                <%} %>
        </tr>
    </table>

</asp:Content>

