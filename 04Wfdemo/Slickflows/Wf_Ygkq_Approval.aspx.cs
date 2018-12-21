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
using System.Web;

namespace Slickflow.WebDemo.Slickflows
{
    public partial class Wf_Ygkq_Approval : BasePage
    {
        public string strUrl = "";
        public bool isUpload = false;
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
                
                int leaveID = int.Parse(AppInstanceID);
                HrsLeaveEntity hrsLeaveEntity = WorkFlows.GetHrsLeaveModel(leaveID);
                if (hrsLeaveEntity != null && hrsLeaveEntity.ID > 0)
                {

                    txtApplyTitle.Value = hrsLeaveEntity.CurrentActivityText;
                    //strUrl = hrsLeaveEntity.Attachment;
                    txtFromDate.Value = hrsLeaveEntity.FromDate.ToString("yyyy-MM-dd");
                    txtToDate.Value = hrsLeaveEntity.ToDate.ToString("yyyy-MM-dd");
                    hiddenInstanceId.Value = hrsLeaveEntity.ID.ToString();
                    hiddenActivityInstanceID.Value = ActivityInstanceID.ToString();

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

                        var m = UploadFileBll.GetModel(leaveID, 6, 2);
                        strUrl = m != null ? m.FilePath : "";
                        var userRoles = WorkFlows.GetCurrUserRoleIDlist(LoginUserID);

                        if (activityEntity != null && roles != null && roles.Count > 0)
                        {
                            foreach (var role in roles)
                            {
                                if (userRoles.Contains(role.ID))
                                {
                                    //涉及多个角色时，取当前流程中的角色ID；                                   
                                    HttpContext.Current.Session["RoleId"] = role.ID;
                                }
                                if (role.ID == LoginRoleID.ToString())
                                {
                                    btnSubmit.Value = "同意并提交";

                                    strUrl = GetUploadFileUrl(leaveID, (int)WfName.员工考勤流程, LoginRoleID, out isUpload);
                                    if (LoginRoleID == (int)WfRole.劳资)
                                    {
                                        this.Repeater1.DataSource = UploadFileBll.GetListUploadFile(leaveID, (int)WfName.员工考勤流程, (int)WfRole.劳资);
                                        this.Repeater1.DataBind();
                                        isUpload = true;
                                        btnFlowback.Style["display"] = "none";
                                    }
                                     else if (LoginRoleID == (int)WfRole.站长)
                                     {
                                         m = UploadFileBll.GetModel(leaveID, (int)WfName.员工考勤流程, (int)WfRole.劳资);
                                         strUrl = m != null ? m.FilePath : "";
                                         btnSubmit.Visible = false;
                                         btnSendNext.Style["display"] = "inline";
                                         btnSendNext.Text = "同意";

                                         //确认后不用弹框选择结束
                                         //hiddenNextActivityPerformers.Value = "step[79d0b19a-2504-429a-cb7e-c6d86bf8c79a]"; //结束节点
                                         hiddenNextActivityPerformers.Value = string.Format("step[{0}]", Wf_Ygkq_ProcessConfig[1].ToString()); //结束节点
                                     }
                                   
                                }
                            }
                        }
                    }

                }
            }
            //是否显示回退按钮,如果是经办人就不显示
            if (!IsShowHtBtn(LoginRoleID))
            {
                btnFlowback.Style["display"] = "none";
            }
        }
        //送往下一步
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

                    WfAppRunner initiator = new WfAppRunner();
                    initiator.AppName = "员工考勤流程";
                    initiator.AppInstanceID = instanceId;
                    initiator.ProcessGUID = processGUID;
                    initiator.UserID = LoginUserID.ToString();
                    initiator.UserName = LoginUserName;
                    initiator.Conditions = GetCondition(string.Format("days-{0}", "0"));
                    initiator.TaskID = Helper.ConverToInt32(this.hiddenTaskID.Value);
                    initiator.NextActivityPerformers = nextActivityPerformers;                                    
                    
                    WfExecutedResult runAppResult = new WfExecutedResult();
                    if (WorkFlows.IsResend(instanceId,LoginUserID.ToString()))
                    {                       
                        //新增返送功能，,办理完毕后再次返送回去（原路返回）
                        runAppResult = service.ResendProcess(initiator);
                    }
                    else
                    {
                        runAppResult = service.RunProcessApp(initiator);
                    }

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
                        int UploadFileID = 0;
                            //修改覆盖
                        if (!string.IsNullOrWhiteSpace(this.txtFilePath.Value) &&
                                 !string.IsNullOrWhiteSpace(this.txtFileName.Value))
                        {
                            //新增
                            UploadFileEntity uploadEntity = new UploadFileEntity()
                            {
                                FilePath = this.txtFilePath.Value,
                                FileName = this.txtFileName.Value,
                                WFBizID = int.Parse(instanceId),
                                WFBizType = (int)WfName.员工考勤流程,
                                CreatedUserID = LoginUserID,
                                CreatedUserName = LoginUserName,
                                LoginRoleID = LoginRoleID,
                                CreatedDate = DateTime.Now
                            };
                            UploadFileID = UploadFileBll.Add(uploadEntity);

                            //var m = UploadFileBll.GetModel(int.Parse(instanceId), (int)WfName.员工考勤流程,LoginRoleID);
                            //if (m != null)
                            //{
                            //    m.FilePath = this.txtFilePath.Value;
                            //    m.FileName = this.txtFileName.Value;
                            //    UploadFileBll.Update(m);
                            //    UploadFileID = m.ID;
                            //}
                            //else
                            //{

                                
                            //}
                        }
                        
                        //保存业务数据
                        HrsLeaveOpinionEntity hrsleaveOpinionEntity = new HrsLeaveOpinionEntity();
                        hrsleaveOpinionEntity.AppInstanceID = instanceId.ToString();
                        hrsleaveOpinionEntity.ActivityID = activityInstanceEntity.ActivityGUID.ToString();
                        hrsleaveOpinionEntity.ActivityName = CurrentActivityText;
                        hrsleaveOpinionEntity.Remark = "同意";
                        hrsleaveOpinionEntity.ChangedTime = now;
                        hrsleaveOpinionEntity.ChangedUserID = LoginUserID.ToString();
                        hrsleaveOpinionEntity.ChangedUserName = LoginUserName;
                        hrsleaveOpinionEntity.UploadFileID = UploadFileID;
                        hrsleaveOpinionEntity.LoginRoleID = LoginRoleID;
                        WorkFlows.AddHrsLeaveOpinion(hrsleaveOpinionEntity);

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
            initiator.AppName = "员工考勤流程退回";
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
            HrsLeaveEntity m = WorkFlows.GetHrsLeaveModel(ID);
            if (m != null)
            {
                if (LoginRoleID == 5)
                {
                    m.KzRemark = hiddenSendbackRemark.Value; //科长意见
                }
                else if (LoginRoleID == 14)
                {
                    m.FgzzRemark = hiddenSendbackRemark.Value;//分管站长意见
                }
                else if (LoginRoleID == 15)
                {
                    m.ZzRemark = hiddenSendbackRemark.Value;//站长意见
                }
                else if (LoginRoleID == 6)
                {
                    m.LzRemark = hiddenSendbackRemark.Value;//劳资负责人意见
                }
                
                if (WorkFlows.UpdateHrsLeave(m))
                {
                    string CurrentActivityText = string.Empty;
                    int activityInstanceID = Helper.ConverToInt32(hiddenActivityInstanceID.Value);
                    ActivityInstanceEntity activityInstanceEntity = service.GetActivityInstance(activityInstanceID);
                    if (activityInstanceEntity != null)
                    {
                        CurrentActivityText = activityInstanceEntity.ActivityName;
                    }
                    //保存业务数据
                    HrsLeaveOpinionEntity hrsleaveopinionentity = new HrsLeaveOpinionEntity();
                    hrsleaveopinionentity.AppInstanceID = instanceId.ToString();
                    hrsleaveopinionentity.ActivityID = activityInstanceEntity.ActivityGUID.ToString();
                    hrsleaveopinionentity.ActivityName = CurrentActivityText;
                    hrsleaveopinionentity.Remark = "回退-" + hiddenSendbackRemark.Value;
                    hrsleaveopinionentity.ChangedTime = DateTime.Now;
                    hrsleaveopinionentity.ChangedUserID = LoginUserID.ToString();
                    hrsleaveopinionentity.ChangedUserName = LoginUserName;
                    hrsleaveopinionentity.LoginRoleID = LoginRoleID;
                    WorkFlows.AddHrsLeaveOpinion(hrsleaveopinionentity);
                }
            }
            base.RegisterStartupScript("", "<script>alert('流程回退成功!');</script>");
        }
    }
}