<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage1.master" AutoEventWireup="true" CodeFile="home.aspx.cs" Inherits="home" %>

<%-- Add content controls here --%>
<asp:Content ID="Content1" runat="server" contentplaceholderid="ContentPlaceHolder1">
   <div class="content">
    <div class="content_resize">
      <div class="mainbar">
        <div class="article">
          <h2><span>First grade</span></h2>
          <div class="clr"></div>
          <p><a href="subject.aspx">Arabic</a></p>
          <p><a href="subject.aspx">English</a></p>
        </div>
        <div class="article">
          <h2><span>Second grade</span></h2>
          <div class="clr"></div>
          <p><a href="subject.aspx">Math</a></p>
          <p><a href="subject.aspx">English</a></p>
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
      </div>
      <div class="clr"></div>
    </div>
  </div>
</asp:Content>