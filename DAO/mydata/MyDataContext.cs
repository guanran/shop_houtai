using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
namespace DAO.mydata
{
    public class MyDataContext: DbContext
    {
        public MyDataContext()
          : base("name=mydata")
        {
        }
        public virtual DbSet<t_goods> t_goods { get; set; }
    }
}
