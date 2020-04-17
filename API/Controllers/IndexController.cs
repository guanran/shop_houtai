using BLL;
using DAO;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Results;

namespace API.Controllers
{
    public class IndexController : ApiController
    {
        public JsonResult<List<t_index_banner>> GetIndexList()
        {
            t_index_banner_BLL bll = new t_index_banner_BLL();
            List<t_index_banner> list = bll.GetModelList("");

            return Json<List<t_index_banner>>(list);
        }

    }
}
