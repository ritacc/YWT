<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="T.aspx.cs" Inherits="YWT.T" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <table>
    <tr>
        <td style=' width:60px;'></td>
    </tr>
    </table>
      <asp:TextBox TextMode="MultiLine" runat="server"  ID="txt"  Height="85px" 
            Width="680px"></asp:TextBox>
     
    </div>
    <div>
        表名:<asp:DropDownList ID="dbdtable" Width="200" runat="server">
        </asp:DropDownList>
       <asp:Button ID="Button1" runat="server" Text="查询" onclick="Button1_Click" 
            Width="77px" />
        
        
        <asp:GridView ID="gdcolumns"  Width="1000" runat="server"  AutoGenerateColumns="false" >
            <Columns>
                <asp:BoundField  HeaderText="NO"  DataField="co_num"/>
                <asp:BoundField  HeaderText="字段"  DataField="column_name"/>
                
                <asp:BoundField  HeaderText="数据类型"  DataField="data_type"/>
                <asp:BoundField  HeaderText="长度"  DataField="data_length"/>
                <asp:BoundField  HeaderText="描述"  DataField="comments1"/>
                <asp:BoundField  HeaderText="是否可为空"  DataField="nullable"/>
                
            </Columns>
        </asp:GridView>
    </div>

    </form>
</body>
</html>
