<%@ Page Title="Home" Language="C#" MasterPageFile="~/mpDefault.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container center-block">
        <div class="row center-block">
            <div class="col-sm-6 col-md-12 center-block text-center">
                <h1>Welcome to wizzGames</h1>
                <div class="account-wall">
                    <h3>Instagram feed:</h3>
                    <!-- SnapWidget -->
                    <script src="http://snapwidget.com/js/snapwidget.js"></script>
                    <iframe src="http://snapwidget.com/in/?u=d2l6emdhbWVzaW5zdGF8aW58MTI1fDN8Mnx8eWVzfDV8bm9uZXxvblN0YXJ0fHllc3x5ZXM=&ve=250216" title="Instagram Widget" class="snapwidget-widget insta_widget center-block" allowtransparency="true" frameborder="0" scrolling="no"></iframe>
                </div>
            </div>

            <div class="account-wall col-lg-6 text-center">
                <a class="twitter-timeline" href="https://twitter.com/WizzGamesTweet" data-widget-id="717701130038472704">Tweets by @WizzGamesTweet</a>
                <script>!function (d, s, id) { var js, fjs = d.getElementsByTagName(s)[0], p = /^http:/.test(d.location) ? 'http' : 'https'; if (!d.getElementById(id)) { js = d.createElement(s); js.id = id; js.src = p + "://platform.twitter.com/widgets.js"; fjs.parentNode.insertBefore(js, fjs); } }(document, "script", "twitter-wjs");</script>
            </div>

            <div class="col-lg-1"></div>

            <div class="footer-newsletter account-wall col-lg-5 text-center">
                <h3>Newsletter</h3>
                <p class="newsInfo">
                    Sign up here to sell your soul to the dark lords of the universe. 
                    Also, you may get news and updates in your email inbox..
                </p>
                By signing up you agree to the <a href="/Terms.aspx" target="_blank">Terms and Conditions of Use</a> and our <a href="/Privacy.aspx" target="_blank">Privacy Policy</a> of wizzGames
                
                <form runat="server">
                    <input id="emailAddress" type="text" placeholder="Type your email" required runat="server" />
                    <asp:Button ID="btn_news" ClientIDMode="Static" Text="Subscribe" class="btn btn-lg btn-primary btn-block center-block subscribe_button" type="submit" runat="server" OnClick="btn_subscribe_click"></asp:Button>
                </form>
            </div>
        </div>
    </div>
</asp:Content>

