<%@ Page Title="" Language="C#" MasterPageFile="~/Eventrix.Master" AutoEventWireup="true" CodeBehind="PurchaseTicket.aspx.cs" Inherits="Prototype_TNT_Der1.PurchaseTicket" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <section class="page-header-wrapper">
        <div class="container">
            <div class="row">
                <div class="col-md-12">
                    <div class="page-header">
                        <h1>Ticket Purchase</h1>
                    </div>
                </div>
            </div><!-- /.row -->
        </div><!-- /.container-fluid -->
    </section>
<div class="container">
        <div class="content-wrapper">
            <div class="inner-content">
                <h3 class="text-center">Purchase Ticket</h3>
                <div class="row">
                    <div class="typography-page-tab" role="tabpanel">
                        <!-- Nav tabs -->
                        <ul class="nav nav-tabs" role="tablist">
                            <li role="presentation" class="active"><a href="#home" aria-controls="home" role="tab" data-toggle="tab">Personal Details</a></li>
                            <li role="presentation"><a href="#paymentdetails" aria-controls="profile" role="tab" data-toggle="tab">Payment Details</a></li>
                        </ul>

                        <!-- Tab panes -->
                        <div class="tab-content">
                            <div role="tabpanel" class="tab-pane fade in active" id="home">
                                <div class="text-center" style="padding-left: 300px; padding-right: 300px;">

                                    <div class="form-group">
                                        <label for="name">Name</label>
                                        <asp:TextBox ID="txtU_name" runat="server" type="text" class="form-control" required=""></asp:TextBox>
                                    </div>

                                    <div class="form-group">
                                        <label for="surname">Surname</label>
                                        <asp:TextBox ID="txtU_surname" runat="server" type="text" class="form-control" required=""></asp:TextBox>
                                    </div>

                                    <div class="form-group">
                                        <label for="email">Email</label>
                                        <asp:TextBox ID="txtU_Email" runat="server" TextMode="Email" class="form-control" required="" ></asp:TextBox>
                                    </div>

                                    <div class="form-group">
                                        <label for="Quantity">Quantity</label>
                                        <asp:TextBox ID="txtQtys" runat="server" TextMode="Number" class="form-control" required="" ></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div role="tabpanel" class="tab-pane fade" id="paymentdetails">
                                <div class="text-center" style="padding-left: 300px; padding-right: 300px;">
                                    <img src="img/paypal.png" />
                                    <br/><br/>
                                    <div class="form-group">
                                        <label >Card Number</label>
                                        <asp:TextBox ID="TextBox4" runat="server" TextMode="Number" class="form-control" required=""></asp:TextBox>
                                    </div>
                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <label>CVV Number </label>
                                            <asp:TextBox ID="TextBox6" runat="server" TextMode="Number" class="form-control" required=""></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <label>Expire Date </label>
                                            <asp:TextBox ID="TextBox7" runat="server" TextMode="Number" class="form-control" required="" placeholder="MM/YY"></asp:TextBox>
                                        </div>
                                    </div>
                                   
                                    <div class="form-group">
                                        <asp:Button ID="btnSave" runat="server" class="btn btn-primary" type="submit" Text="Submit" Style="width: 230px;" OnClick="btnSave_Click1"/>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
