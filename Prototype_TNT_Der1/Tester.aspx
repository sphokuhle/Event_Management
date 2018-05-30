<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Tester.aspx.cs" Inherits="Prototype_TNT_Der1.Tester" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:TextBox ID="txtName" runat="server">Name</asp:TextBox>  
        <asp:TextBox ID="txtSurname" runat="server">Surname</asp:TextBox><br/>
        <asp:TextBox ID="txtUpdatedName" runat="server"></asp:TextBox>  
        <asp:TextBox ID="txtUpdatedSurname" runat="server"></asp:TextBox><br/>
        <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click" /><br/>
    </div>
    </form>
</body>
</html>
