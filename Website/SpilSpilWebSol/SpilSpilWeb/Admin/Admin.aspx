<%@ Page Title="Admin" Language="C#" MasterPageFile="~/mpDefault.master" AutoEventWireup="true" CodeFile="Admin.aspx.cs" Inherits="Admin_Admin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container">
        <div class="row text-center account-wall">
            <h1 class="center-block">Administration</h1>
            <form id="editDescriptions" runat="server">
                <div class="col-lg-6">
                    <h2>Edit Mark</h2>
                    <asp:TextBox ID="markDesc" runat="server">About Mark</asp:TextBox>
                </div>
                <div class="col-lg-6">
                    <h2>Edit Dave</h2>
                    <asp:TextBox ID="daveDesc" runat="server" >About David</asp:TextBox>
                </div>
                <asp:Button Text="Save changes" ID="saveChanges" runat="server" OnClick="saveChanges_onClick" />
            </form>
        </div>
    </div>
</asp:Content>

