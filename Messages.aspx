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
            <li><a href="user.aspx">Ahmed</a></li>
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
                                    <a href="#" class="list-group-item">
                                        <span class="name" style="min-width: 120px; display: inline-block;">Bhaumik Patel</span> <span class="">This is big title</span>
                                        <span class="text-muted" style="font-size: 11px;">- Hi hello how r u ?</span>
                                        <span class="badge">12:10 AM</span>

                                    </a>
                                </div>
                            </div>
                            <div class="tab-pane fade in " id="sent">
                                <div class="list-group">
                                    <a href="#" class="list-group-item">
                                        <span class="name" style="min-width: 120px; display: inline-block;">Bhaumik Patel</span> <span class="">This is big title</span>
                                        <span class="text-muted" style="font-size: 11px;">- Hi hello how r u ?</span>
                                        <span class="badge">12:10 AM</span>

                                    </a>
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
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                        <h4 class="modal-title">Send Message</h4>
                    </div>
                    <div class="modal-body">
                        <form class="form-inline">
                            <div class="row">
                                <div class="col-xs-5 form-group">
                                    <label>To:</label>
                                    <select class="form-control " size="14" name="to" multiple>
                                        <option value="112">Amgad Mohamed Hussien</option>
                                        <option value="113">Saab</option>
                                        <option value="114">Opel</option>
                                        <option value="115">Audi</option>
                                    </select>
                                </div>
                                <div class="col-xs-7 form-group">
                                    <label>Message:</label>
                                    <textarea class="form-control" rows="11" cols="38"></textarea>
                                </div>
                            </div>
                        </form>
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                        <button type="button" class="btn btn-primary">Send</button>
                    </div>
                </div>
            </div>
        </div>

    </div>

</asp:Content>

