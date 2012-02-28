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

namespace EOFFICE.Users
{
    public partial class UserInfo : System.Web.UI.Page
    {
        //Lấy tạm userName="vanhung"
        private string UserName = Global.UserInfo.UserName;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                KhoiTao();
            }            
        }

        protected void KhoiTao()
        {
            BUser BobjUser = new BUser();
            OUser objUser = new OUser();
            objUser = BobjUser.Get(UserName).First();

            lblUserName.Text = UserName;
            txtFullName.Text = objUser.FullName;
            txtDate.Text = objUser.BirthDay.ToString("dd/MM/yyyy");
            txtEmail.Text = objUser.Email;
            txtPhone.Text = objUser.PhoneNumber;
            txtTel.Text = objUser.Tel;
            txtAddress.Text = objUser.Address;
            //Load Giới tính
            BindGender();
        }

        private void BindGender()
        {
            ddlGender.Items.Clear();
            ddlGender.Items.Add(new ListItem("Nam", Gender.Male.ToString("D")));
            ddlGender.Items.Add(new ListItem("Nữ", Gender.Female.ToString("D")));
            ddlGender.Items.Add(new ListItem("Khác", Gender.Other.ToString("D")));
        }

        protected void btnCapNhat_Click(object sender, EventArgs e)
        {
            BUser BobjUser = new BUser();
            CultureInfo culture = new CultureInfo("fr-FR", true);
            DateTime BirthDay;
            string FullName = txtFullName.Text;
            string Email = txtEmail.Text;
            string Phone = txtPhone.Text;
            string Tel = txtTel.Text;
            string Address = txtAddress.Text;
            BirthDay=DateTime.Parse(txtDate.Text,culture,DateTimeStyles.NoCurrentDateDefault);
            if(BobjUser.Update(UserName,FullName,Email,Phone,Tel,ddlGender.SelectedValue,BirthDay,Address))
            {
                lblThongBao.Text="CẬP NHẬT THÀNH CÔNG!";
            }
            KhoiTao();
        }
    }
}
