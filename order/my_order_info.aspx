<%@ Page Language="C#" AutoEventWireup="true" CodeFile="my_order_info.aspx.cs" Inherits="order_my_order_info" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>订单信息</title>
    <script type="text/javascript" src="../js/jquery/jquery-1.10.2.min.js"></script>
<script type="text/javascript" src="../js/jquery/Validform_v5.3.2_min.js"></script>
<script type="text/javascript" src="../js/lhgdialog/lhgdialog.js?skin=idialog"></script>
<script type="text/javascript" src="../js/layout.js"></script>
<script type="text/javascript" src="../js/pinyin.js"></script>
<link href="../css/style.css" rel="stylesheet" type="text/css" />
</head>
<body>
<form id="form1" runat="server">
	<div class="place">
    <span>位置：</span>
    <ul class="placeul">
    <li><a href="../home.aspx">首页</a></li>
    <li><a href="my_order.aspx">我的订单</a></li>
    <li><a href="#">订单信息</a></li>
    </ul>
    </div>

    <div class="formbody">   
    <div class="formtitle"><span>订单详细信息</span></div>
    <!--/订单详细信息-->
<div class="tab-content">
  <dl>
    <dd style="margin-left:50px;text-align:center;">
      <div class="order-flow" style="width:560px">
        <%if (model.status < 4)
          { %>
        <div class="order-flow-left">
          <a class="order-flow-input">生成</a>
          <span><p class="name">订单已生成</p><p><%=model.add_time%></p></span>
        </div>

        <%if (model.payment_status == 0 && model.status == 1)
          { %>
        <div class="order-flow-wait">
           <a class="order-flow-input">确认</a>
           <span><p class="name">等待确认</p></span>
        </div>
        <%}
          else if (model.payment_status == 0 && model.status > 1)
          { %>
        <div class="order-flow-arrive">
          <a class="order-flow-input">确认</a>
          <span><p class="name">已确认</p><p><%=model.confirm_time%></p></span>
        </div>
        <%} %>

         <%if (model.status == 3)
           { %>
         <div class="order-flow-right-arrive">
           <a class="order-flow-input">完成</a>
           <span><p class="name">订单完成</p><p><%=model.complete_time%></p></span>
         </div>
         <%}
           else
           { %>
         <div class="order-flow-right-wait">
           <a class="order-flow-input">完成</a>
           <span><p class="name">订单完成</p></span>
         </div>
         <%} %>
         <%}
          else if (model.status == 4)
          {%>
          <div style="text-align:center;line-height:30px; font-size:20px; color:Red;">该订单已取消</div>
         <%} %>
      </div>
    </dd>
  </dl>
  <dl>
    <dt>订单号</dt>
    <dd><span id="spanOrderNo"><%=model.order_no %></span></dd>
  </dl>
  <asp:Repeater ID="rptList" runat="server">
  <HeaderTemplate>
  <dl>
    <dt>商品列表</dt>
    <dd>
      <table border="0" cellspacing="0" cellpadding="0" class="border-table" width="98%">
        <thead>
          <tr>
          <th width="18%">商品类别</th>
            <th>商品名称</th>
            <th width="12%">销售价</th>
            <th width="10%">数量</th>
            <th width="12%">金额合计</th>
          </tr>
        </thead>
        <tbody>
        </HeaderTemplate>
        <ItemTemplate>
          <tr class="td_c">
           <td><%#new ps_product_category().GetTitle(Convert.ToInt32(Eval("product_category_id")))%></td>
            <td style="text-align:left;white-space:normal;"><%#Eval("goods_title")%></td>
            <td><%#Eval("goods_price")%></td>
            <td><%#Eval("quantity")%>&nbsp;&nbsp;<%# Eval("dw")%></td>
            <td><%#Convert.ToDecimal(Eval("goods_price")) * Convert.ToInt32(Eval("quantity"))%></td>
          </tr>
          </ItemTemplate>
          <FooterTemplate>
        </tbody>
      </table>
    </dd>
  </dl>
  </FooterTemplate>
  </asp:Repeater>
  <dl>
    <dt>收货信息</dt>
    <dd>
      <table border="0" cellspacing="0" cellpadding="0" class="border-table" width="98%">
        <tr>
          <th width="20%">商家账户</th>
          <td>
            <div class="position">
              <span id="spanAcceptName"><asp:Label ID="user_name" runat="server" /></span>
   
            </div>
          </td>
        </tr>
        
        <tr>
          <th>商家名称</th>
          <td> <span id="span1"><asp:Label ID="title" runat="server" /></span></td>
        </tr>
        <tr>
          <th>商家地址</th>
          <td> <span id="spanAddress"><asp:Label ID="contact_address" runat="server" /></span></td>
        </tr>
        <tr>
          <th>联系人姓名</th>
          <td><span id="spanPostCode"><asp:Label ID="contact_name" runat="server" /></span></td>
        </tr>
        <tr>
          <th>联系电话</th>
          <td><span id="spanTelphone"><asp:Label ID="contact_tel" runat="server" /></span></td>
        </tr>
          <tr>
          <th>我的留言</th>
          <td><%=model.message %></td>
        </tr>

      </table>
    </dd>
  </dl>
  

  <dl>
    <dt>订单统计</dt>
    <dd>
      <table border="0" cellspacing="0" cellpadding="0" class="border-table" width="98%">
        <tr>
          <th width="20%">订购商品金额</th>
          <td>
            <div class="position">
              <span id="spanRealAmountValue"><%=model.payable_amount%></span> 元
              
            </div>
          </td>
        </tr>
        <tr>
          <th>实际总金额</th>
          <td>
            <div class="position">
              <span id="spanPaymentFeeValue"><%=model.order_amount%></span> 元
            </div>
          </td>
        </tr>
        <tr>
          <th>价格调整金额</th>
          <td><%=model.real_amount%> 元</td>
        </tr>
      </table>
    </dd>
  </dl>
</div>
<!--/订单详细信息-->
    </div>



    </form>
</body>
</html>
