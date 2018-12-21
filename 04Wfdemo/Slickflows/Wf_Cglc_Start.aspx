﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Wf_Cglc_Start.aspx.cs" Inherits="Slickflow.WebDemo.Slickflows.Wf_Cglc_Start" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>采购流程发起</title>
    <link href="../Skin/default.css?v=1.1" rel="stylesheet" />
    <script src="../js/jquery-1.10.2.min.js" type="text/javascript"></script>
    <script src="../js/layer/layer.js" type="text/javascript"></script>
    <script src="../js/layout.js" type="text/javascript"></script>
    <link href="../js/My97DatePicker/skin/WdatePicker.css" rel="stylesheet" />
    <script src="../js/My97DatePicker/WdatePicker.js" type="text/javascript"></script>
    <link href="../Scripts/webuploader/webuploader.css" rel="stylesheet" />   
    <script src="../Scripts/webuploader/webuploader.js"></script>
    <script type="text/javascript">

        function setToDate() {
            var date = $("#txtFromDate").val();
            var d = new Date(date);
            var days = Math.ceil($("#txtDays").val());
            d.setDate(d.getDate() + parseInt(days));
            var t = formatDate(d.toString(), "YYYY-MM-DD");
            $("#txtToDate").val(t);
        }

    </script>
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
                    <input runat="server" type="text" value="" id="txtApplyTitle" class="input normal" />
                </dd>
            </dl>
            <dl>
                <dt>数量</dt>
                <dd>
                    <input runat="server" type="text" value="" id="txtApplyNumber" style="width:80px" class="input normal" onblur="check(this)"  onkeyup="this.value=this.value.replace(/[^0-9.]/g,'')" /> 件(个)
                </dd>
            </dl>        
            
            <dl>
                <dt>计划时间</dt>
                <dd>
                    <input runat="server" type="text" value="" id="txtApplyDate" class="input normal Wdate" onfocus="WdatePicker()" style="cursor: pointer" />
                </dd>
            </dl>
            <dl>
                <dt>申请采购说明</dt>
                <dd>
                    <textarea runat="server" id="txtApplyContent" class="input normal" style="height:100px;width:320px;"> </textarea>

                </dd>
            </dl>
            <dl>
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
                
            </dl>
            
             <dl class="none">
                <dt>部门经理意见</dt>
                <dd>
                    <input runat="server" type="text" value="" id="txtDepmanagerRemark" class="input normal disabled" disabled="disabled" /></dd>
            </dl>
            <dl class="none">
                <dt>主管总监意见</dt>
                <dd>
                    <input runat="server" type="text" value="" id="txtDirectorRemark" class="input normal disabled" disabled="disabled" /></dd>
            </dl>
            <dl class="none">
                <dt>副总经理意见</dt>
                <dd>
                    <input runat="server" type="text" value="" id="txtDeputyGeneralRemark" class="input normal disabled" disabled="disabled" /></dd>
            </dl>
            <dl class="none">
                <dt>总经理意见</dt>
                <dd>
                    <input runat="server" type="text" value="" id="txtGeneralManagerRemark" class="input normal disabled" disabled="disabled" /></dd>
            </dl>
           

        </div>
        <!--/内容-->

        <!--工具栏-->
        <div class="page-footer">
            <div class="btn-list">
                <input type="hidden" id="hiddenNextActivityPerformers" value="" runat="server" />
                <input type="hidden" id="hiddenNextFlowIsOK" value="" runat="server" />
                <input name="btnSelectFlowStep" type="button" value="提交" class="btn" onclick="SeleteFlowInfo()" />
                <asp:Button ID="btnSave" runat="server" Text="提交保存" CssClass="btn yellow" OnClick="btnSave_Click" Style="display: none" />
                <input name="btnReturn" type="button" value="返回" class="btn yellow" onclick="javascript: history.back(-1);" />

                <span id="span_flow_step"></span>
            </div>
            <div class="clear"></div>
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
                duplicate :true,
                pick: {
                    id: '#picker',
                    //只能选择一个文件上传
                    multiple: false
                },
                duplicate: false
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
            $("#hiddenNextFlowIsOK").val("");
            var ProcessGUID = $("#txtProcessGUID").val();
            var flag = '<%=LoginDeptID == 19 ? "0" : flag%>';
           
            var LeaveType = "1";
            var FromDate = $("#txtFromDate").val();
            var ToDate = $("#txtToDate").val();

            if (ProcessGUID == null || ProcessGUID == "") {
                alert("请填写流程GUID");
                return false;
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
                iframe: { src: 'FlowStepSelect.aspx?Step=start&ProcessGUID=' + ProcessGUID + "&condition=" + "flag-" + flag },
                close: function (index) {
                    layer.close(index);
                },
                beforeClose: function (index) {
                    
                    $("#hiddenNextFlowIsOK").val("");
                    var selectOK = layer.getChildFrame('#hiddenOK', index).val();
                    if (selectOK == "OK") {
                        var _hiddenNextActivityPerformers = layer.getChildFrame('#hiddenNextActivityPerformers', index).val();//选中的步骤人员
                        if (_hiddenNextActivityPerformers != undefined && _hiddenNextActivityPerformers != null && _hiddenNextActivityPerformers != "") {
                            $("#hiddenNextActivityPerformers").val(_hiddenNextActivityPerformers);
                        }
                        var hiddenNextActivityPerformers = $("#hiddenNextActivityPerformers").val();
                        if (hiddenNextActivityPerformers != undefined && hiddenNextActivityPerformers != null && hiddenNextActivityPerformers != "") {
                            $("#hiddenNextFlowIsOK").val("OK");
                            $("#btnSave").click();
                        } else {
                            $("#hiddenNextFlowIsOK").val("");
                            $("#hiddenNextActivityPerformers").val("");
                        }
                        console.log(_hiddenNextActivityPerformers);
                    }
                },
                end: function () {
                }
            });
        }
        function check(e) {
            var re = /^\d+(?=\.{0,1}\d+$|$)/
            if (e.value != "") {
                if (!re.test(e.value)) {
                    alert("请输入正确的数字");
                    e.value = "";
                    e.focus();
                }
            }
        }
    </script>
</body>
</html>
