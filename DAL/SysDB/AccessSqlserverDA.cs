using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using CBSCS.DBUtility;

namespace YWT.DAL.SysDB
{
    public class AccessSqlserverDA
    {
        public DataTable SelectColumn(string tableName)
        {
            string sql = string.Format(@"select  a.colorder as co_num,   
a.name as column_name,b.name as data_type,   
a.length as data_length, --长度
isnull(e.text,'') as data_default,
isnull(g.[value],'') AS comments1,
a.isnullable as   nullable,
pk.PrimaryKey as iskey
FROM syscolumns a 
left join systypes b on a.xtype=b.xusertype   
inner join sysobjects d on a.id=d.id and d.xtype='U' and d.name<>'dtproperties'  
left join syscomments e  on a.cdefault=e.id   
left join sys.extended_properties g on a.id=g.major_id AND a.colid = g.minor_id  
left join (SELECT  TableName=O.Name,IndexName=IDX.Name, ColumnName=C.Name,   
    PrimaryKey=CASE WHEN IDX.is_primary_key=1 THEN N'Y'ELSE N' ' END   
FROM sys.indexes IDX
    INNER JOIN sys.index_columns IDXC ON IDX.[object_id]=IDXC.[object_id] AND IDX.index_id=IDXC.index_id   
    INNER JOIN sys.objects O      ON O.[object_id]=IDX.[object_id]
    INNER JOIN sys.columns C     ON O.[object_id]=C.[object_id] AND O.type='U' AND O.is_ms_shipped=0
            AND IDXC.Column_id=C.Column_id where o.name='{0}')  pk on pk.ColumnName=a.name
where d.name='{0}'--所要查询的表   
order by a.id,a.colorder ", tableName);
            return DbHelperSQL.QueryTable(sql);
        }


        public DataTable GetAllTable()
        {
            string sql = "select name as table_name,id,'' as comments from sysobjects where xtype='U' order by name";
            return DbHelperSQL.QueryTable(sql);
        }

        public DataTable GetAllDate(string tableName)
        {
            string sql = "select top 100 *  from " + tableName;
            return DbHelperSQL.QueryTable(sql);
        }
    }
}