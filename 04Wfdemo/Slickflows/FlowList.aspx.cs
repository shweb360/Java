using System;
using System.Collections.Generic;
using System.Web.UI;


using Slickflow.Engine.Business.Entity;
using Slickflow.Engine.Service;

using Slickflow.WebDemo.Business;
using Slickflow.WebDemo.Common;


namespace Slickflow.WebDemo.Slickflows
{
    public partial class FlowList : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                InitFlowList();
            }
        }

        protected void InitFlowList()
        {
            ALLFlow();//我经办的流程
            MyApplyFlow();//我发起的流程
            GetReadyTasks();//获取当前用户待办任务列表
        }


        /// <summary>
        /// 我经办的流程
        /// </summary>
        private void ALLFlow()
        {
            this.RepeaterALL.DataSource = WorkFlows.GetTaskList(string.Format(" and CreatedByUserID !={0} and EndedByUserID={1}", LoginUserID, LoginUserID));
            this.RepeaterALL.DataBind();
        }

        /// <summary>
        /// 我发起的流程
        /// </summary>
        private void MyApplyFlow()
        {
            this.RepeaterMyApply.DataSource = WorkFlows.GetMyProcessInstance(string.Format(" and CreatedByUserID={0}", LoginUserID));
            this.RepeaterMyApply.DataBind();
        }



        /// <summary>
        /// 获取当前用户待办任务列表
        /// </summary>
        private void GetReadyTasks()
        {
            IWorkflowService wfService = new WorkflowService();
            TaskQuery en = new TaskQuery
            {
                UserID = LoginUserID.ToString()
            };
            IList<TaskViewEntity> taskViewList = wfService.GetReadyTasks(en);
            if (taskViewList != null)
            {
                Repeater2.DataSource = taskViewList;
                Repeater2.DataBind();
            }

        }
        
    }
}