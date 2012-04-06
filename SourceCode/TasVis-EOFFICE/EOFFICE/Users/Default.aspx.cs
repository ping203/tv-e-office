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
using EOFFICE;

namespace EOFFICE.Users
{
    public partial class Default : System.Web.UI.Page
    {
        #region "Propertys"
        /// <summary>
        /// Trang hiện tại
        /// </summary>
        public int CurrentPage
        {

            get
            {
                if (Request.QueryString["currentpage"] != null)
                {
                    try
                    {

                        return int.Parse(Request.QueryString["currentpage"]);
                    }
                    catch (Exception ex)
                    {
                        return 1;
                    }
                }
                else
                {
                    return 1;
                }
            }
        }
        #endregion

        #region "Common Function"

        /// <summary>
        /// Khởi tạo các thông tin của form
        /// </summary>
        private void InitData()
        {
            BUser ctlUP = new BUser();
            if (!Global.IsAdmin())
                Response.Redirect("/permission-fail.aspx");
            //--Pagesize
            if (Request.QueryString["pagesize"] != null)
            {
                try
                {
                    ddlPageSize.Items.FindByValue(Request.QueryString["pagesize"]).Selected = true;
                }
                catch (Exception ex) { }
            }
            //--Trạng thái
            if (Request.QueryString["status"] != null)
            {
                try
                {
                    ddlStatus.Items.FindByValue(Request.QueryString["status"]).Selected = true;
                }
                catch (Exception ex) { }
            }
            //--Phòng ban
            if (Request.QueryString["dpm"] != null)
            {
                try
                {
                    ddlDepartment.Items.FindByValue(Request.QueryString["dpm"]).Selected = true;
                }
                catch (Exception ex) { }
            }
            //--Tiêu chí tìm kiếm
            if (Request.QueryString["type"] != null)
            {
                try
                {
                    ddlColumnName.Items.FindByValue(Request.QueryString["type"]).Selected = true;
                }
                catch (Exception ex) { }
            }
        }

        /// <summary>
        /// Gửi kèm các paramater
        /// </summary>
        public string GenParamRedirect()
        {
            string strParam = "";
            strParam += "fpagesize=" + ddlPageSize.SelectedValue;
            strParam += "&fstatus=" + ddlStatus.SelectedValue;
            strParam += "&fdpm=" + ddlDepartment.SelectedValue;
            strParam += "&ftype=" + ddlColumnName.SelectedValue;
            if (txtKey.Text.Trim().Length > 0)
            {
                strParam += "&fkey=" + Server.UrlEncode(txtKey.Text.Trim());
            }
            //--Pagesize
            if (Request.QueryString["currentpage"] != null)
            {
                try
                {
                    strParam += "&fcurrentpage=" + Request.QueryString["currentpage"];
                }
                catch (Exception ex) { }
            }

            return strParam;
        }

        /// <summary>
        /// Tạo các parmater phục vụ phân trang
        /// </summary>
        /// <returns></returns>
        private string GenarateParam()
        {
            string strParam = "";
            strParam += "pagesize=" + ddlPageSize.SelectedValue;
            strParam += "&status=" + ddlStatus.SelectedValue;
            strParam += "&dpm=" + ddlDepartment.SelectedValue;
            strParam += "&type=" + ddlColumnName.SelectedValue;
            if (txtKey.Text.Trim().Length > 0)
            {
                strParam += "&type=" + Server.UrlEncode(txtKey.Text.Trim());
            }
            return strParam;
        }

        /// <summary>
        /// Bind dannh sách người dùng
        /// </summary>
        private void BindData()
        {
            BUser ctl = new BUser();
            string _fullname = "";
            string _username = "";
            string _email = "";
            string _status = "";
            int _departmentid = int.Parse(ddlDepartment.SelectedValue);
            //--Set key tìm kiếm
            if (txtKey.Text.Trim().Length > 0)
            {
                switch (ddlColumnName.SelectedValue)
                {
                    case "Username":
                        _username = txtKey.Text.Trim();
                        break;
                    case "Fullname":
                        _fullname = txtKey.Text.Trim();
                        break;
                    case "Email":
                        _email = txtKey.Text.Trim();
                        break;
                }
            }

            int count = ctl.GetCount(_fullname, _username, _email, _departmentid, _status, "", "");
            ctlPagging.PageSize = int.Parse(ddlPageSize.SelectedValue);
            spResultCount.InnerHtml = "Tìm thấy <b>" + count.ToString() + "</b> kết quả";
            if (count > ctlPagging.PageSize)
            {
                ctlPagging.Visible = true;
            }
            else
            {
                ctlPagging.Visible = false;
            }
            grvListUsers.DataSource = ctl.Get(_fullname, _username, _email, _departmentid, _status, "DESC", "UserId", CurrentPage, ctlPagging.PageSize);
            grvListUsers.DataBind();
            ctlPagging.CurrentIndex = CurrentPage;
            ctlPagging.ItemCount = count;
            ctlPagging.QueryStringParameterName = GenarateParam();
        }

        /// <summary>
        /// Ẩn hiện button duyệt
        /// </summary>
        /// <param name="status">Trạng thái hiện tại của tài khoản</param>
        /// <returns></returns>
        public bool VisibleApp(object status)
        {
            if (status == null)
                status = 1;
            if (status.ToString() == UserStatus.Approve.ToString("D"))
                return true;
            else
                return false;
        }
        /// <summary>
        /// Ẩn hiện button khóa
        /// </summary>
        /// <param name="status">Trạng thái hiện tại của tài khoản</param>
        /// <returns></returns>
        public bool VisibleUnApp(object status)
        {
            if (status == null)
                status = 1;
            if (status.ToString() == UserStatus.UnApprove.ToString("D"))
                return true;
            else
                return false;
        }

