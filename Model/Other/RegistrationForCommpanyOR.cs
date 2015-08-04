using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace YWT.Model.Other
{
    public class RegistrationForCommpanyOR
    {
        /// <summary>
		/// 
		/// </summary>
		public long Registration_ID { get; set; }
		/// <summary>
		/// 打卡人ID
		/// </summary>
		public string UserID { get; set; }
        ///// <summary>
        ///// 坐标x
        ///// </summary>
        //public string latitude { get; set; }
        ///// <summary>
        ///// 坐标Y
        ///// </summary>
        //public string longitude { get; set; }
		/// <summary>
		/// 签到位置
		/// </summary>
		public string Position { get; set; }
		/// <summary>
		/// 手机IMEI
		/// </summary>
		public string IMEI { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public DateTime Create_Date { get; set; }

          /// <summary>
        /// 创建人姓名
        /// </summary>
        public string RealName { get; set; }
        /// <summary>
        /// 创建人头像
        /// </summary>
        public string UserImg { get; set; }

		/// <summary>
		/// Registration构造函数
		/// </summary>
		public RegistrationForCommpanyOR()
		{

		}

		/// <summary>
		/// Registration构造函数
		/// </summary>
        public RegistrationForCommpanyOR(DataRow row)
		{
			// 
			if(row["Registration_ID"]!= DBNull.Value)
                Registration_ID=Convert.ToInt64(row["Registration_ID"].ToString());
			// 打卡人ID
			UserID=row["UserID"].ToString().Trim();
            //// 坐标x
            //latitude=row["latitude"].ToString().Trim();
            //// 坐标Y
            //longitude=row["longitude"].ToString().Trim();
			// 签到位置
			Position=row["Position"].ToString().Trim();
			// 手机IMEI
			IMEI=row["IMEI"].ToString().Trim();
			// 
			if(row["Create_Date"]!= DBNull.Value)
                Create_Date=Convert.ToDateTime(row["Create_Date"]);

            RealName = row["RealName"].ToString();
            UserImg = row["UserImg"].ToString();
		}
    }
}
