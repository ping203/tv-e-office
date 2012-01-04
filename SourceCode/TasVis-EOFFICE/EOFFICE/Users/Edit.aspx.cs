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

namespace EOFFICE.Users
{
    public partial class Default : System.Web.UI.Page
    {
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
