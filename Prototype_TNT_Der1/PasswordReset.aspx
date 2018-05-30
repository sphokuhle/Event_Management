<%@ Page Title="" Language="C#" MasterPageFile="~/Eventrix.Master" AutoEventWireup="true" CodeBehind="PasswordReset.aspx.cs" Inherits="Prototype_TNT_Der1.PasswordReset" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <section class="page-header-wrapper">
					<div class="container">
						<div class="row">
							<div class="col-md-12">
								<div class="page-header">
								  <h1>Password Reset</h1>
								</div>
							</div>
						</div><!-- /.row -->

					</div><!-- /.container-fluid -->
				</section>


	<div class="container">
    <div class="login-wrap">
	<div class="login-html">
		<input id="tab-1" type="radio" name="tab" class="sign-in" checked/><label for="tab-1" class="tab">Sign In</label>
		<input id="tab-2" type="radio" name="tab" visible="false" class="sign-up"/><label for="tab-2" class="tab"></label>
		<div class="login-form">
			<div class="sign-in-htm">
				<div class="group">
                    <asp:Label ID="lblResponse" runat="server" Visible="false" class="label"></asp:Label>
					<label for="user" class="label">Email Address</label>
					<%--<input id="user" type="text" class="input"/>--%>
                    <asp:TextBox type="Email" ID="txtEmail" runat="server" class="form-control" placeholder="Email"></asp:TextBox>
				</div>

				<div class="group">
					<%--<input runat="server" id="btnLogin" type="submit" class="button" value="Sign In"/>--%>
                    <asp:Button ID="btnReset" runat="server" Text="Request Password" OnClick="btnReset_Click" class="button" />
				</div>
				<div class="hr"></div>
			</div>
		</div>
	</div>
</div>
							
</div><!-- /.container -->
</asp:Content>
