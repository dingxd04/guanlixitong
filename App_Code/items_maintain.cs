using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;

/// <summary>
/// 在库信息-类
/// </summary>
[Serializable]
public partial class items_maintain
{
    public items_maintain()
    { }

    #region Model
    private long        _id;
    private long 		_base_id = 0;
    private string 		_position="";
    private string 		_recorder="";
    private DateTime?	_date_time=DateTime.Now;
    private int? 		_status =0;
    private string 		_details ="";
    private int? 		_is_using=0;
    private string 		_remark ="";
    
    /// <summary>
    /// 在库信息
    /// </summary>
    public long id
    {
        set { _id = value; }
        get { return _id; }
    }
    /// <summary>
    /// 装备编号
    /// </summary>
    public long base_id
    {
        set { _base_id = value; }
        get { return _base_id; }
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
    /// 维护人
    /// </summary>
    public string recorder
    {
        set { _recorder = value; }
        get { return _recorder; }
    }
    /// <summary>
    /// 维护时间
    /// </summary>
    public DateTime? date_time
    {
        set { _date_time = value; }
        get { return _date_time; }
    }
    /// <summary>
    /// 状态代码
    /// </summary>
    public int? status
    {
        set { _status = value; }
        get { return _status; }
    }
    /// <summary>
    /// 状态详情
    /// </summary>
    public string details
    {
        set { _details = value; }
        get { return _details; }
    }
    /// <summary>
    /// 是否正在使用
    /// </summary>
    public int? is_using
    {
        set { _is_using = value; }
        get { return _is_using; }
    }
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
    public int GetMaxId(int userid)
    {

        return DbHelperSQL.GetMaxID("id", "items_maintain where status=" + userid);
    }
    /// <summary>
    /// 是否存在该记录
    /// </summary>
    public bool Exists()
    {
        StringBuilder strSql = new StringBuilder();
        strSql.Append("select count(1) from [items_maintain]");
        strSql.Append(" where id=@id ");

        SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.BigInt)};
        parameters[0].Value = id;

