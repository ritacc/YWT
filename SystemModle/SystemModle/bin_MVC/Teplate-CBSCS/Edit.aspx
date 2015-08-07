<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="<#ClassName>Edit.aspx.cs" Inherits="<#ClaseNameSpace>.<#ClassName>Edit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title><#ClassTitle>信息</title>
    <link href="/include/zDialog/jquery.Dialog.Main.css" rel="Stylesheet" />
    <link href="/include/style_public.css" rel="stylesheet" type="text/css" />

    <script language="JavaScript" src="/include/jquery-1.4.1.js" type="text/javascript"></script>
    <script language="JavaScript" src="/include/cbscs.utils.js" type="text/javascript"></script>
    <script language="JavaScript" src="/include/jquery.validator.js?1111222" type="text/javascript"></script>
    <script language="JavaScript" src="/include/DatePicker/WdatePicker.js" type="text/javascript"></script>
    <script type="text/javascript" src="/include/zDialog/zDialog.js"></script>
    <script type="text/javascript" src="/include/zDialog/jquery.Dialog.Main.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $("#btnClose").click(function () {
                window.parent.Dialog.close();
            });

            $("#btnDelete").click(function () { return confirm("您确定要删除此记录吗？"); });
            $("#btnLock").click(function () { return confirm("您确定要锁定此记录吗？"); });

<#yzList>
        });
    </script>
    <style type="text/css">
        .tButtom input{ height:24px;}
        .tdTitle{ width:120px;}
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div id="pageBody"  class="wdiv">
        <table id="tbContentMain" border="0" cellpadding="0" cellspacing="0" class="window_table">
<#editTrList>
        </table>
    </div>
    <div class="tButtom window_footer_div">
        <asp:Button ID="btnSave" runat="server"  OnClientClick="return $.yz.getErrorList()"  CssClass="btn" Text="保存"  onclick="btnSave_Click" />  
        <asp:Button ID="btnDelete" runat="server"    CssClass="btn" Text="删除"   Visible="false"  onclick="btnDelete_Click" />  
        <!--
	<asp:Button ID="btnLock" runat="server"    CssClass="btn" Text="锁定"  onclick="btnLock_Click" />
        <asp:Button ID="btnUnLock" runat="server"    CssClass="btn" Text="解锁"  onclick="btnUnLock_Click" />
	-->
        <input type="button" class="btn" value="取消" id="btnClose" />
    </div>
    </form>
</body>
</html>
