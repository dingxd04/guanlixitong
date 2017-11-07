<%@ Page Language="C#" AutoEventWireup="true" CodeFile="home.aspx.cs" Inherits="home" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
 <title>系统首页</title>
<link href="css/style.css" rel="stylesheet" type="text/css" />
<script type="text/javascript" src="js/jquery/jquery-1.10.2.min.js"></script>
<script type="text/javascript" src="js/lhgdialog/lhgdialog.js?skin=idialog"></script>
<script type="text/javascript">
    function opdg(s_type, s_url) {
        var t_width, t_height, t_title, t_url, t_id;
        t_id = 'w_1';
        switch (s_type) {
            case 'info':
                t_width = 980;
                t_height = 500;
                t_title = '查看通知公告';
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
    <span>位置：</span>
    <ul class="placeul">
    <li><a href="#">系统首页</a></li>
    </ul>
    </div>
    <div class="mainbox">    
    <div class="mainleft">
        <div class="leftinfo">
    <div class="listtitle">装备信息概览 &nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Literal ID="Lit_mysalse" runat="server"></asp:Literal></div>      
    <div class="maintj">  
    <object classid="clsid:D27CDB6E-AE6D-11cf-96B8-444553540000" codebase="http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=7,0,19,0" width="740" height="460">
  <param name="movie" value="ok.swf" />
  <param name="quality" value="high" />
  <embed src="ok.swf" quality="high" pluginspage="http://www.macromedia.com/go/getflashplayer" type="application/x-shockwave-flash" width="740" height="460"></embed>
</object>  
    </div>
    
    </div>
    <!--leftinfo end-->
    
    </div>
    <!--mainleft end-->
    <div class="mainright">
    <div class="dflist">
    <div class="listtitle"><a href="sysmanager/notice_list.aspx" class="more1">更多</a>通知公告</div>    
    <ul class="newlist">
    <asp:Repeater ID="rptList_notice" runat="server">
    <ItemTemplate> 
    <li><a href="javascript:opdg('info','sysmanager/notice_info.aspx?id=<%#Eval("id")%>');" title="<%# Eval("title")%>"><%# Eval("title").ToString().Length > 18 ? Eval("title").ToString().Substring(0, 18) + "..." : Eval("title").ToString()%></a></li>
    </ItemTemplate>
<FooterTemplate>
  <%#rptList_notice.Items.Count == 0 ? "<li><font color=red>暂无记录</font></li>" : ""%>
</FooterTemplate>
</asp:Repeater>  
    </ul>        
    </div> 
    </div>
    <!--mainright end--> 
    </div>


    </form>
</body>
</html>
