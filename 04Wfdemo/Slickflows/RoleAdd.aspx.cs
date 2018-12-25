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
    public partial class RoleAdd : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {                
                btnSave.Attributes.Add("OnClick", "return RoleAddVerify()");

            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string RoleCode = TxtRoleCode.Value;
                string RoleName = TxtRoleName.Value;

                SysRoleEntity role = new SysRoleEntity()
                {
                    RoleCode = RoleCode,
                    RoleName = RoleName
                };
                if (WorkFlows.AddSysRole(role) > 0)
                {
                    base.RegisterStartupScript("", "<script>alert('添加成功！');</script>");
                }
                else
                {
                    base.RegisterStartupScript("", "<script>alert('添加失败！');</script>");

                }
            }
            catch (Exception ex)
            {

                base.RegisterStartupScript("", "<script>alert('添加出现异常 EXCEPTION:" + ex.ToString() + "');</script>");
            }
        }
    }
}