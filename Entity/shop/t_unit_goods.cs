using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    [Table("t_unit")]
    public class t_unit_goods
    {
        [Key]
        public int id { get; set; }

        public int unit_id { get; set; }

        public int goods_id { get; set; }


        public string goods_name { get; set; }

        public string goods_name_new { get; set; }
        public int? count { get; set; }

        public decimal? price { get; set; }

        public decimal? sell_min_price { get; set; }

        public decimal? sell_max_price { get; set; }

        public DateTime? create_time { get; set; }

        public DateTime? update_time { get; set; }

        public int? status_code { get; set; }
}
    public class UnitGoodsDetailVM
    {
        public List<t_unit_goods> unit_goods_list = new List<t_unit_goods>();
        public t_unit_goods_sum unit_goods_list_sum = new t_unit_goods_sum();

    }

    public class t_unit_goods_sum
    {
        public UInt64? goods_id { get; set; }
        public UInt64? count { get; set; }

        public UInt64? price { get; set; }

        public UInt64? sell_min_price { get; set; }

        public UInt64? sell_max_price { get; set; }

    }
}
