<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Wf_Ht_Approval.aspx.cs" Inherits="Slickflow.WebDemo.Slickflows.Wf_Ht_Approval" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
 <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>合同流程办理</title>
    <link href="../Scripts/webuploader/webuploader.css" rel="stylesheet" />  
    <link href="../Skin/default.css?v=1.1" rel="stylesheet" />
    <script src="../js/jquery-1.10.2.min.js" type="text/javascript"></script>
    <script src="../js/layer/layer.js" type="text/javascript"></script>
    <script src="../js/layout.js" type="text/javascript"></script>
    <link href="../js/My97DatePicker/skin/WdatePicker.css" rel="stylesheet" />
    <script src="../js/My97DatePicker/WdatePicker.js" type="text/javascript"></script>
    <script src="../Scripts/webuploader/webuploader.js"></script>
    <style>
        .tab-content dl dt{ width:190px;
        }
        .tab-content dl dd { margin-left:200px;
        }
        .webuploader-pick{ padding:3px 6px !important;}
    </style>
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
            <span>合同流程</span>
        </div>

        <!--/导航栏-->

        <!--内容-->
        <div class="tab-content">
            <dl style="display:none;">
                <dt>合同流程GUID</dt>
                <dd>
                    <input runat="server" type="text" value="0071eb6a-cceb-4571-a88c-79bc47feb749" disabled="disabled" id="txtProcessGUID" class="input normal" />
                </dd>
            </dl>
            <dl>
                <dt>合同名称</dt>
                <dd>
                    <input runat="server" type="text" value="" id="txtApplyTitle" class="input normal" />

                </dd>
            </dl>
            <dl>
                <dt>合同类型</dt>
                <dd>                    
                    <div class="rule-single-select">
                        <select id="selectApplyType" runat="server">
                            <option value="0">--请选择--</option>
                            <option value="1">采购合同</option>
                            <option value="2">课题研究合同</option>
                            <option value="3">汽车租赁合同</option>
                            <option value="4">设备租赁合同</option>   
                            <option value="5">翻译服务合同</option>
                            <option value="6">房屋租赁合同</option>                            
                            <option value="7">技术咨询合同</option>
                            <option value="8">建筑装饰工程施工合同</option>
                            <option value="9">拍摄制作合同</option>
                            <option value="10">上海市行政机关物业管理服务合同  </option>
                            <option value="11">审计业务约定书      </option>  
                            <option value="12">图书编写委托合同   </option>
                            <option value="13">委托服务合同     </option>
                            <option value="14">委托培训合同   </option>
                            <option value="15">委托市场调查合同   </option>
                            <option value="16">系统维护服务合同</option>
                        </select>
                    </div>
                </dd>
            </dl>
            <dl>
                <dt>甲方</dt>
                <dd>
                    <input runat="server" type="text" value="" id="txtPartyA" class="input normal" />

                </dd>
            </dl>
            <dl>
                <dt>乙方</dt>
                <dd>
                   <input runat="server" type="text" value="" id="txtPartyB" class="input normal" />
                </dd>
            </dl>
            <dl>
                <dt>合同签订日期</dt>
                <dd>
                    <input runat="server" type="text" value="" id="txtSigningDate" class="input normal Wdate" onfocus="WdatePicker({minDate:'%y-%M-%d',onpicked:setToDate})" style="cursor: pointer" />
                </dd>
            </dl>
             <dl>
                <dt>合同期限</dt>
                <dd>
                    <input runat="server" type="text" value="" id="txtTimeLimit" class="input normal" style="width:100px"/> 月
                </dd>
            </dl>
            <dl>
                <dt>合同金额</dt>
                <dd>
                    <input runat="server" type="text" value="" id="txtAmount" class="input normal" style="width:100px"  />元
                </dd>
            </dl>
             <dl>
                <dt>合同备注</dt>
                <dd>
                   <textarea runat="server" id="txtRemark" class="input normal" style="height:100px;width:320px;"> </textarea>
                </dd>
            </dl>
            <dl><% if(!string.IsNullOrEmpty(strUrl)) {
                         %>
                <dt data-options="field:'state'">附件</dt>
                <dd>                  
                    <a href="<%=strUrl.Replace("~","") %>">下载</a><br />
                   <asp:Label ID="labTip" runat="server" style="color:red;"></asp:Label>
                </dd>
                 <%
                 } %>
            </dl>
            <dl>
                <% if (isUpload)
                   {%>
                <dt data-options="field:'state'">上传附件</dt>
                <dd>
                    <div id="uploader" class="wu-example">
                        <!--用来存放文件信息-->
                        <div id="thelist" class="uploader-list"></div>
                        <div class="btns">
                        <div id="picker" style="height:20px; width:120px;">选择文件</div>
                       
                        </div>
                    </div>                
                    <input runat="server" type="hidden"  id="txtFilePath"/>
                    <input runat="server" type="hidden" id="txtFileName"/>
                    
                 </dd>
                   <%
                   } %> 
            </dl>
               <dl>
                <dt></dt>
                <dd>
                    <asp:Label ID="Label1" runat="server" style="color:red;"></asp:Label><br />
                    <asp:Label ID="KzRemark" runat="server"></asp:Label><br />
                    <asp:Label ID="CwzgRemark" runat="server"></asp:Label><br />
                    <asp:Label ID="BgsfzrRemark" runat="server"></asp:Label><br />
                    <asp:Label ID="FgzzRemark" runat="server"></asp:Label><br />   
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
                <input name="btnSelectFlowStep" id="btnSubmit" type="button" value="提交" class="btn" onclick="SeleteFlowInfo()" runat="server" />
                <asp:Button ID="btnSendNext" runat="server" Text="送往下一步" CssClass="btn blue" OnClick="btnSendNext_Click" Style="display:none"/>
                <input name="btnReturn" type="button" value="返回" class="btn yellow" onclick="javascript: history.back(-1);" />

                <input name="btnFlowback" id="btnFlowback" type="button" value="流程退回" class="btn" onclick="BtnFlowback()" runat="server"/>
                <asp:Button ID="btnSendbackProcess" runat="server" Text="流程退回" CssClass="btn blue" OnClick="btnSendbackProcess_Click" Style="display:none"/>
            </div>
            <div class="clear"></div>
        </div>
        <!--/工具栏-->
    </form>
    <script type="text/javascript">
        function SeleteFlowInfo() {
            var ProcessGUID = $("#txtProcessGUID").val();
           
            var InstanceId = $("#hiddenInstanceId").val();
            var flag = '<%=Slickflow.WebDemo.Business.WorkFlows.IsStartedByBgsUser(int.Parse(this.hiddenInstanceId.Value),2)? "0" : flag%>';


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
