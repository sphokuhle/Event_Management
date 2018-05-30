<%@ Page Title="" Language="C#" MasterPageFile="~/Eventrix.Master" AutoEventWireup="true" CodeBehind="CreateEvent.aspx.cs" Inherits="Prototype_TNT_Der1.CreateEvent" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <link href="css/Modal/bootstrap.min.css" rel="stylesheet" />

    <section class="page-header-wrapper">
        <div class="container">
            <div class="row">
                <div class="col-md-12">
                    <div class="page-header">
                    </div>
                    <ol class="breadcrumb">
                        <li><a href="Index.aspx">Home</a></li>
                        <li><a href="#">Event Management</a></li>
                        <li class="active">Create Event</li>
                    </ol>
                </div>
            </div>
            <!-- /.row -->
        </div>
        <!-- /.container-->
    </section>

    <div class="container">
        <div class="content-wrapper">
            <div class="inner-content">

                    <div id="status" runat="server">

                </div>

                <div class="row">

                    <div class="typography-page-tab" role="tabpanel">
                        <!-- Nav tabs -->
                        <ul class="nav nav-tabs" role="tablist">
                            <li role="presentation" class="active"><a href="#Event_Info" aria-controls="home" role="tab" data-toggle="tab">Event Details</a></li>
                            <li role="presentation"><a href="#Ticket_Info" aria-controls="profile" role="tab" data-toggle="tab">Tickets</a></li>
                            <%--<li role="presentation"><a href="#Guest_Info" aria-controls="messages" role="tab" data-toggle="tab">Guests</a></li>
                            <li role="presentation"><a href="#Product_Info" aria-controls="messages" role="tab" data-toggle="tab">Products</a></li>--%>
                        </ul>

                        <!-- Tab panes -->
                        <div class="tab-content">
                            <div role="tabpanel" class="tab-pane fade in active" id="Event_Info">
                                <br />
                                <table>
                                    <tr>
                                        <td>
                                            <div style="width: 400px; padding-left: 50px;">
                                                <div class="form-group">
                                                    <label for="txtEventName">Event Name</label>
                                                    <asp:TextBox ID="txtEventName" runat="server" name="event_name" type="text" class="form-control" required=""></asp:TextBox>
                                                </div>

                                                <div class="form-group">
                                                    <label for="txtCategory">Category</label>
                                                    <asp:TextBox ID="txtCategory" runat="server" list="listEventType" type="text" class="form-control" required=""></asp:TextBox>
                                                    <datalist id="listEventType">
                                                        <option>Conference </option>
                                                        <option>Seminar </option>
                                                        <option>Product Launch</option>
                                                        <option>Award Ceremony </option>
                                                        <option>Trade Show </option>
                                                        <option>Wedding </option>
                                                        <option>Family Event </option>
                                                    </datalist>
                                                </div>

                                                <%-- Date time range picker --%>
                                                <div class="form-group">
                                                    <label>Start Date - End Date</label>
                                                    <table>
                                                        <tr>
                                                            <td>
                                                                <div style="width: 160px;">
                                                                    <asp:TextBox ID="txtStart" runat="server" type="text" class="form-control" required="" TextMode="DateTimeLocal"></asp:TextBox></div>
                                                            </td>
                                                            <td style="text-align: center; width: 40px;">Till</td>
                                                            <td>
                                                                <div style="width: 160px;">
                                                                    <asp:TextBox ID="txtEnd" runat="server" type="text" class="form-control" required="" TextMode="DateTimeLocal"></asp:TextBox></div>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </div>

                                                <div class="form-group">
                                                    <label>Description</label>
                                                    <textarea runat="server" class="form-control" rows="3" id="txtDesc"></textarea>
                                                </div>

                                                <div class="form-group">
                                                    <label for="TextBox1">Upload Event Image</label>
                                                    <asp:FileUpload ID="flEventImages" runat="server" class="btn btn-default btn-xs" Width="109px" />
                                                </div>
                                                <div class="form-group">
                                                    <label for="chkBoxPrivate"></label>
                                                    <asp:CheckBox ID="chkBoxPrivate" runat="server" />
                                                    Private Event
                                                </div>

                                            </div>
                                        </td>
                                        <td>
                                            <div style="width: 150px;"></div>
                                        </td>
                                        <td>
                                            <div style="width: 400px;">
                                                <div class="form-group">
                                                    <label for="TextBox1">Street</label>
                                                    <asp:TextBox ID="txtStreet" runat="server" type="text" class="form-control" required=""></asp:TextBox>
                                                </div>

                                                <div class="form-group">
                                                    <label for="TextBox1">City</label>
                                                    <asp:TextBox ID="txtCity" runat="server" type="text" class="form-control" required=""></asp:TextBox>
                                                </div>

                                                <div class="form-group">
                                                    <label for="TextBox1">Province</label>
                                                    <asp:TextBox ID="txtProvince" runat="server" type="text" class="form-control" required=""></asp:TextBox>
                                                </div>
                                                <div class="form-group">
                                                    <label for="TextBox1">Country</label>
                                                    <asp:TextBox ID="txtCountry" runat="server" type="text" class="form-control" required=""></asp:TextBox>
                                                </div>
                                                <div class="form-group">
                                                    <label></label>
                                                    <asp:CheckBox ID="chkShare" runat="server" />
                                                    Share event
                                                </div>
                                                <div class="form-group">
                                                    <label>Upload <small>Guests, Staff & Products</small></label>
                                                    <table>
                                                        <tr>
                                                            <td>
                                                                <asp:FileUpload ID="flGuest" runat="server" class="btn btn-default btn-xs" Width="113px" /></td>
                                                            <td style="width: 30px;"></td>
                                                            <td>
                                                                <%--<asp:Button ID="btnDownloadFile" runat="server" Text="Download Button" OnClick="btnDownloadFile_Click" />--%>
                                                                <asp:LinkButton ID="lnkDownload" runat="server" OnClick="lnkDownload_Click" class="btn btn-default btn-xs" data-toggle="tooltip" data-placement="right" title="Download template of the spreadsheet" Width="148px" ><i class="fa fa-cloud-download"></i> Download Template</asp:LinkButton>
                                                             <%--   <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click"><a href="#" class="btn btn-default btn-xs" data-toggle="tooltip" data-placement="right" title="Download template of the spreadsheet" ><i class="fa fa-cloud-download"></i> Download </a></asp:LinkButton>--%></td>
                                                        </tr>
                                                    </table>
                                                </div>

                                            </div>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                          
                            <div role="tabpanel" class="tab-pane fade" id="Ticket_Info">
                                <br />
                                <div class="panel-group" id="accordion" role="tablist" aria-multiselectable="true">
                                    <div class="panel panel-default">
                                        <div class="panel-heading panel-heading-link" role="tab" id="headingOne">
                                            <h2 class="panel-title">
                                                <a data-toggle="collapse" data-parent="#accordion" href="#collapseOne" aria-expanded="true" aria-controls="collapseOne">Early Birds
									        </a>
                                            </h2>
                                        </div>
                                        <div id="collapseOne" class="panel-collapse collapse in" role="tabpanel" aria-labelledby="headingOne">
                                            <div class="panel-body">
                                                <table>
                                                    <tr>
                                                        <td>
                                                            <div style="width: 150px;">
                                                                <asp:TextBox ID="txtE_Price" runat="server" type="text" class="form-control"  placeholder="Price"></asp:TextBox>
                                                            </div>
                                                        </td>
                                                        <td>
                                                            <div style="width: 45px;"></div>
                                                        </td>
                                                        <td>
                                                            <div style="width: 150px;">
                                                                <asp:TextBox ID="txtE_Quantity" runat="server" type="text" class="form-control"  placeholder="Quantity"></asp:TextBox>
                                                            </div>
                                                        </td>
                                                        <td>
                                                            <div style="width: 45px;"></div>
                                                        </td>
                                                        <td>
                                                            <div style="width: 150px;">
                                                                <asp:TextBox ID="txtE_Token" runat="server" type="text" class="form-control"  placeholder="Tokens/Credits"></asp:TextBox>
                                                            </div>
                                                        </td>
                                                        <td>
                                                            <div style="width: 45px;"></div>
                                                        </td>
                                                        <td>
                                                            <div style="width: 150px;">
                                                                <asp:TextBox ID="txtE_OpenDate" runat="server" type="text" class="form-control"  placeholder="Open Date" TextMode="DateTimeLocal"></asp:TextBox>
                                                            </div>
                                                        </td>
                                                        <td>
                                                            <div style="width: 45px;"></div>
                                                        </td>
                                                        <td>
                                                            <div style="width: 150px;">
                                                                <asp:TextBox ID="txtE_ClosingDate" runat="server" type="text" class="form-control"  placeholder="Closing Date" TextMode="DateTimeLocal"></asp:TextBox>
                                                            </div>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="panel panel-default">
                                        <div class="panel-heading panel-heading-link" role="tab" id="headingTwo">
                                            <h2 class="panel-title">
                                                <a class="collapsed" data-toggle="collapse" data-parent="#accordion" href="#collapseTwo" aria-expanded="false" aria-controls="collapseTwo">Regular
									        </a>
                                            </h2>
                                        </div>
                                        <div id="collapseTwo" class="panel-collapse collapse" role="tabpanel" aria-labelledby="headingTwo">
                                            <div class="panel-body">
                                                <table>
                                                    <tr>
                                                        <td>
                                                            <div style="width: 150px;">
                                                                <asp:TextBox ID="txtR_Price" runat="server" type="text" class="form-control" placeholder="Price"></asp:TextBox>
                                                            </div>
                                                        </td>
                                                        <td>
                                                            <div style="width: 45px;"></div>
                                                        </td>
                                                        <td>
                                                            <div style="width: 150px;">
                                                                <asp:TextBox ID="txtR_Quantity" runat="server" type="text" class="form-control"  placeholder="Quantity"></asp:TextBox>
                                                            </div>
                                                        </td>
                                                        <td>
                                                            <div style="width: 45px;"></div>
                                                        </td>
                                                        <td>
                                                            <div style="width: 150px;">
                                                                <asp:TextBox ID="txtR_Token" runat="server" type="text" class="form-control"  placeholder="Tokens/Credits"></asp:TextBox>
                                                            </div>
                                                        </td>
                                                        <td>
                                                            <div style="width: 45px;"></div>
                                                        </td>
                                                        <td>
                                                            <div style="width: 150px;">
                                                                <asp:TextBox ID="txtR_OpenDate" runat="server" type="text" class="form-control"  placeholder="Open Date" TextMode="DateTimeLocal"></asp:TextBox>
                                                            </div>
                                                        </td>
                                                        <td>
                                                            <div style="width: 45px;"></div>
                                                        </td>
                                                        <td>
                                                            <div style="width: 150px;">
                                                                <asp:TextBox ID="txtR_ClosingDate" runat="server" type="text" class="form-control"  placeholder="Closing Date" TextMode="DateTimeLocal"></asp:TextBox>
                                                            </div>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="panel panel-default">
                                        <div class="panel-heading panel-heading-link" role="tab" id="headingThree">
                                            <h2 class="panel-title">
                                                <a class="collapsed" data-toggle="collapse" data-parent="#accordion" href="#collapseThree" aria-expanded="false" aria-controls="collapseThree">VIP
									        </a>
                                            </h2>
                                        </div>
                                        <div id="collapseThree" class="panel-collapse collapse" role="tabpanel" aria-labelledby="headingThree">
                                            <div class="panel-body">
                                                <table>
                                                    <tr>
                                                        <td>
                                                            <div style="width: 150px;">
                                                                <asp:TextBox ID="txtV_Price" runat="server" type="text" class="form-control"  placeholder="Price"></asp:TextBox>
                                                            </div>
                                                        </td>
                                                        <td>
                                                            <div style="width: 45px;"></div>
                                                        </td>
                                                        <td>
                                                            <div style="width: 150px;">
                                                                <asp:TextBox ID="txtV_Quantity" runat="server" type="text" class="form-control"  placeholder="Quantity"></asp:TextBox>
                                                            </div>
                                                        </td>
                                                        <td>
                                                            <div style="width: 45px;"></div>
                                                        </td>
                                                        <td>
                                                            <div style="width: 150px;">
                                                                <asp:TextBox ID="txtV_Token" runat="server" type="text" class="form-control"  placeholder="Tokens/Credits"></asp:TextBox>
                                                            </div>
                                                        </td>
                                                        <td>
                                                            <div style="width: 45px;"></div>
                                                        </td>
                                                        <td>
                                                            <div style="width: 150px;">
                                                                <asp:TextBox ID="txtV_OpenDate" runat="server" type="text" class="form-control"  placeholder="Open Date" TextMode="DateTimeLocal"></asp:TextBox>
                                                            </div>
                                                        </td>
                                                        <td>
                                                            <div style="width: 45px;"></div>
                                                        </td>
                                                        <td>
                                                            <div style="width: 150px;">
                                                                <asp:TextBox ID="txtV_ClosingDate" runat="server" type="text" class="form-control"  placeholder="Closing Date" TextMode="DateTimeLocal"></asp:TextBox>
                                                            </div>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="panel panel-default">
                                        <div class="panel-heading panel-heading-link" role="tab" id="headingFour">
                                            <h2 class="panel-title">
                                                <a class="collapsed" data-toggle="collapse" data-parent="#accordion" href="#collapseFour" aria-expanded="false" aria-controls="collapseFour">VVIP
									        </a>
                                            </h2>
                                        </div>
                                        <div id="collapseFour" class="panel-collapse collapse" role="tabpanel" aria-labelledby="headingFour">
                                            <div class="panel-body">
                                                <table>
                                                    <tr>
                                                        <td>
                                                            <div style="width: 150px;">
                                                                <asp:TextBox ID="txtVV_Price" runat="server" type="text" class="form-control"  placeholder="Price"></asp:TextBox>
                                                            </div>
                                                        </td>
                                                        <td>
                                                            <div style="width: 45px;"></div>
                                                        </td>
                                                        <td>
                                                            <div style="width: 150px;">
                                                                <asp:TextBox ID="txtVV_Quantity" runat="server" type="text" class="form-control"  placeholder="Quantity"></asp:TextBox>
                                                            </div>
                                                        </td>
                                                        <td>
                                                            <div style="width: 45px;"></div>
                                                        </td>
                                                        <td>
                                                            <div style="width: 150px;">
                                                                <asp:TextBox ID="txtVV_Token" runat="server" type="text" class="form-control"  placeholder="Tokens/Credits"></asp:TextBox>
                                                            </div>
                                                        </td>
                                                        <td>
                                                            <div style="width: 45px;"></div>
                                                        </td>
                                                        <td>
                                                            <div style="width: 150px;">
                                                                <asp:TextBox ID="txtVV_OpenDate" runat="server" type="text" class="form-control"  placeholder="Open Date" TextMode="DateTimeLocal"></asp:TextBox>
                                                            </div>
                                                        </td>
                                                        <td>
                                                            <div style="width: 45px;"></div>
                                                        </td>
                                                        <td>
                                                            <div style="width: 150px;">
                                                                <asp:TextBox ID="txtVV_ClosingDate" runat="server" type="text" class="form-control"  placeholder="Closing Date" TextMode="DateTimeLocal"></asp:TextBox>
                                                            </div>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                  <div class="text-center">
                                    <%--<button id="btnSubmit" runat="server" class="btn btn-primary" type="submit" data-toggle="modal" data-target="#cssMapModal" onclick="btnSubmit_Click">Create Event</button>--%>
                                    <asp:Button ID="btnSubmitEvent" class="btn btn-primary" data-toggle="modal" runat="server" Text="Done!" OnClick="btnSubmitEvent_Click1"/>
                                </div>

                                <!-- Modal -->
                                <div runat="server" class="modal fade" id="cssMapModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
                                    <div class="modal-dialog modal-lg" style="padding-top: 80px;">
                                        <div class="modal-content">
                                            <div class="modal-header">
                                                <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                                                <h4 runat="server" class="modal-title" id="myModalLabel" style="text-align: center;"></h4>
                                            </div>
                                            <div class="modal-body">

                                                <div class="row">
                                                    <div class="col-md-6 col-xs-12" runat="server" id="mdl_Image">
                                                    </div>
                                                    <div class="col-md-6" runat="server" id="mld_Details">

                                                    </div>
                                                </div>
                                                <hr />
                                                <div runat="server" id="btn_MDL" class="text-center">                                                    
                                                </div>

                                            </div>
                                        </div>
                                        <!-- /.modal-content -->
                                    </div>
                                    <!-- /.modal-dialog -->
                                </div>
                                <!-- End Modal -->
                            </div>
                            <%--                            <div role="tabpanel" class="tab-pane fade" id="Guest_Info">
                                <table>
                                    <tr> 
                                        <td>
                                            <div class="form-group">
                                                <label>Upload </label><small>spreadsheet with guest, staff and product details</small>
                                            </div>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                            <div role="tabpanel" class="tab-pane fade" id="Product_Info">
                                <p>Qui photo booth letterpress, commodo enim craft beer mlkshk aliquip jean shorts ullamco ad vinyl cillum. Homo nostrud organic, assumenda labore ethical culpa terry richardson biodiesel ethical culpa terry richardson biodiesel.</p>
                            </div>--%>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
