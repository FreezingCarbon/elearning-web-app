<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage1.master" AutoEventWireup="true" CodeFile="admin.aspx.cs" Inherits="admin"  EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Stylesheets" runat="Server">
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
        <form runat="server">
            <div class="content_resize">
                <div class="row">
                    <div class="col-md-4">

                        <div class="panel panel-default">
                            <div class="panel-heading">
                                <h4>Create Grade</h4>
                            </div>
                            <div class="panel-body form-horizontal">
                                <asp:TextBox CssClass="form-control" ID="GradeName" runat="server"  placeholder="Name"></asp:TextBox>
                                <asp:Button CssClass="btn-info" Text="Create" runat="server" ID="createGeade" OnClick="createGeade_Click" />
                                 
                            </div>

                        </div>
                        <div class="panel panel-default">
                            <div class="panel-heading">
                                <h4>Create New Class</h4>
                            </div>
                            <div class="panel-body form-horizontal">
                                <asp:ListBox runat="server" ID="grades" CssClass="form-control" >

                                </asp:ListBox>
                               

                   <asp:Button CssClass="btn-info" Text="Create" runat="server" ID="createClass" OnClick="createClass_Click" />
                                         </div>

                        </div>
                        <div class="panel panel-default">
                            <div class="panel-heading">
                                <h4>Create/Update Scheduale</h4>
                            </div>
                            <div class="panel-body form-horizontal">
                                <asp:ListBox runat="server" ID="classes" CssClass="form-control" >

                                </asp:ListBox>


                                <asp:Button CssClass="btn-info" Text="Class Schedule" runat="server" ID="CCSched" OnClick="createClassSched_Click" />
                   
                            </div>
                            <div class="panel-body form-horizontal">
                               <asp:ListBox runat="server" ID="teachers" CssClass="form-control" >

                                </asp:ListBox>
                               <asp:Button CssClass="btn-info" Text="Teacher Schedule" runat="server" ID="CTSched" OnClick="createTeachSched_Click" />
                   
                            </div>

                        </div>
                    </div>
                    <div class="col-md-4">
                        <div class="panel panel-default">
                            <div class="panel-heading">
                                <h4>Create New Account</h4>
                            </div>
                            <div class="panel-body form-horizontal">
                                <asp:TextBox ID="CAID" CssClass="register-input" runat="server" placeholder="Name"></asp:TextBox>
                                 <asp:TextBox ID="CAUN" CssClass="register-input" runat="server" placeholder="Username"></asp:TextBox>
                                <asp:TextBox ID="CAMAIL" CssClass="register-input" runat="server" placeholder="Email address"></asp:TextBox>
                                <asp:TextBox ID="CAPW" TextMode="Password" CssClass="register-input" runat="server" placeholder="Password"></asp:TextBox>
                                <asp:ListBox runat="server" ID="CATypes" CssClass="form-control" >
                                    <asp:ListItem Value="teacher" Text="Teacher" Selected="True"></asp:ListItem>
                                    <asp:ListItem Value="staff" Text="Staff" ></asp:ListItem>
                                </asp:ListBox>
                               <asp:Button CssClass="btn-info" Text="Create Account" runat="server" ID="CAbut" OnClick="createAcc_Click" />
                   
                            </div>
                        </div>
                        <div class="panel panel-default">
                            <div class="panel-heading">
                                <h4>View Student/Teacher Page</h4>
                            </div>
                            <div class="panel-body form-horizontal">
                                            <asp:ListBox runat="server" ID="viewList" CssClass="form-control" >

                                </asp:ListBox>
                               <asp:Button CssClass="btn-info" Text=" View page" runat="server" ID="viewBut" OnClick="viewAcc_Click" />
                   
                            </div>

                        </div>
                    </div>


                    <div class="col-md-4">
                        <div class="panel panel-default">
                            <div class="panel-heading">
                                <h4>Studnets in each Class</h4>
                            </div>

                            <div class="panel-body">
                                <table class="table table-hover">
                                    <tr>
                                        <th>Class</th>
                                        <th>Total</th>
                                        <th>Active</th>
                                    </tr>
                                    <tbody>
                                  <% List<ClassRoom> clss = ClassRoom.GetAllClassRooms();

                               foreach (ClassRoom cls in clss) {
                                   int active = cls.getActiveByID(cls.classRoomID);
                                   int total = cls.getTotalByID(cls.classRoomID);
                                   Level lvl = Level.GetLevelById(cls.levelID);
                                   string lname = "";
                                   if (lvl != null) { lname = lvl.levelName; }
                                   else { lname = cls.levelID.ToString(); }
                                   String name = lname + " - " + cls.classRoomID.ToString();
                                %>
                                        
                                        <tr>
                                            <td><%=name %></td>
                                            <td><%=total %></td>
                                            <td><%=active %></td>
                                        </tr>
                                        <%} %>
                                    </tbody>
                                </table>
                            </div>
                        </div>

                    </div>
                </div>
            </div>
        </form>
    </div>
</asp:Content>

