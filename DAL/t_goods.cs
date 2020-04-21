using System;
using System.Data;
using System.Text;
using MySql.Data.MySqlClient;
using Maticsoft.DBUtility;//Please add references
namespace Maticsoft.DAL
{
	/// <summary>
	/// 数据访问类:t_goods
	/// </summary>
	public partial class t_goods
	{
		public t_goods()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperMySQL.GetMaxID("id", "t_goods"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from t_goods");
			strSql.Append(" where id=@id");
			MySqlParameter[] parameters = {
					new MySqlParameter("@id", MySqlDbType.Int32)
			};
			parameters[0].Value = id;

			return DbHelperMySQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Maticsoft.Model.t_goods model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into t_goods(");
			strSql.Append("topType,type,goodsName,minPrice,maxPrice,sell_min_price,sell_max_price,describe,status,createTime,updateTime,url)");
			strSql.Append(" values (");
			strSql.Append("@topType,@type,@goodsName,@minPrice,@maxPrice,@sell_min_price,@sell_max_price,@describe,@status,@createTime,@updateTime,@url)");
			MySqlParameter[] parameters = {
					new MySqlParameter("@topType", MySqlDbType.VarChar,255),
					new MySqlParameter("@type", MySqlDbType.VarChar,255),
					new MySqlParameter("@goodsName", MySqlDbType.VarChar,255),
					new MySqlParameter("@minPrice", MySqlDbType.Decimal,10),
					new MySqlParameter("@maxPrice", MySqlDbType.Decimal,10),
					new MySqlParameter("@sell_min_price", MySqlDbType.Decimal,10),
					new MySqlParameter("@sell_max_price", MySqlDbType.Decimal,10),
					new MySqlParameter("@describe", MySqlDbType.VarChar,255),
					new MySqlParameter("@status", MySqlDbType.Int32,11),
					new MySqlParameter("@createTime", MySqlDbType.DateTime),
					new MySqlParameter("@updateTime", MySqlDbType.DateTime),
					new MySqlParameter("@url", MySqlDbType.VarChar,255)};
			parameters[0].Value = model.topType;
			parameters[1].Value = model.type;
			parameters[2].Value = model.goodsName;
			parameters[3].Value = model.minPrice;
			parameters[4].Value = model.maxPrice;
			parameters[5].Value = model.sell_min_price;
			parameters[6].Value = model.sell_max_price;
			parameters[7].Value = model.describe;
			parameters[8].Value = model.status;
			parameters[9].Value = model.createTime;
			parameters[10].Value = model.updateTime;
			parameters[11].Value = model.url;

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
		public bool Update(Maticsoft.Model.t_goods model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update t_goods set ");
			strSql.Append("topType=@topType,");
			strSql.Append("type=@type,");
			strSql.Append("goodsName=@goodsName,");
			strSql.Append("minPrice=@minPrice,");
			strSql.Append("maxPrice=@maxPrice,");
			strSql.Append("sell_min_price=@sell_min_price,");
			strSql.Append("sell_max_price=@sell_max_price,");
			strSql.Append("describe=@describe,");
			strSql.Append("status=@status,");
			strSql.Append("createTime=@createTime,");
			strSql.Append("updateTime=@updateTime,");
			strSql.Append("url=@url");
			strSql.Append(" where id=@id");
			MySqlParameter[] parameters = {
					new MySqlParameter("@topType", MySqlDbType.VarChar,255),
					new MySqlParameter("@type", MySqlDbType.VarChar,255),
					new MySqlParameter("@goodsName", MySqlDbType.VarChar,255),
					new MySqlParameter("@minPrice", MySqlDbType.Decimal,10),
					new MySqlParameter("@maxPrice", MySqlDbType.Decimal,10),
					new MySqlParameter("@sell_min_price", MySqlDbType.Decimal,10),
					new MySqlParameter("@sell_max_price", MySqlDbType.Decimal,10),
					new MySqlParameter("@describe", MySqlDbType.VarChar,255),
					new MySqlParameter("@status", MySqlDbType.Int32,11),
					new MySqlParameter("@createTime", MySqlDbType.DateTime),
					new MySqlParameter("@updateTime", MySqlDbType.DateTime),
					new MySqlParameter("@url", MySqlDbType.VarChar,255),
					new MySqlParameter("@id", MySqlDbType.Int32,11)};
			parameters[0].Value = model.topType;
			parameters[1].Value = model.type;
			parameters[2].Value = model.goodsName;
			parameters[3].Value = model.minPrice;
			parameters[4].Value = model.maxPrice;
			parameters[5].Value = model.sell_min_price;
			parameters[6].Value = model.sell_max_price;
			parameters[7].Value = model.describe;
			parameters[8].Value = model.status;
			parameters[9].Value = model.createTime;
			parameters[10].Value = model.updateTime;
			parameters[11].Value = model.url;
			parameters[12].Value = model.id;

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
		public bool Delete(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from t_goods ");
			strSql.Append(" where id=@id");
			MySqlParameter[] parameters = {
					new MySqlParameter("@id", MySqlDbType.Int32)
			};
			parameters[0].Value = id;

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
		public bool DeleteList(string idlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from t_goods ");
			strSql.Append(" where id in ("+idlist + ")  ");
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
		public Maticsoft.Model.t_goods GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select id,topType,type,goodsName,minPrice,maxPrice,sell_min_price,sell_max_price,describe,status,createTime,updateTime,url from t_goods ");
			strSql.Append(" where id=@id");
			MySqlParameter[] parameters = {
					new MySqlParameter("@id", MySqlDbType.Int32)
			};
			parameters[0].Value = id;

			Maticsoft.Model.t_goods model=new Maticsoft.Model.t_goods();
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
		public Maticsoft.Model.t_goods DataRowToModel(DataRow row)
		{
			Maticsoft.Model.t_goods model=new Maticsoft.Model.t_goods();
			if (row != null)
			{
				if(row["id"]!=null && row["id"].ToString()!="")
				{
					model.id=int.Parse(row["id"].ToString());
				}
				if(row["topType"]!=null)
				{
					model.topType=row["topType"].ToString();
				}
				if(row["type"]!=null)
				{
					model.type=row["type"].ToString();
				}
				if(row["goodsName"]!=null)
				{
					model.goodsName=row["goodsName"].ToString();
				}
				if(row["minPrice"]!=null && row["minPrice"].ToString()!="")
				{
					model.minPrice=decimal.Parse(row["minPrice"].ToString());
				}
				if(row["maxPrice"]!=null && row["maxPrice"].ToString()!="")
				{
					model.maxPrice=decimal.Parse(row["maxPrice"].ToString());
				}
				if(row["sell_min_price"]!=null && row["sell_min_price"].ToString()!="")
				{
					model.sell_min_price=decimal.Parse(row["sell_min_price"].ToString());
				}
				if(row["sell_max_price"]!=null && row["sell_max_price"].ToString()!="")
				{
					model.sell_max_price=decimal.Parse(row["sell_max_price"].ToString());
				}
				if(row["describe"]!=null)
				{
					model.describe=row["describe"].ToString();
				}
				if(row["status"]!=null && row["status"].ToString()!="")
				{
					model.status=int.Parse(row["status"].ToString());
				}
				if(row["createTime"]!=null && row["createTime"].ToString()!="")
				{
					model.createTime=DateTime.Parse(row["createTime"].ToString());
				}
				if(row["updateTime"]!=null && row["updateTime"].ToString()!="")
				{
					model.updateTime=DateTime.Parse(row["updateTime"].ToString());
				}
				if(row["url"]!=null)
				{
					model.url=row["url"].ToString();
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
			strSql.Append("select id,topType,type,goodsName,minPrice,maxPrice,sell_min_price,sell_max_price,describe,status,createTime,updateTime,url ");
			strSql.Append(" FROM t_goods ");
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
			strSql.Append("select count(1) FROM t_goods ");
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
				strSql.Append("order by T.id desc");
			}
			strSql.Append(")AS Row, T.*  from t_goods T ");
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
			parameters[0].Value = "t_goods";
			parameters[1].Value = "id";
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

