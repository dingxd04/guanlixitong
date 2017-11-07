<%@ Page Language="C#" AutoEventWireup="true" CodeFile="order_collect_rep.aspx.cs" Inherits="depotmanager_order_collect_rep" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>未配送商品汇总表</title>    
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
            <td height="30" colspan="4" align="center" bgcolor="#FFFFFF">
            <span style="font-size:18px;line-height: 25px;"><b>未配送商品汇总表</b></span></td>
          </tr>
                 <tr bgcolor="#FFFFFF"> 
        
               <td align="center" colspan="4" bgcolor="#C0C0C0">
               <b>
                商品类别：<font color="#FE5200"><asp:Literal ID="Literal6" runat="server"></asp:Literal></font>            
               </b></td>
    </tr>
          <tr bgcolor="#FFFFFF"> 
            <td align="center"  bgcolor="#C0C0C0"><b>序号</b></td>
		 <td align="center"  bgcolor="#C0C0C0"><b>商品类别</b></td>
		 <td align="center"  bgcolor="#C0C0C0"><b>商品名称</b></td>
		 <td align="center"  bgcolor="#C0C0C0"><b>订购数量</b></td>
        </tr>
       <asp:Repeater ID="repCategory" runat="server">
        <ItemTemplate>
         <tr bgcolor="#FFFFFF" >
            <td align="center"> <%# Container.ItemIndex + 1%></td>
            <td align="center"><%#new ps_product_category().GetTitle(Convert.ToInt32(Eval("product_category_id")))%></td>	
            <td align="center"><%# Eval("goods_title")%></td>	
            <td align="center"><%# MyZF(Eval("zongquantity"))%>&nbsp;&nbsp;<%# Eval("dw")%></td>	
          </tr>
       </ItemTemplate>
       </asp:Repeater>   
		 </table>
    </form>
</body>
</html>
