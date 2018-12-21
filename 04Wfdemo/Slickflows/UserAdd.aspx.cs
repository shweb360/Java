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
    public partial class UserAdd : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //添加客户端事件  
                btnSave.Attributes.Add("OnClick", "return UserAddVerify()");
                BindSelectRole();
            }
            
        }

        protected void BindSelectRole()
        {
            this.SelectRole.DataSource = WorkFlows.GetSysRole();
            this.SelectRole.DataTextField = "RoleName";
            this.SelectRole.DataValueField = "ID";
            this.SelectRole.DataBind();
            this.SelectRole.Items.Insert(0, new ListItem("请选择", ""));  
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string LoginName = TxtLoginName.Value;
                string Password = TxtPassword.Value;
                string UserName = TxtUserName.Value;
                string Mobile = TxtMobile.Value;
                string EMail = TxtEMail.Value;
                string CardID = TxtCardID.Value;

                SysUserEntity user = new SysUserEntity()
                {

                    LoginName = LoginName,
                    Password = Password,
                    UserName = UserName,
                    Mobile = Mobile,
                    EMail = EMail,
                    CardID = CardID,
                    CreatedDate = DateTime.Now
                };
                if (WorkFlows.AddSysUser(user) > 0)
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