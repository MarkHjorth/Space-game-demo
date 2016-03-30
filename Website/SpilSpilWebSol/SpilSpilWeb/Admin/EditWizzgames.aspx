<%@ Page Title="Edit Devs" Language="C#" MasterPageFile="~/Admin/mpAdmin.master" AutoEventWireup="true" CodeFile="EditWizzgames.aspx.cs" Inherits="Admin_EditWizzgames" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ChildContent1" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ChildContent2" Runat="Server">
    <div class="container">
        <div class="row text-center account-wall administration">
            <h1 class="center-block">About wizzGames</h1>
            <form id="editDescriptions" runat="server" >
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

