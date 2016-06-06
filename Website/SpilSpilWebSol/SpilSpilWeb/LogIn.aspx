<%@ Page Title="Log In" Language="C#" MasterPageFile="~/mpDefault.master" AutoEventWireup="true" CodeFile="LogIn.aspx.cs" Inherits="LogIn" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container">
        <div class="row">
            <div class="col-sm-6 col-md-4 col-md-offset-4">
                <div class="account-wall">
                    <i class="fa fa-5x fa-rocket login-title">Sign in</i>
                    <form id="signinform" class="form-signin" runat="server">
                        <input id="honneyPot" type="text" class="hidden" runat="server" />
                        <input id="email" type="text" class="form-control center-block" placeholder="Email" runat="server" required autofocus />
                        <input id="password" type="password" class="form-control center-block" placeholder="Password" runat="server" required />
                        <asp:button id="btn" ClientIDMode="Static" text="Sign in" class="btn btn-lg btn-primary btn-block center-block" type="submit" runat="server" OnClick="btn_login_click"></asp:button>
                        <a href="newUser.aspx" class="pull-left new-account">Create an account </a>
                        <a href="/ForgotPassword.aspx" class="pull-right need-help">Forgot password</a>
                        <span class="clearfix"></span>
                    </form>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

