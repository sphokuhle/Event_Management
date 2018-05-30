<%@ Page Title="" Language="C#" MasterPageFile="~/Eventrix.Master" AutoEventWireup="true" CodeBehind="EditEvent.aspx.cs" Inherits="Prototype_TNT_Der1.EditEvent" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     <script type="text/javascript" src="http://maps.googleapis.com/maps/api/js?key=AIzaSyAI5uzweLamk9Tsnk01MwXpY4APBAfmbpw&sensor=false&libraries=places"></script>
    <script type="text/javascript">
        google.maps.event.addDomListener(window, 'load', function () {
            var places = new google.maps.places.Autocomplete(document.getElementById('txtPlaces'));
            google.maps.event.addListener(places, 'place_changed', function () {
                var place = places.getPlace();
                var address = place.formatted_address;
                var latitude = place.geometry.location.lat();
                var longitude = place.geometry.location.lng();
                //    document.getElementById("TextBox1").innerHTML = place;
                document.getElementById("TextBox2").innerHTML = address;
                document.getElementById("TextBox3").innerHTML = latitude;
                document.getElementById("TextBox4").innerHTML = longitude;
                var mesg = "Address: " + address;
                mesg += "\nLatitude: " + latitude;
                mesg += "\nLongitude: " + longitude;
                alert(mesg);
            });
        });
    </script>
    <%--    <link rel="stylesheet" href="css/event-management.css" />--%>
    <link href="css/event.css" rel="stylesheet" />
    <link href="css/Validation.css" rel="stylesheet" />
    <link href="css/ModalsProgress.css" rel="stylesheet" />
    <script src="scripts/js/Validation.js"></script>

    <section class="page-header-wrapper">
        <div class="container">
            <div class="row">
                <div class="col-md-12">
                    <div class="page-header">
                        <h1 runat="server" id="divHearderName"></h1>
                    </div>
                </div>
            </div><!-- /.row -->
        </div><!-- /.container-fluid -->
    </section>

    <div class="container">
        <div class="event-wrapper">
            <div class="event-wrap">
                <div class="event-html" style="width: 185%;">
                    <input id="tab-1" type="radio" name="tab" class="event-detail" checked /><label for="tab-1" class="tab">Event Details</label>
                    <%--                <input id="tab-2" type="radio" name="tab" class="guest-detail" /><label for="tab-2" class="tab">File Uploads</label>--%>
                    <input id="tab-2" type="radio" name="tab" class="ticket-detail" /><label for="tab-2" class="tab">Ticket Details</label>
                    <%--                <input id="tab-4" type="radio" name="tab" class="product-detail" /><label for="tab-4" class="tab">Address Details</label>--%>

                    <div class="event-form" style="align-content:center">
                        <div class="event-detail-htm">
                            <asp:Table runat="server" CssClass="group">
                                <asp:TableRow>

                                    <asp:TableHeaderCell>
                                        <br />
                                        <label for="txtEventName" class="label">Event Name</label>
                                    </asp:TableHeaderCell>
                                    <asp:TableCell>
                                        <asp:TextBox ID="txtEventName" runat="server" class="input" Height="35px" Width="280px"></asp:TextBox>
                                    </asp:TableCell>
                                    <asp:TableHeaderCell>
                                        <br />
                                        <label for="txtStreet" class="label">Street</label>
                                    </asp:TableHeaderCell>
                                    <asp:TableCell>
                                        <asp:TextBox ID="txtStreet" runat="server" class="input" Height="35px" Width="280px"></asp:TextBox>
                                    </asp:TableCell>
                                </asp:TableRow>
                                <asp:TableRow>
                                    <asp:TableHeaderCell>
                                        <br /><label for="txtCategory" class="label">Event Type</label>
                                    </asp:TableHeaderCell>
                                    <asp:TableCell>
                                        <asp:TextBox ID="txtCategory" runat="server" list="listTown" class="input" Height="35px" Width="280px"></asp:TextBox>
                                        <datalist id="listTown">
                                            <option>Conference </option>
                                            <option>Seminar </option>
                                            <option>Product Launch</option>
                                            <option>Award Ceremony </option>
                                            <option>Trade Show </option>
                                            <option>Wedding </option>
                                            <option>Family Event </option>
                                        </datalist>
                                    </asp:TableCell>

                                    <asp:TableHeaderCell>
                                        <br /><label for="txtCity" class="label">City/Town</label>
                                    </asp:TableHeaderCell>
                                    <asp:TableCell>
                                        <asp:TextBox ID="txtCity" runat="server" class="input" Height="35px" Width="280px"></asp:TextBox>
                                    </asp:TableCell>

                                </asp:TableRow>

                                <asp:TableRow>
                                    <asp:TableHeaderCell>
                                        <br /><label for="txtStart" class="label">Start Date</label>
                                    </asp:TableHeaderCell>
                                    <asp:TableCell>
                                        <asp:TextBox ID="txtStart" runat="server" class="input" Height="35px" Width="280px" TextMode="DateTime"></asp:TextBox>
                                    </asp:TableCell>

                                    <asp:TableHeaderCell>
                                        <br /><label for="txtProvince" class="label">Province</label>
                                   </asp:TableHeaderCell>
                                    <asp:TableCell>
                                        <asp:TextBox ID="txtProvince" runat="server" list="listProvince" class="input" Height="35px" Width="280px"></asp:TextBox>
                                        <datalist id="listProvince">
                                            <option>Eastern Cape </option>
                                            <option>Free State </option>
                                            <option>Gauteng</option>
                                            <option>KwaZulu-Natal </option>
                                            <option>Limpopo </option>
                                            <option>Mpumalanga </option>
                                            <option>Northern Cape </option>
                                            <option>North West </option>
                                            <option>Western Cape </option>
                                        </datalist>
                                    </asp:TableCell>

                                </asp:TableRow>

                                <asp:TableRow>
                                    <asp:TableHeaderCell>
                                        <br /><label for="txtEnd" class="label">End Date</label>
                                    </asp:TableHeaderCell>
                                    <asp:TableCell>
                                        <asp:TextBox  ID="txtEnd" runat="server" class="input" Height="35px" Width="280px" TextMode="DateTime"></asp:TextBox>
                                    </asp:TableCell>

                                    <asp:TableHeaderCell>
                                        <br /><label for="txtCountry" class="label">Country</label>
                                    </asp:TableHeaderCell>
                                    <asp:TableCell>
                                        <asp:TextBox ID="txtCountry" runat="server" class="input" Height="35px" Width="280px"></asp:TextBox>
                                    </asp:TableCell>

                                </asp:TableRow>
                            </asp:Table>

                            <asp:Table runat="server" CssClass="group">
                                <asp:TableRow>
                                    <asp:TableHeaderCell>
                                        <br /><label for="txtDesc" class="label">Description</label>
                                     </asp:TableHeaderCell>
                                    <asp:TableCell>
                                        <asp:TextBox ID="txtDesc" runat="server" class="input" TextMode="MultiLine" Rows="3" ToolTip="Enter Event Description" Columns="10" Height="60px" Width="635px"></asp:TextBox>
                                    </asp:TableCell>
                                </asp:TableRow>
                            </asp:Table>

                            <asp:Table runat="server" CssClass="group">
                                <asp:TableRow>
                                 <asp:TableHeaderCell><label for="chkBoxPrivate" class="label">Private Event</label>
                                    </asp:TableHeaderCell>
                                    <asp:TableCell>
                                        <asp:CheckBox ID="chkBoxPrivate" runat="server" />
                                    </asp:TableCell>
                                </asp:TableRow>

                                <asp:TableRow>
                                    <asp:TableHeaderCell>
                                        <br /><label for="flEventImages" class="label">Event Images</label>
                                    </asp:TableHeaderCell>
                                    <asp:TableCell>
                                        <asp:FileUpload ID="flEventImages" runat="server" class="input" Height="50px" Width="250px" />
                                    </asp:TableCell>

                                    <asp:TableHeaderCell>
                                        <br /><label for="flGuest" class="label">Upload Guest</label>
                                    </asp:TableHeaderCell>
                                    <asp:TableCell>
                                        <asp:FileUpload ID="flGuest" runat="server" class="input" Height="50px" Width="250px" />
                                    </asp:TableCell>
                                </asp:TableRow>
                            </asp:Table>

                            <asp:Table runat="server" align="center">
                                <asp:TableRow>
                                    <asp:TableHeaderCell>
                                        
                                    </asp:TableHeaderCell>
                                    <asp:TableCell>
                                        <h3 class="label">To see how to upload <a href="HowToUploadFiles.aspx" runat="server">click Here</a></h3>
                                    </asp:TableCell>
                                </asp:TableRow>
                            </asp:Table>
                        </div>

                        <div class="ticket-detail-htm">
                            <div class="group" align="center">
                                <!-- Nav tabs -->
                                <br />
                                <ul class="nav nav-tabs" role="tablist">
                                    <li role="presentation" class="active"><a href="#EarlyBird" aria-controls="EarlyBird" role="tab" data-toggle="tab">Early Bird</a></li>
                                    <li role="presentation"><a href="#VIP" aria-controls="VIP" role="tab" data-toggle="tab">VIP</a></li>
                                    <li role="presentation"><a href="#VVIP" aria-controls="VVIP" role="tab" data-toggle="tab">VVIP</a></li>
                                    <li role="presentation"><a href="#Regular" aria-controls="Regular" role="tab" data-toggle="tab">Regular</a></li>
                                </ul>
                                <!-- Tab panes -->
                                <div class="tab-content">
                                    <div role="tabpanel" class="tab-pane fade in active" id="EarlyBird">
                                        <asp:Table runat="server" CssClass="group">
                                            <asp:TableRow>
                                                <asp:TableHeaderCell>
                                            <label for="txtE_Price" class="label">Price</label>
                                                </asp:TableHeaderCell>
                                                <asp:TableCell>
                                                    <asp:TextBox ID="txtE_Price" runat="server" class="input" Height="45px" Width="350px"></asp:TextBox>
                                              <br/>
                                                      </asp:TableCell>
                                            </asp:TableRow>
                                            <asp:TableRow>
                                                <asp:TableHeaderCell>
                                            <label for="txtE_Quantity" class="label">Quantity</label>
                                                </asp:TableHeaderCell>
                                                <asp:TableCell>
                                                    <asp:TextBox TextMode="Number" ID="txtE_Quantity" runat="server" class="input" Height="45px" Width="350px"></asp:TextBox>
                                               <br/>
                                                     </asp:TableCell>
                                            </asp:TableRow>
                                            <asp:TableRow>
                                                <asp:TableHeaderCell>
                                            <label for="txtE_Token" class="label">Tokens</label>
                                                </asp:TableHeaderCell>
                                                <asp:TableCell>
                                                    <asp:TextBox TextMode="Number" ID="txtE_Token" runat="server" class="input" Height="45px" Width="350px"></asp:TextBox>
                                              <br/>
                                                     </asp:TableCell>
                                            </asp:TableRow>
                                            <asp:TableRow>
                                                <asp:TableHeaderCell>
                                            <label for="txtE_OpenDate" class="label">Open Date</label>
                                                </asp:TableHeaderCell>
                                                <asp:TableCell>
                                                    <asp:TextBox  ID="txtE_OpenDate" runat="server" class="input" Height="45px" Width="350px"></asp:TextBox>
                                              <br/>
                                                     </asp:TableCell>
                                            </asp:TableRow>
                                            <asp:TableRow>
                                                <asp:TableHeaderCell>
                                            <label for="txtE_ClosingDate" class="label">Closing Date</label>
                                                </asp:TableHeaderCell>
                                                <asp:TableCell>
                                                    <asp:TextBox type="datetime2" ID="txtE_ClosingDate" runat="server" class="input" Height="45px" Width="350px"></asp:TextBox>
                                               <br/>
                                                     </asp:TableCell>
                                            </asp:TableRow>
                                        </asp:Table>
                                    </div>

                                    <div role="tabpanel" class="tab-pane fade" id="VIP">
                                        <asp:Table runat="server" CssClass="group">
                                            <asp:TableRow>
                                                <asp:TableHeaderCell>
                                            <label for="txtV_Price" class="label">Price</label>
                                                </asp:TableHeaderCell>
                                                <asp:TableCell>
                                                    <asp:TextBox ID="txtV_Price" runat="server" class="input" Height="45px" Width="350px"></asp:TextBox>
                                               <br/>
                                                     </asp:TableCell>
                                            </asp:TableRow>
                                            <asp:TableRow>
                                                <asp:TableHeaderCell>
                                            <label for="txtV_Quantity" class="label">Quantity</label>
                                                </asp:TableHeaderCell>
                                                <asp:TableCell>
                                                    <asp:TextBox TextMode="Number" ID="txtV_Quantity" runat="server" class="input" Height="45px" Width="350px"></asp:TextBox>
                                              <br/>
                                                      </asp:TableCell>
                                            </asp:TableRow>
                                            <asp:TableRow>
                                                <asp:TableHeaderCell>
                                            <label for="txtV_Token" class="label">Tokens</label>
                                                </asp:TableHeaderCell>
                                                <asp:TableCell>
                                                    <asp:TextBox TextMode="Number" ID="txtV_Token" runat="server" class="input" Height="45px" Width="350px"></asp:TextBox>
                                              <br/>
                                                     </asp:TableCell>
                                            </asp:TableRow>
                                            <asp:TableRow>
                                                <asp:TableHeaderCell>
                                            <label for="txtV_OpenDate" class="label">Open Date</label>
                                                </asp:TableHeaderCell>
                                                <asp:TableCell>
                                                    <asp:TextBox type="datetime2" ID="txtV_OpenDate" runat="server" class="input" Height="45px" Width="350px"></asp:TextBox>
                                                <br/>
                                                </asp:TableCell>
                                            </asp:TableRow>
                                            <asp:TableRow>
                                                <asp:TableHeaderCell>
                                            <label for="txtV_ClosingDate" class="label">Closing Date</label>
                                                </asp:TableHeaderCell>
                                                <asp:TableCell>
                                                    <asp:TextBox type="datetime2"  ID="txtV_ClosingDate" runat="server" class="input" Height="45px" Width="350px"></asp:TextBox>
                                               <br/>
                                                     </asp:TableCell>
                                            </asp:TableRow>
                                        </asp:Table>
                                    </div>

                                    <div role="tabpanel" class="tab-pane fade" id="VVIP">
                                        <asp:Table runat="server" CssClass="group">
                                            <asp:TableRow>
                                                <asp:TableHeaderCell>
                                            <label for="txtVV_Price" class="label">Price</label>
                                                </asp:TableHeaderCell>
                                                <asp:TableCell>
                                                    <asp:TextBox ID="txtVV_Price" runat="server" class="input" Height="45px" Width="350px"></asp:TextBox>
                                              <br/>
                                                      </asp:TableCell>
                                            </asp:TableRow>
                                            <asp:TableRow>
                                                <asp:TableHeaderCell>
                                            <label for="txtVV_Quantity" class="label">Quantity</label>
                                                </asp:TableHeaderCell>
                                                <asp:TableCell>
                                                    <asp:TextBox TextMode="Number" ID="txtVV_Quantity" runat="server" class="input" Height="45px" Width="350px"></asp:TextBox>
                                                <br/>
                                                </asp:TableCell>
                                            </asp:TableRow>
                                            <asp:TableRow>
                                                <asp:TableHeaderCell>
                                            <label for="txtVV_Token" class="label">Tokens</label>
                                                </asp:TableHeaderCell>
                                                <asp:TableCell>
                                                    <asp:TextBox TextMode="Number" ID="txtVV_Token" runat="server" class="input" Height="45px" Width="350px"></asp:TextBox>
                                                <br/>
                                                </asp:TableCell>
                                            </asp:TableRow>
                                            <asp:TableRow>
                                                <asp:TableHeaderCell>
                                            <label for="txtVV_OpenDate" class="label">Open Date</label>
                                                </asp:TableHeaderCell>
                                                <asp:TableCell>
                                                    <asp:TextBox type="datetime2" ID="txtVV_OpenDate" runat="server" class="input" Height="45px" Width="350px"></asp:TextBox>
                                                <br/>
                                                </asp:TableCell>
                                            </asp:TableRow>
                                            <asp:TableRow>
                                                <asp:TableHeaderCell>
                                            <label for="txtVV_ClosingDate" class="label">Closing Date</label>
                                                </asp:TableHeaderCell>
                                                <asp:TableCell>
                                                    <asp:TextBox type="datetime2" ID="txtVV_ClosingDate" runat="server" class="input" Height="45px" Width="350px"></asp:TextBox>
                                              <br/>
                                                      </asp:TableCell>
                                            </asp:TableRow>
                                        </asp:Table>
                                    </div>

                                    <div role="tabpanel" class="tab-pane fade" id="Regular">
                                        <asp:Table runat="server" CssClass="group">
                                            <asp:TableRow>
                                                <asp:TableHeaderCell>
                                            <label for="txtR_Price" class="label">Price</label>
                                                </asp:TableHeaderCell>
                                                <asp:TableCell>
                                                    <asp:TextBox ID="txtR_Price" runat="server" class="input" Height="45px" Width="350px"></asp:TextBox>
                                               <br/>
                                                     </asp:TableCell>
                                            </asp:TableRow>
                                            <asp:TableRow>
                                                <asp:TableHeaderCell>
                                            <label for="txtR_Quantity" class="label">Quantity</label>
                                                </asp:TableHeaderCell>
                                                <asp:TableCell>
                                                    <asp:TextBox TextMode="Number" ID="txtR_Quantity" runat="server" class="input" Height="45px" Width="350px"></asp:TextBox>
                                               <br/>
                                                     </asp:TableCell>
                                            </asp:TableRow>
                                            <asp:TableRow>
                                                <asp:TableHeaderCell>
                                            <label for="txtR_Token" class="label">Tokens</label>
                                                </asp:TableHeaderCell>
                                                <asp:TableCell>
                                                    <asp:TextBox TextMode="Number" ID="txtR_Token" runat="server" class="input" Height="45px" Width="350px"></asp:TextBox>
                                              <br/>
                                                      </asp:TableCell>
                                            </asp:TableRow>
                                            <asp:TableRow>
                                                <asp:TableHeaderCell>
                                            <label for="txtR_OpenDate" class="label">Open Date</label>
                                                </asp:TableHeaderCell>
                                                <asp:TableCell>
                                                    <asp:TextBox type="datetime2" ID="txtR_OpenDate" runat="server" class="input" Height="45px" Width="350px"></asp:TextBox>
                                               <br/>
                                                     </asp:TableCell>
                                            </asp:TableRow>
                                            <asp:TableRow>
                                                <asp:TableHeaderCell>
                                            <label for="txtR_ClosingDate" class="label">Closing Date</label>
                                                </asp:TableHeaderCell>
                                                <asp:TableCell>
                                                    <asp:TextBox type="datetime2" ID="txtR_ClosingDate" runat="server" class="input" Height="45px" Width="350px"></asp:TextBox>
                                               <br/>
                                                     </asp:TableCell>
                                            </asp:TableRow>
                                        </asp:Table>
                                    </div>
                                </div>
                            </div>
                            <div class="foot-lnk">
                            <asp:Button Style="padding: 12px 100px;" class="btn btn-primary animated lightSpeedIn" ID="btnSubmit" runat="server" Text="Edit Event" OnClick="btnSubmit_Click" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!-- /.container -->

</asp:Content>
