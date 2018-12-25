<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Wf_Cglc_Approval.aspx.cs" Inherits="Slickflow.WebDemo.Slickflows.Wf_Cglc_Approval" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
 <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>采购流程办理</title>
    <link href="../Skin/default.css?v=1.1" rel="stylesheet" />
    <script src="../js/jquery-1.10.2.min.js" type="text/javascript"></script>
    <script src="../js/layer/layer.js" type="text/javascript"></script>
    <script src="../js/layout.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
        

        <!--内容-->
        <!--导航栏-->
        <div class="location">
            <a href="FlowList.aspx" class="home"><i></i><span>首页</span></a>
            <i class="arrow"></i>
            <span>流程管理</span>
            <i class="arrow"></i>
            <span>采购申请流程</span>
        </div>

        <!--/导航栏-->

        <!--内容-->
        <div class="tab-content">
            <dl style="display:none;">
                <dt>采购流程GUID</dt>
                <dd>
                    <input runat="server" type="text" disabled="disabled" id="txtProcessGUID" class="input normal" />
                </dd>
            </dl>
            
            <dl>
                <dt>采购物品</dt>
                <dd>
                    <input runat="server" type="text" value="" id="txtApplyTitle" class="input normal" style="width:80px"/> 件(个)
                </dd>
            </dl>
            <dl>
                <dt>数量</dt>
                <dd>
                    <input runat="server" type="text" value="" id="txtApplyNumber" class="input normal" />
                </dd>
            </dl>        
            
            <dl>
                <dt>计划时间</dt>
                <dd>
                    <input runat="server" type="text" value="" id="txtApplyDate" class="input normal Wdate" onfocus="WdatePicker({minDate:'%y-%M-%d',onpicked:setToDate})" style="cursor: pointer" />
                </dd>
            </dl>
            <dl>
                <dt>申请采购说明</dt>
                <dd>
                    <textarea runat="server" id="txtApplyContent" class="input normal" style="height:100px;width:320px;"> </textarea>

                </dd>
            </dl>
            <dl><% if(!string.IsNullOrEmpty(strUrl)) {
                         %>
                <dt data-options="field:'state'">附件</dt>
                <dd>
                  
                    <a href="<%=strUrl.Replace("~","") %>">下载</a>
                   
                </dd>
                 <%
                 } %>
            </dl>
             <dl>
                <dt></dt>
                <dd>
                    <asp:Label ID="labTip" runat="server" style="color:red;"></asp:Label><br />
                    <asp:Label ID="KsfzRemark" runat="server"></asp:Label><br />
                    <asp:Label ID="FgldRemark" runat="server"></asp:Label><br />
                    <asp:Label ID="CgjbrRemark" runat="server"></asp:Label><br />
                    <asp:Label ID="ZzRemark" runat="server"></asp:Label><br />                   
                </dd>
            </dl>         
        </div>
        <!--/内容-->

        <!--工具栏-->
        <div class="page-footer">
            <div class="btn-list">
                <input type="hidden" id="hiddenNextActivityPerformers" value="" runat="server" />
                <input type="hidden" id="hiddenInstanceId" value="" runat="server" />
                <input type="hidden" id="hiddenNextFlowIsOK" value="" runat="server" />
                <input type="hidden" id="hiddenPerformField" value="" runat="server" />
                <input type="hidden" id="hiddenActivityInstanceID" value="" runat="server" />
                <input type="hidden" id="hiddenTaskID" value="" runat="server" />
                <input type="hidden" id="hiddenSendbackRemark" value="" runat="server" />
                <input name="btnSelectFlowStep" id="btnSubmit" type="button" value="提交" class="btn" onclick="SeleteFlowInfo()" runat="server"/>
                <asp:Button ID="btnSendNext" runat="server" Text="送往下一步" CssClass="btn blue" OnClick="btnSendNext_Click" Style="display: none" />
                <input name="btnReturn" type="button" value="返回" class="btn yellow" onclick="javascript: history.back(-1);" />
                    <input name="btnFlowback" id="btnFlowback" type="button" value="流程退回" class="btn" onclick="BtnFlowback()" runat="server"/>
                <asp:Button ID="btnSendbackProcess" runat="server" Text="流程退回" CssClass="btn blue" OnClick="btnSendbackProcess_Click"  Style="display:none"/>
            </div>
            <div class="clear"></div>
        </div>
        <!--/工具栏-->
    </form>
    <script type="text/javascript">
        function SeleteFlowInfo() {
            var ProcessGUID = $("#txtProcessGUID").val();
            
            var flag = '<%=Slickflow.WebDemo.Business.WorkFlows.IsStartedByBgsUser(int.Parse(this.hiddenInstanceId.Value),1)? "0" : flag%>';
            var InstanceId = $("#hiddenInstanceId").val();



            $("#hiddenNextFlowIsOK").val("");
            $.layer({
                type: 2,
                closeBtn: [0, true],
                shadeClose: false,
                shade: [0],
                border: [5, 0.3, '#000', true],
                offset: ['10px', ''],
                area: ['420px', '410px'],
                title: "转下一步.选择步骤及办理人",
                iframe: { src: 'FlowStepSelect.aspx?Step=task&ProcessGUID=' + ProcessGUID + "&instanceId=" + InstanceId + "&condition=" + "flag-" + parseInt(flag) },
                close: function (index) {
                    layer.close(index);
                },
                beforeClose: function (index) {
                    var selectOK = layer.getChildFrame('#hiddenOK', index).val();
                    if (selectOK == "OK") {
                        var _hiddenNextActivityPerformers = layer.getChildFrame('#hiddenNextActivityPerformers', index).val();//选中的步骤人员
                        if (_hiddenNextActivityPerformers != undefined && _hiddenNextActivityPerformers != null && _hiddenNextActivityPerformers != "") {
                            $("#hiddenNextActivityPerformers").val(_hiddenNextActivityPerformers);
                        }
                        var hiddenNextActivityPerformers = $("#hiddenNextActivityPerformers").val();
                        if (hiddenNextActivityPerformers != undefined && hiddenNextActivityPerformers != null && hiddenNextActivityPerformers != "") {
                            $("#hiddenNextFlowIsOK").val("OK");
                            $("#btnSendNext").click();
                        } else {
                            $("#hiddenNextFlowIsOK").val("");
                            $("#hiddenNextActivityPerformers").val("");
                        }
                    }
                },
                end: function () {

                }
            });
        }
        function BtnFlowback() {

            $.layer({
                type: 2,
                closeBtn: [0, true],
                shadeClose: false,
                shade: [0],
                border: [5, 0.3, '#000', true],
                offset: ['10px', ''],
                area: ['480px', '300px'],
                title: "流程回退",
                iframe: { src: 'FlowSendbackProcess.aspx' },
                close: function (index) {
                    layer.close(index);
                },
                beforeClose: function (index) {
                 
                    var SendOK = layer.getChildFrame('#hiddenSendOK', index).val();
                    var Remark = layer.getChildFrame('#hiddenRemark', index).val();
                    if (SendOK == "OK") {
                        $("#<%= hiddenSendbackRemark.ClientID %>").val(Remark);
                        $("#btnSendbackProcess").click();
                    }
                },
                end: function () {
                }
            });
        }
    </script>
</body>
</html>
