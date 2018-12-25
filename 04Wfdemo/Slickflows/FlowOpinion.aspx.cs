using System;
using System.Web.UI;
using System.Data;
using Slickflow.WebDemo.Business;
using Slickflow.WebDemo.Common;


namespace Slickflow.WebDemo.Slickflows
{
    public partial class FlowOpinion : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                InitFlowOpinion();
            }
        }

        protected void InitFlowOpinion()
        {
            string AppName = Request.QueryString["AppName"] == null ? string.Empty : Request.QueryString["AppName"].ToString();
            string AppInstanceID = Request.QueryString["AppInstanceID"] == null ? string.Empty : Request.QueryString["AppInstanceID"].ToString();
            if (!string.IsNullOrEmpty(AppInstanceID))
            {
                string StrTableName = GetOpinionTableName(AppName);
                int KStype = GetKsType(LoginRoleName);
               
                //财务主管,可查看所有科室情况，
                if (LoginRoleID == (int)WfRole.财务主管 || LoginRoleID == (int)WfRole.劳资)
                {
                    Repeater1.Visible = true;
                    Repeater1.DataSource = WorkFlows.GetOpinionListByAppInstanceID(StrTableName,AppInstanceID);
                    Repeater1.DataBind();                   
                }
                else if (LoginRoleID == (int)WfRole.站长 && AppName != "合同流程" && AppName != "采购流程")
                {
                    Repeater1.Visible = true;
                    Repeater1.DataSource = WorkFlows.GetOpinionSummary(StrTableName, AppInstanceID);
                    Repeater1.DataBind();  
                }
                else
                {
                    Repeater2.Visible = true;                    
                    Repeater2.DataSource = WorkFlows.GetOpinionListByAppInstanceID(KStype, StrTableName, AppInstanceID);
                    Repeater2.DataBind();                   
                }
                
            }
            else
            {
                Repeater1.DataBind();
            }
                Repeater1.DataSource = null;
        }

        public string Getpath(string UploadFileID)
        {
            string path="";
            int id=Convert.ToInt32(UploadFileID);
            //var m=UploadFileBll.GetModelByUserID(int.Parse(AppInstanceID), 0, int.Parse(UserID));
            var m = UploadFileBll.GetModel(id);
            if (m != null && !string.IsNullOrEmpty(m.FilePath))
            {
                path = "<a href='" + m.FilePath.Replace("~", "") + "'>下载</a>";
            }
            return path; 
        }
    }
}