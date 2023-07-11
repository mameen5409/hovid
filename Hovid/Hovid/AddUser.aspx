<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="AddUser.aspx.vb" Inherits="Hovid.AddUser" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <span style="font-weight:bold;text-decoration: underline">Register</span></div>
        Username
        :
        <asp:TextBox ID="txUsername" runat="server"></asp:TextBox>
        <br />
        <br />
        UserNo&nbsp;&nbsp; :
        <asp:TextBox ID="txUserNo" runat="server"></asp:TextBox>
        <br />
        <asp:Button ID="btnCreate" runat="server" Text="Create" style="height: 26px" />
    &nbsp;<asp:Label ID="lbstatus" runat="server" Font-Italic="True"></asp:Label>
    </form>
</body>
</html>
