<%@ Page Title="Change Password" Language="C#" MasterPageFile="~/mpDefault.master" AutoEventWireup="true" CodeFile="ChangePassword.aspx.cs" Inherits="ChangePassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="container">
        <div class="row">
            <div class="col-sm-6 col-md-4 col-md-offset-4">
                <div class="account-wall">
                    <i class="fa fa-3x fa-rocket login-title">Edit Password</i>
                    <form id="signinform" class="form-signin" runat="server">
                        <input id="honneyPot" type="text" class="hidden" runat="server" />
                        <input id="password" type="password" class="form-control center-block" placeholder="New password" runat="server" required autofocus />
                        <input id="passConf" type="password" class="form-control center-block" placeholder="Repeat password" runat="server" required />
                        <asp:button id="btn" ClientIDMode="Static" text="Sign in" class="btn btn-lg btn-primary btn-block center-block" type="submit" runat="server" OnClick="btn_forgot_click"></asp:button>
                        <span class="clearfix"></span>
                    </form>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

