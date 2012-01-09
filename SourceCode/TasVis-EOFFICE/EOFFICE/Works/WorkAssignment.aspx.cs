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

        protected void grvWork_Load()
        {
            BWork objWork = new BWork();
            grvWork.DataSource = objWork.GetWork(0);
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
    }
}
