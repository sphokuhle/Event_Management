﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Eventrix.Master" AutoEventWireup="true" CodeBehind="Filter.aspx.cs" Inherits="Prototype_TNT_Der1.Filter" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
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
    		<!-- Loading main css file -->
		<link href="css/StyleSheet1.css" rel="stylesheet" />

        <main class="main-content">
				<div class="fullwidth-block gallery">
					<div class="container">
						<div class="content fullwidth">
							<h2 class="entry-title">Gallery</h2>
							<div class="filter-links filterable-nav">
								<select class="mobile-filter">
									<option value="*">Show all</option>
									<option value=".concert">Concert</option>
									<option value=".band">Band</option>
									<option value=".stuff">Stuff</option>
								</select>
								<a href="#" class="current" data-filter="*">Show all</a>
								<a href="#" data-filter=".concert">Concert</a>
								<a href="#" data-filter=".band">Band</a>
								<a href="#" data-filter=".stuff">Stuff</a>
							</div>
							<div class="filterable-items">
								<div class="filterable-item concert">
									<a href="dummy/large-gallery/gallery-1.jpg"><figure><img src="dummy/gallery-1.jpg" alt="gallery 1"></figure></a>
								</div>
								<div class="filterable-item concert">
									<a href="dummy/large-gallery/gallery-2.jpg"><figure><img src="dummy/gallery-2.jpg" alt="gallery 2"></figure></a>
								</div>
								<div class="filterable-item stuff">
									<a href="dummy/large-gallery/gallery-3.jpg"><figure><img src="dummy/gallery-3.jpg" alt="gallery 3"></figure></a>
								</div>
								<div class="filterable-item concert">
									<a href="dummy/large-gallery/gallery-4.jpg"><figure><img src="dummy/gallery-4.jpg" alt="gallery 4"></figure></a>
								</div>
								<div class="filterable-item band">
									<a href="dummy/large-gallery/gallery-5.jpg"><figure><img src="dummy/gallery-5.jpg" alt="gallery 5"></figure></a>
								</div>
								<div class="filterable-item stuff">
									<a href="dummy/large-gallery/gallery-6.jpg"><figure><img src="dummy/gallery-6.jpg" alt="gallery 6"></figure></a>
								</div>
								<div class="filterable-item concert">
									<a href="dummy/large-gallery/gallery-7.jpg"><figure><img src="dummy/gallery-7.jpg" alt="gallery 7"></figure></a>
								</div>
								<div class="filterable-item band">
									<a href="dummy/large-gallery/gallery-8.jpg"><figure><img src="dummy/gallery-8.jpg" alt="gallery 8"></figure></a>
								</div>
								<div class="filterable-item band">
									<a href="dummy/large-gallery/gallery-9.jpg"><figure><img src="dummy/gallery-9.jpg" alt="gallery 9"></figure></a>
								</div>
								<div class="filterable-item stuff">
									<a href="dummy/large-gallery/gallery-10.jpg"><figure><img src="dummy/gallery-10.jpg" alt="gallery 10"></figure></a>
								</div>
								<div class="filterable-item band">
									<a href="dummy/large-gallery/gallery-11.jpg"><figure><img src="dummy/gallery-11.jpg" alt="gallery 11"></figure></a>
								</div>
								<div class="filterable-item stuff">
									<a href="dummy/large-gallery/gallery-12.jpg"><figure><img src="dummy/gallery-12.jpg" alt="gallery 12"></figure></a>
								</div>
							</div>
						</div>
					</div>
				</div> <!-- .testimonial-section -->

				
			</main> <!-- .main-content -->

    <script src="scripts/js/js/plugins.js"></script>
    <script src="scripts/js/js/jquery-1.11.1.min.js"></script>
    <script src="scripts/js/js/app.js"></script>
</asp:Content>
