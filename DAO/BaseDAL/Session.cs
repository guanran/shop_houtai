using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO.BaseDAL
{
    public class DbContext
    {
        private SqlConnection _connection;
        private SqlTransaction _transaction;
        public SqlConnection Connection
        {
            get { return _connection; }
            set { _connection = value; }
        }
        public SqlTransaction Transaction
        {
            get { return _transaction; }
            set { _transaction = value; }
        }

        public DbContext()
        {
            _connection = new SqlConnection(GetConnectionString("ConnectionString"));
        }
        public static string GetConnectionString(string configName)
        {
            string connectionString = ConfigurationManager.ConnectionStrings[configName].ConnectionString;
            string ConStringEncrypt = ConfigurationManager.AppSettings["ConStringEncrypt"];
            if (ConStringEncrypt == "true")
            {
                connectionString = DESEncrypt.Decrypt(connectionString);
            }
            return connectionString;
        }

        /// <summary>
        /// 开启会话
        /// </summary>
        /// <param name="isolation"></param>
        /// <returns></returns>
        public SqlTransaction Begin()
        {
            _connection.Open();
            _transaction = _connection.BeginTransaction();
            return _transaction;
        }

        /// <summary>
        /// 事务提交
        /// </summary>
        public void Commit()
        {
            if (_connection != null && _transaction != null && _connection.State == ConnectionState.Open)
            {
                _transaction.Commit();
                _transaction = null;
                _connection.Close();
                _connection.Dispose();
                _connection = null;
            }
        }

        /// <summary>
        /// 事务回滚
        /// </summary>
        public void Rollback()
        {
            if (_connection != null && _transaction != null && _connection.State == ConnectionState.Open)
            {
                _transaction.Rollback();
                _transaction = null;
                _connection.Close();
                _connection.Dispose();
                _connection = null;
            }
        }
        /// <summary>
        /// 资源释放
        /// </summary>
        private void Dispose()
        {
            if (_connection.State != ConnectionState.Closed)
            {
                if (_transaction != null)
                {
                    _transaction.Rollback();
                    _transaction = null;
                }
                _connection.Close();
                _connection = null;
            }
            GC.SuppressFinalize(this);
        }
    }
}
