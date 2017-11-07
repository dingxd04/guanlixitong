<%@ Page Language="C#" AutoEventWireup="true" CodeFile="remove_add_add.aspx.cs" Inherits="depotmanager_remove_add_add" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
   <title>商品入库</title>
<script type="text/javascript" src="../js/jquery/jquery-1.10.2.min.js"></script>
<script type="text/javascript" src="../js/lhgdialog/lhgdialog.js?skin=idialog"></script>
<script type="text/javascript" src="../js/jquery/Validform_v5.3.2_min.js"></script>
<script type="text/javascript" src="../js/layout.js"></script>
<script type="text/javascript" src="../js/pinyin.js"></script>
<link href="../css/style.css" rel="stylesheet" type="text/css" />
<script type="text/javascript">
    $(function () {
        //初始化表单验证
        $("#form1").initValidform();
    });

</script>
</head>
<body>
    <form id="form1" runat="server">
	<div class="place">
    <span>位置：</span>
    <ul class="placeul">
    <li><a href="../home.aspx">首页</a></li>
    <li><a href="remove_add.aspx">商品管理</a></li>
    <li><a href="#">商品入库</a></li>
    </ul>
    </div>

    <div class="formbody">   
    <div class="formtitle"><span>商品信息</span></div>
    <!--/商品信息-->
<div class="tab-content">
   <dl>
    <dt>入库数量</dt>
     <dd>   <asp:TextBox ID="txtproduct_num" runat="server" CssClass="input small" datatype="n" sucmsg=" "></asp:TextBox>&nbsp;&nbsp;<%=dw %>
      <span class="Validform_checktip">*</span></dd>
  </dl>
   <dl>
    <dt>当前库存</dt>
     <dd>   <asp:Literal ID="Litproduct_num" runat="server"></asp:Literal>&nbsp;&nbsp;<%=dw %>
     </dd>
  </dl>
    <dl>
    <dt>商品类别</dt>
    <dd> 

   <asp:Literal id="ddlproduct_category_id" runat="server"></asp:Literal>  

     </dd>
  </dl>

    <dl >
    <dt>商品名称</dt>
    <dd><asp:Literal ID="txtproduct_name" runat="server"></asp:Literal>

    </dd>
  </dl>
  <dl>
    <dt>上传商品图片</dt>
    <dd>
        <asp:Image ID="txtImgUrl" runat="server" Height="300px" Width="300px" />   
    </dd>
  </dl>
  <dl>
    <dt>进货单价(单位：<%=dw %>)</dt>
    <dd>   <asp:Literal ID="txtgo_price" runat="server" ></asp:Literal>&nbsp;&nbsp;元
  </dd>
  </dl> 
<dl>
    <dt> 销售单价(单位：<%=dw %>)</dt>
     <dd>   <asp:Literal ID="txtsalse_price" runat="server"></asp:Literal>&nbsp;&nbsp;元
</dd>
  </dl>
   
 
</div>
<!--/商品信息-->    
    </div>

    <!--工具栏-->
<div class="page-footer">
  <div class="btn-list">
    <asp:Button ID="btnSubmit" runat="server" Text="提交保存" CssClass="btn" onclick="btnSubmit_Click"  />
    <input name="btnReturn" type="button" value="返回上一页" class="btn yellow" onclick="javascript:history.back(-1);" />
  </div>
  <div class="clear"></div>
</div>
<!--/工具栏-->

    </form>
</body>
</html>
