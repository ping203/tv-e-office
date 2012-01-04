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

namespace EOFFICE.Users
{
    public partial class Edit : System.Web.UI.Page
    {
        #region "Valid"
        /// <summary>
        /// Kiểm tra sự tồn tại của username
        /// </summary>
        /// <returns></returns>
        private bool IsUsernameValid()
        {
            BUser ctl = new BUser();
            if (ctl.Get(txtUsername.Text.Trim()).Count > 0)
                //--Nếu tồn tại 
                return false;
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
            drdGender.Items.Clear();
            drdGender.Items.Add(new ListItem("Nam", Gender.Male.ToString("D")));
            drdGender.Items.Add(new ListItem("Nữ", Gender.Female.ToString("D")));
            drdGender.Items.Add(new ListItem("Khác", Gender.Other.ToString("D")));
        }

        /// <summary>
        /// Load danh sách phòng ban
        /// </summary>
        private void BindDepartment()
        {
            BDepartment ctl = new BDepartment();
            drdDepartment.DataSource = ctl.Get(0);
            drdDepartment.DataBind();
        }

        /// <summary>
        /// Load danh sách nhóm người dùng
        /// </summary>
        private void BindGroup()
        {
            BGroup ctl = new BGroup();
            drdGroup.DataSource = ctl.Get(0);
            drdGroup.DataBind();
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
            //--Load danh sách giới tính
            BindGender();
            //--Load danh sách phòng ban
            BindDepartment();
            //--Load danh sách nhóm người dùng
            BindGroup();
        }


        /// <summary>
        /// Sự kiện
        /// Cập nhật thông tin người dùng
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lnkUpdate_Click(object sender, EventArgs e)
        {

        }
        #endregion



    }
}