        /// <summary>
        /// Load danh sách trạng thái
        /// </summary>
        private void BindStatus()
        {
            ddlStatus.Items.Clear();
            ddlStatus.Items.Add(new ListItem("Duyệt", UserStatus.Approve.ToString("D")));
            ddlStatus.Items.Add(new ListItem("Khóa", UserStatus.UnApprove.ToString("D")));
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
                //--Load danh sách trạng thái
                BindStatus();
                //--Load danh sách phòng ban
                BindDepartment();
                //-- Thiết lập các thông tin trong form
                InitData();
                //-- Load danh sách tài khoản
                BindData();

            }
        }
        /// <summary>
        /// Thực hiện thao tác
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lbtAccept_Click(object sender, EventArgs e)
        {
            BUser ctl = new BUser();
            switch (ddlAction.SelectedValue)
            {
                //-- Xóa
                case "Delete":
                    foreach (GridViewRow r in grvListUsers.Rows)
                    {
                        HtmlInputCheckBox chk = (HtmlInputCheckBox)r.FindControl("chkCheckUser");
                        if (chk.Checked)
                        {
                            //-- THực hiện xóa người dùng
                            ctl.Delete(grvListUsers.DataKeys[r.RowIndex].Value.ToString());
                        }
                    }
                    //-- Load lại người dùng
                    BindData();
                    break;
                //-- Duyệt
                case "Approve":
                    foreach (GridViewRow r in grvListUsers.Rows)
                    {
                        HtmlInputCheckBox chk = (HtmlInputCheckBox)r.FindControl("chkCheckUser");
                        if (chk.Checked)
                        {
                            //-- THực hiện duyệt người dùng
                            ctl.UpdateStatus(grvListUsers.DataKeys[r.RowIndex].Value.ToString(),UserStatus.Approve.ToString("D"));
                        }
                    }
                    //-- Load lại người dùng
                    BindData();
                    break;
                //-- Khóa
                case "UnApprove":
                    foreach (GridViewRow r in grvListUsers.Rows)
                    {
                        HtmlInputCheckBox chk = (HtmlInputCheckBox)r.FindControl("chkCheckUser");
                        if (chk.Checked)
                        {
                            //-- THực hiện xóa người dùng
                            ctl.UpdateStatus(grvListUsers.DataKeys[r.RowIndex].Value.ToString(), UserStatus.UnApprove.ToString("D"));
                        }
                    }
                    //-- Load lại người dùng
                    BindData();
                    break;
              
            }
        }

        /// <summary>
        /// Sự kiện xảy ra khi thực hiện các thao tác trên danh sách người dùng
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void grvListUsers_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            //-- Phân quyền người dùng
            if (e.CommandName.Equals("cmdUserGroup", StringComparison.OrdinalIgnoreCase))
            {
                //-- Chuyển tới trang phân quyền người dùng
                Response.Redirect("GroupForUser.aspx?username=" + e.CommandArgument.ToString() + "&" + GenParamRedirect());
            }
            //-- Sửa người dùng
            else if (e.CommandName.Equals("cmdEdit", StringComparison.OrdinalIgnoreCase))
            {
                //-- Chuyển tới trang sửa người dùng 
                Response.Redirect("Edit.aspx?username=" + e.CommandArgument.ToString());
            }
            else if (e.CommandName.Equals("cmdResetPass", StringComparison.OrdinalIgnoreCase))
            {
                BUser Bobj = new BUser();
                Bobj.Update(e.CommandArgument.ToString(), Common.ECommon.GetMd5String("nganson"));
            }
            //--Xóa người dùng
            else if (e.CommandName.Equals("cmdDelete", StringComparison.OrdinalIgnoreCase))
            {
                BUser ctl = new BUser();
                try
                {
                    //-- THực hiện xóa người dùng
                    ctl.Delete(e.CommandArgument.ToString());
                    //--Load lại danh sách người dùng
                    BindData();
                }
                catch (Exception ex)
                {
                    //--Load lại danh sách người dùng
                    BindData();
                }
            }
            //--Khóa người dùng
            else if (e.CommandName.Equals("cmdUnApprove", StringComparison.OrdinalIgnoreCase))
            {
                BUser ctl = new BUser();
                try
                {
                    //-- THực hiện cập nhật trạng thái
                    ctl.UpdateStatus(e.CommandArgument.ToString(), UserStatus.UnApprove.ToString("D"));
                    //--Load lại danh sách người dùng
                    BindData();
                }
                catch (Exception ex)
                {
                    //--Load lại danh sách người dùng
                    BindData();
                }
            }
            //--Duyệt người dùng
            else if (e.CommandName.Equals("cmdApprove", StringComparison.OrdinalIgnoreCase))
            {
                BUser ctl = new BUser();
                try
                {
                    //-- THực hiện cập nhật trạng thái
                    ctl.UpdateStatus(e.CommandArgument.ToString(), UserStatus.Approve.ToString("D"));
                    //--Load lại danh sách người dùng
                    BindData();
                }
                catch (Exception ex)
                {
                    //--Load lại danh sách người dùng
                    BindData();
                }
            }

        }

        /// <summary>
        /// Thay đổi số lượng kết quả hiển thị
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ddlPageSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            //--Load lại danh sách người dùng
            BindData();
        }


        /// <summary>
        /// Thay đổi phòng ban
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ddlDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            //--Load lại danh sách người dùng
            BindData();
        }

        /// <summary>
        /// Thay đổi trạng thái
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ddlStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            //--Load lại danh sách người dùng
            BindData();
        }

        /// <summary>
        /// Tìm kiếm
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lbtSearch_Click(object sender, EventArgs e)
        {
            BindData();
        }
        #endregion
    }
}
