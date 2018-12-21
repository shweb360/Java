<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Wf_Ht_Info.aspx.cs" Inherits="Slickflow.WebDemo.Slickflows.Wf_Ht_Info" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>合同流程</title>
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
            <span>合同流程</span>
        </div>

        <!--/导航栏-->

        <!--内容-->
        <div class="tab-content">
            
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
