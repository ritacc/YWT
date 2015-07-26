<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Interface.aspx.cs" Inherits="YWT.Interface.Interface" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>运维通接口</title>
    <style type="text/css">
        .listTable{
            border-collapse: collapse;
            font-size: 12px;
            line-height: 18px;
            color: #000;
            border-right: 1px solid #808080;       
            /*border-bottom: 1px solid #808080;*/
        }

        .listTable th,.listTable th
        {
            color:#666666;
            border-top: 1px solid #cdcdcd;
            border-left: 1px solid #cdcdcd;
            border-right: 1px solid #cdcdcd;
            border-bottom: 1px solid #cdcdcd;
            font-weight:bold;
            text-shadow: 0 1px 0 #ffffff;
	        background-color: #efefef;
	        background-image: -webkit-gradient(linear, 0 0%, 0 100%, from(#fdfdfd), to(#eaeaea));
	        background-image: -webkit-linear-gradient(top, #fdfdfd 0%, #eaeaea 100%);
            background-image: -moz-linear-gradient(top, #fdfdfd 0%, #eaeaea 100%);
            background-image: -ms-linear-gradient(top, #fdfdfd 0%, #eaeaea 100%);
            background-image: -o-linear-gradient(top, #fdfdfd 0%, #eaeaea 100%);
            background-image: -linear-gradient(top, #fdfdfd 0%, #eaeaea 100%);
            filter: progid:DXImageTransform.Microsoft.gradient( startColorstr='#fdfdfd', endColorstr='#eaeaea',GradientType=0 ); /* IE6-9 */
            height: 28px;
            }


        .listTable td{
            border-left: 1px solid #e8e8e8;
            border-right: 1px solid #e8e8e8;
            border-bottom: 1px solid #e8e8e8;
            color:#292929;
            line-height:24px;
            font-size: 12px;
        }
        .listTable td
        {
            
            padding: 0 2px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div> <a href="/T.aspx">字段查询</a>&nbsp;<a href="/ywt/start.html">设计主页</a></div>
    <div><a href="http://pre.im/d5a5">测试地址</a>
        
    </div>

    <div>
    <table class="listTable" cellspacing="0" rules="all" border="1"  style="width:100%;border-collapse:collapse;">
        <tr><td colspan="2" style=" line-height:0px;">&nbsp;</td></tr>
        <%=sb.ToString()%>
     </table>
    </div>
    </form>
</body>
</html>
