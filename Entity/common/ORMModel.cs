using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.common
{

    public class ORMModel
    {
    }
    public class EntityField
    {
        public string ColumnName { get; set; }
        public string ColumnValue { get; set; }
        public Type ColumnDataType { get; set; }
        public ColumnType ColumnType { get; set; }
    }

    public interface IPagedList
    {
        int CurrentPageIndex { get; set; }
        int PageSize { get; set; }
        int TotalItemCount { get; set; }
    }
    public class PagedList<T> : List<T>, IPagedList
    {
        public PagedList(IList<T> items, int pageIndex, int pageSize)
        {
            PageSize = pageSize;
            TotalItemCount = items.Count;
            CurrentPageIndex = pageIndex;
            for (int i = StartRecordIndex - 1; i < EndRecordIndex; i++)
            {
                Add(items[i]);
            }
        }

        public PagedList(IEnumerable<T> items, int pageIndex, int pageSize, int totalItemCount)
        {
            if (items != null)
            {
                AddRange(items);
            }


            TotalItemCount = totalItemCount;
            CurrentPageIndex = pageIndex;
            PageSize = pageSize;
        }

        public PagedList()
        {
            // TODO: Complete member initialization
        }

        /// <summary>
        /// PageIndex
        /// </summary>
        public int CurrentPageIndex { get; set; }
        public int PageSize { get; set; }
        public int TotalItemCount { get; set; }
        public int TotalPageCount { get { return (int)Math.Ceiling(TotalItemCount / (double)PageSize); } }

        /// <summary>
        /// Start Item Index
        /// </summary>
        public int StartRecordIndex { get { return (CurrentPageIndex - 1) * PageSize + 1; } }

        /// <summary>
        /// End Item Index
        /// </summary>
        public int EndRecordIndex { get { return TotalItemCount > CurrentPageIndex * PageSize ? CurrentPageIndex * PageSize : TotalItemCount; } }
    }


    [AttributeUsage(AttributeTargets.Class)]
    public class TableAttribute : Attribute
    {
        public string TableName { get; set; }
        public TableAttribute(string tableName)
        {
            this.TableName = tableName;
        }
    }
    [AttributeUsage(AttributeTargets.Enum | AttributeTargets.Property | AttributeTargets.Field)]
    public class ColumnAttribute : Attribute
    {
        public string ColumnName { get; set; }
        public ColumnType ColumnType { get; set; }
        public ColumnAttribute(string columnName)
        {
            this.ColumnName = columnName;
        }
        public ColumnAttribute(string columnName, ColumnType columnType)
        {
            this.ColumnName = columnName;
            this.ColumnType = columnType;
        }
    }
    public enum ColumnType
    {
        Normal = 0,
        PrimaryKey = 1,
        ReadOnly = 2,
        Identity = 3,
        IdentityAndPrimaryKey = 4,
    }
}