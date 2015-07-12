using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YWT.DAL.SysDB;
using System.Data;

namespace YWT.BLL.SysDB
{
   public class AccessSqlserverBLL
   {
       public DataTable SelectColumn(string tableName)
       {
           return new AccessSqlserverDA().SelectColumn(tableName);
       }
       public   DataTable GetAllTable()
       {
           return new AccessSqlserverDA().GetAllTable();
       }
    }
}
