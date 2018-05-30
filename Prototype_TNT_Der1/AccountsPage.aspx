<%@ Page Title="" Language="C#" MasterPageFile="~/Eventrix.Master" AutoEventWireup="true" CodeBehind="AccountsPage.aspx.cs" Inherits="Prototype_TNT_Der1.AccountsPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

    <section class="page-header-wrapper">
        <div class="container">
            <div class="row">
                <div class="col-md-12">
                    <div class="page-header">
                        <h1>Account Info</h1>
                    </div>
                </div>
            </div><!-- /.row -->
        </div><!-- /.container-fluid -->
    </section>

    <div class="container">
        <div class="login-wrapper">
            <div class="login-wrap">
                <div class="login-html">
                    <input id="tab-1" type="radio" name="tab" class="sign-in" checked/><label for="tab-1" class="tab">User Account</label>
                    <input id="tab-2" type="radio" name="tab" class="sign-up" /><label for="tab-2" class="tab">Bank Details</label>
                    <div class="login-form">
                        <div class="sign-in-htm">

                            <asp:Table runat="server" CssClass="group">
                                <asp:TableRow>
                                    <asp:TableHeaderCell>
                                        <br />
                                        <label runat="server" id="lblName" class="label">Name</label>
                                    </asp:TableHeaderCell>
                                    <asp:TableCell>
                                        <br />
                                        <asp:TextBox ID="txtU_name" runat="server" class="input" Height="34px" Width="155px" ></asp:TextBox>
                                    </asp:TableCell>
                                    <asp:TableHeaderCell>
                                        <br />
                                        <asp:Button ID="EditName" runat="server" class="button" Text="Edit" Height="34px" Width="90px" OnClick="EditName_Click" />
                                    </asp:TableHeaderCell>
                                </asp:TableRow>

                                <asp:TableRow>
                                    <asp:TableHeaderCell>
                                        <br />
                                        <label runat="server" id="lblSurname" class="label">Surname</label>
                                    </asp:TableHeaderCell>
                                    <asp:TableCell>
                                        <br />
                                        <asp:TextBox ID="txtU_surname" runat="server" class="input" Height="34px" Width="155px" ></asp:TextBox>
                                    </asp:TableCell>
                                    <asp:TableHeaderCell>
                                        <br />
                                        <asp:Button ID="EditSurname" runat="server" class="button" Text="Edit" Height="34px" Width="90px" OnClick="EditSurname_Click" />
                                    </asp:TableHeaderCell>
                                </asp:TableRow>

                                <asp:TableRow>
                                    <asp:TableHeaderCell>
                                        <br />
                                        <label runat="server" id="lblemail" class="label">Email</label>
                                    </asp:TableHeaderCell>
                                    <asp:TableCell>
                                        <br />
                                        <asp:TextBox ID="txtU_Email" runat="server" class="input" Height="34px" Width="155px"></asp:TextBox>
                                    </asp:TableCell>
                                    <asp:TableHeaderCell>
                                        <br />
                                        <asp:Button ID="EditEmail" runat="server" class="button" Text="Edit" Height="34px" Width="90px" OnClick="EditEmail_Click" />
                                    </asp:TableHeaderCell>
                                </asp:TableRow>

                                <asp:TableRow>
                                    <asp:TableHeaderCell>
                                        <br />
                                        <label runat="server" id="lblAttendedEvents" class="label">Attended Events</label>
                                    </asp:TableHeaderCell>
                                    <asp:TableCell>
                                        <br />
                                        <asp:TextBox ID="txtEventsAttended" runat="server" class="input" Height="34px" Width="155px" ></asp:TextBox>
                                    </asp:TableCell>
                                </asp:TableRow>

                                <asp:TableRow>
                                    <asp:TableHeaderCell>
                                        <br />
                                        <label runat="server" id="lblTicketsBought" class="label">Purchased Ticket</label>
                                    </asp:TableHeaderCell>
                                    <asp:TableCell>
                                        <br />
                                        <asp:TextBox ID="txtTicket" runat="server" class="input" Height="34px" Width="155px" ></asp:TextBox>
                                    </asp:TableCell>
                                </asp:TableRow>

                            </asp:Table>
                            <div class="group">
                                <asp:Button ID="btnUAcc" class="button" runat="server" Text="Save Changes" type="submit" />
                                <hr class="hr" />
                            </div>
                        </div>

                        <div class="sign-up-htm">
                            <asp:Table runat="server" CssClass="group">
                                <asp:TableRow>
                                    <asp:TableCell>
                                        <br />
                                        <label runat="server" id="lblAccountNumber" for="user" class="label">Account Number</label>
                                        <asp:TextBox ID="txtName" runat="server" class="input" Height="34px" Width="370px"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="* Name Is Required" ControlToValidate="txtName" CssClass="reqFieldValid">* Required Field</asp:RequiredFieldValidator>
                                    </asp:TableCell>
                                </asp:TableRow>
                                <asp:TableRow>
                                    <asp:TableCell>
                                        <label runat="server" id="lblBankName" for="user" class="label">Bank Name</label>
                                        <asp:TextBox ID="txtSurname" runat="server" class="input" Height="34px" Width="370px"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="* Surname Is Required" ControlToValidate="txtSurname" CssClass="reqFieldValid">* Required Field</asp:RequiredFieldValidator>
                                    </asp:TableCell>
                                </asp:TableRow>
                                <asp:TableRow>
                                    <asp:TableCell>
                                        <label runat="server" id="lblAccountType" for="user" class="label">Account Type</label>
                                        <asp:TextBox ID="txtEmail" runat="server" class="input" list="listAccountype" Height="34px" Width="370px"></asp:TextBox>
                                        <datalist id="listAccountype">
                                            <option>Savings Account</option>
                                            <option>Cheques Account</option>
                                        </datalist>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="* Email Is Required" ControlToValidate="txtEmail" CssClass="reqFieldValid">* Required Field</asp:RequiredFieldValidator>
                                    </asp:TableCell>
                                </asp:TableRow>
                            </asp:Table>
                            <div class="group">
                                <asp:Button class="button" ID="btnSave" runat="server" Text="Save Changes" type="submit"/>
                                <hr class="hr" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            </div>
        </div>
</asp:Content>
