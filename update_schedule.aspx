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
            <li><a href="home.aspx">Home</a></li>
            <li><a href="schedule.aspx">Schedule</a></li>
            <li><a href="Messages.aspx">Messages</a></li>
            <li><a href="user.aspx">Ahmed</a></li>
            <li><a href="logout.aspx">Logout</a></li>
        </ul>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="content">
        <div class="content_resize">
            <div class="row">
                <div class="col-md-4">
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            <h4>Add Session</h4>
                        </div>
                        <form class="panel-body form-horizontal" method="post">
                            <input type="text" class="register-input" value="Grade1-2" disabled="disabled" />

                            <select class="form-control" name="Teacher">
                                <option>Teacher</option>
                                <option>Ahmed Ali</option>
                            </select>
                            <select class="form-control" name="subject">
                                <option>Subject</option>
                                <option>Math</option>
                            </select>
                            <select class="form-control" name="Day">
                                <option>Day</option>
                                <option>Sunday</option>
                            </select>
                            <select class="form-control" name="slot">
                                <option>Slot</option>
                                <option>8 to 8:30</option>
                                <option>11 to 12:30</option>
                            </select>

                            <input type="button" value="Add" class="register-button" />
                        </form>
                    </div>
                    <div class="panel panel-default">
                        <input type="button" class="register-button"  value="Done!"   />
                    </div>
                </div>
                <div class="col-md-8">
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            <h4>Add Session</h4>
                        </div>
                        <div class="panel-body">
                            <table class="table">
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

                                    <td>Physics-1</td>
                                    <td>English</td>
                                    <td></td>
                                    <td>Chemestry-1</td>
                                    <td>Alzebra</td>
                                    <td>Physical</td>

                                </tr>

                                <tr>
                                    <th>11:00 - 12:00</th>

                                    <td>Math-2</td>
                                    <td>Chemestry-2</td>
                                    <td>Physics-1</td>
                                    <td>Arabic</td>
                                    <td>English</td>
                                    <td>Soft Skill</td>
                                </tr>

                                <tr>
                                    <th>12:00 - 01:00</th>

                                    <td>Arabic</td>
                                    <td>English</td>
                                    <td>Math-1</td>
                                    <td>Chemistry</td>
                                    <td>Physics</td>
                                    <td>Chem.Lab</td>
                                </tr>

                                <tr>
                                    <th>01:00 - 02:00</th>

                                    <td>Cumm. Skill</td>
                                    <td>Sports</td>
                                    <td>English</td>
                                    <td>Computer Lab</td>
                                    <td>Arabic</td>
                                    <td>Arabic</td>
                                </tr>

                                <tr>
                                    <th>02:00 - 03:00</th>

                                    <td>Art</td>
                                    <td>Arabic</td>
                                    <td>Computers</td>
                                    <td>
                                        <button onclick="removeSession()" class="btn btn-danger">Math1/Khaled</button></td>
                                    <td></td>
                                    <td></td>
                                </tr>
                            </table>


                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

