<%@ Page Title="Forgot Password" Language="C#" MasterPageFile="~/mpDefault.master" AutoEventWireup="true" CodeFile="ForgotPassword.aspx.cs" Inherits="ForgotPassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="container">
        <div class="row">
            <div class="col-sm-6 col-md-4 col-md-offset-4">
                <div class="account-wall">
                    <i class="fa fa-3x fa-rocket login-title">Reset Password</i>
                    <form id="signinform" class="form-signin" runat="server">
                        <input id="honneyPot" type="text" class="hidden" runat="server" />
                        <input id="email" type="text" class="form-control center-block" placeholder="Email" runat="server" required autofocus />
                        <asp:button id="btn" ClientIDMode="Static" text="Submit" class="btn btn-lg btn-primary btn-block center-block" type="submit" runat="server" OnClick="btn_forgot_click"></asp:button>
                        <span class="clearfix"></span>
                    </form>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

