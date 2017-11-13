using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;

/// <summary>
/// 在库信息-类
/// </summary>
[Serializable]
public partial class spotcheck_base
{
    public spotcheck_base()
    { }

    #region Model
    private long        _id;
    private int?        _spotcheck_department_id = 0;
    private string      _spotcheck_name = "";
    private string      _spotcheck_url = "";
    private string      _spotcheck_type = "";
    private string      _sub_department = "";
    private string      _position = "";
    private string      _checker = "";
    private DateTime?   _last_check_time = DateTime.Now;
    private int?        _check_interval = 0;
    private string      _status = "";
    private string      _status_detail = "";
    private string      _remark = "";

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
    public int? spotcheck_department_id
    {
        set { _spotcheck_department_id = value; }
        get { return _spotcheck_department_id; }
    }
    /// <summary>
    /// 点检点名称
    /// </summary>
    public string spotcheck_name
    {
        set { _spotcheck_name = value; }
        get { return _spotcheck_name; }
    }
    /// <summary>
    /// 点检点图片
    /// </summary>
    public string spotcheck_url
    {
        set { _spotcheck_url = value; }
        get { return _spotcheck_url; }
    }
    /// <summary>
    /// 点检点类型
    /// </summary>
    public string spotcheck_type
    {
        set { _spotcheck_type = value; }
        get { return _spotcheck_type; }
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
    /// 点检人
    /// </summary>
    public string checker
    {
        set { _checker = value; }
        get { return _checker; }
    }
    /// <summary>
    /// 入库时间
    /// </summary>
    public DateTime? last_check_time
    {
        set { _last_check_time = value; }
        get { return _last_check_time; }
    }
    /// <summary>
    /// 维护周期
    /// </summary>
    public int? check_interval
    {
        set { _check_interval = value; }
        get { return _check_interval; }
    }
    /// <summary>
    /// 状态详情
    /// </summary>
    public string status
    {
        set { _status = value; }
        get { return _status; }
    }     /// <summary>
    /// 状态详情
    /// </summary>
    public string status_detail
    {
        set { _status_detail = value; }
        get { return _status_detail; }
    } 
    /// <summary>
    /// <summary>
    /// 备注
    /// </summary>
    public string remark
    {
        set { _remark = value; }
        get { return _remark; }
    }

    #endregion Model

    #region  Method
    /// <summary>
    /// 得到最大ID
    /// </summary>
    public int GetMaxId(int spotcheck_department_id)
    {

        return DbHelperSQL.GetMaxID("id", "spotcheck_base where spotcheck_department_id=" + spotcheck_department_id);
    }
    /// <summary>
    /// 是否存在该记录
    /// </summary>
    public bool Exists()
    {
        StringBuilder strSql = new StringBuilder();
        strSql.Append("select count(1) from [spotcheck_base]");
        strSql.Append(" where id=@id ");

        SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.BigInt)};
        parameters[0].Value = id;

