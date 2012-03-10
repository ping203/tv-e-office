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
using System.Data.SqlClient;
using System.Collections.Specialized;
using System.Web.Configuration;
using System.Collections.Generic;

namespace EOFFICE.Works
{
    public partial class WorkAssignment : System.Web.UI.Page
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

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ddlWorkGroup_Load();
                ddlWork_Load();
                InitData();
                grvWork_Load();
            }
        }

        private void InitData()
        {
            //--Pagesize
            if (Request.QueryString["pagesize"] != null)
            {
                try
                {
                    ddlPageSize.Items.FindByValue(Request.QueryString["pagesize"]).Selected = true;
                }
                catch (Exception ex) { }
            }
            //--Nhóm công việc
            if (Request.QueryString["group"] != null)
            {
                try
                {
                    ddlWorkGroup.Items.FindByValue(Request.QueryString["group"]).Selected = true;
                }
                catch (Exception ex) { }
            }
            //--Trạng thái
            if (Request.QueryString["status"] != null)
            {
                try
                {
                    ddlWork.Items.FindByValue(Request.QueryString["status"]).Selected = true;
                }
                catch (Exception ex) { }
            }
            //--Tiêu chí tìm kiếm
            if (Request.QueryString["type"] != null)
            {
                try
                {
                    ddlTieuChi.Items.FindByValue(Request.QueryString["type"]).Selected = true;
                }
                catch (Exception ex) { }
            }
        }

        public string GenParamRedirect()
        {
            string strParam = "";
            strParam += "pagesize=" + ddlPageSize.SelectedValue;
            strParam += "&group=" + ddlWorkGroup.SelectedValue;
            strParam += "&status=" + ddlWork.SelectedValue;
            strParam += "&type=" + ddlTieuChi.SelectedValue;
            if (txtKeyword.Text.Trim().Length > 0)
            {
                strParam += "&key=" + Server.UrlEncode(txtKeyword.Text.Trim());
            }
            //--Pagesize
            if (Request.QueryString["currentpage"] != null)
            {
                try
                {
                    strParam += "&currentpage=" + Request.QueryString["currentpage"];
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
            strParam += "&group=" + ddlWorkGroup.SelectedValue;
            strParam += "&status=" + ddlWork.SelectedValue;
            strParam += "&type=" + ddlTieuChi.SelectedValue;
            if (txtKeyword.Text.Trim().Length > 0)
            {
                strParam += "&type=" + Server.UrlEncode(txtKeyword.Text.Trim());
            }
            return strParam;
        }

        protected void ddlPageSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            grvWork_Load();
        }

        protected void ddlWorkGroup_Load()
        {
            ListItem lit = new ListItem("--Chọn nhóm công việc--","0");
            BWorkGroup bwg = new BWorkGroup();
            ddlWorkGroup.DataSource = bwg.Get(0);
            ddlWorkGroup.DataTextField = "Name";
            ddlWorkGroup.DataValueField = "WorkGroupID";
            
            ddlWorkGroup.DataBind();
            ddlWorkGroup.Items.Insert(0, lit);
        }
        /// <summary>
        /// Lấy danh sách công việc giao của người dùng đang tạo công việc
        /// </summary>
        
        protected void grvWork_Load()
        {
            
            int UserID = Global.UserInfo.UserID;
            BWork objWork = new BWork();
            string _name = "";
            string _idUserProcess = "";
            int _workgroup = int.Parse(ddlWorkGroup.SelectedValue);
            string _status =ddlWork.SelectedValue;
            //--Set key tìm kiếm
            if (txtKeyword.Text.Trim().Length > 0)
            {
                switch (ddlTieuChi.SelectedValue)
                {
                    case "WorkName":
                        _name = txtKeyword.Text.Trim();
                        break;
                    case "User":
                        _idUserProcess = txtKeyword.Text.Trim();
                        break;
                }
            }
            ctlPagging.PageSize = int.Parse(ddlPageSize.SelectedValue);
            int count = objWork.Get(_name, _status, _workgroup, _idUserProcess).Count;
            spResultCount.InnerHtml = "Tìm thấy <b>" + count.ToString() + "</b> kết quả";
            if (count > ctlPagging.PageSize)
            {
                ctlPagging.Visible = true;
            }
            else
            {
                ctlPagging.Visible = false;
            }
            grvWork.DataSource = objWork.Get(_name, _status, _workgroup, _idUserProcess, "ASC", "Name", CurrentPage, ctlPagging.PageSize);
            grvWork.DataBind();
            ctlPagging.CurrentIndex = CurrentPage;
            ctlPagging.ItemCount = count;
            ctlPagging.QueryStringParameterName = GenarateParam();
        }


        protected void grvWork_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {

                //adding an attribute for onclick event on the check box in the header

                //and passing the ClientID of the Select All checkbox

                ((CheckBox)e.Row.FindControl("CheckAll")).Attributes.Add("onclick", "javascript:SelectAll('" + ((CheckBox)e.Row.FindControl("CheckAll")).ClientID + "')");
            }
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                LinkButton lbtnForward = (LinkButton)grvWork.FindControl("lbtnForward"); 
            }

        }

        protected void lbtnForward_Click(object sender, EventArgs e)
        {
            // Retrieve control 
            LinkButton lbtnForward = sender as LinkButton;

            int WorkID = Int32.Parse(lbtnForward.CommandArgument);

            BWork _BWork = new BWork();
            OWork _OWork = new OWork();
            _OWork = _BWork.GetWork(WorkID).First();
            if (_OWork.Status == "CHUA_GIAO")
            {
                Response.Redirect("EditAssignment.aspx?WorkID=" + WorkID);
            }
            else
            {
                Response.Redirect("WorkAssignmentDetail.aspx?WorkID=" + WorkID);
            }
        } 

        /// <summary>
        /// Hàm lấy ra danh sách người xử lý công việc với chuỗi IDUserProcess truyền vào
        /// </summary>
        /// <param name="IDUserProcess"></param>
        /// <returns></returns>
        protected string BindNguoiXuLy(string IDUserProcess)
        {
            string[] listUser;
            string list=string.Empty;
            BUser obj = new BUser();
            listUser = IDUserProcess.Split(',');
            if (listUser.Count() > 2)
            {
                for (int i = 1; i < listUser.Count() - 1; i++)
                {
                    list += obj.Get(listUser[i]).First().FullName + "; ";
                }
                list = list.Remove(list.Length - 2);
            }
            else
            {
                list = "Chưa có người xử lý!";
            }
            return list;
        }

        /// <summary>
        /// Hàm ghép chuỗi thời gian bắt đầu và kết thúc
        /// </summary>
        /// <param name="WorkID"></param>
        /// <returns></returns>
        protected string BindThoiGian(string WorkID)
        {
            string time = string.Empty;
            BWork obj = new BWork();
            OWork objWork = new OWork();
            objWork = obj.GetWork(int.Parse(WorkID)).First();
            time = objWork.StartProcess.Day.ToString() + "/" + objWork.StartProcess.Month.ToString() + "/" + objWork.StartProcess.Year.ToString();
            time += " - " + objWork.EndProcess.Day.ToString() + "/" + objWork.EndProcess.Month.ToString() + "/" + objWork.EndProcess.Year.ToString();
            return time;
        }

        /// <summary>
        /// Lấy ra trạng thái công việc giao tương ứng với công việc
        /// </summary>
        /// <param name="WorkID"></param>
        /// <returns></returns>
        protected string BindTrangThai(string WorkID)
        {
            string status = string.Empty;
            BWork obj = new BWork();
            OWork objWork = new OWork();
            objWork = obj.GetWork(int.Parse(WorkID)).First();
            NameValueCollection appSettings = WebConfigurationManager.AppSettings as NameValueCollection;
            status = appSettings[objWork.Status];
            return status;
        }


        protected string BindNgayTao(string WorkID)
        {
            string time = string.Empty;
            BWork obj = new BWork();
            OWork objWork = new OWork();
            objWork = obj.GetWork(int.Parse(WorkID)).First();
            time = objWork.CreateDate.Day.ToString() + "/" + objWork.CreateDate.Month.ToString() + "/" + objWork.CreateDate.Year.ToString();
            return time;
        }

        protected void grvWork_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowState == DataControlRowState.Normal)
                e.Row.CssClass = "normal";
            if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowState == DataControlRowState.Alternate)
                e.Row.CssClass = "altenate";
        }

        protected void ddlWork_Load()
        {
            NameValueCollection appSettings =WebConfigurationManager.AppSettings as NameValueCollection;
            string str = appSettings["CHUA_GIAO"];
            string str1 = appSettings["DANG_THUC_HIEN"];
            string str2 = appSettings["DUNG_XU_LY"];
            ListItem[] lit = new ListItem[3];
            
            lit[0] = new ListItem(str, "CHUA_GIAO");
            lit[1] = new ListItem(str1,"DANG_THUC_HIEN");
            lit[2] = new ListItem(str2, "DUNG_XU_LY");
            
            ddlWork.Items.Add(lit[0]);
            ddlWork.Items.Add(lit[1]);
            ddlWork.Items.Add(lit[2]);
        }

        protected void btnTim_Click(object sender, EventArgs e)
        {
            grvWork_Load();            
        }       

        protected void btnDung_Click(object sender, EventArgs e)
        {
            int UserID = Global.UserInfo.UserID;
            BWork obj = new BWork();
            foreach (GridViewRow row in grvWork.Rows)
            {
                CheckBox checkbox = (CheckBox)row.FindControl("MyCheckBox");

                if (checkbox.Checked == true)
                {
                    int Id = Convert.ToInt32(grvWork.DataKeys[row.RowIndex].Value);
                    if (obj.GetWork(Id).First().Status != "CHUA_GIAO")
                    {
                        obj.Update(Id, "DUNG_XU_LY", UserID);
                    }
                }
            }
            grvWork_Load();
        }

        protected void btnTiepTuc_Click(object sender, EventArgs e)
        {
            int UserID = Global.UserInfo.UserID;
            BWork obj = new BWork();
            foreach (GridViewRow row in grvWork.Rows)
            {
                CheckBox checkbox = (CheckBox)row.FindControl("MyCheckBox");

                if (checkbox.Checked == true)
                {
                    int Id = Convert.ToInt32(grvWork.DataKeys[row.RowIndex].Value);
                    if (obj.GetWork(Id).First().Status == "DUNG_XU_LY")
                    {
                        obj.Update(Id, "DANG_THUC_HIEN", UserID);
                    }
                }
            }
            grvWork_Load();
        }

        protected void btnXoa_Click(object sender, EventArgs e)
        {
            BWork obj = new BWork();
            foreach (GridViewRow row in grvWork.Rows)
            {
                CheckBox checkbox = (CheckBox)row.FindControl("MyCheckBox");

                if (checkbox.Checked == true)
                {
                    int Id = Convert.ToInt32(grvWork.DataKeys[row.RowIndex].Value);
                    obj.Delete(Id);
                }
            }
            grvWork_Load();
        }

        protected void btnGiaoViec_Click(object sender, EventArgs e)
        {
            int UserID = Global.UserInfo.UserID;
            BWork obj = new BWork();
            foreach (GridViewRow row in grvWork.Rows)
            {
                CheckBox checkbox = (CheckBox)row.FindControl("MyCheckBox");

                if (checkbox.Checked == true)
                {
                    int Id = Convert.ToInt32(grvWork.DataKeys[row.RowIndex].Value);
                    if (obj.GetWork(Id).First().Status == "CHUA_GIAO")
                    {
                        obj.Update(Id, "DANG_THUC_HIEN", UserID);
                    }
                }
            }
            grvWork_Load();
        }

        protected void ddlWork_SelectedIndexChanged(object sender, EventArgs e)
        {
            grvWork_Load();
        }

        protected void ddlWorkGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            grvWork_Load();
        }
    }
}
