using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace YWT.Model.Order.ImgView
{
   public class OrderImgViewOR
    {
        /// <summary>
        /// 
        /// </summary>
        public string Order_ID { get; set; }
        /// <summary>
        /// 运单编号
        /// </summary>
        public string OrderNo { get; set; }

        /// <summary>
        /// 标题
        /// </summary>
        public string OrderTitle { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime CreateDateTime { get; set; }


        public Int32 FileNum { get; set; }

        public List<string> Files { get; set; }

        public OrderImgViewOR(DataRow row,int type)
        {
            // 
            Order_ID = row["Order_ID"].ToString().Trim();
            // 运单编号
            OrderNo = row["OrderNo"].ToString().Trim();

            // 标题
            OrderTitle = row["OrderTitle"].ToString().Trim();

            if (row["CreateDateTime"] != DBNull.Value)
                CreateDateTime = Convert.ToDateTime(row["CreateDateTime"]);
            if (type == 90) //效果查询，过程还原
            {
                if (row["FileNum90"] != DBNull.Value)
                    FileNum = Convert.ToInt32(row["FileNum90"]);
            }
            else if (type == 30)//现场拍照
            {
                if (row["FileNum30"] != DBNull.Value)
                    FileNum = Convert.ToInt32(row["FileNum30"]);
            }
        }

        public void InitFiles(List<OrderFileOR> _Files)
        {
            Files = new List<string>();
            if (_Files != null)
            {
                foreach (var obj in _Files)
                {
                    Files.Add(obj.FileIcon);
                }
            }
        }
    }
}
