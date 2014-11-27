<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Test.aspx.cs" Inherits="Test" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Label ID="lblDone" runat="server" Text="Label"></asp:Label><br />
        <br />
        <asp:Button ID="btnSubmit" runat="server" Text="Skapa" OnClick="btnSubmit_Click" />
    </div>
    </form>
</body>
</html>
