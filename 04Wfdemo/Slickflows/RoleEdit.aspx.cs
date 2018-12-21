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
using Slickflow.Module.Resource;
namespace Slickflow.WebDemo.Slickflows
{
    public partial class RoleEdit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {                
                int ID = Request.QueryString["ID"] != null ? int.Parse(Request.QueryString["ID"].ToString()) : 0;
                InitRoleInfo(ID);
                TxtRoleID.Value = ID.ToString();
            }
        }
        private void InitRoleInfo(int ID)
        {
            var Role = WorkFlows.GetSysRoleModel(ID);
            if (Role != null)
            {
                this.TxtRoleCode.Value = Role.RoleCode;
                this.TxtRoleName.Value = Role.RoleName;
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            int ID = int.Parse(TxtRoleID.Value);
            var Role = WorkFlows.GetSysRoleModel(ID);
            if (Role != null)
            {
                Role.RoleCode = this.TxtRoleCode.Value;
                Role.RoleName = this.TxtRoleName.Value;
                if (WorkFlows.UpdateSysRole(Role))
                {
                    base.RegisterStartupScript("", "<script>alert('更新成功！');</script>");
                }
                else
                {
                    base.RegisterStartupScript("", "<script>alert('更新失败！');</script>");
                }
            }
        }

    }
}