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
    public partial class Wf_Ygkq_Info : BasePage
    {
        public string strUrl = "";
        public bool isUpload = false;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                InitFlowInfo();
            }
        }

        protected void InitFlowInfo()
        {
            string AppInstanceID = Request.QueryString["AppInstanceID"] == null ? string.Empty : Request.QueryString["AppInstanceID"].ToString();

            if (!string.IsNullOrEmpty(AppInstanceID))
            {
                int ID = int.Parse(AppInstanceID);
                HrsLeaveEntity hrsLeaveEntity = WorkFlows.GetHrsLeaveModel(ID);

                if (hrsLeaveEntity != null && hrsLeaveEntity.ID > 0)
                {
                    txtApplyTitle.Value = hrsLeaveEntity.CurrentActivityText;
                    txtFromDate.Value = hrsLeaveEntity.FromDate.ToString("yyyy-MM-dd");
                    txtToDate.Value = hrsLeaveEntity.ToDate.ToString("yyyy-MM-dd");
                    hiddenInstanceId.Value = hrsLeaveEntity.ID.ToString();
                    var m = UploadFileBll.GetModel(ID, 6, 2);
                    strUrl = m != null ? m.FilePath : "";

                }
            }
        }
    }
}