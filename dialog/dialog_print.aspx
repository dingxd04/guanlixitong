<%@ Page Language="C#" AutoEventWireup="true" CodeFile="dialog_print.aspx.cs" Inherits="dialog_dialog_print" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
 <title>打印订单窗口</title>
<script type="text/javascript" src="../js/jquery/jquery-1.10.2.min.js"></script>
<script type="text/javascript" src="../js/lhgdialog/lhgdialog.js?skin=idialog"></script>
<script type="text/javascript">
    //窗口API
    var api = frameElement.api, W = api.opener;
    api.button({
        name: '确认打印',
        focus: true,
        callback: function () {
            printWin();
        }
    }, {
        name: '取消'
    });
    //打印方法
    function printWin() {
        var oWin = window.open("", "_blank");
        oWin.document.write(document.getElementById("content").innerHTML);
        oWin.focus();
        oWin.document.close();
        oWin.print()
        oWin.close()
    }
</script>
</head>

<body style="margin:0;">
<form id="form1" runat="server">
<div id="content">
<table width="800" border="0" align="center" cellpadding="3" cellspacing="0" style="font-size:12px; font-family:'微软雅黑'; background:#fff;">
<tr>
  <td width="346" height="50" style="font-size:20px;">物联商品订单</td>
  <td width="216">订单号：<%=model.order_no%><br />
下单时间：<%= Convert.ToDateTime(model.add_time).ToString()%></td>
  <td width="220">操&nbsp; 作 人：<%= Session["RealName"].ToString()%><br />打印时间：<%=DateTime.Now%></td>
</tr>
<tr>
  <td colspan="3" style="padding:10px 0; border-top:1px solid #000;">
  <asp:Repeater ID="rptList" runat="server">
      <HeaderTemplate>
        <table width="100%" border="0" cellspacing="0" cellpadding="5" style="font-size:12px; font-family:'微软雅黑'; background:#fff;">
          <tr>
           <td width="18%" align="left" style="background:#ccc;">商品类别</td>
            <td align="left" style="background:#ccc;">商品名称</th>
            <td width="12%" align="left" style="background:#ccc;">销售价</td>
            <td width="10%" align="left" style="background:#ccc;">数量</td>
            <td width="12%" align="left" style="background:#ccc;">金额合计</td>
          </tr>
      </HeaderTemplate>
      <ItemTemplate>
          <tr>
             <td><%#new ps_product_category().GetTitle(Convert.ToInt32(new ps_here_depot().GetTPid(Convert.ToInt32(Eval("goods_id")))))%></td>
            <td><%#Eval("goods_title")%></td>
            <td><%#Eval("goods_price")%></td>
            <td><%#Eval("quantity")%></td>
            <td><%#Convert.ToDecimal(Eval("goods_price")) * Convert.ToInt32(Eval("quantity"))%></td>
          </tr>
      </ItemTemplate>
      <FooterTemplate>
            <%#rptList.Items.Count == 0 ? "<tr><td align=\"center\" colspan=\"5\">暂无记录</td></tr>" : ""%>
          </table>
     </FooterTemplate>
  </asp:Repeater>
  </td>
  </tr>
<tr>
  <td colspan="3" style="border-top:1px solid #000;">
  <table width="100%" border="0" cellspacing="0" cellpadding="5" style="margin:5px auto; font-size:12px; font-family:'微软雅黑'; background:#fff;">
    <tr>
      <td width="44%">
        商家账户：
        <%if (model.user_id > 0)
          { %>
          <%=model.user_name%>
        <%}
          else
          { %>
          匿名用户
        <%} %>
      </td>
      <td width="56%">联系人姓名：<asp:Label ID="contact_name" runat="server" /><br /></td>
    </tr>

    <tr>
      <td>商家名称：<asp:Label ID="title" runat="server" /></td>
      <td>商家地址：<asp:Label ID="contact_address" runat="server" /></td>
    </tr>
    <tr>
      <td valign="top">
        用户留言：<%=model.message%>
      </td>
    <td valign="top">联系电话：<asp:Label ID="contact_tel" runat="server" /></td>
    </tr>
    <tr>
      <td valign="top">订单备注：<%=model.remark%></td>
      
    </tr>
  </table>
    <table width="100%" border="0" align="center" cellpadding="5" cellspacing="0" style="border-top:1px solid #000; font-size:12px; font-family:'微软雅黑'; background:#fff;">
      <tr>
        <td align="right">订购商品金额：￥<%=model.payable_amount%> + 价格调整金额：￥<%=model.real_amount%>  = 实际总额：<%=model.order_amount%></td>
      </tr>
    </table></td>
  </tr>
</table>
</div>
</form>
</body>
</html>