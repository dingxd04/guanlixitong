<%@ Page Language="C#" AutoEventWireup="true" CodeFile="sales_rep.aspx.cs" Inherits="select_sales_rep" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>销售明细报表</title>    
<style type="text/css">
body{
	OVERFLOW:SCROLL;
	margin-left: 0px;
	margin-top: 0px;
	margin-right: 0px;
	margin-bottom: 0px;
	font-family: "宋体";
	font-size: 14px;
	line-height: 20px;
	color: #000000;
}
table {
	font-family: "宋体";
	font-size: 14px;
	line-height: 20px;
	color: #000000;
}
</style>
</head>
<body>
    <form id="form1" runat="server">
	  <table width="98%"  border="1" align="center" cellpadding="5" cellspacing="1" bgcolor="#CACACA">
          <tr bgcolor="#EAEAEA">
            <td height="30" colspan="12" align="center" bgcolor="#FFFFFF">
            <span style="font-size:18px;line-height: 25px;"><b>销售明细报表</b></span></td>
          </tr>
                 <tr bgcolor="#FFFFFF"> 
        
               <td align="center" colspan="12" bgcolor="#C0C0C0">    <b>
                商家地区: <font color="#FE5200"><asp:Literal ID="Literal1" runat="server"></asp:Literal></font>
                下单商家：<font color="#FE5200"><asp:Literal ID="Literal2" runat="server"></asp:Literal></font>
                起始日期：<font color="#FE5200"><asp:Literal ID="Literal4" runat="server"></asp:Literal></font> 
                结束日期：<font color="#FE5200"><asp:Literal ID="Literal5" runat="server"></asp:Literal></font>  
    
               </b></td>
                   </tr>
          <tr bgcolor="#FFFFFF"> 
            <td align="center"  bgcolor="#C0C0C0"><b>序号</b></td>
              <td align="center"  bgcolor="#C0C0C0"><b>订单号</b></td>
		 <td align="center"  bgcolor="#C0C0C0"><b>商家地区</b></td>
         <td align="center"  bgcolor="#C0C0C0"><b>下单商家</b></td>
		 <td align="center"  bgcolor="#C0C0C0"><b>销售时间</b></td>
		 <td align="center"  bgcolor="#C0C0C0"><b>商品名称</b></td>
		 <td align="center"  bgcolor="#C0C0C0"><b>进货单价</b></td>
		 <td align="center"  bgcolor="#C0C0C0"><b>销售单价</b></td>
         <td align="center"  bgcolor="#C0C0C0"><b>销售数量</b></td>
        <td align="center"  bgcolor="#C0C0C0"><b>销售金额</b></td>
       <td align="center"  bgcolor="#C0C0C0"><b>利润</b></td>
        <td align="center"  bgcolor="#C0C0C0"><b>操作员</b></td>
        </tr>
       <asp:Repeater ID="repCategory" runat="server">
        <ItemTemplate>
         <tr bgcolor="#FFFFFF" >
            <td align="center"> <%# Container.ItemIndex + 1%></td>
            <td align="left" style="vnd.ms-excel.numberformat:@" ><%# Eval("note_no")%></td>			
           <td align="center"><%# Convert.ToInt32(Eval("depot_category_id")) == 0 ? "<font color=red>公司操作</font>" : new ps_depot_category().GetTitle(Convert.ToInt32(Eval("depot_category_id")))%></td>
            <td align="center"><%# Convert.ToInt32(Eval("depot_id")) == 0  ? "<font color=red>公司操作</font>" : new ps_depot().GetTitle(Convert.ToInt32(Eval("depot_id")))%></td>
            <td align="center"><%#string.Format("{0:g}",Eval("add_time"))%></td> 
            <td align="center"><%# Eval("goods_title")%></td>	
            <td align="center"><%# MyConvert(Eval("goods_price"))%></td>
             <td align="center"><%# MyConvert(Eval("real_price"))%></td>	
            <td align="left"><%# Eval("quantity")%>&nbsp;&nbsp;<%#new ps_product_category().GetDW(Convert.ToInt32(new ps_here_depot().GetTPid(Convert.ToInt32(Eval("goods_id")))))%></td>	
             <td align="center"><%#  MyConvert(Convert.ToDecimal(Eval("real_price"))* Convert.ToInt32(Eval("quantity")))%></td>
              <td align="center"><%#  MyConvert((Convert.ToDecimal(Eval("real_price")) - Convert.ToDecimal(Eval("goods_price"))) * Convert.ToInt32(Eval("quantity")))%></td>
              <td ><%#new ps_manager().GetName(Convert.ToInt32(Eval("user_id")))%></td>	
	
          </tr>
       </ItemTemplate>
       </asp:Repeater> 
              <tr bgcolor="#FFFFFF"> 
            <td align="center"  bgcolor="#C0C0C0"><b>合计</b></td>

                <td align="center"  bgcolor="#C0C0C0"><b></b></td>
            <td align="center"  bgcolor="#C0C0C0"><b></b></td>
            <td align="center"  bgcolor="#C0C0C0"><b></b></td>
                   <td align="center"  bgcolor="#C0C0C0"><b></b></td>
            <td align="center"  bgcolor="#C0C0C0"><b></b></td>
            <td align="center"  bgcolor="#C0C0C0"><b></b></td> 
            <td align="center"  bgcolor="#C0C0C0"><b><%--<font color="red"><asp:Literal ID="Literal_go_price" runat="server"></asp:Literal></font>--%></b></td>
            <td align="center"  bgcolor="#C0C0C0"><b><%--<font color="red"><asp:Literal ID="Literal_zongprice" runat="server"></asp:Literal></font>--%></b></td>
             <td align="center"  bgcolor="#C0C0C0"><b><font color="red"><asp:Literal ID="Literal_hj" runat="server"></asp:Literal></font></b></td>
             <td align="center"  bgcolor="#C0C0C0"><b><font color="red"><asp:Literal ID="Literal_lrprice" runat="server"></asp:Literal></font></b></td>
               <td align="center"  bgcolor="#C0C0C0"><b></b></td> 

        </tr>  
		 </table>
    </form>
</body>
</html>

