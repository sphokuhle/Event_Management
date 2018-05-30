<%@ Page Title="" Language="C#" MasterPageFile="~/Eventrix.Master" AutoEventWireup="true" CodeBehind="EventList.aspx.cs" Inherits="Prototype_TNT_Der1.EventList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <section class="page-header-wrapper">
        <div class="container">
            <div class="row">
                <div class="col-md-12">
                    <div class="page-header">
                        <%--<h1>Events</h1>--%>
                    </div>
                    <ol class="breadcrumb">
                        <li><a href="Index.aspx">Home</a></li>
                        <li><a href="#">Events</a></li>
                        <li class="active">All Events</li>
                    </ol>
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
                    <div class="col-xs-12 col-md-9 col-sm-8">
                            <header class="entry-header">
                                <h2 class="entry-title">Upcoming Events</h2>
                            </header>
                    </div>
                    <div class="col-xs-12 col-md-3 col-sm-4">
                        <div class="sidebar-wrapper">
                            <aside class="widget widget_search">
                                <form role="search" method="get" class="search-form" action="getpost">
                                    <label class="sr-only">Search for:</label>
                                    <input type="search" class="form-control" placeholder="Search"/ng-model="searchEvent"/>
                                </form>
                            </aside>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div runat="server" id="grid">

                    </div>
                    <!-- /#grid -->
                </div><!-- /.row -->
            </div>
            <!-- /.inner-content -->
        </div>
        <!-- /.content-wrapper -->
    </div>
    <!-- /.container -->

</asp:Content>
