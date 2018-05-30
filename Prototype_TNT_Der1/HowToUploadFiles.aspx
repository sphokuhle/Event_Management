<%@ Page Title="" Language="C#" MasterPageFile="~/Eventrix.Master" AutoEventWireup="true" CodeBehind="HowToUploadFiles.aspx.cs" Inherits="Prototype_TNT_Der1.HowToUploadFiles" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <section class="page-header-wrapper">
        <div class="container">
            <div class="row">
                <div class="col-md-12">
                    <div class="page-header">
                        <h1>Need Help Uploading Files?</h1>
                    </div>
                </div>
            </div><!-- /.row -->
        </div><!-- /.container-fluid -->
    </section>

    <section class="handover-wrapper">
<%--        <h2 class="section-title wow fadeInDown">Our Handover Project</h2>--%>
        <div id="css-handover-carousel" class="carousel slide" data-ride="carousel">
            <!-- Indicators -->
            <ol class="carousel-indicators">
                <li data-target="#css-handover-carousel" data-slide-to="0" class="active"></li>
                <li data-target="#css-handover-carousel" data-slide-to="1"></li>
                <li data-target="#css-handover-carousel" data-slide-to="2"></li>
                <li data-target="#css-handover-carousel" data-slide-to="3"></li>
                <li data-target="#css-handover-carousel" data-slide-to="4"></li>
                <li data-target="#css-handover-carousel" data-slide-to="5"></li>
            </ol>

            <!-- Wrapper for slides -->
            <div class="carousel-inner" role="listbox">
                <div class="item active">
                    <div class="row">
                        <div class="col-md-6 col-md-push-6 wow fadeRight">
                            <div class="handover-work-thumb">
                                <%-- screenshot of the image upload --%>
                                <img src="img/pr2.png" alt="" /> 
                            </div><!-- /.client-thumb -->
                        </div><!-- /.col-md-6 -->

                        <div class="col-md-6 col-md-pull-6 wow fadeInLeft">
                            <div class="handover-project">
                                <h3>Uploading event images</h3>
<%--                                <p>Efficiently communicate installed base leadership skills with extensible testing procedures. Enthusiastically evolve leading-edge scenarios.</p>--%>

                                <ul class="check-square">
                                    <li>Click "choose file" to select your image.</li>
                                    <li>Select the image you wish to upload as an event image.</li>
                                    <li>Click "open".</li>
                                    <li>The name of the file you selected will be displayed. </li>
                                </ul>
                            </div>
                            <!-- /.handover-project -->
                        </div>
                        <!-- /.col-md-6 -->
                    </div>
                    <!-- /.row -->
                </div>
                <!-- /.item -->
                <div class="item">
                    <div class="row">
                        <div class="col-md-6 col-md-push-6">
                            <div class="handover-work-thumb">
                                <%-- Screenshot of the .xlsx file --%>
                                <img src="img/pr2.png" alt="" />
                            </div>
                            <!-- /.client-thumb -->
                        </div>
                        <!-- /.col-md-6 -->

                        <div class="col-md-6 col-md-pull-6">
                            <div class="handover-project">
                                <h3>Uploading your <b style="color:#e89b04;">Public</b> Event Spreadsheet</h3>
<%--                                <p>Spreadsheet for Public Event</p>--%>

                                <ul class="check-square">
                                    <li>The Spreadsheet should have two sheets(Staff & Products), picture on the <br/> right shows <b style="color:#e89b04;">staff</b> sheet format</li>
                                    <li>Click "choose file" to select your Spreadsheet(.xlsx).</li>
                                    <li>Select the Spreadsheet you wish to upload.</li>
                                    <li>Click "open".</li>
                                    <li>The name of the file(.xlsx) you selected will be displayed. </li>
                                </ul>
                            </div>
                            <!-- /.handover-project -->
                        </div>
                        <!-- /.col-md-6 -->
                    </div>
                    <!-- /.row -->
                </div>
                <!-- /.item -->
                <div class="item">
                    <div class="row">
                        <div class="col-md-6 col-md-push-6">
                            <div class="handover-work-thumb">
                                <%-- Screenshot of the .xlsx file --%>
                                <img src="img/pr2.png" alt="" />
                            </div>
                            <!-- /.client-thumb -->
                        </div>
                        <!-- /.col-md-6 -->

                        <div class="col-md-6 col-md-pull-6">
                            <div class="handover-project">
                                <h3>Uploading your <b style="color:#e89b04;">Public</b> Event Spreadsheet</h3>
