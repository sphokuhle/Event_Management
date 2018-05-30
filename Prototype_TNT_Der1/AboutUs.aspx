<%@ Page Title="" Language="C#" MasterPageFile="~/Eventrix.Master" AutoEventWireup="true" CodeBehind="AboutUs.aspx.cs" Inherits="Prototype_TNT_Der1.AboutUs" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <section class="page-header-wrapper">
        <div class="container">
            <div class="row">
                <div class="col-md-12">
                    <div class="page-header">
                        <h1>About Us</h1>
                    </div>
                    <ol class="breadcrumb">
                        <li><a href="#">Home</a></li>
                        <li class="active">About Us</li>
                    </ol>
                </div>
            </div>
            <!-- /.row -->
        </div>
        <!-- /.container-fluid -->
    </section>

    <div class="container">
        <div class="content-wrapper">
            <section class="about-us-wrapper">
                <h2>Our Story</h2>
                <div class="row margin-bottom-60">
                    <div class="col-md-6">
                        <p>Event planning requires strategic planning, professionalism, creativity embedded with uniqueness, as well as meeting the need as required that will leave a pleasing mark on the event host thus encouraging repeated bookings. Duties such as handling guest invites, seat reservations, event layout and so forth have to be properly scrutinised.</p>
                        <p>Event check-in system will allow users to create an account on our event management website. Here it is where they will be able to create an event. When creating an event however, the client (Event Host) will provide short event description such as date, location and the number of guest as well as details of expected guest. Therefore our event management website will send invitations to the expected guests, thereby providing the guests with an option to RSVP and receive QR code if they will attend. The QR code will not only be for access control but will also serve as a token where different guest with different privileges (VIP, VVIP, Regular access) will get specific credits such as purchasing food and beverages using the unique QR code.</p>
                    </div>
                    <!-- /.col-md-6 -->

                    <div class="col-md-6">
                        <p>
                            <b>eventriX </b>is an event management system providing a solution that enables you manage invites, access control and procurement with efficiency and cost saving.
                                        <ul>
                                            <li><b>Email:</b> you can send customized invitation emails to your guests the key dates and times.</li>
                                            <li><b>Check-in and Access control:</b> check-in your guests and control thier access to your event.</li>
                                            <li><b>QR Code:</b> guests can use their QR code to gain acces to the event and purchase product sold within the event</li>
                                            <li><b>Real time statistics:</b> you always have to access to accurate statistics about your event.</li>
                                        </ul>
                        </p>
                    </div>
                    <!-- /.col-md-6 -->
                </div>
                <!-- /.row -->

                <h2>Our Team</h2>
            </section>
            <!-- /.about-us-wrapper -->

            <section class="about-us-slider-wrapper">
                <div id="about-us-slider" class="carousel slide" data-ride="carousel">
                    <!-- Wrapper for slides -->
                    <div class="carousel-inner" role="listbox">
                        <div class="item">
                            <div class="row">
                                <div class="col-md-6">
                                    <img class="img-responsive" src="img/developer/SK.jpg" alt="" />
                                </div>
                                <div class="col-md-6">
                                    <div class="abt-slider-intro">
                                        <h3>S'phokuhle Mkhwanazi (Full-Stack Web Developer)</h3>
                                        <p>
                                            Qualification in BSc Information Technology. Hard Working, self-motivated 
                                                    individual who is a team player. Willing and able to work under pressure and proactively 
                                                    share ideas on improving business and logical processes within the scope of the project.
                                        </p>

                                        <p>Languages familiar with are C#, C++, JAVASCRIPT, JAVA and CSS. Favourite IDE is Visual Studio.</p>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <!-- /.item -->

                    </div>
                    <!-- /.carousel-inner -->

                    <!-- Controls -->
                    <a class="left carousel-control" href="#about-us-slider" role="button" data-slide="prev">
                        <i class="flaticon-arrowhead4"></i>
                        <span class="sr-only">Previous</span>
                    </a>
                    <a class="right carousel-control" href="#about-us-slider" role="button" data-slide="next">
                        <i class="flaticon-arrow437"></i>
                        <span class="sr-only">Next</span>
                    </a>
                </div>
            </section>
        </div>
        <!-- /.content-wrapper -->
    </div>
    <!-- /.container -->

</asp:Content>
