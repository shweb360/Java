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
using Slickflow.Engine.Business.Manager;
using System.Web;

namespace Slickflow.WebDemo.Slickflows
{
    public partial class Wf_Ysbz_Info : BasePage
    {
        public string strUrl = "", strUrl2 = "";
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
                FinancialEntity financialEntity = FinancialBll.GetModel(ID);

                if (financialEntity != null && financialEntity.ID > 0)
                {
                    txtApplyTitle.Value = financialEntity.ApplyTitle;
                    txtApplyContent.Value = financialEntity.ApplyContent;
                    txtApplyDate.Value = financialEntity.ApplyDate.ToString("yyyy-MM-dd");
                    hiddenInstanceId.Value = financialEntity.ID.ToString();

                    var m = UploadFileBll.GetModel(ID, 1, 23);
                    strUrl = m != null ? m.FilePath : "";

                }
            }
          
        }
       
    }
}