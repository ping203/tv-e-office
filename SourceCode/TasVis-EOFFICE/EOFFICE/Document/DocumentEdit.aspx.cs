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

namespace EOFFICE
{

    public partial class DocumentEdit : System.Web.UI.Page
    {
        #region "Property"
        /// <summary>
        /// Lưu mã người dùng
        /// </summary>
        public int DocumentId
        {
            get
            {
                if (Request.QueryString["DocumentId"] != null)
                {
                    return int.Parse( Request.QueryString["DocumentId"]);
                }
                else
                {
                    return 0;
                }
            }
        }
        #endregion
        #region "Common Function"
        /// <summary>
        /// Load ra danh sách loại tài liệu
        /// </summary>
        private void BindDocumentType()
        {
            BDocumentKind ctl = new BDocumentKind();
            ddlType.ClearSelection();
            ddlType.DataSource = ctl.Get(0);
            ddlType.DataBind();
            ddlType.Items.Insert(0, new ListItem("Tất cả", ""));
        }

        /// <summary>
        /// Load danh sách phòng ban
        /// </summary>
        private void BindDepartment()
        {
            ddlDepartment.Items.Clear();
            BDepartment ctl = new BDepartment();
            ddlDepartment.DataSource = ctl.Get(0);
            ddlDepartment.DataBind();
            ddlDepartment.Items.Insert(0, new ListItem("Tất cả", "0"));
        }

        /// <summary>
        /// Lấy về danh sách các người sử lý
        /// </summary>
        /// <returns></returns>
        private string GetUserProcess()
        {
            string str = "";
            for (int i = 0; i < lsbUserProcess.Items.Count; i++)
            {
                if (str == "")
                    str = str + lsbUserProcess.Items[i].Value;
                else
                    str = str+"," + lsbUserProcess.Items[i].Value;
            }
            return str;
        }

        /// <summary>
        /// Bind dannh sách người dùng
        /// </summary>
        private void BindDataUser()
        {
            BUser ctl = new BUser();
            string _fullname = "";
            string _username = "";
            string _email = "";
            string _status =UserStatus.Approve.ToString("D");
            int _departmentid = int.Parse(ddlDepartment.SelectedValue);
            //--Set key tìm kiếm
            if (txtKeySearch.Text.Trim().Length > 0)
            {
                _username = txtKeySearch.Text.Trim();
                _fullname = txtKeySearch.Text.Trim();
                _email = txtKeySearch.Text.Trim();
            }

            int count = ctl.GetCount(_fullname, _username, _email, _departmentid, _status, "", "");
            if (count > 0)
            {
                lbsUserSearch.Visible = true;
                lbsUserSearch.DataSource = ctl.Get(_fullname, _username, _email, _departmentid, _status, "DESC", "UserId", 1,100);
                lbsUserSearch.DataBind();
            }
            else
            {
                lbsUserSearch.Visible = false;
            }
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
            if (!IsPostBack)
            {
                BindDocumentType();
                BindDepartment();
            }
           
        }
        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lnkSave_Click(object sender, EventArgs e)
        {
            ODocument obj = new ODocument() ;
            BDocument ctl = new BDocument();
            if (DocumentId > 0)
            {
                //obj = ctl.Get(DocumentId.ToString());
                if (obj != null)
                {
                    //obj.Content = txtContent.Text;
                    //obj.CreateDate = DateTime.Now;
                    //obj.StartProcess = DateTime.ParseExact(txtStartDate.Text, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                    //obj.EndProcess = DateTime.ParseExact(txtEndDate.Text, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                    //obj.IDUserCreate = Global.UserInfo.UserID;
                    //obj.Name = txtName.Text;
                    //obj.Priority = ddlLevel.SelectedValue;
                    //obj.UserProcess = GetUserProcess();
                    //ctl.Add(obj);
                }
            }
            else
            {
                obj.Content = txtContent.Text;
                obj.CreateDate = DateTime.Now;
                obj.SendDate = DateTime.Now;
                obj.ReceiveDate = DateTime.Now;
                obj.PublishDate = DateTime.Now;
                obj.StartProcess = DateTime.ParseExact(txtStartDate.Text, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                obj.EndProcess = DateTime.ParseExact(txtEndDate.Text, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                obj.IDUserCreate = Global.UserInfo.UserID;
                obj.Name = txtName.Text;
                obj.Priority = ddlLevel.SelectedValue;
                obj.UserProcess = GetUserProcess();
                obj.Status = EOFFICE.Common.DocumentStatus.SaveDrap.ToString("D");
                ctl.Add(obj);
            }
        }

        /// <summary>
        /// Tìm kiếm usẻ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSearchUserProcess_Click(object sender, EventArgs e)
        {
            BindDataUser();
        }
        
        /// <summary>
        /// Chọn phòng ban
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ddlDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindDataUser();
        }

        /// <summary>
        /// Chọn User
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lnkAddUserProcess_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < lbsUserSearch.Items.Count; i++)
            {
                if (lbsUserSearch.Items[i].Selected == true)
                {
                    if (lsbUserProcess.Items.FindByValue(lbsUserSearch.Items[i].Value) == null)
                    {
                        lsbUserProcess.Items.Add(lbsUserSearch.Items[i]);
                    }
                   
                }
            }
        }

        protected void cmdDeleteUser_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < lsbUserProcess.Items.Count; i++)
            {
                if (lsbUserProcess.Items[i].Selected == true)
                {
                    lsbUserProcess.Items.RemoveAt(i);
                }
            }
        }

        protected void lnkSave1_Click(object sender, EventArgs e)
        {

        }




    }
}
