using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.JsonModel
{
    public class IndexList
    {
        //新品列表
        public List<t_goods> newProductList { get; set; }

        //热门
        public List<t_goods> hotProductList { get; set; }
        //推荐产品列表
        public List<t_goods> recommendProductList { get; set; }

        //猜你喜欢
        public List<t_goods> guessYouLikeProductList { get; set; }
    }
}
