
using Entity.common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;

namespace DAO.BaseDAL
{
    public class ORMHelper<T> : IORMHelper<T> where T : class
    {
        private DbContext _session;

        public DbContext SetDbContext(DbContext session = null)
        {
            if (session == null)
            {
                _session = new DbContext();
            }
            else
            {
                _session = session;
            }
            return _session;
        }

        public void SaveChanges()
        {
            _session.Commit();
        }

        public T Get(object id)
        {
            StringBuilder selectSQL = new StringBuilder();
            selectSQL.AppendFormat("SELECT * FROM  {0} with(nolock) ", GetTableName());
            Type type = typeof(T);
            PropertyInfo[] properties = type.GetProperties();
            foreach (PropertyInfo propertyInfo in properties)
            {
                object[] uAttr = propertyInfo.GetCustomAttributes(typeof(ColumnAttribute), false);
                if (uAttr != null && uAttr.Length > 0)
                {
                    ColumnAttribute cattr = uAttr[0] as ColumnAttribute;
                    if (cattr != null)
                    {
                        if (IsPrimaryKey(cattr.ColumnType))
                        {
                            selectSQL.AppendFormat(" where {0} = @ID  ", cattr.ColumnName);
                            break;
                        }
                    }
                }
            }

            SqlParameter[] parameters = {
                    new SqlParameter("@ID", id)};
            List<T> list = QueryList(selectSQL.ToString(), parameters);
            if (list != null && list.Count > 0)
            {
                return list.FirstOrDefault();
            }
            else
            {
                return null;
            }
        }

        public T Get(Expression<Func<IQueryable<T>, IQueryable<T>>> predicate)
        {
            StringBuilder selectSQL = new StringBuilder();
            selectSQL.AppendFormat("SELECT * FROM  {0} with(nolock)  ", GetTableName());
            Dictionary<string, string> dic = GetConditionSql(predicate);
            selectSQL.AppendFormat(" {0} ", dic["where"]);
            selectSQL.AppendFormat(" {0} ", dic["orderby"]);
            List<T> list = QueryList(selectSQL.ToString(), null);
            if (list != null && list.Count > 0)
            {
                return list.FirstOrDefault();
            }
            else
            {
                return null;
            }
        }

        public List<T> GetList()
        {
            StringBuilder selectSQL = new StringBuilder();
            selectSQL.AppendFormat("SELECT * FROM  {0} with(nolock) ", GetTableName());
            return QueryList(selectSQL.ToString(), null);
        }

        public List<T> GetList(Expression<Func<IQueryable<T>, IQueryable<T>>> predicate)
        {
            StringBuilder selectSQL = new StringBuilder();
            selectSQL.AppendFormat("SELECT * FROM  {0} with(nolock)  ", GetTableName());
            Dictionary<string, string> dic = GetConditionSql(predicate);
            selectSQL.AppendFormat(" {0} ", dic["where"]);
            selectSQL.AppendFormat(" {0} ", dic["orderby"]);
            return QueryList(selectSQL.ToString(), null);
        }

        public PagedList<T> GetPagedList(Expression<Func<IQueryable<T>, IQueryable<T>>> predicate, int pageSize, int pageIndex)
        {
            StringBuilder selectSQL = new StringBuilder();
            selectSQL.AppendFormat("SELECT * FROM  {0} with(nolock)  ", GetTableName());
            Dictionary<string, string> dic = GetConditionSql(predicate);
            selectSQL.AppendFormat(" {0} ", dic["where"]);
            string sql = GetPageSQLByRowNum(selectSQL.ToString(), pageSize, pageIndex, dic["orderby"]);
            DataSet ds = Query(sql, null);
            List<T> list = ListHelper.DataTableToIList<T>(ds.Tables[0]).ToList();
            int totalItemCount = Convert.ToInt32(ds.Tables[1].Rows[0][0]);
            return new PagedList<T>(list.AsEnumerable(), pageIndex, pageSize, totalItemCount);
        }


