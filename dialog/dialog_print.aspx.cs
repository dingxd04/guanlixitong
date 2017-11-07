using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class dialog_dialog_print : System.Web.UI.Page
{
    private string order_no = string.Empty;
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
        order_no = AXRequest.GetQueryString("order_no");
        if (order_no == "")
        {
            mym.JscriptMsg(this.Page, "传输参数不正确！", "back", "Error");
            return;
        }
        if (!new ps_orders().Exists(order_no))
        {
            mym.JscriptMsg(this.Page, "订单不存在或已被删除！", "back", "Error");
            return;
        }
        if (!Page.IsPostBack)
        {
            ShowInfo(order_no);
        }
    }

    #region 赋值操作=================================
    private void ShowInfo(string _order_no)
    {
        model.GetModel(_order_no);

        ps_order_goods bll = new ps_order_goods();
        string sql = " order_id =" + model.id;
        DataTable dt = bll.GetList(sql).Tables[0];
        this.rptList.DataSource = dt;
        this.rptList.DataBind();
        //获得商家信息
        if (model.depot_id > 0)
        {
            ps_depot user_info = new ps_depot();
            user_info.GetModel(Convert.ToInt32(model.depot_id));
            title.Text = user_info.title;
            contact_address.Text = user_info.contact_address;
            contact_name.Text = user_info.contact_name;
            contact_tel.Text = user_info.contact_mobile;
        }
    }
    #endregion

}