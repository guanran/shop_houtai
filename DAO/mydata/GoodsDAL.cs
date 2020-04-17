using DAO.common;
using Entity;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO.mydata
{


    public class GoodsDAL
    {
        //private static Database db = null;
        private static string mysqlCon = ConfigurationManager.ConnectionStrings["mydata"].ToString();

        public static List<t_goods> GetGoodsList(int currentPage, int pagesize, string type, string goodsName, string minPrice, string maxPrice, ref int total)
        {
            List<t_goods> result = new List<t_goods>();
            string sql = @"
                            select SQL_CALC_FOUND_ROWS  * from t_goods where `status`=1 {0}  order by id desc limit @begin,@pagesize;
                            SELECT FOUND_ROWS() as total; 
                        ";

            using (MySqlConnection sql_conn = new MySqlConnection(mysqlCon))
            {
                string strWhere = "";
                if (!string.IsNullOrEmpty(type))
                {
                    strWhere += " and (type like '%" + type + "%' or topType like '%" + type + "%')";
                }
                if (!string.IsNullOrEmpty(goodsName))
                {
                    strWhere += " and goodsName like'%" + goodsName + "%'";
                }

                if (!string.IsNullOrEmpty(minPrice))
                {
                    strWhere += " and minPrice>=" + minPrice + "";
                }
                if (!string.IsNullOrEmpty(maxPrice))
                {
                    strWhere += " and minPrice<=" + maxPrice + "";
                }

                sql = string.Format(sql, strWhere);
                sql_conn.Open();
                MySqlCommand cmd = new MySqlCommand(sql, sql_conn);
                DataSet ds = new DataSet();
                cmd.Parameters.AddWithValue("@begin", (currentPage - 1) * pagesize);
                cmd.Parameters.AddWithValue("@pagesize", pagesize);
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                adapter.Fill(ds);
                total = int.Parse(ds.Tables[1].Rows[0][0].ToString());
                result = (List<t_goods>)IListDataSet.DataSetToIList<t_goods>(ds, 0);
                return result;

            }

        }


        public static int AddGoods(t_goods model)
        {
            string sql = @"
INSERT INTO `mydata`.`t_goods` ( `topType`, `type`, `goodsName`, `minPrice`, `maxPrice`, `sell_min_price`, `sell_max_price`,`describe`, `status`, `createTime`, `url`) select @topType, @type,@goodsName,@minPrice,@maxPrice,@sell_min_price,@sell_max_price,@describe,1,now(),@url";

            using (MySqlConnection sql_conn = new MySqlConnection(mysqlCon))
            {
                sql_conn.Open();
                MySqlCommand cmd = new MySqlCommand(sql, sql_conn);
                cmd.Parameters.AddWithValue("@topType", model.topType);
                cmd.Parameters.AddWithValue("@type", model.type);
                cmd.Parameters.AddWithValue("@goodsName", model.goodsName);
                cmd.Parameters.AddWithValue("@minPrice", model.minPrice);
                cmd.Parameters.AddWithValue("@maxPrice", model.maxPrice);
                cmd.Parameters.AddWithValue("@sell_min_price", model.sell_min_price);
                cmd.Parameters.AddWithValue("@sell_max_price", model.sell_max_price);

                cmd.Parameters.AddWithValue("@describe", model.describe);
                cmd.Parameters.AddWithValue("@url", model.url);
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                int p = cmd.ExecuteNonQuery();
                return p;

            }
        }

        public static int UpdateGoods(t_goods model)
        {
            string sql = @"
UPDATE `mydata`.`t_goods` SET  `topType`=@topType, `type`=@type, `goodsName`=@goodsName, `minPrice`=@minPrice, `maxPrice`=@maxPrice, `sell_min_price`=@sell_min_price, `sell_max_price`=@sell_max_price, `describe`=@describe, `updateTime`=now(), `url`=@url WHERE `id`=@id;";

            using (MySqlConnection sql_conn = new MySqlConnection(mysqlCon))
            {
                sql_conn.Open();
                MySqlCommand cmd = new MySqlCommand(sql, sql_conn);
                cmd.Parameters.AddWithValue("@topType", model.topType);
                cmd.Parameters.AddWithValue("@type", model.type);
                cmd.Parameters.AddWithValue("@goodsName", model.goodsName);
                cmd.Parameters.AddWithValue("@minPrice", model.minPrice);
                cmd.Parameters.AddWithValue("@maxPrice", model.maxPrice);
                cmd.Parameters.AddWithValue("@sell_min_price", model.sell_min_price);
                cmd.Parameters.AddWithValue("@sell_max_price", model.sell_max_price);
                cmd.Parameters.AddWithValue("@describe", model.describe);
                cmd.Parameters.AddWithValue("@url", model.url);
                cmd.Parameters.AddWithValue("@id", model.id);
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                int p = cmd.ExecuteNonQuery();
                return p;

            }
        }


        

        public static int DeleteGoods(long id) {
            string sql = @" update t_goods  set  `status`=-1 where id=" + id;
            using (MySqlConnection sql_conn = new MySqlConnection(mysqlCon))
            {
                sql_conn.Open();
                MySqlCommand cmd = new MySqlCommand(sql.ToString(), sql_conn);
                int p = cmd.ExecuteNonQuery();
                return p;
            }
        }

        public static List<t_goods> GetGoodsListFromSql(string str)
        {
            List<t_goods> result = new List<t_goods>();
            string sql = @"
                            select * from t_goods where `status`=1 {0} limit 0,10;
                        ";

            using (MySqlConnection sql_conn = new MySqlConnection(mysqlCon))
            {
                string strWhere = "";
                if (!string.IsNullOrEmpty(str))
                {
                    strWhere += " and (goodsName like '%" + str + "%' or type like '%" + str + "%')";
                }

                sql = string.Format(sql, strWhere);
                sql_conn.Open();
                MySqlCommand cmd = new MySqlCommand(sql, sql_conn);
                DataSet ds = new DataSet();
               
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                adapter.Fill(ds);
                result = (List<t_goods>)IListDataSet.DataSetToIList<t_goods>(ds, 0);
                return result;

            }

        }


    }
}
