<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MenuList.aspx.cs" Inherits="Slickflow.WebDemo.Slickflows.MenuList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>资源管理</title>
    <link href="../Skin/default.css" rel="stylesheet" />
    <script src="../js/jquery-1.10.2.min.js" type="text/javascript"></script>
    <script src="../js/layer/layer.js" type="text/javascript"></script>
    <script src="../js/layout.js" type="text/javascript"></script>
    <script src="../js/comm.js" type="text/javascript"></script>
      <style>
        .Btn {
            background:#16a0d3;border:none; color:white; height:30px; line-height:30px; width:40px; cursor:pointer;
        }
        .selectbtn{background:#16a0d3;border:none; color:white; width:30px; height:22px; line-height:22px;cursor:pointer;}
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <!--导航栏-->
        <div class="location">
           <%-- <a href="javascript:history.back(-1);" class="back"><i></i><span>返回上一页</span></a>--%>
            <a href="FlowList.aspx" class="home"><i></i><span>首页</span></a>
            <i class="arrow"></i>
            <span>资源管理</span>
        </div>
        <!--/导航栏-->

        <!--工具栏-->
        <div class="toolbar-wrap">
            <div id="floatHead_1" class="toolbar">
                <div class="l-list" style="float:right">
                    <ul class="icon-list">
                        <li>
                            <asp:Button ID="btn_add" runat="server" OnClick="add_Click" Text="新增"  CssClass="Btn"/>
                        </li>
                        <li style="margin-left: 10px; border-left: 1px solid #e1e1e1;">                            
                            <asp:Button ID="Button2" runat="server" OnClick="delete_Click" Text="删除"  CssClass="Btn"/>
                        </li>

                    </ul>
                </div>
            </div>
        </div>
        <!--/工具栏-->

        <!--内容-->
        <div class="content-tab-wrap">
            <div id="floatHead" class="content-tab">
                <div class="content-tab-ul-wrap">
                    <ul>
                        <li><a href="javascript:;" onclick="tabs(this);" class="selected">资源列表</a></li>
                    </ul>
                </div>
            </div>
        </div>

        <!--代办流程-->
        <div class="tab-content">
            <table width="100%" border="1" cellspacing="0" cellpadding="0" class="ltable">
                <tr>
                    <th align="center" style="width: 80px;">
                    <input id="btnSelectAll" class="selectbtn" onclick="SelectAllCheckBox()" type="button" runat="server" value="全选"/>&nbsp;&nbsp;
                    <input id="btnReSelect" class="selectbtn" onclick="ReSelectCheckBox()" type="button" runat="server" value="反选" /></th>
                    <%--<th align="center">序号</th>--%>
                    <th align="center">资源名称</th>
                    <th align="center">URL</th>
                    <th align="center">操作</th>
                </tr>
                <asp:Repeater ID="RepMenuList" runat="server">
                    <ItemTemplate>
                        <tr>
                            <td align="center">
                                <asp:CheckBox ID="cbxSonger" runat="server" /></td>
                            <%--<td align="center">
                                <asp:Label ID="Label1" runat="server" Text='<%# Eval("ID") %>'></asp:Label></td>--%>
                            <td align="left"><%#Eval("MenuName") %></td>
                            <td align="left"><%#Eval("MenuUrl") %></td>
                            <td align="center">
                                <a href="javascript:ShowMenuOpinion(<%#Eval("ID") %>)">编辑</a>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </table>
        </div>
        <!--/代办流程-->
        <!--/列表-->
    </form>
    <script type="text/javascript">
        function ShowMenuOpinion(ID) {
            $.layer({
                type: 2,
                closeBtn: [0, true],
                shadeClose: false,
                shade: [0],
                border: [5, 0.3, '#000', true],
                offset: ['10px', ''],
                area: ['540px', '420px'],
                title: "编辑资源信息",
                iframe: {
                    src: 'MenuEdit.aspx?ID=' + ID
                },
                close: function (index) {
                    layer.close(index);
                },
                beforeClose: function (index) {
                },
                end: function () {

                }
            });
        }

    </script>
</body>
</html>
