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
using System.Collections.Generic;

namespace EOFFICE.Users
{
    public partial class Permission : System.Web.UI.Page
    {
        #region "Propertys"
            
        #endregion

        #region "Common Function"

          /// <summary>
        /// Bind danh sách các quyền trong hệ thống
        /// </summary>
        private void BindData()
        {
            BPermisionDefinition ctl = new BPermisionDefinition();
            grvListPermission.DataSource = ctl.Get(0, "", "");
            grvListPermission.DataBind();
           
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
            if (!IsPostBack)
            {
                //-- Load danh sách quyền
                BindData();
            }
        }

        /// <summary>
        /// Cập nhật thông tin quyền
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void cmdUpdateP_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtCode.Text) && !string.IsNullOrEmpty(txtName.Text))
            {
                BPermisionDefinition ctl = new BPermisionDefinition();
                OPermisionDefinition obj = new OPermisionDefinition();
                if (hdfId.Value != "-1")
                {

                }
                else
                {
                    obj.Name = txtName.Text.Trim();
                    obj.Code = txtCode.Text.Trim();
                    ctl.Add(obj);
                    BindData();
                }
            }
        }
        #endregion





    }
}
