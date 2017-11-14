using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;

/// <summary>
/// 在库信息-类
/// </summary>
[Serializable]
public partial class spotcheck_info
{
    public spotcheck_info()
    { }

    #region Model
    private long        _id;
    private long 		_base_id = 0;
    private string 		_position="";
    private string 		_recorder="";
    private DateTime? _date_time = DateTime.Now;
    private string _status = "";
    private string _status_detail = "";
    private string _starndard1 ="";
    private string _record1_name ="";
    private float _record1_value = 0;
    private string _starndard2 ="";
    private string _record2_name ="";
    private float _record2_value = 0;
    private string _starndard3 ="";
    private string _record3_name ="";
    private float  _record3_value=0;
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
    /// 点检点编号
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
    /// 状态
    /// </summary>
    public string status
    {
        set { _status = value; }
        get { return _status; }
    }
    /// <summary>
    /// 状态详情
    /// </summary>
    public string status_detail
    {
        set { _status_detail = value; }
        get { return _status_detail; }
    }
  
    /// <summary>
    /// 指标1要求
    /// </summary>
    public string starndard1
    {
        set { _starndard1 = value; }
        get { return _starndard1; }
    }
    /// <summary>
    ///指标1名称
    /// </summary>
    public string record1_name
    {
        set { _record1_name = value; }
        get { return _record1_name; }
    }
    /// <summary>
    /// 指标1数值
    /// </summary>
    public float record1_value
    {
        set { _record1_value = value; }
        get { return _record1_value; }
    }   
    /// <summary>
    /// 指标2要求
    /// </summary>
    public string starndard2
    {
        set { _starndard2 = value; }
        get { return _starndard2; }
    }
    /// <summary>
    ///指标2名称
    /// </summary>
    public string record2_name
    {
        set { _record2_name = value; }
        get { return _record2_name; }
    }
    /// <summary>
    /// 指标2数值
    /// </summary>
    public float record2_value
    {
        set { _record2_value = value; }
        get { return _record2_value; }
    }   
    /// <summary>
    /// 指标3要求
    /// </summary>
    public string starndard3
    {
        set { _starndard3 = value; }
        get { return _starndard3; }
    }
    /// <summary>
    ///指标3名称
    /// </summary>
    public string record3_name
    {
        set { _record3_name = value; }
        get { return _record3_name; }
    }
    /// <summary>
    /// 指标3数值
    /// </summary>
    public float record3_value
    {
        set { _record3_value = value; }
        get { return _record3_value; }
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
    public long GetMaxId(long base_id)
    {

        return DbHelperSQL.GetMaxID("id", "spotcheck_info where base_id=" + base_id);
    }
    /// <summary>
    /// 是否存在该记录
    /// </summary>
    public bool Exists()
    {
        StringBuilder strSql = new StringBuilder();
        strSql.Append("select count(1) from [spotcheck_info]");
        strSql.Append(" where id=@id ");

        SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.BigInt)};
        parameters[0].Value = id;

