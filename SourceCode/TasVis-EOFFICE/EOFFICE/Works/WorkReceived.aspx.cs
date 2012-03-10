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
using DataAccess.Common;
using DataAccess.DataObject;
using System.Collections.Specialized;
using System.Web.Configuration;
using System.Collections.Generic;

namespace EOFFICE.Works
{
    public partial class WorkReceived : System.Web.UI.Page
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
                strParam += "fkey=" + Server.UrlEncode(txtKeyword.Text.Trim());
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
            strParam += "fgroup=" + ddlWorkGroup.SelectedValue;
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
            ListItem lit = new ListItem("--Chọn nhóm công việc--", "0");
            BWorkGroup bwg = new BWorkGroup();
            ddlWorkGroup.DataSource = bwg.Get(0);
            ddlWorkGroup.DataTextField = "Name";
            ddlWorkGroup.DataValueField = "WorkGroupID";

            ddlWorkGroup.DataBind();
            ddlWorkGroup.Items.Insert(0, lit);
        }

        protected void ddlWork_Load()
        {
            NameValueCollection appSettings = WebConfigurationManager.AppSettings as NameValueCollection;
            string str = appSettings["DANG_THUC_HIEN"];
            string str1 = appSettings["CONG_VIEC_DA_XU_LY"];
            ListItem[] lit = new ListItem[2];
            
            lit[0] = new ListItem("Công việc cần xử lý", "DANG_THUC_HIEN");
            lit[1] = new ListItem(str1, "CONG_VIEC_DA_XU_LY");
            
            ddlWork.Items.Add(lit[0]);
            ddlWork.Items.Add(lit[1]);
            
        }


        protected void grvWork_Load()
        {
            int UserID = Global.UserInfo.UserID;
            BWork objWork = new BWork();
            string _name = "";
            string _idUserProcess = "";
            int _workgroup = int.Parse(ddlWorkGroup.SelectedValue);
            string _status = ddlWork.SelectedValue;
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

        protected string BindTaoViec(string IDUserCreate)
        {
            
            string FullName = string.Empty;
            BUser obj = new BUser();
            FullName = obj.Get(int.Parse(IDUserCreate)).First().FullName;
            return FullName;
        }

        protected string BindChuyenViec(string IDUserProcess)
        {

            string[] listUser;
            string list = string.Empty;
            BUser obj = new BUser();
            listUser = IDUserProcess.Split(',');
            if (listUser.Count() > 2)
            {
                for (int i = 1; i < listUser.Count() - 1; i++)
                {
                    IList<OUser> lstUser = obj.Get(listUser[i]);
                    if (lstUser.Count() > 0)
                        list += lstUser[0].FullName + "; ";
                }
                list = list.Remove(list.Length - 2);
            }
            else
            {
                list = "Chưa có người thực hiện!";
            }
            
            return list;
        }

        protected string BindHanKetThuc(string WorkID)
        {
            string str = string.Empty;
            DateTime time;
            BWork obj = new BWork();
            time = obj.GetWork(int.Parse(WorkID)).First().EndProcess;
            str = time.Day.ToString() + "/" + time.Month.ToString() + "/" + time.Year.ToString();
            return str;
        }

        protected string BindTrangThai(string WorkID)
        {
            string status = string.Empty;
            BWork obj = new BWork();
            OWork objWork = new OWork();
            objWork = obj.GetWork(int.Parse(WorkID)).First();
            if (objWork.Status == "CONG_VIEC_DA_XU_LY")
            {
                status = "Công việc đã xử lý";
            }
            if (objWork.Status == "DANG_THUC_HIEN")
            {
                status = "Công việc cần xử lý";
            }
            
            return status;
        }

        protected string BindNgayGiao(string WorkID)
        {
            string str = string.Empty;
            DateTime time;
            BWork obj = new BWork();
            time = obj.GetWork(int.Parse(WorkID)).First().StartProcess;
            str = time.Day.ToString() + "/" + time.Month.ToString() + "/" + time.Year.ToString();
            return str;
        }

        protected void btnTim_Click(object sender, EventArgs e)
        {
            grvWork_Load();            
        }

        protected void grvWork_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowState == DataControlRowState.Normal)
                e.Row.CssClass = "normal";
            if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowState == DataControlRowState.Alternate)
                e.Row.CssClass = "altenate";
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
