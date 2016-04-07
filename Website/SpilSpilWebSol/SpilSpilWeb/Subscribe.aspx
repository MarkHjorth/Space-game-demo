<%@ Page Title="Subscribe" Language="C#" MasterPageFile="~/mpDefault.master" AutoEventWireup="true" CodeFile="Subscribe.aspx.cs" Inherits="Subscribe" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="container center-block">
        <div class="row center-block">
            <div class="col-lg-3"></div>
            <div class="center-block account-wall col-lg-6 text-center">
                <h1>Subscribe to the newsletter</h1>
                <form runat="server">
                    <p>An email was sent to the specified email address, with a confirmation code</p>
                    <input id="validationCode" type="text" placeholder="Input the confirmation code here" required="required" runat="server" />
                    <asp:Button ID="btn_news" ClientIDMode="Static" Text="Confirm subscription" class="btn btn-lg btn-primary btn-block center-block subscribe_button" type="submit" runat="server" OnClick="btn_subscribe_click"></asp:Button>
                </form>
            </div>
        </div>
    </div>
</asp:Content>