        return DbHelperSQL.Exists(strSql.ToString(), parameters);
    }
    /// <summary>
    /// 查询对应点检点编号下是否有维护记录
    /// </summary>
    public bool Exists(long base_id)
    {
        StringBuilder strSql = new StringBuilder();
        strSql.Append("select count(1) from  [spotcheck_info]");
        strSql.Append(" where base_id=@base_id and base_id>0 ");
        SqlParameter[] parameters = {
					new SqlParameter("@base_id", SqlDbType.Int,4)};
        parameters[0].Value = base_id;

        return DbHelperSQL.Exists(strSql.ToString(), parameters);
    }
    /// <summary>
    /// 通过id返回所属点检点编号
    /// </summary>
    public string GetTPid(int id)
    {
        StringBuilder strSql = new StringBuilder();
        strSql.Append("select top 1 base_id from [spotcheck_info]");
        strSql.Append(" where id=" + id);
        string title = Convert.ToString(DbHelperSQL.GetSingle(strSql.ToString()));
        if (string.IsNullOrEmpty(title))
        {
            return "";
        }
        return title;
    }
    /// <summary>
    /// 通过id返回点检点位置
    /// </summary>
    public string GetPosition(int id)
    {
        StringBuilder strSql = new StringBuilder();
        strSql.Append("select top 1 position from [spotcheck_info]");
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
        strSql.Append("select top 1 count(id) as sumcode from [spotcheck_info]");
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
        strSql.Append("insert into [spotcheck_info] (");
        strSql.Append("(base_id,position,recorder,date_time,status,status_detail,starndard1,record1_name,record1_value,starndard2,record2_name,record2_value,starndard3,record3_name,record3_value,remark)");
        strSql.Append(" values (");
        strSql.Append("@base_id,position,@recorder,@date_time,@status,@status_detail,@starndard1,@record1_name,@record1_value,@starndard2,@record2_name,@record2_value,@starndard3,@record3_name,@record3_value,@remark )");
        strSql.Append(";select @@IDENTITY");
        SqlParameter[] parameters = {
					new SqlParameter("@base_id", SqlDbType.Int,4),
           new SqlParameter("@position", SqlDbType.VarChar,250),
           new SqlParameter("@recorder", SqlDbType.VarChar,50),
           new SqlParameter("@date_time", SqlDbType.DateTime),
           new SqlParameter("@status", SqlDbType.VarChar,50),
           new SqlParameter("@status_detail", SqlDbType.NVarChar,500),
           new SqlParameter("@starndard1", SqlDbType.VarChar,50),
           new SqlParameter("@record1_name", SqlDbType.NVarChar,500),
           new SqlParameter("@record1_value", SqlDbType.Decimal,4),
           new SqlParameter("@starndard2", SqlDbType.VarChar,50),
           new SqlParameter("@record2_name", SqlDbType.NVarChar,500),
           new SqlParameter("@record2_value", SqlDbType.Decimal,4),
           new SqlParameter("@starndard3", SqlDbType.VarChar,50),
           new SqlParameter("@record3_name", SqlDbType.NVarChar,500),
           new SqlParameter("@record3_value", SqlDbType.Decimal,4),
           new SqlParameter("@is_using", SqlDbType.Int,4),
           new SqlParameter("@remark", SqlDbType.NVarChar,500)};
        parameters[0].Value = base_id;
        parameters[1].Value = position;
        parameters[2].Value = recorder;
        parameters[3].Value = date_time;
        parameters[4].Value = status;
        parameters[5].Value = status_detail;
        parameters[6].Value = starndard1;
        parameters[7].Value = record1_name;
        parameters[8].Value = record1_value;
        parameters[9].Value = starndard2;
        parameters[10].Value = record2_name;
        parameters[11].Value = record2_value;
        parameters[12].Value = starndard3;
        parameters[13].Value = record3_name;
        parameters[14].Value = record3_value;
        parameters[15].Value = is_using;
        parameters[16].Value = remark;

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
        strSql.Append("update [spotcheck_info] set ");
        strSql.Append("base_id=@base_id,");
        strSql.Append("position=@position, ");
        strSql.Append("recorder=@recorder, ");
        strSql.Append("date_time=@date_time, ");
        strSql.Append("status=@status, ");
        strSql.Append("status_detail=@status_detail, ");
        strSql.Append("starndard1=@starndard1, ");
        strSql.Append("record1_name=@record1_name, ");
        strSql.Append("record1_value=@record1_value, ");
        strSql.Append("starndard2=@starndard2, ");
        strSql.Append("record2_name=@record2_name, ");
        strSql.Append("record2_value=@record2_value, ");
        strSql.Append("starndard3=@starndard3, ");
        strSql.Append("record3_name=@record3_name, ");
        strSql.Append("record3_value=@record3_value, ");
        strSql.Append("is_using=@is_using, ");
        strSql.Append("remark=@remark, ");
        strSql.Append(" where id=@id ");
        SqlParameter[] parameters = {
					new SqlParameter("@base_id", SqlDbType.Int,4),
           new SqlParameter("@position", SqlDbType.VarChar,250),
           new SqlParameter("@recorder", SqlDbType.VarChar,50),
           new SqlParameter("@date_time", SqlDbType.DateTime),
           new SqlParameter("@status", SqlDbType.Int,4),
           new SqlParameter("@status_detail", SqlDbType.NVarChar,500),  
           new SqlParameter("@starndard1", SqlDbType.VarChar,50),
           new SqlParameter("@record1_name", SqlDbType.NVarChar,500),
           new SqlParameter("@record1_value", SqlDbType.Decimal,4),
           new SqlParameter("@starndard2", SqlDbType.VarChar,50),
           new SqlParameter("@record2_name", SqlDbType.NVarChar,500),
           new SqlParameter("@record2_value", SqlDbType.Decimal,4),
           new SqlParameter("@starndard3", SqlDbType.VarChar,50),
           new SqlParameter("@record3_name", SqlDbType.NVarChar,500),
           new SqlParameter("@record3_value", SqlDbType.Decimal,4),
           new SqlParameter("@is_using", SqlDbType.Int,4),
           new SqlParameter("@remark", SqlDbType.NVarChar,500),
					new SqlParameter("@id", SqlDbType.BigInt,8)};
        parameters[0].Value = base_id;
        parameters[1].Value = position;
        parameters[2].Value = recorder;
        parameters[3].Value = date_time;
        parameters[4].Value = status ;
        parameters[5].Value = status_detail ;
        parameters[6].Value = record1_name;
        parameters[7].Value = record1_value;
        parameters[8].Value = starndard2;
        parameters[9].Value = record2_name;
        parameters[10].Value = record2_value;
        parameters[11].Value = starndard3;
        parameters[12].Value = record3_name;
        parameters[13].Value = record3_value; 
        parameters[14].Value = is_using;
        parameters[15].Value = remark ;
        parameters[16].Value = id;

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
        strSql.Append("delete from [spotcheck_info] ");
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
        strSql.Append("(base_id,position,recorder,date_time,status,status_detail,starndard1,record1_name,record1_value,starndard2,record2_name,record2_value,starndard3,record3_name,record3_value,remark)");
        strSql.Append(" FROM [spotcheck_info] ");
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
            if (ds.Tables[0].Rows[0]["status"] != null )
            {
                this.status = ds.Tables[0].Rows[0]["status"].ToString();
            }
            if (ds.Tables[0].Rows[0]["status_detail"] != null)
            {
                this.status_detail = ds.Tables[0].Rows[0]["status_detail"].ToString();
            }
            if (ds.Tables[0].Rows[0]["starndard1"] != null)
            {
                this.starndard1 = ds.Tables[0].Rows[0]["starndard1"].ToString();
            }
            if (ds.Tables[0].Rows[0]["record1_name"] != null)
            {
                this.record1_name = ds.Tables[0].Rows[0]["record1_name"].ToString();
            }
            if (ds.Tables[0].Rows[0]["record1_value"] != null)
            {
                this.record1_value = float.Parse(ds.Tables[0].Rows[0]["record1_value"].ToString());
            }
            if (ds.Tables[0].Rows[0]["starndard2"] != null)
            {
                this.starndard2 = ds.Tables[0].Rows[0]["starndard2"].ToString();
            }
            if (ds.Tables[0].Rows[0]["record2_name"] != null)
            {
                this.record2_name = ds.Tables[0].Rows[0]["record2_name"].ToString();
            }
            if (ds.Tables[0].Rows[0]["record2_value"] != null)
            {
                this.record2_value = float.Parse(ds.Tables[0].Rows[0]["record2_value"].ToString());
            }
            if (ds.Tables[0].Rows[0]["starndard3"] != null)
            {
                this.starndard3 = ds.Tables[0].Rows[0]["starndard3"].ToString();
            }
            if (ds.Tables[0].Rows[0]["record3_name"] != null)
            {
                this.record3_name = ds.Tables[0].Rows[0]["record3_name"].ToString();
            }
            if (ds.Tables[0].Rows[0]["record3_value"] != null)
            {
                this.record3_value = float.Parse(ds.Tables[0].Rows[0]["record3_value"].ToString());
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
        strSql.Append("update [spotcheck_info] set ");
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
        strSql.Append("update [spotcheck_info] set ");
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
        strSql.Append(" FROM [spotcheck_info] ");
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
        strSql.Append("select * FROM  spotcheck_info");
        if (strWhere.Trim() != "")
        {
            strSql.Append(" where " + strWhere);
        }
        recordCount = Convert.ToInt32(DbHelperSQL.GetSingle(PagingHelper.CreateCountingSql(strSql.ToString())));
        return DbHelperSQL.Query(PagingHelper.CreatePagingSql(recordCount, pageSize, pageIndex, strSql.ToString(), filedOrder));
    }

    #endregion  Method
}


