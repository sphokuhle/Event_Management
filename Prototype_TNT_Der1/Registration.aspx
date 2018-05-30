<%@ Page Title="" Language="C#" MasterPageFile="~/Eventrix.Master" AutoEventWireup="true" CodeBehind="Registration.aspx.cs" Inherits="Prototype_TNT_Der1.Registration" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <section class="page-header-wrapper">
        <div class="container">
            <div class="row">
                <div class="col-md-12">
                    <div class="page-header">
                        <h1>Sign-Up</h1>
                    </div>
                    <ol class="breadcrumb">
                        <li><a href="#">Sign-Up</a></li>
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
                <h3 class="text-center">Welcome to eventriX</h3>
                
                  <div id="status" runat="server">

                </div>
                <div class="row">
                    <div class="text-center" style="padding-left: 300px; padding-right: 300px;">
                        <div class="form-group">
                            <label for="name">Guest Profile Picture</label>
                            <asp:FileUpload ID="profilePic" runat="server" class="form-control" />  <%--Height="50px" Width="250px"--%>
                        </div>
                        <div class="form-group">
                            <label for="name">Name</label>
                            <asp:TextBox ID="txtName" runat="server" name="name" type="text" class="form-control" required="" placeholder="Name"></asp:TextBox>
                        </div>

                        <div class="form-group">
                            <label for="surname">Surname</label>
                            <asp:TextBox ID="txtSurname" runat="server" name="surname" type="text" class="form-control" required="" placeholder="Surname"></asp:TextBox>
                        </div>

                        <div class="form-group">
                            <label for="email">Email</label>
                            <asp:TextBox ID="txtEmail" runat="server" type="email" class="form-control" required="" placeholder="Email"></asp:TextBox>
                        </div>

                        <div class="form-group">
                            <label for="Password">Password</label>
                            <asp:TextBox ID="txtPass" runat="server" type="password" class="form-control" required="" placeholder="Password"></asp:TextBox>
                        </div>

                        <div class="form-group">
                            <label for="Confirm_Password">Confirm Password</label>
                            <asp:TextBox ID="txtPass2" runat="server" type="password" class="form-control" required="" placeholder="Confirm Password"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <asp:CheckBox ID="mycheckbox" runat="server" Text="Event Hosts?" />
                        </div>
                        <div class="form-group">
                            <asp:Button ID="btnSubmit" runat="server" class="btn btn-primary" type="submit" Text="Register" Style="width: 230px;" OnClick="btnSubmit_Click" />
                            <%--<asp:Button ID="btnRegister" runat="server" class="btn btn-primary" type="submit" Text="Sign-Up" Style="width: 230px;" />--%>
                        </div>
                        <div class="form-group">
                            Already have an account? <a href="Login.aspx">Sign-In </a>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>