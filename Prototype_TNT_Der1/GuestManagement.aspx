<%@ Page Title="" Language="C#" MasterPageFile="~/Eventrix.Master" AutoEventWireup="true" CodeBehind="GuestManagement.aspx.cs" Inherits="Prototype_TNT_Der1.GuestManagement" %>
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
                        <li  class="active">Event Management</li>
                    </ol>
                </div>
            </div>
            <!-- /.row -->
        </div>
        <!-- /.container-->
    </section>


    <div class="container" ng-app="EventList_App" ng-controller="cntrl_GuestList">
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
                                                    <th style="width: 1%"> </th>
                                                    <th style="width: 20%">Event Name</th>
                                                    <th></th>
                                                    <th>Event Image</th>
                                                    <th></th>
                                                    <th >Manage</th>
                                                </tr>
                                            </thead>
                                            <tbody>
                                                <tr ng-repeat="ev in EventDetails">
                                                    <td> </td>
                                                    <td>
                                                        <h4>{{ev.Name}}</h4>
                                                        <br />
                                                        <small>{{ev.sDate}} to {{ev.eDate}}</small>
                                                    </td>
                                                    <td></td>
                                                    <td style="width:230px; height:100px;">
                                                        <img src="{{ev.ImageLocation}}" style="width: 150px; height: 100px;" />
                                                    </td>
                                                    <td></td>
                                                    <td style="padding-top:40px;">
                                                        <asp:LinkButton ID="LinkButton1" runat="server"><a href="EventDetails.aspx?EventID={{ev.EventID}}" class="btn btn-primary btn-xs"><i class="fa fa-folder"></i>View </a></asp:LinkButton>
                                                        <label runat="server" id="loadTicket"></label>
                                                        <asp:LinkButton ID="LinkButton3" runat="server"><a href="DeleteTicket.aspx?EventID={{ev.EventID}}" class="btn btn-info btn-xs"><i class="fa fa-trash-o"></i>Cancel Event </a></asp:LinkButton>
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
