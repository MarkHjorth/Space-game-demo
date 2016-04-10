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
                    <a href="../Downloads/2984_Installation.exe" type="application/octet-stream" target="_blank"><i class="fa fa-download fa-5x"></i></a>
                </div>
                <div class="col-lg-6">
                    <h3><i class="fa fa-apple"></i> For Mac</h3>
                    <a href="http://46.101.132.22/pages/download.php?ref=7&ext=zip&k=48c0d9b176" target="_blank"><i class="fa fa-download fa-5x"></i></a>
                </div>
            </div>

            <div class="col-sm-6 col-md-12 center-block text-center account-wall">
                <h2>Older versions <i id="installGuide" class="fa fa-info-circle center-block"></i></h2>
                <br />
                <div id="guide" style="display: none">
                    <h5>Old versions are found at ResourceSpace as zip files.</h5>
                    <p>
                        To install an older version of the game, 
                        simply download the zipped files, and unpack them to the desired location. 
                    </p>
                </div>
                
                <div class="col-lg-6">
                    <h3><i class="fa fa-windows"></i> For Windows</h3>
                    <a href="http://46.101.132.22/?c=2&k=2a3f900a3d" target="_blank"><i class="fa fa-external-link-square fa-5x"></i></a>
                </div>
                <div class="col-lg-6">
                    <h3><i class="fa fa-apple"></i> For Mac</h3>
                    <a href="http://46.101.132.22/?c=3&k=49a9181833" target="_blank"><i class="fa fa-external-link-square fa-5x"></i></a>
                </div>
            </div>
        </div>
        <br />
    </div>

    <script type="text/javascript">
        $(document).ready(function () {
            $('#installGuide').hover(function () {
                if ($('#guide').css('display') == 'block') {
                    $('#guide').css('display', 'none');
                } else {
                    $('#guide').css('display', 'block');
                }
            });
        });
    </script>

</asp:Content>

