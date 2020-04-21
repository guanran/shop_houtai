using System;
using System.Data;
using System.Text;
using MySql.Data.MySqlClient;
using Maticsoft.DBUtility;//Please add references
namespace Maticsoft.DAL
{
	/// <summary>
	/// 数据访问类:t_procurement_records
	/// </summary>
	public partial class t_procurement_records
	{
		public t_procurement_records()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperMySQL.GetMaxID("id", "t_procurement_records"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from t_procurement_records");
			strSql.Append(" where id=@id ");
			MySqlParameter[] parameters = {
					new MySqlParameter("@id", MySqlDbType.tinyint,4)			};
			parameters[0].Value = id;

			return DbHelperMySQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Maticsoft.Model.t_procurement_records model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into t_procurement_records(");
			strSql.Append("id,goodsName,kind,buyTime,buyCount,buyPrice,freight,otherMoney,totalPrice,averagePrice,sellPrice,isArrive)");
			strSql.Append(" values (");
			strSql.Append("@id,@goodsName,@kind,@buyTime,@buyCount,@buyPrice,@freight,@otherMoney,@totalPrice,@averagePrice,@sellPrice,@isArrive)");
			MySqlParameter[] parameters = {
					new MySqlParameter("@id", MySqlDbType.tinyint,4),
					new MySqlParameter("@goodsName", MySqlDbType.VarChar,255),
					new MySqlParameter("@kind", MySqlDbType.VarChar,255),
					new MySqlParameter("@buyTime", MySqlDbType.DateTime),
					new MySqlParameter("@buyCount", MySqlDbType.Int32,11),
					new MySqlParameter("@buyPrice", MySqlDbType.Decimal,10),
					new MySqlParameter("@freight", MySqlDbType.Decimal,10),
					new MySqlParameter("@otherMoney", MySqlDbType.Decimal,10),
					new MySqlParameter("@totalPrice", MySqlDbType.Decimal,10),
					new MySqlParameter("@averagePrice", MySqlDbType.Decimal,10),
					new MySqlParameter("@sellPrice", MySqlDbType.Decimal,10),
					new MySqlParameter("@isArrive", MySqlDbType.Int32,11)};
			parameters[0].Value = model.id;
			parameters[1].Value = model.goodsName;
			parameters[2].Value = model.kind;
			parameters[3].Value = model.buyTime;
			parameters[4].Value = model.buyCount;
			parameters[5].Value = model.buyPrice;
			parameters[6].Value = model.freight;
			parameters[7].Value = model.otherMoney;
			parameters[8].Value = model.totalPrice;
			parameters[9].Value = model.averagePrice;
			parameters[10].Value = model.sellPrice;
			parameters[11].Value = model.isArrive;

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
		public bool Update(Maticsoft.Model.t_procurement_records model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update t_procurement_records set ");
			strSql.Append("goodsName=@goodsName,");
			strSql.Append("kind=@kind,");
			strSql.Append("buyTime=@buyTime,");
			strSql.Append("buyCount=@buyCount,");
			strSql.Append("buyPrice=@buyPrice,");
			strSql.Append("freight=@freight,");
			strSql.Append("otherMoney=@otherMoney,");
			strSql.Append("totalPrice=@totalPrice,");
			strSql.Append("averagePrice=@averagePrice,");
			strSql.Append("sellPrice=@sellPrice,");
			strSql.Append("isArrive=@isArrive");
			strSql.Append(" where id=@id ");
			MySqlParameter[] parameters = {
					new MySqlParameter("@goodsName", MySqlDbType.VarChar,255),
					new MySqlParameter("@kind", MySqlDbType.VarChar,255),
					new MySqlParameter("@buyTime", MySqlDbType.DateTime),
					new MySqlParameter("@buyCount", MySqlDbType.Int32,11),
					new MySqlParameter("@buyPrice", MySqlDbType.Decimal,10),
					new MySqlParameter("@freight", MySqlDbType.Decimal,10),
					new MySqlParameter("@otherMoney", MySqlDbType.Decimal,10),
					new MySqlParameter("@totalPrice", MySqlDbType.Decimal,10),
					new MySqlParameter("@averagePrice", MySqlDbType.Decimal,10),
					new MySqlParameter("@sellPrice", MySqlDbType.Decimal,10),
					new MySqlParameter("@isArrive", MySqlDbType.Int32,11),
					new MySqlParameter("@id", MySqlDbType.tinyint,4)};
			parameters[0].Value = model.goodsName;
			parameters[1].Value = model.kind;
			parameters[2].Value = model.buyTime;
			parameters[3].Value = model.buyCount;
			parameters[4].Value = model.buyPrice;
			parameters[5].Value = model.freight;
			parameters[6].Value = model.otherMoney;
			parameters[7].Value = model.totalPrice;
			parameters[8].Value = model.averagePrice;
			parameters[9].Value = model.sellPrice;
			parameters[10].Value = model.isArrive;
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
			strSql.Append("delete from t_procurement_records ");
			strSql.Append(" where id=@id ");
			MySqlParameter[] parameters = {
					new MySqlParameter("@id", MySqlDbType.tinyint,4)			};
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
			strSql.Append("delete from t_procurement_records ");
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
		public Maticsoft.Model.t_procurement_records GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select id,goodsName,kind,buyTime,buyCount,buyPrice,freight,otherMoney,totalPrice,averagePrice,sellPrice,isArrive from t_procurement_records ");
			strSql.Append(" where id=@id ");
			MySqlParameter[] parameters = {
					new MySqlParameter("@id", MySqlDbType.tinyint,4)			};
			parameters[0].Value = id;

			Maticsoft.Model.t_procurement_records model=new Maticsoft.Model.t_procurement_records();
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
		public Maticsoft.Model.t_procurement_records DataRowToModel(DataRow row)
		{
			Maticsoft.Model.t_procurement_records model=new Maticsoft.Model.t_procurement_records();
			if (row != null)
			{
				if(row["id"]!=null && row["id"].ToString()!="")
				{
					model.id=int.Parse(row["id"].ToString());
				}
				if(row["goodsName"]!=null)
				{
					model.goodsName=row["goodsName"].ToString();
				}
				if(row["kind"]!=null)
				{
					model.kind=row["kind"].ToString();
				}
				if(row["buyTime"]!=null && row["buyTime"].ToString()!="")
				{
					model.buyTime=DateTime.Parse(row["buyTime"].ToString());
				}
				if(row["buyCount"]!=null && row["buyCount"].ToString()!="")
				{
					model.buyCount=int.Parse(row["buyCount"].ToString());
				}
				if(row["buyPrice"]!=null && row["buyPrice"].ToString()!="")
				{
					model.buyPrice=decimal.Parse(row["buyPrice"].ToString());
				}
				if(row["freight"]!=null && row["freight"].ToString()!="")
				{
					model.freight=decimal.Parse(row["freight"].ToString());
				}
				if(row["otherMoney"]!=null && row["otherMoney"].ToString()!="")
				{
					model.otherMoney=decimal.Parse(row["otherMoney"].ToString());
				}
				if(row["totalPrice"]!=null && row["totalPrice"].ToString()!="")
				{
					model.totalPrice=decimal.Parse(row["totalPrice"].ToString());
				}
				if(row["averagePrice"]!=null && row["averagePrice"].ToString()!="")
				{
					model.averagePrice=decimal.Parse(row["averagePrice"].ToString());
				}
				if(row["sellPrice"]!=null && row["sellPrice"].ToString()!="")
				{
					model.sellPrice=decimal.Parse(row["sellPrice"].ToString());
				}
				if(row["isArrive"]!=null && row["isArrive"].ToString()!="")
				{
					model.isArrive=int.Parse(row["isArrive"].ToString());
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
			strSql.Append("select id,goodsName,kind,buyTime,buyCount,buyPrice,freight,otherMoney,totalPrice,averagePrice,sellPrice,isArrive ");
			strSql.Append(" FROM t_procurement_records ");
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
			strSql.Append("select count(1) FROM t_procurement_records ");
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
			strSql.Append(")AS Row, T.*  from t_procurement_records T ");
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
			parameters[0].Value = "t_procurement_records";
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

