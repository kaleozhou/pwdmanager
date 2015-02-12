using System;
namespace Maticsoft.Model
{
	/// <summary>
	/// accountinfo:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class accountinfo
	{
		public accountinfo()
		{}
		#region Model
		private int _accountinfoid;
		private int? _usermanid;
		private string _accountinfoname;
		private string _accountinfolink;
		private string _accountinfopwd;
		private string _accountinfohint;
		private string _accountinfostatus;
		/// <summary>
		/// auto_increment
		/// </summary>
		public int AccountInfoId
		{
			set{ _accountinfoid=value;}
			get{return _accountinfoid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? UserManId
		{
			set{ _usermanid=value;}
			get{return _usermanid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string AccountInfoName
		{
			set{ _accountinfoname=value;}
			get{return _accountinfoname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string AccountInfoLink
		{
			set{ _accountinfolink=value;}
			get{return _accountinfolink;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string AccountInfoPwd
		{
			set{ _accountinfopwd=value;}
			get{return _accountinfopwd;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string AccountInfoHint
		{
			set{ _accountinfohint=value;}
			get{return _accountinfohint;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string AccountInfoStatus
		{
			set{ _accountinfostatus=value;}
			get{return _accountinfostatus;}
		}
		#endregion Model

	}
}

