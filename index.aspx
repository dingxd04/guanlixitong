<%@ Page Language="C#" AutoEventWireup="true" CodeFile="index.aspx.cs" Inherits="index" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>欢迎登录装备综合管理系统</title>
<link href="css/style.css" rel="stylesheet" type="text/css" />
<script type="text/javascript" src="js/jquery/jquery-1.10.2.min.js"></script>
<script src="js/cloud.js" type="text/javascript"></script>
<script  type="text/javascript">
    $(function () {
        //检测IE
        if ('undefined' == typeof (document.body.style.maxHeight)) {
            window.location.href = 'ie6update.html';
        }
        $('.loginbox').css({ 'position': 'absolute', 'left': ($(window).width() - 692) / 2 });
        $(window).resize(function () {
            $('.loginbox').css({ 'position': 'absolute', 'left': ($(window).width() - 692) / 2 });
        })
    });
</script> 
<link href="js/win/win.css" rel="stylesheet" type="text/css" />
<script src="js/win.js" type="text/javascript"></script>
<script language="javascript" type="text/javascript">
    function Check() {
        var Name = form1.txtUserName.value;
        var PW = form1.txtPassword.value;
        
        if (Name == "") {
            win.errorInfo('账号不能为空!', null, null, '提示')
            return false;
        }
        if (PW == "") {
            win.errorInfo('密码不能为空!', null, null, '提示')
            return false;
        }

        return true;
        this.form1.Submit();
    }
    </script> 
</head>
<body style="background-color:#1c77ac; background-image:url(images/light.png); background-repeat:no-repeat; background-position:center top; overflow:hidden;">
    <form id="form1" runat="server">
 <div id="mainBody">
      <div id="cloud1" class="cloud"></div>
      <div id="cloud2" class="cloud"></div>
</div>  

<div class="logintop">    
    <span>欢迎登录装备综合管理系统</span>  
</div>
    
<div class="loginbody"> 
    <span class="systemlogo"></span>       
    <div class="loginbox">  
    <ul>
    <li><input name="txtUserName" ID="txtUserName" runat="server" type="text" class="loginuser" value="" /></li>
    <li><input name="txtPassword" ID="txtPassword" runat="server" type="password" class="loginpwd" value="" /></li>
    <li><asp:Button ID="btnSubmit" runat="server" Text="登 录" CssClass="loginbtn" onclick="btnSubmit_Click"  OnClientClick="return Check();"/></li>
    </ul>  
    </div>   
    </div>   
<div class="loginbm">版权所有 &copy;  All Rights Reserved. 厦门测控站 &nbsp;&nbsp;&nbsp;&nbsp;技术支持：<a href="http://dingxd04.blog.163.com" target="_blank">叮咚</a></div>
    </form>
</body>
</html>
