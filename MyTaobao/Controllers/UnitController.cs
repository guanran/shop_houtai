using DAO.mydata;
using Entity.common;
using Entity;
using MyTaobao.Serives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace MyTaobao.Controllers
{
    public class UnitController : Controller
    {
        // GET: Unit
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetList(int pageIndex, int pageSize, string code, string unit_kind, string unit_name, string price,string status_code)
        {
            int total = 0;
            List<t_unit> list = new List<t_unit>();
            var vmResult = new CommonAjaxResponseModel<VMGDataGrid<t_unit>>();
            vmResult.TData = new VMGDataGrid<t_unit>();
            try
            {
                list = UnitDAL.GetList(pageIndex, pageSize, code, unit_kind, unit_name, price, status_code, ref total);
                vmResult.BFlag = CommonResponseBFlag.Success;
                vmResult.TData.data = list;
                vmResult.TData.dataCount = total;
                vmResult.TData.currentPage = pageIndex;
            }
            catch (Exception ex)
            {

                vmResult.BFlag = CommonResponseBFlag.SysError;
                vmResult.TData.data = null;
                vmResult.TData.dataCount = 0;
                vmResult.Msg = ex.Message;
            }


            return Json(vmResult);
        }


        [HttpPost]
        public ActionResult Delete(long id)
        {
            t_goods model = new t_goods();
            var vmResult = new CommonAjaxResponseModel<VMGDataGrid<t_unit>>();
            vmResult.TData = new VMGDataGrid<t_unit>();

            try
            {
                //删除
                int t1 = UnitDAL.Delete(id);
                vmResult.BFlag = CommonResponseBFlag.Success;
                vmResult.TData.data = null;
                vmResult.TData.dataCount = 0;
                vmResult.Msg = string.Format("删除系列成功。");
                return Json(vmResult);
            }
            catch (Exception ex)
            {
                vmResult.BFlag = CommonResponseBFlag.LogicError;
                vmResult.TData.data = null;
                vmResult.TData.dataCount = 0;
                vmResult.Msg = "编辑报错" + ex.Message;
            }

            return Json(vmResult);
        }

        /// <summary>
        /// 生成系列数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Create(int id)
        {
            List<t_unit_goods> list = new List<t_unit_goods>();
            string code = "";
            var vmResult = new CommonAjaxResponseModel<VMGDataGrid<t_unit>>();
            vmResult.TData = new VMGDataGrid<t_unit>();
            try
            {
                //创建
                list = UnitDAL.GetGoodsByUnitID(id,ref code);

                RandomGoodsListSerives.getList(list, code, id);

                vmResult.BFlag = CommonResponseBFlag.Success;
                vmResult.TData.data = null;
                vmResult.TData.dataCount = 0;
                vmResult.Msg = string.Format("生成系列成功.");
                return Json(vmResult);
            }
            catch (Exception ex)
            {
                vmResult.BFlag = CommonResponseBFlag.LogicError;
                vmResult.TData.data = null;
                vmResult.TData.dataCount = 0;
                vmResult.Msg = "生成系列失败" + ex.Message;
            }

            return Json(vmResult);
        }


        [HttpPost]
        //添加系列 -编辑
        public ActionResult Add(string formVals = "{}")
        {
            var vmResult = new CommonAjaxResponseModel<bool>();
            try
            {
                t_unit model = formVals.ToModel<t_unit>();

                if (model.id != 0)
                {
                    UnitDAL.Update(model);

                    vmResult.BFlag = CommonResponseBFlag.Success;
                    vmResult.TData = true;
                }
                else
                {
                    //插入
                    model.status_code = 1;
                    UnitDAL.Add(model);
                    vmResult.BFlag = CommonResponseBFlag.Success;
                    vmResult.TData = true;

                }

            }
            catch (Exception ex)
            {
                vmResult.BFlag = CommonResponseBFlag.SysError;
                vmResult.Msg = ex.Message;
            }
            return Json(vmResult);
        }


        //copy复制
        public ActionResult Copy(string formVals = "{}")
        {
            var vmResult = new CommonAjaxResponseModel<bool>();
            try
            {
                t_unit model = formVals.ToModel<t_unit>();


              //  t_unit model2 = UnitDAL.GetModel(model.id);

                int unit_id = UnitDAL.CopyUnit(model);

                //List<t_unit_goods> uglist = UnitDAL.GetUnitGoodsListById(model.id);

                if(unit_id!=0&&unit_id != model.id)
                {

                    UnitDAL.CopyUnitGoods(model.id,unit_id);

                    vmResult.BFlag = CommonResponseBFlag.Success;
                    vmResult.TData = true;
                }
                
                 
              

            }
            catch (Exception ex)
            {
                vmResult.BFlag = CommonResponseBFlag.SysError;
                vmResult.Msg = ex.Message;
            }
            return Json(vmResult);
        }


        public ActionResult UnitGoodsList(long? id)
        {
            if (id == null)
            {
                Response.Redirect(Url.Action("Index", "Unit"));
                return View();
            }
            long newId = (long)id;

            t_unit model = UnitDAL.GetModel(newId);
            //List<t_unit_goods> goods_list = new List<t_unit_goods>();
            //if(UnitDAL.GetUnitGoodsList(newId)!=null)
            // goods_list = UnitDAL.GetUnitGoodsList(newId);

            ViewBag.unit_model = model;
            //ViewBag.goods_list = goods_list;


            return View();
        }


        public ActionResult GetUnitGoodsList(int? id)
        {
            UnitGoodsDetailVM list = new UnitGoodsDetailVM();
            var vmResult = new CommonAjaxResponseModel<VMGDataGrid<UnitGoodsDetailVM>>();
            vmResult.TData = new VMGDataGrid<UnitGoodsDetailVM>();
            if (id == null)
            {
                Response.Redirect(Url.Action("Index", "Unit"));
                return View();
            }
            else
            {
                int newId = (int)id;


                try
                {
                    list = UnitDAL.GetUnitGoodsList(newId);

                    vmResult.BFlag = CommonResponseBFlag.Success;
                    vmResult.TData.singleData = list;
                }
                catch (Exception ex)
                {

                    vmResult.BFlag = CommonResponseBFlag.LogicError;
                    vmResult.TData.data = null;
                    vmResult.Msg = ex.Message;
                }
            }
            

            return Json(vmResult);
        }
        


        [HttpPost]
        public ActionResult Delete_UnitGoodsList(long id)
        {
            t_unit_goods model = new t_unit_goods();
            var vmResult = new CommonAjaxResponseModel<VMGDataGrid<t_unit_goods>>();
            vmResult.TData = new VMGDataGrid<t_unit_goods>();

            try
            {
                //删除
                int t1 = UnitDAL.Delete_UnitGoodsList(id);
                vmResult.BFlag = CommonResponseBFlag.Success;
                vmResult.TData.data = null;
                vmResult.TData.dataCount = 0;
                vmResult.Msg = string.Format("删除该系列商品成功。");
                return Json(vmResult);
            }
            catch (Exception ex)
            {
                vmResult.BFlag = CommonResponseBFlag.LogicError;
                vmResult.TData.data = null;
                vmResult.TData.dataCount = 0;
                vmResult.Msg = "删除报错" + ex.Message;
            }

            return Json(vmResult);
        }


        /// <summary>
        /// 查询商品
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult GetGoodsListFromSql(string str)
        {
            StringBuilder _str = new StringBuilder();
            List<t_goods> list = GoodsDAL.GetGoodsListFromSql(str);
            var res = from c in list
                      select new
                      {
                          goods_id = c.id,
                          value = c.goodsName + "(" + c.id + ")"
                      };
            return Json(res);

        }

        public ActionResult AddUnitGoods(string formVals = "{}")
        {
            var vmResult = new CommonAjaxResponseModel<bool>();
            try
            {
                t_unit_goods model = formVals.ToModel<t_unit_goods>();

                if (!string.IsNullOrWhiteSpace(model.goods_name))
                {
                    model.goods_id = int.Parse(model.goods_name.Split('(', ')')[1]);
                    model.goods_name = model.goods_name.Split('(', ')')[0];
                  

                }
                else
                {
                    vmResult.BFlag = CommonResponseBFlag.SysError;
                    vmResult.Msg = "商品id解析出错";

                    return Json(vmResult);
                }


                 if (model.id != 0)
                {
                    UnitDAL.UpdateUnitGoods(model);

                    vmResult.BFlag = CommonResponseBFlag.Success;
                    vmResult.TData = true;
                }
                else
                {
                    //插入
                    UnitDAL.AddUnitGoods(model);
                    vmResult.BFlag = CommonResponseBFlag.Success;
                    vmResult.TData = true;

                }

            }
            catch (Exception ex)
            {
                vmResult.BFlag = CommonResponseBFlag.SysError;
                vmResult.Msg = ex.Message;
            }
            return Json(vmResult);
        }


        #region 生成数据管理页
        

        public ActionResult ShowData()
        {
            return View();
        }


        public ActionResult GetUnitGoodsListData(string unit_id,string goods_type, string goods_name, string MD5, decimal? min_price, decimal? max_price, int pageIndex = 1, int pageSize = 15)
        {
            int total = 0;
            List<t_unit_goods_list> list = new List<t_unit_goods_list>();
            var vmResult = new CommonAjaxResponseModel<VMGDataGrid<t_unit_goods_list>>();
            vmResult.TData = new VMGDataGrid<t_unit_goods_list>();
            try
            {
                list= UnitDAL.GetUnitGoodsListData(unit_id, goods_type, goods_name, MD5, min_price, max_price, pageIndex, pageSize, ref total);
                vmResult.BFlag = CommonResponseBFlag.Success;
                vmResult.TData.data = list;
                vmResult.TData.dataCount = total;
                vmResult.TData.currentPage = pageIndex;
            }
            catch (Exception ex)
            {
                vmResult.BFlag = CommonResponseBFlag.SysError;
                vmResult.TData.data = null;
                vmResult.Msg = ex.Message;
            }

            return Json(vmResult);
        }

        #endregion

        #region 数据页面查询

        public ActionResult GoodsPage()
        {
            return View();
        }


        #endregion
    }
}