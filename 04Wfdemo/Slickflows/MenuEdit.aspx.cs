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
    public partial class MenuEdit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int ID = Request.QueryString["ID"] != null ? int.Parse(Request.QueryString["ID"].ToString()) : 0;
                InitMenuInfo(ID);
                TxtMenuID.Value = ID.ToString();
            }
        }
        private void InitMenuInfo(int ID)
        {
            var menu = WorkFlows.GetSysMenuModel(ID);
            if (menu != null)
            {
                this.TxtMenuName.Value = menu.MenuName;
                this.TxtMenuUrl.Value = menu.MenuUrl;
            }
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            int ID = int.Parse(TxtMenuID.Value);
            var menu = WorkFlows.GetSysMenuModel(ID);
            if (menu != null)
            {
                menu.MenuName = this.TxtMenuName.Value;
                menu.MenuUrl = this.TxtMenuUrl.Value;
                if (WorkFlows.UpdateSysMenu(menu))
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