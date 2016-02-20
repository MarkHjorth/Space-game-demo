<%@ Page Title="Log In" Language="C#" MasterPageFile="~/mpDefault.master" AutoEventWireup="true" CodeFile="LogIn.aspx.cs" Inherits="LogIn" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container">
        <div class="row">
            <div class="col-sm-6 col-md-4 col-md-offset-4">
                <div class="account-wall">
                    <%--<img class="profile-img" src="https://lh5.googleusercontent.com/-b0-k99FZlyE/AAAAAAAAAAI/AAAAAAAAAAA/eu7opA4byxI/photo.jpg?sz=120" alt="">--%>
                    <i class="fa fa-5x fa-rocket login-title"> Sign in</i>
                    <form class="form-signin">
                        <input type="text" class="form-control center-block" placeholder="Email" required autofocus>
                        <input type="password" class="form-control center-block" placeholder="Password" required>
                        <button class="btn btn-lg btn-primary btn-block center-block" type="submit">
                            Sign in
                        </button>
                        <a href="newUser.aspx" class="pull-left new-account">Create an account </a>
                        <a href="#" class="pull-right need-help">Forgot password</a>
                        <span class="clearfix"></span>
                    </form>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

