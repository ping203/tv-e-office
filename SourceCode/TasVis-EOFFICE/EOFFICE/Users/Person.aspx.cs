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

        #endregion


    }
}
