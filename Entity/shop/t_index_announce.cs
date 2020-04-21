using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entity
{
    /// <summary>
    /// t_index_announce:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Table("t_index_announce")]
    public partial class t_index_announce
	{
		public t_index_announce()
		{}
		#region Model
		private int _iautoid;
		private string _stitle;
		private string _scover;
		private string _ssynopsis;
		private int? _iview;
		private int? _iuserid;
		private int? _icreatetime;
		private int? _icreateid;
        /// <summary>
        /// 
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
		public string sTitle
		{
			set{ _stitle=value;}
			get{return _stitle;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string sCover
		{
			set{ _scover=value;}
			get{return _scover;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string sSynopsis
		{
			set{ _ssynopsis=value;}
			get{return _ssynopsis;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? iView
		{
			set{ _iview=value;}
			get{return _iview;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? iUserID
		{
			set{ _iuserid=value;}
			get{return _iuserid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? iCreateTime
		{
			set{ _icreatetime=value;}
			get{return _icreatetime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? iCreateID
		{
			set{ _icreateid=value;}
			get{return _icreateid;}
		}
		#endregion Model

	}
}

