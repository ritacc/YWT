using System;
using System.Collections.Generic;
using System.Text;
using System.Data.OleDb;

namespace SystemModle.Access
{
    public class Access
    {
        public static AccessDB GetAccess(OleDbConnection conn)
        {
            if (conn.Provider == "MSDAORA")
            {
                return new AccessOracle(conn);
            }
            else if (conn.Provider == "SQLOLEDB")
            {
                return new AccessSqlserver(conn);
            }
            return new AccessDB(conn);
        }
    }
}
