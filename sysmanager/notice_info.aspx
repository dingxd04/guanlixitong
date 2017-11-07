<%@ Page Language="C#" AutoEventWireup="true" CodeFile="notice_info.aspx.cs" Inherits="sysmanager_notice_info" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<title>查看公告</title>
   <link href="../css/style.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
<div class="mainindext">
	<div class="placet" style="text-align:center;">
  <span> <asp:Literal ID="Littitle" runat="server"></asp:Literal> </span>
    </div>
    <div class="winfotime">
发布时间：<asp:Literal ID="LitAddTime" runat="server"></asp:Literal> 浏览次数:<asp:Literal ID="LitClickCount" runat="server"></asp:Literal>
    </div> 
    <div class="winfoc">
        <asp:Literal ID="LitContent" runat="server"></asp:Literal>
    </div>
    </div>
    </form>
</body>
</html>
