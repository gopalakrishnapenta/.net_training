<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TestPage1.aspx.cs" Inherits="WebApplication1.TestPage1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1> Test Page 1</h1>
            Name :<asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            <hr />
            <input id="Submit1" type="submit" value="submit" />
        </div>
    </form>
</body>
</html>
