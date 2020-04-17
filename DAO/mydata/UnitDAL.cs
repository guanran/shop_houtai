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
    public class UnitDAL
    {
        private static string mysqlCon = ConfigurationManager.ConnectionStrings["mydata"].ToString();
        public static List<t_unit> GetList(int currentPage, int pagesize, string code, string unit_kind, string unit_name, string price, string status_code, ref int total)
        {
            List<t_unit> result = new List<t_unit>();
            string sql = @"
                           select SQL_CALC_FOUND_ROWS  * from t_unit x1 
left join (select unit_id, convert(count(1), UNSIGNED)  as goods_count,  convert(sum(count), UNSIGNED)  as goods_num from t_unit_goods  where status_code=1  group by unit_id)x2
on x1.id=x2.unit_id where x1.status_code!=-1 {0} order by x1.id limit @begin,@pagesize;

                            SELECT FOUND_ROWS() as total; 
                        ";

            using (MySqlConnection sql_conn = new MySqlConnection(mysqlCon))
            {
                string strWhere = "";
                if (!string.IsNullOrEmpty(code))
                {
                    strWhere += " and code like '%" + code +  "%'";
                }
                if (!string.IsNullOrEmpty(unit_kind))
                {
                    strWhere += " and unit_kind like'%" + unit_kind + "%'";
                }
                if (!string.IsNullOrEmpty(unit_name))
                {
                    strWhere += " and unit_name like'%" + unit_name + "%'";
                }

                
                if (!string.IsNullOrEmpty(price)&& price!="0")
                {
                    strWhere += " and price=" + price + "";
                }
                //if (!string.IsNullOrEmpty(status_code))
                //{
                //    strWhere += " and status_code='" + status_code + "'";
                //}

                
                sql = string.Format(sql, strWhere);
                sql_conn.Open();
                MySqlCommand cmd = new MySqlCommand(sql, sql_conn);
                DataSet ds = new DataSet();
                cmd.Parameters.AddWithValue("@begin", (currentPage - 1) * pagesize);
                cmd.Parameters.AddWithValue("@pagesize", pagesize);
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                adapter.Fill(ds);
                total = int.Parse(ds.Tables[1].Rows[0][0].ToString());
                result = (List<t_unit>)IListDataSet.DataSetToIList<t_unit>(ds, 0);
                return result;

            }

        }


        public static t_unit GetModel(long id)
        {
            t_unit result = new t_unit();
            string sql = @"
                            select  * from t_unit where status_code!=-1 {0} ;
                        ";
            using (MySqlConnection sql_conn = new MySqlConnection(mysqlCon))
            {
                string strWhere = "";
                if (!string.IsNullOrEmpty(id.ToString())&& id!=0)
                {
                    strWhere += " and id= " + id + "";
                }

                sql = string.Format(sql, strWhere);
                sql_conn.Open();
                MySqlCommand cmd = new MySqlCommand(sql, sql_conn);
                DataSet ds = new DataSet();
              
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                adapter.Fill(ds);
              
                result = (t_unit)IListDataSet.DataSetToIList<t_unit>(ds, 0)[0];
                return result;

            }


        }

        public static int Add(t_unit model)
        {
            string sql = @"

INSERT INTO `mydata`.`t_unit` (`code`, `unit_kind`, `unit_name`, `count`, `price`, `total_price`, `begin_time`, `end_time`, `status_code`,create_time) 
select @code, @unit_kind,@unit_name,@count,@price,@total_price,@begin_time,@end_time,1,now()";

            using (MySqlConnection sql_conn = new MySqlConnection(mysqlCon))
            {
                sql_conn.Open();
                MySqlCommand cmd = new MySqlCommand(sql, sql_conn);
                cmd.Parameters.AddWithValue("@code", model.code);
                cmd.Parameters.AddWithValue("@unit_kind", model.unit_kind);
                cmd.Parameters.AddWithValue("@unit_name", model.unit_name);
                cmd.Parameters.AddWithValue("@count", model.count);
                cmd.Parameters.AddWithValue("@price", model.price);
                cmd.Parameters.AddWithValue("@total_price", model.count* model.price);
                cmd.Parameters.AddWithValue("@begin_time", model.begin_time);
                cmd.Parameters.AddWithValue("@end_time", model.end_time);
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                int p = cmd.ExecuteNonQuery();
                return p;

            }
        }

        public static int Update(t_unit model)
        {
            string sql = @"
UPDATE `mydata`.`t_unit` SET `code`=@code, `unit_kind`=@unit_kind, `unit_name`=@unit_name, `count`=@count, `price`=@price, `total_price`=@total_price, `begin_time`=@begin_time, `end_time`=@end_time, `update_time`=now() WHERE `id`=@id;";

            using (MySqlConnection sql_conn = new MySqlConnection(mysqlCon))
            {
                sql_conn.Open();
                MySqlCommand cmd = new MySqlCommand(sql, sql_conn);
                cmd.Parameters.AddWithValue("@code", model.code);
                cmd.Parameters.AddWithValue("@unit_kind", model.unit_kind);
                cmd.Parameters.AddWithValue("@unit_name", model.unit_name);
                cmd.Parameters.AddWithValue("@count", model.count);
                cmd.Parameters.AddWithValue("@price", model.price);
                cmd.Parameters.AddWithValue("@total_price", model.count * model.price);
                cmd.Parameters.AddWithValue("@begin_time", model.begin_time);
                cmd.Parameters.AddWithValue("@end_time", model.end_time);
                
                cmd.Parameters.AddWithValue("@id", model.id);
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                int p = cmd.ExecuteNonQuery();
                return p;

            }
        }


        public static int Delete(long id)
        {
            string sql = @" update t_unit  set  `status_code`=-1 where id=" + id;
            using (MySqlConnection sql_conn = new MySqlConnection(mysqlCon))
            {
                sql_conn.Open();
                MySqlCommand cmd = new MySqlCommand(sql.ToString(), sql_conn);
                int p = cmd.ExecuteNonQuery();
                return p;
            }
        }


        public static UnitGoodsDetailVM GetUnitGoodsList(int id)
        {
            UnitGoodsDetailVM result = new UnitGoodsDetailVM();
            string sql = @"
                            select x1.* from t_unit_goods x1 
left join  t_goods x2 on x1.goods_id=x2.id
where x1.status_code!=-1 {0} ;
select  convert(count(1), UNSIGNED) as goods_id, convert(sum(x1.count), UNSIGNED) AS count, convert(sum(x1.price * x1.count), UNSIGNED) as price,convert(sum(x1.sell_min_price * x1.count), UNSIGNED) as sell_min_price, convert(sum(x1.sell_max_price * x1.count), UNSIGNED) as sell_max_price   from t_unit_goods x1 where x1.status_code != -1 {0}
                        ";

            //select count(1) as goods_id,sum(x1.count + 0) AS count, convert(sum(x1.price * x1.count), UNSIGNED) as price,convert(sum(x1.sell_min_price * x1.count), UNSIGNED) as sell_min_price, convert(sum(x1.sell_max_price * x1.count), UNSIGNED) as sell_max_price   from t_unit_goods x1 where x1.status_code != -1 { 0}

            using (MySqlConnection sql_conn = new MySqlConnection(mysqlCon))
            {
                string strWhere = "";
                if (!string.IsNullOrEmpty(id.ToString())&&id!=0)
                {
                    strWhere += " and x1.unit_id=" + id + "";
                }

                sql = string.Format(sql, strWhere);
                sql_conn.Open();
                MySqlCommand cmd = new MySqlCommand(sql, sql_conn);
                DataSet ds = new DataSet();
               
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                adapter.Fill(ds);

                result.unit_goods_list = (List<t_unit_goods>)IListDataSet.DataSetToIList<t_unit_goods>(ds, 0);
                result.unit_goods_list_sum = ((List<t_unit_goods_sum>)IListDataSet.DataSetToIList<t_unit_goods_sum>(ds, 1)).FirstOrDefault(); 
                return result;

            }
        }

        public static List<t_unit_goods> GetUnitGoodsListById(int id)
        {
            List<t_unit_goods> result = new List<t_unit_goods>();
            string sql = @"
                            select x1.* from t_unit_goods x1 
left join  t_goods x2 on x1.goods_id=x2.id
where x1.status_code!=-1 {0} ;
                        ";

            //select count(1) as goods_id,sum(x1.count + 0) AS count, convert(sum(x1.price * x1.count), UNSIGNED) as price,convert(sum(x1.sell_min_price * x1.count), UNSIGNED) as sell_min_price, convert(sum(x1.sell_max_price * x1.count), UNSIGNED) as sell_max_price   from t_unit_goods x1 where x1.status_code != -1 { 0}

            using (MySqlConnection sql_conn = new MySqlConnection(mysqlCon))
            {
                string strWhere = "";
                if (!string.IsNullOrEmpty(id.ToString()) && id != 0)
                {
                    strWhere += " and x1.unit_id=" + id + "";
                }

                sql = string.Format(sql, strWhere);
                sql_conn.Open();
                MySqlCommand cmd = new MySqlCommand(sql, sql_conn);
                DataSet ds = new DataSet();

                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                adapter.Fill(ds);

                result = (List<t_unit_goods>)IListDataSet.DataSetToIList<t_unit_goods>(ds, 0);

            }
            return result;
        }

        public static int Delete_UnitGoodsList(long id)
        {
            string sql = @" update t_unit_goods  set  `status_code`=-1 where id=" + id;
            using (MySqlConnection sql_conn = new MySqlConnection(mysqlCon))
            {
                sql_conn.Open();
                MySqlCommand cmd = new MySqlCommand(sql.ToString(), sql_conn);
                int p = cmd.ExecuteNonQuery();
                return p;
            }
        }


        public static int UpdateUnitGoods(t_unit_goods model)
        {
            string sql = @"
UPDATE `mydata`.`t_unit_goods` SET  `goods_id`=@goods_id,`goods_name`=@goods_name, `goods_name_new`=@goods_name_new, `count`=@count, `price`=@price, `sell_min_price`=@sell_min_price, `sell_max_price`=@sell_max_price, `update_time`=now()  WHERE `id`=@id;";

            using (MySqlConnection sql_conn = new MySqlConnection(mysqlCon))
            {
                sql_conn.Open();
                MySqlCommand cmd = new MySqlCommand(sql, sql_conn);
                cmd.Parameters.AddWithValue("@goods_id", model.goods_id);
                cmd.Parameters.AddWithValue("@goods_name", model.goods_name);
                cmd.Parameters.AddWithValue("@goods_name_new", model.goods_name_new);
                cmd.Parameters.AddWithValue("@count", model.count);
                cmd.Parameters.AddWithValue("@price", model.price);
                cmd.Parameters.AddWithValue("@sell_min_price", model.sell_min_price);
                cmd.Parameters.AddWithValue("@sell_max_price", model.sell_max_price);
                cmd.Parameters.AddWithValue("@id", model.id);
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                int p = cmd.ExecuteNonQuery();
                return p;

            }
        }


        public static int AddUnitGoods(t_unit_goods model)
        {
            string sql = @"
INSERT INTO `mydata`.`t_unit_goods` (`unit_id`, `goods_id`,`goods_name`, `goods_name_new`, `count`, `price`, `sell_min_price`, `sell_max_price`, `create_time`,`status_code`) 
 select @unit_id, @goods_id,@goods_name,@goods_name_new, @count, @price, @sell_min_price, @sell_max_price, now(), 1;";

            using (MySqlConnection sql_conn = new MySqlConnection(mysqlCon))
            {
                sql_conn.Open();
                MySqlCommand cmd = new MySqlCommand(sql, sql_conn);
                cmd.Parameters.AddWithValue("@unit_id", model.unit_id);
                cmd.Parameters.AddWithValue("@goods_id", model.goods_id);
                cmd.Parameters.AddWithValue("@goods_name", model.goods_name);
                cmd.Parameters.AddWithValue("@goods_name_new", model.goods_name_new);
                cmd.Parameters.AddWithValue("@count", model.count);
                cmd.Parameters.AddWithValue("@price", model.price);
                cmd.Parameters.AddWithValue("@sell_min_price", model.sell_min_price);
                cmd.Parameters.AddWithValue("@sell_max_price", model.sell_max_price);
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                int p = cmd.ExecuteNonQuery();
                return p;

            }
        }

        public static int DeleteUnitGoods(long id)
        {
            string sql = @" update t_unit_goods  set  `status_code`=-1 where id=" + id;
            using (MySqlConnection sql_conn = new MySqlConnection(mysqlCon))
            {
                sql_conn.Open();
                MySqlCommand cmd = new MySqlCommand(sql.ToString(), sql_conn);
                int p = cmd.ExecuteNonQuery();
                return p;
            }
        }


        
        public static List<t_unit_goods> GetGoodsByUnitID(int UnitID,ref string code)
        {
            List<t_unit_goods> result = new List<t_unit_goods>();
            string sql = @"
                            select * from t_unit where status_code!=-1 {0};
                            select * from t_unit_goods  where status_code!=-1 {1} ;
                        ";

            //select count(1) as goods_id,sum(x1.count + 0) AS count, convert(sum(x1.price * x1.count), UNSIGNED) as price,convert(sum(x1.sell_min_price * x1.count), UNSIGNED) as sell_min_price, convert(sum(x1.sell_max_price * x1.count), UNSIGNED) as sell_max_price   from t_unit_goods x1 where x1.status_code != -1 { 0}

            using (MySqlConnection sql_conn = new MySqlConnection(mysqlCon))
            {
                string strWhere = "";
                string strWhere2 = "";
                if (!string.IsNullOrEmpty(UnitID.ToString()) && UnitID != 0)
                {
                    strWhere += " and unit_id=" + UnitID + "";
                    strWhere2 += " and id=" + UnitID + "";
                }

                sql = string.Format(sql, strWhere2, strWhere);
                sql_conn.Open();
                MySqlCommand cmd = new MySqlCommand(sql, sql_conn);
                DataSet ds = new DataSet();

                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                adapter.Fill(ds);
                code = ((List<t_unit>)IListDataSet.DataSetToIList<t_unit>(ds, 0)).FirstOrDefault().code;
                result = (List<t_unit_goods>)IListDataSet.DataSetToIList<t_unit_goods>(ds, 1);
                return result;

            }
        }

        #region copy

       
        public static int CopyUnit(t_unit model)
        {
            int unit_id = 0;
            string sql = @"INSERT INTO `mydata`.`t_unit` (`code`, `unit_kind`, `unit_name`, `count`, `price`, `total_price`, `begin_time`, `end_time`, `status_code`, `create_time`) 
select @code, @unit_kind, @unit_name, count, price, total_price,begin_time,end_time, status_code,now() from t_unit where id=@id;
 ";
            using (MySqlConnection sql_conn = new MySqlConnection(mysqlCon))
            {
                sql_conn.Open();
                MySqlCommand cmd = new MySqlCommand(sql, sql_conn);
                cmd.Parameters.AddWithValue("@code", model.code);
                cmd.Parameters.AddWithValue("@unit_kind", model.unit_kind);
                cmd.Parameters.AddWithValue("@unit_name", model.unit_name);
                cmd.Parameters.AddWithValue("@id", model.id);
               
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                int p = cmd.ExecuteNonQuery();

                if (p == 1)
                {
                    string sql2 = "select id from t_unit where code=@code and unit_kind=@unit_kind and unit_name=@unit_name and id<>@id;";
                    MySqlCommand cmd2 = new MySqlCommand(sql2, sql_conn);
                    cmd2.Parameters.AddWithValue("@code", model.code);
                    cmd2.Parameters.AddWithValue("@unit_kind", model.unit_kind);
                    cmd2.Parameters.AddWithValue("@unit_name", model.unit_name);
                    cmd2.Parameters.AddWithValue("@id", model.id);

                    DataSet ds = new DataSet();
                    MySqlDataAdapter adapter2 = new MySqlDataAdapter(cmd2);
                    adapter2.Fill(ds);

                    unit_id = int.Parse(ds.Tables[0].Rows[0][0].ToString());
                }

                return unit_id;

            }


        }

        public static int CopyUnitGoods(int old_unit_id,int new_unit_id)
        {
            string sql = @"INSERT INTO `mydata`.`t_unit_goods` (`unit_id`, `goods_id`, `goods_name`, `goods_name_new`, `count`, `price`, `sell_min_price`, `sell_max_price`, `create_time`,  `status_code`) 
select  @new_unit_id as unit_id, goods_id, goods_name,goods_name_new,count, price, sell_min_price,sell_max_price,now() as create_time, 1 as status_code  from t_unit_goods where status_code=1 and  unit_id=@old_unit_id ;
";
            using (MySqlConnection sql_conn = new MySqlConnection(mysqlCon))
            {
                sql_conn.Open();
                MySqlCommand cmd = new MySqlCommand(sql, sql_conn);
                cmd.Parameters.AddWithValue("@old_unit_id", old_unit_id);
                cmd.Parameters.AddWithValue("@new_unit_id", new_unit_id);

                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                int p = cmd.ExecuteNonQuery();
                return p;

            }


        }
        #endregion
        #region 生成数据查询

        public static List<t_unit_goods_list> GetUnitGoodsListData(string unit_id, string goods_type, string goods_name, string MD5,decimal?  min_price,decimal? max_price, int pageIndex, int pageSize,ref int total)
        {
            List<t_unit_goods_list> result = new List<t_unit_goods_list>();
            string sql = @"
                         select SQL_CALC_FOUND_ROWS x2.`code`,x2.unit_name,x3.goodsName ,x1.* from t_unit_goods_list x1 
left join t_unit x2 on x1.unit_id=x2.id 
left join t_goods x3 on x1.goods_id=x3.id
where x1.status_code!=-1 {0}
  order by x1.random_num asc
                            limit @begin,@pagesize;
                            SELECT FOUND_ROWS() as total;;
                        ";

            using (MySqlConnection sql_conn = new MySqlConnection(mysqlCon))
            {
                string strWhere = "";
                if (!string.IsNullOrEmpty(unit_id) && unit_id != "0")
                {
                    strWhere += " and x1.unit_id=" + unit_id + "";
                }

                if (!string.IsNullOrEmpty(goods_type))
                {
                    strWhere += " and (x3.type like '%" + goods_type + "%' or x3.topType like '%"+ goods_type + "%')";
                }
                if (!string.IsNullOrEmpty(MD5))
                {
                    strWhere += " and (x1.MD5_1 = '" + MD5 + "' or x1.MD5_2='" + MD5 + "' or x1.MD5_3='" + MD5 + "' or x1.MD5_4='" + MD5 + "' or x1.MD5_5='" + MD5+"')";
                }
                if (!string.IsNullOrEmpty(goods_name))
                {
                    strWhere += " and (x3.goods_name like '%" + goods_name + "%' or x1.goods_name_new like '%" + goods_name + "%')";
                }


                if(min_price!=null && min_price != 0)
                {

                }

                if (max_price != null && max_price != 0)
                {

                }
                sql = string.Format(sql, strWhere);
                sql_conn.Open();
                MySqlCommand cmd = new MySqlCommand(sql, sql_conn);
                DataSet ds = new DataSet();
                cmd.Parameters.AddWithValue("@begin", (pageIndex - 1) * pageSize);
                cmd.Parameters.AddWithValue("@pagesize", pageSize);
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                adapter.Fill(ds);

                result = (List<t_unit_goods_list>)IListDataSet.DataSetToIList<t_unit_goods_list>(ds, 0);
                total = int.Parse(ds.Tables[1].Rows[0][0].ToString());
                return result;

            }
        }
        #endregion
    }
}
