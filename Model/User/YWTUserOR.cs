﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using YWT.Common;

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

            //public string RealNameChar { get; set; }
            ///// <summary>
            ///// 真实姓名首字母
            ///// </summary>
            //public string GetRealNameChar {
            //    get
            //    {
            //        return GetStringSpell.getSpell(RealName);
            //    }
            //}

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

            #region 认证
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

            public string CertifyStatusName
            {
                get
                {
                    if (UserType == 10)
                    {
                        if (CertifyEnterprise == 99)
                        {
                            return "已认证";
                        }
                        else if (CertifyEnterprise == 0 || CertifyEnterprise == 1)
                        {
                            return "未认证";
                        }
                        else if (CertifyEnterprise == 2)
                        {
                            return "审核中";
                        }
                        else if (CertifyEnterprise == 10)
                        {
                            return "认证失败 " + Certify_Rmark;
                        }
                    }
                    else if (UserType == 40)
                    {
                        if (CertifyPersonal == 99)
                        {
                            return "已认证";
                        }
                        else if (CertifyPersonal == 0 || CertifyPersonal == 1)
                        {
                            return "未认证";
                        }
                        else if (CertifyPersonal == 2)
                        {
                            return "审核中";
                        }
                        else if (CertifyPersonal == 10)
                        {
                            return "认证失败 " + Certify_Rmark;
                        }
                    }
                    return "当前用户不可认证。";
                }
            }
            /// <summary>
            /// 认证检测
            /// </summary>
            public int CertifyCheck { get; set; }

            public int Certify
            {
                get
                {
                    if (UserType != 10 && UserType != 40)
                    {
                        if (CertifyCheck == 1)
                        {
                            return 99;
                        }
                        else
                        {
                            return 0;
                        }
                    }
                    if (UserType == 10)
                    {
                        return CertifyEnterprise;
                    }
                    else if (UserType == 40)
                    {
                        return CertifyPersonal;
                    }
                    return -100;
                }
            }
            #endregion


            /// <summary>
            /// 支付密码
            /// </summary>
            public string PayPassword { get; set; }


            /// <summary>
            /// 认证真实姓名
            /// </summary>
            public string CertifyRealName { get; set; }
            /// <summary>
            ///  身份证号
            /// </summary>
            public string CertifyIDCard { get; set; }
            /// <summary>
            /// 公司名称
            /// </summary>
            public string CertifyCompanyName { get; set; }

            /// <summary>
            /// 使用优惠码
            /// </summary>
            public string Use_RecommendCode { get; set; }
            /// <summary>
            /// 我的优惠码
            /// </summary>
            public string User_RecommendCode { get; set; }

            /// <summary>
            /// SNRUser构造函数
            /// User构造函数
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
            /// User构造函数
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
                //RealNameChar = row["RealNameChar"].ToString().Trim();
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
                    UserImg = "/Upload/defaultPhoto.png";
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

                CertifyRealName = row["CertifyRealName"].ToString();
                CertifyIDCard = row["CertifyIDCard"].ToString();
                CertifyCompanyName = row["CertifyCompanyName"].ToString();
                Use_RecommendCode = row["Use_RecommendCode"].ToString();
                User_RecommendCode = row["User_RecommendCode"].ToString();
            }
       

    }
}
