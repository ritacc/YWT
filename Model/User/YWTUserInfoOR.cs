using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace YWT.Model.User
{
    /// <summary>
    /// 
    /// </summary>
    public class YWTUserInfoOR
    {
        /// <summary>
        /// 真实姓名    来处User表
        /// </summary>
        public string RealName { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public string YWTUser_ID { get; set; }
		/// <summary>
		/// 性别
		/// </summary>
		public string User_Sex { get; set; }
		/// <summary>
		/// 所在地-省
		/// </summary>
		public string Location_Province { get; set; }
		/// <summary>
		/// 所在地-市
		/// </summary>
		public string Location_City { get; set; }
		/// <summary>
		/// 所在地-区
		/// </summary>
		public string Location_County { get; set; }
		/// <summary>
		/// 出生年月日
		/// </summary>
		public DateTime Birthday { get; set; }
		/// <summary>
		/// 详细地址
		/// </summary>
		public string User_Address { get; set; }
		/// <summary>
		/// Email
		/// </summary>
		public string Email { get; set; }
		/// <summary>
		/// 最高学历
		/// </summary>
		public string HighestEducation { get; set; }
		/// <summary>
		/// 毕业学院
		/// </summary>
		public string Finish_School { get; set; }
		/// <summary>
		/// 专业名称
		/// </summary>
		public string SpecialtyName { get; set; }
		/// <summary>
		/// 毕业时间
		/// </summary>
		public DateTime? GraduationData { get; set; }
		/// <summary>
		/// 技能描述
		/// </summary>
		public string SkillDescription { get; set; }
		/// <summary>
		/// 专长
		/// </summary>
		public string Specialty { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public string Create_User { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public DateTime Create_Date { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public string Last_Modify_User { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public DateTime Last_Modify_Date { get; set; }
		/// <summary>
		/// UserInfo构造函数
		/// </summary>
		public YWTUserInfoOR()
		{

		}

		/// <summary>
		/// UserInfo构造函数
		/// </summary>
		public YWTUserInfoOR(DataRow row)
		{
			// 
			YWTUser_ID=row["YWTUser_ID"].ToString().Trim();
			// 性别
			User_Sex=row["User_Sex"].ToString().Trim();
			// 所在地-省
			Location_Province=row["Location_Province"].ToString().Trim();
			// 所在地-市
			Location_City=row["Location_City"].ToString().Trim();
			// 所在地-区
			Location_County=row["Location_County"].ToString().Trim();
			// 出生年月日
			if(row["Birthday"]!= DBNull.Value)
                Birthday=Convert.ToDateTime(row["Birthday"]);
			// 详细地址
			User_Address=row["User_Address"].ToString().Trim();
			// Email
			Email=row["Email"].ToString().Trim();
			// 最高学历
			HighestEducation=row["HighestEducation"].ToString().Trim();
			// 毕业学院
			Finish_School=row["Finish_School"].ToString().Trim();
			// 专业名称
			SpecialtyName=row["SpecialtyName"].ToString().Trim();
			// 毕业时间
			if(row["GraduationData"]!= DBNull.Value)
                GraduationData=Convert.ToDateTime(row["GraduationData"]);
			// 技能描述
			SkillDescription=row["SkillDescription"].ToString().Trim();
			// 专长
			Specialty=row["Specialty"].ToString().Trim();
			// 
			Create_User=row["Create_User"].ToString().Trim();
			// 
			if(row["Create_Date"]!= DBNull.Value)
                Create_Date=Convert.ToDateTime(row["Create_Date"]);
			// 
			Last_Modify_User=row["Last_Modify_User"].ToString().Trim();
			// 
			if(row["Last_Modify_Date"]!= DBNull.Value)
                Last_Modify_Date=Convert.ToDateTime(row["Last_Modify_Date"]);
		}
    }
}

