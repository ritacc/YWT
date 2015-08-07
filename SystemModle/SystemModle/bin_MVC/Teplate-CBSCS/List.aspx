<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="<#ClassName>.aspx.cs" Inherits="<#ClaseNameSpace>.<#ClassName>List" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register TagPrefix="webdiyer" Namespace="Wuqi.Webdiyer" Assembly="AspNetPager" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title><#ClassTitle>列表</title>
    <link href="/include/style_public.css" rel="stylesheet" type="text/css" />
    <script language="JavaScript" src="/include/jquery-1.4.1.js" type="text/javascript"></script>
    <script language="JavaScript" src="/include/jquery.validator.js" type="text/javascript"></script>
    <script language="JavaScript" src="/include/DatePicker/WdatePicker.js" type="text/javascript"></script>
    <script type="text/javascript" src="/include/zDialog/zDialog.js"></script>
    <script type="text/javascript" src="/include/zDialog/common.js"></script>
    <script type="text/javascript">
        function RefreshWin() {
            $("#btnSearch").click();
        }
        $(document).ready(function () {
            $("#btnAdd").click(function () {
                openDlg("<#ClassName>Edit.aspx", { title: "<#ClassTitle>管理", width: 600, height: 500 });
            });
           

            $(".itmeEdit").each(function (i, o) {
                var obj = $(o);
                obj.click(function () {
                var murl = "<#ClassName>Edit.aspx?id=" + obj.attr("id");
                    openDlg(murl, { title: "<#ClassTitle>管理", width: 600, height: 500 });
                 });
            });

        });
       
    </script>
    <style type="text/css">
        .iscomfim{font-family:webdings;color:red;line-height:14px}
         
        .Lock10, .Lock0{background:#ecf5ff;}
        .Lock11,.Lock1{background:#efffd7;}
        .tdTitle{ padding-left:5px; padding-right:2px;}
    </style>
</head>
<body>
    <form id="form1" runat="server">
     <div>
         
               <h1><#ClassTitle>列表</h1>
     </div>
    <table border="0" cellpadding="0" cellspacing="0" style="width: 100%;">
        <tr>
            <td>
                <table>
                    <tr>
                        <td class="tdTitle">
                            <nobr>查询：</nobr>
                        </td>
                        <td>
                            <asp:TextBox ID="txtStart" onfocus="WdatePicker();" runat="server" Style="width: 80px"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="txtEnd" onfocus="WdatePicker();" runat="server" Style="width: 80px"></asp:TextBox>
                        </td> 
                        <td>
                            <asp:Button runat="server" ID="btnSearch" Text="查询" CssClass="btn" OnClientClick="return $.yz.getErrorList()"
                                OnClick="btnSearch_Click" />
                        </td>
                    </tr>
                </table>
            </td>
            <td class="w70">
                <input type="button" id="btnAdd" class="btn" value="添加" />
            </td>
        </tr>
    </table>
    <div  id="HKoutData">

        <table class="listTable" cellspacing="0" rules="all" border="1"  style="width:100%;border-collapse:collapse;">
            <tr>
                <th class="w40">序号</th>
                <#GridViewTh>
            </tr>
               <%
                    int index=0; 
                    if (dt != null) foreach (System.Data.DataRow row in dt.Rows)
                    {
                    index++;
                  %>
                  <tr class="GridItems">
                    <td class="ac"><%= index %></td>
                    <td>
                        <a href="javascript:void(0);" id="<%= row["<#keyFild>"]%>" class="itmeEdit"><%= row["<#keyFild>"]%></a>
                    </td>
                    <#BoundFieldItem>
              </tr>
            <%} %>            
        </table> 
    </div>
     <div class=" divpublic">
        <webdiyer:AspNetPager ID="pager" runat="server" Width="100%" LastPageText="尾页" FirstPageText="首页"
            NumericButtonCount="5" PrevPageText="上一页" NextPageText="下一页" PageSize="200" ShowNavigationToolTip="False"
            ShowPageIndex="False" ShowCustomInfoSection="Left" AlwaysShow="True" CssClass="pagerStyle"
            OnPageChanged="pager_PageChanged">
        </webdiyer:AspNetPager>
    </div>
    </form>
</body>
</html>
