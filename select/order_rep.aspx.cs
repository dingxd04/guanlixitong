using System;
using System.Data;
using System.Text;
using System.Web;
using System.Web.UI;

public partial class select_order_rep : System.Web.UI.Page
{
    protected int depot_category_id;
    protected int depot_id;
    protected int status;
    protected string note_no = string.Empty;
    protected string start_time = string.Empty;
    protected string stop_time = string.Empty;


    ManagePage mym = new ManagePage();
    protected void Page_Load(object sender, EventArgs e)
    {
        //判断是否登录
        if (!mym.IsAdminLogin())
        {
            Response.Write("<script>parent.location.href='../index.aspx'</script>");
            Response.End();
        }
        //判断权限
        ps_manager_role_value myrv = new ps_manager_role_value();
        int role_id = Convert.ToInt32(Session["RoleID"]);
        int nav_id = 16;
        if (!myrv.QXExists(role_id, nav_id))
        {
            Response.Redirect("../error.html");
            Response.End();
        }
        if (!Page.IsPostBack)
        {
            this.depot_category_id = AXRequest.GetQueryInt("depot_category_id");
            this.depot_id = AXRequest.GetQueryInt("depot_id");
            this.status = AXRequest.GetQueryInt("status");
            this.note_no = AXRequest.GetQueryString("note_no");
            this.start_time = AXRequest.GetQueryString("start_time");
            this.stop_time = AXRequest.GetQueryString("stop_time");

            binddr();
        }

        Response.Clear();
        Response.Buffer = true;
        Response.AppendHeader("Content-Disposition", "attachment;filename=" + HttpUtility.UrlEncode("订单信息表"+DateTime.Now.ToString("d")+".xls", Encoding.UTF8).ToString());
        Response.ContentEncoding = System.Text.Encoding.UTF8;
        Response.ContentType = "application/vnd.ms-excel";
        this.EnableViewState = false;


    }

    #region 组合SQL查询语句==========================
    protected string CombSqlTxt(int _depot_category_id, int _depot_id, int _status, string _note_no, string _start_time, string _stop_time)
    {
        StringBuilder strTemp = new StringBuilder();

        if (_status > 0)
        {
            strTemp.Append(" and status=" + _status);
        }
        if (_depot_category_id > 0)
        {
            strTemp.Append(" and depot_category_id=" + _depot_category_id);
        }
        if (_depot_id > 0)
        {
            strTemp.Append(" and depot_id=" + _depot_id);
        }

        if (string.IsNullOrEmpty(_start_time))
        {
            _start_time = "1900-01-01";
            Literal4.Text = "(不限)";
        }
        else
        {
            Literal4.Text = _start_time;
        }
        if (string.IsNullOrEmpty(_stop_time))
        {
            _stop_time = "2099-01-01";
            Literal5.Text = DateTime.Now.ToString("d");
        }
        else
        {
            Literal5.Text = _stop_time;
        }
        strTemp.Append(" and add_time between  '" + DateTime.Parse(_start_time) + "' and '" + DateTime.Parse(_stop_time + " 23:59:59") + "'");

        _note_no = _note_no.Replace("'", "");
        if (!string.IsNullOrEmpty(_note_no))
        {
            strTemp.Append(" and order_no like  '%" + _note_no + "%' ");
        }
        return strTemp.ToString();
    }
    #endregion

    //绑定记录
    public void binddr()
    {     
        ps_orders bll = new ps_orders();

        string sqlstr = "id>0 ";
        sqlstr = sqlstr + CombSqlTxt(this.depot_category_id, this.depot_id, this.status, this.note_no, this.start_time, this.stop_time);
        sqlstr = sqlstr + " order by add_time desc,id desc";
        DataView dv = bll.GetList(sqlstr).Tables[0].DefaultView;
        repCategory.DataSource = dv;
        repCategory.DataBind();

        this.Literal_pa.Text = MyConvert(bll.GetTitleSum( " status<>4"+ CombSqlTxt(this.depot_category_id, this.depot_id, this.status, this.note_no, this.start_time, this.stop_time) , "sum(payable_amount)"));
        this.Literal_ra.Text = MyConvert(bll.GetTitleSum(" status<>4" + CombSqlTxt(this.depot_category_id, this.depot_id, this.status, this.note_no, this.start_time, this.stop_time), "sum(real_amount)"));
        this.Literal_oa.Text = MyConvert(bll.GetTitleSum(" status<>4" + CombSqlTxt(this.depot_category_id, this.depot_id, this.status, this.note_no, this.start_time, this.stop_time), "sum(order_amount)"));
    }
 
    #region 返回订单状态=============================
    protected string GetOrderStatus(int _id)
    {
        string _title = string.Empty;

        switch (_id)
        {
            case 1:
                _title = "已生成";
                break;
            case 2:
                _title = "已确认";
                break;
            case 3:
                _title = "交易完成";
                break;
            case 4:
                _title = "<font color=red>已取消</font>";
                break;
        }

        return _title;
    }
    #endregion

    //小数位是0的不显示
    public string MyConvert(object d)
    {
        string myNum = d.ToString();
        string[] strs = d.ToString().Split('.');
        if (strs.Length > 1)
        {
            if (Convert.ToInt32(strs[1]) == 0)
            {
                myNum = strs[0];
            }
        }
        return myNum;
    }
}
