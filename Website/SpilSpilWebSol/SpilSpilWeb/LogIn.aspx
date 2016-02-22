<%@ Page Title="Log In" Language="C#" MasterPageFile="~/mpDefault.master" AutoEventWireup="true" CodeFile="LogIn.aspx.cs" Inherits="LogIn" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container">
        <div class="row">
            <div class="col-sm-6 col-md-4 col-md-offset-4">
                <div class="account-wall">
                    <i class="fa fa-5x fa-rocket login-title">Sign in</i>
                    <div class="form-signin">
                        <input id="email" type="text" class="form-control center-block" placeholder="Email" required autofocus />
                        <input type="password" class="form-control center-block" placeholder="Password" required />
                        <button id="btn" class="btn btn-lg btn-primary btn-block center-block" type="submit" >
                            Sign in
                        </button>
                        <a href="newUser.aspx" class="pull-left new-account">Create an account </a>
                        <a href="#" class="pull-right need-help">Forgot password</a>
                        <span class="clearfix"></span>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

