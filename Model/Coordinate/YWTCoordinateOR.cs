using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace YWT.Model.Coordinate
{
   public class YWTCoordinateOR
    {
       /// <summary>
		/// 
		/// </summary>
		public string ID { get; set; }
		/// <summary>
		/// 经度
		/// </summary>
		public string longitude { get; set; }
		/// <summary>
		/// 纬度
		/// </summary>
		public string latitude { get; set; }
		/// <summary>
		/// 创建时间
		/// </summary>
		public DateTime CreateDateTime { get; set; }

        public string X { get; set; }
        public string Y { get; set; }
        public string U { get; set; }
		/// <summary>
		/// 车辆编号
		/// </summary>
		public string CarID { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public string UserID { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public string IMEI { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public string OS { get; set; }
		/// <summary>
		/// 
		/// </summary>
        public string manufacturer { get; set; }

       /// <summary>
       /// 自动ID
       /// </summary>
        public long UserAutoID { get; set; }

		/// <summary>
		/// SNRCoordinate构造函数
		/// </summary>
		public YWTCoordinateOR()
		{
            CarID = "";
            IMEI = "";
            OS = "";
            manufacturer = "";
             
		}

		/// <summary>
		/// SNRCoordinate构造函数
		/// </summary>
        public YWTCoordinateOR(DataRow row)
		{
			// 
			ID=row["ID"].ToString().Trim();
			// 经度
			longitude=row["longitude"].ToString().Trim();
			// 纬度
			latitude=row["latitude"].ToString().Trim();
			// 创建时间
			if(row["CreateDateTime"]!= DBNull.Value)
                CreateDateTime=Convert.ToDateTime(row["CreateDateTime"]);
			// 车辆编号
			CarID=row["CarID"].ToString().Trim();
			// 
			UserID=row["UserID"].ToString().Trim();
			// 
			IMEI=row["IMEI"].ToString().Trim();
			// 
			OS=row["OS"].ToString().Trim();
			// 
            manufacturer = row["manufacturer"].ToString().Trim();
            // 经度
            //gaodeLongitude = row["gaodeLongitude"].ToString().Trim();
            //// 纬度
            //gaodeLatitude = row["gaodeLatitude"].ToString().Trim();
		}
    }
}
