<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage1.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content2" ContentPlaceHolderID="Stylesheets" runat="server">
</asp:Content>

<asp:Content ID="menu" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container">
        <div class="row">
            <div class="col-lg-5 col-md-offset-1">
                <h1 class="register-title">SignUp</h1>
                <form class="register" action="home.aspx" method="post">
                    <input type="text" class="register-input" placeholder="Name" />
                    <input type="text" class="register-input" placeholder="Username" />
                    <input type="text" class="register-input" placeholder="Email address" />
                    <input type="password" class="register-input" placeholder="Password" />
                    <input type="submit" value="Create Account" class="register-button" />
                </form>

            </div>

            <div class="col-lg-5 ">
                <h1 class="register-title">Login</h1>
                <form  runat="server" class="register" method="post">
                    
                    <asp:TextBox id="userName_login" runat="server" class="register-input" placeholder="Username" />
                    <asp:TextBox id="passwordLogin" runat="server"  TextMode="Password" class="register-input" placeholder="Password" />
                    <asp:Button runat="server" ID="LoginButton" Text="Login" CssClass="register-button" OnClick="LoginButton_Click" />

                </form>

            </div>
        </div>
    </div>

</asp:Content>

