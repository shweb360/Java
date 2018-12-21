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
    public partial class Wf_Ht_Info : BasePage
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
                ContractEntity contractEntity = ContractBll.GetModel(ID);

                if (contractEntity != null && contractEntity.ID > 0)
                {
                    txtApplyTitle.Value = contractEntity.ApplyTitle;
                    txtPartyA.Value = contractEntity.PartyA;
                    txtPartyB.Value = contractEntity.PartyB;
                    txtSigningDate.Value = contractEntity.SigningDate.ToString("yyyy-MM-dd");
                    txtAmount.Value = contractEntity.Amount.ToString();
                    txtTimeLimit.Value = contractEntity.TimeLimit;
                    txtRemark.Value = contractEntity.Remark;
                    selectApplyType.SelectedIndex = contractEntity.ApplyType;
                    hiddenInstanceId.Value = contractEntity.ID.ToString();
                    hiddenActivityInstanceID.Value = contractEntity.ToString();
                    var m = UploadFileBll.GetModel(ID,  (int)WfName.合同流程, (int)WfRole.科室员工);
                    strUrl = m != null ? m.FilePath : "";

                }
            }
        }
    }
}