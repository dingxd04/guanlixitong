using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;

	/// <summary>
	/// 类ps_manager_role_value。
	/// </summary>
	[Serializable]
	public partial class ps_manager_role_value
	{
		public ps_manager_role_value()
		{}
		#region Model
		private int _id;
		private int? _role_id=0;
		private int? _nav_id=0;
		/// <summary>
		/// 角色栏目对应关系id
		/// </summary>
		public int id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 角色id
		/// </summary>
		public int? role_id
		{
			set{ _role_id=value;}
			get{return _role_id;}
		}
		/// <summary>
		/// 栏目id
		/// </summary>
		public int? nav_id
		{
			set{ _nav_id=value;}
			get{return _nav_id;}
		}
		#endregion Model


		#region  Method


		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists()
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from [ps_manager_role_value]");
			strSql.Append(" where id=@id ");

			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = id;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}

        /// <summary>
        /// 是否有访问该网页的权限
        /// </summary>
        public bool QXExists(int _role_id, int _nav_id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from ps_manager_role_value where role_id=" + _role_id + " and nav_id=" + _nav_id + "");
            return DbHelperSQL.Exists(strSql.ToString());
        }
		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add()
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into [ps_manager_role_value] (");
			strSql.Append("role_id,nav_id)");
			strSql.Append(" values (");
			strSql.Append("@role_id,@nav_id)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@role_id", SqlDbType.Int,4),
					new SqlParameter("@nav_id", SqlDbType.Int,4)};
			parameters[0].Value = role_id;
			parameters[1].Value = nav_id;

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
			strSql.Append("update [ps_manager_role_value] set ");
			strSql.Append("role_id=@role_id,");
			strSql.Append("nav_id=@nav_id");
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@role_id", SqlDbType.Int,4),
					new SqlParameter("@nav_id", SqlDbType.Int,4),
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = role_id;
			parameters[1].Value = nav_id;
			parameters[2].Value = id;

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
        public bool Delete(int role_id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from [ps_manager_role_value] ");
            strSql.Append(" where role_id=@role_id ");
			SqlParameter[] parameters = {
					new SqlParameter("@role_id", SqlDbType.Int,4)};
            parameters[0].Value = role_id;

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
		/// 得到一个对象实体
		/// </summary>
		public void GetModel(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select id,role_id,nav_id ");
			strSql.Append(" FROM [ps_manager_role_value] ");
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
				if(ds.Tables[0].Rows[0]["role_id"]!=null && ds.Tables[0].Rows[0]["role_id"].ToString()!="")
				{
					this.role_id=int.Parse(ds.Tables[0].Rows[0]["role_id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["nav_id"]!=null && ds.Tables[0].Rows[0]["nav_id"].ToString()!="")
				{
					this.nav_id=int.Parse(ds.Tables[0].Rows[0]["nav_id"].ToString());
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
			strSql.Append(" FROM [ps_manager_role_value] ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQL.Query(strSql.ToString());
		}

		#endregion  Method
	}


