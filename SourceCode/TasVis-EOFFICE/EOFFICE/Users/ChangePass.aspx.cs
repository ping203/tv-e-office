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
using DataAccess.Common;

namespace EOFFICE.Users
{
    public partial class ChangePass : System.Web.UI.Page
    {
        
       
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                KhoiTao();
            }
        }

        private void KhoiTao()
        {
            string UserName = Global.UserInfo.UserName;
            lblUserName.Text = UserName;
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            string UserName = Global.UserInfo.UserName;
            BUser Bobj = new BUser();
            OUser obj = new OUser();
            obj = Bobj.Get(UserName).First();

            if (Common.ECommon.GetMd5String(txtPass.Text) != obj.Password)
            {
                lblThongBao.Text = "MẬT KHẨU CŨ KHÔNG ĐÚNG!";
            }
            else
            {
                if (txtPassRepeat.Text != txtPassNew.Text)
                {
                    lblThongBao.Text = "MẬT KHẨU NHẮC LẠI KHÔNG KHỚP!";
                }
                else
                {
                    if (Bobj.Update(UserName, Common.ECommon.GetMd5String(txtPassNew.Text)))
                    {
                        lblThongBao.Text = "ĐỔI MẬT KHẨU THÀNH CÔNG!";
                    }
                }
            }
        }
    }
}
