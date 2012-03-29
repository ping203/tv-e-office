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
using System.Collections.Generic;

namespace EOFFICE.Document
{
    public partial class SendDocumentProcessedUser : System.Web.UI.Page
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
            //-- Kiểm tra quyền duyệt
            if (!ctlUP.HasPermission(Global.UserInfo.UserID, Common.PermissionCode.DocumentSendPublish.ToString())&&!Global.IsAdmin())
                Response.Redirect("/permission-fail.aspx");
            //--Pagesize
            if (Request.QueryString["pagesize"] != null)
            {
                try {
                    ddlPageSize.Items.FindByValue(Request.QueryString["pagesize"]).Selected = true;
                }
                catch (Exception ex) { }
            }
            hdfCurrentPage.Value = CurrentPage.ToString();
            if (Request.QueryString["dt"] != null)
            {
                try
                {
                    ddlDocumentType.Items.FindByValue(Request.QueryString["dt"]).Selected = true;
                }
                catch (Exception ex) { }
            }
            if (Request.QueryString["key"] != null)
            {
                try
                {
                    txtKey.Text =Server.UrlDecode( Request.QueryString["key"]);
                }
                catch (Exception ex) { }
            }
            //--Tiêu chí tìm kiếm
            if (Request.QueryString["td"] != null)
            {
                try
                {
                    txtStartDate.Text = Server.UrlDecode(Request.QueryString["td"]);
                }
                catch (Exception ex) { }
            }
            if (Request.QueryString["ed"] != null)
            {
                try
                {
                    txtEndDate.Text = Server.UrlDecode(Request.QueryString["ed"]);
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
            //strParam += "&fstatus=" + ddlStatus.SelectedValue;
            strParam += "&fdpm=" + ddlDocumentType.SelectedValue;
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
            strParam += "pagesize="+ddlPageSize.SelectedValue;
            //strParam += "&status=" + ddlStatus.SelectedValue;
            strParam += "&dt=" + ddlDocumentType.SelectedValue;
            if (txtStartDate.Text.Trim().Length > 0)
            {
                strParam += "&td=" + Server.UrlEncode(txtStartDate.Text.Trim());
            }
            if (txtEndDate.Text.Trim().Length > 0)
            {
                strParam += "&ed=" + Server.UrlEncode(txtEndDate.Text.Trim());
            }
            if (txtKey.Text.Trim().Length > 0)
            {
                strParam += "&key=" +Server.UrlEncode( txtKey.Text.Trim());
            }
            return strParam;
        }

        /// <summary>
        /// Bind dannh sách  Công văn đi
        /// </summary>
        private void BindData()
        {
            DateTime StartDate = DateTime.ParseExact("01/01/1970", "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
            DateTime EndDate = DateTime.MaxValue;
            if (txtStartDate.Text.Trim().Length > 0)
                StartDate = DateTime.ParseExact(txtStartDate.Text, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
            if (txtEndDate.Text.Trim().Length > 0)
                EndDate  = DateTime.ParseExact(txtEndDate.Text, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
            int pagesize = int.Parse(ddlPageSize.SelectedValue);
            BDocument ctl = new BDocument();
            IList<ODocument> lst = ctl.Get("", txtKey.Text, StartDate, EndDate, int.Parse(ddlDocumentType.SelectedValue), 0, "", int.Parse(EOFFICE.Common.DocumentStatus.Processed.ToString("D")), "Name", "DESC", 0, int.Parse(hdfCurrentPage.Value), pagesize, int.Parse(EOFFICE.Common.DocumentType.DocumentSend.ToString("D")));
            grvListDocument.DataSource = lst;
            grvListDocument.DataBind();
            if (grvListDocument.Rows.Count > 0)
            {
                if (lst[0].TotalResult > pagesize)
                {
                    ctlPagging.Visible = true;
                    ctlPagging.PageSize = int.Parse(ddlPageSize.SelectedValue);
                    ctlPagging.CurrentIndex = int.Parse(hdfCurrentPage.Value);
                    ctlPagging.ItemCount = lst[0].TotalResult;
                    ctlPagging.QueryStringParameterName = GenarateParam();
                }
                else
                {
                    ctlPagging.Visible = false;
                }
            }
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
        /// Load ra danh sách loại tài liệu
        /// </summary>
        private void BindDocumentType()
        {
            BDocumentKind ctl = new BDocumentKind();
            ddlDocumentType.ClearSelection();
            ddlDocumentType.DataSource = ctl.Get(0);
            ddlDocumentType.DataBind();
            ddlDocumentType.Items.Insert(0, new ListItem("Tất cả", "0"));
        }

                /// <summary>
        /// Load danh sahcs nguoi xu ly
        /// </summary>
        /// <param name="str"></param>
        public string BindUserProcess(object str)
        {

            string strU = "";
            BUser ctl = new BUser();
            foreach (string i in str.ToString().Split(','))
            {
                try
                {
                    OUser obj = ctl.Get(int.Parse(i))[0];
                    if (obj != null)
                    {
                        if (strU == "")
                            strU = strU + obj.FullName;
                        else
                            strU = strU + ", " + obj.FullName;
                    }
                }
                catch (Exception ex) { }
            }
            return strU;
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
                //--Load danh sách loại Công văn đi
                BindDocumentType();
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
                    foreach (GridViewRow r in grvListDocument.Rows)
                    {
                        HtmlInputCheckBox chk = (HtmlInputCheckBox)r.FindControl("chkCheckUser");
                        if (chk.Checked)
                        {
                            //-- THực hiện xóa  Công văn đi
                            ctl.Delete(grvListDocument.DataKeys[r.RowIndex].Value.ToString());
                        }
                    }
                    //-- Load lại  Công văn đi
                    BindData();
                    break;
                //-- Duyệt
                case "Approve":
                    foreach (GridViewRow r in grvListDocument.Rows)
                    {
                        HtmlInputCheckBox chk = (HtmlInputCheckBox)r.FindControl("chkCheckUser");
                        if (chk.Checked)
                        {
                            //-- THực hiện duyệt  Công văn đi
                            ctl.UpdateStatus(grvListDocument.DataKeys[r.RowIndex].Value.ToString(),UserStatus.Approve.ToString("D"));
                        }
                    }
                    //-- Load lại  Công văn đi
                    BindData();
                    break;
                //-- Khóa
                case "UnApprove":
                    foreach (GridViewRow r in grvListDocument.Rows)
                    {
                        HtmlInputCheckBox chk = (HtmlInputCheckBox)r.FindControl("chkCheckUser");
                        if (chk.Checked)
                        {
                            //-- THực hiện xóa  Công văn đi
                            ctl.UpdateStatus(grvListDocument.DataKeys[r.RowIndex].Value.ToString(), UserStatus.UnApprove.ToString("D"));
                        }
                    }
                    //-- Load lại  Công văn đi
                    BindData();
                    break;
            }
        }

        /// <summary>
        /// Sự kiện xảy ra khi thực hiện các thao tác trên danh sách  Công văn đi
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void grvListDocument_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            //-- Sửa Công văn đi
            if (e.CommandName.Equals("Publish", StringComparison.OrdinalIgnoreCase))
            {
                //-- Chuyển tới trang sửa  Công văn đi
                Response.Redirect("/DocumentSend/DocumentDetailsProcessed.aspx?DocumentId=" + e.CommandArgument.ToString());
            }
        }

        /// <summary>
        /// Thay đổi số lượng kết quả hiển thị
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ddlPageSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            //--Load lại danh sách  Công văn đi
            hdfCurrentPage.Value = "1";
            BindData();
        }


        /// <summary>
        /// Thay đổi phòng ban
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ddlDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            //--Load lại danh sách  Công văn đi
            hdfCurrentPage.Value = "1";
            BindData();
        }

        /// <summary>
        /// Thay đổi trạng thái
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ddlStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            //--Load lại danh sách  Công văn đi
            hdfCurrentPage.Value = "1";
            BindData();
        }

        /// <summary>
        /// Tìm kiếm
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lbtSearch_Click(object sender, EventArgs e)
        {
            hdfCurrentPage.Value = "1";
            BindData();
        }

        /// <summary>
        /// Tìm kiếm
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lbtSearch_Click1(object sender, EventArgs e)
        {
            hdfCurrentPage.Value = "1";
            BindData();
        }


        /// <summary>
        /// Chọn loại Công văn đi
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ddlDocumentType_SelectedIndexChanged(object sender, EventArgs e)
        {
            hdfCurrentPage.Value = "1";
            BindData();
        }
        #endregion


    }
}
