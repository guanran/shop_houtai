using System;
using System.Configuration;
using System.Data;
using System.Text;
using MySql.Data.MySqlClient;
using Entity;
using DAO.DBUtility;
namespace DAO
{
	/// <summary>
	/// 数据访问类:t_unit
	/// </summary>
	public partial class t_unit_DAL
    {
		public t_unit_DAL()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperMySQL.GetMaxID("id", "t_unit"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from t_unit");
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
		public bool Add(t_unit model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into t_unit(");
			strSql.Append("code,unit_kind,unit_name,count,price,total_price,begin_time,end_time,status_code,create_time,update_time)");
			strSql.Append(" values (");
			strSql.Append("@code,@unit_kind,@unit_name,@count,@price,@total_price,@begin_time,@end_time,@status_code,@create_time,@update_time)");
			MySqlParameter[] parameters = {
					new MySqlParameter("@code", MySqlDbType.VarChar,255),
					new MySqlParameter("@unit_kind", MySqlDbType.VarChar,255),
					new MySqlParameter("@unit_name", MySqlDbType.VarChar,255),
					new MySqlParameter("@count", MySqlDbType.Int32,11),
					new MySqlParameter("@price", MySqlDbType.Decimal,10),
					new MySqlParameter("@total_price", MySqlDbType.Decimal,10),
					new MySqlParameter("@begin_time", MySqlDbType.DateTime),
					new MySqlParameter("@end_time", MySqlDbType.DateTime),
					new MySqlParameter("@status_code", MySqlDbType.Int32,255),
					new MySqlParameter("@create_time", MySqlDbType.DateTime),
					new MySqlParameter("@update_time", MySqlDbType.DateTime)};
			parameters[0].Value = model.code;
			parameters[1].Value = model.unit_kind;
			parameters[2].Value = model.unit_name;
			parameters[3].Value = model.count;
			parameters[4].Value = model.price;
			parameters[5].Value = model.total_price;
			parameters[6].Value = model.begin_time;
			parameters[7].Value = model.end_time;
			parameters[8].Value = model.status_code;
			parameters[9].Value = model.create_time;
			parameters[10].Value = model.update_time;

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
		public bool Update(t_unit model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update t_unit set ");
			strSql.Append("code=@code,");
			strSql.Append("unit_kind=@unit_kind,");
			strSql.Append("unit_name=@unit_name,");
			strSql.Append("count=@count,");
			strSql.Append("price=@price,");
			strSql.Append("total_price=@total_price,");
			strSql.Append("begin_time=@begin_time,");
			strSql.Append("end_time=@end_time,");
			strSql.Append("status_code=@status_code,");
			strSql.Append("create_time=@create_time,");
			strSql.Append("update_time=@update_time");
			strSql.Append(" where id=@id");
			MySqlParameter[] parameters = {
					new MySqlParameter("@code", MySqlDbType.VarChar,255),
					new MySqlParameter("@unit_kind", MySqlDbType.VarChar,255),
					new MySqlParameter("@unit_name", MySqlDbType.VarChar,255),
					new MySqlParameter("@count", MySqlDbType.Int32,11),
					new MySqlParameter("@price", MySqlDbType.Decimal,10),
					new MySqlParameter("@total_price", MySqlDbType.Decimal,10),
					new MySqlParameter("@begin_time", MySqlDbType.DateTime),
					new MySqlParameter("@end_time", MySqlDbType.DateTime),
					new MySqlParameter("@status_code", MySqlDbType.Int32,255),
					new MySqlParameter("@create_time", MySqlDbType.DateTime),
					new MySqlParameter("@update_time", MySqlDbType.DateTime),
					new MySqlParameter("@id", MySqlDbType.Int32,11)};
			parameters[0].Value = model.code;
			parameters[1].Value = model.unit_kind;
			parameters[2].Value = model.unit_name;
			parameters[3].Value = model.count;
			parameters[4].Value = model.price;
			parameters[5].Value = model.total_price;
			parameters[6].Value = model.begin_time;
			parameters[7].Value = model.end_time;
			parameters[8].Value = model.status_code;
			parameters[9].Value = model.create_time;
			parameters[10].Value = model.update_time;
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
			strSql.Append("delete from t_unit ");
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
			strSql.Append("delete from t_unit ");
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
		public t_unit GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select id,code,unit_kind,unit_name,count,price,total_price,begin_time,end_time,status_code,create_time,update_time from t_unit ");
			strSql.Append(" where id=@id");
			MySqlParameter[] parameters = {
					new MySqlParameter("@id", MySqlDbType.Int32)
			};
			parameters[0].Value = id;

			t_unit model=new t_unit();
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
		public t_unit DataRowToModel(DataRow row)
		{
			t_unit model=new t_unit();
			if (row != null)
			{
				if(row["id"]!=null && row["id"].ToString()!="")
				{
					model.id=int.Parse(row["id"].ToString());
				}
				if(row["code"]!=null)
				{
					model.code=row["code"].ToString();
				}
				if(row["unit_kind"]!=null)
				{
					model.unit_kind=row["unit_kind"].ToString();
				}
				if(row["unit_name"]!=null)
				{
					model.unit_name=row["unit_name"].ToString();
				}
				if(row["count"]!=null && row["count"].ToString()!="")
				{
					model.count=int.Parse(row["count"].ToString());
				}
				if(row["price"]!=null && row["price"].ToString()!="")
				{
					model.price=decimal.Parse(row["price"].ToString());
				}
				if(row["total_price"]!=null && row["total_price"].ToString()!="")
				{
					model.total_price=decimal.Parse(row["total_price"].ToString());
				}
				if(row["begin_time"]!=null && row["begin_time"].ToString()!="")
				{
					model.begin_time=DateTime.Parse(row["begin_time"].ToString());
				}
				if(row["end_time"]!=null && row["end_time"].ToString()!="")
				{
					model.end_time=DateTime.Parse(row["end_time"].ToString());
				}
				if(row["status_code"]!=null && row["status_code"].ToString()!="")
				{
					model.status_code=int.Parse(row["status_code"].ToString());
				}
				if(row["create_time"]!=null && row["create_time"].ToString()!="")
				{
					model.create_time=DateTime.Parse(row["create_time"].ToString());
				}
				if(row["update_time"]!=null && row["update_time"].ToString()!="")
				{
					model.update_time=DateTime.Parse(row["update_time"].ToString());
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
			strSql.Append("select id,code,unit_kind,unit_name,count,price,total_price,begin_time,end_time,status_code,create_time,update_time ");
			strSql.Append(" FROM t_unit ");
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
			strSql.Append("select count(1) FROM t_unit ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			object obj = DbHelperMySQL.GetSingle(strSql.ToString());
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
			strSql.Append(")AS Row, T.*  from t_unit T ");
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
			parameters[0].Value = "t_unit";
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

