<%@ Page Language="C#" AutoEventWireup="true" CodeFile="adddepot_rep.aspx.cs" Inherits="select_adddepot_rep" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>入库信息报表</title>    
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
            <td height="30" colspan="9" align="center" bgcolor="#FFFFFF">
            <span style="font-size:18px;line-height: 25px;"><b>入库信息表</b></span></td>
          </tr>
                 <tr bgcolor="#FFFFFF"> 
        
               <td align="center" colspan="9" bgcolor="#C0C0C0">
               <b>
           
                起始日期：<font color="#FE5200"><asp:Literal ID="Literal4" runat="server"></asp:Literal></font> 
                结束日期：<font color="#FE5200"><asp:Literal ID="Literal5" runat="server"></asp:Literal></font>  
                商品类别：<font color="#FE5200"><asp:Literal ID="Literal6" runat="server"></asp:Literal></font>
            
               </b></td>
    </tr>
          <tr bgcolor="#FFFFFF"> 
            <td align="center"  bgcolor="#C0C0C0"><b>序号</b></td>
        	 <td align="center"  bgcolor="#C0C0C0"><b>单号</b></td>	
		 <td align="center"  bgcolor="#C0C0C0"><b>商品类别</b></td>
		 <td align="center"  bgcolor="#C0C0C0"><b>商品名称</b></td>
	   <td align="center"  bgcolor="#C0C0C0"><b>进货单价</b></td>
		 <td align="center"  bgcolor="#C0C0C0"><b>销售单价</b></td>
		 <td align="center"  bgcolor="#C0C0C0"><b>入库数量</b></td>
        <td align="center"  bgcolor="#C0C0C0"><b>入库时间</b></td>
         <td align="center"  bgcolor="#C0C0C0"><b>操作员</b></td>

        </tr>
       <asp:Repeater ID="repCategory" runat="server">
        <ItemTemplate>
         <tr bgcolor="#FFFFFF" >
            <td align="center"> <%# Container.ItemIndex + 1%></td>
            <td align="left" style="vnd.ms-excel.numberformat:@" ><%# Eval("note_no")%></td>
            <td align="center"><%#new ps_product_category().GetTitle(Convert.ToInt32(Eval("product_category_id")))%></td>	
            <td align="center"><%# Eval("product_name")%></td>	
           <td align="center"><%# MyConvert(Eval("go_price"))%></td>	
            <td align="center"><%# MyConvert(Eval("salse_price"))%></td>		
            <td align="center"><%# MyZF(Eval("product_num"))%>&nbsp;&nbsp;<%# Eval("dw")%></td>	
             <td align="center"><%#string.Format("{0:g}",Eval("add_time"))%></td>
             <td align="center"><%#new ps_manager().GetName(Convert.ToInt32(Eval("user_id")))%></td>	
          </tr>
       </ItemTemplate>
       </asp:Repeater>   
		 </table>
    </form>
</body>
</html>

