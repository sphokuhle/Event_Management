<%@ Page Title="" Language="C#" MasterPageFile="~/Eventrix.Master" AutoEventWireup="true" CodeBehind="EventRSVP.aspx.cs" Inherits="Prototype_TNT_Der1.EventRSVP" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <script src="http://maps.googleapis.com/maps/api/js?v=3.exp&key=AIzaSyBZG4nUTvkqIphqxAPyQAF9S1bPBT147Fc"></script>
    <script src="https://code.angularjs.org/1.3.15/angular.js"></script>
    <script src="https://rawgit.com/allenhwkim/angularjs-google-maps/master/build/scripts/ng-map.js"></script>
    <script src="scripts/scripts/MapScript.js"></script>
  
    <script src="scripts/AAF/angular.js"></script>
    <script src="scripts/AAF/Chart.min.js"></script>
    <script src="scripts/AAF/angular-chart.min.js"></script>
    <script src="scripts/scripts/ReportFinal.js"></script>
    <link href="css/Reports/Report.css" rel="stylesheet" />
    <script>
        angular.module('ngMap').run(function ($rootScope) {
            $rootScope.logLatLng = function (e) {
                console.log('loc', e.latLng);
            }
            $rootScope.wayPoints = [
              { location: { lat: 44.32384807250689, lng: -78.079833984375 }, stopover: true },
              { location: { lat: 44.55916341529184, lng: -76.17919921875 }, stopover: true },
            ];
        });
    </script>


    <section class="page-header-wrapper">
        <div class="container">
            <div class="row">
                <div class="col-md-12">
                    <div class="page-header">
                        <h1></h1>
                    </div>
                </div>
            </div>
            <!-- /.row -->
        </div>
        <!-- /.container-fluid -->
    </section>

    <div class="container">
        <div class="content-wrapper">
            <div class="inner-content">
                <div class="row">
                    <div class="col-md-7">
                        <div class="portfolio-content">
                            <%-- Image Slider --%>
                            <div class="post-thumbnail">
                                <div id="blog-post-carousel" class="carousel slide" data-ride="carousel">
                                    <div class="carousel-inner">
                                        <div class="item active" runat="server" id="divImageSlider"></div>
                                        <div class="item" runat="server" id="secondaryImageSlider"></div>
                                    </div>

                                    <a class="left carousel-control" href="#blog-post-carousel" data-slide="prev">
                                        <i class="flaticon-arrowhead4"></i>
                                        <span class="sr-only">Previous</span>
                                    </a>
                                    <a class="right carousel-control" href="#blog-post-carousel" data-slide="next">
                                        <i class="flaticon-arrow437"></i>
                                        <span class="sr-only">Next</span>
                                    </a>
                                </div>
                            </div>
                            <%-- End Of Image Slider --%>
                            <div class="portfolio-info">
                                <p><span class="title">Directions</span></p>
                            </div>
                            <div ng-app="mapModule">
                                <div>
                                    <b>Origin: </b>
                                    <input ng-model="origin" runat="server" />
                                    <b>Mode of Travel: </b>
                                    <select ng-model="travelMode" ng-init="travelMode='DRIVING'">
                                        <option value="DRIVING">Driving</option>
                                        <option value="WALKING">Walking</option>
                                        <option value="BICYCLING">Bicycling</option>
                                        <option value="TRANSIT">Transit</option>
                                    </select>
                                 <div ng-controller="FindEventID">
                                    <ng-map zoom="14" id="my-map" center="-26.20227, 28.04363" on-click="logLatLng()">
                                       <directions
                                         draggable = "true"
                                         panel = "directions-panel"
                                         travel - mode = "{{travelMode}}"
                                         origin = "{{origin}}, South Africa"
                                         destination = "{{EventAddressInfo.STREET}}, {{EventAddressInfo.CITY}},South Africa" >
                                       </directions>
                                     </ng-map>
                                  </div>
                                    Directions path length: {{map.directionsRenderers[0].directions.routes[0].overview_path.length}}   
                                </div>
                            </div>
                        </div>
                    </div>
                    <%-- Event Details --%>
                    <div class="col-md-5">
                        <div class="portfolio-info">
                            <p id="EventName"><span runat="server" id="EName" class="title"></span></p>
                            <p runat="server" id="StartDate"></p>
                            <p runat="server" id="EndDate"></p>
                            <p><span class="title">Description :</span></p>
                            <p runat="server" id="Description"></p>

                            <%-- Product Info --%>
                            <ul runat="server" id="ticketInfo"></ul>
                            <br />
                            <p runat="server" id="ProductsHeading"></p>
                            <ul runat="server" id="Products"></ul>
                            <%-- End of Product Info --%>
                        </div>
                    </div>
                     <%-- End of Event Details --%>
                </div> <!-- /.row -->
            <br />
            <hr />
            <asp:Button ID="btnComing" runat="server" class="btn btn-primary animated bounceIn" Text="Coming" OnClick="btnComing_Click" style="width:110px;"/>
            <asp:Button ID="btnNotCOming" runat="server" class="btn btn-primary animated bounceIn" Text="Not Coming" OnClick="btnNotCOming_Click" style="width:110px;"/>
                <div class="social-link wow fadeInDown">
                    <ul>
                        <li>
                            <asp:LinkButton ID="lnkFB" runat="server" OnClick="lnkFB_Click"><i class="fa fa-facebook"></i></asp:LinkButton>
                        </li>
                        <li>
                            <asp:LinkButton ID="lnkTWT" runat="server" OnClick="lnkTWT_Click"><i class="fa fa-twitter"></i></asp:LinkButton>
                        </li>
                        <li>
                            <asp:LinkButton ID="lnkLndIn" runat="server" OnClick="lnkLndIn_Click"><i class="fa fa-linkedin"></i></asp:LinkButton>
                        </li>
                    </ul>
                </div>
<%--<a href="https://facebook.com/sharer.php?u=http://arunendapally.com/post/implementation-of-single-sign-on-(sso)-in-asp.net-mvc" target="_blank">Facebook</a>
<br/>
<a href="https://www.linkedin.com/shareArticle?mini=true&amp;url=http://arunendapally.com/post/implementation-of-single-sign-on-(sso)-in-asp.net-mvc&title=Implementation of Single Sign On (SSO) in ASP.NET MVC" target="_blank">LinkedIn</a>
<br/>
<a href="https://twitter.com/intent/tweet?url=http://arunendapally.com/post/implementation-of-single-sign-on-(sso)-in-asp.net-mvc&text=Implementation of Single Sign On (SSO) in ASP.NET MVC&via=arunendapally&hashtags=MVC,SSO" target="_blank">Twitter</a>
<br/>
<a href="https://plus.google.com/share?url=http://arunendapally.com/post/implementation-of-single-sign-on-(sso)-in-asp.net-mvc" target="_blank">Google+</a>--%>

        </div> <!-- /.inner-content -->
    </div> <!-- /.content-wrapper -->
    </div>
    <!-- /.container -->


</asp:Content>
