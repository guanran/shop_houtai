using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entity
{
    [Table("t_goods")]
    public  class t_goods
    {
        [Key]
        public int id { get; set; }
        public string topType { get; set; }
        public string type { get; set; }
        public string goodsName { get; set; }
        public decimal? minPrice { get; set; }
        public decimal? maxPrice { get; set; }

        public decimal? sell_min_price { get; set; }
        public decimal? sell_max_price { get; set; }
        public string describe { get; set; }
        public int? status { get; set; }
        public DateTime? createTime { get; set; }
        public DateTime? updateTime { get; set; }
        public string url { get; set; }

    }
}
