using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entity
{
    /// <summary>
    /// t_index_banner:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Table("t_goods")]
    public partial class t_index_banner
	{
		public t_index_banner()
		{}
		#region Model
		private int _iautoid;
		private string _sname;
		private string _simg;
		private string _sbackground;
		private string _surl;
		private int _itype=1;
		private int _iadminid=0;
		private int _ionline=2;
		private int _isort=0;
		private int _istatus=1;
		private int _icreatetime=0;
		private int _iupdatetime=0;
        /// <summary>
        /// auto_increment
        /// </summary>
        [Key]
        public int iAutoID
		{
			set{ _iautoid=value;}
			get{return _iautoid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string sName
		{
			set{ _sname=value;}
			get{return _sname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string sImg
		{
			set{ _simg=value;}
			get{return _simg;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string sBackGround
		{
			set{ _sbackground=value;}
			get{return _sbackground;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string sUrl
		{
			set{ _surl=value;}
			get{return _surl;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int iType
		{
			set{ _itype=value;}
			get{return _itype;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int iAdminID
		{
			set{ _iadminid=value;}
			get{return _iadminid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int iOnline
		{
			set{ _ionline=value;}
			get{return _ionline;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int iSort
		{
			set{ _isort=value;}
			get{return _isort;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int iStatus
		{
			set{ _istatus=value;}
			get{return _istatus;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int iCreateTime
		{
			set{ _icreatetime=value;}
			get{return _icreatetime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int iUpdateTime
		{
			set{ _iupdatetime=value;}
			get{return _iupdatetime;}
		}
		#endregion Model

	}
}

