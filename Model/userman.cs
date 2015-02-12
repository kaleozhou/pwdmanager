using System;
namespace Maticsoft.Model
{
	/// <summary>
	/// userman:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class userman
	{
		public userman()
		{}
		#region Model
		private int _usermanid;
		private string _usermanname;
		private string _usermanpwd;
		private DateTime? _usermanregisterdate;
		private string _usermanrealname;
		private decimal? _usermanphone;
		private string _usermansex;
		private DateTime? _usermanenddate;
		private string _usermanstatus;
		/// <summary>
		/// auto_increment
		/// </summary>
		public int UserManId
		{
			set{ _usermanid=value;}
			get{return _usermanid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string UserManName
		{
			set{ _usermanname=value;}
			get{return _usermanname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string UserManPwd
		{
			set{ _usermanpwd=value;}
			get{return _usermanpwd;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? UserManRegisterDate
		{
			set{ _usermanregisterdate=value;}
			get{return _usermanregisterdate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string UserManRealname
		{
			set{ _usermanrealname=value;}
			get{return _usermanrealname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? UserManPhone
		{
			set{ _usermanphone=value;}
			get{return _usermanphone;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string UserManSex
		{
			set{ _usermansex=value;}
			get{return _usermansex;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? UserManEndDate
		{
			set{ _usermanenddate=value;}
			get{return _usermanenddate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string UserManStatus
		{
			set{ _usermanstatus=value;}
			get{return _usermanstatus;}
		}
		#endregion Model

	}
}

