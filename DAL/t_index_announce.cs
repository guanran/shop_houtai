using System;
using System.Data;
using System.Text;
using MySql.Data.MySqlClient;
using Maticsoft.DBUtility;//Please add references
namespace Maticsoft.DAL
{
	/// <summary>
	/// 数据访问类:t_index_announce
	/// </summary>
	public partial class t_index_announce
	{
		public t_index_announce()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperMySQL.GetMaxID("iAutoID", "t_index_announce"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int iAutoID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from t_index_announce");
			strSql.Append(" where iAutoID=@iAutoID ");
			MySqlParameter[] parameters = {
					new MySqlParameter("@iAutoID", MySqlDbType.Int32,10)			};
			parameters[0].Value = iAutoID;

			return DbHelperMySQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Maticsoft.Model.t_index_announce model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into t_index_announce(");
			strSql.Append("iAutoID,sTitle,sCover,sSynopsis,iView,iUserID,iCreateTime,iCreateID)");
			strSql.Append(" values (");
			strSql.Append("@iAutoID,@sTitle,@sCover,@sSynopsis,@iView,@iUserID,@iCreateTime,@iCreateID)");
			MySqlParameter[] parameters = {
					new MySqlParameter("@iAutoID", MySqlDbType.Int32,10),
					new MySqlParameter("@sTitle", MySqlDbType.VarChar,255),
					new MySqlParameter("@sCover", MySqlDbType.VarChar,500),
					new MySqlParameter("@sSynopsis", MySqlDbType.VarChar,255),
					new MySqlParameter("@iView", MySqlDbType.Int32,10),
					new MySqlParameter("@iUserID", MySqlDbType.Int32,10),
					new MySqlParameter("@iCreateTime", MySqlDbType.Int32,10),
					new MySqlParameter("@iCreateID", MySqlDbType.Int32,10)};
			parameters[0].Value = model.iAutoID;
			parameters[1].Value = model.sTitle;
			parameters[2].Value = model.sCover;
			parameters[3].Value = model.sSynopsis;
			parameters[4].Value = model.iView;
			parameters[5].Value = model.iUserID;
			parameters[6].Value = model.iCreateTime;
			parameters[7].Value = model.iCreateID;

			int rows=DbHelperMySQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Maticsoft.Model.t_index_announce model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update t_index_announce set ");
			strSql.Append("sTitle=@sTitle,");
			strSql.Append("sCover=@sCover,");
			strSql.Append("sSynopsis=@sSynopsis,");
			strSql.Append("iView=@iView,");
			strSql.Append("iUserID=@iUserID,");
			strSql.Append("iCreateTime=@iCreateTime,");
			strSql.Append("iCreateID=@iCreateID");
			strSql.Append(" where iAutoID=@iAutoID ");
			MySqlParameter[] parameters = {
					new MySqlParameter("@sTitle", MySqlDbType.VarChar,255),
					new MySqlParameter("@sCover", MySqlDbType.VarChar,500),
					new MySqlParameter("@sSynopsis", MySqlDbType.VarChar,255),
					new MySqlParameter("@iView", MySqlDbType.Int32,10),
					new MySqlParameter("@iUserID", MySqlDbType.Int32,10),
					new MySqlParameter("@iCreateTime", MySqlDbType.Int32,10),
					new MySqlParameter("@iCreateID", MySqlDbType.Int32,10),
					new MySqlParameter("@iAutoID", MySqlDbType.Int32,10)};
			parameters[0].Value = model.sTitle;
			parameters[1].Value = model.sCover;
			parameters[2].Value = model.sSynopsis;
			parameters[3].Value = model.iView;
			parameters[4].Value = model.iUserID;
			parameters[5].Value = model.iCreateTime;
			parameters[6].Value = model.iCreateID;
			parameters[7].Value = model.iAutoID;

			int rows=DbHelperMySQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int iAutoID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from t_index_announce ");
			strSql.Append(" where iAutoID=@iAutoID ");
			MySqlParameter[] parameters = {
					new MySqlParameter("@iAutoID", MySqlDbType.Int32,10)			};
			parameters[0].Value = iAutoID;

			int rows=DbHelperMySQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		/// <summary>
		/// 批量删除数据
		/// </summary>
		public bool DeleteList(string iAutoIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from t_index_announce ");
			strSql.Append(" where iAutoID in ("+iAutoIDlist + ")  ");
			int rows=DbHelperMySQL.ExecuteSql(strSql.ToString());
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Maticsoft.Model.t_index_announce GetModel(int iAutoID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select iAutoID,sTitle,sCover,sSynopsis,iView,iUserID,iCreateTime,iCreateID from t_index_announce ");
			strSql.Append(" where iAutoID=@iAutoID ");
			MySqlParameter[] parameters = {
					new MySqlParameter("@iAutoID", MySqlDbType.Int32,10)			};
			parameters[0].Value = iAutoID;

			Maticsoft.Model.t_index_announce model=new Maticsoft.Model.t_index_announce();
			DataSet ds=DbHelperMySQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				return DataRowToModel(ds.Tables[0].Rows[0]);
			}
			else
			{
				return null;
			}
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Maticsoft.Model.t_index_announce DataRowToModel(DataRow row)
		{
			Maticsoft.Model.t_index_announce model=new Maticsoft.Model.t_index_announce();
			if (row != null)
			{
				if(row["iAutoID"]!=null && row["iAutoID"].ToString()!="")
				{
					model.iAutoID=int.Parse(row["iAutoID"].ToString());
				}
				if(row["sTitle"]!=null)
				{
					model.sTitle=row["sTitle"].ToString();
				}
				if(row["sCover"]!=null)
				{
					model.sCover=row["sCover"].ToString();
				}
				if(row["sSynopsis"]!=null)
				{
					model.sSynopsis=row["sSynopsis"].ToString();
				}
				if(row["iView"]!=null && row["iView"].ToString()!="")
				{
					model.iView=int.Parse(row["iView"].ToString());
				}
				if(row["iUserID"]!=null && row["iUserID"].ToString()!="")
				{
					model.iUserID=int.Parse(row["iUserID"].ToString());
				}
				if(row["iCreateTime"]!=null && row["iCreateTime"].ToString()!="")
				{
					model.iCreateTime=int.Parse(row["iCreateTime"].ToString());
				}
				if(row["iCreateID"]!=null && row["iCreateID"].ToString()!="")
				{
					model.iCreateID=int.Parse(row["iCreateID"].ToString());
				}
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select iAutoID,sTitle,sCover,sSynopsis,iView,iUserID,iCreateTime,iCreateID ");
			strSql.Append(" FROM t_index_announce ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperMySQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获取记录总数
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM t_index_announce ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			object obj = DbHelperSQL.GetSingle(strSql.ToString());
			if (obj == null)
			{
				return 0;
			}
			else
			{
				return Convert.ToInt32(obj);
			}
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("SELECT * FROM ( ");
			strSql.Append(" SELECT ROW_NUMBER() OVER (");
			if (!string.IsNullOrEmpty(orderby.Trim()))
			{
				strSql.Append("order by T." + orderby );
			}
			else
			{
				strSql.Append("order by T.iAutoID desc");
			}
			strSql.Append(")AS Row, T.*  from t_index_announce T ");
			if (!string.IsNullOrEmpty(strWhere.Trim()))
			{
				strSql.Append(" WHERE " + strWhere);
			}
			strSql.Append(" ) TT");
			strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
			return DbHelperMySQL.Query(strSql.ToString());
		}

		/*
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		{
			MySqlParameter[] parameters = {
					new MySqlParameter("@tblName", MySqlDbType.VarChar, 255),
					new MySqlParameter("@fldName", MySqlDbType.VarChar, 255),
					new MySqlParameter("@PageSize", MySqlDbType.Int32),
					new MySqlParameter("@PageIndex", MySqlDbType.Int32),
					new MySqlParameter("@IsReCount", MySqlDbType.Bit),
					new MySqlParameter("@OrderType", MySqlDbType.Bit),
					new MySqlParameter("@strWhere", MySqlDbType.VarChar,1000),
					};
			parameters[0].Value = "t_index_announce";
			parameters[1].Value = "iAutoID";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperMySQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

