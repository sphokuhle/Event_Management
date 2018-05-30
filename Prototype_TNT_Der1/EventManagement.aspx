<%@ Page Title="" Language="C#" MasterPageFile="~/Eventrix.Master" AutoEventWireup="true" CodeBehind="EventManagement.aspx.cs" Inherits="Prototype_TNT_Der1.EventManagement" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <script src="scripts/AAF/angular.min.js"></script>
    <script src="scripts/EventList.js"></script>


    <section class="page-header-wrapper">
        <div class="container">
            <div class="row">
                <div class="col-md-12">
                    <div class="page-header">
                    </div>
                    <ol class="breadcrumb">
                        <li><a href="Index.aspx">Home</a></li>
                        <li><a href="#">Event Management</a></li>
                        <li class="active">Manage Event</li>
                    </ol>
                </div>
            </div>
            <!-- /.row -->
        </div>
        <!-- /.container-->
    </section>


     <div class="container" ng-app="EventList_App" ng-controller="cntrl_HostList" >
        <div class="content-wrapper">
            <div class="inner-content">
                <div class="row">

                    <div class="panel-group" id="accordion" role="tablist" aria-multiselectable="true">
                        <div class="panel panel-default">
                            <div class="panel-heading panel-heading-link" role="tab" id="headingOne">
                                <h2 class="panel-title">
                                    <a data-toggle="collapse" data-parent="#accordion" href="#collapseOne" aria-expanded="true" aria-controls="collapseOne">Manage Events</a>
                                </h2>
                            </div>
                            <div id="collapseOne" class="panel-collapse collapse in" role="tabpanel" aria-labelledby="headingOne">
                                <div class="panel-body">
                                    <div class="stats-last-agile">
                                        <!-- start project list -->
                                        <table class="table table-striped projects">
                                            <thead>
                                                <tr>
                                                    <th></th>
                                                    <th></th>
                                                    <th></th>
                                                    <th></th>
                                                    <th></th>
                                                </tr>
                                            </thead>
                                            <tbody>
                                                <tr ng-repeat="ev in EventDetails">
                                                    <td style="width: 230px; height: 100px;">
                                                        <img src="{{ev.ImageLocation}}" />
                                                    </td>
                                                    <td></td>
                                                    <td>
                                                        <h4>{{ev.Name}}</h4>
                                                        <small>{{ev.sDate}} TILL {{ev.eDate}}</small><br />
                                                        <small>{{ev.Street}}, {{ev.City}}</small>
                                                    </td>
                                                    <td></td>
                                                     <td style="padding-top:40px;">
                                                        <asp:LinkButton ID="LinkButton1" runat="server"><a href="EventDetails.aspx?ev={{ev.EventID}}" class="btn btn-primary btn-xs"><i class="fa fa-folder"></i>View </a></asp:LinkButton>
                                                        <asp:LinkButton ID="LinkButton2" runat="server"><a href="AAFReport.aspx?ev={{ev.EventID}}" class="btn btn-default btn-xs"><i class="fa fa-line-chart"></i>Reports </a></asp:LinkButton>
                                                        <asp:LinkButton ID="LinkButton3" runat="server"><a href="EditEvent.aspx?EventID={{ev.EventID}}" class="btn btn-info btn-xs"><i class="fa fa-pencil"></i>Edit </a></asp:LinkButton>
                                                        <asp:LinkButton ID="LinkButton4" runat="server"><a href="EventList.aspx?dl={{ev.EventID}}" class="btn btn-danger btn-xs"><i class="fa fa-trash-o"></i>Delete </a></asp:LinkButton>
                                                        <a href="SendSurvey.aspx?eventID={{ev.EventID}}" class="btn btn-danger btn-xs"><i class="fa fa-folder"></i>Send Survey </a>
                                                        <%--<asp:LinkButton ID="LinkButton5" runat="server"><a href="EventSurvey.aspx?eventID={{ev.EventID}}" class="btn btn-danger btn-xs"><i class="fa fa-folder"></i>Send Survey </a></asp:LinkButton>--%>
                                                    </td>
                                                </tr>
                                               
                                            </tbody>
                                        </table>
                                        <!-- end project list -->
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
