using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;

/// <summary>
/// 在库信息-类
/// </summary>
[Serializable]
public partial class items_base
{
    public items_base()
    { }

    #region Model
    private long _id;
    private int? _items_department_id = 0;
    private string _items_name = "";
    private string _items_url = "";
    private string _items_type = "";
    private string _manufacturer = "";
    private string _sub_department = "";
    private string _position = "";
    private string _keeper = "";
    private string _remark = "";
    private DateTime? _last_test_time = DateTime.Now;
    private int? _test_interval = 0;
    private string _status_detail = "";
    private int? _items_total = 0;
    private int? _items_using_num = 0;
    private int? _items_well_num = 0;
    private int? _items_repair_num = 0;
    private int? _items_bad_num = 0;
    private int? _is_xs = 0;
    /// <summary>
    /// 在库信息
    /// </summary>
    public long id
    {
        set { _id = value; }
        get { return _id; }
    }
    /// <summary>
    /// 所属单位
    /// </summary>
    public int? items_department_id
    {
        set { _items_department_id = value; }
        get { return _items_department_id; }
    }
    /// <summary>
    /// 装备名称
    /// </summary>
    public string items_name
    {
        set { _items_name = value; }
        get { return _items_name; }
    }
    /// <summary>
    /// 装备图片
    /// </summary>
    public string items_url
    {
        set { _items_url = value; }
        get { return _items_url; }
    }
    /// <summary>
    /// 装备类型
    /// </summary>
    public string items_type
    {
        set { _items_type = value; }
        get { return _items_type; }
    }
    /// <summary>
    /// 生产厂商
    /// </summary>
    public string manufacturer
    {
        set { _manufacturer = value; }
        get { return _manufacturer; }
    }
    /// <summary>
    /// 所属子系统
    /// </summary>
    public string sub_department
    {
        set { _sub_department = value; }
        get { return _sub_department; }
    }
    /// <summary>
    /// 存放位置
    /// </summary>
    public string position
    {
        set { _position = value; }
        get { return _position; }
    }
    /// <summary>
    /// 保管人
    /// </summary>
    public string keeper
    {
        set { _keeper = value; }
        get { return _keeper; }
    }
    /// <summary>
    /// 备注
    /// </summary>
    public string remark
    {
        set { _remark = value; }
        get { return _remark; }
    }
    /// <summary>
    /// 入库时间
    /// </summary>
    public DateTime? last_test_time
    {
        set { _last_test_time = value; }
        get { return _last_test_time; }
    }
    /// <summary>
    /// 维护周期
    /// </summary>
    public int? test_interval
    {
        set { _test_interval = value; }
        get { return _test_interval; }
    }
    /// <summary>
    /// 状态详情
    /// </summary>
    public string status_detail
    {
        set { _status_detail = value; }
        get { return _status_detail; }
    } /// <summary>
    /// 当前数量
    /// </summary>
    public int? items_total
    {
        set { _items_total = value; }
        get { return _items_total; }
    }
    /// 在用数量
    /// </summary>
    public int? items_using_num
    {
        set { _items_using_num = value; }
        get { return _items_using_num; }
    }
    /// 可用备件数量
    /// </summary>
    public int? items_well_num
    {
        set { _items_well_num = value; }
        get { return _items_well_num; }
    }
    /// 维修中数量
    /// </summary>
    public int? items_repair_num
    {
        set { _items_repair_num = value; }
        get { return _items_repair_num; }
    }
    /// 故障数量
    /// </summary>
    public int? items_bad_num
    {
        set { _items_bad_num = value; }
        get { return _items_bad_num; }
    }
    /// <summary>
    /// 预留
    /// </summary>
    public int? is_xs
    {
        set { _is_xs = value; }
        get { return _is_xs; }
    }
    #endregion Model

