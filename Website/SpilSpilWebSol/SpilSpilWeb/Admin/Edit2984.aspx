<%@ Page Title="Edit 2984" Language="C#" MasterPageFile="~/Admin/mpAdmin.master" AutoEventWireup="true" CodeFile="Edit2984.aspx.cs" Inherits="Admin_Edit2984" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ChildContent1" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ChildContent2" Runat="Server">
    <div class="container">
        <div class="row text-center account-wall administration">
            <h1 class="center-block">About 2984</h1>
            <form id="editDescriptions" runat="server" >
                <div class="col-lg-12">
                    <h2>Edit 2984</h2>
                    <asp:TextBox ID="desc" runat="server" ValidationGroup="none">About 2984</asp:TextBox>
                </div>
                <asp:Button Text="Save changes" ID="saveChanges" runat="server" OnClick="saveChanges_onClick" />
            </form>
        </div>
    </div>
</asp:Content>

