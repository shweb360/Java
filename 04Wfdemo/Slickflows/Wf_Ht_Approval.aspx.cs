using System;
using System.Collections.Generic;
using System.Web.UI;


using Slickflow.WebDemo.Business;
using Slickflow.WebDemo.Common;
using Slickflow.WebDemo.Entity;

using Slickflow.Engine.Common;
using Slickflow.Engine.Core.Result;
using Slickflow.Engine.Business.Entity;
using Slickflow.Engine.Service;
using Slickflow.Engine.Xpdl;

namespace Slickflow.WebDemo.Slickflows
{
    public partial class Wf_Ht_Approval : BasePage
    {
        public string strUrl = "";
        public bool isUpload = false;
        public string flag = "1"; //分支条件，
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {              
                InitFlowInfo();
            }
        }
        protected void InitFlowInfo()
        {
            string AppInstanceID = Request.QueryString["AppInstanceID"] == null ? string.Empty : Request.QueryString["AppInstanceID"].ToString();
            string ProcessGUID = Request.QueryString["ProcessGUID"] == null ? string.Empty : Request.QueryString["ProcessGUID"].ToString();
            int ActivityInstanceID = Request.QueryString["ActivityInstanceID"] == null ? 0 : Helper.ConverToInt32(Request.QueryString["ActivityInstanceID"].ToString());
            int TaskID = Request.QueryString["TaskID"] == null ? 0 : Helper.ConverToInt32(Request.QueryString["TaskID"].ToString());
            this.hiddenTaskID.Value = TaskID.ToString();
            if (!string.IsNullOrEmpty(AppInstanceID))
            {
                int ID = int.Parse(AppInstanceID);
                ContractEntity contractEntity = ContractBll.GetModel(ID);

                if (contractEntity != null && contractEntity.ID > 0)
                {
                    txtApplyTitle.Value = contractEntity.ApplyTitle;
                    txtPartyA.Value = contractEntity.PartyA;
                    txtPartyB.Value = contractEntity.PartyB;
                    txtSigningDate.Value = contractEntity.SigningDate.ToString("yyyy-MM-dd");
                    txtAmount.Value = contractEntity.Amount.ToString();
                    txtTimeLimit.Value = contractEntity.TimeLimit;
                    txtRemark.Value = contractEntity.Remark;
                    hiddenInstanceId.Value = contractEntity.ID.ToString();
                    hiddenActivityInstanceID.Value = ActivityInstanceID.ToString();
                    strUrl = contractEntity.Attachment;
                    if (contractEntity.ApplyType > 0)
                    {
                        this.selectApplyType.SelectedIndex = contractEntity.ApplyType;
                    }

                    //权限设置
                    IWorkflowService service = new WorkflowService();
                    ActivityInstanceEntity activityInstanceEntity = service.GetActivityInstance(ActivityInstanceID);
                    ProcessInstanceEntity processInstanceEntity = service.GetProcessInstance(activityInstanceEntity.ProcessInstanceID);

                    this.txtProcessGUID.Value = activityInstanceEntity.ProcessGUID;
                    if (activityInstanceEntity != null)
                    {
                        ActivityEntity activityEntity = service.GetActivityEntity(processInstanceEntity.ProcessGUID,
                            processInstanceEntity.Version,
                            activityInstanceEntity.ActivityGUID);

                        var roles = service.GetActivityRoles(processInstanceEntity.ProcessGUID,
                            processInstanceEntity.Version,
                            activityInstanceEntity.ActivityGUID);

                        var m = UploadFileBll.GetModel(ID, 5, 24);
                        strUrl = m != null ? m.FilePath : "";
                        btnSubmit.Value = "同意并提交";

                        if (activityEntity != null && roles != null && roles.Count > 0)
                        {
                            foreach (var role in roles)
                            {
                                
                                if (role.ID == LoginRoleID.ToString() || LoginRoleID == 27 || LoginRoleID == 71)
                                {                                    
                                    switch (role.ID)
                                    {
                                        case "4"://采购经办人
                                            KzRemark.Text = string.IsNullOrWhiteSpace(contractEntity.KzRemark) ? "" : "科长意见：" + contractEntity.KzRemark;
                                            break;

                                        case "5"://科长
                                            CwzgRemark.Text = string.IsNullOrWhiteSpace(contractEntity.CwzgRemark) ? "" : "财务意见：" + contractEntity.CwzgRemark;
                                            break;

                                        case "16"://财务
                                            BgsfzrRemark.Text = string.IsNullOrWhiteSpace(contractEntity.BgsfzrRemark) ? "" : "办公室负责人意见：" + contractEntity.BgsfzrRemark;
                                            break;

                                        case "13"://办公室负责人
                                            FgzzRemark.Text = string.IsNullOrWhiteSpace(contractEntity.FgzzRemark) ? "" : "分管领导意见：" + contractEntity.FgzzRemark;
                                            //只有采购合同大于五万需要党委会审议,其余都是10万
                                            if ((contractEntity.ApplyType > 1 && contractEntity.Amount > 100000)
                                                || (contractEntity.ApplyType == 1 && contractEntity.Amount > 50000))
                                            {
                                                labTip.Text = "提示：该流程需要党委会审核。";
                                                btnSubmit.Value = "同意(党委会审核已通过)";
                                            }
                                            break;
                                        case "14"://分管领导
                                            ZzRemark.Text = string.IsNullOrWhiteSpace(contractEntity.ZzRemark) ? "" : "站长意见：" + contractEntity.ZzRemark;
                                            break;

                                        case "25": //站长
                                            btnSendNext.Text = "同意";
                                            btnSubmit.Visible = false;
                                            btnSendNext.Style["display"] = "inline";
                                            //只有采购合同大于五万需要党委会审议,其余都是10万
                                            if ((contractEntity.ApplyType > 1 && contractEntity.Amount > 100000)
                                                || (contractEntity.ApplyType == 1 && contractEntity.Amount > 50000))
                                            {                                              
                                                btnSendNext.Text = "同意(党委会审核已通过)";
                                            }
                                            //站长确认后不用弹框选择结束
                                           // hiddenNextActivityPerformers.Value = "step[5dd66b5e-6088-4c01-f553-b2516f1e4e1f]"; //结束节点
                                            hiddenNextActivityPerformers.Value =string.Format("step[{0}]",Wf_Ht_ProcessConfig[1].ToString()); //结束节点
                                            break;
                                    }
                                }
                            }
                        }
                    }

                }
            }
        }

