<%@ Page Title="" Language="C#" MasterPageFile="~/Eventrix.Master" AutoEventWireup="true" CodeBehind="Report.aspx.cs" Inherits="Prototype_TNT_Der1.Report" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=12.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
          
<%--    <link href="css/Reports/Report.css" rel="stylesheet" />
    <script src="js/Reports/angular.min.js"></script>
    <script src="js/Reports/Chart.min.js"></script>
    <script src="js/Reports/angular-chart.min.js"></script>
    <script src="js/Reports/EventReport.js"></script>--%>

     <link href="css/Reports/Report.css" rel="stylesheet" />
    <script src="scripts/AAF/angular.js"></script>
    <script src="scripts/AAF/Chart.js"></script>
    <script src="scripts/AAF/angular.min.js"></script>
    <script src="scripts/AAF/Chart.min.js"></script>
    <script src="scripts/AAF/EventReports.js"></script>

    <style>
        table, th, tr, td {
            border: none;
            border-collapse: collapse;
            border-style: none;
        }

        .Formlabel {
            text-align: left;
            display: inline;
            display: block;
        }

        #content {
            margin: 15px auto;
            text-align: center;
            width: 1000px;
            position: relative;
            height: 100%;
        }

        #wrapper {
            -moz-box-shadow: 0px 0px 3px #aaa;
            -webkit-box-shadow: 0px 0px 3px #aaa;
            box-shadow: 0px 0px 3px #aaa;
            -moz-border-radius: 10px;
            -webkit-border-radius: 10px;
            border-radius: 10px;
            border: 2px solid #fff;
            background-color: #f9f9f9;
            width: 1000px;
            overflow: hidden;
            padding: 10px;
        }


        .hidden {
            display: none;
        }

        .middle {
            margin-left: auto;
            margin-right: auto;
            width: 98%;
        }

        .col-md-6 {
            padding: 5px;
        }

        .x_panel {
            background-color: white;
            margin-bottom: 12px;
            border: 1px solid #E4E4E4;
            border-radius: 7px;
        }

        .x_content {
            padding: 10px;
        }

        .count {
            font-size: 20px;
        }

        .row {
            margin-bottom: 10px;
        }

        li {
            padding-top: 5px;
            padding-bottom: 5px;
            margin-left: 2px;
            margin-right: 5px;
        }
    </style>
    <section class="page-header-wrapper">
        <div class="container">
            <div class="row">
                <div class="col-md-12">
                    <div class="page-header">
                    </div>
                    <ol class="breadcrumb">
                        <li><a href="Index.aspx">Home</a></li>
                        <li><a href="#">Event Management</a></li>
                        <li class="active">Reports</li>
                    </ol>
                </div>
            </div>
            <!-- /.row -->
        </div>
        <!-- /.container-->
    </section>

    <div class="container" ng-app="reportsModule">
        <div class="content-wrapper">
            <div class="inner-content">
                <div class="row">
                    <div class="typography-page-tab" role="tabpanel">
                        <!-- Nav tabs -->
                        <ul class="nav nav-tabs" role="tablist">
                            <li role="presentation" class="active"><a href="#before" aria-controls="home" role="tab" data-toggle="tab">Before Event</a></li>
                            <li role="presentation"><a href="#during" aria-controls="profile" role="tab" data-toggle="tab">During Event</a></li>
                            <li role="presentation"><a href="#after" aria-controls="messages" role="tab" data-toggle="tab">After Event</a></li>
                        </ul>

                        <!-- Tab panes -->
                        <div class="tab-content">
                            <div role="tabpanel" class="tab-pane fade in active" id="before">

                                <div class="market-updates">
                                    <div class="col-md-3 market-update-gd">
                                        <div class="market-update-block clr-block-4" style="height: 144px">
                                            <div class="col-md-4 market-update-right">
                                                <i class="fa fa-eye"></i>
                                            </div>
                                            <div class="col-md-8 market-update-left">
                                                <h4>Event Views</h4>
                                                <br />
                                                <h3 runat="server" id="numViews"></h3>
                                            </div>
                                            <div class="clearfix"></div>
                                        </div>
                                    </div>
                                    <div class="col-md-3 market-update-gd">
                                        <div class="market-update-block clr-block-4" style="height: 144px">
                                            <div class="col-md-4 market-update-right">
                                                <i class="fa fa-calendar" style="font-size: 3em; color: #fff; text-align: left;"></i>
                                            </div>
                                            <div class="col-md-8 market-update-left">
                                                <h4>Last Event View Was on</h4>
                                                <h4 runat="server" id="ViewDate"></h4>
                                            </div>
                                            <div class="clearfix"></div>
                                        </div>
                                    </div>
                                    <div class="col-md-3 market-update-gd">
                                        <div class="market-update-block clr-block-4" style="height: 144px">
                                            <div class="col-md-4 market-update-right">
                                                <i class="fa fa-users"></i>
                                            </div>
                                            <div class="col-md-8 market-update-left">
                                                <h4>Event Shares</h4>
                                                <br />
                                                <h3 runat="server" id="numShares"></h3>
                                            </div>
                                            <div class="clearfix"></div>
                                        </div>
                                    </div>
                                    <div class="col-md-3 market-update-gd">
                                        <div class="market-update-block clr-block-4" style="height: 144px">
                                            <div class="col-md-4 market-update-right">
                                                <i class="fa fa-calendar" style="font-size: 3em; color: #fff; text-align: left;"></i>
                                            </div>
                                            <div class="col-md-8 market-update-left">
                                                <h4>Recent Share Was On</h4>
                                                <h4 runat="server" id="shareDate"></h4>
                                            </div>
                                            <div class="clearfix"></div>
                                        </div>
                                    </div>

                                    <div class="clearfix"></div>
                                </div>

                                <div class="row">
                                    <div class="col-md-12">
                                        <div class="panel-group" role="tablist" aria-multiselectable="true">
                                            <div class="panel panel-default">
                                                <div class="panel-heading panel-heading-link" role="tab">
                                                    <h2 class="panel-title" style="text-align: center;"> Number of Tickets Remaining </h2>
                                                </div>
                                                <div class="panel-collapse collapse in">
                                                    <div class="panel-body" ng-controller="pieCtrl_AccPerCampus">
                                                        <canvas id="pie" class="chart chart-doughnut"
                                                            chart-data="NumCampData" chart-labels="['EB','Reg','VIP','VVIP']" chart-options="options">
                                                        </canvas>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-6">
                                        <div class="panel-group"  role="tablist" aria-multiselectable="true">
                                            <div class="panel panel-default">
                                                <div class="panel-heading panel-heading-link" role="tab">
                                                   <h2 class="panel-title" style="text-align: center;">Another Report</h2>
                                                </div>
                                                <div class="panel-collapse collapse in">
                                                    <div class="panel-body">
                                                      <%--  <div class="row typography-page-chart text-center" runat="server" id="DivCheckedIn">
                                                        </div>--%>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-6">
                                        <div class="panel-group"  role="tablist" aria-multiselectable="true">
                                            <div class="panel panel-default">
                                                <div class="panel-heading panel-heading-link" role="tab">
                                                    <h2 class="panel-title" style="text-align: center;"> Another Report</h2>
                                                </div>
                                                <div class="panel-collapse collapse in">
                                                    <div class="panel-body">
                                                        Graph
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>

                            </div>
                            <div role="tabpanel" class="tab-pane fade" id="during">
                                <div class="row">
                                    <div class="col-md-6">
                                        <div class="panel-group"  role="tablist" aria-multiselectable="true">
                                            <div class="panel panel-default">
                                                <div class="panel-heading panel-heading-link" role="tab">
                                                    <h2 class="panel-title" style="text-align: center;"> Most Used WorkStation</h2>
                                                </div>
                                                <div class="panel-collapse collapse in">
                                                    <div ng-controller="lineCtrl_CheckedGuest">
                                                        <%-- <div ng-show="APK[0] > APK[1] || APB[0] > APB[1] || SWC[0] > SWC[1] || DFC[0] > DFC[1]  ">
                                     <label ng-if="APK[0] > APK[1]" class="alert alert-danger" style="font-weight:400; width:98%">Demand is greater than supply at APK campus</label>
                                     <label ng-if="APB[0] > APB[1]" class="alert alert-danger" style="font-weight:400; width:98%">Demand is greater than supply at APB campus</label>
                                     <label ng-if="DFC[0] > DFC[1]" class="alert alert-danger" style="font-weight:400; width:98%">Demand is greater than supply at DFC campus</label>
                                     <label ng-if="SWC[0] > SWC[1]" class="alert alert-danger" style="font-weight:400; width:98%">Demand is greater than supply at SWC campus</label>

                                </div>--%>
                                                        <canvas id="line" class="chart chart-bar" chart-data="[[Int_One[1],Int_Two[1],Int_Three[1],Int_Four[1]],[Int_One[0],Int_Two[0],Int_Three[0],Int_Four[0]]]"
                                                            chart-labels="['First Hour','Second Hour','Third Hour','Final Hour']" chart-series="series" chart-options="options"></canvas>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-6">
                                        <div class="panel-group"  role="tablist" aria-multiselectable="true">
                                            <div class="panel panel-default">
                                                <div class="panel-heading panel-heading-link" role="tab">
                                                    <h2 class="panel-title" style="text-align: center;"> Number of Scans per Staff For Procurement</h2>
                                                </div>
                                                <div class="panel-collapse collapse in" >
                                                    <div class="panel-body" runat="server" id="piechart">
                                                        
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                <div class="col-md-12">
                                    <div class="panel-group"  role="tablist" aria-multiselectable="true">
                                            <div class="panel panel-default">
                                                <div class="panel-heading panel-heading-link" role="tab">
                                                    <h2 class="panel-title" style="text-align: center;"> Number of Scans per Staff For Procurement</h2>
                                                </div>
                                                <div class="panel-collapse collapse in" >
                                                    <div class="panel-body" runat="server" id="Div1">
                                                       
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-12">
                                        <div class="panel-group"  role="tablist" aria-multiselectable="true">
                                            <div class="panel panel-default">
                                                <div class="panel-heading panel-heading-link" role="tab">
                                                    <h2 class="panel-title" style="text-align: center;"> Most Checked In Entrance</h2>
                                                </div>
                                                <div class="panel-collapse collapse in">
                                                    <div class="panel-body" runat="server" id="DivCheckedIn">
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                <div class="row">
                                    <div class="col-md-6">
                                        <div class="panel-group"  role="tablist" aria-multiselectable="true">
                                            <div class="panel panel-default">
                                                <div class="panel-heading panel-heading-link" role="tab">
                                                    <h2 class="panel-title" style="text-align: center;"> Another Report</h2>
                                                </div>
                                                <div class="panel-collapse collapse in">
                                                    <div class="panel-body">
                                                        Graph
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-6">
                                        <div class="panel-group"  role="tablist" aria-multiselectable="true">
                                            <div class="panel panel-default">
                                                <div class="panel-heading panel-heading-link" role="tab">
                                                    <h2 class="panel-title" style="text-align: center;"> Another Report</h2>
                                                </div>
                                                <div class="panel-collapse collapse in">
                                                    <div class="panel-body">
                                                        Graph
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-6">
                                        <div class="panel-group"  role="tablist" aria-multiselectable="true">
                                            <div class="panel panel-default">
                                                <div class="panel-heading panel-heading-link" role="tab">
                                                    <h2 class="panel-title" style="text-align: center;"> Another Report</h2>
                                                </div>
                                                <div class="panel-collapse collapse in">
                                                    <div class="panel-body">
                                                        Graph
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-6">
                                        <div class="panel-group"  role="tablist" aria-multiselectable="true">
                                            <div class="panel panel-default">
                                                <div class="panel-heading panel-heading-link" role="tab">
                                                    <h2 class="panel-title" style="text-align: center;"> Another Report</h2>
                                                </div>
                                                <div class="panel-collapse collapse in">
                                                    <div class="panel-body">
                                                        Graph
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div role="tabpanel" class="tab-pane fade" id="after">
                                <div class="row">
                                    <div class="col-md-6">
                                        <div class="panel-group"  role="tablist" aria-multiselectable="true">
                                            <div class="panel panel-default">
                                                <div class="panel-heading panel-heading-link" role="tab">
                                                    <h2 class="panel-title" style="text-align: center;"> Another Report</h2>
                                                </div>
                                                <div class="panel-collapse collapse in">
                                                    <div class="panel-body">
                                                        Graph
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-6">
                                        <div class="panel-group"  role="tablist" aria-multiselectable="true">
                                            <div class="panel panel-default">
                                                <div class="panel-heading panel-heading-link" role="tab">
                                                    <h2 class="panel-title" style="text-align: center;"> Another Report</h2>
                                                </div>
                                                <div class="panel-collapse collapse in">
                                                    <div class="panel-body">
                                                        Graph
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-6">
                                        <div class="panel-group"  role="tablist" aria-multiselectable="true">
                                            <div class="panel panel-default">
                                                <div class="panel-heading panel-heading-link" role="tab">
                                                    <h2 class="panel-title" style="text-align: center;"> Another Report</h2>
                                                </div>
                                                <div class="panel-collapse collapse in">
                                                    <div class="panel-body">
                                                        Graph
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-6">
                                        <div class="panel-group"  role="tablist" aria-multiselectable="true">
                                            <div class="panel panel-default">
                                                <div class="panel-heading panel-heading-link" role="tab">
                                                    <h2 class="panel-title" style="text-align: center;"> Another Report</h2>
                                                </div>
                                                <div class="panel-collapse collapse in">
                                                    <div class="panel-body">
                                                        Graph
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>

                                <div class="row">
                                    <div class="col-md-12">
                                        <div class="panel-group" role="tablist" aria-multiselectable="true">
                                            <div class="panel panel-default">
                                                <div class="panel-heading panel-heading-link" role="tab">
                                                    <h2 class="panel-title" style="text-align: center;">Product Sold </h2>
                                                </div>
                                                <div class="panel-collapse collapse in">
                                                    <div class="panel-body">
                                                        <table class="table stats-table ">
                                                            <thead>
                                                                <tr>
                                                                    <th style="text-align: center;">P.NO</th>
                                                                    <th style="text-align: center;">PRODUCT</th>
                                                                    <th style="text-align: center;">SOLD</th>
                                                                    <th style="text-align: center;">REMAINING</th>
                                                                    <th style="text-align: center;">PROGRESS</th>
                                                                </tr>
                                                            </thead>
                                                            <tbody runat="server" id="ProductRowDiv">
                                                           <%--     <tr>
                                                                    <td style="text-align: center;">1</td>
                                                                    <td style="text-align: center;">Cheese Burger</td>
                                                                    <td style="text-align: center;"><span class="label label-success">15 </span></td>
                                                                    <td style="text-align: center;"><span class="label label-danger">7 </span></td>
                                                                    <td style="text-align: center;">
                                                                        <h5>10% <i class="fa fa-level-up"></i></h5>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="text-align: center;">1</td>
                                                                    <td style="text-align: center;">Beef Burger</td>
                                                                    <td style="text-align: center;"><span class="label label-success">15 </span></td>
                                                                    <td style="text-align: center;"><span class="label label-danger">7 </span></td>
                                                                    <td style="text-align: center;">
                                                                        <h5>10% <i class="fa fa-level-down"></i></h5>
                                                                    </td>
                                                                </tr>--%>
                                                            </tbody>
                                                        </table>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
        </div>
</asp:Content>
