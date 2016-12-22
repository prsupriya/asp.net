<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CitiesForm.aspx.cs" Inherits="MyDbApp.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Label ID="lblMsg" runat="server" /><br />
        <asp:TextBox ID="txtCity" runat="server" /><br />
        <asp:button ID="btnDelete" runat="server" Text="Delete" OnClick="btnDelete_Click" /><asp:button ID="btnEdit" runat="server" Text="Edit" OnClick="btnEdit_Click" /><asp:Button ID="btnEnter" runat="server" Text="Add to the List" OnClick="btnEnter_Click"/><br /><br />
        <asp:DropDownList ID="ddlCities" runat="server" OnSelectedIndexChanged ="ddlCities_IndexChanged" AutoPostBack="true"></asp:DropDownList>
    </div>
    </form>
</body>
</html>
