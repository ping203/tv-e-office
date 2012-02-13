using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using DataAccess.DataObject;

    public partial class System.Web.UI.Page
    {
        #region "Propertys"
        /// <summary>
        /// UserInfo
        /// </summary>
        public static OUser UserInfo
        {
            get
            {
                
                if (HttpContext.Current.Items["EUserInfo"] != null)
                {
                    try
                    {
                        return (OUser)(HttpContext.Current.Items["EUserInfo"]);
                    }
                    catch (Exception ex)
                    {
                        return null;
                    }
                }
                else
                {
                    return null;
                }
            }
        }

        /// <summary>
        /// UserId
        /// </summary>
        public static int UserId
        {
            get
            {
                if (HttpContext.Current.Items["EUserId"] != null)
                {
                    try
                    {
                        return int.Parse(HttpContext.Current.Items["EUserId"].ToString());
                    }
                    catch (Exception ex)
                    {
                        return -1;
                    }
                }
                else
                {
                    return -1;
                }
            }
        }
        #endregion
    }
