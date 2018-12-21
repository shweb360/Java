using System;
using System.Collections.Generic;
using System.Web.UI;

using Slickflow.WebDemo.Business;
using Slickflow.WebDemo.Common;
using Slickflow.WebDemo.Entity;

using Slickflow.Engine.Common;
using Slickflow.Engine.Core.Result;
using Slickflow.Engine.Service;
using System.Web;

namespace Slickflow.WebDemo.Slickflows
{
    public partial class Wf_Ygkq_Start : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtProcessGUID.Value = Wf_Ygkq_ProcessConfig[0].ToString();
                if (LoginRoleID > 0)
                {
                    HttpContext.Current.Session["RoleId"] = ((int)WfRole.劳资).ToString();

                }
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string processGUID = Wf_Ygkq_ProcessConfig[0].ToString();

                string strNextActivityPerformers = hiddenNextActivityPerformers.Value.ToString().Trim();

                IDictionary<string, PerformerList> nextActivityPerformers = NextActivityPerformers(strNextActivityPerformers);
                if (nextActivityPerformers == null)
                {
                    base.RegisterStartupScript("", "<script>alert('请选择办理步骤或办理人员');</script>");
                    return;
                }

                DateTime now = DateTime.Now;

                //业务数据
                HrsLeaveEntity hrsLeaveEntity = new HrsLeaveEntity();
                //hrsLeaveEntity.LeaveType = leaveType;

                try
                {
                    hrsLeaveEntity.FromDate = Helper.ConvertToDateTime(this.txtFromDate.Value, now);
                }
                catch (Exception ex)
                {
                    hrsLeaveEntity.FromDate = now;
                }
                try
                {
                    hrsLeaveEntity.ToDate = Helper.ConvertToDateTime(this.txtToDate.Value, now);
                }
                catch (Exception ex)
                {
                    hrsLeaveEntity.ToDate = now;
                }
                hrsLeaveEntity.CurrentActivityText = this.txtApplyTitle.Value;
                hrsLeaveEntity.Attachment = "";
                hrsLeaveEntity.Status = 0;
                hrsLeaveEntity.CreatedUserID = LoginUserID;
                hrsLeaveEntity.CreatedUserName = this.LoginUserName;
                hrsLeaveEntity.CreatedDate = now;

                hrsLeaveEntity.KzRemark = "";
                hrsLeaveEntity.FgzzRemark = "";
                hrsLeaveEntity.ZzRemark = "";
                hrsLeaveEntity.LzRemark = "";

                int instanceId = WorkFlows.AddHrsLeave(hrsLeaveEntity);
                if (instanceId > 0)
                {
                    //调用流程
                    IWorkflowService service = new WorkflowService();

                    WfAppRunner initiator = new WfAppRunner();
                    initiator.AppName = "员工考勤流程";
                    initiator.AppInstanceID = instanceId.ToString();
                    initiator.ProcessGUID = processGUID;
                    initiator.UserID = LoginUserID.ToString();
                    initiator.UserName = LoginUserName;
                    initiator.Conditions = GetCondition(string.Format("days-{0}", "0"));
                    WfExecutedResult startedResult = service.StartProcess(initiator);
                    if (startedResult.Status != WfExecutedStatus.Success)
                    {
                        base.RegisterStartupScript("", "<script>alert('" + startedResult.Message + "');</script>");
                        return;
                    }
                    int UploadFileID = 0;
                    if (!string.IsNullOrWhiteSpace(this.txtFilePath.Value) &&
                                   !string.IsNullOrWhiteSpace(this.txtFileName.Value))
                    {
                        //上传文件
                        UploadFileEntity uploadEntity = new UploadFileEntity()
                        {
                            FilePath = this.txtFilePath.Value,
                            FileName = this.txtFileName.Value,
                            WFBizID = instanceId,
                            WFBizType = (int)WfName.员工考勤流程,
                            CreatedUserID = LoginUserID,
                            CreatedUserName = LoginUserName,
                            LoginRoleID = LoginRoleID,
                            CreatedDate = DateTime.Now
                        };
                        UploadFileID=UploadFileBll.Add(uploadEntity);
                    }
                    initiator.NextActivityPerformers = nextActivityPerformers;
                    WfExecutedResult runAppResult = service.RunProcessApp(initiator);
                    if (runAppResult.Status != WfExecutedStatus.Success)
                    {
                        base.RegisterStartupScript("", "<script>alert('" + runAppResult.Message + "');</script>");
                        return;
                    }


                    HrsLeaveOpinionEntity hrsleaveOpinionEntity = new HrsLeaveOpinionEntity();
                    hrsleaveOpinionEntity.AppInstanceID = instanceId.ToString();
                    hrsleaveOpinionEntity.ActivityID = System.Guid.Empty.ToString();
                    hrsleaveOpinionEntity.ActivityName = LoginRoleName;
                    hrsleaveOpinionEntity.Remark = "";
                    hrsleaveOpinionEntity.ChangedTime = now;
                    hrsleaveOpinionEntity.ChangedUserID = LoginUserID.ToString();
                    hrsleaveOpinionEntity.ChangedUserName = LoginUserName;
                    hrsleaveOpinionEntity.UploadFileID = UploadFileID;
                    hrsleaveOpinionEntity.LoginRoleID = LoginRoleID;
                    
                    WorkFlows.AddHrsLeaveOpinion(hrsleaveOpinionEntity);


                    base.RegisterStartupScript("", "<script>alert('流程发起成功');window.location.href='FlowList.aspx';</script>");

                }
            }
            catch (Exception ex)
            {
                base.RegisterStartupScript("", "<script>alert('流程发起出现异常 EXCEPTION:" + ex.ToString() + "');</script>");
            }
        }
    }
}