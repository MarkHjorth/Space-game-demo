<%@ Page Title="Personal Stats" Language="C#" MasterPageFile="~/LoggedIn/LoggedInMP.master" AutoEventWireup="true" CodeFile="PersonalStats.aspx.cs" Inherits="LoggedIn_PersonalStats" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ChildContent1" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ChildContent2" runat="Server">
    <div class="container">
        <div class="center-block center-this">
            <input type="submit" value="Toggle scores / sessions" id="toggle" style="width:100%"/>
        </div>
        <div id="statsTable" class="row account-wall padding">
            <h2>Persional Statistics</h2>
            <p>Here you can see your collected scores of your 2984 adventure: </p>
            <asp:Table ID="stats" runat="server" Width="100%" class="table table-striped table-bordered">
            </asp:Table>
        </div>
        <div id="sessionsTable" class="row account-wall padding">
            <h2>Persional sessions</h2>
            <p>Here you can see all the sessions you have played in 2984:</p>
            <asp:Table ID="sessions" runat="server" Width="100%" class="table table-striped table-bordered">
            </asp:Table>
        </div>
    </div>

    <script type="text/javascript">
        $(document).ready(function () {
            $('#sessionsTable').hide();
            
            $('#toggle').click(function () {
                $('#statsTable').toggle(200);
                $('#sessionsTable').toggle(200);
            });
        });
    </script>
</asp:Content>

