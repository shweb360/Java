<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserAdd.aspx.cs" Inherits="Slickflow.WebDemo.Slickflows.UserAdd" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>新增用户</title>
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
            <span>用户管理</span>
            <i class="arrow"></i>
            <span>新增用户</span>
        </div>

        <!--/导航栏-->

        <!--内容-->
        <div class="tab-content">
           
            <dl>
                <dt>用户名</dt>
                <dd>
                    <input runat="server" type="text" value="" id="TxtLoginName" class="input normal"/>

                </dd>
            </dl>
            <dl>
                <dt>初始密码</dt>
                <dd>
                    <input runat="server" type="text" value="" id="TxtPassword" class="input normal" />
                </dd>
            </dl>
            <dl>
                <dt>再输一次</dt>
                <dd>
                    <input runat="server" type="text" value="" id="TxtRePassword" class="input normal" />
                </dd>
            </dl>
             <dl>
                <dt>姓名</dt>
                <dd>
                    <input runat="server" type="text" value="" id="TxtUserName" class="input normal" />

                </dd>
            </dl>
            <dl>
                <dt>性别</dt>
                <dd>
                    <div class="rule-single-select">
                        <select id="selectLeaveType" runat="server">                            
                            <option value="1">男</option>
                            <option value="2">女</option>                           
                        </select>
                    </div>
                </dd>
            </dl>
            
            <dl>
                <dt>手机</dt>
                <dd>
                    <input runat="server" type="text" value="" id="TxtMobile" class="input normal" />
                </dd>
            </dl>
           <dl>
                <dt>邮箱</dt>
                <dd>
                    <input runat="server" type="text" value="" id="TxtEMail" class="input normal" />
                </dd>
            </dl>
            <dl>
                <dt>工作证卡号</dt>
                <dd>
                    <input runat="server" type="text" value="" id="TxtCardID" class="input normal" />
                </dd>
            </dl>
            <dl>
                <dt>用户角色</dt>
                <dd>
                    <div class="rule-single-select">
                        <select id="SelectRole" runat="server">                            
                                               
                        </select>
                    </div>
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

        function UserAddVerify() {
            var loginName = document.getElementById("TxtLoginName").value;
            var password = document.getElementById("TxtPassword").value;
            var repassword = document.getElementById("TxtRePassword").value;
            var userRealName = document.getElementById("TxtUserName").value;
            var mobile = document.getElementById("TxtMobile").value;
            var email = document.getElementById("TxtEMail").value;
            var btnSave = document.getElementById("btnSave");
            var cardID = document.getElementById("TxtCardID").value;

            var mobileReg = /1[3-8]+\d{9}/;
            var emailReg = new RegExp("^[a-z0-9]+([._\\-]*[a-z0-9])*@([a-z0-9]+[-a-z0-9]*[a-z0-9]+.){1,63}[a-z0-9]+$"); 
            if (loginName == "" || loginName == null) {
                alert("用户名不能为空");
                return false;
            }
            else if (password == "" || password == null) {
                alert("密码不能为空");
                return false;
            }
            else if (repassword == "" || repassword == null || repassword != password) {
                alert("对不起，两次输入密码不一样");
                return false;
            }
            else if (userRealName == "" || userRealName == null) {
                alert("姓名不能为空");
                return false;
            }
            else if (mobile == "" || mobile == null || mobileReg.test(mobile) == false) {
                alert("请输入合法的手机号码");
                return false;
            }
            else if (email == "" || email == null || emailReg.test(email) == false) {
                alert("请输入合法的邮箱");
                return false;
            }
            else if (cardID == "" || cardID == null) {
                alert("工作证卡号不能为空");
                return false;
            }
            
            return true;
        }
    </script>

</body>
</html>
