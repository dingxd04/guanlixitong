using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;

	/// <summary>
	/// 类ps_salse_depot。
	/// </summary>
	[Serializable]
	public partial class ps_salse_depot
	{
		public ps_salse_depot()
		{}
        #region Model
        private long _id;
        private string _note_no = "";
        private int? _depot_category_id = 0;
        private int? _depot_id = 0;
        private int? _order_id;
        private long? _goods_id;
        private int? _product_category_id = 0;
        private string _goods_title;
        private decimal? _goods_price = 0M;
        private decimal? _real_price = 0M;
        private int? _quantity = 0;
        private string _dw = "";
        private DateTime? _add_time = DateTime.Now;
        private long? _here_depot_id = 0;
        private int? _user_id = 0;
        /// <summary>
        /// 销售记录id
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
        /// 地区id
        /// </summary>
        public int? depot_category_id
        {
            set { _depot_category_id = value; }
            get { return _depot_category_id; }
        }
        /// <summary>
        /// 商家的ID
        /// </summary>
        public int? depot_id
        {
            set { _depot_id = value; }
            get { return _depot_id; }
        }
        /// <summary>
        /// 订单ID
        /// </summary>
        public int? order_id
        {
            set { _order_id = value; }
            get { return _order_id; }
        }
        /// <summary>
        /// 商品ID
        /// </summary>
        public long? goods_id
        {
            set { _goods_id = value; }
            get { return _goods_id; }
        }
        /// <summary>
        /// 产品种类
        /// </summary>
        public int? product_category_id
        {
            set { _product_category_id = value; }
            get { return _product_category_id; }
        }
        /// <summary>
        /// 商品名称
        /// </summary>
        public string goods_title
        {
            set { _goods_title = value; }
            get { return _goods_title; }
        }
        /// <summary>
        /// 进货价格
        /// </summary>
        public decimal? goods_price
        {
            set { _goods_price = value; }
            get { return _goods_price; }
        }
        /// <summary>
        /// 实际价格
        /// </summary>
        public decimal? real_price
        {
            set { _real_price = value; }
            get { return _real_price; }
        }
        /// <summary>
        /// 订购数量
        /// </summary>
        public int? quantity
        {
            set { _quantity = value; }
            get { return _quantity; }
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
        /// 销售时间
        /// </summary>
        public DateTime? add_time
        {
            set { _add_time = value; }
            get { return _add_time; }
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
			strSql.Append("select count(1) from [ps_salse_depot]");
			strSql.Append(" where id=@id ");

			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.BigInt)};
			parameters[0].Value = id;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}
        /// <summary>
        /// 是否操作用户销售用户的记录
        /// </summary>
        public bool ExistsCZXS()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from [ps_salse_depot]");
            strSql.Append(" where user_id=@user_id  ");

            SqlParameter[] parameters = {
                                            new SqlParameter("@user_id", SqlDbType.Int,4)};
            parameters[0].Value = user_id;
            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 根据条件和字段汇总
        /// </summary>
        public string GetTitleSum(string strWhere, string Title)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 " + Title + " as sumcode from [ps_salse_depot]");
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
            strSql.Append("insert into [ps_salse_depot] (");
            strSql.Append("note_no,depot_category_id,depot_id,order_id,goods_id,product_category_id,goods_title,goods_price,real_price,quantity,dw,add_time,here_depot_id,user_id)");
            strSql.Append(" values (");
            strSql.Append("@note_no,@depot_category_id,@depot_id,@order_id,@goods_id,@product_category_id,@goods_title,@goods_price,@real_price,@quantity,@dw,@add_time,@here_depot_id,@user_id)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@note_no", SqlDbType.VarChar,50),
					new SqlParameter("@depot_category_id", SqlDbType.Int,4),
					new SqlParameter("@depot_id", SqlDbType.Int,4),
					new SqlParameter("@order_id", SqlDbType.Int,4),
					new SqlParameter("@goods_id", SqlDbType.BigInt,8),
					new SqlParameter("@product_category_id", SqlDbType.Int,4),
					new SqlParameter("@goods_title", SqlDbType.NVarChar,100),
					new SqlParameter("@goods_price", SqlDbType.Decimal,5),
					new SqlParameter("@real_price", SqlDbType.Decimal,5),
					new SqlParameter("@quantity", SqlDbType.Int,4),
					new SqlParameter("@dw", SqlDbType.VarChar,50),
					new SqlParameter("@add_time", SqlDbType.DateTime),
					new SqlParameter("@here_depot_id", SqlDbType.BigInt,8),
					new SqlParameter("@user_id", SqlDbType.Int,4)};
            parameters[0].Value = note_no;
            parameters[1].Value = depot_category_id;
            parameters[2].Value = depot_id;
            parameters[3].Value = order_id;
            parameters[4].Value = goods_id;
            parameters[5].Value = product_category_id;
            parameters[6].Value = goods_title;
            parameters[7].Value = goods_price;
            parameters[8].Value = real_price;
            parameters[9].Value = quantity;
            parameters[10].Value = dw;
            parameters[11].Value = add_time;
            parameters[12].Value = here_depot_id;
            parameters[13].Value = user_id;

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
            strSql.Append("update [ps_salse_depot] set ");
            strSql.Append("note_no=@note_no,");
            strSql.Append("depot_category_id=@depot_category_id,");
            strSql.Append("depot_id=@depot_id,");
            strSql.Append("order_id=@order_id,");
            strSql.Append("goods_id=@goods_id,");
            strSql.Append("product_category_id=@product_category_id,");
            strSql.Append("goods_title=@goods_title,");
            strSql.Append("goods_price=@goods_price,");
            strSql.Append("real_price=@real_price,");
            strSql.Append("quantity=@quantity,");
            strSql.Append("dw=@dw,");
            strSql.Append("add_time=@add_time,");
            strSql.Append("here_depot_id=@here_depot_id,");
            strSql.Append("user_id=@user_id");
            strSql.Append(" where id=@id ");
            SqlParameter[] parameters = {
					new SqlParameter("@note_no", SqlDbType.VarChar,50),
					new SqlParameter("@depot_category_id", SqlDbType.Int,4),
					new SqlParameter("@depot_id", SqlDbType.Int,4),
					new SqlParameter("@order_id", SqlDbType.Int,4),
					new SqlParameter("@goods_id", SqlDbType.BigInt,8),
					new SqlParameter("@product_category_id", SqlDbType.Int,4),
					new SqlParameter("@goods_title", SqlDbType.NVarChar,100),
					new SqlParameter("@goods_price", SqlDbType.Decimal,5),
					new SqlParameter("@real_price", SqlDbType.Decimal,5),
					new SqlParameter("@quantity", SqlDbType.Int,4),
					new SqlParameter("@dw", SqlDbType.VarChar,50),
					new SqlParameter("@add_time", SqlDbType.DateTime),
					new SqlParameter("@here_depot_id", SqlDbType.BigInt,8),
					new SqlParameter("@user_id", SqlDbType.Int,4),
					new SqlParameter("@id", SqlDbType.BigInt,8)};
            parameters[0].Value = note_no;
            parameters[1].Value = depot_category_id;
            parameters[2].Value = depot_id;
            parameters[3].Value = order_id;
            parameters[4].Value = goods_id;
            parameters[5].Value = product_category_id;
            parameters[6].Value = goods_title;
            parameters[7].Value = goods_price;
            parameters[8].Value = real_price;
            parameters[9].Value = quantity;
            parameters[10].Value = dw;
            parameters[11].Value = add_time;
            parameters[12].Value = here_depot_id;
            parameters[13].Value = user_id;
            parameters[14].Value = id;

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
            strSql.Append("delete from [ps_salse_depot] ");
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
            strSql.Append("select id,note_no,depot_category_id,depot_id,order_id,goods_id,product_category_id,goods_title,goods_price,real_price,quantity,dw,add_time,here_depot_id,user_id ");
            strSql.Append(" FROM [ps_salse_depot] ");
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
                if (ds.Tables[0].Rows[0]["depot_category_id"] != null && ds.Tables[0].Rows[0]["depot_category_id"].ToString() != "")
                {
                    this.depot_category_id = int.Parse(ds.Tables[0].Rows[0]["depot_category_id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["depot_id"] != null && ds.Tables[0].Rows[0]["depot_id"].ToString() != "")
                {
                    this.depot_id = int.Parse(ds.Tables[0].Rows[0]["depot_id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["order_id"] != null && ds.Tables[0].Rows[0]["order_id"].ToString() != "")
                {
                    this.order_id = int.Parse(ds.Tables[0].Rows[0]["order_id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["goods_id"] != null && ds.Tables[0].Rows[0]["goods_id"].ToString() != "")
                {
                    this.goods_id = long.Parse(ds.Tables[0].Rows[0]["goods_id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["product_category_id"] != null && ds.Tables[0].Rows[0]["product_category_id"].ToString() != "")
                {
                    this.product_category_id = int.Parse(ds.Tables[0].Rows[0]["product_category_id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["goods_title"] != null)
                {
                    this.goods_title = ds.Tables[0].Rows[0]["goods_title"].ToString();
                }
                if (ds.Tables[0].Rows[0]["goods_price"] != null && ds.Tables[0].Rows[0]["goods_price"].ToString() != "")
                {
                    this.goods_price = decimal.Parse(ds.Tables[0].Rows[0]["goods_price"].ToString());
                }
                if (ds.Tables[0].Rows[0]["real_price"] != null && ds.Tables[0].Rows[0]["real_price"].ToString() != "")
                {
                    this.real_price = decimal.Parse(ds.Tables[0].Rows[0]["real_price"].ToString());
                }
                if (ds.Tables[0].Rows[0]["quantity"] != null && ds.Tables[0].Rows[0]["quantity"].ToString() != "")
                {
                    this.quantity = int.Parse(ds.Tables[0].Rows[0]["quantity"].ToString());
                }
                if (ds.Tables[0].Rows[0]["dw"] != null)
                {
                    this.dw = ds.Tables[0].Rows[0]["dw"].ToString();
                }
                if (ds.Tables[0].Rows[0]["add_time"] != null && ds.Tables[0].Rows[0]["add_time"].ToString() != "")
                {
                    this.add_time = DateTime.Parse(ds.Tables[0].Rows[0]["add_time"].ToString());
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
			strSql.Append(" FROM [ps_salse_depot] ");
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
            strSql.Append("select * FROM  ps_salse_depot");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            recordCount = Convert.ToInt32(DbHelperSQL.GetSingle(PagingHelper.CreateCountingSql(strSql.ToString())));
            return DbHelperSQL.Query(PagingHelper.CreatePagingSql(recordCount, pageSize, pageIndex, strSql.ToString(), filedOrder));
        }

		#endregion  Method
	}


