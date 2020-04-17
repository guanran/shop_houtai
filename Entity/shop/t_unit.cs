using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entity
{
    [Table("t_unit")]
    public class t_unit
    {
        [Key]
        public int id { get; set; }

        public string code { get; set; }

        public string unit_kind { get; set; }

        public string unit_name { get; set; }

        public int? count { get; set; }

        public decimal? price { get; set; }

        public decimal? total_price { get; set; }

        public DateTime? begin_time { get; set; }

        public DateTime? end_time { get; set; }

        public int? status_code { get; set; }

        public DateTime? create_time { get; set; }

        public DateTime? update_time { get; set; }

        public int unit_id { get; set; }


        public UInt64? goods_count { get; set; }

        public UInt64? goods_num { get; set; }
        
    }
}
