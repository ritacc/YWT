using System;
using System.Collections.Generic;
using System.Text;
using System.Data.OleDb;
using System.Data;

namespace SystemModle.Access
{
    public class AccessDB
    {
        protected OleDbConnection _Connection;
        protected DBCommond db;

        public AccessDB(OleDbConnection conn)
        {
            db = new DBCommond();
            db.Connection = conn;
        }

        public virtual DataTable GetAllTable()
        {
            return new DataTable();
        }

        public virtual DataTable GetColumnsByTableName(string strTableName)
        {
            return new DataTable();
        }

        public virtual List<string> GetPrimaryKeys(string strTableName)
        {
            return new List<string>();
        }

        public virtual string GetDataType(string strColumnName)
        {
            return string.Empty;
        }
		
		public virtual string GetDataType(string strColumnName, int DBLen)
		{
			return string.Empty;
		}

		public virtual string GetDataType(string strColumnName, int DBLen, string isNull)
		{
			return string.Empty;
		}


		public virtual string GetValidatorType(string strDataType)
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

            return sResult;
		}
		public virtual string GetValidatorType(string strDataType, string isNull)
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
