<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage1.master" AutoEventWireup="true" CodeFile="schedule.aspx.cs" Inherits="schedule" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Stylesheets" runat="Server">
    <link href="timetablestyle.css" rel="stylesheet" />
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

            <td>Physics-1</td>
            <td>English</td>
            <td title="No Class" class="Holiday"></td>
            <td>Chemestry-1</td>
            <td>Alzebra</td>
            <td>Physical</td>
            </div>
        </tr>

        <tr>
            <th>11:00 - 12:00</td>
        
            <td>Math-2</td>
                <td>Chemestry-2</td>
                <td>Physics-1</td>
                <td>Arabic</td>
                <td>English</td>
                <td>Soft Skill</td>
            </div>
        </tr>

        <tr>
            <th>12:00 - 01:00</td>
        
            <td>Arabic</td>
                <td>English</td>
                <td>Math-1</td>
                <td>Chemistry</td>
                <td>Physics</td>
                <td>Chem.Lab</td>
            </div>
        </tr>

        <tr>
            <th>01:00 - 02:00</td>
        
            <td>Cumm. Skill</td>
                <td>Sports</td>
                <td>English</td>
                <td>Computer Lab</td>
                <td>Arabic</td>
                <td>Arabic</td>
            </div>
        </tr>

        <tr>
            <th>02:00 - 03:00</td>
        
            <td>Art</td>
                <td>Arabic</td>
                <td>Computers</td>
                <td></td>
                <td></td>
                <td></td>
            </div>
        </tr>
    </table>

</asp:Content>

