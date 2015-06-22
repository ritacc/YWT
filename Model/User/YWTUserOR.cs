using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace YWT.Model.User
{
    public class YWTUserOR
    {
      

            /// <summary>
            /// 
            /// </summary>
            public string ID { get; set; }

            public long UserAutoID { get; set; }
            /// <summary>
            /// 用户名
            /// </summary>
            public string UserName { get; set; }
            /// <summary>
            /// 密码
            /// </summary>
            public string PassWord { get; set; }
            /// <summary>
            /// 手机号码
            /// </summary>
            public string Mobile { get; set; }
            /// <summary>
            /// 真实姓名
            /// </summary>
            public string RealName { get; set; }
            /// <summary>
            /// 加入日期
            /// </summary>
            public DateTime JoinDateTime { get; set; }
            /// <summary>
            /// 是否可用
            /// </summary>
            public bool Active { get; set; }
            /// <summary>
            /// 用户类型 0普通用户 1供应商 2司机 99管理员
            /// </summary>
            public int UserType { get; set; }
            /// <summary>
            /// 设备IMEI唯一编码
            /// </summary>
            public string IMEI { get; set; }
            /// <summary>
            /// 手机系统版本
            /// </summary>
            public string OS { get; set; }
            /// <summary>
            /// 设备生产商
            /// </summary>
            public string manufacturer { get; set; }
            /// <summary>
            /// 最后登录时间
            /// </summary>
            public DateTime LastLoginTime { get; set; }
            /// <summary>
            /// 对应供应商编号
            /// </summary>
            public string SupplierID { get; set; }

            /// <summary>
            /// 用户头像
            /// </summary>
            public string UserImg { get; set; }

            /// <summary>
            /// 个人认证
            /// </summary>
            public int CertifyPersonal { get; set; }
            /// <summary>
            /// 个人认证 时间
            /// </summary>
            public DateTime CertifyPersonal_Time { get; set; }
            /// <summary>
            /// 承运商认证
            /// </summary>
            public int CertifyEnterprise { get; set; }
            /// <summary>
            /// 承运商认证 时间
            /// </summary>
            public DateTime CertifyEnterprise_Time { get; set; }

            /// <summary>
            /// 审核备注
            /// </summary>
            public string Certify_Rmark { get; set; }

            /// <summary>
            /// 支付密码
            /// </summary>
            public string PayPassword { get; set; }

            /// <summary>
            /// SNRUser构造函数
            /// </summary>
            public YWTUserOR()
            {

                ID = Guid.NewGuid().ToString();
                LastLoginTime = DateTime.Now;
                JoinDateTime = DateTime.Now;
                UserName = "";
                //真实姓名
                RealName = "";
                //用户类型 0普通用户 1供应商 2司机 99管理员           
                UserType = 0;
                //设备IMEI唯一编码
                IMEI = "";
                //手机系统版本
                OS = "";
                //设备生产商
                manufacturer = "";
                //对应供应商编号
                SupplierID = "";

                //UserImg = "";
            }

            /// <summary>
            /// SNRUser构造函数
            /// </summary>
            public YWTUserOR(DataRow row)
            {
                // 
                ID = row["ID"].ToString();
                UserAutoID = Convert.ToInt64(row["UserAutoID"]);
                // 用户名
                UserName = row["UserName"].ToString().Trim();
                // 密码
                //PassWord=row["PassWord"].ToString().Trim();
                // 手机号码
                Mobile = row["Mobile"].ToString().Trim();
                // 真实姓名
                RealName = row["RealName"].ToString().Trim();
                // 加入日期
                if (row["JoinDateTime"] != DBNull.Value)
                    JoinDateTime = Convert.ToDateTime(row["JoinDateTime"]);
                // 是否可用
                if (row["Active"] != DBNull.Value)
                    Active = Convert.ToBoolean(row["Active"]);
                // 用户类型 0普通用户 1供应商 2司机 99管理员
                if (row["UserType"] != DBNull.Value)
                    UserType = Convert.ToInt32(row["UserType"]);
                // 设备IMEI唯一编码
                IMEI = row["IMEI"].ToString().Trim();
                // 手机系统版本
                OS = row["OS"].ToString().Trim();
                // 设备生产商
                manufacturer = row["manufacturer"].ToString().Trim();
                // 最后登录时间
                if (row["LastLoginTime"] != DBNull.Value)
                    LastLoginTime = Convert.ToDateTime(row["LastLoginTime"]);
                // 对应供应商编号
                SupplierID = row["SupplierID"].ToString().Trim();

                UserImg = row["UserImg"].ToString();
                if (string.IsNullOrEmpty(UserImg))
                {
                    UserImg = "/Images/defaultPhoto.png";
                }

                // 个人认证 时间
                if (row["CertifyPersonal"] != DBNull.Value)
                    CertifyPersonal = Convert.ToInt32(row["CertifyPersonal"]);


                if (row["CertifyPersonal_Time"] != DBNull.Value)
                    CertifyPersonal_Time = Convert.ToDateTime(row["CertifyPersonal_Time"]);

                /// 承运商认证
                if (row["CertifyEnterprise"] != DBNull.Value)
                    CertifyEnterprise = Convert.ToInt32(row["CertifyEnterprise"]);

                /// 承运商认证 时间
                if (row["CertifyEnterprise_Time"] != DBNull.Value)
                    CertifyEnterprise_Time = Convert.ToDateTime(row["CertifyEnterprise_Time"]);

                Certify_Rmark = row["Certify_Rmark"].ToString();

                PayPassword = string.IsNullOrEmpty(row["PayPassword"].ToString()) ? "0" : "1";

            }
       

    }
}
