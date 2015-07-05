using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YWT.Model.Order
{
    public class YWTOrderAdminOR
    {
        /// <summary>
        /// 运维单主数据
        /// </summary>
        public YWTOrderOR OrderMain { get; set; }

        /// <summary>
        /// 运单文件
        /// </summary>
        public List<OrderFileOR> OrderFile { get; set; }
    }
}
