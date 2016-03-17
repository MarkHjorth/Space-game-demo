<%@ Page Title="Account" Language="C#" MasterPageFile="~/LoggedIn/LoggedInMP.master" AutoEventWireup="true" CodeFile="Account.aspx.cs" Inherits="Account" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ChildContent1" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ChildContent2" runat="Server">
    <div class="container">
        <div class="row">
            <div class="col-md-10 col-md-offset-1 account-wall">
                <h1 id="uName" runat="server">..</h1>
                <div class="col-lg-6">
                    <table class="table">
                        <tr>
                            <td>
                                <h4>User ID: </h4>
                            </td>
                            <td>
                                <h5>
                                    <input type="text" value="id" readonly="true" id="userID" runat="server"/>
                                </h5>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <h4>Username: </h4>
                            </td>
                            <td>
                                <h5>
                                    <input type="text" value="name" readonly="true" id="userNAME" runat="server" />
                                </h5>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <h4>Email: </h4>
                            </td>
                            <td>
                                <h5>
                                    <input type="text" value="email" id="userEMAIL" runat="server" />
                                </h5>
                            </td>
                            <td>
                                <h5>
                                    <input type="text" value="" placeholder="New Email" id="userChangeEMAIL" runat="server" />
                                </h5>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <h4>Password: </h4>
                            </td>
                            <td>
                                <h5>
                                    <input type="password" value="pass" id="userPASSWORD" runat="server" />
                                </h5>
                            </td>
                            <td>
                                <h5>
                                    <input type="password" value="" placeholder="New password" id="userChangePASSWORD" runat="server" />
                                </h5>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <h4>Member since: </h4>
                            </td>
                            <td>
                                <h5>
                                    <input type="text" value="member since" readonly="true" id="userSINCE" runat="server" />
                                </h5>
                            </td>
                        </tr>
                        <tr id="save">
                            <td></td>
                            <td></td>
                            <td>
                                <button>Save new info</button>
                            </td>
                        </tr>
                    </table>
                    <button id="show">Edit info</button>
                </div>
            </div>
        </div>
    </div>

    <script type="text/javascript">
        $(document).ready(function () {
            $('#userChangeEMAIL').hide();
            $('#userChangePASSWORD').hide();
            $('#save').hide();

            $('#show').click(function () {
                alert("Not yet implemented! Try again tomorrow!");
                //$('#userChangeEMAIL').show(100);
                //$('#userChangePASSWORD').show(100);
                //$('#save').show(100);
            });
        });
    </script>
</asp:Content>

