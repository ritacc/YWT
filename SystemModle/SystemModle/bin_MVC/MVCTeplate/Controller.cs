using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using App.Framework;
using App.Framework.Web;
using App.Framework.Web.Filters;
using CSC.Code;
using CSC.Business;
using CSC.Resources;

/*
 <#ClassName>
 */
namespace CSC.Controllers
{
	public class <#ClassName>Controller : XController
	{
		#region "Index Page"
		[AuthorizationFilter((int)EnumPermission.CSCP02030_View)]
		public ActionResult <#ClassName>List(<#ClassName>ListModel model)
		{
			model = model ?? new <#ClassName>ListModel();
			model.Search<#ClassName> = model.Search<#ClassName> ?? new Search<#ClassName>Criteria();
			var search<#ClassName> = new Search<#ClassName>Criteria()
			{
			};

			//…Ë÷√≈≈–Ú
			List<Comparison<<#ClassName>Model>> compList = new List<Comparison<<#ClassName>Model>>();
			//compList.Add((x, y) => x.<#ClassName>Code.CompareTo(y.<#ClassName>Code));
			//compList.Add((x, y) => x.BinLocCode.CompareTo(y.BinLocCode));

			//…Ë÷√ª∫¥Ê
			model.<#ClassName>List = SessionCache.Instance.GetOrSetCache<BusinessList<<#ClassName>Model>>("<#ClassName>List",
				() => BusinessPortal.Search<<#ClassName>Model>(search<#ClassName>), !this.IsSortingOrPageing());

			return ViewList(model, (pageparams) =>
			{
				int recordCount;
				pageparams.SecondSortFields = new List<KeyValuePair<int, SortDirectionEnum>>() { };
				pageparams.SecondSortFields.Add(new KeyValuePair<int, SortDirectionEnum>(0, SortDirectionEnum.Asc));

				model.<#ClassName>List = model.<#ClassName>List.Page(pageparams, out recordCount, compList);
				return recordCount;
			});
		}

		#endregion

		#region "Create Page"

		[AuthorizationFilter((int)EnumPermission.CSCP02030_Add)]
		public ActionResult <#ClassName>Create()
		{
			return View();
		}

		[AuthorizationFilter((int)EnumPermission.CSCP02030_Add)]
		[HttpPost]
		public ActionResult <#ClassName>Create(<#ClassName>Model model)
		{
			try
			{
				if (!ModelState.IsValid)
				{
					return View(model);
				}

				model.RecordStatus = EnumRecordStatus.ADD.ToString();
				BusinessResult result = BusinessPortal.Save(model);
				if (result.ResultType == 0)
				{
					SessionCache.Instance.Remove("<#ClassName>List");
					this.ShowMessageEx(BusinessResultMessage.INF_SAVE_SUCCEED, isSucessed: true);
				}
				else if (result.ResultType == -9999)
				{
					this.ShowMessageEx(BusinessResultMessage.INF_SAVE_FAILED, isSucessed: false);
				}
				else
				{
					this.ShowMessageEx(result.GetMessage(), isSucessed: false);
				}

				return View(model);
			}
			catch (Exception ex)
			{
				this.ShowMessage(ex.Message, isSucessed: false);
				return View(model);
			}
		}

		#endregion

		#region "Edit Page"

		[AuthorizationFilter((int)EnumPermission.CSCP02030_Edit)]
		public ActionResult <#ClassName>Edit()
		{
			var loadBrandCode = new Load<#ClassName>Criteria()
			{
				<#KeyFormat> = long.Parse(Request.QueryString["<#KeyFormat>"])
			};
			var model = BusinessPortal.Load<<#ClassName>Model>(loadBrandCode);

			return View(model);
		}

		[AuthorizationFilter((int)EnumPermission.CSCP02030_Edit)]
		[HttpPost]
		public ActionResult <#ClassName>Edit(<#ClassName>Model model)
		{
			try
			{
				if (!ModelState.IsValid)
				{
					return View(model);
				}

				model.RecordStatus = EnumRecordStatus.EDIT.ToString();
				BusinessResult result = BusinessPortal.Save(model);
				if (result.ResultType == 0)
				{
					SessionCache.Instance.Remove("<#ClassName>List");
					this.ShowMessageEx(BusinessResultMessage.INF_SAVE_SUCCEED, isSucessed: true);
				}
				else if (result.ResultType == -9999)
				{
					this.ShowMessageEx(BusinessResultMessage.INF_SAVE_FAILED, isSucessed: false);
				}
				else
				{
					this.ShowMessageEx(result.GetMessage(), isSucessed: false);
				}

				return View(model);
			}
			catch (Exception ex)
			{
				this.ShowMessage(ex.Message, isSucessed: false);
				return View(model);
			}
		}

		#endregion

		#region "Delete Function"

		[AuthorizationFilter((int)EnumPermission.CSCP02030_Delete)]
		public ActionResult <#ClassName>Delete()
		{
			try
			{
				if (string.IsNullOrEmpty(Request.QueryString["<#KeyFormat>"].ToString()))
				{
					throw new Exception();
				}
				var brandCodeModel = new <#ClassName>Model()
				{
					<#KeyFormat> = long.Parse(Request.QueryString["<#KeyFormat>"].ToString())
				};

				BusinessResult result = BusinessPortal.Delete(brandCodeModel);
				if (result.ResultType == 0)
				{
					SessionCache.Instance.Remove("<#ClassName>List");
					return this.ShowMessageResult(BusinessResultMessage.INF_DELETE_SUCCEED, isSucessed: true, btnSureClickScript: "window.parent.loadFrame(window.parent.$(\"#tb<#ClassName>List\"), null, true);");
				}
				else if (result.ResultType == -9999)
				{
					return this.ShowMessageResult(BusinessResultMessage.INF_DELETE_FAILED, isSucessed: false);
				}
				else
				{
					return this.ShowMessageResult(result.GetMessage(), isSucessed: false);
				}
			}
			catch (Exception ex)
			{
				this.ShowMessage(ex.Message, isSucessed: false);
				return this.Message(ex.Message);
			}
		}

		#endregion

	}
}