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
    public partial class Person : System.Web.UI.Page
    {
        #region "Common Function"

        /// <summary>
        /// Bind danh sách người dùng theo nhóm
        /// </summary>
        private void BindData()
        {
            BUserGroup ctl = new BUserGroup();
            OUserGroup obj = new OUserGroup();
            //grvListUserGroups.DataSource = ctl.Get(obj);
            //grvListUserGroups.DataBind();
        }

        #endregion

        #region "Events"


        /// <summary>
        /// Load data
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            BindData();
        }

        /// <summary>
        /// Cập nhật mật khẩu mới
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lbtChangedPassword_Click(object sender, EventArgs e)
        {
            if (Global.UserInfo.Password != txtCurrentPassword.Text.Trim())
            {
                lblErrorChangedPass.Text = "Mật khẩu hiện tại không hợp lệ!.";
            }
            else
            {
                if (txtNewPassword.Text.Trim() != txtConfirmNewPassword.Text.Trim())
                {
                    lblErrorChangedPass.Text = "Mật khẩu mới hoặc xác nhận mật khẩu mới không hợp lệ!.";
                }
                lblErrorChangedPass.Text = "";
                Global.UserInfo.Password=txtConfirmNewPassword.Text.Trim();
                OUser obj = Global.UserInfo;
                (new BUser()).Update(obj.UserName, obj.Password);
                RegisterClientScriptBlock("Notification", "<script language='javascript'>alert('Thay đổi mật khẩu thành công');</script>");
            }
        }

        #endregion




    }
}
