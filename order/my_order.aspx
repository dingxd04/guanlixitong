<%@ Page Language="C#" AutoEventWireup="true" CodeFile="my_order.aspx.cs" Inherits="order_my_order" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
<title>我的订单</title>
<link href="../css/style.css" rel="stylesheet" type="text/css" />
<script type="text/javascript" src="../js/jquery/jquery-1.10.2.min.js"></script>
<script type="text/javascript" src="../js/lhgdialog/lhgdialog.js?skin=idialog"></script>
<script type="text/javascript" src="../js/layout.js"></script>
<script type="text/javascript" src="../js/lhgcore.min.js"></script>
<script type="text/javascript" src="../js/lhgcalendar.min.js"></script>
<script type="text/javascript">
    J(function () {
        J('#txtstart_time').calendar({ btnBar: true });
        J('#txtstop_time').calendar({ btnBar: true });
    });
    function opdg(s_type, s_url) {
        var t_width, t_height, t_title, t_url, t_id;
        t_id = 'w_1';
        switch (s_type) {
            case 'info':
                t_width = 1080;
                t_height = 460;
                t_title = '查看订单详情';
                t_url = s_url;
                break;
        }
        $.dialog({
            width: t_width,
            height: t_height,
            title: t_title,
            max: false,
            content: 'url:' + t_url
        });
    } 
</script> 
</head>
<body>
    <form id="form1" runat="server">
	<div class="place">
    <span>位置:</span>
    <ul class="placeul">
    <li><a href="../home.aspx">首页</a></li>
    <li><a href="#">我的订单</a></li>
    </ul>
    </div>  
    <div class="rightinfo">
    <dl class="seachform"> 
    <dd><label> 订单号</label><span class="single-select"><asp:TextBox ID="txtNote_no" runat="server" Width="120" CssClass="scinput"></asp:TextBox></span></dd>
	<dd><label>下单起始日期</label><span class="single-select"><input  type="text" class="timeinput" id="txtstart_time" name="txtstart_time" readonly="readonly" runat="server" /></span></dd>
	<dd><label>下单结束日期</label><span class="single-select"><input type="text" class="timeinput" id="txtstop_time" name="txtstop_time" readonly="readonly" runat="server"/></span></dd>

     <dd><label>订单状态</label>  
    <span class="rule-single-select">
<asp:DropDownList ID="ddlStatus" runat="server" AutoPostBack="True" onselectedindexchanged="ddlStatus_SelectedIndexChanged">
            <asp:ListItem Value="" Selected="True">==全部==</asp:ListItem>
            <asp:ListItem Value="1">已生成</asp:ListItem>
            <asp:ListItem Value="2">已确认</asp:ListItem>
            <asp:ListItem Value="3">已完成</asp:ListItem>
            <asp:ListItem Value="4">已取消</asp:ListItem>

          </asp:DropDownList>
    </span>
    </dd>

      <dd class="cx"><asp:Button ID="lbtnSearch" runat="server" CssClass="scbtn" onclick="btnSearch_Click" Text="查询"></asp:Button>   
 </dd>
     <dd class="toolbar1">
        <asp:LinkButton ID="btnExport" runat="server" CssClass="save" onclick="btnExport_Click">   <li><span><img src="../images/t04.png" /></span>导出Execl</li></asp:LinkButton>
        </dd>
    </dl>
            <!--列表-->

	  <table class="tablelistl">
    	<thead>
    	<tr>
        <th width="40px;">序号</th>
		<th  width="110px;">订单号</th>
        <th width="8%">订单状态</th>
	<th width="100px;">下单总金额<br /><font color="red">(<asp:Literal ID="Literal_pa" runat="server"></asp:Literal>)</font></th>
		<th width="100px;">调整金额<br /><font color="red">(<asp:Literal ID="Literal_ra" runat="server"></asp:Literal>)</font></th>
         <th width="100px;">实际总金额<br /><font color="red">(<asp:Literal ID="Literal_oa" runat="server"></asp:Literal>)</font></th>
		<th width="130px;">下单时间</th>
         <th width="90px;">操作</th>     
        </tr>
        </thead>
        <tbody>
<asp:Repeater ID="rptList" runat="server">
<ItemTemplate>
        <tr>
            <td><%# pageSize * page + Container.ItemIndex + 1 - pageSize%></td>
            <td><%# Eval("order_no")%></td>
             <td ><%#GetOrderStatus(Convert.ToInt32(Eval("status")))%></td>
                <td><%# MyConvert(Eval("payable_amount"))%></td>	
             <td><%# MyConvert(Eval("real_amount"))%></td>	
            <td><%# MyConvert(Eval("order_amount"))%></td>		
            <td><%#string.Format("{0:g}",Eval("add_time"))%></td>
            <td><a href="my_order_info.aspx?action=Edit&id=<%#Eval("id")%>" class="tablelink"> 查看详情</a> 
           &nbsp;&nbsp;<asp:LinkButton ID="lbtnDelCa" runat="server" CommandArgument='<%# Eval("id")%>' OnClientClick="return confirm('是否真的要取消该订单吗？')" onclick="lbtnDelCa_Click"><%# Convert.ToInt32(Eval("status")) < 2 ? "<font color =red>[取消订单]</font>" : ""%></asp:LinkButton>
 
        
            </td>
        </tr> 		
 	   </ItemTemplate>
<FooterTemplate>
  <%#rptList.Items.Count == 0 ? "<tr><td align=\"center\" colspan=\"8\"><font color=red>暂无记录</font></td></tr>" : ""%>
   </tbody>
    </table>
</FooterTemplate>
</asp:Repeater> 

    <div class="pagelist">
  <div class="l-btns">
    <span>显示</span><asp:TextBox ID="txtPageNum" runat="server" CssClass="pagenum" onkeydown="return checkNumber(event);" ontextchanged="txtPageNum_TextChanged" AutoPostBack="True"></asp:TextBox><span>条/页</span>
  </div>
  <div id="PageContent" runat="server" class="default"></div>
</div>
      
    </div>
    </form>
</body>
</html>
