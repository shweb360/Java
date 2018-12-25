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
    public partial class MenuList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                InitMenuList();
            }
        }
        protected void InitMenuList()
        {
            RepMenuList.DataSource = WorkFlows.GetSysMenu();
            RepMenuList.DataBind();
        }

        protected void add_Click(object sender, EventArgs e)
        {
            Response.Redirect("MenuAdd.aspx");
        }

        protected void delete_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < this.RepMenuList.Items.Count; i++)
            {
                CheckBox chk = (CheckBox)this.RepMenuList.Items[i].FindControl("cbxSonger");
                Label lb = (Label)this.RepMenuList.Items[i].FindControl("Label1");
                if (chk != null && lb != null)
                {
                    if (chk.Checked)
                    {
                        string id = lb.Text.ToString();
                        int a = WorkFlows.DeleteSysMenu(id);
                        if (a > 0)
                        {
                            Response.Write("<script>alert('删除成功！');</script>");                           
                            InitMenuList();
                        }
                        else
                        {
                            Response.Write("<script>alert('删除失败！');</script>");                            
                        }
                    }
                }
            }
        }
    }
}