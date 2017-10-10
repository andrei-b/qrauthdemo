﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="qrauth.Default" %>

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
                <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Login.aspx">Password Login</asp:HyperLink>
            </AnonymousTemplate>
            <LoggedInTemplate>
                You are logged in,
                <asp:LoginName ID="LoginName1" runat="server" />
                !
            </LoggedInTemplate>
        </asp:LoginView>
    
    </div>
        <p>
            &nbsp;</p>
    </form>
</body>
</html>
