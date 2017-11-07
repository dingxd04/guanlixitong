using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class select_order_edit : System.Web.UI.Page
{
    protected int page;
    private string action = ""; //操作类型
    private int id = 0;
    ManagePage mym = new ManagePage();
    protected ps_orders model = new ps_orders();

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
            }
        }

    }

    #region 赋值操作=================================
    private void ShowInfo(int _id)
    {
        model.GetModel(_id);
        //绑定商品列表
        ps_order_goods bll = new ps_order_goods();
        string sql = " order_id =" + _id;

        DataTable dt = bll.GetList(sql).Tables[0];
        this.rptList.DataSource = dt;
        this.rptList.DataBind();

        //获得商家信息
        if (model.depot_id > 0)
        {              
            ps_depot user_info = new ps_depot();
            user_info.GetModel(Convert.ToInt32(model.depot_id));
            user_name.Text = model.user_name;
            title.Text = user_info.title;
            contact_address.Text = user_info.contact_address;
            contact_name.Text = user_info.contact_name;
            contact_tel.Text = user_info.contact_mobile;
        }
        //根据订单状态，显示各类操作按钮
        switch (model.status)
        {
            case 1: //订单为已生成状态     
                    //确认订单、取消订单显示
                   btnConfirm.Visible = btnCancel.Visible = true;       
                //修改订单备注、调价按钮显示
                   btnEditRemark.Visible = btnEditPaymentFee.Visible = true;
                break;
            case 2: //如果订单为已确认状态
                //完成显示
                btnComplete.Visible = true;    
                //修改订单备注按钮可见
                btnEditRemark.Visible = true;
                break;
 
        }

    }
    #endregion
}