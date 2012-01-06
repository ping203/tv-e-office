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
using DataAccess.DataObject;
using DataAccess.Common;

namespace EOFFICE.Works
{
    public partial class Default : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ddlWorkGroup_Load();
                
            }
        }

        protected void ddlWorkGroup_Load()
        {
            ddlWorkGroup.Items.Clear();
            ListItem lit = new ListItem("-- Chọn loại công việc --", "0");
            ddlWorkGroup.Items.Add(lit);
            BWorkGroup bwg = new BWorkGroup();
            ddlWorkGroup.DataSource = bwg.Get(0);
            ddlWorkGroup.DataTextField = "Name";
            ddlWorkGroup.DataValueField = "WorkGroupID";
            ddlWorkGroup.DataBind();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            OWork objWork = new OWork();
            objWork.Name = txtWorkName.Text;
            objWork.Description = txtDescription.Text;
            objWork.Content = txtContent.Text;
            //objWork.Attachs=
        }

        
    }
}
