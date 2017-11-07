using System;
using System.Data;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Xml;

public partial class home : System.Web.UI.Page
{
    protected string msg = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        //判断是否登录
        ManagePage mym = new ManagePage();
        if (!mym.IsAdminLogin())
        {
            Response.Write("<script>parent.location.href='index.aspx'</script>");
            Response.End();
        }
       
        if (!IsPostBack)
        {
            noticeBind();//通知公告
            salesTopBind();//销售周排行
        }
    }

  
    #region 绑定通知公告=================================
    protected void noticeBind()
    {
        ps_article bll = new ps_article();
        this.rptList_notice.DataSource = bll.GetList(13, " status=1 ", " sort_id asc, add_time desc");
        this.rptList_notice.DataBind();
    }
    #endregion

    #region 绑定销售周排行=================================
    protected void salesTopBind()
    {
        string _start_time = DateTime.Now.AddDays(-7).ToString("d") + " 00:00:00";
        string _stop_time = DateTime.Now.ToString("d") + " 23:59:59";
        ps_salse_depot bll = new ps_salse_depot();
        string salesTop = "";
        DataTable dt = bll.GetListSql("select top 10 depot_id,zongprice,zongcount from (select depot_id,sum(real_price*quantity) as zongprice ,count(id) as zongcount from [ps_salse_depot] where  add_time between  '" + DateTime.Parse(_start_time) + "' and '" + DateTime.Parse(_stop_time) + "' group by depot_id) a order by a.zongprice desc").Tables[0];
        foreach (DataRow dr in dt.Rows)
        {
            salesTop = salesTop + new ps_depot().GetTitle(Convert.ToInt32(dr["depot_id"].ToString())) + "   购买金额：" + MyConvert(dr["zongprice"].ToString()) + "    购买量：" + dr["zongcount"].ToString() + ",";
        }

        string salesTop_price = "";
        DataTable dtp = bll.GetListSql("select top 10 depot_id,zongprice from (select depot_id,sum(real_price*quantity) as zongprice from [ps_salse_depot] where  add_time between  '" + DateTime.Parse(_start_time) + "' and '" + DateTime.Parse(_stop_time) + "' group by depot_id) a order by a.zongprice desc").Tables[0];
        foreach (DataRow dr in dtp.Rows)
        {
            salesTop_price = salesTop_price + dr["zongprice"].ToString() + ",";
        }

        DataTable dtmy = bll.GetListSql("select top 1 depot_id,zongprice,zongcount from (select depot_id,sum(real_price*quantity) as zongprice ,count(id) as zongcount from [ps_salse_depot] where depot_id=" + Convert.ToInt32(Session["DepotID"]) + " and add_time between  '" + DateTime.Parse(_start_time) + "' and '" + DateTime.Parse(_stop_time) + "' group by depot_id) a order by a.zongprice desc").Tables[0];
        foreach (DataRow dr in dtmy.Rows)
        {
            Lit_mysalse.Text = "<font color=red>" + new ps_depot().GetTitle(Convert.ToInt32(dr["depot_id"].ToString())) + "   购买金额：" + MyConvert(dr["zongprice"].ToString()) + "    购买量：" + dr["zongcount"].ToString() + "</font>";
        }

        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.Load(Server.MapPath("piedata.xml"));
        //获得节点列表
        XmlNode xmlNode = xmlDoc.DocumentElement.ChildNodes.Item(0);
        xmlNode["pie_num"].InnerText = Utils.DelLastComma(salesTop_price);
        xmlNode["pie_name"].InnerText = Utils.DelLastComma(salesTop);
        xmlDoc.Save(Server.MapPath("piedata.xml"));
    }
    #endregion

    //小数位是0的不显示
    public string MyConvert(object d)
    {
        string myNum = d.ToString();
        string[] strs = d.ToString().Split('.');
        if (strs.Length > 1)
        {
            if (Convert.ToInt32(strs[1]) == 0)
            {
                myNum = strs[0];
            }
        }
        return myNum;
    }
   
}