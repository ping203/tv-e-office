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
using System.Collections.Generic;
namespace EOFFICE
{
    public partial class Login : System.Web.UI.Page
    {
        #region "Property"
        /// <summary>
        /// 
        /// </summary>
        private OUser UInfo
        {
            set
            {
                if (Session["MyUserInfo"] != null)
                {
                    Session["MyUserInfo"] = value;
                }
                else
                { Session.Add("MyUserInfo", value); }
            }
        }
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Đăng nhập
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            BUser ctlUser = new BUser();
            if (txtUsername.Text.Trim() != "" && txtPassword.Text.Trim() != "")
            {
                IList<OUser> lst = ctlUser.Get(txtUsername.Text, txtPassword.Text);
                if (lst != null && lst.Count > 0)
                {
                    UInfo = lst[0];
                    Response.Redirect("/");
                }
                else
                {
                    RegisterClientScriptBlock("Notification", "<script language='javascript'>alert('Thông tin đăng nhập không hợp lệ');</script>");
                }
            }
            else
                RegisterClientScriptBlock("Notification", "<script language='javascript'>alert('Thông tin đăng nhập không hợp lệ');</script>");
        }
    }
}
