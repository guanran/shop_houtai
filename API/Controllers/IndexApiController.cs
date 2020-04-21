using BLL;
using DAO;
using Entity;
using Entity.common;
using Entity.JsonModel;
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
        public t_index_banner_BLL banner_bll = new t_index_banner_BLL();

        public t_index_announce_BLL announce_bll = new t_index_announce_BLL();

        [HttpGet]
        public JsonResult IndexList()
        {
            CommonAjaxResponseModel<IndexList> vmResult = new CommonAjaxResponseModel<IndexList>();

            IndexList model = new IndexList();
            try
            {
                //获取轮播图
                List<t_index_banner> banner_list = banner_bll.GetModelList("");
                //获取通知列表
                List<t_index_announce> announce_list = announce_bll.GetModelList("");

                model.bannerList = banner_list;
                model.announceList = announce_list;
                vmResult.BFlag = CommonResponseBFlag.Success;
                vmResult.TData = model;
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
                List<t_index_banner> result = banner_bll.GetModelList("");
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
