<%@ Page Title="" Language="C#" MasterPageFile="~/Eventrix.Master" AutoEventWireup="true" CodeBehind="EventDetails.aspx.cs" Inherits="Prototype_TNT_Der1.EventDetails" %>
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


    <link href="css/Modal/bootstrap.min.css" rel="stylesheet" />

    <section class="page-header-wrapper">
        <div class="container">
            <div class="row">
                <div class="col-md-12">
                    <div class="page-header">
                        <h1>Event Details</h1>
                    </div>
                    <ol class="breadcrumb">
                        <li><a href="Index.aspx">Home</a></li>
                        <li><a href="EventList.aspx">Events</a></li>
                        <li class="active">View Details</li>
                    </ol>
                </div>
            </div>
            <!-- /.row -->
        </div>
        <!-- /.container-->
    </section>

    <div class="container">
        <div class="content-wrapper">
            <div class="inner-content">
                <div class="row">
                    <div class="col-md-7">
                        <div class="portfolio-content">
                            <div runat="server" id="divImageSlider">
                            </div>
                                <table>
                                <tr>
                                    <td>
                                        <div class="social-link wow fadeInDown">
                                            <asp:Button ID="AttendEvent" runat="server" class="btn btn-primary animated bounceIn" Text="Attend Event" Style="width: 110px;" />
                                            <asp:Button ID="btnEdit" runat="server" class="btn btn-primary animated bounceIn" Text="Edit Event" Style="width: 110px;" Onclick="btnEdit_Click"/>
                                            <asp:Button ID="btnDelete" runat="server" class="btn btn-primary animated bounceIn" Text="Delete Event" Style="width: 110px;" OnClick="btnDelete_Click" />
                                            <asp:Button ID="btnReport" runat="server" class="btn btn-primary animated bounceIn" Text="Event Report" Style="width: 110px;" OnClick="btnReport_Click" />
                                        </div>
                                    </td>
                                    <td>
                                        <div class="social-link wow fadeInDown" style="padding-left: 100px;">
                                            <ul>
                                                <li>
                                                    <asp:LinkButton ID="lnkFB" runat="server" OnClick="lnkFB_Click"><i class="fa fa-facebook"></i></asp:LinkButton></li>
                                                <li>
                                                    <asp:LinkButton ID="lnkTWT" runat="server" OnClick="lnkTWT_Click"><i class="fa fa-twitter"></i></asp:LinkButton></li>
                                                <li>
                                                    <asp:LinkButton ID="lnkLndIn" runat="server" OnClick="lnkLndIn_Click"><i class="fa fa-linkedin"></i></asp:LinkButton></li>
                                            </ul>
                                        </div>
                                    </td>
                                </tr>
                            </table>
                            <hr />

                            <div class="market-updates" runat="server" id="market">
                                    <div class="col-md-3 market-update-gd">
                                        <div class="market-update-block clr-block-4" style="height: 144px">
                                            <div class="col-md-4 market-update-right">
                                                <i class="fa fa-eye"></i>
                                            </div>
                                            <div class="">
                                                <br />
                                                <h4>Views</h4>
                                                <p runat="server" id="numViews"></p>
                                            </div>
                                            <div class="clearfix"></div>
                                        </div>
                                    </div>
                                    <div class="col-md-3 market-update-gd">
                                        <div class="market-update-block clr-block-4" style="height: 144px">
                                            <div class="col-md-4 market-update-right">
                                                <i class="fa fa-calendar" style="font-size: 3em; color: #fff; text-align: left;"></i>
                                            </div>
                                            <div class="">
                                                <br/>
                                                <p>Last View Was on</p>
                                                <p runat="server" id="ViewDate"></p>
                                            </div>
                                            <div class="clearfix"></div>
                                        </div>
                                    </div>
                                    <div class="col-md-3 market-update-gd">
                                        <div class="market-update-block clr-block-4" style="height: 144px">
                                            <div class="col-md-4 market-update-right">
                                                <i class="fa fa-users"></i>
                                            </div>
                                            <div class="market-update-left">
                                                <br/>
                                                <p>Event Shares</p>
                                                <p runat="server" id="numShares"></p>
                                            </div>
                                            <div class="clearfix"></div>
                                        </div>
                                    </div>
                                    <div class="col-md-3 market-update-gd">
                                        <div class="market-update-block clr-block-4" style="height: 144px">
                                            <div class="col-md-4 market-update-right">
                                                <i class="fa fa-calendar" style="font-size: 3em; color: #fff; text-align: left;"></i>
                                            </div>
                                            <div class="market-update-left">
                                                <br />
                                                <p>Recent Share Was On</p>
                                                <p runat="server" id="shareDate"></p>
                                            </div>
                                            <div class="clearfix"></div>
                                        </div>
                                    </div>
                                    <div class="clearfix"></div>
                                </div>

                            <h3 runat="server" id="MapVsReportContainer"></h3>
                            <div id="googleMap" runat="server">
                                <div ng-app="mapModule">
                                    <div>
                                        <b>Origin: </b>
                                        <input ng-model="origin" runat="server" />
                                        <b>Mode of Travel: </b>
                                        <select ng-model="travelMode" ng-init="travelMode='DRIVING'" style="height: 30px; width: 174px;">
                                            <option value="DRIVING">Driving</option>
                                            <option value="WALKING">Walking</option>
                                            <option value="BICYCLING">Cycling</option>
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
                                    <%-- Increases the size of the page, hence commented out --%>
                                    <%--<div id="directions-panel" style="width: 28%; float: left; height: 100%; overflow: auto; padding: 0px 5px;">
                                </div>--%>
                                </div>
                            </div>

                            <div ng-app="reportsModule" ng-controller="pieCtrl_AccPerCampus" runat="server" id="PieChart">
                                <canvas id="pie" class="chart chart-doughnut"
                                    chart-data="NumCampData" chart-labels="['EB','Reg','VIP','VVIP']" chart-options="options">
                                </canvas>
                            </div>
                        </div>
                        <!-- /.portfolio-content -->
                    </div>
                    <!-- /.col-md-7 -->

                    <div class="col-md-5">
                        <div class="portfolio-info">
                            <p><span runat="server" id="EName" class="title"></span></p>
                            <p runat="server" id ="StartDate"></p>
                            <p runat="server" id="EndDate"></p>

                            <p runat="server" id="Description">
                            </p>
                            <!-- /.project-live-link -->
                            <br/>
                            <div class="panel-group" id="accordion" role="tablist" aria-multiselectable="true">
                                <div class="panel panel-default" runat="server" id="ticket" >
                                    <div class="panel-heading panel-heading-link" role="tab" id="headingOne">
                                        <h2 class="panel-title">
                                            <a data-toggle="collapse" data-parent="#accordion" href="#collapseOne" aria-expanded="true" aria-controls="collapseOne">Tickets
									        </a>
                                        </h2>
                                    </div>
                                    <div id="collapseOne" class="panel-collapse collapse in" role="tabpanel" aria-labelledby="headingOne">
                                        <div class="panel-body" >
                                            <ul runat="server" id="ticketInfo">
                                                <%--<li><span class="title">Early Bird Tickets :Available 100</span> Price: For Free!, Available Till: 15 September 2017</li>
                                                <li><a class='btn btn-default animated bounceIn' href="PurchaseTicket.aspx?EBT_ID=">Buy Ticket</a></li>
                                                <hr />
                                                <li><span class="title">VIP Tickets :Available 100</span> Price: For Free!, Available Till: </li>
                                                <li><a class='btn btn-default animated bounceIn' href="PurchaseTicket.aspx?EBT_ID=">Buy Ticket</a></li>
                                                <hr />
                                                <li><span class="title">VVIP Tickets :Available 100</span> Price: For Free!, Available Till: </li>
                                                <li><a class='btn btn-default animated bounceIn' href="PurchaseTicket.aspx?EBT_ID=">Buy Ticket</a></li>--%>
                                            </ul>  
                                        </div>
                                    </div>
                                </div>
                                <div class="panel panel-default">
                                    <div class="panel-heading panel-heading-link" role="tab" id="headingTwo">
                                        <h2 class="panel-title">
                                            <a class="collapsed" data-toggle="collapse" data-parent="#accordion" href="#collapseTwo" aria-expanded="false" aria-controls="collapseTwo">Products
									        </a>
                                        </h2>
                                    </div>
                                    <div id="collapseTwo" class="panel-collapse collapse" role="tabpanel" aria-labelledby="headingTwo">
                                        <div class="panel-body">
                                            <ul runat="server" id="Products">
                                               <%-- <tr>
                                                    <td><b>Kota</b></td>
                                                    <td style="padding-left: 180px;">R14.00</td>
                                                </tr>--%>
                                            </ul>
                                        </div>
                                    </div>
                                </div>
                             
                            </div>

                        </div>
                        <!-- /.portfolio-info -->
                    </div>
                    <!-- /.col-md-5 -->
                </div>
                <!-- /.row -->

            </div>
            <!-- /.inner-content -->
        </div>
        <!-- /.content-wrapper -->
    </div>
    <!-- /.container -->

</asp:Content>
