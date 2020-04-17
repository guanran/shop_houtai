using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace Entity.common
{
    public static class JsonExtensions
    {
        /// <summary>
        /// 使用Json.net序列化对象
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string ToJsonByNewton(this object obj)
        {
            var setting = new Newtonsoft.Json.JsonSerializerSettings();
            setting.Converters.Add(new Newtonsoft.Json.Converters.IsoDateTimeConverter());

            string json = Newtonsoft.Json.JsonConvert.SerializeObject(obj, Formatting.None, setting);

            return json;
        }

        /// <summary>
        /// 使用Json.Net反序列化对象
        /// </summary>
        /// <param name="json"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static object ToObjectByNewton(this string json, Type type)
        {
            var model = Newtonsoft.Json.JsonConvert.DeserializeObject(json, type);

            return model;
        }

        public static string ToJson(this object obj)
        {

            JavaScriptSerializer serializer = new JavaScriptSerializer();
            serializer.MaxJsonLength = int.MaxValue;
            return serializer.Serialize(obj);
        }

        /// <summary>
        /// ExpandoObject
        /// </summary>
        /// <param name="exobj">ExpandoObject</param>
        /// <returns></returns>
        public static string ExToJson(ExpandoObject exobj)
        {

            var l = exobj.ToList();
            StringBuilder jsonStr = new StringBuilder();
            foreach (var item in l)
            {
                jsonStr.AppendFormat(",\"{0}\":\"{1}\"", item.Key, item.Value.ToString());
            }
            return jsonStr.Length > 0 ? "{" + jsonStr.Remove(0, 1) + "}" : "{}";
        }

        /// <summary>
        /// 格式化成Json字符串
        /// </summary>
        /// <param name="JsonObj">需要格式化的对象</param>
        /// <returns>Json字符串</returns>
        public static string ToJson<T>(T JsonObj)
        {
            // 首先，当然是JSON序列化
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(T));

            // 定义一个stream用来存发序列化之后的内容
            MemoryStream ms = new MemoryStream();
            ms.Position = 0;
            serializer.WriteObject(ms, JsonObj);
            string json = Encoding.UTF8.GetString(ms.ToArray());
            ms.Close();
            ms.Dispose();
            return json;
        }

        public static TEntity ToModel<TEntity>(this string json)
        {
            JavaScriptSerializer jsSerializer = new JavaScriptSerializer();
            jsSerializer.MaxJsonLength = int.MaxValue;
            return jsSerializer.Deserialize<TEntity>(json);
        }
        /// <summary>
        /// <para> 功    能： 把1,2,3,...,35,36转换成A,B,C,...,Y,Z </para>
        /// <para> 作    者： 韩保新 </para>
        /// <para> 创建日期： 2011-12-20</para>
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public static string NunberToChar(this int number)
        {
            if (1 <= number && 36 >= number)
            {
                int num = number + 64;
                System.Text.ASCIIEncoding asciiEncoding = new System.Text.ASCIIEncoding();
                byte[] btNumber = new byte[] { (byte)num };
                return asciiEncoding.GetString(btNumber);
            }
            return "数字不在转换范围内";
        }
        public static string Format(this DateTime date, string formatString = "yyyy-MM-dd", string defautString = "-")
        {
            if (date.ToString().Contains("0001-1-1"))
                return defautString;
            return date.ToString(formatString);
        }
        public static string Format(this DateTime? date, string formatString = "yyyy-MM-dd", string defautString = "-")
        {
            if (date.HasValue)
            {
                return date.Value.ToString(formatString);
            }

            return defautString;

        }
    }
}