        public PagedList<T> GetPagedList(List<T> list, int pageSize, int pageIndex)
        {
            //StringBuilder selectSQL = new StringBuilder();
            //selectSQL.AppendFormat("SELECT * FROM  {0} with(nolock)  ", GetTableName());
            //Dictionary<string, string> dic = GetConditionSql(predicate);
            //selectSQL.AppendFormat(" {0} ", dic["where"]);
            //string sql = GetPageSQLByRowNum(selectSQL.ToString(), pageSize, pageIndex, dic["orderby"]);
            //DataSet ds = Query(sql, null);
            //List<T> list = ListHelper.DataTableToIList<T>(ds.Tables[0]).ToList();
            if (list != null)
            {

                int totalItemCount = Convert.ToInt32(list.Count());
                list = list.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();

                return new PagedList<T>(list.AsEnumerable(), pageIndex, pageSize, totalItemCount);
            }
            else
            {
                return new PagedList<T>(null, pageIndex, pageSize, 0);
            }
        }


        public void Insert(T obj, bool IsSaveChanges = true)
        {
            Dictionary<string, object> dict = GetInsertSQL(obj);
            SqlParameter[] parameters = (SqlParameter[])dict["parameters"];
            ExecuteSql(dict["sql"].ToString(), false, parameters);
            if (IsSaveChanges)
            {
                SaveChanges();
            }
        }

        public void Insert(List<T> list, bool IsSaveChanges = true)
        {
            if (list != null && list.Count > 0)
            {
                foreach (var item in list)
                {
                    Insert(item, false);
                }
                if (IsSaveChanges)
                {
                    SaveChanges();
                }
            }
        }

        public void Update(T obj, bool IsSaveChanges = true)
        {
            Dictionary<string, object> dict = GetUpdateSQL(obj);
            SqlParameter[] parameters = (SqlParameter[])dict["parameters"];
            ExecuteSql(dict["sql"].ToString(), false, parameters);
            if (IsSaveChanges)
            {
                SaveChanges();
            }
        }

        public void Update(List<T> list, bool IsSaveChanges = true)
        {
            if (list != null && list.Count > 0)
            {
                foreach (var item in list)
                {
                    Update(item, false);
                }
                if (IsSaveChanges)
                {
                    SaveChanges();
                }
            }
        }

        public void Delete(T obj, bool IsSaveChanges = true)
        {
            string sql = GetDeleteSQL(obj);
            ExecuteSql(sql, false);
            if (IsSaveChanges)
            {
                SaveChanges();
            }
        }

        public void Delete(List<T> list, bool IsSaveChanges = true)
        {
            if (list != null && list.Count > 0)
            {
                foreach (var item in list)
                {
                    string sql = GetDeleteSQL(item);
                    ExecuteSql(sql, false);
                }
                if (IsSaveChanges)
                {
                    SaveChanges();
                }
            }
        }

        public void Delete(object id, bool IsSaveChanges = true)
        {
            string sql = GetDeleteSQL(id);
            ExecuteSql(sql, false);
            if (IsSaveChanges)
            {
                SaveChanges();
            }
        }

        public void Delete(object[] id, bool IsSaveChanges = true)
        {
            if (id != null && id.Length > 0)
            {
                foreach (var item in id)
                {
                    string sql = GetDeleteSQL(item);
                    ExecuteSql(sql, false);
                }
                if (IsSaveChanges)
                {
                    SaveChanges();
                }
            }
        }

        public int ExecuteSql(string SQLString, bool IsSaveChanges = true)
        {
            try
            {
                CheckConnState();

                using (SqlCommand cmd = _session.Connection.CreateCommand())
                {
                    cmd.CommandText = SQLString;
                    cmd.Transaction = _session.Transaction;
                    int rows = cmd.ExecuteNonQuery();
                    cmd.Dispose();
                    if (IsSaveChanges)
                    {
                        SaveChanges();
                    }
                    return rows;
                }
            }
            catch (System.Data.SqlClient.SqlException e)
            {
                _session.Rollback();
                throw e;
            }
        }

        public int ExecuteSql(string SQLString, bool IsSaveChanges = true, params SqlParameter[] cmdParms)
        {
            try
            {
                CheckConnState();

                using (SqlCommand cmd = _session.Connection.CreateCommand())
                {
                    cmd.CommandText = SQLString;
                    cmd.Transaction = _session.Transaction;
                    cmd.CommandType = CommandType.Text;
                    if (cmdParms != null)
                    {
                        foreach (SqlParameter parameter in cmdParms)
                        {
                            if ((parameter.Direction == ParameterDirection.InputOutput || parameter.Direction == ParameterDirection.Input) &&
                                (parameter.Value == null))
                            {
                                parameter.Value = DBNull.Value;
                            }
                            cmd.Parameters.Add(parameter);
                        }
                    }
                    int rows = cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();
                    cmd.Dispose();
                    if (IsSaveChanges)
                    {
                        SaveChanges();
                    }
                    return rows;
                }
            }
            catch (System.Data.SqlClient.SqlException e)
            {
                _session.Rollback();
                throw e;
            }
        }

