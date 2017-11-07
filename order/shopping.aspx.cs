using System;
using System.Text;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections.Generic;
using LitJson;

public partial class order_shopping : System.Web.UI.Page
{
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
        int nav_id = 21;
        if (!myrv.QXExists(role_id, nav_id))
        {
            Response.Redirect("../error.html");
            Response.End();
        }

        if (!Page.IsPostBack)
        {
            RptBind();
        }
    }


    #region 数据绑定=================================
    private void RptBind()
    {
        ShopCart bll = new ShopCart();
        IList<cart_items> ls1 = bll.get_cart_list();
        this.rptList.DataSource = ls1;
        this.rptList.DataBind();
        cart_total cartModel = ShopCart.GetTotal();
        total_quantity.Text = cartModel.total_quantity.ToString();
        payable_amount.Text = cartModel.payable_amount.ToString();
        payable_amount1.Text = cartModel.payable_amount.ToString();
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
 
    //提交订单
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        int user_id = 0;
        int depot_category_id = 0;
        int depot_id = 0;
        string user_name = string.Empty;

        user_id = Convert.ToInt32(Session["AID"]);
        depot_category_id = Convert.ToInt32(Session["DepotCatID"]);
        depot_id = Convert.ToInt32(Session["DepotID"]);
        user_name = Session["AdminName"].ToString();
    
        //检查购物车商品
        IList<cart_items> iList = ShopCart.GetList();
        if (iList == null)
        {
            mym.JscriptMsg(this.Page, "对不起，购物车为空，无法结算！", "", "Error");
            return;
        }

        //统计购物车
        cart_total cartModel =ShopCart.GetTotal();
        //判断是否有商品
        if (cartModel.payable_amount == 0)
        {
            mym.JscriptMsg(this.Page, "对不起，购物车为空，无法结算！", "", "Error");
            return;
        }
        
        //保存订单=======================================================================
        ps_orders model = new ps_orders();
        model.order_no =  Utils.GetOrderNumber(); //订单号B开头为商品订单
        model.user_id = user_id;
        model.depot_category_id = depot_category_id;
        model.depot_id = depot_id;
        model.user_name = user_name;
        model.payment_id = 1;//未支付
        model.message = message.Text;
        model.payable_amount = cartModel.payable_amount;
        model.real_amount =0;

        //订单总金额=实付商品金额
        model.order_amount = cartModel.payable_amount;   
        model.add_time = DateTime.Now;

   
        if (model.Add() ==0)
        {
            mym.JscriptMsg(this.Page, "订单保存过程中发生错误，请重新提交！", "", "Error");
            return;
        }
       //商品详细列表
        ps_order_goods gls = new ps_order_goods();
        ps_here_depot my = new ps_here_depot();
        foreach (cart_items item in iList)
        {
            my.GetModel(item.id);
            gls.order_id = model.GetMaxId();
            gls.goods_id = item.id;
            gls.goods_title = item.title;
            gls.goods_price =my.go_price;
            gls.real_price = item.price;
            gls.quantity = item.quantity;
            gls.product_category_id = item.product_category_id;
            gls.dw = item.dw;
            gls.Add();
        }
        //清空购物车
        ShopCart.Clear("0");
        //提交成功，返回URL
        mym.JscriptMsg(this.Page, "恭喜您，订单已成功提交！", "my_order.aspx", "Success");
        return;
    }
}