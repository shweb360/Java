using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Slickflow.Engine.Business.Entity;
using Slickflow.Engine.Service;
using Slickflow.WebDemo.Business;
using Slickflow.WebDemo.Common;

namespace Slickflow.WebDemo.Slickflows
{
    public partial class UserList : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                InitUserList();
            }
        }
        protected void InitUserList()
        {
            RepUserList.DataSource = WorkFlows.GetSysUser("");
            RepUserList.DataBind();
        }

        protected void delete_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < this.RepUserList.Items.Count; i++)
            {
                CheckBox chk = (CheckBox)this.RepUserList.Items[i].FindControl("cbxSonger");
                Label lb = (Label)this.RepUserList.Items[i].FindControl("Label1");
                if (chk != null && lb != null)
                {
                    if (chk.Checked)
                    {
                        string id = lb.Text.ToString();
                        int a = WorkFlows.DeleteSysUser(id);
                        if (a > 0)
                        {
                            Response.Write("<script>alert('删除成功！');</script>");
                            InitUserList();
                        }
                        else
                        {
                            Response.Write("<script>alert('删除失败！');</script>");                                                       
                        }
                    }
                }
            }
            
        }

        protected void add_Click(object sender, EventArgs e)
        {
            Response.Redirect("UserAdd.aspx");
        }
    }
}