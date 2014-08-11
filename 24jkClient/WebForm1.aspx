<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="_24jkClient.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div style="height: 271px">
        
        <asp:FileUpload ID="FileUpload1" runat="server" />
    
        <br />
        <asp:Label ID="Label1" runat="server"></asp:Label>
        <br/>
        <asp:Button ID="Button1" runat="server" Text="to the DB!" OnClick="Button1_Click" />
        
        <asp:Button ID="Button4" runat="server" OnClick="Button4_Click" Text="Button" />
        
        <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="show me dem files!" />
        <br />
        <br />
        <asp:ListBox ID="ListBox1" runat="server" Height="169px" Width="195px" OnSelectedIndexChanged="ListBox1_SelectedIndexChanged"></asp:ListBox>

        <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="download this file" />
            
   
        <asp:Image ID="Image1" runat="server" ImageUrl="" />
            
    </div>
    </form>
</body>
</html>

