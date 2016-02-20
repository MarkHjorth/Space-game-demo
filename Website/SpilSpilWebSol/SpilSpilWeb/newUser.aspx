<%@ Page Title="New User" Language="C#" MasterPageFile="~/mpDefault.master" AutoEventWireup="true" CodeFile="newUser.aspx.cs" Inherits="newUser" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container">
        <div class="row">
            <div class="col-sm-6 col-md-12">
                <div class="account-wall">
                    <%--<img class="profile-img" src="https://lh5.googleusercontent.com/-b0-k99FZlyE/AAAAAAAAAAI/AAAAAAAAAAA/eu7opA4byxI/photo.jpg?sz=120" alt="">--%>
                    <i class="fa fa-5x fa-space-shuttle login-title">Create account</i>
                    <form class="form-signin">
                        <input type="text" id="name" class="form-control center-block" placeholder="Full name" required="required" autofocus data-validation-required-message="Please enter your full name" runat="server" />
                        <input type="email" id="email" class="form-control center-block" placeholder="Email" required="required" data-validation-required-message="Please enter a valid Email" />
                        <input type="email" id="confemail" class="form-control center-block" placeholder="Confirm Email" required="required" oninput="checkem(this)" />
                        <input type="password" id="pass" class="form-control center-block" placeholder="Password" required="required" runat="server" />
                        <input type="password" id="confpass" class="form-control center-block" placeholder="Confirm Password" required="required" oninput="checkps(this)" runat="server" />
                        <button class="btn btn-lg btn-primary btn-block center-block" type="submit" id="createAcc" runat="server" >
                            Create Account
                        </button>
                        <span class="clearfix"></span>
                    </form>
                </div>
            </div>
        </div>
    </div>





    <script type='text/javascript'>
        //Check if email match
        function checkem(input) {
            if (input.value != document.getElementById('email').value) {
                input.setCustomValidity('Emails must be matching!');
            } else {
                // input is valid -- reset the error message
                input.setCustomValidity('');
            }
        }

        //Check if passwords match
        function checkps(input) {
            if (input.value != document.getElementById('pass').value) {
                input.setCustomValidity('Passwords must be matching!');
            } else {
                // input is valid -- reset the error message
                input.setCustomValidity('');
            }
        }

        //Check if password is safe
        function checkPassSafe(str) {
            // at least one number, one lowercase and one uppercase letter
            // at least six characters
            var re = /(?=.*\d)(?=.*[a-z])(?=.*[A-Z]).{6,}/;
            return re.test(str);
        }
    </script>
</asp:Content>

