<%@ Page Title="New User" Language="C#" MasterPageFile="~/mpDefault.master" AutoEventWireup="true" CodeFile="newUser.aspx.cs" Inherits="newUser" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container">
        <div class="row">
            <div class="col-sm-6 col-md-12">
                <div class="account-wall">
                    <i class="fa fa-5x fa-space-shuttle login-title">&nbspCreate account</i>
                    <form class="form-newuser" runat="server">
                        <asp:TextBox ID="honneyPot" type="text" class="hidden" runat="server" />
                        <asp:TextBox type="text" ID="name" class="form-control center-block" placeholder="Username" required="required" autofocus data-validation-required-message="Please enter a Username" runat="server" />
                        <asp:TextBox type="email" ID="email" class="form-control center-block" placeholder="Email" required="required" data-validation-required-message="Please enter a valid email" runat="server" />
                        <asp:TextBox type="email" ID="confemail" class="form-control center-block" placeholder="Confirm Email" required="required" runat="server" />
                        <asp:TextBox type="password" ID="pass" class="form-control center-block" placeholder="Password" required="required" runat="server" />
                        <asp:TextBox type="password" ID="confpass" class="form-control center-block" placeholder="Confirm Password" required="required" runat="server" />
                        <input type="checkbox" id="acceptTOS" name="terms" class="aggree" runat="server"/>
                        <label for="terms" class="aggree">I have read and agreed to the <a href="/Terms.aspx" target="_blank">'Terms and Conditions of Use'</a> and <a href="/Privacy.aspx" target="_blank">'Privacy Policy'</a></label>
                        <asp:Button class="btn btn-lg btn-primary btn-block center-block" type="submit" Text="Create Account" ID="createAcc" runat="server" OnClick="btn_create_user_click"></asp:Button>
                        <span class="clearfix"></span>
                    </form>
                </div>
            </div>
        </div>
    </div>

    <%--<script type='text/javascript'>
        //Check if email match
        function checkem(input) {
            debugger;
            if (input.value != document.getElementById('email').value) {
                input.setCustomValidity('Emails must be matching!');
            }
            else {
                // input is valid -- reset the error message
                input.setCustomValidity('');
            }
        }

        //Check if passwords match
        function checkps(input) {
            debugger;
            if (input.value != document.getElementById('pass').value) {
                input.setCustomValidity('Passwords must be matching!');
            }
            else {
                // input is valid -- reset the error message
                input.setCustomValidity('');
            }

        }

        //Check if password is safe
        function checkPassSafe(str) {
            debugger;
            // at least one number, one lowercase and one uppercase letter
            // at least six characters
            var re = /(?=.*\d)(?=.*[a-z])(?=.*[A-Z]).{6,}/;
            return re.test(str);
        }
    </script>--%>
</asp:Content>

