<%@ Page Title="Scoreboards" Language="C#" MasterPageFile="~/mpDefault.master" AutoEventWireup="true" CodeFile="Scoreboards.aspx.cs" Inherits="Scoreboards" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container">
        <div class="row account-wall padding">
            <h2>Global Scoreboards</h2>
            <p>Here you can see the scores of all 2984 players. </p>
            
            <asp:Table ID="aspTable" runat="server" Width="100%" class="table table-striped table-bordered">
            </asp:Table>
        </div>
    </div>
</asp:Content>

