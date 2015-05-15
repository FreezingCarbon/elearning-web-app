<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage1.master" AutoEventWireup="true" CodeFile="Messages.aspx.cs" Inherits="Messages" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Stylesheets" runat="Server">
    <script type="text/javascript" src="js/jquery-2.1.3.js"></script>
    <script type="text/javascript" src="js/bootstrap.min.js"></script>
    <link href="inbox.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder3" runat="Server">
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
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="content">
        <div class="content_resize">
            <div class="container">
                <div class="row">
                    <div class="col-sm-9 col-md-10">
                        <!-- Split button -->
                        <div class="btn-group">
                            <a data-toggle="modal" href="#send_modal" class="btn btn-danger btn-sm btn-block" role="button">New Message</a>
                            <hr />

                        </div>

                    </div>
                </div>
                <hr />
                <div class="row">
                    <div class="col-sm-9 col-md-10">
                        <!-- Nav tabs -->
                        <ul class="nav nav-tabs">
                            <li class="active"><a href="#inbox" data-toggle="tab"><span class="glyphicon glyphicon-inbox"></span>Primary</a></li>
                            <li><a href="#sent" data-toggle="tab"><span class="glyphicon glyphicon-user"></span>
                                Sent</a></li>
                        </ul>
                        <!-- Tab panes -->
                        <div class="tab-content">
                            <div class="tab-pane fade in active" id="inbox">
                                <div class="list-group">
                                    <% List<Message> msgs = Message.GetMessagesByRecieverId(((ELearn.User)Session["user"]).userID);
                                       foreach (Message msg in msgs)
                                       { 
                                    %>
                                    <a href="#" class="list-group-item">
                                        <span class="name" style="min-width: 120px; display: inline-block;"><%=msg.subject %></span> <span class="">This is big title</span>
                                        <span class="text-muted" style="font-size: 11px;"><%=msg.body %></span>
                                        <span class="badge"><%=msg.time %></span>

                                    </a>
                                    <%} %>
                                </div>
                            </div>
                            <div class="tab-pane fade in " id="sent">
                                <div class="list-group">
                                    <% msgs = Message.GetMessagesBySenderId(((ELearn.User)Session["user"]).userID);
                                       foreach (Message msg in msgs)
                                       { 
                                    %>
                                    <a href="#" class="list-group-item">
                                        <span class="name" style="min-width: 120px; display: inline-block;"><%=msg.subject %></span> <span class="">This is big title</span>
                                        <span class="text-muted" style="font-size: 11px;"><%=msg.body %></span>
                                        <span class="badge"><%=msg.time %></span>

                                    </a>
                                    <%} %>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

        </div>
        <div id="send_modal" class="modal fade">
            <div class="modal-dialog ">
                <div class="modal-content">
                    <form class="form-inline" runat="server">

                        <div class="modal-header">
                            <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                            <h4 class="modal-title">Send Message</h4>
                        </div>
                        <div class="modal-body">
                            <div class="row">
                                <div class="col-xs-5 form-group">

                                    <label>subject:</label>
                                    <asp:TextBox runat="server" ID="subject1"></asp:TextBox>
                                    <label>To:</label>
                                    <asp:ListBox ID="list1" runat="server" class="form-control " Height="200" name="to" SelectionMode="Multiple">

                                        <asp:ListItem Value="112">Amgad Mohamed Hussien</asp:ListItem>
                                        <asp:ListItem Value="113">Saab</asp:ListItem>
                                        <asp:ListItem Value="114">Opel</asp:ListItem>
                                        <asp:ListItem Value="115">Audi</asp:ListItem>
                                    </asp:ListBox>
                                </div>
                                <div class="col-xs-7 form-group">
                                    <label>Message:</label>
                                    <asp:TextBox ID="message1" class="form-control" TextMode="MultiLine" Height="250" Width="270" runat="server"></asp:TextBox>

                                </div>
                            </div>

                        </div>
                        <div class="modal-footer">
                            <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                            <asp:Button runat="server" ID="button1" CssClass="btn btn-primary" Text="Send" OnClick="button1OnClick" />
                        </div>
                    </form>
                </div>
            </div>
        </div>

    </div>

</asp:Content>

