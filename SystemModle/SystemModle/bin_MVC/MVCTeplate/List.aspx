<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<CSC.Business.<#ClassName>ListModel>" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
	<title>List</title>
	<link href="<%=Url.Content("~/Content/Css/Shared/Common.css")%>" rel="stylesheet" type="text/css" />
	<link href="<%=Url.Content("~/Content/Css/jQuery/dropdownEx.css")%>" rel="stylesheet" type="text/css" />

	<script src="<%=Url.Content("~/Content/Scripts/jQuery/jquery-1.4.1.min.js")%>" type="text/javascript"></script>
	<script src="<%=Url.Content("~/Content/Scripts/jQuery/jquery.Dialog.js")%>" type="text/javascript"></script>
	<script src="<%=Url.Content("~/Content/Scripts/jQuery/jquery.Grid.js")%>" type="text/javascript"></script>
	<script src="<%=Url.Content("~/Content/Scripts/jQuery/jquery.Tabs.js")%>" type="text/javascript"></script>
	<script src="<%=Url.Content("~/Content/Scripts/jQuery/jquery.dropdownEx.js")%>" type="text/javascript"></script> 
	<script src="<%=Url.Content("~/Content/Scripts/Shared/Common.js")%>" type="text/javascript"></script>
	<script src="<%=Url.Content("~/Content/Scripts/Common/Message.js")%>" type="text/javascript"></script>
	<script src="<%=Url.Content("~/Content/Scripts/Common/FrameWindow.js")%>" type="text/javascript"></script>
	<script src="<%=Url.Content("~/Content/Scripts/Common/popDialog.js")%>" type="text/javascript"></script>


	<script type="text/javascript">
		<%Html.EnableSortScript(); %>

		var dlgEdit=null;
		$(function () {
			//Create,Edit,Delete,Audit
			$("div.btn > a").click(function(e) {
				var title = $(this).attr("title"); 
				var href = $(this).attr("href");
				var toolsId = $(this).attr("id");
				var cbs = $("div.grid_list :checkbox:checked:not(:disabled)[name='cbKey']");
				switch (toolsId) {
					case "tool_create":
						dlgEdit = popDialog(href,"<#ClassName>Create",450,350,title);
						break;
					case "tool_edit":
						if (cbs.length !== 1) { 
							alert($g["SelectSingle"]); 
							break; 
						}
						dlgEdit = popDialog(href.replace(/-<#KeyFormat>-/ig, cbs.val()),"<#ClassName>Edit",450,350,title);
						break;
					case "tool_delete":
						if (cbs.length !== 1) { 
							alert($g["SelectSingle"]); 
							break; 
						}
						if (window.confirm($g["DeleteConfirm"])) {
							href = "<%=Url.Content("~/<#ClassName>/<#ClassName>Delete?<#KeyFormat>=-<#KeyFormat>-")%>";
							var deleteDiv = getDeleteDiv();
							return loadFrame(deleteDiv, href.replace(/-<#KeyFormat>-/ig, cbs.val()), true, true);
						}
						break;
					case "tool_audit":
						if (cbs.length !== 1) { 
							alert($g["SelectSingle"]); 
							break; 
						}
						href = href.replace(/-CreatedBy-/ig, cbs.attr("CreatedBy"));
						href = href.replace(/-CreationDate-/ig, cbs.attr("CreationDate"));
						href = href.replace(/-LastUpdatedBy-/ig, cbs.attr("LastUpdatedBy"));
						href = href.replace(/-LastUpdateDate-/ig, cbs.attr("LastUpdateDate"));
						dlgEdit = popDialog(href,"Audit",360,175,title);
						break;
				};
				e.preventDefault();
			});
		});
	</script>
</head>
<body>
<div class="centra">
    <div class="search">
	    <%Html.BeginForm("<#ClassName>List", "<#ClassName>", FormMethod.Get);%>
		<table>
			<tr>
				
				<td>
					<input type="submit" value="<%:GlobalText.BtnSearchText %>" />
					<%Html.Button(GlobalText.BtnResetText, "reset", Url.Content("~/<#ClassName>/Index"));%>
				</td>				
			</tr>
		</table>
		<%Html.EndForm();%>
	</div>
    <div class="menu">
		<ul>
			<li class="b">
				<div class="btn">
					
					<%if (QuickInvoke.GetCurrentUserHasPermission(EnumPermission.CSCP02030_Add)){ %>
						<%=Html.ActionLink(GlobalText.BtnCreateText, "<#ClassName>Create", "<#ClassName>", null, new { @class = "tool_create", @id = "tool_create", @Title =GlobalText.BtnCreateText })%>	
					<%} %>
					
					<%if (QuickInvoke.GetCurrentUserHasPermission(EnumPermission.CSCP02030_Edit)){ %>
						<%=Html.ActionLink(GlobalText.BtnEditText, "<#ClassName>Edit", "<#ClassName>", new { @<#KeyFormat> = "-<#KeyFormat>-" }, new { @class = "tool_edit", @id = "tool_edit",  @Title = GlobalText.BtnEditText })%>
					<%} %>
					
					<%if (QuickInvoke.GetCurrentUserHasPermission(EnumPermission.CSCP02030_Delete)){ %>
						<a id="tool_delete" class="tool_delete" title="<%=ResultCodeText.Title_Delete %>" href="#"><%=GlobalText.BtnDeleteText %></a>
					<%} %>
					
					<%if (QuickInvoke.GetCurrentUserHasPermission(EnumPermission.CSCP02030_View)){ %>
						<%=Html.ActionLink(GlobalText.BtnAuditText, "Index", "Audit", new { @CreatedBy = "-CreatedBy-", @CreationDate = "-CreationDate-", @LastUpdatedBy = "-LastUpdatedBy-", @LastUpdateDate = "-LastUpdateDate-" }, new { @class = "tool_audit", @id = "tool_audit", @Title = GlobalText.BtnAuditText })%>
					<%} %>
				</div>
			</li>
		</ul>
	</div>
    <div class="grid_list">
		<table>
			<thead>
				<tr>
					<th class="w20 t_center"></th>
					<#thList>
					<%--<th class="w100 t_left sort">
						<% Html.Sort(<#ClassName>Text.Bin_Loc_Code, "Godown_Code", 0);%>
					</th>--%>
					<th></th>
				</tr>
			</thead>
			<tbody>
				<% if (Model.<#ClassName>List != null){ %>
						<%foreach (var item in Model.<#ClassName>List){%>
							<tr>
								<td class="t_center">
									<input type="checkbox" name="cbKey" value="<%=item.<#KeyFormat>%>" CreatedBy="<%=item.CreatedByName%>" CreationDate="<%=item.CreationDate %>" LastUpdatedBy="<%=item.LastUpdatedByName %>" LastUpdateDate="<%=item.LastUpdateDate %>"/>
								</td>
<#tdlist>
								<td></td>
							</tr>
						<% } %>
				<% } %>
			</tbody>
		</table>
	</div>
	<div class="pager">
		<%=Html.QuickPager()%>
	</div>
</div>
</body>
</html>