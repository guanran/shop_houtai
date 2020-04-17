using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.common
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class VMGDataGrid<T>
    {
        /// <summary>
        /// 当前页
        /// </summary>
        public int currentPage { get; set; }
        /// <summary>
        /// 数据总数
        /// </summary>
        public int dataCount { get; set; }
        /// <summary>
        /// 数据
        /// </summary>
        public List<T> data { get; set; }

        public T singleData { get; set; }
    }

    public class VMGDataGridHeader
    {
        public string name { get; set; }
        public string caption { get; set; }
        public string dataType { get; set; }
        public float width { get; set; }
        public string sort { get; set; }
        public string group { get; set; }
        public string total { get; set; }
        public bool show { get; set; }
    }

    public class VMDGDataGrid<T>
    {
        public VMGDataGrid<T> pageModel { get; set; }
        public List<VMGDataGridHeader> headers { get; set; }
    }

    /// <summary>
    /// 分页对象
    /// </summary>
    public class PageModel
    {
        /// <summary>
        /// 总页数
        /// </summary>
        public int total_rows_count { get; set; }

        /// <summary>
        /// 当前页码
        /// </summary>
        public int current_page { get; set; }

        /// <summary>
        /// 每页记录条数
        /// </summary>
        public int page_rows_count { get; set; }

        /// <summary>
        /// 共计页数
        /// </summary>
        public int total_pages
        {
            get { return ((total_rows_count + page_rows_count - 1) / page_rows_count) + 1; }
        }

        /// <summary>
        /// 排序字段
        /// </summary>
        public string orderby { get; set; }

    }
    /// <summary>
    /// 全局BLL返回对象
    /// </summary>
    public class CommonResponseModel<T>
    {
        /// <summary>
        /// 程序执行结果
        /// </summary>
        public CommonResponseBFlag BFlag { get; set; }

        /// <summary>
        /// 程序出现异常是返回的异常对象
        /// </summary>
        public Exception Ex { get; set; }

        /// <summary>
        /// 程序正常返回的执行数据结果
        /// </summary>
        public T TData { get; set; }

        /// <summary>
        /// 备用消息
        /// </summary>
        public string Informates { get; set; }
    }

    /// <summary>
    /// 全局Ajax请求返回对象
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class CommonAjaxResponseModel<T>
    {
        /// <summary>
        /// 结果
        /// </summary>
        public CommonResponseBFlag BFlag { get; set; }
        /// <summary>
        /// 消息
        /// </summary>
        public string Msg { get; set; }
        /// <summary>
        /// 数据结果
        /// </summary>
        public T TData { get; set; }
    }

    /// <summary>
    /// ejAjax返回对象
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class CommonResult<T>
    {
        /// <summary>
        /// 结果
        /// </summary>
        public CommonResponseBFlag BFlag { get; set; }
        /// <summary>
        /// 数据
        /// </summary>
        public T TData { get; set; }
    }

    public class PageSearchModel<T>
    {
        public int pageIndex = 1;
        public int pageSize = 15;
        public int total = 0;
        public T condition { get; set; }
    }

    /// <summary>
    /// 全局返回结果类型
    /// </summary>
    public enum CommonResponseBFlag
    {
        /// <summary>
        /// 成功
        /// </summary>
        Success = 10,
        /// <summary>
        /// 逻辑错误
        /// </summary>
        LogicError = 20,
        /// <summary>
        /// 系统错误
        /// </summary>
        SysError = 30,
        /// <summary>
        /// 权限错误
        /// </summary>
        AuthorityError = 40,
        /// <summary>
        /// 帐号登录状态错误
        /// </summary>
        LoginError = 50,
        /// <summary>
        /// 图片服务器保存失败
        /// </summary>
        EjuServerError = 60
    }
}
