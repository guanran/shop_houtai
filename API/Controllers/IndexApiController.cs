using BLL;
using DAO;
using Entity;
using Entity.common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace API.Controllers
{
    public class IndexApiController : Controller
    {
        public t_index_banner_BLL bll = new t_index_banner_BLL();
        //获取轮播图

        [HttpGet]
        public JsonResult IndexList()
        {
            CommonAjaxResponseModel<List<t_index_banner>> vmResult = new CommonAjaxResponseModel<List<t_index_banner>>();
            try
            {
                List<t_index_banner> result = bll.GetModelList("");
                vmResult.BFlag = CommonResponseBFlag.Success;
                vmResult.TData = result;
            }
            catch (Exception e)
            {
                vmResult.BFlag = CommonResponseBFlag.SysError;
                vmResult.Msg = e.Message;
            }
            return Json(vmResult, JsonRequestBehavior.AllowGet);
        }



        [HttpGet]
        public JsonResult carouselList()
        {
            CommonAjaxResponseModel<List<t_index_banner>> vmResult = new CommonAjaxResponseModel<List<t_index_banner>>();
            try
            {
                List<t_index_banner> result = bll.GetModelList("");
                vmResult.BFlag = CommonResponseBFlag.Success;
                vmResult.TData = result;
            }
            catch (Exception e)
            {
                vmResult.BFlag = CommonResponseBFlag.SysError;
                vmResult.Msg = e.Message;
            }
            return Json(vmResult, JsonRequestBehavior.AllowGet);
        }

    }
}
