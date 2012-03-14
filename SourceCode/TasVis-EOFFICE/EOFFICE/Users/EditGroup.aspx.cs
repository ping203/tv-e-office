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

namespace EOFFICE.Users
{
    public partial class EditGroup : System.Web.UI.Page
    {
        #region "Propertys"
        /// <summary>
        /// Lưu mã nhóm người dùng
        /// </summary>
        public int GroupId
        {
            get
            {
                if (Request.QueryString["GroupId"] != null)
                {
                    return int.Parse(Request.QueryString["GroupId"]);
                }
                else
                {
                    return 0;
                }
            }
        }
        #endregion
        #region "Valid"
        /// <summary>
        /// Kiểm tra sự tồn tại của tên nhóm
        /// </summary>
        /// <returns></returns>
        private bool IsNameValid()
        {
            BGroup ctl = new BGroup();
            if (ctl.Get(txtName.Text.Trim()).Count > 0 && GroupId < 1)
            {
                RegisterClientScriptBlock( "notifycation", "<script language='javascript'>alert('Nhóm người dùng đã tồn tại.');</script>");
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
        /// Cập nhật thông tin nhóm người dùng
        /// </summary>
        private void UpdateGroup()
        {
            if (!IsNameValid())
                return;
            BGroup ctl = new BGroup();
            OGroup obj;
            try
            {
                if(GroupId>0)
                obj = ctl.Get(GroupId)[0];
                else
                    obj = new OGroup();
            }catch(Exception ex)
            {
                obj = new OGroup();
            }
            //-- gán thông tin cho đối tượng nhóm người dùng
            obj.Description = txtDescription.Text;
            //-- Cập nhật User
            if (obj.GroupID > 0)
            {
                ctl.Update(obj.GroupID, obj.Name, obj.Description);
            }
            //--Thêm mới User
            else
            {
                obj.Name = txtName.Text;
                ctl.Add(obj);
            }
            //--Về trang quản lý nhóm người dùng
            Response.Redirect("Group.aspx");
            
        }

        /// <summary>
        /// Khởi tạo dữ liệu
        /// </summary>
        private void InitData()
        {
            BUser ctlUP = new BUser();
            if (!Global.IsAdmin())
                Response.Redirect("/permission-fail.aspx");
            BGroup ctl = new BGroup();
            OGroup obj = new OGroup();
            try
            {
                //-- kiểm tra và lấy về nhóm người dùng cần sửa
                if (GroupId>0)
                    obj = ctl.Get(GroupId)[0];
                else
                    return;
                txtDescription.Text = obj.Description;
                txtName.Text = obj.Name;
                txtName.Visible = false;
                lblName.Text = obj.Name;
                lblName.Visible = true;
                
                
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
                //-- Load dữ liệu insert
                InitData();
            }
           
        }


        /// <summary>
        /// Sự kiện
        /// Cập nhật thông tin nhóm người dùng
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lnkUpdate_Click(object sender, EventArgs e)
        {
            UpdateGroup();
        }
        #endregion



    }
}
