<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage1.master" AutoEventWireup="true" CodeFile="user.aspx.cs" Inherits="user" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="content">
    <div class="content_resize">
      <div class="mainbar">
        <div class="article">

            <table style="width:100%;">
                <tr>
                    <td style="width: 90px">Username:</td>
                    <td>User1234</td>
                </tr>
                <tr>
                    <td style="width: 90px">Name:</td>
                    <td>Mahmoud Mohsen</td>
                </tr>
                <tr>
                    <td style="width: 90px">Mail:</td>
                    <td>mahmoud@gmail.com</td>
                </tr>
            </table>

        </div>
      </div>
      <div class="sidebar">
        <div class="search">
          <form id="form" name="form" method="post" action="#">
            <span>
            <input name="q" type="text" class="keywords" id="textfield" maxlength="50" value="Search..." />
            <input name="b" type="image" src="images/search.gif" class="button" />
            </span>
          </form>
        </div>
        <div class="gadget">
          <h2></h2>
          <div class="clr"></div>
          <ul class="sb_menu">
            <li><a href="#">My Schedule</a></li>
            <li><a href="#">Edit Profile</a></li>
            <li><a href="#">Inbox</a></li>
            <li><a href="#">Sent Messages</a></li>
            <li><a href="#">Deleted Messages</a></li>
          </ul>
        </div>
      </div>
      <div class="clr"></div>
    </div>
  </div>
</asp:Content>