<%--                                <p>Spreadsheet for Public Event</p>--%>

                                <ul class="check-square">
                                    <li>The Spreadsheet should have two sheets(Staff & Products), picture on the <br/> right shows <b style="color:#e89b04;">product </b> sheet format</li>
                                    <li>Click "choose file" to select your Spreadsheet(.xlsx).</li>
                                    <li>Select the Spreadsheet you wish to upload.</li>
                                    <li>Click "open".</li>
                                    <li>The name of the file(.xlsx) you selected will be displayed. </li>
                                </ul>
                            </div>
                            <!-- /.handover-project -->
                        </div>
                        <!-- /.col-md-6 -->
                    </div>
                    <!-- /.row -->
                </div>
                <!-- /.item -->
                <div class="item">
                    <div class="row">
                        <div class="col-md-6 col-md-push-6">
                            <div class="handover-work-thumb">
                                <img src="img/pr2.png" alt="" />
                            </div>
                            <!-- /.client-thumb -->
                        </div>
                        <!-- /.col-md-6 -->

                        <div class="col-md-6 col-md-pull-6">
                            <div class="handover-project">
                                <h3>Uploading your <b style="color:#e89b04;">Private</b> Event Spreadsheet</h3>
<%--                                <p>Spreadsheet for Private Event</p>--%>

                                <ul class="check-square">
                                    <li>The Spreadsheet should have three sheets(Guest, Staff & Products), picture on the <br/> right shows <b style="color:#e89b04;">guest </b> sheet format</li>
                                    <li>Click "choose file" to select your Spreadsheet(.xlsx).</li>
                                    <li>Select the Spreadsheet you wish to upload.</li>
                                    <li>Click "open".</li>
                                    <li>The name of the file(.xlsx) you selected will be displayed. </li>
                                </ul>
                            </div>
                            <!-- /.handover-project -->
                        </div>
                        <!-- /.col-md-6 -->
                    </div>
                    <!-- /.row -->
                </div>
                <!-- /.item -->
                <div class="item">
                    <div class="row">
                        <div class="col-md-6 col-md-push-6">
                            <div class="handover-work-thumb">
                                <img src="img/pr2.png" alt="" />
                            </div>
                            <!-- /.client-thumb -->
                        </div>
                        <!-- /.col-md-6 -->

                        <div class="col-md-6 col-md-pull-6">
                            <div class="handover-project">
                                <h3>Uploading your <b style="color:#e89b04;">Private</b> Event Spreadsheet</h3>
<%--                                <p>Spreadsheet for Private Event</p>--%>

                                <ul class="check-square">
                                    <li>The Spreadsheet should have three sheets(Guest, Staff & Products), picture on the <br/> right shows <b style="color:#e89b04;">staff</b> sheet format</li>
                                    <li>Click "choose file" to select your Spreadsheet(.xlsx).</li>
                                    <li>Select the Spreadsheet you wish to upload.</li>
                                    <li>Click "open".</li>
                                    <li>The name of the file(.xlsx) you selected will be displayed. </li>
                                </ul>
                            </div>
                            <!-- /.handover-project -->
                        </div>
                        <!-- /.col-md-6 -->
                    </div>
                    <!-- /.row -->
                </div>
                <!-- /.item -->
                <div class="item">
                    <div class="row">
                        <div class="col-md-6 col-md-push-6">
                            <div class="handover-work-thumb">
                                <img src="img/pr2.png" alt="" />
                            </div>
                            <!-- /.client-thumb -->
                        </div>
                        <!-- /.col-md-6 -->

                        <div class="col-md-6 col-md-pull-6">
                            <div class="handover-project">
                                <h3>Uploading your <b style="color:#e89b04;">Private</b> Event Spreadsheet</h3>
<%--                                <p>Spreadsheet for Private Event</p>--%>

                                <ul class="check-square">
                                    <li>The Spreadsheet should have three sheets(Guest, Staff & Products), picture on the <br/> right shows <b style="color:#e89b04;">product</b> sheet format</li>
                                    <li>Click "choose file" to select your Spreadsheet(.xlsx).</li>
                                    <li>Select the Spreadsheet you wish to upload.</li>
                                    <li>Click "open".</li>
                                    <li>The name of the file(.xlsx) you selected will be displayed. </li>
                                </ul>
                            </div>
                            <!-- /.handover-project -->
                        </div>
                        <!-- /.col-md-6 -->
                    </div>
                    <!-- /.row -->
                </div>

            </div>
            <!-- /.carousel-inner -->
        </div>
        <!-- /.carousel -->
    </section>

</asp:Content>
