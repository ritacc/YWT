using System;
using System.Collections.Generic;
using System.Text;
using System.Data.OleDb;
using System.Data;

namespace SystemModle.Access
{
    public class AccessSqlserver : AccessDB
    {
        public AccessSqlserver(OleDbConnection conn)
            : base(conn)
        {

        }

        public override DataTable GetAllTable()
        {
            string sql = "select name as table_name,id,'' as comments from sysobjects where xtype='U' order by name";
            return db.ExecuteQuery(sql);
        }


        /// <summary>
        /// 查询表字段即相磁信息
        /// </summary>
        /// <param name="strTableName"></param>
        /// <returns></returns>
        public override DataTable GetColumnsByTableName(string strTableName)
        {
            string sql = @"select  a.colorder as co_num,   
a.name as column_name,b.name as data_type,   
a.length as data_length, --长度
isnull(e.text,'') as data_default,
isnull(g.[value],'') AS comments,
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
order by a.id,a.colorder  ";
            sql = string.Format(sql, strTableName);
            return db.ExecuteQuery(sql);
        }

        public override List<string> GetPrimaryKeys(string strTableName)
        {
            List<string> listResult = new List<string>();
            string sql = @"SELECT  TableName=O.Name,IndexName=IDX.Name, ColumnName=C.Name,   
    PrimaryKey=CASE WHEN IDX.is_primary_key=1 THEN N'Y'ELSE N' ' END   
FROM sys.indexes IDX
    INNER JOIN sys.index_columns IDXC ON IDX.[object_id]=IDXC.[object_id] AND IDX.index_id=IDXC.index_id   
    INNER JOIN sys.objects O      ON O.[object_id]=IDX.[object_id]
    INNER JOIN sys.columns C     ON O.[object_id]=C.[object_id] AND O.type='U' AND O.is_ms_shipped=0
            AND IDXC.Column_id=C.Column_id where o.name='{0}'";
            sql = string.Format(sql, strTableName);
            DataTable dt = db.ExecuteQuery(sql);
            foreach (DataRow row in dt.Rows)
            {
                listResult.Add(row["column_name"].ToString());
            }
            return listResult;
        }

		//public override string GetDataType(string strColumnName)
		//{
		//    string[] arrType = { "VarChar", "NVarChar", "Char", "NText"};
		//    bool isAddLen = false;
		//    string newType=GetDataType(strColumnName);
		//    foreach (string str in arrType)
		//    {
		//        if (str == newType)
		//        {
		//            isAddLen = true;
		//            break;
		//        }
		//    }
		//    if (isAddLen)
		//    {
		//        newType= string.Format("{0}({1})", newType, DBLen);
		//    }
			
			
		//    return newType;
		//}

		public override string GetDataType(string strColumnName, int DBLen)
		{
			string[] arrType = { "VarChar", "NVarChar", "Char", "NText" };
			bool isAddLen = false;
			string newType = GetDataType(strColumnName);
			foreach (string str in arrType)
			{
				if (str == newType)
				{
					isAddLen = true;
					break;
				}
			}
			if (isAddLen)
			{
				newType = string.Format("{0}({1})", newType, DBLen);
			}
			return newType;
		}
		//public override string GetDataType(string strColumnName, int DBLen)
		//{
		//    string[] arrType = { "VarChar", "NVarChar", "Char", "NText" };
		//    bool isAddLen = false;
		//    string newType = GetDataType(strColumnName);
		//    string mtempType=newType.ToLower();
		//    foreach (string str in arrType)
		//    {
		//        if (str == newType)
		//        {
		//            isAddLen = true;
		//            break;
		//        }
		//    }
		//    if (isAddLen)
		//    {
		//        newType = string.Format("{0}({1})", newType, DBLen);
		//    }
			
		//    return newType;
		//}

        public override string GetDataType(string strColumnName)
        {
            string sResult = string.Empty;
                        
            switch (strColumnName.ToLower())
            {
                case "varchar":
                    sResult = "VarChar";
                    break;
                case "char":
                    sResult = "Char";
                    break;
                case "nvarchar":
                    sResult = "NVarChar";
                    break;
                case "datetime":
                    sResult = "DateTime";
                    break;
                case "int":
                    sResult = "Int";
                    break;
                case "date":
                    sResult = "Date";
                    break;
                case "smalldatetime":
                    sResult = "SmallDateTime";
                    break;               
                case "bigint":
                    sResult = "BigInt";
                    break;
                case "smallint":
                    sResult = "SmallInt";
                    break;
				case "decimal":
                    sResult = "Decimal";
					break;
                case "float":
                    sResult = "Float";
                    break;                     
                case "ntext":
                    sResult = "NText";
                    break; 
                case "bit":
                    sResult = "Bit";
                    break; 
                case "real":
                    sResult = "Real";
                    break;
                default:
                    sResult = "VarChar";
                    break;

            }
            return sResult;
        }

		public override string GetValidatorType(string strDataType,   string isNull)
        {
            
            string sResult = string.Empty;
            switch (strDataType.ToLower())
            {
                case "varchar":                  
                case "char":                   
                case "nvarchar":                   
                case "ntext":
                    sResult = "string";
                    break;
                case "bit":
                    sResult = "bool";
                    break;
                case "datetime":
                    sResult = "DateTime";
                    break;
                case "int":
                    sResult = "int";
                    break;
                case "date":
                    sResult = "string";
                    break;
				case "decimal":
					sResult = "decimal";
					break;
                case "smalldatetime":
                    sResult = "DateTime";
                    break;
                case "bigint":
					sResult = "long";
                    break;
                case "smallint":
                    sResult = "int";
                    break;                    
                case "float":
                    sResult = "float";
                    break;                
                case "real":
                    sResult = "float";
                    break;
                default:
                    sResult = "string";
                    break;
            }

			if (isNull == "1")
			{
				string[] isAddNull = { "bigint", "int", "DateTime", "long", "decimal", "float" };
				foreach (string str in isAddNull)
				{
					if (str ==sResult.ToLower())
					{
						sResult += "?";
						break;
					}
				}
			}

            return sResult;
        }
    }
}
