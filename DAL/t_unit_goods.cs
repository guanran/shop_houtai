using System;
using System.Data;
using System.Text;
using MySql.Data.MySqlClient;
using Maticsoft.DBUtility;//Please add references
namespace Maticsoft.DAL
{
	/// <summary>
	/// 数据访问类:t_unit_goods
	/// </summary>
	public partial class t_unit_goods
	{
		public t_unit_goods()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperMySQL.GetMaxID("id", "t_unit_goods"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from t_unit_goods");
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
		public bool Add(Maticsoft.Model.t_unit_goods model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into t_unit_goods(");
			strSql.Append("unit_id,goods_id,goods_name,goods_name_new,count,price,sell_min_price,sell_max_price,create_time,update_time,status_code)");
			strSql.Append(" values (");
			strSql.Append("@unit_id,@goods_id,@goods_name,@goods_name_new,@count,@price,@sell_min_price,@sell_max_price,@create_time,@update_time,@status_code)");
			MySqlParameter[] parameters = {
					new MySqlParameter("@unit_id", MySqlDbType.Int32,11),
					new MySqlParameter("@goods_id", MySqlDbType.Int32,11),
					new MySqlParameter("@goods_name", MySqlDbType.VarChar,255),
					new MySqlParameter("@goods_name_new", MySqlDbType.VarChar,255),
					new MySqlParameter("@count", MySqlDbType.Int32,11),
					new MySqlParameter("@price", MySqlDbType.Decimal,10),
					new MySqlParameter("@sell_min_price", MySqlDbType.Decimal,10),
					new MySqlParameter("@sell_max_price", MySqlDbType.Decimal,10),
					new MySqlParameter("@create_time", MySqlDbType.DateTime),
					new MySqlParameter("@update_time", MySqlDbType.DateTime),
					new MySqlParameter("@status_code", MySqlDbType.Int32,255)};
			parameters[0].Value = model.unit_id;
			parameters[1].Value = model.goods_id;
			parameters[2].Value = model.goods_name;
			parameters[3].Value = model.goods_name_new;
			parameters[4].Value = model.count;
			parameters[5].Value = model.price;
			parameters[6].Value = model.sell_min_price;
			parameters[7].Value = model.sell_max_price;
			parameters[8].Value = model.create_time;
			parameters[9].Value = model.update_time;
			parameters[10].Value = model.status_code;

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
		public bool Update(Maticsoft.Model.t_unit_goods model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update t_unit_goods set ");
			strSql.Append("unit_id=@unit_id,");
			strSql.Append("goods_id=@goods_id,");
			strSql.Append("goods_name=@goods_name,");
			strSql.Append("goods_name_new=@goods_name_new,");
			strSql.Append("count=@count,");
			strSql.Append("price=@price,");
			strSql.Append("sell_min_price=@sell_min_price,");
			strSql.Append("sell_max_price=@sell_max_price,");
			strSql.Append("create_time=@create_time,");
			strSql.Append("update_time=@update_time,");
			strSql.Append("status_code=@status_code");
			strSql.Append(" where id=@id");
			MySqlParameter[] parameters = {
					new MySqlParameter("@unit_id", MySqlDbType.Int32,11),
					new MySqlParameter("@goods_id", MySqlDbType.Int32,11),
					new MySqlParameter("@goods_name", MySqlDbType.VarChar,255),
					new MySqlParameter("@goods_name_new", MySqlDbType.VarChar,255),
					new MySqlParameter("@count", MySqlDbType.Int32,11),
					new MySqlParameter("@price", MySqlDbType.Decimal,10),
					new MySqlParameter("@sell_min_price", MySqlDbType.Decimal,10),
					new MySqlParameter("@sell_max_price", MySqlDbType.Decimal,10),
					new MySqlParameter("@create_time", MySqlDbType.DateTime),
					new MySqlParameter("@update_time", MySqlDbType.DateTime),
					new MySqlParameter("@status_code", MySqlDbType.Int32,255),
					new MySqlParameter("@id", MySqlDbType.Int32,11)};
			parameters[0].Value = model.unit_id;
			parameters[1].Value = model.goods_id;
			parameters[2].Value = model.goods_name;
			parameters[3].Value = model.goods_name_new;
			parameters[4].Value = model.count;
			parameters[5].Value = model.price;
			parameters[6].Value = model.sell_min_price;
			parameters[7].Value = model.sell_max_price;
			parameters[8].Value = model.create_time;
			parameters[9].Value = model.update_time;
			parameters[10].Value = model.status_code;
			parameters[11].Value = model.id;

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
			strSql.Append("delete from t_unit_goods ");
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
			strSql.Append("delete from t_unit_goods ");
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
		public Maticsoft.Model.t_unit_goods GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select id,unit_id,goods_id,goods_name,goods_name_new,count,price,sell_min_price,sell_max_price,create_time,update_time,status_code from t_unit_goods ");
			strSql.Append(" where id=@id");
			MySqlParameter[] parameters = {
					new MySqlParameter("@id", MySqlDbType.Int32)
			};
			parameters[0].Value = id;

			Maticsoft.Model.t_unit_goods model=new Maticsoft.Model.t_unit_goods();
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
		public Maticsoft.Model.t_unit_goods DataRowToModel(DataRow row)
		{
			Maticsoft.Model.t_unit_goods model=new Maticsoft.Model.t_unit_goods();
			if (row != null)
			{
				if(row["id"]!=null && row["id"].ToString()!="")
				{
					model.id=int.Parse(row["id"].ToString());
				}
				if(row["unit_id"]!=null && row["unit_id"].ToString()!="")
				{
					model.unit_id=int.Parse(row["unit_id"].ToString());
				}
				if(row["goods_id"]!=null && row["goods_id"].ToString()!="")
				{
					model.goods_id=int.Parse(row["goods_id"].ToString());
				}
				if(row["goods_name"]!=null)
				{
					model.goods_name=row["goods_name"].ToString();
				}
				if(row["goods_name_new"]!=null)
				{
					model.goods_name_new=row["goods_name_new"].ToString();
				}
				if(row["count"]!=null && row["count"].ToString()!="")
				{
					model.count=int.Parse(row["count"].ToString());
				}
				if(row["price"]!=null && row["price"].ToString()!="")
				{
					model.price=decimal.Parse(row["price"].ToString());
				}
				if(row["sell_min_price"]!=null && row["sell_min_price"].ToString()!="")
				{
					model.sell_min_price=decimal.Parse(row["sell_min_price"].ToString());
				}
				if(row["sell_max_price"]!=null && row["sell_max_price"].ToString()!="")
				{
					model.sell_max_price=decimal.Parse(row["sell_max_price"].ToString());
				}
				if(row["create_time"]!=null && row["create_time"].ToString()!="")
				{
					model.create_time=DateTime.Parse(row["create_time"].ToString());
				}
				if(row["update_time"]!=null && row["update_time"].ToString()!="")
				{
					model.update_time=DateTime.Parse(row["update_time"].ToString());
				}
				if(row["status_code"]!=null && row["status_code"].ToString()!="")
				{
					model.status_code=int.Parse(row["status_code"].ToString());
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
			strSql.Append("select id,unit_id,goods_id,goods_name,goods_name_new,count,price,sell_min_price,sell_max_price,create_time,update_time,status_code ");
			strSql.Append(" FROM t_unit_goods ");
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
			strSql.Append("select count(1) FROM t_unit_goods ");
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
			strSql.Append(")AS Row, T.*  from t_unit_goods T ");
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
			parameters[0].Value = "t_unit_goods";
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

