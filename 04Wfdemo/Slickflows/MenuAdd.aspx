<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MenuAdd.aspx.cs" Inherits="Slickflow.WebDemo.Slickflows.MenuAdd" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>新增资源</title>
        <link href="../Skin/default.css?v=1.1" rel="stylesheet" />
    <script src="../js/jquery-1.10.2.min.js" type="text/javascript"></script>
    <script src="../js/layer/layer.js" type="text/javascript"></script>
    <script src="../js/layout.js" type="text/javascript"></script>
    <link href="../js/My97DatePicker/skin/WdatePicker.css" rel="stylesheet" />
    <script src="../js/My97DatePicker/WdatePicker.js" type="text/javascript"></script>
</head>
<body>
<form id="form1" runat="server">
        <!--导航栏-->
        <div class="location">
            <a href="FlowList.aspx" class="home"><i></i><span>首页</span></a>
            <i class="arrow"></i>
            <span>角色管理</span>
            <i class="arrow"></i>
            <span>新增角色</span>
        </div>

        <!--/导航栏-->

        <!--内容-->
        <div class="tab-content">
           
            <dl>
                <dt>资源名称</dt>
                <dd>
                    <input runat="server" type="text" value="" id="TxtMenuName" class="input normal"/>

                </dd>
            </dl>
            <dl>
                <dt>资源Url</dt>
                <dd>
                    <input runat="server" type="text" value="" id="TxtMenuUrl" class="input normal" />
                </dd>
            </dl>
                    
        </div>
        <!--/内容-->

        <!--工具栏-->
        <div class="page-footer">
            <div class="btn-list" style="left:120px">               
                <asp:Button ID="btnSave" runat="server" Text="保存" class="btn" OnClick="btnSave_Click"></asp:Button>                            
                <input name="btnReturn" type="button" value="返回" class="btn yellow" onclick="javascript: history.back(-1);" />
                <span id="span_flow_step"></span>
            </div>
            <div class="clear"></div>
        </div>
        <!--/工具栏-->
    </form>
    <script type="text/javascript">

        function MenuAddVerify() {
            var menuName = document.getElementById("TxtMenuName").value;
            var menuUrl = document.getElementById("TxtMenuUrl").value;

            if (roleCode == "" || roleCode == null) {
                alert("角色代码不能为空");
                return false;
            }
            else if (roleName == "" || roleName == null) {
                alert("角色名称不能为空");
                return false;
            }

            return true;
        }
    </script>
</body>
</html>
