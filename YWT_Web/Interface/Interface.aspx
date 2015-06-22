<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Interface.aspx.cs" Inherits="YWT.Interface.Interface" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
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
        }
        .listTable td
        {
            padding: 0 2px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <table class="listTable" cellspacing="0" rules="all" border="1"  style="width:100%;border-collapse:collapse;">
        <%=sb.ToString()%>
     </table>
    </div>
    </form>
</body>
</html>
