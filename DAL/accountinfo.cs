using System;
using System.Data;
using System.Text;
using MySql.Data.MySqlClient;
using Maticsoft.DBUtility;//Please add references
namespace Maticsoft.DAL
{
	/// <summary>
	/// 数据访问类:accountinfo
	/// </summary>
	public partial class accountinfo
	{
		public accountinfo()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperMySQL.GetMaxID("AccountInfoId", "accountinfo"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int AccountInfoId)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from accountinfo");
			strSql.Append(" where AccountInfoId=@AccountInfoId");
			MySqlParameter[] parameters = {
					new MySqlParameter("@AccountInfoId", MySqlDbType.Int32)
			};
			parameters[0].Value = AccountInfoId;

			return DbHelperMySQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Maticsoft.Model.accountinfo model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into accountinfo(");
			strSql.Append("UserManId,AccountInfoName,AccountInfoLink,AccountInfoPwd,AccountInfoHint,AccountInfoStatus)");
			strSql.Append(" values (");
			strSql.Append("@UserManId,@AccountInfoName,@AccountInfoLink,@AccountInfoPwd,@AccountInfoHint,@AccountInfoStatus)");
			MySqlParameter[] parameters = {
					new MySqlParameter("@UserManId", MySqlDbType.Int32,11),
					new MySqlParameter("@AccountInfoName", MySqlDbType.VarChar,64),
					new MySqlParameter("@AccountInfoLink", MySqlDbType.VarChar,64),
					new MySqlParameter("@AccountInfoPwd", MySqlDbType.VarChar,128),
					new MySqlParameter("@AccountInfoHint", MySqlDbType.VarChar,64),
					new MySqlParameter("@AccountInfoStatus", MySqlDbType.VarChar,64)};
			parameters[0].Value = model.UserManId;
			parameters[1].Value = model.AccountInfoName;
			parameters[2].Value = model.AccountInfoLink;
			parameters[3].Value = model.AccountInfoPwd;
			parameters[4].Value = model.AccountInfoHint;
			parameters[5].Value = model.AccountInfoStatus;

			int rows=DbHelperMySQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Maticsoft.Model.accountinfo model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update accountinfo set ");
			strSql.Append("UserManId=@UserManId,");
			strSql.Append("AccountInfoName=@AccountInfoName,");
			strSql.Append("AccountInfoLink=@AccountInfoLink,");
			strSql.Append("AccountInfoPwd=@AccountInfoPwd,");
			strSql.Append("AccountInfoHint=@AccountInfoHint,");
			strSql.Append("AccountInfoStatus=@AccountInfoStatus");
			strSql.Append(" where AccountInfoId=@AccountInfoId");
			MySqlParameter[] parameters = {
					new MySqlParameter("@UserManId", MySqlDbType.Int32,11),
					new MySqlParameter("@AccountInfoName", MySqlDbType.VarChar,64),
					new MySqlParameter("@AccountInfoLink", MySqlDbType.VarChar,64),
					new MySqlParameter("@AccountInfoPwd", MySqlDbType.VarChar,128),
					new MySqlParameter("@AccountInfoHint", MySqlDbType.VarChar,64),
					new MySqlParameter("@AccountInfoStatus", MySqlDbType.VarChar,64),
					new MySqlParameter("@AccountInfoId", MySqlDbType.Int32,11)};
			parameters[0].Value = model.UserManId;
			parameters[1].Value = model.AccountInfoName;
			parameters[2].Value = model.AccountInfoLink;
			parameters[3].Value = model.AccountInfoPwd;
			parameters[4].Value = model.AccountInfoHint;
			parameters[5].Value = model.AccountInfoStatus;
			parameters[6].Value = model.AccountInfoId;

			int rows=DbHelperMySQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int AccountInfoId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from accountinfo ");
			strSql.Append(" where AccountInfoId=@AccountInfoId");
			MySqlParameter[] parameters = {
					new MySqlParameter("@AccountInfoId", MySqlDbType.Int32)
			};
			parameters[0].Value = AccountInfoId;

			int rows=DbHelperMySQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		/// <summary>
		/// 批量删除数据
		/// </summary>
		public bool DeleteList(string AccountInfoIdlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from accountinfo ");
			strSql.Append(" where AccountInfoId in ("+AccountInfoIdlist + ")  ");
			int rows=DbHelperMySQL.ExecuteSql(strSql.ToString());
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Maticsoft.Model.accountinfo GetModel(int AccountInfoId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select AccountInfoId,UserManId,AccountInfoName,AccountInfoLink,AccountInfoPwd,AccountInfoHint,AccountInfoStatus from accountinfo ");
			strSql.Append(" where AccountInfoId=@AccountInfoId");
			MySqlParameter[] parameters = {
					new MySqlParameter("@AccountInfoId", MySqlDbType.Int32)
			};
			parameters[0].Value = AccountInfoId;

			Maticsoft.Model.accountinfo model=new Maticsoft.Model.accountinfo();
			DataSet ds=DbHelperMySQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				return DataRowToModel(ds.Tables[0].Rows[0]);
			}
			else
			{
				return null;
			}
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Maticsoft.Model.accountinfo DataRowToModel(DataRow row)
		{
			Maticsoft.Model.accountinfo model=new Maticsoft.Model.accountinfo();
			if (row != null)
			{
				if(row["AccountInfoId"]!=null && row["AccountInfoId"].ToString()!="")
				{
					model.AccountInfoId=int.Parse(row["AccountInfoId"].ToString());
				}
				if(row["UserManId"]!=null && row["UserManId"].ToString()!="")
				{
					model.UserManId=int.Parse(row["UserManId"].ToString());
				}
				if(row["AccountInfoName"]!=null)
				{
					model.AccountInfoName=row["AccountInfoName"].ToString();
				}
				if(row["AccountInfoLink"]!=null)
				{
					model.AccountInfoLink=row["AccountInfoLink"].ToString();
				}
				if(row["AccountInfoPwd"]!=null)
				{
					model.AccountInfoPwd=row["AccountInfoPwd"].ToString();
				}
				if(row["AccountInfoHint"]!=null)
				{
					model.AccountInfoHint=row["AccountInfoHint"].ToString();
				}
				if(row["AccountInfoStatus"]!=null)
				{
					model.AccountInfoStatus=row["AccountInfoStatus"].ToString();
				}
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select AccountInfoId,UserManId,AccountInfoName,AccountInfoLink,AccountInfoPwd,AccountInfoHint,AccountInfoStatus ");
			strSql.Append(" FROM accountinfo ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperMySQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获取记录总数
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM accountinfo ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			object obj = DbHelperSQL.GetSingle(strSql.ToString());
			if (obj == null)
			{
				return 0;
			}
			else
			{
				return Convert.ToInt32(obj);
			}
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("SELECT * FROM ( ");
			strSql.Append(" SELECT ROW_NUMBER() OVER (");
			if (!string.IsNullOrEmpty(orderby.Trim()))
			{
				strSql.Append("order by T." + orderby );
			}
			else
			{
				strSql.Append("order by T.AccountInfoId desc");
			}
			strSql.Append(")AS Row, T.*  from accountinfo T ");
			if (!string.IsNullOrEmpty(strWhere.Trim()))
			{
				strSql.Append(" WHERE " + strWhere);
			}
			strSql.Append(" ) TT");
			strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
			return DbHelperMySQL.Query(strSql.ToString());
		}

		/*
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		{
			MySqlParameter[] parameters = {
					new MySqlParameter("@tblName", MySqlDbType.VarChar, 255),
					new MySqlParameter("@fldName", MySqlDbType.VarChar, 255),
					new MySqlParameter("@PageSize", MySqlDbType.Int32),
					new MySqlParameter("@PageIndex", MySqlDbType.Int32),
					new MySqlParameter("@IsReCount", MySqlDbType.Bit),
					new MySqlParameter("@OrderType", MySqlDbType.Bit),
					new MySqlParameter("@strWhere", MySqlDbType.VarChar,1000),
					};
			parameters[0].Value = "accountinfo";
			parameters[1].Value = "AccountInfoId";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperMySQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

