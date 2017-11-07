<%@ Page Language="C#" AutoEventWireup="true" CodeFile="shopping.aspx.cs" Inherits="order_shopping" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>购物车</title>
    <link href="../css/style.css" rel="stylesheet" type="text/css" />
<script type="text/javascript" src="../js/jquery/jquery-1.10.2.min.js"></script>
<script type="text/javascript" src="../js/lhgdialog/lhgdialog.js?skin=idialog"></script>
<script type="text/javascript" src="../js/layout.js"></script>
<script type="text/javascript" src="../js/base.js"></script>
<script type="text/javascript" src="../js/cart.js"></script>
</head>
<body>
    <form id="form1" runat="server">
<div id="main">
<div  style="height:10px;"></div>
<div class="boxwrap">
  <div class="cart_box">

    <!--购物车-->
    <h1 class="main_tit">
    <span><a onclick="DeleteCart(this,'/','0');" href="javascript:;">清空购物车</a></span>
      我的购物车
    </h1>
    <div class="line20"></div> 
  
    <table width="938" border="0" align="center" cellpadding="8" cellspacing="0" class="cart_table">
      <tr>       
      <th width="100" align="center">商品类别</th>
        <th width="64"></th>
        <th align="left">商品名称</th>
        <th width="80" align="center">单价</th>
        <th width="80" align="center">数量</th>
        <th width="100" align="center">金额小计</th>
        <th width="50" align="center">操作</th>
      </tr>
  <asp:Repeater ID="rptList" runat="server">
<ItemTemplate> 
      <tr>
           <td><%#new ps_product_category().GetTitle(Convert.ToInt32(new ps_here_depot().GetTPid(Convert.ToInt32(Eval("id")))))%></td>
        <td><a target="_blank" href=""><img src="<%# Eval("img_url")%>" class="img" /></a></td>
        <td><%# Eval("title")%></td>  
        <td align="center"><%# MyConvert(Eval("price"))%>&nbsp;&nbsp;元/<%# Eval("dw")%><input name="goods_price" type="hidden" value="<%# MyConvert(Eval("price"))%>" /></td>
        <td align="center">
          <a href="javascript:;" class="reduce" title="减一" onclick="CartComputNum(this, '/', '<%# Eval("id")%>', -1);">减一</a>
          <input type="text" name="goods_quantity" class="input" style="width:30px;text-align:center;ime-mode:Disabled;" value="<%# Eval("quantity")%>" onblur="CartAmountTotal(this, '/', '<%# Eval("id")%>');" onkeypress="return (/[\d]/.test(String.fromCharCode(event.keyCode)))" />
          <a href="javascript:;" class="subjoin" title="加一" onclick="CartComputNum(this,'/', '<%# Eval("id")%>', 1);">加一</a>
        </td>
        <td align="center"><font color="#FF0000" size="2">￥<label name="real_amount"><%# Convert.ToDecimal(Eval("price")) * Convert.ToDecimal(Eval("quantity"))%></label></font></td>      
        <td align="center"><a onclick="DeleteCart(this,'/','<%# Eval("id")%>');" href="javascript:;">删除</a></td>
      </tr>
       </ItemTemplate>
<FooterTemplate>
  <%#rptList.Items.Count == 0 ? " <tr><td colspan=\"6\"><div class=\"msg_tips\"><div class=\"ico warning\"></div><div class=\"msg\"><strong>购物车没有商品！</strong><p>您的购物车为空，<a href=\"goods_list.aspx\">马上去选购</a>吧！</p></div></div></td></tr>" : ""%>

</FooterTemplate>
</asp:Repeater> 
           <tr>
        <th colspan="6" align="right">
          商品件数：
            <asp:Literal ID="total_quantity" runat="server"></asp:Literal>件 &nbsp;&nbsp; 商品总金额：<font color="#FF0000" size="2">￥<asp:Literal ID="payable_amount" runat="server"></asp:Literal></font>元 
        </th>
      </tr>

           <tr>
        <th colspan="6" align="left">

    <div>
      <div class="left">
        <h4>订单留言<span>字数控制在100个字符内</span></h4>
          <asp:TextBox ID="message" class="input" runat="server" Height="84px" 
              TextMode="MultiLine" Width="307px"></asp:TextBox>
      </div>
      
      <div class="right" style="text-align:right;line-height:40px;">
        <b class="font18">应付总金额：<font color="#FF0000">￥<label id="order_amount"><asp:Literal ID="payable_amount1" runat="server"></asp:Literal></label></font></b>
      </div>
    </div>
     <div class="line20"></div>
    <div class="right">
      <a class="btn green" href="goods_list.aspx">继续购物</a>
    <asp:Button ID="btnSubmit" runat="server" Text="提交保存 " CssClass="btn"  onclick="btnSubmit_Click"  />
   
    </div>
    </th>
      </tr>
    	</table>
   
    <div class="clear"></div>
    <!--/购物车-->

  </div>
</div>

<div class="clear"></div>
</div>

    </form>
</body>
</html>
