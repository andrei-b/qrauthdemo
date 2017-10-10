<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="auth.aspx.cs" Inherits="authx.auth" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="auth" runat="server">
    <div>
    
        <asp:LoginView ID="LoginView1" runat="server">
            <AnonymousTemplate>
                Please log&nbsp; in to proceed
            </AnonymousTemplate>
            <LoggedInTemplate>
                Congratulations, you are logged in!
            </LoggedInTemplate>
        </asp:LoginView>
    
    </div>
        <p>
            <asp:Image ID="Image1" runat="server" Height="113px" Width="117px" OnPreRender="Image1_PreRender" />
        </p>
    </form>
</body>
</html>
