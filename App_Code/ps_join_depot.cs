using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;

	/// <summary>
	/// 入库记录-类
	/// </summary>
	[Serializable]
	public partial class ps_join_depot
	{
		public ps_join_depot()
		{}

        #region Model
        private long _id;
        private string _note_no = "";
        private int? _product_category_id = 0;
        private string _product_name = "";
        private DateTime? _add_time = DateTime.Now;
        private string _product_code_state = "";
        private decimal? _go_price = 0M;
        private decimal? _salse_price = 0M;
        private int? _product_num = 1;
        private string _dw = "";
        private long? _here_depot_id = 0;
        private int? _user_id = 0;
        /// <summary>
        /// 入库记录
        /// </summary>
        public long id
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 单据号
        /// </summary>
        public string note_no
        {
            set { _note_no = value; }
            get { return _note_no; }
        }
        /// <summary>
        /// 商品种类id
        /// </summary>
        public int? product_category_id
        {
            set { _product_category_id = value; }
            get { return _product_category_id; }
        }
        /// <summary>
        /// 商品名称
        /// </summary>
        public string product_name
        {
            set { _product_name = value; }
            get { return _product_name; }
        }
        /// <summary>
        ///  入库时间
        /// </summary>
        public DateTime? add_time
        {
            set { _add_time = value; }
            get { return _add_time; }
        }
        /// <summary>
        /// 入库或者出库
        /// </summary>
        public string product_code_state
        {
            set { _product_code_state = value; }
            get { return _product_code_state; }
        }
        /// <summary>
        /// 入库价格
        /// </summary>
        public decimal? go_price
        {
            set { _go_price = value; }
            get { return _go_price; }
        }
        /// <summary>
        /// 销售价格
        /// </summary>
        public decimal? salse_price
        {
            set { _salse_price = value; }
            get { return _salse_price; }
        }
        /// <summary>
        /// 入库数量
        /// </summary>
        public int? product_num
        {
            set { _product_num = value; }
            get { return _product_num; }
        }
        /// <summary>
        /// 单位
        /// </summary>
        public string dw
        {
            set { _dw = value; }
            get { return _dw; }
        }
        /// <summary>
        /// 对应在库表id
        /// </summary>
        public long? here_depot_id
        {
            set { _here_depot_id = value; }
            get { return _here_depot_id; }
        }
        /// <summary>
        /// 操作人id
        /// </summary>
        public int? user_id
        {
            set { _user_id = value; }
            get { return _user_id; }
        }
        #endregion Model

		#region  Method

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists()
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from [ps_join_depot]");
			strSql.Append(" where id=@id ");

			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.BigInt)};
			parameters[0].Value = id;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}

        /// <summary>
        /// 是否存在用户id记录
        /// </summary>
        public bool ExistsYH()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from [ps_join_depot]");
            strSql.Append(" where user_id=@user_id ");

            SqlParameter[] parameters = {
					new SqlParameter("@user_id", SqlDbType.Int,4)};
            parameters[0].Value = user_id;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 根据条件汇总
        /// </summary>
        public string GetwhereSum(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 count(id) as sumcode from [ps_join_depot]");
            strSql.Append(" where " + strWhere);
            string title = Convert.ToString(DbHelperSQL.GetSingle(strSql.ToString()));
            if (string.IsNullOrEmpty(title))
            {
                return "0";
            }
            return title;
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into [ps_join_depot] (");
            strSql.Append("note_no,product_category_id,product_name,add_time,product_code_state,go_price,salse_price,product_num,dw,here_depot_id,user_id)");
            strSql.Append(" values (");
            strSql.Append("@note_no,@product_category_id,@product_name,@add_time,@product_code_state,@go_price,@salse_price,@product_num,@dw,@here_depot_id,@user_id)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@note_no", SqlDbType.VarChar,50),
					new SqlParameter("@product_category_id", SqlDbType.Int,4),
					new SqlParameter("@product_name", SqlDbType.VarChar,200),
					new SqlParameter("@add_time", SqlDbType.DateTime),
					new SqlParameter("@product_code_state", SqlDbType.VarChar,50),
					new SqlParameter("@go_price", SqlDbType.Decimal,9),
					new SqlParameter("@salse_price", SqlDbType.Decimal,9),
					new SqlParameter("@product_num", SqlDbType.Int,4),
					new SqlParameter("@dw", SqlDbType.VarChar,50),
					new SqlParameter("@here_depot_id", SqlDbType.BigInt,8),
					new SqlParameter("@user_id", SqlDbType.Int,4)};
            parameters[0].Value = note_no;
            parameters[1].Value = product_category_id;
            parameters[2].Value = product_name;
            parameters[3].Value = add_time;
            parameters[4].Value = product_code_state;
            parameters[5].Value = go_price;
            parameters[6].Value = salse_price;
            parameters[7].Value = product_num;
            parameters[8].Value = dw;
            parameters[9].Value = here_depot_id;
            parameters[10].Value = user_id;

            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
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
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update [ps_join_depot] set ");
            strSql.Append("note_no=@note_no,");
            strSql.Append("product_category_id=@product_category_id,");
            strSql.Append("product_name=@product_name,");
            strSql.Append("add_time=@add_time,");
            strSql.Append("product_code_state=@product_code_state,");
            strSql.Append("go_price=@go_price,");
            strSql.Append("salse_price=@salse_price,");
            strSql.Append("product_num=@product_num,");
            strSql.Append("dw=@dw,");
            strSql.Append("here_depot_id=@here_depot_id,");
            strSql.Append("user_id=@user_id");
            strSql.Append(" where id=@id ");
            SqlParameter[] parameters = {
					new SqlParameter("@note_no", SqlDbType.VarChar,50),
					new SqlParameter("@product_category_id", SqlDbType.Int,4),
					new SqlParameter("@product_name", SqlDbType.VarChar,200),
					new SqlParameter("@add_time", SqlDbType.DateTime),
					new SqlParameter("@product_code_state", SqlDbType.VarChar,50),
					new SqlParameter("@go_price", SqlDbType.Decimal,9),
					new SqlParameter("@salse_price", SqlDbType.Decimal,9),
					new SqlParameter("@product_num", SqlDbType.Int,4),
					new SqlParameter("@dw", SqlDbType.VarChar,50),
					new SqlParameter("@here_depot_id", SqlDbType.BigInt,8),
					new SqlParameter("@user_id", SqlDbType.Int,4),
					new SqlParameter("@id", SqlDbType.BigInt,8)};
            parameters[0].Value = note_no;
            parameters[1].Value = product_category_id;
            parameters[2].Value = product_name;
            parameters[3].Value = add_time;
            parameters[4].Value = product_code_state;
            parameters[5].Value = go_price;
            parameters[6].Value = salse_price;
            parameters[7].Value = product_num;
            parameters[8].Value = dw;
            parameters[9].Value = here_depot_id;
            parameters[10].Value = user_id;
            parameters[11].Value = id;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
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
        public bool Delete(long id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from [ps_join_depot] ");
            strSql.Append(" where id=@id ");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.BigInt)};
            parameters[0].Value = id;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
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
        public void GetModel(long id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,note_no,product_category_id,product_name,add_time,product_code_state,go_price,salse_price,product_num,dw,here_depot_id,user_id ");
            strSql.Append(" FROM [ps_join_depot] ");
            strSql.Append(" where id=@id ");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.BigInt)};
            parameters[0].Value = id;

            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["id"] != null && ds.Tables[0].Rows[0]["id"].ToString() != "")
                {
                    this.id = long.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["note_no"] != null)
                {
                    this.note_no = ds.Tables[0].Rows[0]["note_no"].ToString();
                }
                if (ds.Tables[0].Rows[0]["product_category_id"] != null && ds.Tables[0].Rows[0]["product_category_id"].ToString() != "")
                {
                    this.product_category_id = int.Parse(ds.Tables[0].Rows[0]["product_category_id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["product_name"] != null)
                {
                    this.product_name = ds.Tables[0].Rows[0]["product_name"].ToString();
                }
                if (ds.Tables[0].Rows[0]["add_time"] != null && ds.Tables[0].Rows[0]["add_time"].ToString() != "")
                {
                    this.add_time = DateTime.Parse(ds.Tables[0].Rows[0]["add_time"].ToString());
                }
                if (ds.Tables[0].Rows[0]["product_code_state"] != null)
                {
                    this.product_code_state = ds.Tables[0].Rows[0]["product_code_state"].ToString();
                }
                if (ds.Tables[0].Rows[0]["go_price"] != null && ds.Tables[0].Rows[0]["go_price"].ToString() != "")
                {
                    this.go_price = decimal.Parse(ds.Tables[0].Rows[0]["go_price"].ToString());
                }
                if (ds.Tables[0].Rows[0]["salse_price"] != null && ds.Tables[0].Rows[0]["salse_price"].ToString() != "")
                {
                    this.salse_price = decimal.Parse(ds.Tables[0].Rows[0]["salse_price"].ToString());
                }
                if (ds.Tables[0].Rows[0]["product_num"] != null && ds.Tables[0].Rows[0]["product_num"].ToString() != "")
                {
                    this.product_num = int.Parse(ds.Tables[0].Rows[0]["product_num"].ToString());
                }
                if (ds.Tables[0].Rows[0]["dw"] != null)
                {
                    this.dw = ds.Tables[0].Rows[0]["dw"].ToString();
                }
                if (ds.Tables[0].Rows[0]["here_depot_id"] != null && ds.Tables[0].Rows[0]["here_depot_id"].ToString() != "")
                {
                    this.here_depot_id = long.Parse(ds.Tables[0].Rows[0]["here_depot_id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["user_id"] != null && ds.Tables[0].Rows[0]["user_id"].ToString() != "")
                {
                    this.user_id = int.Parse(ds.Tables[0].Rows[0]["user_id"].ToString());
                }
            }
        }
   
  

        /// <summary>
        /// 获得SQL 查询的数据
        /// </summary>
        public DataSet GetListSql(string strsql)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(strsql);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select * ");
			strSql.Append(" FROM [ps_join_depot] ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQL.Query(strSql.ToString());
		}

        /// <summary>
        /// 获得查询分页数据
        /// </summary>
        public DataSet GetList(int pageSize, int pageIndex, string strWhere, string filedOrder, out int recordCount)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * FROM  ps_join_depot");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            recordCount = Convert.ToInt32(DbHelperSQL.GetSingle(PagingHelper.CreateCountingSql(strSql.ToString())));
            return DbHelperSQL.Query(PagingHelper.CreatePagingSql(recordCount, pageSize, pageIndex, strSql.ToString(), filedOrder));
        }


		#endregion  Method
	}


