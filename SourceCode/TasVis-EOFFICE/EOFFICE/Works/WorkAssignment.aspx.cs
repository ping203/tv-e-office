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
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ddlWorkGroup_Load();
                grvWork_Load();
                ddlWork_Load();
            }
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
            BWork objWork = new BWork();
            grvWork.DataSource = objWork.Get(1, "CHUA_GIAO").Union(objWork.Get(1, "DANG_THUC_HIEN"));
            grvWork.DataBind();
        }


        protected void grvWork_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {

                //adding an attribute for onclick event on the check box in the header

                //and passing the ClientID of the Select All checkbox

                ((CheckBox)e.Row.FindControl("CheckAll")).Attributes.Add("onclick", "javascript:SelectAll('" + ((CheckBox)e.Row.FindControl("CheckAll")).ClientID + "')");
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
            for (int i = 0; i < listUser.Count(); i++)
            {
                list += obj.Get(listUser[i]).First().FullName+"; ";
            }
            list = list.Remove(list.Length - 2);
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
            ListItem[] lit = new ListItem[3];
            lit[0]= new ListItem("Tất cả","0");
            lit[1] = new ListItem(str, "CHUA_GIAO");
            lit[2] = new ListItem(str1,"DANG_THUC_HIEN");
            ddlWork.Items.Add(lit[0]);
            ddlWork.Items.Add(lit[1]);
            ddlWork.Items.Add(lit[2]);
        }

        protected void btnTim_Click(object sender, EventArgs e)
        {
            BWork objWork = new BWork();

            string name = txtWorkName.Text;
            string UserProcess = txtUserProcess.Text;

            if (ddlWorkGroup.SelectedValue == "0")
            {
                if (ddlWork.SelectedValue == "0")
                {
                    grvWork.DataSource = objWork.Get(1, name, "CHUA_GIAO", UserProcess).Union(objWork.Get(1, name, "DANG_THUC_HIEN", UserProcess));                   
                }
                else
                {
                    grvWork.DataSource = objWork.Get(1, name, ddlWork.SelectedValue.ToString(), UserProcess);
                }
            }
            else
            {
                    grvWork.DataSource = objWork.Get(1, name, ddlWork.SelectedValue.ToString(),Int32.Parse( ddlWorkGroup.SelectedValue.ToString()), UserProcess);
            }
            
            grvWork.DataBind();
        }
    }
}
