using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Slickflow.WebDemo.Business;
using Slickflow.WebDemo.Common;
using Slickflow.WebDemo.Entity;

using Slickflow.Engine.Common;
using Slickflow.Engine.Core.Result;
using Slickflow.Engine.Service;
namespace Slickflow.WebDemo.Slickflows
{
    public partial class Wf_Ysbz_Start : BasePage
    {       
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                
                txtProcessGUID.Value = Wf_Ysbz_ProcessConfig[0].ToString();
                if (LoginRoleID > 0)
                {
                    HttpContext.Current.Session["RoleId"] = ((int)WfRole.办公室财务).ToString();
                     
                }
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string processGUID = Wf_Ysbz_ProcessConfig[0].ToString();
                string strNextActivityPerformers = hiddenNextActivityPerformers.Value.ToString().Trim();
                IDictionary<string, PerformerList> nextActivityPerformers = NextActivityPerformers(strNextActivityPerformers);
                if (nextActivityPerformers == null)
                {
                    base.RegisterStartupScript("", "<script>alert('请选择办理步骤或办理人员');</script>");
                    return;
                }
                DateTime now = DateTime.Now;
                //预算编制流程业务数据
                FinancialEntity financialEntity = new FinancialEntity();
                financialEntity.ApplyTitle = this.txtApplyTitle.Value;
                financialEntity.ApplyContent = this.txtApplyContent.Value;
               
                financialEntity.FinancialType = 1;                
                try
                {
                    financialEntity.ApplyDate = Helper.ConvertToDateTime(this.txtApplyDate.Value, now);
                }
                catch (Exception ex)
                {
                    financialEntity.ApplyDate = now;
                }                
                financialEntity.CurrentActivityText = string.Empty;
                financialEntity.Status = 0;
                financialEntity.CreatedUserID = LoginUserID;
                financialEntity.CreatedUserName = this.LoginUserName;
                financialEntity.CreatedDate = now;
                financialEntity.Attachment = "";
                financialEntity.AKsfzrRemark = "";
                financialEntity.AKsfgldRemark = "";
                financialEntity.ZzRemark = "";
                financialEntity.BKsfzrRemark = "";
                financialEntity.BKsfgldRemark = "";
                financialEntity.KzRemark = "";
                financialEntity.FgldRemark = "";
                financialEntity.CwRemark = "";
                int instanceId = FinancialBll.Add(financialEntity);
                if (instanceId > 0)
                {
                    //调用流程
                    IWorkflowService service = new WorkflowService();

                    WfAppRunner initiator = new WfAppRunner();
                    initiator.AppName = "预算编制流程";
                    initiator.AppInstanceID = instanceId.ToString();
                    initiator.ProcessGUID = processGUID;
                    initiator.UserID = LoginUserID.ToString();
                    initiator.UserName = LoginUserName;

                    initiator.Conditions = GetCondition(string.Format("flag-{0}", "1"));

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
                            WFBizType = (int)WfName.预算编制流程,
                            CreatedUserID = LoginUserID,
                            CreatedUserName = LoginUserName,
                            LoginRoleID = LoginRoleID,
                            CreatedDate = DateTime.Now
                        };
                        UploadFileID=UploadFileBll.Add(uploadEntity);
                       
                    }

                    FinancialOpinionEntity financialOpinionEntity = new FinancialOpinionEntity();
                    financialOpinionEntity.AppInstanceID = instanceId.ToString();
                    financialOpinionEntity.ActivityID = System.Guid.Empty.ToString();
                    financialOpinionEntity.ActivityName = "流程发起";
                    financialOpinionEntity.Remark = "";
                    financialOpinionEntity.ChangedTime = now;
                    financialOpinionEntity.ChangedUserID = LoginUserID;
                    financialOpinionEntity.ChangedUserName = LoginUserName;
                    financialOpinionEntity.UploadFileID = UploadFileID;
                    financialOpinionEntity.LoginRoleID = LoginRoleID;
                    FinancialOpinionBll.Add(financialOpinionEntity);
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