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
using EOFFICE.Common;
namespace EOFFICE.MasterPages
{
    public partial class Default : System.Web.UI.MasterPage
    {
        /// <summary>
        /// Kiểm tra quyền
        /// </summary>
        private void CheckPermission()
        {
            BUser ctl = new BUser();
            //-- Kiểm tra quyền dự thảo
            if (ctl.HasPermission(Global.UserInfo.UserID, PermissionCode.DocumentDrap.ToString()) || Global.IsAdmin())
                pnDocumentDrap.Visible = true;
            //-- Kiểm tra quyền duyệt
            if (ctl.HasPermission(Global.UserInfo.UserID, PermissionCode.DocumentProcess.ToString()) || Global.IsAdmin())
                pnDocumentProcess.Visible = true;
            //-- Kiểm tra quyền phát hành
            if (ctl.HasPermission(Global.UserInfo.UserID, PermissionCode.DocumentPublish.ToString()) || Global.IsAdmin())
                pnDocumentPublish.Visible = true;
            BUser ctlUP = new BUser();
            if (Global.IsAdmin())
                li_User.Visible=true ;
        }

        protected void Page_Load(object sender, EventArgs e)
        {			
            if (Session["MyUserInfo"] == null)
            {
                string strReturn = "";
                if (Request.QueryString["returnURL"] == null)
                {
                    strReturn = "?returnURL=" + Server.UrlEncode(HttpContext.Current.Request.RawUrl);
                }
                else
                {
                    strReturn = "?returnURL=" + Request.QueryString["returnURL"];
                }
                Response.Redirect("~/Login.aspx" + strReturn);
            }
            lblUser.Text = Global.UserInfo.FullName;
            lblUser.DataBind();
            CheckPermission();
        }

        /// <summary>
        /// Đăng xuất
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("~/Login.aspx");
        }
    }
}
