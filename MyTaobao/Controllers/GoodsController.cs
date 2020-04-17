using DAO.mydata;
using Entity.common;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyTaobao.Controllers
{
    public class GoodsController : Controller
    {
        // GET: Goods
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult GoodsList(int pageIndex, int pageSize,string type,string goodsName,string minPrice,string maxPrice)
        {
            int total = 0;
            List<t_goods> list = new List<t_goods>();
            var vmResult = new CommonAjaxResponseModel<VMGDataGrid<t_goods>>();
            vmResult.TData = new VMGDataGrid<t_goods>();
            try
            {
                list = GoodsDAL.GetGoodsList(pageIndex, pageSize, type, goodsName, minPrice, maxPrice, ref total);
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
        public ActionResult DeleteGoods(long id)
        {
            t_goods model = new t_goods();
            var vmResult = new CommonAjaxResponseModel<VMGDataGrid<t_goods>>();
            vmResult.TData = new VMGDataGrid<t_goods>();

            try
            {
                //删除
                int t1 = GoodsDAL.DeleteGoods(id);
                vmResult.BFlag = CommonResponseBFlag.Success;
                vmResult.TData.data = null;
                vmResult.TData.dataCount = 0;
                vmResult.Msg = string.Format("删除产品成功。");
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



        //添加商品 -编辑
        public ActionResult AddGoods(string formVals = "{}")
        {
            var vmResult = new CommonAjaxResponseModel<bool>();
            try
            {
                t_goods model = formVals.ToModel<t_goods>();

                if (model.id != 0)
                {
                    GoodsDAL.UpdateGoods(model);

                    vmResult.BFlag = CommonResponseBFlag.Success;
                    vmResult.TData = true;
                }
                else
                {
                    //插入
                    model.status = 1;
                    GoodsDAL.AddGoods(model);
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

        // GET: Goods/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Goods/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Goods/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Goods/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Goods/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Goods/Delete/5
        public ActionResult Delete(int id)
        {


            return View();
        }

        // POST: Goods/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here



                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
