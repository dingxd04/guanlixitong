using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class depotmanager_product_edit : System.Web.UI.Page
{
    protected int page;
    private string action = ""; //操作类型
    protected string dw = ""; //计量单位
    private int id = 0;
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
        string _action = AXRequest.GetQueryString("action");
        this.page = AXRequest.GetQueryInt("page", 1);
        if (!string.IsNullOrEmpty(_action) && _action == "Edit")
        {
            this.action = "Edit";//修改类型
            if (!int.TryParse(Request.QueryString["id"] as string, out this.id))
            {
                mym.JscriptMsg(this.Page, "传输参数不正确！", "back", "Error");
                return;
            }

        }
        if (!Page.IsPostBack)
        {
            if (action == "Edit") //修改
            {
                QDBind();
                ShowInfo(this.id);
                Focus myFocus = new Focus();
                myFocus.SetEnterControl(this.txtsalse_price);
                myFocus.SetFocus(txtsalse_price.Page, "txtsalse_price");
            }
        }
    }

    #region 绑定商品类别=================================
    private void QDBind()
    {
        ps_product_category bll = new ps_product_category();
        DataTable dt = bll.GetList("1=1 order by sort_id").Tables[0];
        this.ddlproduct_category_id.Items.Clear();
        this.ddlproduct_category_id.Items.Add(new ListItem("请选择商品类别...", ""));
        foreach (DataRow dr in dt.Rows)
        {
            string Id = dr["id"].ToString();
            string Title = dr["title"].ToString().Trim();
            this.ddlproduct_category_id.Items.Add(new ListItem(Title, Id));
        }
    }
    #endregion

    #region 赋值操作=================================
    private void ShowInfo(int _id)
    {
        ps_here_depot model1 = new ps_here_depot();
        model1.GetModel(_id);

        this.dw = new ps_product_category().GetDW(Convert.ToInt32(model1.product_category_id));
       this. ddlproduct_category_id.SelectedValue = model1.product_category_id.ToString();

       this.txtImgUrl.Text = model1.product_url;
        this.txtproduct_name.Text = model1.product_name;
        this.txtgo_price.Text = MyConvert(model1.go_price.ToString());
        this.txtsalse_price.Text = MyConvert(model1.salse_price.ToString());
        this.txtproduct_num.Text = model1.product_num.ToString();
    }
    #endregion

    #region 修改操作=================================
    private bool DoEdit(int _id)
    {
        bool result = false;
        ps_here_depot model = new ps_here_depot();
        model.GetModel(_id);

        model.product_url =this.txtImgUrl.Text ;
        model.product_category_id = int.Parse(ddlproduct_category_id.SelectedValue);
        model.product_name = txtproduct_name.Text;
        model.go_price = Convert.ToDecimal(this.txtgo_price.Text);
        model.salse_price = Convert.ToDecimal(this.txtsalse_price.Text);
        if (model.UpdateALL())
        {
            mym.AddAdminLog("修改", "修改商品:" + txtproduct_name.Text); //记录日志
            result = true;
        }

        return result;
    }
    #endregion


    //筛选商品类别
    protected void ddlproduct_category_id_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlproduct_category_id.SelectedValue == "")
        {
            this.dw = "";
        }
        else
        {
            this.dw = new ps_product_category().GetDW(Convert.ToInt32(ddlproduct_category_id.SelectedValue));
        }
    }

    //保存
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (action == "Edit") //修改
        {
            if (!DoEdit(this.id))
            {
                mym.JscriptMsg(this.Page, "保存过程中发生错误！", "", "Error");
                return;
            }
            mym.JscriptMsg(this.Page, "修改商品信息成功！", Utils.CombUrlTxt("depot_manager.aspx", "page={0}", this.page.ToString()), "Success");
        }
        else //发生错误
        {
                mym.JscriptMsg(this.Page, "保存过程中发生错误！", "", "Error");
                return;
        }
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
}