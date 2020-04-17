using Entity.common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;

namespace DAO.BaseDAL
{
    public interface IORMHelper<T> where T : class
    {
        DbContext SetDbContext(DbContext session = null);
        void SaveChanges();
        T Get(object id);
        T Get(Expression<Func<IQueryable<T>, IQueryable<T>>> predicate);
        List<T> GetList();
        List<T> GetList(Expression<Func<IQueryable<T>, IQueryable<T>>> predicate);
        PagedList<T> GetPagedList(Expression<Func<IQueryable<T>, IQueryable<T>>> predicate, int pageSize, int pageIndex);
        void Insert(T obj, bool IsSaveChanges = true);
        void Insert(List<T> list, bool IsSaveChanges = true);
        void Update(T obj, bool IsSaveChanges = true);
        void Update(List<T> obj, bool IsSaveChanges = true);
        void Delete(T obj, bool IsSaveChanges = true);
        void Delete(object id, bool IsSaveChanges = true);
        void Delete(List<T> obj, bool IsSaveChanges = true);
        void Delete(object[] id, bool IsSaveChanges = true);
        int ExecuteSql(string SQLString, bool IsSaveChanges = true);
        int ExecuteSql(string SQLString, bool IsSaveChanges = true, params SqlParameter[] cmdParms);
        List<T> QueryList(string SQLString, params SqlParameter[] cmdParms);
        DataSet Query(string SQLString, params SqlParameter[] cmdParms);
        PagedList<T> QueryPagedList(string SQLString, int pageSize, int pageIndex, string SortString, params SqlParameter[] cmdParms);
        DataSet QueryPaged(string SQLString, int pageSize, int pageIndex, out int totalItemCount, string SortString, params SqlParameter[] cmdParms);
    }
}