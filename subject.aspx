<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage1.master" AutoEventWireup="true" CodeFile="subject.aspx.cs" Inherits="_class" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Stylesheets" runat="Server">
    <script src="js/jquery-2.1.3.js"></script>
    <link href="css/bootstrap.min.css" rel="stylesheet" />
    <script src="js/bootstrap.min.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder3" runat="Server">
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
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="content">
        <div class="content_resize">
            <div class="mainbar">
                <div class="article">
                    <h2><span>Sessions</span></h2>
                    <table class="table table-hover">
                        <thead>
                            <tr>
                                <th>Date</th>
                                <th>video</th>
                                <th>Notes</th>
                            </tr>
                        </thead>
                        <tbody>
                            <tr>
                                <td>22-05-2014</td>
                                <td><a href="video.aspx">View</a></td>
                                <td><a href="notes.aspx">Download</a></td>
                            </tr>
                            <%if (Request.QueryString["type"] == "Teacher")
                              {%>
                            <tr>
                                <td>
                                    <div id="newsession">
                                        <p><a data-toggle="modal" href="#form-content" class="btn btn-primary">New Session!</a></p>
                                    </div>
                            </tr>
                            <%} %>
                        </tbody>
                    </table>

                </div>
                <div class="clr"></div>

            </div>
            <div class="sidebar">
                <div class="gadget">
                    <h2></h2>
                    <ul>
                        <li><strong>Subject: </strong>Math-1</li>
                        <li><strong>Class: </strong>1A</li>
                        <li><strong>Teacher: </strong>Prof.Amgad Mohamed</li>
                        <li><strong>Day: </strong>Monday</li>

                    </ul>
                </div>
            </div>
            <div id="form-content" class="modal hide fade in" style="display: none;">
        <div class="modal-header">
            <a class="close" data-dismiss="modal">×</a>
            <h3>New Session</h3>
        </div>
        <div class="modal-body">
            <form class="contact" name="session">
                <label class="label" for="date">Date</label><br>
                <input type="date" name="date" class="input-xlarge"><br>
                <label class="label" for="video">video</label><br>
                <input type="file" name="video" class="input-xlarge"><br>
                <label class="label" for="notes">Notes</label><br>
                <input type="file" name="notes" class="input-xlarge"><br>
            </form>
        </div>
        <div class="modal-footer">
            <input class="btn btn-success" type="submit" value="Send!" id="submit">
            <a href="#" class="btn" data-dismiss="modal">Cancel</a>
        </div>
    </div>
        </div>
    </div>

</asp:Content>


