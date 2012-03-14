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

namespace EOFFICE.Calendar
{
    public partial class SMS : System.Web.UI.Page
    {
        OUser _OUser = new OUser();
        BUser _BUser = new BUser();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (_BUser.HasPermission(Global.UserInfo.UserID, Common.PermissionCode.SendSMS.ToString()))
            {
                if (!IsPostBack)
                {
                    BindDepartment();
                }
            }
            else {
                Response.Redirect("/permission-fail.aspx");
            }
        }
        public void BindDepartment()
        {
            BDepartment BobjDepartment = new BDepartment();
            rptDepartment.DataSource= BobjDepartment.Get(0);
            rptDepartment.DataBind();
        }
        protected void btnSend_Click(object sender, EventArgs e)
        {
            wssendmessenger.Service ws = new EOFFICE.wssendmessenger.Service();            
            string strPhoneNumber="";
            string content = "NganSon.,JSC: ";
            content += Common.ECommon.ReplaceUnicode(txtContent.Text);            
            String[] arrUserName = hdfUsers.Value.Split(',');
            string fail = "";
            foreach (string strUserName in arrUserName)
            {
                if (strUserName != "")
                {
                    if (_BUser.Get(strUserName).Count > 0)
                    {
                        IList<OUser> lstUser = _BUser.Get(strUserName);
                        strPhoneNumber = lstUser[0].PhoneNumber;
                        if (strPhoneNumber != "")
                        {
                            if (ws.send(ConfigurationManager.AppSettings["usersms"].ToString(), ConfigurationManager.AppSettings["passwordsms"].ToString(), content, strPhoneNumber) != "200|Send success")
                            {
                                fail += lstUser[0].FullName + "(" + strPhoneNumber + ");";
                            }
                        }
                        else {                            
                            continue;
                        }
                    }
                }
            }
            if (fail != "")
            {
                RegisterClientScriptBlock("NOTE", "<script>alert('Không gửi được tin nhắn tới một vài số điện thoại vui lòng kiểm tra lại số điện thoại: " + fail + "');</script>");
            }
            else
            {
                RegisterClientScriptBlock("NOTE", "<script>alert('Gửi tin nhắn thành công !');</script>");
            }
        }
    }
}
