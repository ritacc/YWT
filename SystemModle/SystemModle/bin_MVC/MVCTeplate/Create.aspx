<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<CSC.Business.<#ClassName>Model>" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
	<title>Create</title>

	<link href="<%=Url.Content("~/Content/Css/Shared/Common.css") %>" rel="stylesheet" type="text/css" />
	<link href="<%=Url.Content("~/Content/Css/Shared/Form.css")%>" rel="stylesheet" type="text/css" />
	<link href="<%=Url.Content("~/Content/Css/jQuery/dropdownEx.css")%>" rel="stylesheet" type="text/css" />
	<link href="<%=Url.Content("~/Content/Css/Shared/Edit.css")%>" rel="stylesheet" type="text/css" />

	<script src="<%=Url.Content("~/Content/Scripts/jQuery/jquery-1.4.1.min.js") %>" type="text/javascript"></script>
	<script src="<%=Url.Content("~/Content/Scripts/jQuery/jquery.Tabs.js") %>" type="text/javascript"></script>
	<script src="<%=Url.Content("~/Content/Scripts/jQuery/jquery.Grid.js") %>" type="text/javascript"></script>
	<script src="<%=Url.Content("~/Content/Scripts/jQuery/jquery.dialog.js") %>" type="text/javascript"></script>
	<script src="<%=Url.Content("~/Content/Scripts/Common/FrameWindow.js")%>" type="text/javascript"></script>
	<script src="<%=Url.Content("~/Content/Scripts/Shared/Calendar.js")%>" type="text/javascript"></script>
	<script src="<%=Url.Content("~/Content/Scripts/Common/popDialog.js")%>" type="text/javascript"></script>
	<script src="<%=Url.Content("~/Content/Scripts/Common/Message.js")%>" type="text/javascript"></script>
	<script src="<%=Url.Content("~/Content/Scripts/jQuery/jquery.dropdownEx.js")%>" type="text/javascript"></script>
	<script src="<%=Url.Content("~/Content/Scripts/Shared/Common.js") %>" type="text/javascript"></script>
	<script src="<%:Url.Content("~/Content/Scripts/jquery/jquery-SimpleValidForm.js") %>" type="text/javascript"></script>
	<script src="<%:Url.Content("~/Content/Scripts/jquery/jquery-SimpleValidMethod.js") %>" type="text/javascript"></script>

	<%Html.EnableClientValidation(); %>
	<script type="text/javascript">
		window.checkFormChanged = true;
		
		window.btnSureClick = function (sucessed, redirectUrl) {
			if (sucessed) {
				window.parent.$("#tabSummary").find("iframe")[0].contentWindow.dlgEdit.close(function () {
					window.parent.loadFrame(window.parent.$("#tabSummary"), null, true);
				});
			}
		};
		
		$(function () {
			<%=Html.Message() %> 

			$("#btnCancel").click(function () {
				window.parent.$("#tbSalesMemoDetails").find("iframe")[0].contentWindow.dlgEdit.close();
				return false;
			});
		});
	</script>
</head>
<body>
	<%Html.BeginForm("<#ClassName>Create", "<#ClassName>", FormMethod.Post);%>
    <div class="centra">
       <table style="margin-left: 20px; margin-top: 10px;">
            <#EditTr>
        </table>
    </div>
	<div id="Message" class="message">
	</div>
	<div class="bottom dialog-buttons">
		<table width="100%">
			<tr>
				<td align="center">
					<% Html.Submit(GlobalText.BtnSaveText,"btnSave"); %>
					&nbsp;
					<% Html.ReturnButton(GlobalText.btnCancelText, "btnCancel", null); %>
				</td>
			</tr>
		</table>
	</div>
	<%Html.EndForm();%>
</body>
</html>
