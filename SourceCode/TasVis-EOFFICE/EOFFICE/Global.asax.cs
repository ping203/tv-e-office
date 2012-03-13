using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.Xml.Linq;
using DataAccess.Common;
using DataAccess.DataObject;
namespace EOFFICE
{
    public class Global : System.Web.HttpApplication
    {
        public static OUser UserInfo
        {

            get
            {
                try
                {
                    if (HttpContext.Current.Session["MyUserInfo"] != null)
                    {
                        return (OUser)HttpContext.Current.Session["MyUserInfo"];
                    }
                    return new OUser();
                }
                catch (Exception ex)
                { return new OUser(); }
            }
        }

        /// <summary>
        /// Kiểm tra quyền quản trị
        /// </summary>
        public static bool IsAdmin()
        {
            if (UserInfo.UserName.Equals("admin", StringComparison.OrdinalIgnoreCase))
                return true;
            else
                return false;
        }

        protected void Application_Start(object sender, EventArgs e)
        {
            CDBase.strConnectionString = ConfigurationManager.ConnectionStrings["sqlconnection"].ConnectionString;
        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}