        return DbHelperSQL.Exists(strSql.ToString(), parameters);
    }
    /// <summary>
    /// 查询对应装备编号下是否有维护记录
    /// </summary>
    public bool Exists(long base_id)
    {
        StringBuilder strSql = new StringBuilder();
        strSql.Append("select count(1) from  [items_maintain]");
        strSql.Append(" where base_id=@base_id and base_id>0 ");
        SqlParameter[] parameters = {
					new SqlParameter("@base_id", SqlDbType.Int,4)};
        parameters[0].Value = base_id;

        return DbHelperSQL.Exists(strSql.ToString(), parameters);
    }
    /// <summary>
    /// 通过id返回所属装备编号
    /// </summary>
    public string GetTPid(int id)
    {
        StringBuilder strSql = new StringBuilder();
        strSql.Append("select top 1 base_id from [items_maintain]");
        strSql.Append(" where id=" + id);
        string title = Convert.ToString(DbHelperSQL.GetSingle(strSql.ToString()));
        if (string.IsNullOrEmpty(title))
        {
            return "";
        }
        return title;
    }
    /// <summary>
    /// 通过id返回装备位置
    /// </summary>
    public string GetPosition(int id)
    {
        StringBuilder strSql = new StringBuilder();
        strSql.Append("select top 1 position from [items_maintain]");
        strSql.Append(" where id=" + id);
        string position_ = Convert.ToString(DbHelperSQL.GetSingle(strSql.ToString()));
        if (string.IsNullOrEmpty(position_))
        {
            return "";
        }
        return position_;
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
        strSql.Append("select top 1 count(id) as sumcode from [items_maintain]");
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
        strSql.Append("insert into [items_maintain] (");
        strSql.Append("(base_id ,position,recorder,date_time,status ,details ,is_using,remark)");
        strSql.Append(" values (");
        strSql.Append("@base_id ,@position,@recorder,@date_time,@status ,@details ,@is_using,@remark )");
        strSql.Append(";select @@IDENTITY");
        SqlParameter[] parameters = {
					new SqlParameter("@base_id", SqlDbType.Int,4),
           new SqlParameter("@position", SqlDbType.VarChar,250),
           new SqlParameter("@recorder", SqlDbType.VarChar,50),
           new SqlParameter("@date_time", SqlDbType.DateTime),
           new SqlParameter("@status", SqlDbType.Int,4),
           new SqlParameter("@details", SqlDbType.NVarChar,500),
           new SqlParameter("@is_using", SqlDbType.Int,4),
           new SqlParameter("@remark", SqlDbType.NVarChar,500)};
        parameters[0].Value = base_id;
        parameters[6].Value = position;
        parameters[4].Value = recorder;
        parameters[9].Value = date_time;
        parameters[10].Value = status;
        parameters[11].Value = details;
        parameters[12].Value = is_using;
        parameters[8].Value = remark;

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
        strSql.Append("update [items_maintain] set ");
        strSql.Append("base_id=@base_id,");
        strSql.Append("position=@position, ");
        strSql.Append("recorder=@recorder, ");
        strSql.Append("date_time=@date_time, ");
        strSql.Append("status=@status, ");
        strSql.Append("details=@details, ");
        strSql.Append("is_using=@is_using, ");
        strSql.Append("remark=@remark, ");
        strSql.Append(" where id=@id ");
        SqlParameter[] parameters = {
					new SqlParameter("@base_id", SqlDbType.Int,4),
           new SqlParameter("@position", SqlDbType.VarChar,250),
           new SqlParameter("@recorder", SqlDbType.VarChar,50),
           new SqlParameter("@date_time", SqlDbType.DateTime),
           new SqlParameter("@status", SqlDbType.Int,4),
           new SqlParameter("@details", SqlDbType.NVarChar,500),
           new SqlParameter("@is_using", SqlDbType.Int,4),
           new SqlParameter("@remark", SqlDbType.NVarChar,500),
					new SqlParameter("@id", SqlDbType.BigInt,8)};
        parameters[0].Value = base_id;
        parameters[1].Value = position;
        parameters[2].Value = recorder;
        parameters[3].Value = date_time;
        parameters[4].Value = status ;
        parameters[5].Value = details ;
        parameters[6].Value = is_using;
        parameters[7].Value = remark ;
        parameters[8].Value = id;

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
        strSql.Append("delete from [items_maintain] ");
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
        strSql.Append("(base_id ,position,recorder,date_time,status ,details ,is_using,remark)");
        strSql.Append(" FROM [items_maintain] ");
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
            if (ds.Tables[0].Rows[0]["base_id"] != null && ds.Tables[0].Rows[0]["base_id"].ToString() != "")
            {
                this.base_id = long.Parse(ds.Tables[0].Rows[0]["base_id"].ToString());
            }
            if (ds.Tables[0].Rows[0]["position"] != null)
            {
                this.position = ds.Tables[0].Rows[0]["position"].ToString();
            }
            if (ds.Tables[0].Rows[0]["recorder"] != null)
            {
                this.recorder = ds.Tables[0].Rows[0]["recorder"].ToString();
            }
            if (ds.Tables[0].Rows[0]["date_time"] != null && ds.Tables[0].Rows[0]["date_time"].ToString() != "")
            {
                this.date_time = DateTime.Parse(ds.Tables[0].Rows[0]["date_time"].ToString());
            }
            if (ds.Tables[0].Rows[0]["status"] != null && ds.Tables[0].Rows[0]["status"].ToString() != "")
            {
                this.status = int.Parse(ds.Tables[0].Rows[0]["status"].ToString());
            }
            if (ds.Tables[0].Rows[0]["details"] != null) 
            {
                this.details = ds.Tables[0].Rows[0]["details"].ToString();
            }
            if (ds.Tables[0].Rows[0]["is_using"] != null && ds.Tables[0].Rows[0]["is_using"].ToString() != "")
            {
                this.is_using = int.Parse(ds.Tables[0].Rows[0]["is_using"].ToString());
            }
              if (ds.Tables[0].Rows[0]["remark"] != null)
            {
                this.remark = ds.Tables[0].Rows[0]["remark"].ToString();
            }
        }
    }
    /// <summary>
    /// 更新设备是否正在使用
    /// </summary>
    public bool UpdateIsUsing()
    {
        StringBuilder strSql = new StringBuilder();
        strSql.Append("update [items_maintain] set ");
        strSql.Append("is_using=@is_using");
        strSql.Append(" where id=@id ");
        SqlParameter[] parameters = {
					new SqlParameter("@is_using", SqlDbType.TinyInt,1),
					new SqlParameter("@id", SqlDbType.BigInt,8)};
        parameters[0].Value = is_using;
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
        strSql.Append("update [items_maintain] set ");
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
        strSql.Append(" FROM [items_maintain] ");
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
        strSql.Append("select * FROM  items_maintain");
        if (strWhere.Trim() != "")
        {
            strSql.Append(" where " + strWhere);
        }
        recordCount = Convert.ToInt32(DbHelperSQL.GetSingle(PagingHelper.CreateCountingSql(strSql.ToString())));
        return DbHelperSQL.Query(PagingHelper.CreatePagingSql(recordCount, pageSize, pageIndex, strSql.ToString(), filedOrder));
    }

    #endregion  Method
}