        public List<T> QueryList(string SQLString, params SqlParameter[] cmdParms)
        {
            DataSet ds = Query(SQLString, cmdParms);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                return ListHelper.DataTableToIList<T>(ds.Tables[0]).ToList();
            }
            return null;
        }

        /// <summary>
        /// 自定义 connection 查询
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="SQLString"></param>
        /// <param name="cmdParms"></param>
        /// <returns></returns>
        public List<T> QueryListConn(string connection, string SQLString, params SqlParameter[] cmdParms)
        {
            DataSet ds = QueryConn(connection, SQLString, cmdParms);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                return ListHelper.DataTableToIList<T>(ds.Tables[0]).ToList();
            }
            return null;
        }

        public PagedList<T> QueryPagedList(string SQLString, int pageSize, int pageIndex, string SortString, params SqlParameter[] cmdParms)
        {
            string sql = GetPageSQLByRowNum(SQLString, pageSize, pageIndex, SortString);
            DataSet ds = Query(sql, cmdParms);
            List<T> list = ListHelper.DataTableToIList<T>(ds.Tables[0]).ToList();
            int totalItemCount = Convert.ToInt32(ds.Tables[1].Rows[0][0]);
            return new PagedList<T>(list.AsEnumerable(), pageIndex, pageSize, totalItemCount);
        }

        public DataSet Query(string SQLString, params SqlParameter[] cmdParms)
        {
            using (SqlConnection conn = new SqlConnection(DbContext.GetConnectionString("ConnectionString")))
            {
                using (SqlCommand cmdd = conn.CreateCommand())
                {
                    cmdd.CommandText = SQLString;
                    cmdd.CommandType = CommandType.Text;
                    if (cmdParms != null)
                    {
                        foreach (SqlParameter parameter in cmdParms)
                        {
                            if ((parameter.Direction == ParameterDirection.InputOutput || parameter.Direction == ParameterDirection.Input) && (parameter.Value == null))
                            {
                                parameter.Value = DBNull.Value;
                            }
                            cmdd.Parameters.Add(parameter);
                        }
                    }
                    using (SqlDataAdapter da = new SqlDataAdapter(cmdd))
                    {
                        DataSet ds = new DataSet();
                        try
                        {
                            da.Fill(ds, "ds");
                            cmdd.Parameters.Clear();
                        }
                        catch (System.Data.SqlClient.SqlException ex)
                        {
                            throw new Exception(ex.Message);
                        }
                        return ds;
                    }
                }
            }
        }

        /// <summary>
        /// 自定义 连接字符串 查询
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="SQLString"></param>
        /// <param name="cmdParms"></param>
        /// <returns></returns>
        public DataSet QueryConn(string connection, string SQLString, params SqlParameter[] cmdParms)
        {
            using (SqlConnection conn = new SqlConnection(connection))
            {
                using (SqlCommand cmdd = conn.CreateCommand())
                {
                    cmdd.CommandTimeout = 1000;
                    cmdd.CommandText = SQLString;
                    cmdd.CommandType = CommandType.Text;
                    if (cmdParms != null)
                    {
                        foreach (SqlParameter parameter in cmdParms)
                        {
                            if ((parameter.Direction == ParameterDirection.InputOutput || parameter.Direction == ParameterDirection.Input) && (parameter.Value == null))
                            {
                                parameter.Value = DBNull.Value;
                            }
                            cmdd.Parameters.Add(parameter);
                        }
                    }
                    using (SqlDataAdapter da = new SqlDataAdapter(cmdd))
                    {
                        DataSet ds = new DataSet();
                        try
                        {
                            da.Fill(ds, "ds");
                            cmdd.Parameters.Clear();
                        }
                        catch (System.Data.SqlClient.SqlException ex)
                        {
                            throw new Exception(ex.Message);
                        }
                        return ds;
                    }
                }
            }
        }

        public DataSet QueryPaged(string SQLString, int pageSize, int pageIndex, out int totalItemCount, string SortString, params SqlParameter[] cmdParms)
        {
            using (SqlConnection conn = new SqlConnection(DbContext.GetConnectionString("ConnectionString")))
            {
                using (SqlCommand cmdd = conn.CreateCommand())
                {
                    if (pageIndex < 1)
                        pageIndex = 1;
                    string sql = GetPageSQLByRowNum(SQLString, pageSize, pageIndex, SortString);
                    cmdd.CommandText = sql;
                    cmdd.CommandType = CommandType.Text;
                    if (cmdParms != null)
                    {
                        foreach (SqlParameter parameter in cmdParms)
                        {
                            if ((parameter.Direction == ParameterDirection.InputOutput || parameter.Direction == ParameterDirection.Input) && (parameter.Value == null))
                            {
                                parameter.Value = DBNull.Value;
                            }
                            cmdd.Parameters.Add(parameter);
                        }
                    }
                    using (SqlDataAdapter da = new SqlDataAdapter(cmdd))
                    {
                        DataSet ds = new DataSet();
                        try
                        {
                            da.Fill(ds, "ds");
                            cmdd.Parameters.Clear();
                        }
                        catch (System.Data.SqlClient.SqlException ex)
                        {
                            throw new Exception(ex.Message);
                        }
                        totalItemCount = Convert.ToInt32(ds.Tables[1].Rows[0][0]);
                        return ds;
                    }
                }
            }
        }

        #region 事务内查询
        /*
        private List<T> QueryList(string SQLString, ConnBase transConnBase, params SqlParameter[] cmdParms)
        {
            DataSet ds = Query(SQLString, transConnBase, cmdParms);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                return ListHelper.DataTableToIList<T>(ds.Tables[0]).ToList();
            }
            return null;
        }
        private DataSet Query(string SQLString, ConnBase transConnBase, params SqlParameter[] cmdParms)
        {
            if (transConnBase == null || transConnBase.Connection == null)
            {
                return null;
            }
            CheckConnState();
            using (SqlCommand cmd = _session.Connection.CreateCommand())
            {
                cmd.CommandText = SQLString;
                cmd.Transaction = _session.Transaction;
                cmd.CommandType = CommandType.Text;
                if (cmdParms != null)
                {
                    foreach (SqlParameter parameter in cmdParms)
                    {
                        if ((parameter.Direction == ParameterDirection.InputOutput || parameter.Direction == ParameterDirection.Input) && (parameter.Value == null))
                        {
                            parameter.Value = DBNull.Value;
                        }
                        cmd.Parameters.Add(parameter);
                    }
                }
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    DataSet ds = new DataSet();
                    try
                    {
                        da.Fill(ds, "ds");
                        cmd.Parameters.Clear();
                    }
                    catch (System.Data.SqlClient.SqlException ex)
                    {
                        da.Dispose();
                        cmd.Dispose();
                        _session.Rollback();
                        throw new Exception(ex.Message);
                    }
                    da.Dispose();
                    cmd.Dispose();
                    return ds;
                }
            }
        }*/
        #endregion

        #region

        private void CheckConnState()
        {
            if (_session == null || _session.Connection == null)
            {
                _session = null;
                _session = new DbContext();
            }
            if (_session.Connection.State == ConnectionState.Closed)
            {
                _session.Begin();
            }
        }

        private static string GetTableName()
        {
            Type type = typeof(T);

            object[] table = type.GetCustomAttributes(typeof(TableAttribute), false);
            if (table != null && table.Length > 0)
            {
                TableAttribute tAttr = table[0] as TableAttribute;
                if (tAttr != null)
                {
                    return tAttr.TableName;
                }
            }
            return "";
        }

        private static bool IsPrimaryKey(ColumnType ctype)
        {
            if (ctype == ColumnType.IdentityAndPrimaryKey || ctype == ColumnType.PrimaryKey)
            {
                return true;
            }
            return false;
        }

        private static bool NeedQuotes(Type ctype)
        {
            if (ctype == typeof(System.Guid) || ctype == typeof(System.Guid?) || ctype == typeof(System.String) || ctype == typeof(System.DateTime) || ctype == typeof(System.DateTime?))
            {
                return true;
            }
            return false;
        }

        private static bool IsBool(Type ctype)
        {
            if (ctype == typeof(System.Boolean) || ctype == typeof(System.Boolean?))
            {
                return true;
            }
            return false;
        }

        private static bool IsUpdateColumn(ColumnType ctype)
        {
            if (ctype == ColumnType.PrimaryKey || ctype == ColumnType.IdentityAndPrimaryKey || ctype == ColumnType.Identity || ctype == ColumnType.ReadOnly)
            {
                return false;
            }
            return true;
        }

        #endregion

        #region getsql

        private static string GetDeleteSQL(object id)
        {
            StringBuilder deleteSQL = new StringBuilder();
            deleteSQL.AppendFormat("DELETE FROM  {0} ", GetTableName());

            Type type = typeof(T);

            PropertyInfo[] properties = type.GetProperties();
            foreach (PropertyInfo propertyInfo in properties)
            {
                object[] uAttr = propertyInfo.GetCustomAttributes(typeof(ColumnAttribute), false);
                if (uAttr != null && uAttr.Length > 0)
                {
                    ColumnAttribute cattr = uAttr[0] as ColumnAttribute;
                    if (cattr != null)
                    {
                        if (IsPrimaryKey(cattr.ColumnType))
                        {
                            if (NeedQuotes(propertyInfo.PropertyType))
                            {
                                deleteSQL.AppendFormat(" where {0} = '{1}'  ", cattr.ColumnName, id);
                            }
                            else
                            {
                                deleteSQL.AppendFormat(" where {0} = {1}  ", cattr.ColumnName, id);
                            }
                            break;
                        }
                    }
                }
            }
            return deleteSQL.ToString();
        }

        private static string GetDeleteSQL(T tObj)
        {
            List<EntityField> list = getFieldsAndValues(tObj);
            StringBuilder deleteSQL = new StringBuilder();
            deleteSQL.AppendFormat("DELETE FROM  {0} ", GetTableName());
            if (list != null && list.Count > 0)
            {
                string sqlwhere = "";
                foreach (var item in list)
                {
                    if (IsPrimaryKey(item.ColumnType))
                    {
                        if (NeedQuotes(item.ColumnDataType))
                        {
                            sqlwhere = item.ColumnName + " = '" + item.ColumnValue + "'";
                        }
                        else
                        {
                            sqlwhere = item.ColumnName + "=" + item.ColumnValue;
                        }
                        break;
                    }
                }
                deleteSQL.AppendFormat(" where {0}  ", sqlwhere);
            }
            return deleteSQL.ToString();
        }

        private static Dictionary<string, object> GetUpdateSQL(T tObj)
        {
            Dictionary<string, object> dict = new Dictionary<string, object>();
            List<EntityField> list = getFieldsAndValues(tObj);
            StringBuilder updateSQL = new StringBuilder();
            List<SqlParameter> parameters = new List<SqlParameter>();
            updateSQL.AppendFormat("UPDATE {0} SET ", GetTableName());
            if (list != null && list.Count > 0)
            {
                string sqlwhere = "";
                foreach (var item in list)
                {
                    SqlParameter sqlp = new SqlParameter();
                    sqlp.ParameterName = item.ColumnName;
                    if (!IsUpdateColumn(item.ColumnType))
                    {
                        if (IsPrimaryKey(item.ColumnType))
                        {
                            sqlwhere = item.ColumnName + "= @" + item.ColumnName;
                            sqlp.Value = item.ColumnValue;
                            parameters.Add(sqlp);
                        }
                        continue;
                    }
                    updateSQL.Append(item.ColumnName).Append("=@").Append(item.ColumnName).Append(",");

                    if (item.ColumnValue == null)
                    {
                        sqlp.Value = null;
                    }
                    else
                    {
                        if (IsBool(item.ColumnDataType))
                        {
                            if (Convert.ToBoolean(item.ColumnValue))
                            {
                                sqlp.Value = 1;
                            }
                            else
                            {
                                sqlp.Value = 0;
                            }
                        }
                        else
                        {
                            sqlp.Value = item.ColumnValue;
                        }
                    }
                    parameters.Add(sqlp);
                }
                updateSQL.Remove(updateSQL.Length - 1, 1);
                updateSQL.AppendFormat(" where {0}  ", sqlwhere);
            }
            dict.Add("sql", updateSQL.ToString());
            dict.Add("parameters", parameters.ToArray());
            return dict;
        }

        private static Dictionary<string, object> GetInsertSQL(T tObj)
        {
            Dictionary<string, object> dict = new Dictionary<string, object>();
            List<EntityField> list = getFieldsAndValues(tObj);
            StringBuilder fields = new StringBuilder();
            StringBuilder values = new StringBuilder();
            StringBuilder insertSQL = new StringBuilder();
            List<SqlParameter> parameters = new List<SqlParameter>();

            if (list != null && list.Count > 0)
            {
                foreach (var item in list)
                {
                    if (!string.IsNullOrEmpty(item.ColumnValue))
                    {
                        SqlParameter sqlp = new SqlParameter();

                        sqlp.ParameterName = item.ColumnName;
                        fields.Append(item.ColumnName).Append(",");
                        values.AppendFormat("@{0}", item.ColumnName).Append(",");
                        if (IsBool(item.ColumnDataType))
                        {
                            if (Convert.ToBoolean(item.ColumnValue))
                            {
                                sqlp.Value = 1;
                            }
                            else
                            {
                                sqlp.Value = 0;
                            }
                        }
                        else
                        {
                            sqlp.Value = item.ColumnValue;
                        }
                        parameters.Add(sqlp);
                    }
                }
                if (!string.IsNullOrEmpty(fields.ToString()) && !string.IsNullOrEmpty(values.ToString()))
                {
                    fields.Remove(fields.Length - 1, 1);
                    values.Remove(values.Length - 1, 1);
                }

                insertSQL.Append("INSERT INTO ").Append(GetTableName()).Append(" ( ").Append(fields).Append(" )  VALUES ( ").Append(values).Append(")");
            }
            dict.Add("sql", insertSQL.ToString());
            dict.Add("parameters", parameters.ToArray());
            return dict;
        }

        #endregion

        private static List<EntityField> getFieldsAndValues(T tObj)
        {
            List<EntityField> list = new List<EntityField>();

            Type type = typeof(T);

            PropertyInfo[] properties = type.GetProperties();
            foreach (PropertyInfo propertyInfo in properties)
            {
                object[] uAttr = propertyInfo.GetCustomAttributes(typeof(ColumnAttribute), false);
                if (uAttr != null && uAttr.Length > 0)
                {
                    ColumnAttribute cattr = uAttr[0] as ColumnAttribute;
                    if (cattr != null)
                    {
                        EntityField ef = new EntityField();
                        ef.ColumnDataType = propertyInfo.PropertyType;
                        ef.ColumnName = cattr.ColumnName;
                        ef.ColumnType = cattr.ColumnType;
                        if (propertyInfo.GetValue(tObj, null) != null)
                        {
                            ef.ColumnValue = propertyInfo.GetValue(tObj, null).ToString();
                        }
                        list.Add(ef);
                    }
                }
            }
            return list;
        }

        private static Dictionary<string, string> GetConditionSql(Expression<Func<IQueryable<T>, IQueryable<T>>> aiExp)
        {
            AiExpConditions<T> expc = new AiExpConditions<T>();
            expc.Add(aiExp);
            Dictionary<string, string> dic = new Dictionary<string, string>();
            string sqlwhere = expc.Where().Replace("= null", " is null ").Replace("=null", " is null ");
            sqlwhere = sqlwhere.Replace(" +", "+").Replace("+ ", "+");
            sqlwhere = sqlwhere.Replace("'%'+'", "'%").Replace("'+'%'", "%'");
            sqlwhere = sqlwhere.Replace("'%'+", "'%").Replace("+'%'", "%'");
            sqlwhere = sqlwhere.Replace("'%null%'", "'%%'");
            sqlwhere = sqlwhere.Replace("0 Or", "1=0 Or").Replace("1 Or", "1=1 Or");
            sqlwhere = sqlwhere.Replace("Or 0", "Or 0=1").Replace("Or 1", "Or 1=1");
            dic.Add("where", sqlwhere);
            dic.Add("orderby", expc.OrderBy());
            return dic;
        }

        private static string GetPageSQLByRowNum(string sql, int PageSize, int PageIndex, string SortString)
        {
            PageIndex -= 1;
            int PageStart = (PageSize * PageIndex);
            int PageEnd = (PageIndex + 1) * PageSize;
            string oldsql = sql;//保存一下旧的SQL
            sql = sql.ToLower();
            string RowColumn = " row_number() over  ( " + SortString + " ) as rnum ,";//序列语句
            string PagerWhere = " where rnum >" + PageStart + " and rnum <= " + PageEnd;//翻页
            //开始拼接新的翻页查询语句
            sql = sql.Insert(0, " select * from ( select " + RowColumn + " * from ( ");
            sql = sql.Insert(sql.Length, ") as rowsub) as TableTemp " + PagerWhere + ";");
            string CountSQL = oldsql.Insert(0, " select count(*) as datacount from (");
            CountSQL += " ) as  counttable";
            sql += CountSQL;
            return sql;
        }
    }
}