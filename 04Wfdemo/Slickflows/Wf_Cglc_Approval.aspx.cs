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
    public partial class Wf_Cglc_Approval : BasePage
    {
        public string strUrl = "";
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
                ProcurementEntity procurementEntity = ProcurementBll.GetModel(ID);

                if (procurementEntity != null && procurementEntity.ID > 0)
                {
                    txtApplyTitle.Value = procurementEntity.ApplyTitle;
                    txtApplyNumber.Value = procurementEntity.ApplyNumber.ToString();
                    txtApplyContent.Value = procurementEntity.ApplyContent;
                    txtApplyDate.Value = procurementEntity.ApplyDate.ToString("yyyy-MM-dd");
                    hiddenInstanceId.Value = procurementEntity.ID.ToString();
                    hiddenActivityInstanceID.Value = ActivityInstanceID.ToString();
                    strUrl = procurementEntity.Attachment;

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

                        var m = UploadFileBll.GetModel(ID, 4, 4);
                        strUrl = m != null ? m.FilePath : "";

                        if (activityEntity != null && roles != null && roles.Count > 0)
                        {
                            foreach (var role in roles)
                            {
                                if (role.ID == LoginRoleID.ToString())
                                {
                                    //科室员工上传的附件
                                    var model = UploadFileBll.GetModel(ID, 4, 4);
                                    strUrl = model != null ? model.FilePath : "";
                                    btnSubmit.Value = "同意并提交";
                                    
                                    switch (role.ID)
                                    {
                                        case "4"://科室员工
                                            KsfzRemark.Text = string.IsNullOrWhiteSpace(procurementEntity.KsfzRemark) ? "" : "科长意见：" + procurementEntity.KsfzRemark;
                                            break;

                                        case "5"://科长
                                            FgldRemark.Text = string.IsNullOrWhiteSpace(procurementEntity.FgldRemark) ? "" : "分管领导意见：" + procurementEntity.FgldRemark;
                                            break;

                                        case "14"://分管领导
                                            CgjbrRemark.Text = string.IsNullOrWhiteSpace(procurementEntity.CgjbrRemark) ? "" : "采购经办人意见：" + procurementEntity.CgjbrRemark;
                                            break;

                                        case "77"://采购经办人
                                            ZzRemark.Text = string.IsNullOrWhiteSpace(procurementEntity.ZzRemark) ? "" : "站长意见：" + procurementEntity.ZzRemark;
                                            break;

                                        case "25"://站长

                                            btnSubmit.Visible = false;
                                            btnSendNext.Style["display"] = "inline";
                                            btnSendNext.Text = "同意";

                                            //站长确认后不用弹框选择结束
                                            //hiddenNextActivityPerformers.Value = "step[8ab6ee65-24b5-4f59-a674-b1fb72181b73]"; //结束节点
                                            hiddenNextActivityPerformers.Value = string.Format("step[{0}]", Wf_Cglc_ProcessConfig[1].ToString());
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
                    initiator.AppName = "采购流程";
                    initiator.AppInstanceID = instanceId;
                    initiator.ProcessGUID = processGUID;
                    initiator.UserID = LoginUserID.ToString();
                    initiator.UserName = LoginUserName;
                    initiator.NextActivityPerformers = nextActivityPerformers;
                    initiator.Conditions = GetCondition(string.Format("flag-{0}", WorkFlows.IsStartedByBgsUser(int.Parse(instanceId),1) ? "0" : _flag));
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
                        ProcurementOpinionEntity procurementOpinionEntity = new ProcurementOpinionEntity();
                        procurementOpinionEntity.AppInstanceID = instanceId.ToString();
                        procurementOpinionEntity.ActivityID = activityInstanceEntity.ActivityGUID.ToString();
                        procurementOpinionEntity.ActivityName = CurrentActivityText;
                        procurementOpinionEntity.Remark = "同意";
                        procurementOpinionEntity.ChangedTime = now;
                        procurementOpinionEntity.ChangedUserID = LoginUserID;
                        procurementOpinionEntity.ChangedUserName = LoginUserName;
                        ProcurementOpinionBll.Add(procurementOpinionEntity);

                    }
                    catch (Exception ex)
                    { }

                    try
                    {
                        ProcurementEntity procurementEntity = new Entity.ProcurementEntity();
                        procurementEntity.ID = Helper.ConverToInt32(instanceId);

                        procurementEntity.CurrentActivityText = CurrentActivityText;
                        ProcurementBll.Update(procurementEntity);
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
            initiator.AppName = "采购流程退回";
            initiator.AppInstanceID = instanceId;
            initiator.ProcessGUID = processGUID;
            initiator.UserID = LoginUserID.ToString();
            initiator.UserName = LoginUserName;
            initiator.TaskID = Helper.ConverToInt32(this.hiddenTaskID.Value);
            WfExecutedResult runAppResult = service.SendBackProcess(initiator); //退回
            if (runAppResult.Status != WfExecutedStatus.Success)
            {
                //base.RegisterStartupScript("", "<script>alert('" + runAppResult.Message + "');</script>");
                //return;
            }
            int ID = int.Parse(instanceId);
            ProcurementEntity m = ProcurementBll.GetModel(ID);
            if (m != null)
            {
                if (LoginRoleID == 5)
                {
                    m.KsfzRemark = hiddenSendbackRemark.Value; //科室负责人意见
                }
                else if (LoginRoleID == 14)
                {
                    m.FgldRemark = hiddenSendbackRemark.Value;//分管领导意见
                }
                else if (LoginRoleID == 4)
                {
                    m.CgjbrRemark = hiddenSendbackRemark.Value;//采购经办人意见
                }
                else if (LoginRoleID == 15)
                {
                    m.ZzRemark = hiddenSendbackRemark.Value;//站长意见
                }
                if (ProcurementBll.Update(m))
                {
                    string CurrentActivityText = string.Empty;
                    int activityInstanceID = Helper.ConverToInt32(hiddenActivityInstanceID.Value);
                    ActivityInstanceEntity activityInstanceEntity = service.GetActivityInstance(activityInstanceID);
                    if (activityInstanceEntity != null)
                    {
                        CurrentActivityText = activityInstanceEntity.ActivityName;
                    }
                    //保存业务数据
                    ProcurementOpinionEntity procurementOpinionEntity = new ProcurementOpinionEntity();
                    procurementOpinionEntity.AppInstanceID = instanceId.ToString();
                    procurementOpinionEntity.ActivityID = activityInstanceEntity.ActivityGUID.ToString();
                    procurementOpinionEntity.ActivityName = CurrentActivityText;
                    procurementOpinionEntity.Remark = "回退-" + hiddenSendbackRemark.Value;
                    procurementOpinionEntity.ChangedTime = DateTime.Now;
                    procurementOpinionEntity.ChangedUserID = LoginUserID;
                    procurementOpinionEntity.ChangedUserName = LoginUserName;
                    procurementOpinionEntity.LoginRoleID = LoginRoleID;
                    ProcurementOpinionBll.Add(procurementOpinionEntity);
                }
            }

            base.RegisterStartupScript("", "<script>alert('流程回退成功!');</script>");
        }
    }
}