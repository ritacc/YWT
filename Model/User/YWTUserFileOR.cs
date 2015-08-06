using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace YWT.Model.User
{
   /// <summary>
    /// 
    /// </summary>
    public class YWTUserFileOR
    {

        /// <summary>
        /// 
        /// </summary>
        public string ID { get; set; }
        /// <summary>
        /// 对应用户ID
        /// </summary>
        public string User_ID { get; set; }
        /// <summary>
        /// 文件类型 司机企业待
        /// </summary>
        public string FileType { get; set; }
        /// <summary>
        /// 文件名
        /// </summary>
        public string FileName { get; set; }
        /// <summary>
        /// 创建人
        /// </summary>
        public string Creator { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DateTime CreateDateTime { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string CertifyType { get; set; }
        /// <summary>
        /// YWTUserFile构造函数
        /// </summary>
        public YWTUserFileOR()
        {

        }

        /// <summary>
        /// YWTUserFile构造函数
        /// </summary>
        public YWTUserFileOR(DataRow row)
        {
            // 
            ID = row["ID"].ToString().Trim();
            // 对应用户ID
            User_ID = row["User_ID"].ToString().Trim();
            // 文件类型 司机企业待
            FileType = row["FileType"].ToString().Trim();
            // 文件名
            FileName = row["FileName"].ToString().Trim();
            // 创建人
            Creator = row["Creator"].ToString().Trim();
            // 
            if (row["CreateDateTime"] != DBNull.Value)
                CreateDateTime = Convert.ToDateTime(row["CreateDateTime"]);

            // 
            CertifyType = row["CertifyType"].ToString().Trim();
        }
    }
}
