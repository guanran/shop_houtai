using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entity
{
	/// <summary>
	/// t_procurement_records:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class t_procurement_records
	{
		public t_procurement_records()
		{}
		#region Model
		private int _id;
		private string _goodsname;
		private string _kind;
		private DateTime? _buytime;
		private int? _buycount;
		private decimal? _buyprice;
		private decimal? _freight;
		private decimal? _othermoney;
		private decimal? _totalprice;
		private decimal? _averageprice;
		private decimal? _sellprice;
		private int? _isarrive;
		/// <summary>
		/// 
		/// </summary>
		public int id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string goodsName
		{
			set{ _goodsname=value;}
			get{return _goodsname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string kind
		{
			set{ _kind=value;}
			get{return _kind;}
		}
		/// <summary>
		/// on update CURRENT_TIMESTAMP
		/// </summary>
		public DateTime? buyTime
		{
			set{ _buytime=value;}
			get{return _buytime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? buyCount
		{
			set{ _buycount=value;}
			get{return _buycount;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? buyPrice
		{
			set{ _buyprice=value;}
			get{return _buyprice;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? freight
		{
			set{ _freight=value;}
			get{return _freight;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? otherMoney
		{
			set{ _othermoney=value;}
			get{return _othermoney;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? totalPrice
		{
			set{ _totalprice=value;}
			get{return _totalprice;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? averagePrice
		{
			set{ _averageprice=value;}
			get{return _averageprice;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? sellPrice
		{
			set{ _sellprice=value;}
			get{return _sellprice;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? isArrive
		{
			set{ _isarrive=value;}
			get{return _isarrive;}
		}
		#endregion Model

	}
}

