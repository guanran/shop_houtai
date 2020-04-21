using System;
using System.Data;
using System.Text;
using MySql.Data.MySqlClient;
using Maticsoft.DBUtility;//Please add references
namespace Maticsoft.DAL
{
	/// <summary>
	/// 数据访问类:t_index_banner
	/// </summary>
	public partial class t_index_banner
	{
		public t_index_banner()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperMySQL.GetMaxID("iAutoID", "t_index_banner"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int iAutoID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from t_index_banner");
			strSql.Append(" where iAutoID=@iAutoID");
			MySqlParameter[] parameters = {
					new MySqlParameter("@iAutoID", MySqlDbType.Int32)
			};
			parameters[0].Value = iAutoID;

			return DbHelperMySQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Maticsoft.Model.t_index_banner model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into t_index_banner(");
			strSql.Append("sName,sImg,sBackGround,sUrl,iType,iAdminID,iOnline,iSort,iStatus,iCreateTime,iUpdateTime)");
			strSql.Append(" values (");
			strSql.Append("@sName,@sImg,@sBackGround,@sUrl,@iType,@iAdminID,@iOnline,@iSort,@iStatus,@iCreateTime,@iUpdateTime)");
			MySqlParameter[] parameters = {
					new MySqlParameter("@sName", MySqlDbType.VarChar,255),
					new MySqlParameter("@sImg", MySqlDbType.VarChar,500),
					new MySqlParameter("@sBackGround", MySqlDbType.VarChar,50),
					new MySqlParameter("@sUrl", MySqlDbType.VarChar,200),
					new MySqlParameter("@iType", MySqlDbType.Int32,1),
					new MySqlParameter("@iAdminID", MySqlDbType.Int32,10),
					new MySqlParameter("@iOnline", MySqlDbType.Int32,1),
					new MySqlParameter("@iSort", MySqlDbType.Int32,1),
					new MySqlParameter("@iStatus", MySqlDbType.Int32,1),
					new MySqlParameter("@iCreateTime", MySqlDbType.Int32,10),
					new MySqlParameter("@iUpdateTime", MySqlDbType.Int32,10)};
			parameters[0].Value = model.sName;
			parameters[1].Value = model.sImg;
			parameters[2].Value = model.sBackGround;
			parameters[3].Value = model.sUrl;
			parameters[4].Value = model.iType;
			parameters[5].Value = model.iAdminID;
			parameters[6].Value = model.iOnline;
			parameters[7].Value = model.iSort;
			parameters[8].Value = model.iStatus;
			parameters[9].Value = model.iCreateTime;
			parameters[10].Value = model.iUpdateTime;

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
		public bool Update(Maticsoft.Model.t_index_banner model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update t_index_banner set ");
			strSql.Append("sName=@sName,");
			strSql.Append("sImg=@sImg,");
			strSql.Append("sBackGround=@sBackGround,");
			strSql.Append("sUrl=@sUrl,");
			strSql.Append("iType=@iType,");
			strSql.Append("iAdminID=@iAdminID,");
			strSql.Append("iOnline=@iOnline,");
			strSql.Append("iSort=@iSort,");
			strSql.Append("iStatus=@iStatus,");
			strSql.Append("iCreateTime=@iCreateTime,");
			strSql.Append("iUpdateTime=@iUpdateTime");
			strSql.Append(" where iAutoID=@iAutoID");
			MySqlParameter[] parameters = {
					new MySqlParameter("@sName", MySqlDbType.VarChar,255),
					new MySqlParameter("@sImg", MySqlDbType.VarChar,500),
					new MySqlParameter("@sBackGround", MySqlDbType.VarChar,50),
					new MySqlParameter("@sUrl", MySqlDbType.VarChar,200),
					new MySqlParameter("@iType", MySqlDbType.Int32,1),
					new MySqlParameter("@iAdminID", MySqlDbType.Int32,10),
					new MySqlParameter("@iOnline", MySqlDbType.Int32,1),
					new MySqlParameter("@iSort", MySqlDbType.Int32,1),
					new MySqlParameter("@iStatus", MySqlDbType.Int32,1),
					new MySqlParameter("@iCreateTime", MySqlDbType.Int32,10),
					new MySqlParameter("@iUpdateTime", MySqlDbType.Int32,10),
					new MySqlParameter("@iAutoID", MySqlDbType.Int32,10)};
			parameters[0].Value = model.sName;
			parameters[1].Value = model.sImg;
			parameters[2].Value = model.sBackGround;
			parameters[3].Value = model.sUrl;
			parameters[4].Value = model.iType;
			parameters[5].Value = model.iAdminID;
			parameters[6].Value = model.iOnline;
			parameters[7].Value = model.iSort;
			parameters[8].Value = model.iStatus;
			parameters[9].Value = model.iCreateTime;
			parameters[10].Value = model.iUpdateTime;
			parameters[11].Value = model.iAutoID;

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
			strSql.Append("delete from t_index_banner ");
			strSql.Append(" where iAutoID=@iAutoID");
			MySqlParameter[] parameters = {
					new MySqlParameter("@iAutoID", MySqlDbType.Int32)
			};
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
			strSql.Append("delete from t_index_banner ");
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
		public Maticsoft.Model.t_index_banner GetModel(int iAutoID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select iAutoID,sName,sImg,sBackGround,sUrl,iType,iAdminID,iOnline,iSort,iStatus,iCreateTime,iUpdateTime from t_index_banner ");
			strSql.Append(" where iAutoID=@iAutoID");
			MySqlParameter[] parameters = {
					new MySqlParameter("@iAutoID", MySqlDbType.Int32)
			};
			parameters[0].Value = iAutoID;

			Maticsoft.Model.t_index_banner model=new Maticsoft.Model.t_index_banner();
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
		public Maticsoft.Model.t_index_banner DataRowToModel(DataRow row)
		{
			Maticsoft.Model.t_index_banner model=new Maticsoft.Model.t_index_banner();
			if (row != null)
			{
				if(row["iAutoID"]!=null && row["iAutoID"].ToString()!="")
				{
					model.iAutoID=int.Parse(row["iAutoID"].ToString());
				}
				if(row["sName"]!=null)
				{
					model.sName=row["sName"].ToString();
				}
				if(row["sImg"]!=null)
				{
					model.sImg=row["sImg"].ToString();
				}
				if(row["sBackGround"]!=null)
				{
					model.sBackGround=row["sBackGround"].ToString();
				}
				if(row["sUrl"]!=null)
				{
					model.sUrl=row["sUrl"].ToString();
				}
				if(row["iType"]!=null && row["iType"].ToString()!="")
				{
					model.iType=int.Parse(row["iType"].ToString());
				}
				if(row["iAdminID"]!=null && row["iAdminID"].ToString()!="")
				{
					model.iAdminID=int.Parse(row["iAdminID"].ToString());
				}
				if(row["iOnline"]!=null && row["iOnline"].ToString()!="")
				{
					model.iOnline=int.Parse(row["iOnline"].ToString());
				}
				if(row["iSort"]!=null && row["iSort"].ToString()!="")
				{
					model.iSort=int.Parse(row["iSort"].ToString());
				}
				if(row["iStatus"]!=null && row["iStatus"].ToString()!="")
				{
					model.iStatus=int.Parse(row["iStatus"].ToString());
				}
				if(row["iCreateTime"]!=null && row["iCreateTime"].ToString()!="")
				{
					model.iCreateTime=int.Parse(row["iCreateTime"].ToString());
				}
				if(row["iUpdateTime"]!=null && row["iUpdateTime"].ToString()!="")
				{
					model.iUpdateTime=int.Parse(row["iUpdateTime"].ToString());
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
			strSql.Append("select iAutoID,sName,sImg,sBackGround,sUrl,iType,iAdminID,iOnline,iSort,iStatus,iCreateTime,iUpdateTime ");
			strSql.Append(" FROM t_index_banner ");
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
			strSql.Append("select count(1) FROM t_index_banner ");
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
			strSql.Append(")AS Row, T.*  from t_index_banner T ");
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
			parameters[0].Value = "t_index_banner";
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

