﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Eventrix.Master" AutoEventWireup="true" CodeBehind="GuestEventList.aspx.cs" Inherits="Prototype_TNT_Der1.GuestEventList" %>
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
                        <h1>Events</h1>
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
    <div class="container" ng-app="EventList_App" ng-controller="cntrl_GuestList">
        <div class="content-wrapper">
            <div class="inner-content">
                <div class="sidebar-wrapper">
                    <aside class="widget widget_search">
                        <form role="search" method="get" class="search-form" action="getPost">
                            <label class="sr-only">Search for:</label>
                            <input type="search" class="form-control" placeholder="Search Event by Name, City or Province"/ ng-model="searchEvent" />

                            <%--<input type="search" class="form-control" placeholder="Search" value="" name="s" title="Search for:">
                            <button type="submit" class="search-submit" value=""><i class="fa fa-search"></i></button>--%>
                        </form>
                    </aside>
                </div>
                <br />
                <div class="row">
                    <div id="grid" runat="server">
                        <div class="portfolio-item col-sm-6 col-md-4" data-groups='["all", "numbers", "blue", "square"]' ng-repeat="ev in EventDetails | filter:searchEvent">
                            <div class="single-portfolio">
                                <img src="{{ev.ImageLocation}}" alt="" style="width: 317px; height: 190px" />
                                <div class="portfolio-links" style="width: 200px; margin-left: -120px;">
                                    <li class="fa fa-link">
                                        <a href="#" style="font-size: 18px; font-family: 'Roboto', sans-serif; color: white;">
                                            <p>{{ev.Name}}</p>
                                            <p>{{ev.sDate}} </p>
                                            <p>{{ev.eDate}}</p>
                                        </a>
                                    </li>
                                    <a class="image-link" href="{{ev.ImageLocation}}"><i class="fa fa-search-plus"></i></a>
                                    <a href="EventDetails.aspx?ev={{ev.EventID}}"><i class="fa fa-link"></i></a>
                                </div>
                                <!-- /.links -->
                            </div>
                            <!-- /.single-portfolio -->
                        </div>
                        <!-- /.portfolio-item -->

                        <%-- <div class="portfolio-item col-sm-6 col-md-4" data-groups='["all", "numbers", "green", "square"]'>
					                	<div class="single-portfolio">
							                <img src="img/work/portfolio-2.jpg" alt="">
											<div class="portfolio-links">
							                    <a class="image-link" href="img/work/portfolio-2.jpg"><i class="fa fa-search-plus"></i></a>
							                    <a href="EventDetails.aspx"><i class="fa fa-link"></i></a>
											<li class="fa fa-link">
											 <a href="#" style=" font-size: 18px;
											    font-family: 'Roboto', sans-serif;
											    color: white;">
											  <p>Name</p>
											  <p>Time</p>
											  <p>Date</p>
											  <p>Location</p></a>
											</li>
											</div><!-- /.links -->
						                </div><!-- /.single-portfolio -->
					                </div><!-- /.portfolio-item -->

					                <div class="portfolio-item col-sm-6 col-md-4" data-groups='["all", "letters", "blue", "square"]'>
					                	<div class="single-portfolio">
						                  	<img src="img/work/portfolio-3.jpg" alt="">
											<div class="portfolio-links">
					                        	<a class="image-link" href="img/work/portfolio-3.jpg"><i class="fa fa-search-plus"></i></a>
					                        	<a href="portfolio-single.html"><i class="fa fa-link"></i></a>
						                   </div><!-- /.links -->
					                    </div><!-- /.single-portfolio -->
					                </div><!-- /.portfolio-item -->

					                <div class="portfolio-item col-sm-6 col-md-4" data-groups='["all", "numbers", "red", "square"]'>
					                	<div class="single-portfolio">
						                	<img src="img/work/portfolio-4.jpg" alt="">
											<div class="portfolio-links">
					                        	<a class="image-link" href="img/work/portfolio-4.jpg"><i class="fa fa-search-plus"></i></a>
					                        	<a href="EventDetails.aspx"><i class="fa fa-link"></i></a>
							                </div><!-- /.links -->
					                  	</div><!-- /.single-portfolio -->
					                </div><!-- /.portfolio-item -->

					                <div class="portfolio-item col-sm-6 col-md-4" data-groups='["all", "numbers", "red", "circle"]'>
					                	<div class="single-portfolio">
						                  <img src="img/work/portfolio-5.jpg" alt="">
											<div class="portfolio-links">
					                        	<a class="image-link" href="img/work/portfolio-5.jpg"><i class="fa fa-search-plus"></i></a>
					                        	<a href="EventDetails.aspx"><i class="fa fa-link"></i></a>
							                </div><!-- /.links -->
					                  	</div><!-- /.single-portfolio -->
					                </div><!-- /.portfolio-item -->

					                <div class="portfolio-item col-sm-6 col-md-4" data-groups='["all", "numbers", "red", "square"]'>
					                	<div class="single-portfolio">
						                  	<img src="img/work/portfolio-6.jpg" alt="">
											<div class="portfolio-links">
						                        <a class="image-link" href="img/work/portfolio-6.jpg"><i class="fa fa-search-plus"></i></a>
						                        <a href="EventDetails.aspx"><i class="fa fa-link"></i></a>
						                   	</div><!-- /.links -->
					                  	</div><!-- /.single-portfolio -->
					                </div><!-- /.portfolio-item -->

					                <div class="portfolio-item col-sm-6 col-md-4" data-groups='["all", "numbers", "green", "circle"]'>
					                	<div class="single-portfolio">
						                  	<img src="img/work/portfolio-7.jpg" alt="">
											<div class="portfolio-links">
						                        <a class="image-link" href="img/work/portfolio-7.jpg"><i class="fa fa-search-plus"></i></a>
						                        <a href="EventDetails.aspx"><i class="fa fa-link"></i></a>
						                    </div><!-- /.links -->
					                  </div><!-- /.single-portfolio -->
					                </div><!-- /.portfolio-item -->

					                <div class="portfolio-item col-sm-6 col-md-4" data-groups='["all", "letters", "red", "square"]'>
					                	<div class="single-portfolio">
					                    	<img src="img/work/portfolio-8.jpg" alt="">
											<div class="portfolio-links">
						                        <a class="image-link" href="img/work/portfolio-8.jpg"><i class="fa fa-search-plus"></i></a>
						                        <a href="EventDetails.aspx"><i class="fa fa-link"></i></a>
						                    </div><!-- /.links -->
				                    	</div><!-- /.single-portfolio -->
					                </div><!-- /.portfolio-item -->

					                <div class="portfolio-item col-sm-6 col-md-4" data-groups='["all", "numbers", "green", "square"]'>
					                	<div class="single-portfolio">
						                    <img src="img/work/portfolio-9.jpg" alt="">
											<div class="portfolio-links">
						                        <a class="image-link" href="img/work/portfolio-9.jpg"><i class="fa fa-search-plus"></i></a>
						                        <a href="portfolio-single.html"><i class="fa fa-link"></i></a>
						                    </div><!-- /.links -->
					                  </div><!-- /.single-portfolio -->
					                </div><!-- /.portfolio-item -->

					                <div class="portfolio-item col-sm-6 col-md-4" data-groups='["all", "letters", "green", "circle"]'>
					                	<div class="single-portfolio">
							                <img src="img/work/portfolio-10.jpg" alt="">
											<div class="portfolio-links">
					                        	<a class="image-link" href="img/work/portfolio-10.jpg"><i class="fa fa-search-plus"></i></a>
					                        	<a href="portfolio-single.html"><i class="fa fa-link"></i></a>
							                </div><!-- /.links -->
					                    </div><!-- /.single-portfolio -->
					                </div><!-- /.portfolio-item -->

					                <div class="portfolio-item col-sm-6 col-md-4" data-groups='["all", "numbers", "blue", "square"]'>
					                	<div class="single-portfolio">
							                <img src="img/work/portfolio-11.jpg" alt="">
											<div class="portfolio-links">
						                     	<a class="image-link" href="img/work/portfolio-11.jpg"><i class="fa fa-search-plus"></i></a>
						                    	<a href="portfolio-single.html"><i class="fa fa-link"></i></a>
							                </div><!-- /.links -->
					                    </div><!-- /.single-portfolio -->
					                </div><!-- /.portfolio-item -->

					                <div class="portfolio-item col-sm-6 col-md-4" data-groups='["all", "letters", "red", "square"]'>
					                	<div class="single-portfolio">
						                    <img src="img/work/portfolio-12.jpg" alt="">
											<div class="portfolio-links">
						                        <a class="image-link" href="img/work/portfolio-12.jpg"><i class="fa fa-search-plus"></i></a>
						                        <a href="portfolio-single.html"><i class="fa fa-link"></i></a>
						                    </div><!-- /.links -->
					                  </div><!-- /.single-portfolio -->
					                </div><!-- /.portfolio-item -->--%>
                    </div>
                    <!-- /#grid -->
                </div>
                <!-- /.row -->
            </div>
            <!-- /.inner-content -->
        </div>
        <!-- /.content-wrapper -->
    </div>
    <!-- /.container -->

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
    <script src="scripts/js/jquery.shuffle.min.js"></script>
    <!-- Custom Script -->
    <script src="scripts/js/scripts.js"></script>
</asp:Content>
