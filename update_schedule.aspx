<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage1.master" AutoEventWireup="true" CodeFile="update_schedule.aspx.cs" Inherits="update_schedule" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Stylesheets" runat="Server">
    <link href="timetablestyle.css" rel="stylesheet" />
    <script type="text/javascript">
        function removeSession() {
            confirm("Delete This Session?");
        }

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder3" runat="Server">
    <div class="menu_nav">
        <ul>
            <li><a href="admin.aspx">Home</a></li>
            <li><a href="schedule.aspx">Schedule</a></li>
            <li><a href="Messages.aspx">Messages</a></li>
            <li><a href="user.aspx"><%=((ELearn.User)Session["user"]).username %></a></li>
            <li><a href="logout.aspx">Logout</a></li>
        </ul>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="content">
        <%
            //Session.Add("userType", "staff");
            List<List<string>> schedule = null;
            if (((string)Session["schType"]).Equals("class"))
                schedule = ClassRoom.GetSchedule(Convert.ToInt32(((string)Session["classID"])));
            else Response.Redirect("Default.aspx");
            ClassRoom.GetClassRoomById(Convert.ToInt32(Session["classID"]));
        %>
        <div class="content_resize">
            <div class="row">
                <div class="col-md-4">
                    <form runat="server">
                        <div class="panel panel-default">
                            <div class="panel-heading">
                                <h4>Add Session</h4>
                            </div>
                            <div class="panel-body form-horizontal">
                                <%int lvlID = ClassRoom.GetClassRoomById(Convert.ToInt32(Session["classID"])).levelID;
                                  int clsID = Convert.ToInt32(Session["classID"]); %>
                                <input type="text" class="register-input" value="<%= Level.GetLevelById(lvlID).levelName+" - "+clsID %>" disabled="disabled" />
                                <asp:DropDownList runat="server" ID="teachers" CssClass="form-control">
                                </asp:DropDownList>

                                <asp:DropDownList runat="server" ID="subjects" CssClass="form-control">
                                </asp:DropDownList>

                                <asp:DropDownList runat="server" ID="slotes" CssClass="form-control">
                                </asp:DropDownList>

                                <asp:Button runat="server" CssClass="register-button" OnClick="add_Click" Text="Add" />
                            </div>
                        </div>
                        <div class="panel panel-default">
                            <div class="panel-heading">
                                <h4>Remove Session</h4>
                            </div>
                            <div class="panel-body form-horizontal">
                                <asp:DropDownList runat="server" ID="removed" CssClass="form-control">
                                </asp:DropDownList>

                                <asp:Button runat="server" CssClass="register-button" OnClick="remove_Click" Text="Remove" />
                           
                            </div>
                        </div>



                    </form>
                </div>
                <div class="col-md-8">
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            <h4>Schedule</h4>
                        </div>
                        <div class="panel-body">

                            <table width="80%" align="center">
                                <div id="head_nav">
                                    <tr>
                                        <th>Time</th>
                                        <th>saturday</th>
                                        <th>sunday</th>
                                        <th>monday</th>
                                        <th>tuesday</th>
                                        <th>wednesday</th>
                                        <th>thursday</th>
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

                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

