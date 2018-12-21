<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Wf_Ysbz_Approval.aspx.cs" Inherits="Slickflow.WebDemo.Slickflows.Wf_Ysbz_Approval" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
 <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>预算编制流程</title>
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
            <span>预算编制</span>
        </div>

        <!--/导航栏-->

        <!--内容-->
        <div class="tab-content">
            <dl style="display:none">
                <dt>预算编制流程GUID</dt>
                <dd>
                    <input runat="server" type="text" disabled="disabled" id="txtProcessGUID" class="input normal" />
                </dd>
            </dl>
            
            <dl>
                <dt>标题</dt>
                <dd>
                    <input runat="server" type="text" value="" id="txtApplyTitle" class="input normal" />

                </dd>
            </dl>
            <dl>
                <dt>截止日期</dt>
                <dd>
                    <input runat="server" type="text" value="" id="txtApplyDate" class="input normal Wdate" onfocus="WdatePicker({minDate:'%y-%M-%d',onpicked:setToDate})" style="cursor: pointer" />
                </dd>
            </dl>
             <dl>
                <dt>内容</dt>
                <dd>
                    <textarea runat="server" id="txtApplyContent" class="input normal" style="height:100px;width:320px;"> </textarea>

                </dd>
            </dl>
            <dl><% if(!string.IsNullOrEmpty(strUrl)) {
                         %>
                <dt data-options="field:'state'" runat="server" id="dtA">附件</dt>
                <dd>
                  
                    <a href="<%=strUrl.Replace("~","") %>">下载</a>
                   
                </dd>
                 <%
                 } %>
            </dl>
              <dl><% if (!string.IsNullOrEmpty(strUrl2))
                    {
                         %>
                <dt data-options="field:'state'" runat="server" id="dtB">附件</dt>
                <dd>
                  
                    <a href="<%=strUrl2.Replace("~","") %>">下载</a>
                   
                </dd>
                 <%
                 } %>
            </dl>   
            <div style="margin-left:160px;">
               <asp:Repeater ID="Repeater1" runat="server">
               <ItemTemplate>
                <table>       
                    <tr>            
                        <td>【<%#Eval("DeptName")%>】<%#Eval("CreatedUserName")%> &nbsp;</td>
                        <td>
                           <%#Getpath(Eval("FilePath").ToString())%>
                        </td>    
                    </tr>           
                </table>
                </ItemTemplate>
            </asp:Repeater>
            </div>    
            <dl runat="server" id="showUploder">
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
                    <asp:Label ID="labTip" runat="server" style="color:red;"></asp:Label><br />
                    <asp:Label ID="AKsfzrRemark" runat="server"></asp:Label><br />
                    <asp:Label ID="AKsfgldRemark" runat="server"></asp:Label><br />
                    <asp:Label ID="ZzRemark" runat="server"></asp:Label><br />
                    <asp:Label ID="BKsfzrRemark" runat="server"></asp:Label><br />
                    <asp:Label ID="BKsfgldRemark" runat="server"></asp:Label><br />

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
                <input type="hidden" id="hiddenIsCwzg" value="false" runat="server" />

                <input name="btnSelectFlowStep" id="btnSubmit" type="button" value="提交" class="btn" onclick="SeleteFlowInfo()" runat="server"/>
                <asp:Button ID="btnSendNext" runat="server" Text="送往下一步" CssClass="btn blue" OnClick="btnSendNext_Click" Style="display: none" />
                <input name="btnReturn" type="button" value="返回" class="btn yellow" onclick="javascript: history.back(-1);" />
                <input name="btnFlowback" id="btnFlowback" type="button" value="流程退回" class="btn" onclick="BtnFlowback()" runat="server"/>
                <asp:Button ID="btnSendbackProcess" runat="server" Text="流程退回" CssClass="btn blue" OnClick="btnSendbackProcess_Click" Style="display:none"/>
            </div>
            <div class="clear">
               
            </div>
        </div>
        <!--/工具栏-->
    </form>
    <script type="text/javascript">

        jQuery(function () {
            var $ = jQuery,
                $list = $('#thelist'),
                state = 'pending',
                uploader;
            uploader = WebUploader.create({
                // 不压缩image  
                resize: false,
                // swf文件路径  
                swf: '../Scripts/webuploader/Uploader.swf',
                // 文件接收服务端。  
                server: '../Ashx/FileUpload.ashx',
                //限制只能上传一个文件
                fileNumLimit: 1,
                pick: {
                    id: '#picker',
                    //只能选择一个文件上传
                    multiple: false
                }
            });
            // 当有文件添加进来的时候  
            uploader.on('fileQueued', function (file) {
                $list.append('<div id="' + file.id + '" class="item">' +
                    '<h4 class="info">' + file.name + '</h4>' +
                    '<p class="state">等待上传...</p>' +
                '</div>');
                uploader.upload();
            });
            uploader.on('uploadSuccess', function (file, res) {
                $('#' + file.id).find('p.state').text('上传成功');
                var obj = JSON.parse(res._raw);
                if (obj.FilePath) {
                    $("#<%= txtFilePath.ClientID %>").val(obj.FilePath);
                    $("#<%= txtFileName.ClientID %>").val(obj.FileName);

                }
                else {
                    alert(obj.msg);
                }
            });
            uploader.on('uploadError', function (file) {
                $('#' + file.id).find('p.state').text('上传出错');
            });
            uploader.on('uploadComplete', function (file) {
                $('#' + file.id).find('.progress').fadeOut();
            });
        });

        function SeleteFlowInfo() {
            var ProcessGUID = $("#txtProcessGUID").val();
            var flag = "1";
            var InstanceId = $("#hiddenInstanceId").val();
            $("#hiddenNextFlowIsOK").val("");

            var loginRole = '<%=LoginRoleID%>';
            if (loginRole == 16) {
                if (!confirm("请确认已全部汇总完毕，并提交站长？")) {
                    return;
                }                
            }
            
            $.layer({
                type: 2,
                closeBtn: [0, true],
                shadeClose: false,
                shade: [0],
                border: [5, 0.3, '#000', true],
                offset: ['10px', ''],
                area: ['420px', '410px'],
                title: "转下一步.选择步骤及办理人",
                iframe: { src: 'FlowStepSelect.aspx?Step=task&ProcessGUID=' + ProcessGUID + "&instanceId=" + InstanceId + "&condition=" + "flag-" + parseInt(flag)},
                close: function (index) {
                    layer.close(index);
                },
                beforeClose: function (index) {
                    //debugger;
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
                    //debugger;
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
