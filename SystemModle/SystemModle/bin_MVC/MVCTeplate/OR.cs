using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Text;
using App.Framework;
using App.Framework.Data;
using App.Framework.Security;

namespace CSC.Business
{
	 public class <#ClassName>ListModel
    {
        public BusinessList<<#ClassName>Model> <#ClassName>List
        {
            get;
            set;
        }

        public Search<#ClassName>Criteria Search<#ClassName>
        {
            get;
            set;
        }
    }

    public class <#ClassName>Model : DataEntity
    {        
        #region "Field from <#ClassName> table"
		
		<#FieldModel>
				
		#endregion

		#region "Other Field"
		[DbField("RecordStatus")]
		public string RecordStatus { get; set; }		

		[DbField("CREATED_BY_NAME")]
		public string CreatedByName { get; set; }

		[DbField("LAST_UPDATED_BY_NAME")]
		public string LastUpdatedByName { get; set; }
		#endregion

		public override DataCriteria CreateSaveCriteria()
		{
			return new Save<#ClassName>Criteria(this);
		}

		public override DataCriteria CreateDeleteCriteria()
		{
			return new Delete<#ClassName>Criteria(this);
		}
	}

	[DbCommand("spSearch<#ClassName>")]
	public class Search<#ClassName>Criteria : DataCriteria
	{
	}

	[DbCommand("spSave<#ClassName>")]
	public class Save<#ClassName>Criteria : DataCriteria
	{

		 private <#ClassName>Model m_Parent;
        public Save<#ClassName>Criteria(<#ClassName>Model parent)
		{
			m_Parent = parent;
		}

		<#SaveFilds>

		[DbParameter("CREATED_BY")]
		public long CreatedBy
		{
			get { return App.Framework.Security.User.Current.UserId; }
		}

		[DbParameter("CREATION_DATE")]
		public DateTime CreationDate
		{
			get { return m_Parent.CreationDate; }
			set { m_Parent.CreationDate = value; }
		}

		[DbParameter("LAST_UPDATED_BY")]
		public long LastUpdatedBy
		{
			get { return App.Framework.Security.User.Current.UserId; }
		}

		[DbParameter("LAST_UPDATE_DATE")]
		public DateTime LastUpdateDate
		{
			get { return m_Parent.LastUpdateDate; }
			set { m_Parent.LastUpdateDate = value; }
		}

		[DbParameter("RecordStatus")]
		public string RecordStatus
		{
			get { return m_Parent.RecordStatus; }
			set { m_Parent.RecordStatus = value; }
		}
	}

	[DbCommand("spDelete<#ClassName>")]
	public class Delete<#ClassName>Criteria : DataCriteria
	{
		private <#ClassName>Model m_Parent;

		public Delete<#ClassName>Criteria(<#ClassName>Model parent)
		{
			m_Parent = parent;
		}

		[DbParameter("<#Key>")]
		public long <#KeyFormat>
		{
			get { return m_Parent.<#KeyFormat>; }
			set { m_Parent.<#KeyFormat> = value; }
		}
	}

	[DbCommand("spLoad<#ClassName>")]
	public class Load<#ClassName>Criteria : DataCriteria
	{
		[DbParameter("<#Key>")]
		public long <#KeyFormat> { get; set; }
	}
}
