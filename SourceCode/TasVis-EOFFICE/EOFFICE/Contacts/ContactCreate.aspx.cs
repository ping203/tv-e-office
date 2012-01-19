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
using System.Globalization;

namespace EOFFICE.Contacts
{
    public partial class ContactCreate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            { 
                ddlContactGroup_Load();
            }
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

        protected void ddlContactGroup_Load()
        {
            BContactGroup Bobj = new BContactGroup();
            ddlContactGroup.DataSource = Bobj.GetByUser(1);
            ddlContactGroup.DataTextField = "GroupName";
            ddlContactGroup.DataValueField = "ContactGroupID";
            ddlContactGroup.DataBind();
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            CultureInfo culture = new CultureInfo("fr-FR", true);
            BContact BobjContact = new BContact();
            OContact objContact = new OContact();
            objContact.ContactName = "";
            objContact.TitleName = ddlXungDanh.SelectedValue.ToString();
            objContact.FullName = txtFullName.Text;
            objContact.Phone = txtPhone.Text;
            objContact.Tel = txtTel.Text;
            objContact.Email = txtEmail.Text;
            objContact.BirthDay = DateTime.Parse(txtBirthDay.Text, culture, DateTimeStyles.NoCurrentDateDefault);
            objContact.Gender = ddlGender.SelectedValue.ToString();
            objContact.Job = txtJob.Text;
            objContact.Address = txtAddress.Text;
            objContact.Other = txtOther.Text;
            objContact.IDContactGroup = int.Parse(ddlContactGroup.SelectedValue.ToString());
            objContact.IDUser = 1;//Lấy IDUser sau

            if (BobjContact.Add(objContact))
            {
                lblThongBao.Text = "BẠN ĐÃ THÊM DANH BẠ THÀNH CÔNG!";
            }
        }
    }
}
