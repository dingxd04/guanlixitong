using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class left : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //判断是否登录
        ManagePage mym = new ManagePage();
        if (!mym.IsAdminLogin())
        {
            Response.Write("<script>parent.location.href='index.aspx'</script>");
            Response.End();
        }

        if (!Page.IsPostBack)
        {
            articleBind();
        }
    }

    #region 绑定菜单=================================

    protected void articleBind()
    {
        ps_manager_role_value myrv = new ps_manager_role_value();
        string sqlstr = "parent_id=0 and(1=2 or ";
        DataTable dt = myrv.GetList("role_id=" + Convert.ToInt32(Session["RoleID"]) + "").Tables[0];
        if (dt.DefaultView.Count > 0)
        {
            for (int i = 0; i < dt.DefaultView.Count; i++)
            {
                sqlstr = sqlstr + "id=" + dt.Rows[i]["nav_id"].ToString() + " or ";
            }
        }
        sqlstr = sqlstr + "1=2) order by sort_id";
        ps_navigation bll = new ps_navigation();
        this.repCategory.DataSource = bll.GetList(sqlstr);
        this.repCategory.DataBind();
 
    }

    protected void bsClassList(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            int ID = Convert.ToInt32(((DataRowView)e.Item.DataItem).Row["ID"].ToString());//获得对应ID
            Repeater sClass = (Repeater)e.Item.FindControl("childCategory");//找到要绑定数据的Repeater
            if (sClass != null)
            {
                ps_manager_role_value myrv = new ps_manager_role_value();
                string sqlstr = "parent_id=" + ID + "  and(1=2 or ";
                DataTable dt = myrv.GetList("role_id=" + Convert.ToInt32(Session["RoleID"]) + "").Tables[0];
                if (dt.DefaultView.Count > 0)
                {
                    for (int i = 0; i < dt.DefaultView.Count; i++)
                    {
                        sqlstr = sqlstr + "id=" + dt.Rows[i]["nav_id"].ToString() + " or ";
                    }
                }
                sqlstr = sqlstr + "1=2) order by sort_id";
                ps_navigation bll = new ps_navigation();
                sClass.DataSource = bll.GetList(sqlstr);
                sClass.DataBind();
            }
        }
    }

    #endregion
}