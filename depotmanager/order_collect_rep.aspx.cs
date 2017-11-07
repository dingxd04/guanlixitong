using System;
using System.Data;
using System.Text;
using System.Web;
using System.Web.UI;


public partial class depotmanager_order_collect_rep : System.Web.UI.Page
{
    protected int product_category_id;
    protected string note_no = string.Empty;
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
        int nav_id = 40;
        if (!myrv.QXExists(role_id, nav_id))
        {
            Response.Redirect("../error.html");
            Response.End();
        }
        if (!Page.IsPostBack)
        {
            this.product_category_id = AXRequest.GetQueryInt("product_category_id");
            this.note_no = AXRequest.GetQueryString("note_no");
            binddr();
        }

        Response.Clear();
        Response.Buffer = true;
        Response.AppendHeader("Content-Disposition", "attachment;filename=" + HttpUtility.UrlEncode("未配送商品汇总表" + DateTime.Now.ToString("d") + ".xls", Encoding.UTF8).ToString());
        Response.ContentEncoding = System.Text.Encoding.UTF8;
        Response.ContentType = "application/vnd.ms-excel";
        this.EnableViewState = false;
    }

    #region 组合SQL查询语句==========================
    protected string CombSqlTxt(int _product_category_id, string _note_no)
    {
        StringBuilder strTemp = new StringBuilder();

        ps_orders bll = new ps_orders();
        DataTable dt = bll.GetList("status=2").Tables[0];
        strTemp.Append(" and (1=2");
        foreach (DataRow dr in dt.Rows)
        {
            strTemp.Append(" or order_id=" + dr["id"].ToString());
        }
        strTemp.Append(")");

        if (_product_category_id > 0)
        {
            strTemp.Append(" and product_category_id=" + _product_category_id);
            Literal6.Text = new ps_product_category().GetTitle(_product_category_id);
        }
        else
        {
            Literal6.Text = "(所有)";
        }

        _note_no = _note_no.Replace("'", "");
        if (!string.IsNullOrEmpty(_note_no))
        {
            strTemp.Append(" and goods_title like  '%" + _note_no + "%' ");
        }
        return strTemp.ToString();
    }
    #endregion

    //绑定记录
    public void binddr()
    {
        string sqlstr = "";
        ps_order_goods bll = new ps_order_goods();
   
        sqlstr = "id>0";
        sqlstr = sqlstr + CombSqlTxt(this.product_category_id, this.note_no);
        DataView dv = bll.GetListRep(sqlstr).Tables[0].DefaultView;
        repCategory.DataSource = dv;
        repCategory.DataBind();

    }
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

    //负数红色显示
    public string MyZF(object d)
    {
        string myNum = d.ToString();
        if (Convert.ToInt32(d.ToString()) <= 0)
        {
            myNum = "<font color=red> " + d.ToString() + "</font>";
        }
        return myNum;
    }
}