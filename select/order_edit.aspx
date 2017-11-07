<%@ Page Language="C#" AutoEventWireup="true" CodeFile="order_edit.aspx.cs" Inherits="select_order_edit" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>编辑订单信息</title>
    <script type="text/javascript" src="../js/jquery/jquery-1.10.2.min.js"></script>
<script type="text/javascript" src="../js/jquery/Validform_v5.3.2_min.js"></script>
<script type="text/javascript" src="../js/lhgdialog/lhgdialog.js?skin=idialog"></script>
<script type="text/javascript" src="../js/layout.js"></script>
<script type="text/javascript" src="../js/pinyin.js"></script>
<link href="../css/style.css" rel="stylesheet" type="text/css" />
<script type="text/javascript">
    $(function () {
        $("#btnConfirm").click(function () { OrderConfirm(); });   //确认订单
        $("#btnComplete").click(function () { OrderComplete(); }); //完成订单
        $("#btnCancel").click(function () { OrderCancel(); });     //取消订单
        $("#btnPrint").click(function () { OrderPrint(); });       //打印订单

        $("#btnEditRemark").click(function () { EditOrderRemark(); });    //修改订单备注
        $("#btnEditPaymentFee").click(function () { EditPaymentFee(); });  //调价

    });

    //确认订单
    function OrderConfirm() {
        var dialog = $.dialog.confirm('确认订单后将无法修改金额，确认要继续吗？', function () {
            var postData = { "order_no": $("#spanOrderNo").text(), "edit_type": "order_confirm" };
            //发送AJAX请求
            sendAjaxUrl(dialog, postData, "../tools/admin_ajax.ashx?action=edit_order_status");
            return false;
        });
    }

    //完成订单
    function OrderComplete() {
        var dialog = $.dialog.confirm('订单完成后，说明商品已经送到客户手里，订单完成，确认要继续吗？', function () {
            var postData = { "order_no": $("#spanOrderNo").text(), "edit_type": "order_complete" };
            //发送AJAX请求
            sendAjaxUrl(dialog, postData, "../tools/admin_ajax.ashx?action=edit_order_status");
            return false;
        });
    }
    //取消订单
    function OrderCancel() {
        var dialog = $.dialog({
            title: '取消订单',
            content: '操作提示信息：<br />1、请与下单商家沟通；<br />2、取消订单后该订单不做财务收入统计；<br />3、请单击相应按钮继续下一步操作！',
            min: false,
            max: false,
            lock: true,
            icon: 'confirm.gif',
            button: [{
                name: '确认取消',
                callback: function () {
                    var postData = { "order_no": $("#spanOrderNo").text(), "edit_type": "order_cancel", "check_revert": 0 };
                    //发送AJAX请求
                    sendAjaxUrl(dialog, postData, "../tools/admin_ajax.ashx?action=edit_order_status");
                    return false;
                }
            }, {
                name: '关闭'
            }]
        });

    }
 
    //打印订单
    function OrderPrint() {
        var dialog = $.dialog({
            title: '打印订单',
            content: 'url:../dialog/dialog_print.aspx?order_no=' + $("#spanOrderNo").text(),
            min: false,
            max: false,
            lock: true,
            width: 850//,
            //height: 500
        });
    }
   
    //修改订单备注
    function EditOrderRemark() {
        var dialog = $.dialog({
            title: '订单备注',
            content: '<textarea id="txtOrderRemark" name="txtOrderRemark" rows="2" cols="20" class="input">' + $("#divRemark").html() + '</textarea>',
            min: false,
            max: false,
            lock: true,
            ok: function () {
//                var remark = $("#txtOrderRemark", parent.document).val();
                var remark = $("#txtOrderRemark").text();
                if (remark == "") {
                    $.dialog.alert('对不起，请输入订单备注内容！' + remark, function () { }, dialog);
                    return false;
                }
                var postData = { "order_no": $("#spanOrderNo").text(), "edit_type": "edit_order_remark", "remark": remark };
                //发送AJAX请求
                sendAjaxUrl(dialog, postData, "../tools/admin_ajax.ashx?action=edit_order_status");
                return false;
            },
            cancel: true
        });
    }
    //调价
    function EditPaymentFee() {
        var pop = $.dialog.prompt('请调整商品实际总金额',
            function (val) {
                if (!checkIsMoney(val)) {
                    $.dialog.alert('对不起，请输入正确的商品实际总金额！', function () { }, pop);
                    return false;
                }
                var postData = { "order_no": $("#spanOrderNo").text(), "edit_type": "edit_payment_fee", "payment_fee": val };
                //发送AJAX请求
                sendAjaxUrl(pop, postData, "../tools/admin_ajax.ashx?action=edit_order_status");
                return false;
            },
            $("#spanPaymentFeeValue").text()
        );
    }

 
    //=================================工具类的JS函数====================================
    //检查是否货币格式
    function checkIsMoney(val) {
        var regtxt = /^(([1-9]{1}\d*)|([0]{1}))(\.(\d){1,2})?$/;
        if (!regtxt.test(val)) {
            return false;
        }
        return true;
    }
    //发送AJAX请求
    function sendAjaxUrl(winObj, postData, sendUrl) {
        $.ajax({
            type: "post",
            url: sendUrl,
            data: postData,
            dataType: "json",
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                $.dialog.alert('尝试发送失败，错误信息：' + errorThrown, function () { }, winObj);
            },
            success: function (data, textStatus) {
                if (data.status == 1) {
                    winObj.close();
                    $.dialog.tips(data.msg, 2, '32X32/succ.png', function () { location.reload(); }); //刷新页面
                } else {
                    $.dialog.alert('错误提示：' + data.msg, function () { }, winObj);
                }
            }
        });
    }
</script>
</head>
<body>
<form id="form1" runat="server">
	<div class="place">
    <span>位置：</span>
    <ul class="placeul">
    <li><a href="../home.aspx">首页</a></li>
    <li><a href="order_list.aspx">订单管理</a></li>
    <li><a href="#">编辑订单信息</a></li>
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
          <th>用户留言</th>
          <td><%=model.message %></td>
        </tr>
        <tr>
          <th>订单备注</th>
          <td>
            <div class="position">
              <div id="divRemark"><%=model.remark %></div>
              <input id="btnEditRemark" runat="server" visible="false" type="button" class="ibtn" value="修改" />
            </div>
          </td>
        </tr>
      </table>
    </dd>
  </dl>
  

  <dl>
    <dt>订单统计</dt>
    <dd>
      <table border="0" cellspacing="0" cellpadding="0" class="border-table" width="98%">
        <tr>
          <th width="20%">下单总金额</th>
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
         <input id="btnEditPaymentFee" runat="server" visible="false" type="button" class="ibtn" value="调价" />
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

<!--工具栏-->
<div class="page-footer">
  <div class="btn-list">
    <input id="btnConfirm" runat="server" visible="false" type="button" value="确认订单" class="btn" />
    <input id="btnComplete" runat="server" visible="false" type="button" value="完成订单" class="btn" />
    <input id="btnCancel" runat="server" visible="false" type="button" value="取消订单" class="btn green" />
    <input id="btnPrint" type="button" value="打印订单" class="btn violet" />
    <input id="btnReturn" type="button" value="返回上一页" class="btn yellow" onclick="javascript:history.back(-1);" />
  </div>
  <div class="clear"></div>
</div>
<!--/工具栏-->

    </form>
</body>
</html>
