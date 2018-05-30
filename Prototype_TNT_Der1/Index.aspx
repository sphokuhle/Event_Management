<%@ Page Title="" Language="C#" MasterPageFile="~/Eventrix.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="Prototype_TNT_Der1.Index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     
    <script src="scripts/angular.js"></script>
    <script src="scripts/HomeList.js"></script>
    <link href="css/Events.css" rel="stylesheet" />
    <div id="x-corp-carousel" class="carousel slide hero-slide" data-ride="carousel">
        <!-- Indicators -->
        <ol class="carousel-indicators">
            <li data-target="#x-corp-carousel" data-slide-to="0" class="active"></li>
            <li data-target="#x-corp-carousel" data-slide-to="1"></li>
        </ol>

        <!-- Wrapper for slides -->
        <div class="carousel-inner" role="listbox" runat="server" id="homeSlider">
            

        </div>
        <!--.carousel-inner-->

        <!-- Controls -->
        <a class="left carousel-control" href="#x-corp-carousel" role="button" data-slide="prev">
            <i class="fa fa-angle-left" aria-hidden="true"></i>
            <span class="sr-only">Previous</span>
        </a>
        <a class="right carousel-control" href="#x-corp-carousel" role="button" data-slide="next">
            <i class="fa fa-angle-right" aria-hidden="true"></i>
            <span class="sr-only">Next</span>
        </a>
    </div>
    <!-- #x-corp-carousel-->

      <div class="container" ng-app="HomeEventList_App">
        <div class="content-wrapper" ng-controller="cntrl_IndexList">
            <div class="inner-content">
                <div class="row">
                    <div class="col-xs-12 col-sm-12 col-md-6">
                        <header class="entry-header">
                            <h2 class="entry-title" runat="server" id="homeTitle"></h2>
                        </header>
                        <br/>
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
                            <div class="more-post text-center" runat="server" id="MoreEvents">
                                <%--<a href="blog.html" class="btn btn-primary btn-lg">More Events</a>--%>
                            </div>
                        </section>
                </div>
                <!-- /.row -->
            </div>
            <!-- /.inner-content -->
        </div>
        <!-- /.content-wrapper -->

    </div>

</asp:Content>
