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

namespace EOFFICE
{

    public partial class DocumentEdit : System.Web.UI.Page
    {
        #region "Propertys"
        /// <summary>
        /// Lưu mã người dùng
        /// </summary>
        public string Username
        {
            get {
                if (Request.QueryString["Username"] != null)
                {
                    return Request.QueryString["Username"];
                }
                else
                {
                    return "";
                }
            }
        }
        #endregion
        #region "Valid"
        /// <summary>
        /// Kiểm tra sự tồn tại của username
        /// </summary>
        /// <returns></returns>
        private bool IsUsernameValid()
        {
            BUser ctl = new BUser();
            if (ctl.Get(txtUsername.Text.Trim()).Count > 0 && string.IsNullOrEmpty(Username))
            {
                RegisterClientScriptBlock( "notifycation", "<script language='javascript'>alert('Tài khoản đã tồn tại.');</script>");
                //--Nếu tồn tại 
                return false;
            }
            else
                //--Nếu không tồn tại thì pass
                return true;
        }

        #endregion
        #region "Common Function"

        /// <summary>
        /// Load danh sách giới tính
        /// </summary>
        private void BindGender()
        {
            ddlGender.Items.Clear();
            ddlGender.Items.Add(new ListItem("Nam", Gender.Male.ToString("D")));
            ddlGender.Items.Add(new ListItem("Nữ", Gender.Female.ToString("D")));
            ddlGender.Items.Add(new ListItem("Khác", Gender.Other.ToString("D")));
        }

        /// <summary>
        /// Load danh sách trạng thái
        /// </summary>
        private void BindStatus()
        {
            ddlStatus.Items.Clear();
            ddlStatus.Items.Add(new ListItem("Duyệt", UserStatus.Approve.ToString("D")));
            ddlStatus.Items.Add(new ListItem("Khóa", UserStatus.UnApprove.ToString("D")));
        }

        /// <summary>
        /// Load danh sách phòng ban
        /// </summary>
        private void BindDepartment()
        {
            BDepartment ctl = new BDepartment();
            ddlDepartment.DataSource = ctl.Get(0);
            ddlDepartment.DataBind();
        }

        /// <summary>
        /// Load danh sách nhóm người dùng
        /// </summary>
        private void BindGroup()
        {
            BGroup ctl = new BGroup();
            ddlGroup.DataSource = ctl.Get(0);
            ddlGroup.DataBind();
        }

        /// <summary>
        /// Cập nhật thông tin User
        /// </summary>
        private void UpdateUser()
        {
            if (!IsUsernameValid())
                return;
            BUser ctl = new BUser();
            OUser obj;
            try
            {
                if(!string.IsNullOrEmpty(Username))
                obj = ctl.Get(Username)[0];
                else
                    obj = new OUser();
            }catch(Exception ex)
            {
                obj = new OUser();
            }
            //-- gán thông tin cho đổi tượng người dùng
            obj.BirthDay = Convert.ToDateTime(txtBirthDay.Text.Trim());
            obj.Email = txtEmail.Text.ToString();
            obj.FullName = txtFullName.Text.Trim();
            obj.Gender = ddlGender.SelectedValue;
            obj.IDDepartment = int.Parse(ddlDepartment.SelectedValue);
            obj.IDGroup = int.Parse(ddlGroup.SelectedValue);
            obj.PhoneNumber = txtPhoneNumber.Text.Trim();
            obj.Tel  = txtTel.Text.Trim();
            obj.Address = txtAddress.Text.Trim();
            obj.Position = txtPossition.Text.Trim();
            obj.Status = ddlStatus.SelectedValue;
            //-- Cập nhật User
            if (obj.UserID > 0)
            {
                ctl.Update(obj.UserName, obj.FullName, obj.Email, obj.PhoneNumber, obj.Tel, obj.Gender, obj.BirthDay, obj.Address, obj.Position, "1", obj.IDDepartment);
                //RegisterClientScriptBlock("notifycation", "<script language='javascript'>alert('Cập nhật thành công.');</script>");
                Response.Redirect("Default.aspx");
            }
                //--Thêm mới User
            else
            {
                obj.UserName = txtUsername.Text.Trim();
                obj.Password = txtPassword.Text.Trim();
                ctl.Add(obj);
                Response.Redirect("Default.aspx");
            }
            
        }

        /// <summary>
        /// Khởi tạo dữ liệu
        /// </summary>
        private void InitData()
        {
            BUser ctl = new BUser();
            OUser obj=new OUser();
            try
            {
                //-- kiểm tra và lấy về thí sinh cần sửa
                if (!string.IsNullOrEmpty(Username))
                    obj = ctl.Get(Username)[0];
                else
                    return;
                txtUsername.Text = obj.UserName;
                lblUsername.Text = obj.UserName;
                tr_mk.Visible = false;
                tr_cmk.Visible = false;
                lblUsername.Visible = true;
                txtUsername.Visible = false;
                txtFullName.Text = obj.FullName;
                txtEmail.Text = obj.Email;
                txtPhoneNumber.Text = obj.PhoneNumber;
                txtTel.Text = obj.Tel;
                try
                {
                    ddlGender.Items.FindByValue(obj.Gender).Selected = true;
                }
                catch (Exception ex) { }
                txtBirthDay.Text = obj.BirthDay.ToString("dd/MM/yyyy");
                txtAddress.Text = obj.Address;
                txtPossition.Text = obj.Position;
                try
                {
                    ddlStatus.Items.FindByValue(obj.Status).Selected = true;
                }
                catch (Exception ex) { }
                try
                {
                    ddlDepartment.Items.FindByValue(obj.IDDepartment.ToString()).Selected = true;
                }
                catch (Exception ex) { }
                try
                {
                    ddlGroup.Items.FindByValue(obj.IDGroup.ToString()).Selected = true;
                }
                catch (Exception ex) { }
                
            }
            catch (Exception ex)
            {
            }
        }
        #endregion

        #region "Events"

        /// <summary>
        /// Sự kiện
        /// Load data
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //--Load danh sách giới tính
                BindGender();
                //--Load danh sách trạng thái
                BindStatus();
                //--Load danh sách phòng ban
                BindDepartment();
                //--Load danh sách nhóm người dùng
                BindGroup();
                //-- Load dữ liệu insert
                InitData();
            }
           
        }


        /// <summary>
        /// Sự kiện
        /// Cập nhật thông tin người dùng
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lnkUpdate_Click(object sender, EventArgs e)
        {
            UpdateUser();
        }

        /// <summary>
        /// Quay lại trang quản trị người dùng
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lnkBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Users/");
        }
        #endregion




    }
}
