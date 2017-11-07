using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class depotmanager_remove_add_add : System.Web.UI.Page
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
        int nav_id = 7;
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
                ShowInfo(this.id);
                Focus myFocus = new Focus();
                myFocus.SetEnterControl(this.txtproduct_num);
                myFocus.SetFocus(txtproduct_num.Page, "txtproduct_num");
            }
        }
    }


    #region 赋值操作=================================
    private void ShowInfo(int _id)
    {
        ps_here_depot model1 = new ps_here_depot();
        model1.GetModel(_id);
        this.dw = model1.dw;
        this.ddlproduct_category_id.Text = new ps_product_category().GetTitle(Convert.ToInt32(model1.product_category_id));
        this.txtImgUrl.ImageUrl = model1.product_url;
        this.txtproduct_name.Text = model1.product_name;
        this.txtgo_price.Text = MyConvert(model1.go_price.ToString());
        this.txtsalse_price.Text = MyConvert(model1.salse_price.ToString());
        this.Litproduct_num.Text = model1.product_num.ToString();
    }
    #endregion

    #region 修改操作=================================
    private bool DoEdit(int _id)
    {
        DateTime now = DateTime.Now;
        string note_no = now.ToString("yy") + now.ToString("MM") + now.ToString("dd") + now.ToString("HH") + now.ToString("mm") + now.ToString("ss");

        bool result = false;
        ps_here_depot model = new ps_here_depot();
        model.GetModel(_id);
        model.product_num = int.Parse(txtproduct_num.Text) + int.Parse(Litproduct_num.Text);

        ps_join_depot model1 = new ps_join_depot();
        model1.product_category_id = model.product_category_id;
        model1.note_no = note_no;
        model1.add_time = DateTime.Now;
        model1.product_name = model.product_name;
        model1.product_code_state = "入库";
        model1.go_price = model.go_price;
        model1.salse_price = model.salse_price;
        model1.user_id = Convert.ToInt32(Session["AID"]);
        model1.product_num = int.Parse(txtproduct_num.Text);
        model1.here_depot_id = _id;
        model1.dw = model.dw;
        model1.Add();

        if (model.UpdateALL())
        {
            mym.AddAdminLog("入库", "入库商品:" + txtproduct_name.Text); //记录日志
            result = true;
        }

        return result;
    }
    #endregion

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
            mym.JscriptMsg(this.Page, "修改商品信息成功！", Utils.CombUrlTxt("remove_add.aspx", "page={0}", this.page.ToString()), "Success");
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