        protected void btnSendNext_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime now = DateTime.Now;
                string CurrentActivityText = string.Empty;
                string currentOpinionRemark = string.Empty;
                string processGUID = this.txtProcessGUID.Value.ToString();

                string instanceId = this.hiddenInstanceId.Value;
               
                int activityInstanceID = Helper.ConverToInt32(hiddenActivityInstanceID.Value);
                string strNextActivityPerformers = hiddenNextActivityPerformers.Value.ToString().Trim();
                IDictionary<string, PerformerList> nextActivityPerformers = NextActivityPerformers(strNextActivityPerformers);
                if (nextActivityPerformers == null)
                {
                    base.RegisterStartupScript("", "<script>alert('请选择办理步骤或办理人员');</script>");
                    return;
                }                
                if (!string.IsNullOrEmpty(instanceId))
                {
                    //调用流程
                    IWorkflowService service = new WorkflowService();
                    string _flag = "1"; //分支条件，
                    WfAppRunner initiator = new WfAppRunner();
                    
                    initiator.AppName = "合同流程";
                    initiator.AppInstanceID = instanceId;
                    initiator.ProcessGUID = processGUID;
                    initiator.UserID = LoginUserID.ToString();
                    initiator.UserName = LoginUserName;
                    initiator.TaskID = Helper.ConverToInt32(this.hiddenTaskID.Value);
                    initiator.NextActivityPerformers = nextActivityPerformers;
                    initiator.Conditions = GetCondition(string.Format("flag-{0}", WorkFlows.IsStartedByBgsUser(int.Parse(instanceId),2) ? "0" : _flag));
                    WfExecutedResult runAppResult = service.RunProcessApp(initiator);
                    if (runAppResult.Status != WfExecutedStatus.Success)
                    {
                        base.RegisterStartupScript("", "<script>alert('" + runAppResult.Message + "');</script>");
                        return;
                    }

                    ActivityInstanceEntity activityInstanceEntity = service.GetActivityInstance(activityInstanceID);
                    if (activityInstanceEntity != null)
                    {
                        CurrentActivityText = activityInstanceEntity.ActivityName;
                    }
                    try
                    {
                        //保存业务数据
                        ContractOpinionEntity contractOpinionEntity = new ContractOpinionEntity();
                        contractOpinionEntity.AppInstanceID = instanceId.ToString();
                        contractOpinionEntity.ActivityID = activityInstanceID.ToString();
                        contractOpinionEntity.ActivityName = CurrentActivityText;
                        contractOpinionEntity.Remark = "同意";
                        contractOpinionEntity.ChangedTime = now;
                        contractOpinionEntity.ChangedUserID = LoginUserID;
                        contractOpinionEntity.ChangedUserName = LoginUserName;
                        ContractOpinionBll.Add(contractOpinionEntity);

                    }
                    catch (Exception ex)
                    { }

                    try
                    {
                        ContractEntity contractEntity = new Entity.ContractEntity();
                        contractEntity.ID = Helper.ConverToInt32(instanceId);                        
                        contractEntity.CurrentActivityText = CurrentActivityText;
                        ContractBll.Update(contractEntity);
                    }
                    catch (Exception ex)
                    { }

                    base.RegisterStartupScript("", "<script>alert('办理成功');window.location.href='FlowList.aspx';</script>");

                }
            }
            catch (Exception ex)
            {
                base.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('流程发起出现异常 EXCEPTION:" + ex.ToString() + "');</script>");
            }
        }

        protected void btnSendbackProcess_Click(object sender, EventArgs e)
        {
            string instanceId = this.hiddenInstanceId.Value;
            string processGUID = this.txtProcessGUID.Value.ToString();
            //调用流程
            IWorkflowService service = new WorkflowService();

            WfAppRunner initiator = new WfAppRunner();
            initiator.AppName = "合同流程退回";
            initiator.AppInstanceID = instanceId;
            initiator.ProcessGUID = processGUID;
            initiator.UserID = LoginUserID.ToString();
            initiator.UserName = LoginUserName;
            initiator.TaskID = Helper.ConverToInt32(this.hiddenTaskID.Value);
            WfExecutedResult runAppResult = service.SendBackProcess(initiator); //退回
            if (runAppResult.Status != WfExecutedStatus.Success)
            {
                base.RegisterStartupScript("", "<script>alert('" + runAppResult.Message + "');</script>");
                return;
            }
            int ID = int.Parse(instanceId);
            ContractEntity m = ContractBll.GetModel(ID);
            if (m != null)
            {
                if (LoginRoleID == 5)
                {
                    m.KzRemark = hiddenSendbackRemark.Value; //科长意见
                }
                else if (LoginRoleID == 16)
                {
                    m.CwzgRemark = hiddenSendbackRemark.Value;//财务意见
                }
                else if (LoginRoleID == 13)
                {
                    m.BgsfzrRemark = hiddenSendbackRemark.Value;//办公室负责人意见
                }
                else if (LoginRoleID == 15)
                {
                    m.FgzzRemark = hiddenSendbackRemark.Value;//分管领导意见
                }
                else if (LoginRoleID == 15)
                {
                    m.ZzRemark = hiddenSendbackRemark.Value;//站长意见
                }               
                if (ContractBll.Update(m))
                {
                    string CurrentActivityText = string.Empty;
                    int activityInstanceID = Helper.ConverToInt32(hiddenActivityInstanceID.Value);
                    ActivityInstanceEntity activityInstanceEntity = service.GetActivityInstance(activityInstanceID);
                    if (activityInstanceEntity != null)
                    {
                        CurrentActivityText = activityInstanceEntity.ActivityName;
                    }
                    //保存业务数据
                    ContractOpinionEntity contractOpinionEntity = new ContractOpinionEntity();
                    contractOpinionEntity.AppInstanceID = instanceId.ToString();
                    contractOpinionEntity.ActivityID = activityInstanceEntity.ActivityGUID.ToString();
                    contractOpinionEntity.ActivityName = CurrentActivityText;
                    contractOpinionEntity.Remark = "回退-" + hiddenSendbackRemark.Value;
                    contractOpinionEntity.ChangedTime = DateTime.Now;
                    contractOpinionEntity.ChangedUserID = LoginUserID;
                    contractOpinionEntity.ChangedUserName = LoginUserName;
                    contractOpinionEntity.LoginRoleID = LoginRoleID;
                    ContractOpinionBll.Add(contractOpinionEntity);
                }
            }
            base.RegisterStartupScript("", "<script>alert('流程回退成功!');</script>");
        }
    }
}