<%@ Page Language="C#" AutoEventWireup="true" CodeFile="sales_list.aspx.cs" Inherits="select_sales_list" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<title>销售查询</title>
<link href="../css/style.css" rel="stylesheet" type="text/css" />

<script type="text/javascript" src="../js/jquery/jquery-1.10.2.min.js"></script>
<script type="text/javascript" src="../js/layout.js"></script>
<script type="text/javascript" src="../js/lhgcore.min.js"></script>
<script type="text/javascript" src="../js/lhgcalendar.min.js"></script>
<script type="text/javascript">
    J(function () {
        J('#txtstart_time').calendar({ btnBar: true });
        J('#txtstop_time').calendar({ btnBar: true });
    }); 
</script> 
</head>
<body>
    <form id="form1" runat="server">
	<div class="place">
    <span>位置:</span>
    <ul class="placeul">
    <li><a href="../home.aspx">首页</a></li>
    <li><a href="#">销售查询</a></li>
    </ul>
    </div>   
    <div class="rightinfo">      
    <dl class="seachform">   
    <dd><label>订单号</label><span class="single-select"><asp:TextBox ID="txtNote_no" runat="server" Width="120" CssClass="scinput"></asp:TextBox></span></dd>
	<dd><label>销售起始日期</label><span class="single-select"><input  type="text" class="timeinput" id="txtstart_time" name="txtstart_time" readonly="readonly" runat="server" /></span></dd>
	<dd><label>销售结束日期</label><span class="single-select"><input type="text" class="timeinput" id="txtstop_time" name="txtstop_time" readonly="readonly" runat="server"/></span></dd>
      <dd><label>商家地区</label>  
    <span class="rule-single-select">
<asp:DropDownList ID="ddldepot_category_id"  runat="server" AutoPostBack="True" onselectedindexchanged="ddldepot_category_id_SelectedIndexChanged">
</asp:DropDownList>
    </span>
    </dd>
    <dd><label>下单商家</label>  
    <span class="rule-single-select">
<asp:DropDownList ID="ddldepot_id"  runat="server" AutoPostBack="True" onselectedindexchanged="ddldepot_id_SelectedIndexChanged">
</asp:DropDownList>
    </span>
    </dd>

      <dd class="cx"> <asp:Button ID="lbtnSearch" runat="server" CssClass="scbtn" onclick="btnSearch_Click" Text="查询"></asp:Button>   
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
		<th width="60px;">商家地区</th>
        <th>下单商家</th>
		<th width="110px;">销售时间</th>
		<th>商品名称</th>
		<th width="60px;">进货单价<%--<br /><font color="red">(<asp:Literal ID="Literal_go_price" runat="server"></asp:Literal>)</font>--%></th>
		<th width="60px;">销售单价<%--<br /><font color="red">(<asp:Literal ID="Literal_zongprice" runat="server"></asp:Literal>)</font>--%></th>
        <th width="60px;">销售数量<%--<br /><font color="red">(<asp:Literal ID="Literal_zongprice_sj" runat="server"></asp:Literal>)</font>--%></th>
        <th width="100px;">销售金额<br /><font color="red">(<asp:Literal ID="Literal_hj" runat="server"></asp:Literal>)</font></th>
        <th width="100px;">利润<br /><font color="red">(<asp:Literal ID="Literal_lrprice" runat="server"></asp:Literal>)</font></th>
       <th width="60px;">操作员</th>

        </tr>
        </thead>
        <tbody>
        <asp:Repeater ID="rptList" runat="server">
<ItemTemplate> 
        <tr>
            <td><%# pageSize * page + Container.ItemIndex + 1 - pageSize%></td>
             <td><%# Eval("note_no")%></td>
           <td><%# Convert.ToInt32(Eval("depot_category_id")) == 0 ? "<font color=red>公司操作</font>" : new ps_depot_category().GetTitle(Convert.ToInt32(Eval("depot_category_id")))%></td>
            <td><%# Convert.ToInt32(Eval("depot_id")) == 0  ? "<font color=red>公司操作</font>" : new ps_depot().GetTitle(Convert.ToInt32(Eval("depot_id")))%></td>
            <td><%#string.Format("{0:g}",Eval("add_time"))%></td> 
            <td><%# Eval("goods_title")%></td>	
            <td><%# MyConvert(Eval("goods_price"))%></td>
             <td><%# MyConvert(Eval("real_price"))%></td>	
            <td><%# Eval("quantity")%>&nbsp;&nbsp;<%#new ps_product_category().GetDW(Convert.ToInt32(new ps_here_depot().GetTPid(Convert.ToInt32(Eval("goods_id")))))%></td>	
             <td><%#  MyConvert(Convert.ToDecimal(Eval("real_price"))* Convert.ToInt32(Eval("quantity")))%></td>
              <td><%#  MyConvert((Convert.ToDecimal(Eval("real_price")) - Convert.ToDecimal(Eval("goods_price"))) * Convert.ToInt32(Eval("quantity")))%></td>
              <td ><%#new ps_manager().GetName(Convert.ToInt32(Eval("user_id")))%></td>	
        </tr>      
	   </ItemTemplate>
<FooterTemplate>
  <%#rptList.Items.Count == 0 ? "<tr><td align=\"center\" colspan=\"12\"><font color=red><font color=red>暂无记录</font></font></td></tr>" : ""%>
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
