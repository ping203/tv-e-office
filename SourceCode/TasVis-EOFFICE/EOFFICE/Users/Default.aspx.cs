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
        /// Bind dannh sách người dùng
        /// </summary>
        private void BindData()
        {
            BUser ctl = new BUser();
            int c = ctl.GetCount("", "", "");
            grvListUsers.DataSource = ctl.Get("");
            grvListUsers.DataBind();
            ctlPagging.CurrentIndex = c;
            ctlPagging.ItemCount = 200;
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
        /// <summary>
        /// Thực hiện thao tác
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lnkAccept_Click(object sender, EventArgs e)
        {
            BUser ctl = new BUser();
            switch (drdAction.SelectedValue)
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
            //-- Sửa người dùng
            if (e.CommandName.Equals("cmdEdit", StringComparison.OrdinalIgnoreCase))
            {
                //-- Chuyển tới trang sửa người dùng 
                Response.Redirect("Edit.aspx?username=" + e.CommandArgument.ToString());
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
        #endregion


    }
}
