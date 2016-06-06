<%@ Page Title="Account" Language="C#" MasterPageFile="~/LoggedIn/LoggedInMP.master" AutoEventWireup="true" CodeFile="Account.aspx.cs" Inherits="Account" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ChildContent1" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ChildContent2" runat="Server">
    <div class="container">
        <div class="row">
            <div class="col-md-10 col-md-offset-1 account-wall">
                <h1 id="uName" runat="server">..</h1>
                <form id="userInfo" class="col-lg-8" runat="server">
                    <table class="table">
                        <tr>
                            <td>
                                <h4>User ID: </h4>
                            </td>
                            <td>
                                <h5 id="userID" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <h4>Username: </h4>
                            </td>
                            <td>
                                <h5 id="userNAME" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <h4>Email: </h4>
                            </td>
                            <td>
                                <h5 id="userEMAIL" runat="server" />
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
                                    <input type="password" value="" placeholder="Old password" id="userPASSWORD" runat="server" />
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
                                <h5 id="userSINCE" runat="server" />
                            </td>
                        </tr>
                    </table>
                    <asp:Button class="btn btn-lg btn-primary center-block" Text="Edit info" ID="editInfo" runat="server" OnClick="btn_update_info_click"></asp:Button>
                </form>
            </div>
        </div>
    </div>

    <script type="text/javascript">
        $(document).ready(function () {
            //$('#userChangeEMAIL').hide();
            //$('#userChangePASSWORD').hide();
            //$('#save').hide();

            $('#show').click(function () {
                alert("Not yet implemented! Try again tomorrow!");
                //$('#userChangeEMAIL').show(100);
                //$('#userChangePASSWORD').show(100);
                //$('#save').show(100);
            });
        });
    </script>
</asp:Content>

