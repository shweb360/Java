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
    public partial class Wf_Ht_Start : BasePage
    {
        public string flag = "1"; //分支条件，
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtProcessGUID.Value = Wf_Ht_ProcessConfig[0].ToString();
                if (LoginRoleID > 0)
                {
                    HttpContext.Current.Session["RoleId"] = ((int)WfRole.科室员工).ToString();

                }
            }
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {

            try
            {
                string processGUID = Wf_Ht_ProcessConfig[0].ToString();
                string strNextActivityPerformers = hiddenNextActivityPerformers.Value.ToString().Trim();
                IDictionary<string, PerformerList> nextActivityPerformers = NextActivityPerformers(strNextActivityPerformers);
                if (nextActivityPerformers == null)
                {
                    base.RegisterStartupScript("", "<script>alert('请选择办理步骤或办理人员');</script>");
                    return;
                }
                DateTime now = DateTime.Now;
                //流程业务数据
                ContractEntity contractEntity = new ContractEntity();
                contractEntity.ApplyTitle = this.txtApplyTitle.Value;
                contractEntity.ApplyType = Helper.ConverToInt32(this.selectApplyType.Value);
                contractEntity.PartyA = this.txtPartyA.Value;
                contractEntity.PartyB = this.txtPartyB.Value;
                contractEntity.Amount = Helper.ConverToDecimal(this.txtAmount.Value);
                contractEntity.TimeLimit = this.txtTimeLimit.Value;
                contractEntity.Remark = this.txtRemark.Value;
                contractEntity.Attachment = "";// this.txtAttachment.Value;
                try
                {
                    contractEntity.SigningDate = Helper.ConvertToDateTime(this.txtSigningDate.Value, now);
                }
                catch (Exception ex)
                {
                    contractEntity.SigningDate = now;
                }
                contractEntity.CurrentActivityText = string.Empty;
                contractEntity.Status = 0;
                contractEntity.CreatedUserID = LoginUserID;
                contractEntity.CreatedUserName = this.LoginUserName;
                contractEntity.CreatedDate = now;

                contractEntity.KzRemark = "";
                contractEntity.CwzgRemark = "";
                contractEntity.BgsfzrRemark = "";
                contractEntity.FgzzRemark = "";
                contractEntity.ZzRemark = "";

                int instanceId = ContractBll.Add(contractEntity);
                if (instanceId > 0)
                {
                    //调用流程
                    IWorkflowService service = new WorkflowService();

                    WfAppRunner initiator = new WfAppRunner();
                    initiator.AppName = "合同流程";
                    initiator.AppInstanceID = instanceId.ToString();
                    initiator.ProcessGUID = processGUID;
                    initiator.UserID = LoginUserID.ToString();
                    initiator.UserName = LoginUserName;
                    initiator.Conditions = GetCondition(string.Format("flag-{0}", WorkFlows.IsStartedByBgsUser(instanceId, 2) ? "0" : flag));
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
                            WFBizType = (int)WfName.合同流程,
                            CreatedUserID = LoginUserID,
                            CreatedUserName = LoginUserName,
                            LoginRoleID = LoginRoleID,
                            CreatedDate = DateTime.Now
                        };
                        UploadFileID = UploadFileBll.Add(uploadEntity);
                    }
                    //送往下一步                  
                    initiator.NextActivityPerformers = nextActivityPerformers;
                    WfExecutedResult runAppResult = service.RunProcessApp(initiator);
                    if (runAppResult.Status != WfExecutedStatus.Success)
                    {
                        base.RegisterStartupScript("", "<script>alert('" + runAppResult.Message + "');</script>");
                        return;
                    }
                    //保存业务数据                  
                    ContractOpinionEntity contractOpinionEntity = new ContractOpinionEntity();
                    contractOpinionEntity.AppInstanceID = instanceId.ToString();
                    contractOpinionEntity.ActivityID = System.Guid.Empty.ToString();
                    contractOpinionEntity.ActivityName = "合同经办人";
                    contractOpinionEntity.Remark = "";
                    contractOpinionEntity.ChangedTime = now;
                    contractOpinionEntity.ChangedUserID = LoginUserID;
                    contractOpinionEntity.ChangedUserName = LoginUserName;
                    contractOpinionEntity.UploadFileID = UploadFileID;
                    contractOpinionEntity.LoginRoleID = LoginRoleID;
                    ContractOpinionBll.Add(contractOpinionEntity);
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