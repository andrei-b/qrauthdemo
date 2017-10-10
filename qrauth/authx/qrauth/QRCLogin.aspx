<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="QRCLogin.aspx.cs" Inherits="qrauth.QRCLogin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <h1>Login with QR Code</h1>
    
    </div>
        <asp:Image ID="Image1" runat="server" OnPreRender="Image1_PreRender" />
    </form>
</body>
</html>
