using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;

	/// <summary>
	/// 角色-类
	/// </summary>
	[Serializable]
	public partial class ps_manager_role
	{
		public ps_manager_role()
		{}
		#region Model
		private int _id;
		private string _role_name="";
		private int? _role_type=0;
		private int? _is_sys=0;
		/// <summary>
		/// 角色id
		/// </summary>
		public int id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 角色名称
		/// </summary>
		public string role_name
		{
			set{ _role_name=value;}
			get{return _role_name;}
		}
		/// <summary>
		/// 角色类型
		/// </summary>
		public int? role_type
		{
			set{ _role_type=value;}
			get{return _role_type;}
		}
		/// <summary>
		/// 是否为系统管理员
		/// </summary>
		public int? is_sys
		{
			set{ _is_sys=value;}
			get{return _is_sys;}
		}
		#endregion Model


		#region  Method

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from [ps_manager_role]");
			strSql.Append(" where id=@id ");

			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = id;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add()
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into [ps_manager_role] (");
			strSql.Append("role_name,role_type,is_sys)");
			strSql.Append(" values (");
			strSql.Append("@role_name,@role_type,@is_sys)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@role_name", SqlDbType.NVarChar,100),
					new SqlParameter("@role_type", SqlDbType.TinyInt,1),
					new SqlParameter("@is_sys", SqlDbType.TinyInt,1)};
			parameters[0].Value = role_name;
			parameters[1].Value = role_type;
			parameters[2].Value = is_sys;

			object obj = DbHelperSQL.GetSingle(strSql.ToString(),parameters);
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
		/// 更新一条数据
		/// </summary>
		public bool Update()
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update [ps_manager_role] set ");
			strSql.Append("role_name=@role_name,");
			strSql.Append("role_type=@role_type,");
			strSql.Append("is_sys=@is_sys");
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@role_name", SqlDbType.NVarChar,100),
					new SqlParameter("@role_type", SqlDbType.TinyInt,1),
					new SqlParameter("@is_sys", SqlDbType.TinyInt,1),
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = role_name;
			parameters[1].Value = role_type;
			parameters[2].Value = is_sys;
			parameters[3].Value = id;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
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
		public bool Delete(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from [ps_manager_role] ");
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = id;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
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
        /// 返回角色名称
        /// </summary>
        public string GetTitle(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 role_name from [ps_manager_role]");
            strSql.Append(" where id=" + id);
            string title = Convert.ToString(DbHelperSQL.GetSingle(strSql.ToString()));
            if (string.IsNullOrEmpty(title))
            {
                return "";
            }
            return title;
        }

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public void GetModel(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select id,role_name,role_type,is_sys ");
			strSql.Append(" FROM [ps_manager_role] ");
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = id;

			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["id"]!=null && ds.Tables[0].Rows[0]["id"].ToString()!="")
				{
					this.id=int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["role_name"]!=null )
				{
					this.role_name=ds.Tables[0].Rows[0]["role_name"].ToString();
				}
				if(ds.Tables[0].Rows[0]["role_type"]!=null && ds.Tables[0].Rows[0]["role_type"].ToString()!="")
				{
					this.role_type=int.Parse(ds.Tables[0].Rows[0]["role_type"].ToString());
				}
				if(ds.Tables[0].Rows[0]["is_sys"]!=null && ds.Tables[0].Rows[0]["is_sys"].ToString()!="")
				{
					this.is_sys=int.Parse(ds.Tables[0].Rows[0]["is_sys"].ToString());
				}
			}
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select * ");
			strSql.Append(" FROM [ps_manager_role] ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQL.Query(strSql.ToString());
		}

		#endregion  Method
	}


