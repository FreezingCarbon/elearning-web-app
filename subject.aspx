<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage1.master" AutoEventWireup="true" CodeFile="subject.aspx.cs" Inherits="_class" %>



<asp:Content ID="Content4" ContentPlaceHolderID="Stylesheets" runat="Server">
    <script type="text/javascript" src="js/jquery-2.1.3.js"></script>
    <script type="text/javascript" src="js/bootstrap.min.js"></script>
    <script type="text/javascript">
        function viewVideo(videoID) {
            $("#video_model").modal('show');
        }

    </script>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="ContentPlaceHolder3" runat="Server">
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
<asp:Content ID="Content6" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

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
                                <td>
                                    <button onclick="viewVideo('23')">View</button></td>
                                <td><a href="notes.aspx">Download</a></td>
                            </tr>
                            <%if (Request.QueryString["type"] == "Teacher")
                              {%>
                            <tr>
                                <td>
                                    <div id="newsession">
                                        <p><a data-toggle="modal" href="#session_model" class="btn btn-primary">New Session!</a></p>
                                    </div>
                            </tr>
                            <%} %>
                        </tbody>
                    </table>

                </div>
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
            <div class="clr"></div>
        </div>

        <div id="session_model" class="modal fade">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                        <h4 class="modal-title">New Session</h4>
                    </div>
                    <div class="modal-body">
                        <form name="session">
                            <div class="form-inline">
                                <div class="form-group">
                                    <label for="date">Date</label>
                                    <input type="date" class="form-control" name="date">
                                </div>
                                <br />
                                <div class="form-group">
                                    <label for="video">video</label>
                                    <input type="file" class="form-control" name="video">
                                </div>
                                <br />
                                <div class="form-group">
                                    <label for="notes">Notes</label>
                                    <input type="file" class="form-control" name="notes">
                                </div>
                            </div>
                        </form>
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                        <button type="button" class="btn btn-primary">Save changes</button>
                    </div>
                </div>
            </div>
        </div>
        <div id="video_model" class="modal fade">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                        <h4 class="modal-title">Session Video</h4>
                    </div>
                    <div class="modal-body">

                        <video width="100%" controls>
                              <source src=http://techslides.com/demos/sample-videos/small.mp4 type=video/mp4>
                            Your browser does not support HTML5 video.
                        </video>
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                    </div>
                </div>
            </div>
        </div>

    </div>

</asp:Content>