        return DbHelperSQL.Exists(strSql.ToString(), parameters);
    }
    /// <summary>
    /// 查询点检点名称是否存在
    /// </summary>
    public bool Exists(string spotcheck_name)
    {
        StringBuilder strSql = new StringBuilder();
        strSql.Append("select count(1) from  [spotcheck_base]");
        strSql.Append(" where spotcheck_name=@spotcheck_name and spotcheck_name<>'' ");
        SqlParameter[] parameters = {
					new SqlParameter("@spotcheck_name", SqlDbType.NVarChar,100)};
        parameters[0].Value = spotcheck_name;

        return DbHelperSQL.Exists(strSql.ToString(), parameters);
    }
    /// <summary>
    /// 通过id返回所属单位id
    /// </summary>
    public string GetTPid(int id)
    {
        StringBuilder strSql = new StringBuilder();
        strSql.Append("select top 1 spotcheck_department_id from [spotcheck_base]");
        strSql.Append(" where id=" + id);
        string title = Convert.ToString(DbHelperSQL.GetSingle(strSql.ToString()));
        if (string.IsNullOrEmpty(title))
        {
            return "";
        }
        return title;
    }
    /// <summary>
    /// 通过id返回点检点图片
    /// </summary>
    public string GetTPurl(int id)
    {
        StringBuilder strSql = new StringBuilder();
        strSql.Append("select top 1 spotcheck_url from [spotcheck_base]");
        strSql.Append(" where id=" + id);
        string title = Convert.ToString(DbHelperSQL.GetSingle(strSql.ToString()));
        if (string.IsNullOrEmpty(title))
        {
            return "";
        }
        return title;
    }
    /// <summary>
    /// 是否存在点检点所属单位id记录
    /// </summary>
    public bool ExistsBM()
    {
        StringBuilder strSql = new StringBuilder();
        strSql.Append("select count(1) from [spotcheck_base]");
        strSql.Append(" where spotcheck_department_id=@spotcheck_department_id ");

        SqlParameter[] parameters = {
					new SqlParameter("@spotcheck_department_id", SqlDbType.Int,4)};
        parameters[0].Value = spotcheck_department_id;

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
        strSql.Append("select top 1 count(id) as sumcode from [spotcheck_base]");
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
        strSql.Append("insert into [spotcheck_base] (");
        strSql.Append("(spotcheck_department_id,spotcheck_name,spotcheck_url,spotcheck_type,sub_department,position,checker,last_check_time,check_interval,status,status_detail,remark)");
        strSql.Append(" values (");
        strSql.Append("@spotcheck_department_id,@spotcheck_name,@spotcheck_url,@spotcheck_type,@sub_department,@position,@checker,@last_check_time,@check_interval,@status,@status_detail,@remark)");
        strSql.Append(";select @@IDENTITY");
        SqlParameter[] parameters = {
					new SqlParameter("@spotcheck_department_id", SqlDbType.Int,4),
           new SqlParameter("@spotcheck_name", SqlDbType.VarChar,200),
           new SqlParameter("@spotcheck_url", SqlDbType.VarChar,250),
           new SqlParameter("@spotcheck_type", SqlDbType.VarChar,100),
           new SqlParameter("@sub_department", SqlDbType.VarChar,50),
           new SqlParameter("@position", SqlDbType.VarChar,250),
           new SqlParameter("@checker", SqlDbType.VarChar,50),
           new SqlParameter("@last_check_time", SqlDbType.DateTime),
           new SqlParameter("@check_interval", SqlDbType.Int,4),
           new SqlParameter("@status", SqlDbType.VarChar,50),
           new SqlParameter("@status_detail", SqlDbType.NVarChar,500),
           new SqlParameter("@remark", SqlDbType.NVarChar,500)};
        parameters[0].Value = spotcheck_department_id;
        parameters[1].Value = spotcheck_name;
        parameters[2].Value = spotcheck_url;
        parameters[3].Value = spotcheck_type;
        parameters[4].Value = sub_department;
        parameters[5].Value = position;
        parameters[6].Value = checker;
        parameters[7].Value = last_check_time;
        parameters[8].Value = check_interval;
        parameters[9].Value = status;
        parameters[10].Value = status_detail;
        parameters[11].Value = remark;

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
        strSql.Append("update [spotcheck_base] set ");
        strSql.Append("spotcheck_department_id=@spotcheck_department_id,");
        strSql.Append("spotcheck_name=@spotcheck_name, ");
        strSql.Append("spotcheck_url=@spotcheck_url, ");
        strSql.Append("spotcheck_type=@spotcheck_type, ");
        strSql.Append("sub_department=@sub_department, ");
        strSql.Append("position=@position, ");
        strSql.Append("checker=@checker, ");
        strSql.Append("remark=@remark, ");
        strSql.Append("check_interval=@check_interval, ");
        strSql.Append(" where id=@id ");
        SqlParameter[] parameters = {
					new SqlParameter("@spotcheck_department_id", SqlDbType.Int,4),
           new SqlParameter("@spotcheck_name", SqlDbType.VarChar,200),
           new SqlParameter("@spotcheck_url", SqlDbType.VarChar,250),
           new SqlParameter("@spotcheck_type", SqlDbType.VarChar,100),
           new SqlParameter("@sub_department", SqlDbType.VarChar,50),
           new SqlParameter("@position", SqlDbType.VarChar,250),
           new SqlParameter("@checker", SqlDbType.VarChar,50),
           new SqlParameter("@remark", SqlDbType.NVarChar,500),
           new SqlParameter("@check_interval", SqlDbType.Int,4),
		    new SqlParameter("@id", SqlDbType.BigInt,8)};
        parameters[0].Value = spotcheck_department_id;
        parameters[1].Value = spotcheck_name;
        parameters[2].Value = spotcheck_url;
        parameters[3].Value = spotcheck_type;
        parameters[4].Value = sub_department;
        parameters[5].Value = position;
        parameters[6].Value = checker;
        parameters[7].Value = remark;
        parameters[8].Value = check_interval;
        parameters[9].Value = id;

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
        strSql.Append("delete from [spotcheck_base] ");
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
        strSql.Append("(spotcheck_department_id,spotcheck_name,spotcheck_url,spotcheck_type,sub_department,position,checker,last_check_time,check_interval,status,status_detail,remark)");
        strSql.Append(" FROM [spotcheck_base] ");
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
            if (ds.Tables[0].Rows[0]["spotcheck_department_id"] != null && ds.Tables[0].Rows[0]["spotcheck_department_id"].ToString() != "")
            {
                this.spotcheck_department_id = int.Parse(ds.Tables[0].Rows[0]["spotcheck_department_id"].ToString());
            }
            if (ds.Tables[0].Rows[0]["spotcheck_name"] != null)
            {
                this.spotcheck_name = ds.Tables[0].Rows[0]["spotcheck_name"].ToString();
            }
            if (ds.Tables[0].Rows[0]["spotcheck_url"] != null)
            {
                this.spotcheck_url = ds.Tables[0].Rows[0]["spotcheck_url"].ToString();
            }
            if (ds.Tables[0].Rows[0]["spotcheck_type"] != null)
            {
                this.spotcheck_type = ds.Tables[0].Rows[0]["spotcheck_type"].ToString();
            }
            if (ds.Tables[0].Rows[0]["sub_department"] != null)
            {
                this.sub_department = ds.Tables[0].Rows[0]["sub_department"].ToString();
            }
            if (ds.Tables[0].Rows[0]["position"] != null)
            {
                this.position = ds.Tables[0].Rows[0]["position"].ToString();
            }
            if (ds.Tables[0].Rows[0]["checker"] != null)
            {
                this.checker = ds.Tables[0].Rows[0]["checker"].ToString();
            }
            if (ds.Tables[0].Rows[0]["last_check_time"] != null && ds.Tables[0].Rows[0]["last_check_time"].ToString() != "")
            {
                this.last_check_time = DateTime.Parse(ds.Tables[0].Rows[0]["last_check_time"].ToString());
            }
            if (ds.Tables[0].Rows[0]["check_interval"] != null && ds.Tables[0].Rows[0]["check_interval"].ToString() != "")
            {
                this.check_interval = int.Parse(ds.Tables[0].Rows[0]["check_interval"].ToString());
            }
            if (ds.Tables[0].Rows[0]["status"] != null)
            {
                this.status = ds.Tables[0].Rows[0]["status"].ToString();
            }
            if (ds.Tables[0].Rows[0]["status_detail"] != null)
            {
                this.status_detail = ds.Tables[0].Rows[0]["status_detail"].ToString();
            }
            if (ds.Tables[0].Rows[0]["remark"] != null)
            {
                this.remark = ds.Tables[0].Rows[0]["remark"].ToString();
            }
         
        }
    }
    /// <summary>
    /// 更新设备总数量
    /// </summary>
    public bool UpdateStatus()
    {
        StringBuilder strSql = new StringBuilder();
        strSql.Append("update [spotcheck_base] set ");
        strSql.Append("status=@status");
        strSql.Append(" where id=@id ");
        SqlParameter[] parameters = {
					new SqlParameter("@status", SqlDbType.VarChar,50),
					new SqlParameter("@id", SqlDbType.BigInt,8)};
        parameters[0].Value = status;
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
        strSql.Append("update [spotcheck_base] set ");
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
    //    strSql.Append("update [spotcheck_base] set ");
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
        strSql.Append(" FROM [spotcheck_base] ");
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
        strSql.Append("select * FROM  spotcheck_base");
        if (strWhere.Trim() != "")
        {
            strSql.Append(" where " + strWhere);
        }
        recordCount = Convert.ToInt32(DbHelperSQL.GetSingle(PagingHelper.CreateCountingSql(strSql.ToString())));
        return DbHelperSQL.Query(PagingHelper.CreatePagingSql(recordCount, pageSize, pageIndex, strSql.ToString(), filedOrder));
    }

    #endregion  Method
}


