<%@ Page Title="" Language="C#" MasterPageFile="~/Eventrix.Master" AutoEventWireup="true" CodeBehind="AllEventList.aspx.cs" Inherits="Prototype_TNT_Der1.AllEventList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <script src="scripts/AAF/angular.min.js"></script>
    <script src="scripts/EventList.js"></script>
    <script src="scripts/js/scripts.js"></script>
    <script src="scripts/js/jquery.shuffle.min.js"></script>

    
    <link href="css/Events.css" rel="stylesheet" />

    <section class="page-header-wrapper">
        <div class="container">
            <div class="row">
                <div class="col-md-12">
                    <div class="page-header">
                        <h1>All Events</h1>
                    </div>
                    <ol class="breadcrumb">
                        <li><a href="#">Home</a></li>
                        <li class="active">All Events</li>
                    </ol>
                </div>
            </div>
            <!-- /.row -->
        </div>
        <!-- /.container-fluid -->
    </section>

    <div class="container" ng-app="EventList_App" ng-controller="cntrl_EventList">
        <div class="content-wrapper">
            <div class="inner-content">
                   <div class="row">
                    <div class="col-xs-12 col-sm-12 col-md-6">
                        
		        <!-- Blog end -->
                    </div>
                    <div class="col-xs-12 col-md-6 col-sm-4">
                        <div class="sidebar-wrapper">
                       <div class="col-md-4">
                                 <form role="search" method="get" class="search-form">
                                    <label class="sr-only">Search for:</label>
                                    <input type="search" class="form-control" ng-model="searchEvent" placeholder="General" value=""  name="s" title="Search for:" />
                                </form>
                            </div>
                            <div class="col-md-4">
                                 <form role="search" method="get" class="search-form">
                                    <label class="sr-only">City or Location</label>
                                    <input type="search" class="form-control" placeholder="Location" ng-model="searchEvent.City" value="" name="s" title="City,Province or Street" />
                                </form>
                            </div>
                            <div class="col-md-4">
                                 <form role="search" method="get" class="search-form">
                                    <label class="sr-only">Date</label>
                                    <input type="search" class="form-control" placeholder="Date" ng-model="searchEvent.sDate" value="" name="s" title="Date" />
                                </form>
                            </div>
                        </div>
                    </div>
                </div>
                <br />
                <div class="row">
                <section id="blog" class="blog-section section-padding">
                            <div class="row content-row">
                                <div class="col-sm-6 col-md-4" ng-repeat="ev in EventDetails | filter:searchEvent">
                                    <section class="blog-post-wrapper">
                                        <header class="entry-header">
                                            <div class="entry-meta">
                                                <span class="the-time">{{ev.sDate}}</span>
                                            </div>
                                            <div class="entry-meta">
                                                <span class="the-time">{{ev.Street}}, {{ev.City}}</span>
                                            </div>
                                            <!-- /.entry-meta -->
                                            <h2 class="entry-title"><a href="EventDetails.aspx?ev={{ev.EventID}}">{{ev.Name}}</a></h2>
                                        </header>
                                        <!-- /.entry-header -->

                                        <div class="post-thumbnail">
                                            <img src="{{ev.ImageLocation}}" class="img-responsive" style="height:165px;" alt=""/>

                                            <div class="entry-footer clearfix">
                                                <a class="readmore pull-right" href="EventDetails.aspx?ev={{ev.EventID}}"><i class="fa fa-plus"></i></a>
                                            </div>
                                            <!-- /.entry-footer -->
                                        </div>
                                        <!-- /.post-thumbnail -->
                                    </section>
                                </div>
                            </div>
                            <!-- /.row -->
                          
                        </section>
                </div>
                <!-- /.row -->
            </div>
            <!-- /.inner-content -->
        </div>
        <!-- /.content-wrapper -->
    </div><!-- /.container -->

    	    <!-- jQuery -->
	    <script src="scripts/js/jquery.js"></script>
	    <!-- Bootstrap Core JavaScript -->
	    <script src="scripts/js/bootstrap.min.js"></script>
	    <!-- wow.min.js -->
	    <script src="scripts/js/wow.min.js"></script>
		<!-- jQuery REVOLUTION Slider  -->
		<script type="text/javascript" src="rs-plugin/js/jquery.themepunch.tools.min.js"></script>
		<script type="text/javascript" src="rs-plugin/js/jquery.themepunch.revolution.min.js"></script>
		<!-- owl-carousel -->
	    <script src="scripts/owl-carousel/owl.carousel.min.js"></script>
	    <!-- smoothscroll -->
	    <script src="scripts/js/smoothscroll.js"></script>
		<!-- Offcanvas Menu -->
		<script src="scripts/js/hippo-offcanvas.js"></script>
		<!-- easypiechart -->
		<script src="scripts/js/jquery.easypiechart.min.js"></script>
	    <!-- Scrolling Nav JavaScript -->
	    <script src="scripts/js/jquery.easing.min.js"></script>
		<!-- Magnific-popup -->
		<script src="scripts/js/jquery.magnific-popup.min.js"></script>
		<!-- Shuffle.min js -->

</asp:Content>
