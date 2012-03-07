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
using DataAccess.DataObject;
using System.Globalization;

namespace EOFFICE.Contacts
{
    public partial class ContactDetail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                BindGender();
                ddlContactGroup_Load();
                Infomation_Load();
            }

        }

        protected void Infomation_Load()
        {
            int ContactID = int.Parse(Request.QueryString["ID"].ToString());
            int UserID = Global.UserInfo.UserID;

            BContact Bobj = new BContact();
            OContact obj = new OContact();
            obj = Bobj.Get(ContactID, UserID).First();

            txtFullName.Text = obj.FullName;
            txtBirthDay.Text = obj.BirthDay.ToString("dd/MM/yyyy");
            txtAddress.Text = obj.Address;
            txtEmail.Text = obj.Email;
            txtJob.Text = obj.Job;
            txtOther.Text = obj.Other;
            txtPhone.Text = obj.Phone;
            txtTel.Text = obj.Tel;

            ddlContactGroup.SelectedValue = obj.IDContactGroup.ToString();
            ddlGender.SelectedValue = obj.Gender;
            ddlXungDanh.SelectedValue = obj.TitleName;
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            int ContactID = int.Parse(Request.QueryString["ID"].ToString());
            int UserID = Global.UserInfo.UserID;

            BContact Bobj = new BContact();
            
            string FullName=txtFullName.Text;
            CultureInfo culture = new CultureInfo("fr-FR", true);
            DateTime BirthDay = DateTime.Parse(txtBirthDay.Text, culture, DateTimeStyles.NoCurrentDateDefault);
            string ContactName = "";
            string TitleName = ddlXungDanh.SelectedValue;
            string Phone = txtPhone.Text;
            string Tel = txtTel.Text;
            string Gender = ddlGender.SelectedValue.ToString();
            string Job = txtJob.Text;
            string Address = txtAddress.Text;
            string Other = txtOther.Text;
            int ContactGroup = int.Parse(ddlContactGroup.SelectedValue);
            string Email = txtEmail.Text;
            if (Bobj.Update(ContactID, ContactName, FullName, TitleName, Phone, Tel, BirthDay, Gender, Job, Address, ContactGroup, UserID, Other, Email))
            {
                lblThongBao.Text = "Cập nhật thành công!";
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
