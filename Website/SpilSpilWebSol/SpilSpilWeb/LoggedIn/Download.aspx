<%@ Page Title="Download" Language="C#" MasterPageFile="~/mpDefault.master" AutoEventWireup="true" CodeFile="Download.aspx.cs" Inherits="Download" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container center-block">
        <div class="row row-margin">
            <h1 class="text-center">Download</h1>
            <div class="col-sm-6 col-md-12 center-block text-center account-wall">
                <h2>Latest versions</h2>
                <div class="col-lg-6">
                    <h3><i class="fa fa-windows"></i> For Windows</h3>
                    <a href="https://github.com/DarkShadow93/Specialisering2014/raw/master/Unity/shooter3D/Builds/2984_win.zip" target="_blank"><i class="fa fa-download fa-5x"></i></a>
                </div>
                <div class="col-lg-6">
                    <h3><i class="fa fa-apple"></i> For Mac</h3>
                    <a href="https://github.com/DarkShadow93/Specialisering2014/raw/master/Unity/shooter3D/Builds/2984_mac.zip" target="_blank" onclick="window.open('http://www.google.com');"><i class="fa fa-download fa-5x"></i></a>
                </div>
            </div>

            <div class="col-sm-6 col-md-12 center-block text-center account-wall">
                <h2>Older versions</h2>
                <p>No older versions found..</p>
                <%--<div class="col-lg-6">
                    <h3><i class="fa fa-windows"></i> For Windows</h3>
                    <a href="#" target="_blank"><i class="fa fa-download fa-5x"></i></a>
                </div>
                <div class="col-lg-6">
                    <h3><i class="fa fa-apple"></i> For Mac</h3>
                    <a href="#" target="_blank"><i class="fa fa-download fa-5x"></i></a>
                </div>--%>
            </div>
        </div>
        <br />
    </div>
</asp:Content>