    #region  Method
    /// <summary>
    /// 得到最大ID
    /// </summary>
    public int GetMaxId(int items_department_id)
    {

        return DbHelperSQL.GetMaxID("id", "items_base where items_department_id=" + items_department_id);
    }
    /// <summary>
    /// 是否存在该记录
    /// </summary>
    public bool Exists()
    {
        StringBuilder strSql = new StringBuilder();
        strSql.Append("select count(1) from [items_base]");
        strSql.Append(" where id=@id ");

        SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.BigInt)};
        parameters[0].Value = id;

        return DbHelperSQL.Exists(strSql.ToString(), parameters);
    }
    /// <summary>
    /// 查询装备名称是否存在
    /// </summary>
    public bool Exists(string items_name)
    {
        StringBuilder strSql = new StringBuilder();
        strSql.Append("select count(1) from  [items_base]");
        strSql.Append(" where items_name=@items_name and items_name<>'' ");
        SqlParameter[] parameters = {
					new SqlParameter("@items_name", SqlDbType.NVarChar,100)};
        parameters[0].Value = items_name;

        return DbHelperSQL.Exists(strSql.ToString(), parameters);
    }
    /// <summary>
    /// 通过id返回所属单位id
    /// </summary>
    public string GetTPid(int id)
    {
        StringBuilder strSql = new StringBuilder();
        strSql.Append("select top 1 items_department_id from [items_base]");
        strSql.Append(" where id=" + id);
        string title = Convert.ToString(DbHelperSQL.GetSingle(strSql.ToString()));
        if (string.IsNullOrEmpty(title))
        {
            return "";
        }
        return title;
    }
    /// <summary>
    /// 通过id返回装备图片
    /// </summary>
    public string GetTPurl(int id)
    {
        StringBuilder strSql = new StringBuilder();
        strSql.Append("select top 1 items_url from [items_base]");
        strSql.Append(" where id=" + id);
        string title = Convert.ToString(DbHelperSQL.GetSingle(strSql.ToString()));
        if (string.IsNullOrEmpty(title))
        {
            return "";
        }
        return title;
    }
    /// <summary>
    /// 是否存在装备所属单位id记录
    /// </summary>
    public bool ExistsBM()
    {
        StringBuilder strSql = new StringBuilder();
        strSql.Append("select count(1) from [items_base]");
        strSql.Append(" where items_department_id=@items_department_id ");

        SqlParameter[] parameters = {
					new SqlParameter("@items_department_id", SqlDbType.Int,4)};
        parameters[0].Value = items_department_id;

        return DbHelperSQL.Exists(strSql.ToString(), parameters);
    }
    /// <summary>
    /// 返回sql查询结果
    /// </summary>
    public string Getsql(string sqlstr)
    {
        StringBuilder strSql = new StringBuilder();
        strSql.Append(sqlstr);
        string title = Convert.ToString(DbHelperSQL.GetSingle(strSql.ToString()));
        if (string.IsNullOrEmpty(title))
        {
            return "0";
        }
        return title;
    }

    /// <summary>
    /// 根据条件汇总
    /// </summary>
    public string GetwhereSum(string strWhere)
    {
        StringBuilder strSql = new StringBuilder();
        strSql.Append("select top 1 count(id) as sumcode from [items_base]");
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
        strSql.Append("insert into [items_base] (");
        strSql.Append("(items_department_id,items_name,items_url,items_type,manufacturer,sub_department,position,keeper,remark,last_test_time,test_interval,status_detail,items_total,items_using_num,items_well_num,items_repair_num,items_bad_num,is_xs)");
        strSql.Append(" values (");
        strSql.Append("@items_department_id,@items_name,@items_url,@items_type,@manufacturer,@sub_department,@position,@keeper,@remark,@last_test_time,@test_interval,@status_detail,@items_total,@items_using_num,@items_well_num,@items_repair_num,@items_bad_num,@is_xs)");
        strSql.Append(";select @@IDENTITY");
        SqlParameter[] parameters = {
					new SqlParameter("@items_department_id", SqlDbType.Int,4),
           new SqlParameter("@items_name", SqlDbType.VarChar,200),
           new SqlParameter("@items_url", SqlDbType.VarChar,250),
           new SqlParameter("@items_type", SqlDbType.VarChar,100),
           new SqlParameter("@manufacturer", SqlDbType.VarChar,100),
           new SqlParameter("@sub_department", SqlDbType.VarChar,50),
           new SqlParameter("@position", SqlDbType.VarChar,250),
           new SqlParameter("@keeper", SqlDbType.VarChar,50),
           new SqlParameter("@remark", SqlDbType.NVarChar,500),
           new SqlParameter("@last_test_time", SqlDbType.DateTime),
           new SqlParameter("@test_interval", SqlDbType.Int,4),
           new SqlParameter("@status_detail", SqlDbType.VarChar,100),
           new SqlParameter("@items_total", SqlDbType.Int,4),
           new SqlParameter("@items_using_num", SqlDbType.Int,4),
           new SqlParameter("@items_well_num", SqlDbType.Int,4),
           new SqlParameter("@items_repair_num", SqlDbType.Int,4),
           new SqlParameter("@items_bad_num", SqlDbType.Int,4),
           new SqlParameter("@is_xs", SqlDbType.Int,4)};
        parameters[0].Value = items_department_id;
        parameters[1].Value = items_name;
        parameters[2].Value = items_url;
        parameters[3].Value = items_type;
        parameters[4].Value = manufacturer;
        parameters[5].Value = sub_department;
        parameters[6].Value = position;
        parameters[7].Value = keeper;
        parameters[8].Value = remark;
        parameters[9].Value = last_test_time;
        parameters[10].Value = test_interval;
        parameters[11].Value = status_detail;
        parameters[12].Value = items_total;
        parameters[13].Value = items_using_num;
        parameters[14].Value = items_well_num;
        parameters[15].Value = items_repair_num;
        parameters[16].Value = items_bad_num;
        parameters[17].Value = is_xs;

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
    public bool UpdateALL()
    {
        StringBuilder strSql = new StringBuilder();
        strSql.Append("update [items_base] set ");
        strSql.Append("items_department_id=@items_department_id,");
        strSql.Append("items_name=@items_name, ");
        strSql.Append("items_url=@items_url, ");
        strSql.Append("items_type=@items_type, ");
        strSql.Append("manufacturer=@manufacturer, ");
        strSql.Append("sub_department=@sub_department, ");
        strSql.Append("position=@position, ");
        strSql.Append("keeper=@keeper, ");
        strSql.Append("remark=@remark, ");
        strSql.Append("test_interval=@test_interval, ");
        strSql.Append("items_total=@items_total, ");
        strSql.Append("is_xs=@is_xs, ");
        strSql.Append(" where id=@id ");
        SqlParameter[] parameters = {
					new SqlParameter("@items_department_id", SqlDbType.Int,4),
           new SqlParameter("@items_name", SqlDbType.VarChar,200),
           new SqlParameter("@items_url", SqlDbType.VarChar,250),
           new SqlParameter("@items_type", SqlDbType.VarChar,100),
           new SqlParameter("@manufacturer", SqlDbType.VarChar,100),
           new SqlParameter("@sub_department", SqlDbType.VarChar,50),
           new SqlParameter("@position", SqlDbType.VarChar,250),
           new SqlParameter("@keeper", SqlDbType.VarChar,50),
           new SqlParameter("@remark", SqlDbType.NVarChar,500),
           new SqlParameter("@test_interval", SqlDbType.Int,4),
           new SqlParameter("@items_total", SqlDbType.Int,4),
           new SqlParameter("@is_xs", SqlDbType.Int,4),
					new SqlParameter("@id", SqlDbType.BigInt,8)};
        parameters[0].Value = items_department_id;
        parameters[1].Value = items_name;
        parameters[2].Value = items_url;
        parameters[3].Value = items_type;
        parameters[4].Value = manufacturer;
        parameters[5].Value = sub_department;
        parameters[6].Value = position;
        parameters[7].Value = keeper;
        parameters[8].Value = remark;
        parameters[9].Value = test_interval;
        parameters[10].Value = items_total;
        parameters[11].Value = is_xs;
        parameters[12].Value = id;

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
        strSql.Append("delete from [items_base] ");
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

    /// 得到一个对象实体
    /// </summary>
    public void GetModel(long id)
    {
        StringBuilder strSql = new StringBuilder();
        strSql.Append("(items_department_id,items_name,items_url,items_type,manufacturer,sub_department,position,keeper,remark,last_test_time,test_interval,status_detail,items_total,items_using_num,items_well_num,items_repair_num,items_bad_num,is_xs)");
        strSql.Append(" FROM [items_base] ");
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
            if (ds.Tables[0].Rows[0]["items_department_id"] != null && ds.Tables[0].Rows[0]["items_department_id"].ToString() != "")
            {
                this.items_department_id = int.Parse(ds.Tables[0].Rows[0]["items_department_id"].ToString());
            }
            if (ds.Tables[0].Rows[0]["items_name"] != null)
            {
                this.items_name = ds.Tables[0].Rows[0]["items_name"].ToString();
            }
            if (ds.Tables[0].Rows[0]["items_url"] != null)
            {
                this.items_url = ds.Tables[0].Rows[0]["items_url"].ToString();
            }
            if (ds.Tables[0].Rows[0]["items_type"] != null)
            {
                this.items_type = ds.Tables[0].Rows[0]["items_type"].ToString();
            }
            if (ds.Tables[0].Rows[0]["manufacturer"] != null)
            {
                this.manufacturer = ds.Tables[0].Rows[0]["manufacturer"].ToString();
            }
            if (ds.Tables[0].Rows[0]["sub_department"] != null)
            {
                this.sub_department = ds.Tables[0].Rows[0]["sub_department"].ToString();
            }
            if (ds.Tables[0].Rows[0]["position"] != null)
            {
                this.position = ds.Tables[0].Rows[0]["position"].ToString();
            }
            if (ds.Tables[0].Rows[0]["keeper"] != null)
            {
                this.keeper = ds.Tables[0].Rows[0]["keeper"].ToString();
            }
            if (ds.Tables[0].Rows[0]["remark"] != null)
            {
                this.remark = ds.Tables[0].Rows[0]["remark"].ToString();
            }
            if (ds.Tables[0].Rows[0]["last_test_time"] != null && ds.Tables[0].Rows[0]["last_test_time"].ToString() != "")
            {
                this.last_test_time = DateTime.Parse(ds.Tables[0].Rows[0]["last_test_time"].ToString());
            }
            if (ds.Tables[0].Rows[0]["test_interval"] != null && ds.Tables[0].Rows[0]["test_interval"].ToString() != "")
            {
                this.test_interval = int.Parse(ds.Tables[0].Rows[0]["test_interval"].ToString());
            }
            if (ds.Tables[0].Rows[0]["status_detail"] != null)
            {
                this.status_detail = ds.Tables[0].Rows[0]["status_detail"].ToString();
            }
            if (ds.Tables[0].Rows[0]["items_total"] != null && ds.Tables[0].Rows[0]["items_total"].ToString() != "")
            {
                this.items_total = int.Parse(ds.Tables[0].Rows[0]["items_total"].ToString());
            }
            if (ds.Tables[0].Rows[0]["items_using_num"] != null && ds.Tables[0].Rows[0]["items_using_num"].ToString() != "")
            {
                this.items_using_num = int.Parse(ds.Tables[0].Rows[0]["items_using_num"].ToString());
            }
            if (ds.Tables[0].Rows[0]["items_well_num"] != null && ds.Tables[0].Rows[0]["items_well_num"].ToString() != "")
            {
                this.items_well_num = int.Parse(ds.Tables[0].Rows[0]["items_well_num"].ToString());
            }
            if (ds.Tables[0].Rows[0]["items_repair_num"] != null && ds.Tables[0].Rows[0]["items_repair_num"].ToString() != "")
            {
                this.items_repair_num = int.Parse(ds.Tables[0].Rows[0]["items_repair_num"].ToString());
            }
            if (ds.Tables[0].Rows[0]["items_bad_num"] != null && ds.Tables[0].Rows[0]["items_bad_num"].ToString() != "")
            {
                this.items_bad_num = int.Parse(ds.Tables[0].Rows[0]["items_bad_num"].ToString());
            }
            if (ds.Tables[0].Rows[0]["is_xs"] != null && ds.Tables[0].Rows[0]["is_xs"].ToString() != "")
            {
                this.is_xs = int.Parse(ds.Tables[0].Rows[0]["is_xs"].ToString());
            }
        }
    }
    /// <summary>
    /// 更新设备总数量
    /// </summary>
    public bool UpdateTotal()
    {
        StringBuilder strSql = new StringBuilder();
        strSql.Append("update [items_base] set ");
        strSql.Append("items_total=@items_total");
        strSql.Append(" where id=@id ");
        SqlParameter[] parameters = {
					new SqlParameter("@items_total", SqlDbType.TinyInt,1),
					new SqlParameter("@id", SqlDbType.BigInt,8)};
        parameters[0].Value = items_total;
        parameters[1].Value = id;

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
    /// 更新存放位置
    /// </summary>
    public bool UpdatePosition()
    {
        StringBuilder strSql = new StringBuilder();
        strSql.Append("update [items_base] set ");
        strSql.Append("position=@position");
        strSql.Append(" where id=@id ");
        SqlParameter[] parameters = {
					new SqlParameter("@position", SqlDbType.VarChar,250),
					new SqlParameter("@id", SqlDbType.BigInt,8)};
        parameters[0].Value = position;
        parameters[1].Value = id;

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

    ///// <summary>
    ///// 更新入库价格和销售价格
    ///// </summary>
    //public bool Update()
    //{
    //    StringBuilder strSql = new StringBuilder();
    //    strSql.Append("update [items_base] set ");
    //    strSql.Append("go_price=@go_price,");
    //    strSql.Append("salse_price=@salse_price");
    //    strSql.Append(" where id=@id ");
    //    SqlParameter[] parameters = {
    //                new SqlParameter("@go_price", SqlDbType.Decimal,9),
    //                new SqlParameter("@salse_price", SqlDbType.Decimal,9),
    //                new SqlParameter("@id", SqlDbType.BigInt,8)};

    //    parameters[0].Value = go_price;
    //    parameters[1].Value = salse_price;
    //    parameters[2].Value = id;

    //    int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
    //    if (rows > 0)
    //    {
    //        return true;
    //    }
    //    else
    //    {
    //        return false;
    //    }
    //}


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
        StringBuilder strSql = new StringBuilder();
        strSql.Append("select * ");
        strSql.Append(" FROM [items_base] ");
        if (strWhere.Trim() != "")
        {
            strSql.Append(" where " + strWhere);
        }
        return DbHelperSQL.Query(strSql.ToString());
    }
    /// <summary>
    /// 获得查询分页数据
    /// </summary>
    public DataSet GetList(int pageSize, int pageIndex, string strWhere, string filedOrder, out int recordCount)
    {
        StringBuilder strSql = new StringBuilder();
        strSql.Append("select * FROM  items_base");
        if (strWhere.Trim() != "")
        {
            strSql.Append(" where " + strWhere);
        }
        recordCount = Convert.ToInt32(DbHelperSQL.GetSingle(PagingHelper.CreateCountingSql(strSql.ToString())));
        return DbHelperSQL.Query(PagingHelper.CreatePagingSql(recordCount, pageSize, pageIndex, strSql.ToString(), filedOrder));
    }

    #endregion  Method
}


