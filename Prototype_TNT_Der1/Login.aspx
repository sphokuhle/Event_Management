<%@ Page Title="" Language="C#" MasterPageFile="~/Eventrix.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Prototype_TNT_Der1.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  

    <section class="page-header-wrapper">
        <div class="container">
            <div class="row">
                <div class="col-md-12">
                    <div class="page-header">
                        <h1>Sign-In</h1>
                    </div>
                    <ol class="breadcrumb">
                        <li><a href="#">Sign-In</a></li>
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

                  <div id="status" runat="server">

                </div>

                <h3 class="text-center">Welcome Back</h3><hr/>
                <div class="row">

                    <div class="text-center" style="padding-left: 300px; padding-right: 300px;">

                        <div class="form-group">
                            <label for="email">Email</label>
                            <asp:TextBox ID="txtUserName" runat="server" TextMode="Email" class="form-control" required="" placeholder="Email"></asp:TextBox>
                        </div>

                        <div class="form-group">
                            <label for="Password">Password</label>
                            <asp:TextBox ID="txtLogPass" runat="server" TextMode="Password" class="form-control" required="" placeholder="Password"></asp:TextBox>
                        </div>

                             <div class="form-group">
                            <asp:Table runat="server">
                                <asp:TableRow>
                                    <asp:TableCell>
                                        <div style="padding-left: 15px;">
                                            <asp:CheckBox ID="remember_me" runat="server" Text="" />Remember Me?
                                        </div>
                                    </asp:TableCell>
                                    <asp:TableCell>
                                            <div style="padding-left:170px;">
                                <a href="ForgotPassword.aspx"> Forgot Password? </a>
                                             </div>
                                    </asp:TableCell>
                                </asp:TableRow>

                            </asp:Table>
                        </div>
                        <div class="form-group">
                            <asp:Button ID="btnLogin" runat="server" Text="Sign-In" class="btn btn-primary" type="submit" Style="width: 230px;" OnClick="btnLogin_Click1" />
                        </div>
                        <div class="form-group">
                            Don't have an account? <a href="Registration.aspx">Sign-Up</a>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
