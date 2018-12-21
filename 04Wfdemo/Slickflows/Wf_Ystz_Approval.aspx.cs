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
    public partial class Wf_Ystz_Approval : BasePage
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
                int ID = int.Parse(AppInstanceID);
                FinancialEntity financialEntity = FinancialBll.GetModel(ID);

                if (financialEntity != null && financialEntity.ID > 0)
                {
                    txtApplyTitle.Value = financialEntity.ApplyTitle;
                    txtApplyContent.Value = financialEntity.ApplyContent;
                    txtApplyDate.Value = financialEntity.ApplyDate.ToString("yyyy-MM-dd");
                    hiddenInstanceId.Value = financialEntity.ID.ToString();
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

                        if (activityEntity != null && roles != null && roles.Count > 0)
                        {
                            var m = UploadFileBll.GetModel(ID, (int)WfName.预算调整流程, 23);
                            strUrl = m != null ? m.FilePath : "";

                            var userRoles = WorkFlows.GetCurrUserRoleIDlist(LoginUserID);
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

                                    strUrl = GetUploadFileUrl(ID, (int)WfName.预算调整流程, LoginRoleID, out isUpload);
                                    if (LoginRoleID == (int)WfRole.财务主管)
                                    {
                                        this.Repeater1.DataSource = UploadFileBll.GetListUploadFile(ID, (int)WfName.预算调整流程, (int)WfRole.办公室财务);
                                        this.Repeater1.DataBind();
                                        isUpload = true;
                                        ZzRemark.Text = string.IsNullOrWhiteSpace(financialEntity.ZzRemark) ? "" : "站长意见：" + financialEntity.ZzRemark; 
                                    }
                                    else if (LoginRoleID == (int)WfRole.站长)
                                    {
                                        btnSubmit.Visible = false;
                                        labTip.Text = "提示：该流程需要党委会审核。";

                                        btnSendNext.Text = "同意(党委会审核已通过)";
                                        btnSendNext.Style["display"] = "inline";
                                        //站长确认后不用弹框选择结束
                                       // hiddenNextActivityPerformers.Value = "step[20382115-972d-49ec-8490-e0b9e35cc09e]"; //结束节点
                                        hiddenNextActivityPerformers.Value = string.Format("step[{0}]", Wf_Ystz_ProcessConfig[1].ToString());
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
                    initiator.AppName = "预算调整流程";
                    initiator.AppInstanceID = instanceId;
                    initiator.ProcessGUID = processGUID;
                    initiator.UserID = LoginUserID.ToString();
                    initiator.UserName = LoginUserName;
                    initiator.TaskID = Helper.ConverToInt32(this.hiddenTaskID.Value);
                    initiator.NextActivityPerformers = nextActivityPerformers;
                    
                    WfExecutedResult runAppResult = new WfExecutedResult();
                    if (WorkFlows.IsResend(instanceId, LoginUserID.ToString()))
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
                        if (!string.IsNullOrWhiteSpace(this.txtFilePath.Value) &&
                                   !string.IsNullOrWhiteSpace(this.txtFileName.Value))
                        {
                            //上传文件
                            UploadFileEntity uploadEntity = new UploadFileEntity()
                            {
                                FilePath = this.txtFilePath.Value,
                                FileName = this.txtFileName.Value,
                                WFBizID = int.Parse(instanceId),
                                WFBizType = (int)WfName.预算调整流程,
                                CreatedUserID = LoginUserID,
                                CreatedUserName = LoginUserName,
                                CreatedDate = DateTime.Now,
                                LoginRoleID = LoginRoleID
                            };
                            UploadFileID = UploadFileBll.Add(uploadEntity);

                            ////修改覆盖
                            //var m = UploadFileBll.GetModelByUserID(int.Parse(instanceId), (int)WfName.预算调整流程, LoginUserID);
                            //if (m != null && LoginRoleID != (int)WfRole.办公室预算专管员)
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
                        FinancialOpinionEntity financialOpinionEntity = new FinancialOpinionEntity();
                        financialOpinionEntity.AppInstanceID = instanceId.ToString();
                        financialOpinionEntity.ActivityID = activityInstanceEntity.ActivityGUID.ToString();
                        financialOpinionEntity.ActivityName = CurrentActivityText;
                        financialOpinionEntity.Remark = "同意";
                        financialOpinionEntity.ChangedTime = now;
                        financialOpinionEntity.ChangedUserID = LoginUserID;
                        financialOpinionEntity.ChangedUserName = LoginUserName;
                        financialOpinionEntity.UploadFileID = UploadFileID;
                        financialOpinionEntity.LoginRoleID = LoginRoleID;
                        FinancialOpinionBll.Add(financialOpinionEntity);

                    }
                    catch (Exception ex)
                    { }

                    try
                    {
                        FinancialEntity financialEntity = new Entity.FinancialEntity();
                        financialEntity.ID = Helper.ConverToInt32(instanceId);

                        financialEntity.CurrentActivityText = CurrentActivityText;
                        FinancialBll.Update(financialEntity);
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
            initiator.AppName = "预算调整流程退回";
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
            FinancialEntity m = FinancialBll.GetModel(ID);
            if (m != null)
            {
                if (LoginRoleID == 5)
                {
                    m.KzRemark = hiddenSendbackRemark.Value; //科长意见
                }
                else if (LoginRoleID == 14)
                {
                    m.FgldRemark = hiddenSendbackRemark.Value; //分管站长意见
                }
                else if (LoginRoleID == 16)
                {
                    m.CwRemark = hiddenSendbackRemark.Value;//财务意见
                }
                else if (LoginRoleID == 15)
                {
                    m.ZzRemark = hiddenSendbackRemark.Value;//站长意见
                }               
             
                if (FinancialBll.Update(m))
                {
                    string CurrentActivityText = string.Empty;
                    int activityInstanceID = Helper.ConverToInt32(hiddenActivityInstanceID.Value);
                    ActivityInstanceEntity activityInstanceEntity = service.GetActivityInstance(activityInstanceID);
                    if (activityInstanceEntity != null)
                    {
                        CurrentActivityText = activityInstanceEntity.ActivityName;
                    }
                    //保存业务数据
                    FinancialOpinionEntity financialOpinionEntity = new FinancialOpinionEntity();
                    financialOpinionEntity.AppInstanceID = instanceId.ToString();
                    financialOpinionEntity.ActivityID = activityInstanceEntity.ActivityGUID.ToString();
                    financialOpinionEntity.ActivityName = CurrentActivityText;
                    financialOpinionEntity.Remark = "回退-" + hiddenSendbackRemark.Value;
                    financialOpinionEntity.ChangedTime = DateTime.Now;
                    financialOpinionEntity.ChangedUserID = LoginUserID;
                    financialOpinionEntity.ChangedUserName = LoginUserName;
                    financialOpinionEntity.LoginRoleID = LoginRoleID;
                    FinancialOpinionBll.Add(financialOpinionEntity);
                }
            }
            base.RegisterStartupScript("", "<script>alert('流程回退成功!');</script>");
        }
    }
}