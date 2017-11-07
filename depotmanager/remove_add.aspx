<%@ Page Language="C#" AutoEventWireup="true" CodeFile="remove_add.aspx.cs" Inherits="depotmanager_remove_add" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
 <title>商品入库管理</title>
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
                t_width = 980;
                t_height = 460;
                t_title = '查看商品详情';
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
    <li><a href="#">商品入库管理</a></li>
    </ul>
    </div>
    <div class="rightinfo">
   <dl class="seachform"> 
    <dd><label>商品名称</label> <span class="single-select"><asp:TextBox ID="txtNote_no" runat="server" Width="220" CssClass="scinput"></asp:TextBox></span></dd>   
     <dd><label>商品种类</label>  
    <span class="rule-single-select">
      <asp:DropDownList ID="ddlproduct_category_id"  runat="server" AutoPostBack="True" onselectedindexchanged="ddlproduct_category_id_SelectedIndexChanged">
          </asp:DropDownList>
    </span>
    </dd>

       <dd class="cx"><asp:Button ID="lbtnSearch" runat="server" CssClass="scbtn" onclick="btnSearch_Click" Text="查询"></asp:Button>   
</dd>
    
    </dl>
		        <!--列表-->
<asp:Repeater ID="rptList" runat="server">
<HeaderTemplate>
     <table class="imgtable">
    	<thead>
    	<tr>
        <th width="50px;">序号</th>
		<th width="140px;">商品图片</th>
		<th >商品名称</th>
          <th >备注</th>
		 <th>商品类别</th>
         <th width="80px;">进货单价</th>
		<th width="80px;">销售单价</th>
		<th width="80px;">当前库存</th>
         <th width="120px;">操作</th>
        </tr>
        </thead>
        <tbody>
	 </HeaderTemplate>
<ItemTemplate> 
        <tr>
            <td><%# pageSize * page + Container.ItemIndex + 1 - pageSize%></td>
              <td class="imgtd"><img src="<%# Eval("product_url")%>" width="100" height="100" onMouseOver="toolTip('<img src=<%# Eval("product_url")%>>')" onMouseOut="toolTip()" /></td>
             <td><%# Eval("product_name")%></td>
             	<td><%# Eval("remark")%></td>	
             <td><%#new ps_product_category().GetTitle(Convert.ToInt32(Eval("product_category_id")))%></td>	      
            <td><%# MyConvert(Eval("go_price"))%></td>	
            <td><%# MyConvert(Eval("salse_price"))%></td>		
            <td><%# MyZF(Eval("product_num"))%>&nbsp;&nbsp;<%# Eval("dw")%></td>		
            <td><%--<a href="javascript:opdg('info','product_info.aspx?id=<%#Eval("id")%>');" class="tablelink"> 查看</a>--%>  &nbsp;&nbsp;<a href="remove_add_add.aspx?action=Edit&id=<%#Eval("id")%>&page=<%=page%>" class="tablelink"><font color =green>[入库]</font></a></td>
        </tr>      
	   </ItemTemplate>
<FooterTemplate>
  <%#rptList.Items.Count == 0 ? "<tr><td align=\"center\" colspan=\"9\"><font color=red><font color=red>暂无记录</font></font></td></tr>" : ""%>
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
  <script type="text/javascript" src="../js/ToolTip.js"></script>
</html>
