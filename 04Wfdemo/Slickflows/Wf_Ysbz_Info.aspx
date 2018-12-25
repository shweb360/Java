<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Wf_Ysbz_Info.aspx.cs" Inherits="Slickflow.WebDemo.Slickflows.Wf_Ysbz_Info" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link href="../Scripts/webuploader/webuploader.css" rel="stylesheet" />  
    <link href="../Skin/default.css?v=1.1" rel="stylesheet" />
    <script src="../js/jquery-1.10.2.min.js" type="text/javascript"></script>
    <script src="../js/layer/layer.js" type="text/javascript"></script>
    <script src="../js/layout.js" type="text/javascript"></script>
    <link href="../js/My97DatePicker/skin/WdatePicker.css" rel="stylesheet" />
    <script src="../js/My97DatePicker/WdatePicker.js" type="text/javascript"></script>

    
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
        

        <!--内容-->
        <!--导航栏-->
        <div class="location">
            <a href="FlowList.aspx" class="home"><i></i><span>首页</span></a>
            <i class="arrow"></i>
            <span>流程管理</span>
            <i class="arrow"></i>
            <span>预算编制流程</span>
        </div>

        <!--/导航栏-->

        <!--内容-->
        <div class="tab-content">
                       
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
                <dt data-options="field:'state'">附件</dt>
                <dd>
                  
                    <a href="<%=strUrl.Replace("~","") %>">下载</a>
                   
                </dd>
                 <%
                 } %>
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
                <input type="hidden" id="hiddenInstanceId" value="" runat="server" />
                <input type="hidden" id="hiddenNextFlowIsOK" value="" runat="server" />
                <input type="hidden" id="hiddenPerformField" value="" runat="server" />
                <input type="hidden" id="hiddenActivityInstanceID" value="" runat="server" />               
                <input name="btnReturn" type="button" value="返回" class="btn yellow" onclick="javascript: history.back(-1);" />
            </div>
            <div class="clear"></div>
        </div>
        <!--/工具栏-->
    </form>
    
</body>
</html>
