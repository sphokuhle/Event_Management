<%@ Page Title="" Language="C#" MasterPageFile="~/Eventrix.Master" AutoEventWireup="true" CodeBehind="EditGuest.aspx.cs" Inherits="Prototype_TNT_Der1.EditGuest" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <section class="page-header-wrapper">
        <div class="container">
            <div class="row">
                <div class="col-md-12">
                    <div class="page-header">
                        <h1>Edit Personal Details</h1>
                    </div>
                </div>
            </div><!-- /.row -->
        </div><!-- /.container-fluid -->
    </section>
    <div class="container">
        <div class="content-wrapper">
            <div class="inner-content">
                <div class="row">  
                    <div class="text-center" style="padding-left: 300px; padding-right: 300px;">
                        <div class="form-group">
		                    <label for="email">Change Profile Picture</label>
		                    <asp:FileUpload ID="profilePic" Text="Change Profile Picture" runat="server" class="form-control" Height="40px" Width="370px" />
	                    </div>

	                    <div class="form-group">
		                    <label for="email">Name</label>
		                    <asp:TextBox ID="txtName" runat="server" class="form-control" Height="40px" Width="370px"></asp:TextBox>
	                    </div>

	                    <div class="form-group">
		                    <label for="email">Lastname</label>
		                    <asp:TextBox ID="txtLastname" runat="server" class="form-control" Height="40px" Width="370px"></asp:TextBox>
	                    </div>
	
	                    <div class="form-group">
		                    <label for="email">Email</label>
		                    <asp:TextBox ID="txtEmail" runat="server" class="form-control" TextMode="Email" OnTextChanged="txtEmail_TextChanged" ToolTip="User Email" Height="40px" Width="370px"></asp:TextBox>
		                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="* Email Is Required" ControlToValidate="txtEmail" CssClass="reqFieldValid">* Required Field</asp:RequiredFieldValidator>
		                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="* Enter Valid Email Format" ControlToValidate="txtEmail" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" CssClass="reqFieldValid" Display="Dynamic"></asp:RegularExpressionValidator>
	                    </div>
	                    <!-- End of Dynamic User Details -->
	                    <div class="form-group">
		                    <asp:Button Style="width: 230px;" class="btn btn-primary animated lightSpeedIn" ID="btnEdit" runat="server" Text="Submit Changes" type="submit" OnClick="btnEdit_Click" />
	                    </div>								
                    
	                    <div class="form-group">
		                    <label for="email">Current Password</label>
		                    <asp:TextBox textmode="Password" ID="txtOldpassword" runat="server" class="input" placeholder="********" Height="40px" Width="370px"></asp:TextBox>
	                    </div>
	
	                    <div class="form-group">
		                    <label for="email">New Password</label>
		                    <asp:TextBox ID="txtNewPas" runat="server" class="input" placeholder="New Password" TextMode="Password" OnTextChanged="txtPass_TextChanged" ToolTip="Enter Password" Height="40px" Width="370px"></asp:TextBox>
		                    <ajaxToolkit:PasswordStrength ID="pwdStrength" TargetControlID="txtNewPas"  StrengthIndicatorType="Text" HelpStatusLabelID="lblhelp1" PreferredPasswordLength="8"
			                    MinimumNumericCharacters="1" MinimumSymbolCharacters="1" TextStrengthDescriptions="Very Poor;Weak;Average;Good;Excellent" TextStrengthDescriptionStyles="VeryPoorStrength;WeakStrength;AverageStrength;GoodStrength;ExcellentStrength"
			                    runat="server" DisplayPosition="RightSide"></ajaxToolkit:PasswordStrength>
	                    </div>
	
	                    <div class="form-group">
		                    <label for="email">Confirm New Password</label>
		                    <asp:TextBox ID="txtConfirmPas" runat="server" class="input" placeholder="Confirm Password" TextMode="Password" OnTextChanged="txtPass2_TextChanged" ToolTip="Enter Same Password as above" Height="40px" Width="370px"></asp:TextBox>
		                    <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="* Passwords Do Not Match" ControlToCompare="txtNewPas" ControlToValidate="txtConfirmPas" CssClass="reqFieldValid" Display="Dynamic" EnableViewState="true">* Passwords Do Not Match</asp:CompareValidator>
	                    </div>

	                    <div class="form-group">
		                    <asp:Label class="label" ID="lblWarning" ForeColor="Red" Visible="false" runat="server"></asp:Label>
	                    </div>

	                    <div class="form-group">
		                    <asp:Button ID="btnReset" Style="width: 230px;" class="btn btn-primary animated lightSpeedIn" runat="server" Text="Reset Password" type="submit" OnClick="btnReset_Click" />
	                    </div>
                    </div>
                </div>
            </div>
        </div>
    </div>



</asp:Content>
