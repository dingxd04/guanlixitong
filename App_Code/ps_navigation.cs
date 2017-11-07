using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;

	/// <summary>
	/// 类ps_navigation。
	/// </summary>
	[Serializable]
	public partial class ps_navigation
	{
		public ps_navigation()
		{}
		#region Model
		private int _id;
		private string _title;
		private string _link_url="";
		private int? _sort_id=1;
		private int? _parent_id=0;
		/// <summary>
		/// 系统栏目id
		/// </summary>
		public int id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 栏目名称
		/// </summary>
		public string title
		{
			set{ _title=value;}
			get{return _title;}
		}
		/// <summary>
		/// 链接
		/// </summary>
		public string link_url
		{
			set{ _link_url=value;}
			get{return _link_url;}
		}
		/// <summary>
		/// 排序
		/// </summary>
		public int? sort_id
		{
			set{ _sort_id=value;}
			get{return _sort_id;}
		}
		/// <summary>
		/// 父级id
		/// </summary>
		public int? parent_id
		{
			set{ _parent_id=value;}
			get{return _parent_id;}
		}
		#endregion Model


		#region  Method


		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists()
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from [ps_navigation]");
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
			strSql.Append("insert into [ps_navigation] (");
			strSql.Append("title,link_url,sort_id,parent_id)");
			strSql.Append(" values (");
			strSql.Append("@title,@link_url,@sort_id,@parent_id)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@title", SqlDbType.NVarChar,100),
					new SqlParameter("@link_url", SqlDbType.NVarChar,255),
					new SqlParameter("@sort_id", SqlDbType.Int,4),
					new SqlParameter("@parent_id", SqlDbType.Int,4)};
			parameters[0].Value = title;
			parameters[1].Value = link_url;
			parameters[2].Value = sort_id;
			parameters[3].Value = parent_id;

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
			strSql.Append("update [ps_navigation] set ");
			strSql.Append("title=@title,");
			strSql.Append("link_url=@link_url,");
			strSql.Append("sort_id=@sort_id,");
			strSql.Append("parent_id=@parent_id");
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@title", SqlDbType.NVarChar,100),
					new SqlParameter("@link_url", SqlDbType.NVarChar,255),
					new SqlParameter("@sort_id", SqlDbType.Int,4),
					new SqlParameter("@parent_id", SqlDbType.Int,4),
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = title;
			parameters[1].Value = link_url;
			parameters[2].Value = sort_id;
			parameters[3].Value = parent_id;
			parameters[4].Value = id;

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
			strSql.Append("delete from [ps_navigation] ");
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
		/// 得到一个对象实体
		/// </summary>
		public void GetModel(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select id,title,link_url,sort_id,parent_id ");
			strSql.Append(" FROM [ps_navigation] ");
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
				if(ds.Tables[0].Rows[0]["title"]!=null )
				{
					this.title=ds.Tables[0].Rows[0]["title"].ToString();
				}
				if(ds.Tables[0].Rows[0]["link_url"]!=null )
				{
					this.link_url=ds.Tables[0].Rows[0]["link_url"].ToString();
				}
				if(ds.Tables[0].Rows[0]["sort_id"]!=null && ds.Tables[0].Rows[0]["sort_id"].ToString()!="")
				{
					this.sort_id=int.Parse(ds.Tables[0].Rows[0]["sort_id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["parent_id"]!=null && ds.Tables[0].Rows[0]["parent_id"].ToString()!="")
				{
					this.parent_id=int.Parse(ds.Tables[0].Rows[0]["parent_id"].ToString());
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
			strSql.Append(" FROM [ps_navigation] ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQL.Query(strSql.ToString());
		}

		#endregion  Method
	}


