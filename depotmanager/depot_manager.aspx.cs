using System;
using System.Text;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class depotmanager_depot_manager : System.Web.UI.Page
{
    protected int totalCount;
    protected int page;
    protected int pageSize;

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
        int nav_id = 11;
        if (!myrv.QXExists(role_id, nav_id))
        {
            Response.Redirect("../error.html");
            Response.End();
        }
         this.product_category_id = AXRequest.GetQueryInt("product_category_id");

        this.note_no = AXRequest.GetQueryString("note_no");

        this.pageSize = GetPageSize(10); //每页数量

        if (!Page.IsPostBack)
        {
            ZYBind();//绑定商品类别

            if (Convert.ToInt32(Session["DepotID"]) == 0 && Convert.ToInt32(Session["DepotCatID"]) == 0)//公司用户
            {
                RptBind("id>0" + CombSqlTxt(this.product_category_id, this.note_no), "add_time desc,id desc");
            }
        
        }
    }
   

    #region 绑定商品类别=================================
    private void ZYBind()
    {
        ps_product_category bll = new ps_product_category();
        DataTable dt = bll.GetList("1=1").Tables[0];
        this.ddlproduct_category_id.Items.Clear();
        this.ddlproduct_category_id.Items.Add(new ListItem("==全部==", "0"));
        foreach (DataRow dr in dt.Rows)
        {
            string Id = dr["id"].ToString();
            string Title = dr["title"].ToString().Trim();
            this.ddlproduct_category_id.Items.Add(new ListItem(Title, Id));
        }
    }
    #endregion


    #region 数据绑定=================================
    private void RptBind(string _strWhere, string _orderby)
    {
        this.page = AXRequest.GetQueryInt("page", 1);

        if (this.product_category_id > 0)
        {
            this.ddlproduct_category_id.SelectedValue = this.product_category_id.ToString();
        }

        txtNote_no.Text = this.note_no;

        ps_here_depot bll = new ps_here_depot();
        this.rptList.DataSource = bll.GetList(this.pageSize, this.page, _strWhere, _orderby, out this.totalCount);
        this.rptList.DataBind();

        //绑定页码
        txtPageNum.Text = this.pageSize.ToString();
        string pageUrl = Utils.CombUrlTxt("depot_manager.aspx", "product_category_id={0}&note_no={1}&page={2}", this.product_category_id.ToString(),  this.note_no,  "__id__");
        PageContent.InnerHtml = Utils.OutPageList(this.pageSize, this.page, this.totalCount, pageUrl, 8);
    }
    #endregion

    #region 组合SQL查询语句==========================
    protected string CombSqlTxt(int _product_category_id, string _note_no)
    {
        StringBuilder strTemp = new StringBuilder();

        if (_product_category_id > 0)
        {
            strTemp.Append(" and product_category_id=" + _product_category_id);
        }

        _note_no = _note_no.Replace("'", "");
        if (!string.IsNullOrEmpty(_note_no))
        {
            strTemp.Append(" and product_name like  '%" + _note_no + "%' ");
        }
        return strTemp.ToString();
    }
    #endregion

    #region 返回每页数量=============================
    private int GetPageSize(int _default_size)
    {
        int _pagesize;
        if (int.TryParse(Utils.GetCookie("depot_manager_page_size"), out _pagesize))
        {
            if (_pagesize > 0)
            {
                return _pagesize;
            }
        }
        return _default_size;
    }
    #endregion


    //查询
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        Response.Redirect(Utils.CombUrlTxt("depot_manager.aspx", "product_category_id={0}&note_no={1}", this.product_category_id.ToString(), txtNote_no.Text));
    }
  

    //筛选商品类别
    protected void ddlproduct_category_id_SelectedIndexChanged(object sender, EventArgs e)
    {
        Response.Redirect(Utils.CombUrlTxt("depot_manager.aspx", "product_category_id={0}&note_no={1}", this.ddlproduct_category_id.SelectedValue, txtNote_no.Text));
    }


    //设置分页数量
    protected void txtPageNum_TextChanged(object sender, EventArgs e)
    {
        int _pagesize;
        if (int.TryParse(txtPageNum.Text.Trim(), out _pagesize))
        {
            if (_pagesize > 0)
            {
                Utils.WriteCookie("depot_manager_page_size", _pagesize.ToString(), 14400);
            }
        }
        Response.Redirect(Utils.CombUrlTxt("depot_manager.aspx", "product_category_id={0}&note_no={1}", this.product_category_id.ToString(), txtNote_no.Text));
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

    //缺货
    protected void lbtnAcceptCa_Click(object sender, EventArgs e)
    {
        this.page = AXRequest.GetQueryInt("page", 1);
        // 当前点击的按钮
        LinkButton lb = (LinkButton)sender;
        int caId = int.Parse(lb.CommandArgument);
        ps_here_depot bll = new ps_here_depot();
        bll.GetModel(caId);
        bll.id = caId;
        bll.status = 1;
        bll.UpdateStatus(); //更新是否缺货状态

        mym.JscriptMsg(this.Page, " 设置成功！", Utils.CombUrlTxt("depot_manager.aspx", "product_category_id={0}&note_no={1}", this.product_category_id.ToString(), txtNote_no.Text), "Success");
    }

    // 有货
    protected void lbtnRefuseCa_Click(object sender, EventArgs e)
    {
        this.page = AXRequest.GetQueryInt("page", 1);
        // 当前点击的按钮
        LinkButton lb = (LinkButton)sender;
        int caId = int.Parse(lb.CommandArgument);
        ps_here_depot bll = new ps_here_depot();
        bll.GetModel(caId);
        bll.id = caId;
        bll.status = 0;
        bll.UpdateStatus(); //更新是否缺货状态

        mym.JscriptMsg(this.Page, " 设置成功！", Utils.CombUrlTxt("depot_manager.aspx", "product_category_id={0}&note_no={1}", this.product_category_id.ToString(), txtNote_no.Text), "Success");
    }

    //暂停订购
    protected void lbtnAcceptCaDG_Click(object sender, EventArgs e)
    {
        this.page = AXRequest.GetQueryInt("page", 1);
        // 当前点击的按钮
        LinkButton lb = (LinkButton)sender;
        int caId = int.Parse(lb.CommandArgument);
        ps_here_depot bll = new ps_here_depot();
        bll.GetModel(caId);
        bll.id = caId;
        bll.is_xs = 1;
        bll.UpdateXS(); //更新是否暂停订购

        mym.JscriptMsg(this.Page, " 设置成功！", Utils.CombUrlTxt("depot_manager.aspx", "product_category_id={0}&note_no={1}", this.product_category_id.ToString(), txtNote_no.Text), "Success");
    }

    // 可以订购
    protected void lbtnRefuseCaDG_Click(object sender, EventArgs e)
    {
        this.page = AXRequest.GetQueryInt("page", 1);
        // 当前点击的按钮
        LinkButton lb = (LinkButton)sender;
        int caId = int.Parse(lb.CommandArgument);
        ps_here_depot bll = new ps_here_depot();
        bll.GetModel(caId);
        bll.id = caId;
        bll.is_xs = 0;
        bll.UpdateXS(); //更新是否暂停订购

        mym.JscriptMsg(this.Page, " 设置成功！", Utils.CombUrlTxt("depot_manager.aspx", "product_category_id={0}&note_no={1}", this.product_category_id.ToString(), txtNote_no.Text), "Success");
    }
}