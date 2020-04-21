using Entity.common;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class SerivesDAL
    {
        private static string mysqlCon = ConfigurationManager.ConnectionStrings["mydata"].ToString();

        public static int AddList(List<goodsList> gList,int unit_id)
        {

            int xx = 0;
            string sql = @"
INSERT INTO `t_unit_goods_list` (`unit_id`, `goods_id`, `goods_name_new`,number, `guid`, `random_num`, `ping_string`, `MD5_1`, `MD5_2`, `MD5_3`, `MD5_4`,`MD5_5`,`goods_number`, `create_time`,`status_code`) 


select @unit_id, @goods_id, @goods_name_new,@number,  @guid, @random_num, @ping_string, @MD5_1, @MD5_2, @MD5_3,@MD5_4,@MD5_5, @goods_number, now(), 1;";


            string sql2 = "update   t_unit_goods_list set status_code=-1 where unit_id=@unit_id ;";
            using (MySqlConnection sql_conn = new MySqlConnection(mysqlCon))
            {
                sql_conn.Open();
                MySqlTransaction tran = sql_conn.BeginTransaction();
                try
                {
                    MySqlCommand cmd2 = new MySqlCommand(sql2, sql_conn);
                    cmd2.Parameters.AddWithValue("@unit_id", unit_id);
                    cmd2.Transaction = tran;
                    cmd2.ExecuteNonQuery();
                    foreach (goodsList item in gList)
                    {
                        MySqlCommand cmd = new MySqlCommand(sql, sql_conn);

                        cmd.Parameters.AddWithValue("@unit_id", unit_id);
                        cmd.Parameters.AddWithValue("@goods_id", item.goods_id);
                        cmd.Parameters.AddWithValue("@goods_name_new", item.goods_name_new);
                        cmd.Parameters.AddWithValue("@number", xx);
                        cmd.Parameters.AddWithValue("@guid", item.guid);
                        cmd.Parameters.AddWithValue("@random_num", item.random_num);
                        cmd.Parameters.AddWithValue("@ping_string", item.ping_string);
                        cmd.Parameters.AddWithValue("@MD5_1", item.MD5_1);
                        cmd.Parameters.AddWithValue("@MD5_2", item.MD5_2);
                        cmd.Parameters.AddWithValue("@MD5_3", item.MD5_3);
                        cmd.Parameters.AddWithValue("@MD5_4", item.MD5_4);
                        cmd.Parameters.AddWithValue("@MD5_5", item.MD5_5);

                        
                        cmd.Parameters.AddWithValue("@goods_number", item.goods_number);

                        cmd.Transaction = tran;
                        cmd.ExecuteNonQuery();
                        xx++;
                    }
                    tran.Commit();
                }
                catch
                {
                    tran.Rollback();
                    throw;
                }
                finally
                {
                    sql_conn.Close();
                }
                return xx;

            }
        }


    }
}
