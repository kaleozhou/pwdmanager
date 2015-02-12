using System;
using System.Data;
using System.Text;
using MySql.Data.MySqlClient;
using Maticsoft.DBUtility;//Please add references
namespace Maticsoft.DAL
{
	/// <summary>
	/// 数据访问类:userman
	/// </summary>
	public partial class userman
	{
		public userman()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperMySQL.GetMaxID("UserManId", "userman"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int UserManId)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from userman");
			strSql.Append(" where UserManId=@UserManId");
			MySqlParameter[] parameters = {
					new MySqlParameter("@UserManId", MySqlDbType.Int32)
			};
			parameters[0].Value = UserManId;

			return DbHelperMySQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Maticsoft.Model.userman model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into userman(");
			strSql.Append("UserManName,UserManPwd,UserManRegisterDate,UserManRealname,UserManPhone,UserManSex,UserManEndDate,UserManStatus)");
			strSql.Append(" values (");
			strSql.Append("@UserManName,@UserManPwd,@UserManRegisterDate,@UserManRealname,@UserManPhone,@UserManSex,@UserManEndDate,@UserManStatus)");
			MySqlParameter[] parameters = {
					new MySqlParameter("@UserManName", MySqlDbType.VarChar,50),
					new MySqlParameter("@UserManPwd", MySqlDbType.VarChar,50),
					new MySqlParameter("@UserManRegisterDate", MySqlDbType.Date),
					new MySqlParameter("@UserManRealname", MySqlDbType.VarChar,50),
					new MySqlParameter("@UserManPhone", MySqlDbType.Decimal,20),
					new MySqlParameter("@UserManSex", MySqlDbType.VarChar,20),
					new MySqlParameter("@UserManEndDate", MySqlDbType.Date),
					new MySqlParameter("@UserManStatus", MySqlDbType.VarChar,50)};
			parameters[0].Value = model.UserManName;
			parameters[1].Value = model.UserManPwd;
			parameters[2].Value = model.UserManRegisterDate;
			parameters[3].Value = model.UserManRealname;
			parameters[4].Value = model.UserManPhone;
			parameters[5].Value = model.UserManSex;
			parameters[6].Value = model.UserManEndDate;
			parameters[7].Value = model.UserManStatus;

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
		public bool Update(Maticsoft.Model.userman model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update userman set ");
			strSql.Append("UserManName=@UserManName,");
			strSql.Append("UserManPwd=@UserManPwd,");
			strSql.Append("UserManRegisterDate=@UserManRegisterDate,");
			strSql.Append("UserManRealname=@UserManRealname,");
			strSql.Append("UserManPhone=@UserManPhone,");
			strSql.Append("UserManSex=@UserManSex,");
			strSql.Append("UserManEndDate=@UserManEndDate,");
			strSql.Append("UserManStatus=@UserManStatus");
			strSql.Append(" where UserManId=@UserManId");
			MySqlParameter[] parameters = {
					new MySqlParameter("@UserManName", MySqlDbType.VarChar,50),
					new MySqlParameter("@UserManPwd", MySqlDbType.VarChar,50),
					new MySqlParameter("@UserManRegisterDate", MySqlDbType.Date),
					new MySqlParameter("@UserManRealname", MySqlDbType.VarChar,50),
					new MySqlParameter("@UserManPhone", MySqlDbType.Decimal,20),
					new MySqlParameter("@UserManSex", MySqlDbType.VarChar,20),
					new MySqlParameter("@UserManEndDate", MySqlDbType.Date),
					new MySqlParameter("@UserManStatus", MySqlDbType.VarChar,50),
					new MySqlParameter("@UserManId", MySqlDbType.Int32,11)};
			parameters[0].Value = model.UserManName;
			parameters[1].Value = model.UserManPwd;
			parameters[2].Value = model.UserManRegisterDate;
			parameters[3].Value = model.UserManRealname;
			parameters[4].Value = model.UserManPhone;
			parameters[5].Value = model.UserManSex;
			parameters[6].Value = model.UserManEndDate;
			parameters[7].Value = model.UserManStatus;
			parameters[8].Value = model.UserManId;

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
		public bool Delete(int UserManId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from userman ");
			strSql.Append(" where UserManId=@UserManId");
			MySqlParameter[] parameters = {
					new MySqlParameter("@UserManId", MySqlDbType.Int32)
			};
			parameters[0].Value = UserManId;

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
		public bool DeleteList(string UserManIdlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from userman ");
			strSql.Append(" where UserManId in ("+UserManIdlist + ")  ");
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
		public Maticsoft.Model.userman GetModel(int UserManId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select UserManId,UserManName,UserManPwd,UserManRegisterDate,UserManRealname,UserManPhone,UserManSex,UserManEndDate,UserManStatus from userman ");
			strSql.Append(" where UserManId=@UserManId");
			MySqlParameter[] parameters = {
					new MySqlParameter("@UserManId", MySqlDbType.Int32)
			};
			parameters[0].Value = UserManId;

			Maticsoft.Model.userman model=new Maticsoft.Model.userman();
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
		public Maticsoft.Model.userman DataRowToModel(DataRow row)
		{
			Maticsoft.Model.userman model=new Maticsoft.Model.userman();
			if (row != null)
			{
				if(row["UserManId"]!=null && row["UserManId"].ToString()!="")
				{
					model.UserManId=int.Parse(row["UserManId"].ToString());
				}
				if(row["UserManName"]!=null)
				{
					model.UserManName=row["UserManName"].ToString();
				}
				if(row["UserManPwd"]!=null)
				{
					model.UserManPwd=row["UserManPwd"].ToString();
				}
				if(row["UserManRegisterDate"]!=null && row["UserManRegisterDate"].ToString()!="")
				{
					model.UserManRegisterDate=DateTime.Parse(row["UserManRegisterDate"].ToString());
				}
				if(row["UserManRealname"]!=null)
				{
					model.UserManRealname=row["UserManRealname"].ToString();
				}
				if(row["UserManPhone"]!=null && row["UserManPhone"].ToString()!="")
				{
					model.UserManPhone=decimal.Parse(row["UserManPhone"].ToString());
				}
				if(row["UserManSex"]!=null)
				{
					model.UserManSex=row["UserManSex"].ToString();
				}
				if(row["UserManEndDate"]!=null && row["UserManEndDate"].ToString()!="")
				{
					model.UserManEndDate=DateTime.Parse(row["UserManEndDate"].ToString());
				}
				if(row["UserManStatus"]!=null)
				{
					model.UserManStatus=row["UserManStatus"].ToString();
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
			strSql.Append("select UserManId,UserManName,UserManPwd,UserManRegisterDate,UserManRealname,UserManPhone,UserManSex,UserManEndDate,UserManStatus ");
			strSql.Append(" FROM userman ");
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
			strSql.Append("select count(1) FROM userman ");
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
				strSql.Append("order by T.UserManId desc");
			}
			strSql.Append(")AS Row, T.*  from userman T ");
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
			parameters[0].Value = "userman";
			parameters[1].Value = "UserManId";
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

