using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace YWT.Model.User
{
    /// <summary>
    /// 运维商用户信息
    /// </summary>
  public  class YWTSupplierUserOR : YWTUserInfoOR
    {

        /// <summary>
        /// 
        /// </summary>
        public string ID { get; set; } 
        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { get; set; }
        
        /// <summary>
        /// 手机号码
        /// </summary>
        public string Mobile { get; set; }
        /// <summary>
        /// 真实姓名
        /// </summary>
        public new string RealName { get; set; }
        
        /// <summary>
        /// 是否可用
        /// </summary>
        public bool Active { get; set; }
        /// <summary>
        /// 用户类型 0普通用户 1供应商 2司机 99管理员
        /// </summary>
        public int UserType { get; set; }
       
        /// <summary>
        /// 对应供应商编号
        /// </summary>
        public string SupplierID { get; set; }

        /// <summary>
        /// 用户头像
        /// </summary>
        public string UserImg { get; set; }

      public YWTSupplierUserOR(DataRow row)
          : base(row)
      {
          ID = row["ID"].ToString();
          // 用户名
          UserName = row["UserName"].ToString().Trim();
          // 密码
          //PassWord=row["PassWord"].ToString().Trim();
          // 手机号码
          Mobile = row["Mobile"].ToString().Trim();
          // 真实姓名
          RealName = row["RealName"].ToString().Trim();
      
          // 是否可用
          if (row["Active"] != DBNull.Value)
              Active = Convert.ToBoolean(row["Active"]);
          // 用户类型 0普通用户 1供应商 2司机 99管理员
          if (row["UserType"] != DBNull.Value)
              UserType = Convert.ToInt32(row["UserType"]);
 
          // 对应供应商编号
          SupplierID = row["SupplierID"].ToString().Trim(); 

          UserImg = row["UserImg"].ToString();
          if (string.IsNullOrEmpty(UserImg))
          {
              UserImg = "/Images/defaultPhoto.png";
          } 
          
      }
    }
}
