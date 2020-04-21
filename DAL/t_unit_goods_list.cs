using System;
using System.Data;
using System.Text;
using MySql.Data.MySqlClient;
using Maticsoft.DBUtility;//Please add references
namespace Maticsoft.DAL
{
	/// <summary>
	/// 数据访问类:t_unit_goods_list
	/// </summary>
	public partial class t_unit_goods_list
	{
		public t_unit_goods_list()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperMySQL.GetMaxID("id", "t_unit_goods_list"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from t_unit_goods_list");
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
		public bool Add(Maticsoft.Model.t_unit_goods_list model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into t_unit_goods_list(");
			strSql.Append("unit_id,goods_id,goods_name_new,number,guid,random_num,ping_string,MD5_1,MD5_2,MD5_3,MD5_4,MD5_5,goods_number,isSell,sell_time,isSend,express_fee,status_code,create_time,update_time)");
			strSql.Append(" values (");
			strSql.Append("@unit_id,@goods_id,@goods_name_new,@number,@guid,@random_num,@ping_string,@MD5_1,@MD5_2,@MD5_3,@MD5_4,@MD5_5,@goods_number,@isSell,@sell_time,@isSend,@express_fee,@status_code,@create_time,@update_time)");
			MySqlParameter[] parameters = {
					new MySqlParameter("@unit_id", MySqlDbType.Int32,11),
					new MySqlParameter("@goods_id", MySqlDbType.Int32,11),
					new MySqlParameter("@goods_name_new", MySqlDbType.VarChar,255),
					new MySqlParameter("@number", MySqlDbType.VarChar,255),
					new MySqlParameter("@guid", MySqlDbType.VarChar,255),
					new MySqlParameter("@random_num", MySqlDbType.Int32,11),
					new MySqlParameter("@ping_string", MySqlDbType.VarChar,255),
					new MySqlParameter("@MD5_1", MySqlDbType.VarChar,255),
					new MySqlParameter("@MD5_2", MySqlDbType.VarChar,255),
					new MySqlParameter("@MD5_3", MySqlDbType.VarChar,255),
					new MySqlParameter("@MD5_4", MySqlDbType.VarChar,255),
					new MySqlParameter("@MD5_5", MySqlDbType.VarChar,255),
					new MySqlParameter("@goods_number", MySqlDbType.VarChar,255),
					new MySqlParameter("@isSell", MySqlDbType.Int32,11),
					new MySqlParameter("@sell_time", MySqlDbType.DateTime),
					new MySqlParameter("@isSend", MySqlDbType.Int32,11),
					new MySqlParameter("@express_fee", MySqlDbType.Decimal,10),
					new MySqlParameter("@status_code", MySqlDbType.Int32,11),
					new MySqlParameter("@create_time", MySqlDbType.DateTime),
					new MySqlParameter("@update_time", MySqlDbType.DateTime)};
			parameters[0].Value = model.unit_id;
			parameters[1].Value = model.goods_id;
			parameters[2].Value = model.goods_name_new;
			parameters[3].Value = model.number;
			parameters[4].Value = model.guid;
			parameters[5].Value = model.random_num;
			parameters[6].Value = model.ping_string;
			parameters[7].Value = model.MD5_1;
			parameters[8].Value = model.MD5_2;
			parameters[9].Value = model.MD5_3;
			parameters[10].Value = model.MD5_4;
			parameters[11].Value = model.MD5_5;
			parameters[12].Value = model.goods_number;
			parameters[13].Value = model.isSell;
			parameters[14].Value = model.sell_time;
			parameters[15].Value = model.isSend;
			parameters[16].Value = model.express_fee;
			parameters[17].Value = model.status_code;
			parameters[18].Value = model.create_time;
			parameters[19].Value = model.update_time;

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
		public bool Update(Maticsoft.Model.t_unit_goods_list model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update t_unit_goods_list set ");
			strSql.Append("unit_id=@unit_id,");
			strSql.Append("goods_id=@goods_id,");
			strSql.Append("goods_name_new=@goods_name_new,");
			strSql.Append("number=@number,");
			strSql.Append("guid=@guid,");
			strSql.Append("random_num=@random_num,");
			strSql.Append("ping_string=@ping_string,");
			strSql.Append("MD5_1=@MD5_1,");
			strSql.Append("MD5_2=@MD5_2,");
			strSql.Append("MD5_3=@MD5_3,");
			strSql.Append("MD5_4=@MD5_4,");
			strSql.Append("MD5_5=@MD5_5,");
			strSql.Append("goods_number=@goods_number,");
			strSql.Append("isSell=@isSell,");
			strSql.Append("sell_time=@sell_time,");
			strSql.Append("isSend=@isSend,");
			strSql.Append("express_fee=@express_fee,");
			strSql.Append("status_code=@status_code,");
			strSql.Append("create_time=@create_time,");
			strSql.Append("update_time=@update_time");
			strSql.Append(" where id=@id");
			MySqlParameter[] parameters = {
					new MySqlParameter("@unit_id", MySqlDbType.Int32,11),
					new MySqlParameter("@goods_id", MySqlDbType.Int32,11),
					new MySqlParameter("@goods_name_new", MySqlDbType.VarChar,255),
					new MySqlParameter("@number", MySqlDbType.VarChar,255),
					new MySqlParameter("@guid", MySqlDbType.VarChar,255),
					new MySqlParameter("@random_num", MySqlDbType.Int32,11),
					new MySqlParameter("@ping_string", MySqlDbType.VarChar,255),
					new MySqlParameter("@MD5_1", MySqlDbType.VarChar,255),
					new MySqlParameter("@MD5_2", MySqlDbType.VarChar,255),
					new MySqlParameter("@MD5_3", MySqlDbType.VarChar,255),
					new MySqlParameter("@MD5_4", MySqlDbType.VarChar,255),
					new MySqlParameter("@MD5_5", MySqlDbType.VarChar,255),
					new MySqlParameter("@goods_number", MySqlDbType.VarChar,255),
					new MySqlParameter("@isSell", MySqlDbType.Int32,11),
					new MySqlParameter("@sell_time", MySqlDbType.DateTime),
					new MySqlParameter("@isSend", MySqlDbType.Int32,11),
					new MySqlParameter("@express_fee", MySqlDbType.Decimal,10),
					new MySqlParameter("@status_code", MySqlDbType.Int32,11),
					new MySqlParameter("@create_time", MySqlDbType.DateTime),
					new MySqlParameter("@update_time", MySqlDbType.DateTime),
					new MySqlParameter("@id", MySqlDbType.Int32,11)};
			parameters[0].Value = model.unit_id;
			parameters[1].Value = model.goods_id;
			parameters[2].Value = model.goods_name_new;
			parameters[3].Value = model.number;
			parameters[4].Value = model.guid;
			parameters[5].Value = model.random_num;
			parameters[6].Value = model.ping_string;
			parameters[7].Value = model.MD5_1;
			parameters[8].Value = model.MD5_2;
			parameters[9].Value = model.MD5_3;
			parameters[10].Value = model.MD5_4;
			parameters[11].Value = model.MD5_5;
			parameters[12].Value = model.goods_number;
			parameters[13].Value = model.isSell;
			parameters[14].Value = model.sell_time;
			parameters[15].Value = model.isSend;
			parameters[16].Value = model.express_fee;
			parameters[17].Value = model.status_code;
			parameters[18].Value = model.create_time;
			parameters[19].Value = model.update_time;
			parameters[20].Value = model.id;

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
			strSql.Append("delete from t_unit_goods_list ");
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
			strSql.Append("delete from t_unit_goods_list ");
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
		public Maticsoft.Model.t_unit_goods_list GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select id,unit_id,goods_id,goods_name_new,number,guid,random_num,ping_string,MD5_1,MD5_2,MD5_3,MD5_4,MD5_5,goods_number,isSell,sell_time,isSend,express_fee,status_code,create_time,update_time from t_unit_goods_list ");
			strSql.Append(" where id=@id");
			MySqlParameter[] parameters = {
					new MySqlParameter("@id", MySqlDbType.Int32)
			};
			parameters[0].Value = id;

			Maticsoft.Model.t_unit_goods_list model=new Maticsoft.Model.t_unit_goods_list();
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
		public Maticsoft.Model.t_unit_goods_list DataRowToModel(DataRow row)
		{
			Maticsoft.Model.t_unit_goods_list model=new Maticsoft.Model.t_unit_goods_list();
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
				if(row["goods_name_new"]!=null)
				{
					model.goods_name_new=row["goods_name_new"].ToString();
				}
				if(row["number"]!=null)
				{
					model.number=row["number"].ToString();
				}
				if(row["guid"]!=null)
				{
					model.guid=row["guid"].ToString();
				}
				if(row["random_num"]!=null && row["random_num"].ToString()!="")
				{
					model.random_num=int.Parse(row["random_num"].ToString());
				}
				if(row["ping_string"]!=null)
				{
					model.ping_string=row["ping_string"].ToString();
				}
				if(row["MD5_1"]!=null)
				{
					model.MD5_1=row["MD5_1"].ToString();
				}
				if(row["MD5_2"]!=null)
				{
					model.MD5_2=row["MD5_2"].ToString();
				}
				if(row["MD5_3"]!=null)
				{
					model.MD5_3=row["MD5_3"].ToString();
				}
				if(row["MD5_4"]!=null)
				{
					model.MD5_4=row["MD5_4"].ToString();
				}
				if(row["MD5_5"]!=null)
				{
					model.MD5_5=row["MD5_5"].ToString();
				}
				if(row["goods_number"]!=null)
				{
					model.goods_number=row["goods_number"].ToString();
				}
				if(row["isSell"]!=null && row["isSell"].ToString()!="")
				{
					model.isSell=int.Parse(row["isSell"].ToString());
				}
				if(row["sell_time"]!=null && row["sell_time"].ToString()!="")
				{
					model.sell_time=DateTime.Parse(row["sell_time"].ToString());
				}
				if(row["isSend"]!=null && row["isSend"].ToString()!="")
				{
					model.isSend=int.Parse(row["isSend"].ToString());
				}
				if(row["express_fee"]!=null && row["express_fee"].ToString()!="")
				{
					model.express_fee=decimal.Parse(row["express_fee"].ToString());
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
			strSql.Append("select id,unit_id,goods_id,goods_name_new,number,guid,random_num,ping_string,MD5_1,MD5_2,MD5_3,MD5_4,MD5_5,goods_number,isSell,sell_time,isSend,express_fee,status_code,create_time,update_time ");
			strSql.Append(" FROM t_unit_goods_list ");
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
			strSql.Append("select count(1) FROM t_unit_goods_list ");
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
			strSql.Append(")AS Row, T.*  from t_unit_goods_list T ");
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
			parameters[0].Value = "t_unit_goods_list";
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

