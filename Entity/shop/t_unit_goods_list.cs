using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    [Table("t_unit_goods_list")]
    public class t_unit_goods_list
    {
        [Key]
        public int id { get; set; }

        public int unit_id { get; set; }

        public int goods_id { get; set; }

        public string goods_name_new { get; set; }
        public string number { get; set; }
        public string guid { get; set; }
        public int? random_num { get; set; }
        public string ping_string { get; set; }
        public string MD5_1 { get; set; }
        public string MD5_2 { get; set; }
        public string MD5_3 { get; set; }
        public string MD5_4 { get; set; }
        public string MD5_5 { get; set; }

        public string goods_number { get; set; }

        //是否已卖出 1是 0 否
        public int? isSell { get; set; }

        public DateTime? sellTime { get; set; }

        public int? isSend { get; set; }

        public decimal? express_fee { get; set; }

        public int? status_code { get; set; }
        public DateTime? create_time { get; set; }
        public DateTime? update_time { get; set; }

        public DateTime? sell_time { get; set; }

        [NotMapped]
        public string code { get; set; }
        [NotMapped]
        public string unit_name { get; set; }
        [NotMapped]
        public string goodsName { get; set; }
    }
}
