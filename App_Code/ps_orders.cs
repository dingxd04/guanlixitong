using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;

	/// <summary>
	/// 类ps_orders。
	/// </summary>
	[Serializable]
	public partial class ps_orders
	{
		public ps_orders()
		{}
        #region Model
        private int _id;
        private string _order_no = "";
        private int? _depot_category_id = 0;
        private int? _depot_id = 0;
        private int? _user_id = 0;
        private string _user_name = "";
        private int? _payment_id = 0;
        private int? _payment_status = 0;
        private DateTime? _payment_time;
        private string _message = "";
        private string _remark = "";
        private decimal? _payable_amount = 0M;
        private decimal? _real_amount = 0M;
        private decimal? _order_amount = 0M;
        private int? _status = 1;
        private DateTime? _add_time = DateTime.Now;
        private DateTime? _confirm_time;
        private DateTime? _complete_time;
        /// <summary>
        /// 自增ID
        /// </summary>
        public int id
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 订单号
        /// </summary>
        public string order_no
        {
            set { _order_no = value; }
            get { return _order_no; }
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
        /// 用户ID
        /// </summary>
        public int? user_id
        {
            set { _user_id = value; }
            get { return _user_id; }
        }
        /// <summary>
        /// 用户名
        /// </summary>
        public string user_name
        {
            set { _user_name = value; }
            get { return _user_name; }
        }
        /// <summary>
        /// 支付方式
        /// </summary>
        public int? payment_id
        {
            set { _payment_id = value; }
            get { return _payment_id; }
        }
        /// <summary>
        /// 支付状态1未支付2已支付
        /// </summary>
        public int? payment_status
        {
            set { _payment_status = value; }
            get { return _payment_status; }
        }
        /// <summary>
        /// 支付时间
        /// </summary>
        public DateTime? payment_time
        {
            set { _payment_time = value; }
            get { return _payment_time; }
        }
        /// <summary>
        /// 订单留言
        /// </summary>
        public string message
        {
            set { _message = value; }
            get { return _message; }
        }
        /// <summary>
        /// 订单备注
        /// </summary>
        public string remark
        {
            set { _remark = value; }
            get { return _remark; }
        }
        /// <summary>
        /// 订单商品总金额
        /// </summary>
        public decimal? payable_amount
        {
            set { _payable_amount = value; }
            get { return _payable_amount; }
        }
        /// <summary>
        /// 调价金额
        /// </summary>
        public decimal? real_amount
        {
            set { _real_amount = value; }
            get { return _real_amount; }
        }
        /// <summary>
        /// 订单实际总金额
        /// </summary>
        public decimal? order_amount
        {
            set { _order_amount = value; }
            get { return _order_amount; }
        }
        /// <summary>
        /// 订单状态1生成订单,2确认订单,3完成订单,4取消订单
        /// </summary>
        public int? status
        {
            set { _status = value; }
            get { return _status; }
        }
        /// <summary>
        /// 下单时间
        /// </summary>
        public DateTime? add_time
        {
            set { _add_time = value; }
            get { return _add_time; }
        }
        /// <summary>
        /// 确认时间
        /// </summary>
        public DateTime? confirm_time
        {
            set { _confirm_time = value; }
            get { return _confirm_time; }
        }
        /// <summary>
        /// 订单完成时间
        /// </summary>
        public DateTime? complete_time
        {
            set { _complete_time = value; }
            get { return _complete_time; }
        }
        #endregion Model


		#region  Method


		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{

		return DbHelperSQL.GetMaxID("id", "ps_orders"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from [ps_orders]");
			strSql.Append(" where id=@id ");

			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = id;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string order_no)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from [ps_orders]");
            strSql.Append(" where order_no=@order_no ");
            SqlParameter[] parameters = {
					new SqlParameter("@order_no", SqlDbType.NVarChar,100)};
            parameters[0].Value = order_no;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 根据条件和字段汇总
        /// </summary>
        public string GetTitleSum(string strWhere, string Title)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 " + Title + " as sumcode from [ps_orders]");
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
            strSql.Append("insert into [ps_orders] (");
            strSql.Append("order_no,depot_category_id,depot_id,user_id,user_name,payment_id,payment_status,payment_time,message,remark,payable_amount,real_amount,order_amount,status,add_time,confirm_time,complete_time)");
            strSql.Append(" values (");
            strSql.Append("@order_no,@depot_category_id,@depot_id,@user_id,@user_name,@payment_id,@payment_status,@payment_time,@message,@remark,@payable_amount,@real_amount,@order_amount,@status,@add_time,@confirm_time,@complete_time)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@order_no", SqlDbType.NVarChar,100),
					new SqlParameter("@depot_category_id", SqlDbType.Int,4),
					new SqlParameter("@depot_id", SqlDbType.Int,4),
					new SqlParameter("@user_id", SqlDbType.Int,4),
					new SqlParameter("@user_name", SqlDbType.NVarChar,100),
					new SqlParameter("@payment_id", SqlDbType.Int,4),
					new SqlParameter("@payment_status", SqlDbType.TinyInt,1),
					new SqlParameter("@payment_time", SqlDbType.DateTime),
					new SqlParameter("@message", SqlDbType.NVarChar,500),
					new SqlParameter("@remark", SqlDbType.NVarChar,500),
					new SqlParameter("@payable_amount", SqlDbType.Decimal,5),
					new SqlParameter("@real_amount", SqlDbType.Decimal,5),
					new SqlParameter("@order_amount", SqlDbType.Decimal,5),
					new SqlParameter("@status", SqlDbType.TinyInt,1),
					new SqlParameter("@add_time", SqlDbType.DateTime),
					new SqlParameter("@confirm_time", SqlDbType.DateTime),
					new SqlParameter("@complete_time", SqlDbType.DateTime)};
            parameters[0].Value = order_no;
            parameters[1].Value = depot_category_id;
            parameters[2].Value = depot_id;
            parameters[3].Value = user_id;
            parameters[4].Value = user_name;
            parameters[5].Value = payment_id;
            parameters[6].Value = payment_status;
            parameters[7].Value = payment_time;
            parameters[8].Value = message;
            parameters[9].Value = remark;
            parameters[10].Value = payable_amount;
            parameters[11].Value = real_amount;
            parameters[12].Value = order_amount;
            parameters[13].Value = status;
            parameters[14].Value = add_time;
            parameters[15].Value = confirm_time;
            parameters[16].Value = complete_time;

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
            strSql.Append("update [ps_orders] set ");
            strSql.Append("order_no=@order_no,");
            strSql.Append("depot_category_id=@depot_category_id,");
            strSql.Append("depot_id=@depot_id,");
            strSql.Append("user_id=@user_id,");
            strSql.Append("user_name=@user_name,");
            strSql.Append("payment_id=@payment_id,");
            strSql.Append("payment_status=@payment_status,");
            strSql.Append("payment_time=@payment_time,");
            strSql.Append("message=@message,");
            strSql.Append("remark=@remark,");
            strSql.Append("payable_amount=@payable_amount,");
            strSql.Append("real_amount=@real_amount,");
            strSql.Append("order_amount=@order_amount,");
            strSql.Append("status=@status,");
            strSql.Append("add_time=@add_time,");
            strSql.Append("confirm_time=@confirm_time,");
            strSql.Append("complete_time=@complete_time");
            strSql.Append(" where id=@id ");
            SqlParameter[] parameters = {
					new SqlParameter("@order_no", SqlDbType.NVarChar,100),
					new SqlParameter("@depot_category_id", SqlDbType.Int,4),
					new SqlParameter("@depot_id", SqlDbType.Int,4),
					new SqlParameter("@user_id", SqlDbType.Int,4),
					new SqlParameter("@user_name", SqlDbType.NVarChar,100),
					new SqlParameter("@payment_id", SqlDbType.Int,4),
					new SqlParameter("@payment_status", SqlDbType.TinyInt,1),
					new SqlParameter("@payment_time", SqlDbType.DateTime),
					new SqlParameter("@message", SqlDbType.NVarChar,500),
					new SqlParameter("@remark", SqlDbType.NVarChar,500),
					new SqlParameter("@payable_amount", SqlDbType.Decimal,5),
					new SqlParameter("@real_amount", SqlDbType.Decimal,5),
					new SqlParameter("@order_amount", SqlDbType.Decimal,5),
					new SqlParameter("@status", SqlDbType.TinyInt,1),
					new SqlParameter("@add_time", SqlDbType.DateTime),
					new SqlParameter("@confirm_time", SqlDbType.DateTime),
					new SqlParameter("@complete_time", SqlDbType.DateTime),
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = order_no;
            parameters[1].Value = depot_category_id;
            parameters[2].Value = depot_id;
            parameters[3].Value = user_id;
            parameters[4].Value = user_name;
            parameters[5].Value = payment_id;
            parameters[6].Value = payment_status;
            parameters[7].Value = payment_time;
            parameters[8].Value = message;
            parameters[9].Value = remark;
            parameters[10].Value = payable_amount;
            parameters[11].Value = real_amount;
            parameters[12].Value = order_amount;
            parameters[13].Value = status;
            parameters[14].Value = add_time;
            parameters[15].Value = confirm_time;
            parameters[16].Value = complete_time;
            parameters[17].Value = id;

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
        public bool Delete(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from [ps_orders] ");
            strSql.Append(" where id=@id ");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
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
        public void GetModel(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,order_no,depot_category_id,depot_id,user_id,user_name,payment_id,payment_status,payment_time,message,remark,payable_amount,real_amount,order_amount,status,add_time,confirm_time,complete_time ");
            strSql.Append(" FROM [ps_orders] ");
            strSql.Append(" where id=@id ");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = id;

            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["id"] != null && ds.Tables[0].Rows[0]["id"].ToString() != "")
                {
                    this.id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["order_no"] != null)
                {
                    this.order_no = ds.Tables[0].Rows[0]["order_no"].ToString();
                }
                if (ds.Tables[0].Rows[0]["depot_category_id"] != null && ds.Tables[0].Rows[0]["depot_category_id"].ToString() != "")
                {
                    this.depot_category_id = int.Parse(ds.Tables[0].Rows[0]["depot_category_id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["depot_id"] != null && ds.Tables[0].Rows[0]["depot_id"].ToString() != "")
                {
                    this.depot_id = int.Parse(ds.Tables[0].Rows[0]["depot_id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["user_id"] != null && ds.Tables[0].Rows[0]["user_id"].ToString() != "")
                {
                    this.user_id = int.Parse(ds.Tables[0].Rows[0]["user_id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["user_name"] != null)
                {
                    this.user_name = ds.Tables[0].Rows[0]["user_name"].ToString();
                }
                if (ds.Tables[0].Rows[0]["payment_id"] != null && ds.Tables[0].Rows[0]["payment_id"].ToString() != "")
                {
                    this.payment_id = int.Parse(ds.Tables[0].Rows[0]["payment_id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["payment_status"] != null && ds.Tables[0].Rows[0]["payment_status"].ToString() != "")
                {
                    this.payment_status = int.Parse(ds.Tables[0].Rows[0]["payment_status"].ToString());
                }
                if (ds.Tables[0].Rows[0]["payment_time"] != null && ds.Tables[0].Rows[0]["payment_time"].ToString() != "")
                {
                    this.payment_time = DateTime.Parse(ds.Tables[0].Rows[0]["payment_time"].ToString());
                }
                if (ds.Tables[0].Rows[0]["message"] != null)
                {
                    this.message = ds.Tables[0].Rows[0]["message"].ToString();
                }
                if (ds.Tables[0].Rows[0]["remark"] != null)
                {
                    this.remark = ds.Tables[0].Rows[0]["remark"].ToString();
                }
                if (ds.Tables[0].Rows[0]["payable_amount"] != null && ds.Tables[0].Rows[0]["payable_amount"].ToString() != "")
                {
                    this.payable_amount = decimal.Parse(ds.Tables[0].Rows[0]["payable_amount"].ToString());
                }
                if (ds.Tables[0].Rows[0]["real_amount"] != null && ds.Tables[0].Rows[0]["real_amount"].ToString() != "")
                {
                    this.real_amount = decimal.Parse(ds.Tables[0].Rows[0]["real_amount"].ToString());
                }
                if (ds.Tables[0].Rows[0]["order_amount"] != null && ds.Tables[0].Rows[0]["order_amount"].ToString() != "")
                {
                    this.order_amount = decimal.Parse(ds.Tables[0].Rows[0]["order_amount"].ToString());
                }
                if (ds.Tables[0].Rows[0]["status"] != null && ds.Tables[0].Rows[0]["status"].ToString() != "")
                {
                    this.status = int.Parse(ds.Tables[0].Rows[0]["status"].ToString());
                }
                if (ds.Tables[0].Rows[0]["add_time"] != null && ds.Tables[0].Rows[0]["add_time"].ToString() != "")
                {
                    this.add_time = DateTime.Parse(ds.Tables[0].Rows[0]["add_time"].ToString());
                }
                if (ds.Tables[0].Rows[0]["confirm_time"] != null && ds.Tables[0].Rows[0]["confirm_time"].ToString() != "")
                {
                    this.confirm_time = DateTime.Parse(ds.Tables[0].Rows[0]["confirm_time"].ToString());
                }
                if (ds.Tables[0].Rows[0]["complete_time"] != null && ds.Tables[0].Rows[0]["complete_time"].ToString() != "")
                {
                    this.complete_time = DateTime.Parse(ds.Tables[0].Rows[0]["complete_time"].ToString());
                }
            }
        }

        /// <summary>
        /// 根据订单号返回一个实体
        /// </summary>
        public void GetModel(string order_no)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,order_no,depot_category_id,depot_id,user_id,user_name,payment_id,payment_status,payment_time,message,remark,payable_amount,real_amount,order_amount,status,add_time,confirm_time,complete_time ");
            strSql.Append(" FROM [ps_orders] ");
            strSql.Append(" where order_no=@order_no");
            SqlParameter[] parameters = {
					new SqlParameter("@order_no", SqlDbType.NVarChar,100)};
            parameters[0].Value = order_no;

            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["id"] != null && ds.Tables[0].Rows[0]["id"].ToString() != "")
                {
                    this.id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["order_no"] != null)
                {
                    this.order_no = ds.Tables[0].Rows[0]["order_no"].ToString();
                }
                if (ds.Tables[0].Rows[0]["depot_category_id"] != null && ds.Tables[0].Rows[0]["depot_category_id"].ToString() != "")
                {
                    this.depot_category_id = int.Parse(ds.Tables[0].Rows[0]["depot_category_id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["depot_id"] != null && ds.Tables[0].Rows[0]["depot_id"].ToString() != "")
                {
                    this.depot_id = int.Parse(ds.Tables[0].Rows[0]["depot_id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["user_id"] != null && ds.Tables[0].Rows[0]["user_id"].ToString() != "")
                {
                    this.user_id = int.Parse(ds.Tables[0].Rows[0]["user_id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["user_name"] != null)
                {
                    this.user_name = ds.Tables[0].Rows[0]["user_name"].ToString();
                }
                if (ds.Tables[0].Rows[0]["payment_id"] != null && ds.Tables[0].Rows[0]["payment_id"].ToString() != "")
                {
                    this.payment_id = int.Parse(ds.Tables[0].Rows[0]["payment_id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["payment_status"] != null && ds.Tables[0].Rows[0]["payment_status"].ToString() != "")
                {
                    this.payment_status = int.Parse(ds.Tables[0].Rows[0]["payment_status"].ToString());
                }
                if (ds.Tables[0].Rows[0]["payment_time"] != null && ds.Tables[0].Rows[0]["payment_time"].ToString() != "")
                {
                    this.payment_time = DateTime.Parse(ds.Tables[0].Rows[0]["payment_time"].ToString());
                }
                if (ds.Tables[0].Rows[0]["message"] != null)
                {
                    this.message = ds.Tables[0].Rows[0]["message"].ToString();
                }
                if (ds.Tables[0].Rows[0]["remark"] != null)
                {
                    this.remark = ds.Tables[0].Rows[0]["remark"].ToString();
                }
                if (ds.Tables[0].Rows[0]["payable_amount"] != null && ds.Tables[0].Rows[0]["payable_amount"].ToString() != "")
                {
                    this.payable_amount = decimal.Parse(ds.Tables[0].Rows[0]["payable_amount"].ToString());
                }
                if (ds.Tables[0].Rows[0]["real_amount"] != null && ds.Tables[0].Rows[0]["real_amount"].ToString() != "")
                {
                    this.real_amount = decimal.Parse(ds.Tables[0].Rows[0]["real_amount"].ToString());
                }
                if (ds.Tables[0].Rows[0]["order_amount"] != null && ds.Tables[0].Rows[0]["order_amount"].ToString() != "")
                {
                    this.order_amount = decimal.Parse(ds.Tables[0].Rows[0]["order_amount"].ToString());
                }
                if (ds.Tables[0].Rows[0]["status"] != null && ds.Tables[0].Rows[0]["status"].ToString() != "")
                {
                    this.status = int.Parse(ds.Tables[0].Rows[0]["status"].ToString());
                }
                if (ds.Tables[0].Rows[0]["add_time"] != null && ds.Tables[0].Rows[0]["add_time"].ToString() != "")
                {
                    this.add_time = DateTime.Parse(ds.Tables[0].Rows[0]["add_time"].ToString());
                }
                if (ds.Tables[0].Rows[0]["confirm_time"] != null && ds.Tables[0].Rows[0]["confirm_time"].ToString() != "")
                {
                    this.confirm_time = DateTime.Parse(ds.Tables[0].Rows[0]["confirm_time"].ToString());
                }
                if (ds.Tables[0].Rows[0]["complete_time"] != null && ds.Tables[0].Rows[0]["complete_time"].ToString() != "")
                {
                    this.complete_time = DateTime.Parse(ds.Tables[0].Rows[0]["complete_time"].ToString());
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
			strSql.Append(" FROM [ps_orders] ");
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
            strSql.Append("select * FROM  ps_orders");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            recordCount = Convert.ToInt32(DbHelperSQL.GetSingle(PagingHelper.CreateCountingSql(strSql.ToString())));
            return DbHelperSQL.Query(PagingHelper.CreatePagingSql(recordCount, pageSize, pageIndex, strSql.ToString(), filedOrder));
        }

		#endregion  Method
	}


