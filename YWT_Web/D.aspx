<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="D.aspx.cs" Inherits="YWT.D" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    
    <div>
        表名:<asp:DropDownList ID="dbdtable" Width="200" runat="server">
        </asp:DropDownList>
       <asp:Button ID="Button1" runat="server" Text="查询" onclick="Button1_Click" 
            Width="77px" />
        
        
        <asp:GridView ID="gdcolumns"  Width="1000" runat="server"  AutoGenerateColumns="true" />
    </div>

    </form>
</body>
</html>
