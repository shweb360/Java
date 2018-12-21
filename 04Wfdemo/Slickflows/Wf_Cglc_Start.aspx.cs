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
    public partial class Wf_Cglc_Start : BasePage
    {
        public string flag = "1"; //分支条件，
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtProcessGUID.Value = Wf_Cglc_ProcessConfig[0].ToString();
                if (LoginRoleID > 0)
                {
                    HttpContext.Current.Session["RoleId"] = ((int)WfRole.采购经办人).ToString();

                }
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {

            try
            {
                string processGUID = Wf_Cglc_ProcessConfig[0].ToString();
                string strNextActivityPerformers = hiddenNextActivityPerformers.Value.ToString().Trim();
                IDictionary<string, PerformerList> nextActivityPerformers = NextActivityPerformers(strNextActivityPerformers);
                if (nextActivityPerformers == null)
                {
                    base.RegisterStartupScript("", "<script>alert('请选择办理步骤或办理人员');</script>");
                    return;
                }
                DateTime now = DateTime.Now;
                //流程业务数据
                ProcurementEntity procurementEntity = new ProcurementEntity();
                procurementEntity.ApplyTitle = this.txtApplyTitle.Value;
                procurementEntity.ApplyNumber = Helper.ConverToDecimal(this.txtApplyNumber.Value);
                procurementEntity.ApplyContent = this.txtApplyContent.Value;
                procurementEntity.Attachment = "";
                try
                {
                    procurementEntity.ApplyDate = Helper.ConvertToDateTime(this.txtApplyDate.Value, now);
                }
                catch (Exception ex)
                {
                    procurementEntity.ApplyDate = now;
                }
                procurementEntity.CurrentActivityText = string.Empty;
                procurementEntity.Status = 0;
                procurementEntity.CreatedUserID = LoginUserID;
                procurementEntity.CreatedUserName = this.LoginUserName;
                procurementEntity.CreatedDate = now;

                procurementEntity.KsfzRemark = "";
                procurementEntity.FgldRemark = "";
                procurementEntity.CgjbrRemark = "";
                procurementEntity.ZzRemark = "";

                int instanceId = ProcurementBll.Add(procurementEntity);
                if (instanceId > 0)
                {
                    //调用流程
                    IWorkflowService service = new WorkflowService();

                    WfAppRunner initiator = new WfAppRunner();
                    initiator.AppName = "采购流程";
                    initiator.AppInstanceID = instanceId.ToString();
                    initiator.ProcessGUID = processGUID;
                    initiator.UserID = LoginUserID.ToString();
                    initiator.UserName = LoginUserName;
                    initiator.Conditions = GetCondition(string.Format("flag-{0}", WorkFlows.IsStartedByBgsUser(instanceId, 1) ? "0" : flag));
                    WfExecutedResult startedResult = service.StartProcess(initiator);
                    if (startedResult.Status != WfExecutedStatus.Success)
                    {
                        base.RegisterStartupScript("", "<script>alert('" + startedResult.Message + "');</script>");
                        return;
                    }

                    //送往下一步                  
                    initiator.NextActivityPerformers = nextActivityPerformers;
                    WfExecutedResult runAppResult = service.RunProcessApp(initiator);
                    if (runAppResult.Status != WfExecutedStatus.Success)
                    {
                        base.RegisterStartupScript("", "<script>alert('" + runAppResult.Message + "');</script>");
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
                            WFBizType = 4,
                            CreatedUserID = LoginUserID,
                            CreatedUserName = LoginUserName,
                            LoginRoleID = LoginRoleID,
                            CreatedDate = DateTime.Now
                        };
                        UploadFileID = UploadFileBll.Add(uploadEntity);
                    }
                    //保存业务数据                  
                    ProcurementOpinionEntity procurementOpinionEntity = new ProcurementOpinionEntity();
                    procurementOpinionEntity.AppInstanceID = instanceId.ToString();
                    procurementOpinionEntity.ActivityID = System.Guid.Empty.ToString();
                    procurementOpinionEntity.ActivityName = "流程发起";
                    procurementOpinionEntity.Remark = "";
                    procurementOpinionEntity.ChangedTime = now;
                    procurementOpinionEntity.ChangedUserID = LoginUserID;
                    procurementOpinionEntity.ChangedUserName = LoginUserName;
                    procurementOpinionEntity.UploadFileID = UploadFileID;
                    procurementOpinionEntity.LoginRoleID = LoginRoleID;
                    ProcurementOpinionBll.Add(procurementOpinionEntity);
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