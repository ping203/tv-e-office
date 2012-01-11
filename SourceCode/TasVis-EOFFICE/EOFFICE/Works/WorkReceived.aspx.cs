using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using DataAccess.BusinessObject;
using DataAccess.Common;
using DataAccess.DataObject;
using System.Collections.Specialized;
using System.Web.Configuration;

namespace EOFFICE.Works
{
    public partial class WorkReceived : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ddlWorkGroup_Load();
                ddlWork_Load();
                grvWork_Load();
            }
        }

        protected void ddlWorkGroup_Load()
        {
            ListItem lit = new ListItem("--Chọn nhóm công việc--", "0");
            BWorkGroup bwg = new BWorkGroup();
            ddlWorkGroup.DataSource = bwg.Get(0);
            ddlWorkGroup.DataTextField = "Name";
            ddlWorkGroup.DataValueField = "WorkGroupID";

            ddlWorkGroup.DataBind();
            ddlWorkGroup.Items.Insert(0, lit);
        }

        protected void ddlWork_Load()
        {
            NameValueCollection appSettings = WebConfigurationManager.AppSettings as NameValueCollection;
            string str = appSettings["CONG_VIEC_CAN_HOAN_THANH"];
            string str1 = appSettings["CONG_VIEC_DA_XY_LY"];
            ListItem[] lit = new ListItem[3];
            lit[0] = new ListItem("Tất cả", "0");
            lit[1] = new ListItem(str, "CONG_VIEC_CAN_HOAN_THANH");
            lit[2] = new ListItem(str1, "CONG_VIEC_DA_XY_LY");
            ddlWork.Items.Add(lit[0]);
            ddlWork.Items.Add(lit[1]);
            ddlWork.Items.Add(lit[2]);
        }

        protected void grvWork_Load()
        {
            BWork objWork = new BWork();
            grvWork.DataSource = objWork.Get(1, "CONG_VIEC_CAN_HOAN_THANH").Union(objWork.Get(1, "CONG_VIEC_DA_XY_LY"));
            grvWork.DataBind();
        }
    }
}
