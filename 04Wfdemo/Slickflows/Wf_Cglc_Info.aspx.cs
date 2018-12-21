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
    public partial class Wf_Cglc_Info : BasePage
    {
        public string strUrl = "";
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
                    var m = UploadFileBll.GetModel(ID, (int)WfName.采购流程, (int)WfRole.采购经办人);
                    strUrl = m != null ? m.FilePath : "";

                }
            }
        }
    }
}