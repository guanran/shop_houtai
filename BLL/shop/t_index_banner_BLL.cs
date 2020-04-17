using System;
using System.Data;
using System.Collections.Generic;
using Entity;
using DAO;

namespace BLL
{
	/// <summary>
	/// t_index_banner
	/// </summary>
	public partial class t_index_banner_BLL
	{
		private readonly t_index_banner_DAL dal=new t_index_banner_DAL();
		public t_index_banner_BLL()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
			return dal.GetMaxId();
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int iAutoID)
		{
			return dal.Exists(iAutoID);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(t_index_banner model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(t_index_banner model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int iAutoID)
		{
			
			return dal.Delete(iAutoID);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string iAutoIDlist )
		{
			return dal.DeleteList(iAutoIDlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public t_index_banner GetModel(int iAutoID)
		{
			
			return dal.GetModel(iAutoID);
		}

		

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<t_index_banner> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<t_index_banner> DataTableToList(DataTable dt)
		{
			List<t_index_banner> modelList = new List<t_index_banner>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				t_index_banner model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = dal.DataRowToModel(dt.Rows[n]);
					if (model != null)
					{
						modelList.Add(model);
					}
				}
			}
			return modelList;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetAllList()
		{
			return GetList("");
		}

		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			return dal.GetRecordCount(strWhere);
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			return dal.GetListByPage( strWhere,  orderby,  startIndex,  endIndex);
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		//public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		//{
			//return dal.GetList(PageSize,PageIndex,strWhere);
		//}

		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

