using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.OleDb;

namespace SystemModle
{
    /// <summary>
    /// 数据库访问类
    /// </summary>
    public class DBCommond
    {
        /// <summary>
        /// DBCommond构造函数
        /// </summary>
        public DBCommond()
        {
        }

        /// <summary>
        /// DBCommond构造函数
        /// </summary>
        /// <param name="conn"></param>
        public DBCommond(OleDbConnection conn)
        {
            _Connection = conn;
        }

        // 数据库连接
        private OleDbConnection _Connection = null;
        /// <summary>
        /// 数据库连接
        /// </summary>
        public OleDbConnection Connection
        {
            set { _Connection = value; }
        }

        /// <summary>
        /// 执行查询脚本
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public DataTable ExecuteQuery(string sql)
        {
            DataTable dt = new DataTable();
            OleDbCommand _Command = null;
            try
            {
                _Connection.Open();
                _Command = _Connection.CreateCommand();
                _Command.Connection = _Connection;

                _Command.CommandText = sql;
                OleDbDataAdapter da = new OleDbDataAdapter(_Command);
                da.Fill(dt);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                if (_Connection.State == ConnectionState.Open)
                {
                    _Connection.Close();
                }
                if (null != _Command)
                {
                    _Command.Dispose();
                }
            }
            return dt;
        }

        /// <summary>
        /// 执行SQL 脚本命令，返回受影响的行数
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public int ExecuteNoQuery(string sql)
        {
            int iResult = 0;
            OleDbCommand _Command = null;
            try
            {
                _Connection.Open();
                _Command = _Connection.CreateCommand();
                _Command.Connection = _Connection;

                _Command.CommandText = sql;
                iResult = _Command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                iResult = -1;
                throw new Exception(ex.Message);
            }
            finally
            {
                if (_Connection.State == ConnectionState.Open)
                {
                    _Connection.Close();
                }
                if (null != _Command)
                {
                    _Command.Dispose();
                }
            }
            return iResult;
        }

        /// <summary>
        /// 用事务执行SQL 脚本命令
        /// </summary>
        /// <param name="sqls"></param>
        /// <returns></returns>
        public bool ExecuteNoQuery(List<string> sqls)
        {
            bool bResult = false;
            OleDbTransaction tran = null;
            OleDbCommand _Command = null;
            try
            {
                _Connection.Open();
                _Command = _Connection.CreateCommand();
                _Command.Connection = _Connection;
                tran = _Connection.BeginTransaction();
                _Command.Transaction = tran;

                foreach (string sql in sqls)
                {
                    _Command.CommandText = sql;
                    _Command.ExecuteNonQuery();
                }
                tran.Commit();
                bResult = true;
            }
            catch (Exception ex)
            {
                // 回滚事务
                if (null != tran)
                {
                    tran.Rollback();
                }
                throw new Exception(ex.Message);
            }
            finally
            {
                if (_Connection.State == ConnectionState.Open)
                {
                    _Connection.Close();
                }
                if (null != _Command)
                {
                    _Command.Dispose();
                }
            }
            return bResult;
        }
    }
}
