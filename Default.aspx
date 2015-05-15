<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage1.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content2" ContentPlaceHolderID="Stylesheets" runat="server">
</asp:Content>

<asp:Content ID="menu" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container">
        <div class="row">
            <form runat="server" >
                <div class="col-lg-5 col-md-offset-1">
                    <h1 class="register-title">SignUp</h1>
                    <div class="register">
                    <asp:TextBox ID="RegName" runat="server" class="register-input" placeholder="Name" />
                    <asp:TextBox ID="RegUser" runat="server" class="register-input" placeholder="Username" />
                    <asp:TextBox ID="RegMail" runat="server" class="register-input" placeholder="E-Mail" />
                    <asp:TextBox ID="RegPass" runat="server" TextMode="Password" class="register-input" placeholder="Password" />
                    <asp:ListBox ID="ListBox1" CssClass="register-input" runat="server">
                        <asp:ListItem Value="-1" Text="None" Selected="True"></asp:ListItem>
                    </asp:ListBox>
                    <asp:Label ID="RegisError" runat="server" CssClass="register-input label-danger" Visible="false" Text="Try Again!"></asp:Label>
                    <asp:Button runat="server" ID="RegButton" Text="Create Acount" CssClass="register-button" OnClick="RegButton_Click" />
                        </div>

                </div>

                <div class="col-lg-5 ">
                    <h1 class="register-title">Login</h1>
                    <div class="register">
                    <asp:TextBox ID="userName_login" runat="server" class="register-input" placeholder="Username" />
                    <asp:TextBox ID="passwordLogin" runat="server" TextMode="Password" class="register-input" placeholder="Password" />
                    <asp:Label ID="ErrorLogin" runat="server" CssClass="register-input label-danger" Visible="false" Text="Try Again!"></asp:Label>
                    <asp:Button runat="server" ID="LoginButton" Text="Login" CssClass="register-button" OnClick="LoginButton_Click" />
                        </div>

                </div>
            </form>

        </div>
    </div>

</asp:Content>

