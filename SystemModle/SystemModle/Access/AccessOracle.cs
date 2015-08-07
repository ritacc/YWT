using System;
using System.Collections.Generic;
using System.Text;
using System.Data.OleDb;
using System.Data;

namespace SystemModle.Access
{
    public class AccessOracle : AccessDB
    {
        public AccessOracle(OleDbConnection conn)
            : base(conn)
        {

        }

        public override DataTable GetAllTable()
        {
            string sql = "select a.table_name, b.comments from user_tables a inner join user_tab_comments b on a.table_name = b.table_name";
            return db.ExecuteQuery(sql);
        }


        /// <summary>
        /// 查询表字段即相磁信息
        /// </summary>
        /// <param name="strTableName"></param>
        /// <returns></returns>
        public override DataTable GetColumnsByTableName(string strTableName)
        {
            string sql = @"select a.column_name, a.data_type, a.data_length, a.data_default, b.comments,a.nullable ,pkey.iskey
from user_tab_columns a 
inner join user_col_comments b on a.column_name = b.column_name and a.table_name=b.table_name 
left join (select cu.*,'Y' as isKey  from user_cons_columns cu, user_constraints au 
where cu.constraint_name = au.constraint_name and au.constraint_type = 'P' and au.table_name ='{0}') pkey 
on pkey.column_name=a.COLUMN_NAME
where a.table_name='{0}'  order by a.column_id  ";
            sql = string.Format(sql, strTableName);
            return db.ExecuteQuery(sql);
        }

        public override List<string> GetPrimaryKeys(string strTableName)
        {
            List<string> listResult = new List<string>();
            string sql = "select   column_name   from   user_cons_columns where   constraint_name   =   (select   constraint_name   from   user_constraints where   table_name   =   '{0}'  and   constraint_type   ='P')";
            sql = string.Format(sql, strTableName);
            DataTable dt = db.ExecuteQuery(sql);
            foreach (DataRow row in dt.Rows)
            {
                listResult.Add(row["column_name"].ToString());
            }
            return listResult;
        }

        public override string GetDataType(string strColumnName)
        {
            string sResult = string.Empty;
            switch (strColumnName)
            {
                case "DATE":
                    sResult = "DateTime";
                    break;
                case "NUMBER":
                    sResult = "Number";
                    break;
                case "INTEGER":
                    sResult = "Int32";
                    break;
                case "CHAR":
                    sResult = "Char";
                    break;
                case "VARCHAR2":
                    sResult = "VarChar";
                    break;
                case "NVARCHAR2":
                    sResult = "NVarChar";
                    break;
                case "VARCHAR":
                    sResult = "VarChar";
                    break;
                case "NVARCHAR":
                    sResult = "NVarChar";
                    break;
                default:
                    sResult = "NVarChar";
                    break;

            }
            return sResult;
        }
        

        public override string GetValidatorType(string strDataType,string isNull)
        {
            string sResult = string.Empty;
            switch (strDataType)
            {
                    
                case "DATE":
                    sResult = "DateTime";
                    break;
                case "NUMBER":
                    sResult = "int";
                    break;
                case "INTEGER":
                    sResult = "int";
                    break;
                case "CHAR":
                    sResult = "string";
                    break;
                case "VARCHAR2":
                    sResult = "string";
                    break;
                case "NVARCHAR2":
                    sResult = "string";
                    break;
                case "VARCHAR":
                    sResult = "string";
                    break;
                case "NVARCHAR":
                    sResult = "string";
                    break;
                default:
                    sResult = "string";
                    break;

            }
            return sResult;
        }
    }
}
