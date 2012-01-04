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
using DataAccess.DataObject;
using DataAccess.BusinessObject;

namespace EOFFICE.Works
{
    public partial class WorkGroupCreat : System.Web.UI.Page
    {
        static string prevPage = String.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                grvWorkGroup_Load();
                prevPage = Request.UrlReferrer.ToString();
            }
        }

        protected void grvWorkGroup_Load()
        {            
            BWorkGroup objWorkGroup = new BWorkGroup();
            grvWorkGroup.DataSource= objWorkGroup.Get(0);
            grvWorkGroup.DataBind();
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect(prevPage);
        }

        protected void btnBack2_Click(object sender, EventArgs e)
        {
            Response.Redirect(prevPage);
        }
    }
}
