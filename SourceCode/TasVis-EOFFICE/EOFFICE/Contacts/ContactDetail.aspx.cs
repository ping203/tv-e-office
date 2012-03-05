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
using DataAccess.Common;
using DataAccess.BusinessObject;

namespace EOFFICE.Contacts
{
    public partial class ContactDetail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                BindGender();
            }

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {

        }

        protected void btnDanhSach_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }

        protected void btnNhom_Click(object sender, EventArgs e)
        {
            Response.Redirect("ContactGroup.aspx");
        }

        protected void btnThem_Click(object sender, EventArgs e)
        {
            Response.Redirect("ContactCreate.aspx");
        }

        private void BindGender()
        {
            ddlGender.Items.Clear();            
            ddlGender.Items.Add(new ListItem("Nam", Gender.Male.ToString("D")));
            ddlGender.Items.Add(new ListItem("Nữ", Gender.Female.ToString("D")));
            ddlGender.Items.Add(new ListItem("Khác", Gender.Other.ToString("D")));
            ddlGender.DataBind();
        }

        protected void ddlContactGroup_Load()
        {
            int UserID = Global.UserInfo.UserID;
            BContactGroup Bobj = new BContactGroup();
            ddlContactGroup.DataSource = Bobj.GetByUser(UserID);
            ddlContactGroup.DataTextField = "GroupName";
            ddlContactGroup.DataValueField = "ContactGroupID";
            ddlContactGroup.DataBind();            
        }
    }
}
