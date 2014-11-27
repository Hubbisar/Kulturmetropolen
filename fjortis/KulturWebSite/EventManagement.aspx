<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EventManagement.aspx.cs" Inherits="EventManagement" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:TextBox ID="title" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator runat="server"
            ControlToValidate="title"
            ErrorMessage="Rubrik krävs."> *
        </asp:RequiredFieldValidator>

        <asp:TextBox ID="content" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator runat="server"
            ControlToValidate="content"
            ErrorMessage="Innehåll krävs."> *
        </asp:RequiredFieldValidator>

        <asp:TextBox ID="image" runat="server"></asp:TextBox>
        <asp:FileUpload ID="imageUpload" runat="server" />

        <asp:TextBox ID="category" runat="server">
        </asp:TextBox>
        <asp:RequiredFieldValidator runat="server"
            ControlToValidate="category"
            ErrorMessage="Kategori krävs."> *</asp:RequiredFieldValidator>

        <asp:TextBox ID="date" runat="server"></asp:TextBox>
        <asp:TextBox ID="city" runat="server"></asp:TextBox>
        <asp:TextBox ID="location" runat="server"></asp:TextBox>
    </div>
    </form>
</body>
</html>
