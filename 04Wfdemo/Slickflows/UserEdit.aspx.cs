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
    public partial class UserEdit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int ID = Request.QueryString["ID"] != null ? int.Parse(Request.QueryString["ID"].ToString()) : 0;
                BindSelectRole();
                InitUserInfo(ID);
            }
        }

        private void InitUserInfo(int ID)
        {
           var User= WorkFlows.GetSysUserModel(ID);
           if (User != null)
           {
               this.TxtLoginName.Value = User.LoginName;
               this.TxtPassword.Value = User.Password;

               this.TxtUserName.Value = User.UserName;
               this.TxtMobile.Value = User.Mobile;
               this.TxtEMail.Value = User.EMail;
               this.TxtCardID.Value = User.CardID;
               

               this.SelectRole.SelectedIndex = SelectRole.Items.IndexOf(SelectRole.Items.FindByValue("1"));
               
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

        }
    }
}