<%@ WebHandler Language="C#" Class="submit_ajax" %>

using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Web;
using System.Web.SessionState;
using LitJson;

/// <summary>
/// AJAX提交处理
/// </summary>
public class submit_ajax : IHttpHandler, IRequiresSessionState
{

    public void ProcessRequest(HttpContext context)
    {
        //取得处事类型
        string action = AXRequest.GetQueryString("action");

        switch (action)
        {
        
            case "cart_goods_add": //购物车加入商品
                cart_goods_add(context);
                break;
            case "cart_goods_update": //购物车修改商品
                cart_goods_update(context);
                break;
            case "cart_goods_delete": //购物车删除商品
                cart_goods_delete(context);
                break;
            case "view_cart_count": //输出当前购物车总数
                view_cart_count(context);
                break;
        }
    }

    #region 购物车加入商品OK===============================
    private void cart_goods_add(HttpContext context)
    {
        string goods_id = AXRequest.GetFormString("goods_id");
        int goods_quantity = AXRequest.GetFormInt("goods_quantity", 1);
        if (goods_id == "")
        {
            context.Response.Write("{\"status\":0, \"msg\":\"您提交的商品参数有误！\"}");
            return;
        }

        //统计购物车
        ShopCart.Add(goods_id, goods_quantity);
        cart_total cartModel = ShopCart.GetTotal();
        context.Response.Write("{\"status\":1, \"msg\":\"商品已成功添加到购物车！\", \"quantity\":" + cartModel.total_num + ", \"amount\":" + cartModel.real_amount + "}");
        return;
    }
    #endregion

    #region 修改购物车商品OK===============================
    private void cart_goods_update(HttpContext context)
    {
        string goods_id = AXRequest.GetFormString("goods_id");
        int goods_quantity = AXRequest.GetFormInt("goods_quantity");
        if (goods_id == "")
        {
            context.Response.Write("{\"status\":0, \"msg\":\"您提交的商品参数有误！\"}");
            return;
        }

        if (ShopCart.Update(goods_id, goods_quantity))
        {
            context.Response.Write("{\"status\":1, \"msg\":\"商品数量修改成功！\"}");
        }
        else
        {
            context.Response.Write("{\"status\":0, \"msg\":\"商品数量更改失败，请检查操作是否有误！\"}");
        }
        return;
    }
    #endregion

    #region 删除购物车商品OK===============================
    private void cart_goods_delete(HttpContext context)
    {
        string goods_id = AXRequest.GetFormString("goods_id");
        if (goods_id == "")
        {
            context.Response.Write("{\"status\":0, \"msg\":\"您提交的商品参数有误！\"}");
            return;
        }
        ShopCart.Clear(goods_id);
        context.Response.Write("{\"status\":1, \"msg\":\"商品移除成功！\"}");
        return;
    }
    #endregion


    #region 输出购物车总数OK===============================
    private void view_cart_count(HttpContext context)
    {
       cart_total cartModel = ShopCart.GetTotal();
       context.Response.Write("document.write('" + cartModel.total_num + "');");
    }
    #endregion



    public bool IsReusable
    {
        get
        {
            return false;
        }
    }
}