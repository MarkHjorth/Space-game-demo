<%@ Page Title="Contact" Language="C#" MasterPageFile="~/mpDefault.master" AutoEventWireup="true" CodeFile="Contact.aspx.cs" Inherits="Contact" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container center-block">
        <div class="row center-block">
            <div class="col-lg-2"></div>
            <div class="footer-newsletter account-wall col-lg-8 text-center center-block">
                <h3>Contact the wizzGames Team</h3>
                <form runat="server">
                    <input id="honneyPot" type="text" runat="server" hidden="hidden"/>
                    <p class="newsInfo">Name: </p>
                    <input id="name" type="text" placeholder="Type your name" runat="server" />
                    <p class="newsInfo">Email: *</p>
                    <input id="email" type="text" placeholder="Type your email" runat="server" />
                    <p class="newsInfo">Subject: </p>
                    <input id="subject" type="text" placeholder="Type a subject" runat="server" />
                    <p class="newsInfo">Message: *</p>
                    <asp:TextBox id="message" type="text" placeholder="Write your message" runat="server" />

                    <asp:Button ID="btn_contact" ClientIDMode="Static" Text="Submit" class="btn btn-lg btn-primary btn-block center-block subscribe_button" type="submit" OnClick="btn_submit_clicked" runat="server"></asp:Button>
                </form>
            </div>
        </div>
    </div>
</asp:Content>

