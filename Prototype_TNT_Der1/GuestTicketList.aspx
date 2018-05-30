<%@ Page Title="" Language="C#" MasterPageFile="~/Eventrix.Master" AutoEventWireup="true" CodeBehind="GuestTicketList.aspx.cs" Inherits="Prototype_TNT_Der1.GuestTicketList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="st-container" class="st-container">
        <div class="st-pusher">
            <div class="st-content">
                <div class="st-content-inner">
                    <section class="page-header-wrapper">
                        <div class="container">
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="page-header">
                                        <h1>Load Credit</h1>
                                    </div>
                                    <ol class="breadcrumb">
                                        <li><a href="#">Home</a></li>
                                        <li><a href="#">Pages</a></li>
                                        <li class="active">Our Clients</li>
                                    </ol>
                                </div>
                            </div>
                            <!-- /.row -->
                        </div>
                        <!-- /.container-fluid -->
                    </section>

                    <script src="scripts/AAF/angular.min.js"></script>
                    <%--<script src="scripts/TicketList.js"></script>--%>
                    <script src="scripts/GuestTicketList.js"></script>
                    <div class="container" ng-app="GuestEventList_App" ng-controller="cntrl_GuestEventList">
                        <div class="content-wrapper">
                            <div class="our-clients-wrapper" runat="server" id="EventDiv">
                                <div class="media" ng-repeat="ev in EventDetails">
                                    <div class="media-left" id="imageDiv">
                                        <a href="EventDetails.aspx?EventID={{ev.EventID}}" ng-model="Images">
                                            <img class="media-object" src="{{ev.ImageLocation}}" alt="" style="height: 400px; width: 400px;" />
                                        </a>
                                    </div>
                                    <div class="media-body">
                                        <h2 class="media-heading">{{ev.Name}}</h2>
                                        <span>{{ev.sDate}} till, {{ev.eDate}}</span>
                                        <br />
                                        <div class="typography-page-tab" role="tabpanel">
                                            <!-- Nav tabs -->
                                            <ul class="nav nav-tabs" role="tablist">
                                                <li role="presentation" ng-repeat="ticket in ev.eventTicket"><a href="#{{ticket._Type}}{{ev.EventID}}" aria-controls="{{ticket._Type}}{{ev.EventID}}" role="tab" data-toggle="tab">{{ticket._Type}}</a></li>
                                                <li role="presentation" class="active"><a href="#" aria-controls="" role="tab" data-toggle="tab">...</a></li>
                                                <%--<li role="presentation"><a href="#profile" aria-controls="profile" role="tab" data-toggle="tab">{{tick._Type}}</a></li>
                                            <li role="presentation"><a href="#profile" aria-controls="profile" role="tab" data-toggle="tab">{{tick._Type}}</a></li>
					                        <li role="presentation"><a href="#messages" aria-controls="messages" role="tab" data-toggle="tab">{{tick._Type}}</a></li>--%>
                                            </ul>
                                            <!-- Tab panes -->
                                            <div class="tab">
                                                <div role="tabpanel" class="tab-pane fade in active" id="{{ticket._Type}}{{ev.EventID}}" ng-repeat="ticket in ev.eventTicket">
                                                    <span>Number of Ticket Credit: {{ticket._Credit}}</span> Update To:
                                                    <input runat="server" id="txtNewCredit" type="number" />
                                                    <p>Ticket Price: {{ticket._Price}}</p>
                                                    <%--<asp:TextBox ID="txt_Ticket_ID" runat="server" Visible="False">{{ticket._TicketID}}</asp:TextBox>--%>
                                                    <input runat="server" id="txt_Ticket_ID" type="text" ng-model="ticket._TicketID" hidden="hidden" />
                                                    <p>Number of Ticket: {{ticket.numTicket}}</p>
                                                    <p>Refund Policy: {{ticket._Refund}}</p>
                                                    <asp:Button ID="btnUpdateCredit" class='btn btn-primary animated bounceIn' Style="padding: 12px 110px 12px 15px;" runat="server" Text="Submit Changes" OnClick="btnUpdateCredit_Click" />
                                                </div>
                                                <%--					                    <div role="tabpanel" class="tab-pane fade" id="profile">
					                      <p>Food truck fixie locavore, accusamus mcsweeney's marfa nulla single-origin coffee squid. Exercitation labore velit, blog sartorial leggings next level wes anderson artisan four loko farm-to-table craft beer culpa terry richardson biodiesel</p>
					                    </div>
                                           <div role="tabpanel" class="tab-pane fade" id="profile">
					                      <p>Food truck fixie locavore, accusamus mcsweeney's marfa nulla single-origin coffee squid. Exercitation labore velit, blog sartorial leggings next level wes anderson artisan four loko farm-to-table craft beer culpa terry richardson biodiesel</p>
					                    </div>
					                    <div role="tabpanel" class="tab-pane fade" id="messages">
					                      <p>Qui photo booth letterpress, commodo enim craft beer mlkshk aliquip jean shorts ullamco ad vinyl cillum. Homo nostrud organic, assumenda labore ethical culpa terry richardson biodiesel ethical culpa terry richardson biodiesel.</p>
					                    </div>--%>
                                            </div>
                                        </div>
                                    </div>
                                </div>

                                <%--							<div class="media">
							  <div class="media-left">
							    <a href="#">
							      <img class="media-object" src="img/partner/partner-logo-6.png" alt="">
							    </a>
							  </div>
							  <div class="media-body">
							    <h2 class="media-heading">Brooklyn Youth</h2>
							    <span>Sports Club</span>
								<p>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Consectetuer adipiscing elit, sed diam nonummy nibh euismod tincidunt ut laoreet dolore magna aliquam erat volutpat. Ut wisi enim ad minim veniam diam nonummy nibh euismod tincidunt ut laoreet dolore magna aliquam erat volutpat. Ut wisi enim ad minim veniam.</p>
								<p>website : <a href="#">www.themehippo.com</a></p>
							  </div>
							</div>--%>

                                <%--		<div class="media">
							  <div class="media-left">
							    <a href="#">
							      <img class="media-object" src="img/partner/partner-logo-2.png" alt="">
							    </a>
							  </div>
							  <div class="media-body">
							    <h2 class="media-heading">Igor</h2>
							    <span>Hair Studio</span>
								<p>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Consectetuer adipiscing elit, sed diam nonummy nibh euismod tincidunt ut laoreet dolore magna aliquam erat volutpat. Ut wisi enim ad minim veniam diam nonummy nibh euismod tincidunt ut laoreet dolore magna aliquam erat volutpat. Ut wisi enim ad minim veniam.</p>
								<p>website : <a href="#">www.themehippo.com</a></p>
							  </div>
							</div>--%>

                                <%--		<div class="media">
							  <div class="media-left">
							    <a href="#">
							      <img class="media-object" src="img/partner/partner-logo-3.png" alt="">
							    </a>
							  </div>
							  <div class="media-body">
							    <h2 class="media-heading">Stillness</h2>
							    <span>Fishing Firm</span>
								<p>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Consectetuer adipiscing elit, sed diam nonummy nibh euismod tincidunt ut laoreet dolore magna aliquam erat volutpat. Ut wisi enim ad minim veniam diam nonummy nibh euismod tincidunt ut laoreet dolore magna aliquam erat volutpat. Ut wisi enim ad minim veniam.</p>
								<p>website : <a href="#">www.themehippo.com</a></p>
							  </div>
							</div>--%>
                            </div>
                            <!-- /.our-clients-wrapper -->
                        </div>
                        <!-- /.content-wrapper -->
                    </div>
                    <!-- /.container -->
                </div>
                <!-- .st-content-inner -->
            </div>
            <!-- .st-content -->
        </div>
        <!-- .st-pusher -->
    </div><!-- /st-container -->
</asp:Content>
