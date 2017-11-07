<%@ Page Language="C#" AutoEventWireup="true" CodeFile="product_edit.aspx.cs" Inherits="depotmanager_product_edit" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
   <title>编辑商品</title>
<script type="text/javascript" src="../js/jquery/jquery-1.10.2.min.js"></script>
<script type="text/javascript" src="../js/lhgdialog/lhgdialog.js?skin=idialog"></script>
<script type="text/javascript" src="../js/jquery/Validform_v5.3.2_min.js"></script>
<script type="text/javascript" src="../js/swfupload/swfupload.js"></script>
<script type="text/javascript" src="../js/swfupload/swfupload.queue.js"></script>
<script type="text/javascript" src="../js/swfupload/swfupload.handlers.js"></script>
<script type="text/javascript" src="../js/layout.js"></script>
<script type="text/javascript" src="../js/pinyin.js"></script>
<link href="../css/style.css" rel="stylesheet" type="text/css" />
<script type="text/javascript">
    $(function () {
        //初始化表单验证
        $("#form1").initValidform();

        //初始化上传控件
        $(".upload-img").each(function () {
            $(this).InitSWFUpload({ sendurl: "../tools/upload_ajax.ashx", flashurl: "../js/swfupload/swfupload.swf" });
        });
        //设置封面图片的样式
        $(".photo-list ul li .img-box img").each(function () {
            if ($(this).attr("src") == $("#hidFocusPhoto").val()) {
                $(this).parent().addClass("selected");
            }
        });
        //设置封面图片的样式
        $(".photo-list ul li .img-box img").each(function () {
            if ($(this).attr("src") == $("#hidFocusPhoto").val()) {
                $(this).parent().addClass("selected");
            }
        });
    });

</script>
</head>
<body>
    <form id="form1" runat="server">
	<div class="place">
    <span>位置：</span>
    <ul class="placeul">
    <li><a href="../home.aspx">首页</a></li>
    <li><a href="depot_manager.aspx">商品管理</a></li>
    <li><a href="#">编辑商品</a></li>
    </ul>
    </div>

    <div class="formbody">   
    <div class="formtitle"><span>商品信息</span></div>
    <!--/商品信息-->
<div class="tab-content">

    <dl>
    <dt>商品类别</dt>
    <dd> 
    <span class="rule-single-select">
   <asp:DropDownList id="ddlproduct_category_id" runat="server" datatype="*" errormsg="请选择商品类别" sucmsg=" "  AutoPostBack="True" onselectedindexchanged="ddlproduct_category_id_SelectedIndexChanged"></asp:DropDownList>  
    </span>
    <span class="Validform_checktip">*</span>
     </dd>
  </dl>

    <dl >
    <dt>商品名称</dt>
    <dd><asp:TextBox ID="txtproduct_name" runat="server"  MaxLength="200" CssClass="input normal" datatype="*"  errormsg=""  Width="300"></asp:TextBox>
    <span class="Validform_checktip">*</span>
    </dd>
  </dl>
  <dl>
    <dt>上传商品图片</dt>
    <dd>
         <asp:TextBox ID="txtImgUrl" runat="server" CssClass="input normal upload-path" />
      <div class="upload-box upload-img"></div>  <span class="Validform_checktip">*</span> <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtImgUrl"
                ErrorMessage="请选择您要上传的图片！"></asp:RequiredFieldValidator>
    </dd>
  </dl>
  <dl>
    <dt>进货单价(单位：<%=dw %>)</dt>
    <dd>   <asp:TextBox ID="txtgo_price" runat="server" CssClass="input small" onkeyup="clearNoNum(this)"  MaxLength="8" datatype="*" sucmsg="" errormsg="请输入正确的金额" ></asp:TextBox>&nbsp;&nbsp;元
      <span class="Validform_checktip">*</span></dd>
  </dl> 
<dl>
    <dt> 销售单价(单位：<%=dw %>)</dt>
     <dd>   <asp:TextBox ID="txtsalse_price" runat="server" CssClass="input small" onkeyup="clearNoNum(this)"  MaxLength="8" datatype="*" sucmsg="" errormsg="请输入正确的金额"></asp:TextBox>&nbsp;&nbsp;元
      <span class="Validform_checktip">*</span></dd>
  </dl>
    <dl>
    <dt>当前库存</dt>
     <dd>   <asp:Literal ID="txtproduct_num" runat="server"></asp:Literal>&nbsp;&nbsp;<%=dw %>
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
