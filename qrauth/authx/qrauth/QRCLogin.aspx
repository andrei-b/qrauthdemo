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
    <asp:ScriptManager runat="server" id="ScriptManager1" />
<asp:Timer ID="Timer1" runat="server" Interval="120000" 
  OnTick="Timer1_Tick">
</asp:Timer>
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
  <Triggers>
    <asp:AsyncPostBackTrigger ControlID="Timer1" 
        EventName="Tick" />
    </Triggers>
    <ContentTemplate>
      <asp:Label ID="Label1" runat="server" ></asp:Label>
  </ContentTemplate>
</asp:UpdatePanel>
</body>
</html>
