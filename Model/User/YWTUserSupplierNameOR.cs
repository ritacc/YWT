using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace YWT.Model.User
{
   public class YWTUserSupplierNameOR :YWTUserOR
   {  
       /// <summary>
       /// 所属运维商
       /// </summary>
       public string Company { get; set; }

       public YWTUserSupplierNameOR(DataRow row):base(row)
       {
           Company = row["Company"].ToString().Trim();
       }

    }
}
