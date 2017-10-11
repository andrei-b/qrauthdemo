<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="qrauth.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:LoginView ID="LoginView1" runat="server">
            <AnonymousTemplate>
                You are not logged in!<br /> Please select the log in method:<br />
                <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Login.aspx">Password Log in</asp:HyperLink>
                <br />
                <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/QRCLogin.aspx">QR Code Log in</asp:HyperLink>
                <br />
                <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="~/Register.aspx">Sign Up</asp:HyperLink>
            </AnonymousTemplate>
            <LoggedInTemplate>
                You are logged in,
                <asp:LoginName ID="LoginName1" runat="server" />
                !<br /> &nbsp;<asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">Log out</asp:LinkButton>
            </LoggedInTemplate>
        </asp:LoginView>
    
    </div>
        <p>
            &nbsp;</p>
    </form>
</body>
</html>
