<%@ Page Title="Contact" Language="C#" MasterPageFile="~/mpDefault.master" AutoEventWireup="true" CodeFile="Contact.aspx.cs" Inherits="Contact" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container center-block">
        <div class="row center-block">
            <div class="account-wall col-lg-5" itemscope itemtype="http://schema.org/Place">
                <h1>Ways to contact wizzGames:</h1>
                <br />
                <div class="col-lg-2"><a href="https://www.facebook.com/groups/1664422403836900/" target="_blank"><i class="fa fa-facebook fa-5x fbLink socLink"></i></a></div>
                <div class="col-lg-2"></div>
                <div class="col-lg-2"><a href="https://twitter.com/WizzGamesTweet" target="_blank"><i class="fa fa-twitter fa-5x twitLink socLink"></i></a></div>
                <div class="col-lg-3"></div>
                <div class="col-lg-2"><a href="https://www.instagram.com/wizzgamesinsta/" target="_blank"><i class="fa fa-instagram fa-5x insLink socLink"></i></a></div>

                <br />
                <a href="https://www.google.dk/maps/place/Sofiendalsvej+60,+9200+Aalborg+SV/@57.0194986,9.8815865,15z/data=!4m2!3m1!1s0x464933ae71ccf9db:0x6c1a8b6ec94a8aa6" class="address socLink" target="_blank">
                    <br />
                    <br />
                    <b>Address:</b><br />
                    Sofiendalsvej 60<br />
                    9000 Aalborg<br />
                </a>
            </div>
            <div class="col-lg-1">
            </div>
            <div class="account-wall col-lg-6">
                <script src='https://maps.googleapis.com/maps/api/js?v=3.exp'></script>
                <div style='overflow: hidden; height: 23em; width: 100%;'>
                    <div id='gmap_canvas' style='height: 100%; width: 100%;'></div>
                    <div><small><a href="http://embedgooglemaps.com">embed google map							</a></small></div>
                    <div><small><a href="http://googlemapsgenerator.com">googlemapsgenerator.com</a></small></div>
                    <style>
                        #gmap_canvas img {
                            max-width: none !important;
                            background: none !important;
                        }
                    </style>
                </div>
                <script type='text/javascript'>function init_map() { var myOptions = { zoom: 14, center: new google.maps.LatLng(57.02096155930723, 9.887620089965838), mapTypeId: google.maps.MapTypeId.ROADMAP }; map = new google.maps.Map(document.getElementById('gmap_canvas'), myOptions); marker = new google.maps.Marker({ map: map, position: new google.maps.LatLng(57.02096155930723, 9.887620089965838) }); infowindow = new google.maps.InfoWindow({ content: '<strong>wizzGames</strong><br>Sofiendalsvej 60<br>' }); google.maps.event.addListener(marker, 'click', function () { infowindow.open(map, marker); }); infowindow.open(map, marker); } google.maps.event.addDomListener(window, 'load', init_map);</script>
            </div>
            <a name="conForm"></a>

            <div class="col-lg-2"></div>
            <div class="footer-newsletter account-wall col-lg-8 text-center center-block">
                <h3>Contact the wizzGames Team</h3>
                <form runat="server">
                    <input id="honneyPot" type="text" runat="server" hidden="hidden" />
                    <p class="newsInfo">Name: </p>
                    <input id="name" type="text" placeholder="Type your name" runat="server" /><br />
                    <br />
                    <p class="newsInfo">Email: *</p>
                    <input id="email" type="text" placeholder="Type your email" runat="server" required="required" /><br />
                    <br />
                    <p class="newsInfo">Subject: </p>
                    <input id="subject" type="text" placeholder="Type a subject" runat="server" /><br />
                    <br />
                    <p class="newsInfo">Message: *</p>
                    <asp:TextBox ID="message" type="text" placeholder="Write your message" runat="server" required="required" />
                    <br />
                    <input type="checkbox" id="acceptTOS" name="terms" class="aggree" runat="server" />
                    <label for="terms" class="aggree">I have read and agreed to the <a href="/Terms.aspx" target="_blank">Terms and Conditions of Use</a></label>
                    <asp:Button ID="btn_contact" ClientIDMode="Static" Text="Submit" class="btn btn-lg btn-primary btn-block center-block subscribe_button" type="submit" OnClick="btn_submit_clicked" runat="server"></asp:Button>
                </form>
            </div>
        </div>
    </div>
</asp:Content>

