<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FlowStepSelect.aspx.cs" Inherits="Slickflow.WebDemo.Slickflows.FlowStepSelect" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width" />
    <title></title>
    <link href="../Skin/default.css?v=1.1" rel="stylesheet" />
    <link href="../Skin/layout.css?v=0.1" rel="stylesheet" />
    <link href="../js/zTree/zTreeStyle/zTreeStyle.css?v=0.1" rel="stylesheet" />
    <script src="../js/base.js" type="text/javascript"></script>
    <script src="../js/jquery-1.8.0.min.js?v=0.1" type="text/javascript"></script>
    <script src="../js/zTree/jquery.ztree.core-3.5.min.js?v=0.1" type="text/javascript"></script>
    <script src="../js/zTree/jquery.ztree.excheck-3.5.min.js?v=0.1" type="text/javascript"></script>

    <script type="text/javascript">
        function GetCheckedAll() {
           
            var nodesArray = [];
            var treeObj = $.fn.zTree.getZTreeObj("ztree_container");
            var nodes = treeObj.getCheckedNodes(true);
            if (nodes.length > 0) {
                for (var i = 0; i < nodes.length; i++) {
                    var node = nodes[i];
                    nodesArray.push(node.id);
                }
            }
            $("#hiddenNextActivityPerformers").val(nodesArray.join(','));
            var NextActivityPerformers = $("#hiddenNextActivityPerformers").val();
            if (step == undefined || step == null || step == "" || step == "0" || step.length < 1) {
                alert("请选择办理步骤或办理人员");
                return;
            }
        }

        function SelectOK() {

            $("#hiddenOK").val("");

            var nodesArray = [];
            var treeObj = $.fn.zTree.getZTreeObj("ztree_container");
            var nodes = treeObj.getCheckedNodes(true);
            if (nodes.length > 0) {
                for (var i = 0; i < nodes.length; i++) {
                    var node = nodes[i];
                    nodesArray.push(node.id);
                }
            }
            $("#hiddenNextActivityPerformers").val(nodesArray.join(','));
            var nextActivityPerformers = $("#hiddenNextActivityPerformers").val();
            if (nextActivityPerformers == undefined || nextActivityPerformers == null || nextActivityPerformers == "" || nextActivityPerformers == "0" || nextActivityPerformers.length < 1) {
                alert("请选择办理步骤或办理人员");
                return;
            }

            $("#hiddenOK").val("OK");
            CloseWindowPage();
        }

        //关闭窗口
        function CloseWindowPage() {
            var index = parent.layer.getFrameIndex(window.name);
            parent.layer.close(index);
        }

    </script>


</head>
<body>
    <form id="form1" runat="server">
        <div style="margin-left:10px;margin-top:10px;display:none" id="checkBox">
        <span id="checkAllTrue" style="font-size:13px;cursor:pointer;border:1px solid #ccc;padding:2px;">全选</span>
        <span id="checkAllFalse" style="font-size:13px;cursor:pointer;border:1px solid #ccc;padding:2px;">取消</span>        
         </div>
        <div id="ztree_container" class="ztree">
        </div>
        
        <asp:Literal ID="LiteralMSG" runat="server"></asp:Literal>
        <div style="margin-top: 20px; float: right; text-align: right; line-height: 30px;">
            <input type="hidden" id="hiddenStepGuid" value="" runat="server" />
            <input type="hidden" id="hiddenStepUser" value="" runat="server" />
            <input type="hidden" id="hiddenOK" value="" runat="server" />

            <input type="hidden" id="hiddenNextActivityPerformers" value="" runat="server" />

            <input type="hidden" id="hiddenIsSelectMember" value="" runat="server" />
            
            <input type="button" value="确定" class="btn" onclick="SelectOK();" />&nbsp;&nbsp;
                <input type="button" value="取消" class="btn" onclick="CloseWindowPage();" />
        </div>

    </form>


    <script type="text/javascript">
        var setting = {
            check: {
                enable: true,
                chkboxType: { "Y": "ps", "N": "ps" },
                chkStyle: "checkbox"
            },
            data: {
                simpleData: {
                    enable: true
                }
            },
            view: {
                showLine: true
            }
        };

        $(function () {

            //getJson在IE下IE下默认会使用浏览器缓存，所以导致数据不显示            
            $.ajaxSetup({ cache: false });

            $.getJSON('FlowStepSelect.aspx' + window.location.search + '&Action=InitStep', function (data) {
                $.fn.zTree.init($("#ztree_container"), setting, data);
                $.ajaxSetup({ cache: true });
                var treeObj = $.fn.zTree.getZTreeObj("ztree_container");                               
                if (treeObj.getNodes().length > 1) {
                    $("#checkBox").show();
                }                
            }, 'JSON');

            function checkNode(e) {
                var zTree = $.fn.zTree.getZTreeObj("ztree_container"),
                        type = e.data.type,
                        nodes = zTree.getSelectedNodes();
                console.log(type.indexOf("All"));
                if (type.indexOf("All") < 0 && nodes.length == 0) {
                    alert("请先选择一个节点");
                }
                if (type == "checkAllTrue") {
                    zTree.checkAllNodes(true);
                } else if (type == "checkAllFalse") {
                    zTree.checkAllNodes(false);
                }
            }
  
            $("#checkAllTrue").bind("click", { type: "checkAllTrue" }, checkNode);
            $("#checkAllFalse").bind("click", { type: "checkAllFalse" }, checkNode);
           
        });
    </script>

</body>
</html>
