using DAO;
using Entity.common;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;

namespace MyTaobao.Serives
{
    public class RandomGoodsListSerives
    {

        public static void getList(List<t_unit_goods> list,string code,int unit_id)
        {

            List<goodsList> gList = new List<goodsList>();
            Random random = new Random();
            foreach (t_unit_goods item in list)
            {
                for (int i = 1; i <= item.count; i++)
                {
                    goodsList gl = new goodsList();
                    gl.goods_number = i.ToString()+"/"+ item.count.ToString();
                    gl.unit_goods_id = item.id;
                    gl.goods_id = item.goods_id;
                    gl.goods_name_new = item.goods_name_new;
                    gl.guid = Guid.NewGuid().ToString();
                    gl.random_num = random.Next();
                    gl.ping_string = code + "_" + gl.guid + "_" + gl.goods_name_new + "_" + gl.random_num.ToString();
                    gl.MD5_1 = GetMD5(gl.ping_string);
                    gl.MD5_2 = GetMD5(gl.MD5_1);
                    gl.MD5_3 = GetMD5(gl.MD5_2);
                    gl.MD5_4 = GetMD5(gl.MD5_3);
                    gl.MD5_5 = GetMD5(gl.MD5_4);
                    gList.Add(gl);
                }
            }

            gList = gList.OrderBy(t => t.random_num).ToList();
            int j = 0;
            foreach (var item in gList)
            {
                item.number = j;
                j++;
            }
            //存入数据库

           int p= SerivesDAL.AddList(gList, unit_id);



            //var fileName = ExportProjectList(gList);

        }


    



        public static string GetMD5(string sDataIn)

        {

            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();

            byte[] bytValue, bytHash;

            bytValue = System.Text.Encoding.UTF8.GetBytes(sDataIn);

            bytHash = md5.ComputeHash(bytValue);

            md5.Clear();

            string sTemp = "";

            for (int i = 0; i < bytHash.Length; i++)

            {

                sTemp += bytHash[i].ToString("X").PadLeft(2, '0');

            }

            return sTemp.ToLower();

        }
    }
}