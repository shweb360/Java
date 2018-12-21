<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FlowSendbackProcess.aspx.cs" Inherits="Slickflow.WebDemo.Slickflows.FlowSendbackProcess" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>流程回退</title>
    <link href="../Skin/default.css?v=1.1" rel="stylesheet" />
    <link href="../Skin/layout.css?v=0.1" rel="stylesheet" />
    <link href="../js/zTree/zTreeStyle/zTreeStyle.css?v=0.1" rel="stylesheet" />
    <script src="../js/base.js" type="text/javascript"></script>
    <script src="../js/jquery-1.8.0.min.js?v=0.1" type="text/javascript"></script>
    <script src="../js/zTree/jquery.ztree.core-3.5.min.js?v=0.1" type="text/javascript"></script>
    <script src="../js/zTree/jquery.ztree.excheck-3.5.min.js?v=0.1" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div class="tab-content">      
            <dl>
                <dt>回退原因：</dt>
                <dd>
                    <textarea id="txtRemark" class="input normal" style="height:100px;width:280px;"> </textarea>
                </dd>
            </dl>
             <div style="margin-top: 20px; text-align: center; line-height: 30px;">
              
                <input type="hidden" id="hiddenSendOK" value="" runat="server" />
                <input type="hidden" id="hiddenRemark" value="" runat="server" />
        
                <input type="button" value="确定" class="btn" onclick="SendbackOK();" />&nbsp;&nbsp;
                <input type="button" value="取消" class="btn" onclick="CloseWindowPage();" />
        </div>
        </div>
    </div>
         <input type="hidden" id="hiddenY" value="OK" runat="server" />
    </form>
    <script type="text/javascript">
        function SendbackOK() {
            
            $("#hiddenSendOK").val("");
            $("#hiddenRemark").val("")
            var txtRemark = $("#txtRemark").val();
            if (txtRemark == "" || txtRemark == null || txtRemark==undefined) {
                alert("请输入回退原因");
                return;
            }
            $("#hiddenSendOK").val("OK");
            $("#hiddenRemark").val(txtRemark)
            CloseWindowPage();
        }

        //关闭窗口
        function CloseWindowPage() {
            var index = parent.layer.getFrameIndex(window.name);
            parent.layer.close(index);
        }
    </script>
</body>
</html>
