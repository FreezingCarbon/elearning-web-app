<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage1.master" AutoEventWireup="true" CodeFile="admin.aspx.cs" Inherits="admin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Stylesheets" runat="Server">
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
                            <h4>Create Grade</h4>
                        </div>
                        <form class="panel-body form-horizontal">
                            <input type="text" class="form-control" placeholder="Name" />
                            <input type="button" class="btn-info" value="Create" />
                        </form>

                    </div>
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            <h4>Create New Class</h4>
                        </div>
                        <form class="panel-body form-horizontal">
                            <select class="form-control">
                                <option>Grade1</option>
                                <option>Grade2</option>
                                <option>Grade3</option>
                                <option>Grade4</option>
                            </select>

                            <input type="button" class="btn-info" value="New Class" />
                        </form>

                    </div>
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            <h4>Create/Update Scheduale</h4>
                        </div>
                        <form class="panel-body form-horizontal">
                            <select class="form-control">
                                <option>Grade1-4</option>
                                <option>Grade2-2</option>
                                <option>Grade3-3</option>
                                <option>Grade4-12</option>
                            </select>

                            <input type="button" class="btn-info" value="Class Schedule" />
                        </form>
                        <form class="panel-body form-horizontal">
                            <select class="form-control">
                                <option>Amgad</option>
                                <option>Mohsen</option>
                                <option>Hatem</option>
                                <option>Hassan</option>
                            </select>

                            <input type="button" class="btn-info" value="Teacher Schedule" />
                        </form>

                    </div>
                </div>
                <div class="col-md-4">
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            <h4>Create New Account</h4>
                        </div>
                        <form class="panel-body form-horizontal" method="post">
                            <input type="text" class="register-input" placeholder="Name" />
                            <input type="text" class="register-input" placeholder="Username" />
                            <input type="text" class="register-input" placeholder="Email address" />
                            <input type="password" class="register-input" placeholder="Password" />
                            <select class="form-control" name="type">
                                <option>Teacher</option>
                                <option>Admin</option>
                            </select>
                            <input type="submit" value="Create Account" class="register-button" />
                        </form>
                    </div>
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            <h4>View Student/Teacher Page</h4>
                        </div>
                        <form class="panel-body form-horizontal">
                            <select class="form-control">
                                <option>Amgad Mohamed(AMGADMHM)</option>
                                <option>Mohsen(MO2014)</option>
                            </select>

                            <input type="button" class="btn-info" value="View page" />
                        </form>

                    </div>
                </div>


                <div class="col-md-4">
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            <h4>Studnets in each Class</h4>
                        </div>
                        <div class="panel-body">
                        <table class="table table-hover">
                            <tr><th>Class</th><th>Total</th><th>Active</th></tr>
                            <tbody><tr><td>Grad1-12</td><td>32</td><td>20</td></tr></tbody>
                        </table>
                            </div>
                    </div>

                </div>
            </div>
        </div>
    </div>
</asp:Content>

