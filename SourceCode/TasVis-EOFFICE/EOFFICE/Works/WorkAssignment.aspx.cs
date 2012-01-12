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
            grvWork.DataSource = objWork.Get(1, "CHUA_GIAO").Union(objWork.Get(1, "DANG_THUC_HIEN")).Union(objWork.Get(1, "DUNG_XU_LY"));
            grvWork.DataBind();

            if ((objWork.Get(1, "CHUA_GIAO").Union(objWork.Get(1, "DANG_THUC_HIEN")).Union(objWork.Get(1, "DUNG_XU_LY"))).Count()==0)
            {
                lblThongBao.Text = "Không có công việc nào";
            }
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
            for (int i = 1; i < listUser.Count()-1; i++)
            {
                list += obj.Get(listUser[i]).First().FullName + "; ";
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
            string str2 = appSettings["DUNG_XU_LY"];
            ListItem[] lit = new ListItem[4];
            lit[0]= new ListItem("Tất cả","0");
            lit[1] = new ListItem(str, "CHUA_GIAO");
            lit[2] = new ListItem(str1,"DANG_THUC_HIEN");
            lit[3] = new ListItem(str2, "DUNG_XU_LY");
            ddlWork.Items.Add(lit[0]);
            ddlWork.Items.Add(lit[1]);
            ddlWork.Items.Add(lit[2]);
            ddlWork.Items.Add(lit[3]);
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
                    grvWork.DataSource = objWork.Get(1, name, "CHUA_GIAO", UserProcess).Union(objWork.Get(1, name, "DANG_THUC_HIEN", UserProcess)).Union(objWork.Get(1, name, "DUNG_XU_LY", UserProcess));
                    
                }
                else
                {
                    grvWork.DataSource = objWork.Get(1, name, ddlWork.SelectedValue.ToString(), UserProcess);
                }
            }
            else
            {
                if (ddlWork.SelectedValue == "0")
                {
                    grvWork.DataSource = objWork.Get(1, name, "CHUA_GIAO", Int32.Parse(ddlWorkGroup.SelectedValue.ToString()), UserProcess).Union(objWork.Get(1, name, "DANG_THUC_HIEN", Int32.Parse(ddlWorkGroup.SelectedValue.ToString()), UserProcess)).Union(objWork.Get(1, name, "DUNG_XU_LY", Int32.Parse(ddlWorkGroup.SelectedValue.ToString()), UserProcess));
                }
                else
                {
                    grvWork.DataSource = objWork.Get(1, name, ddlWork.SelectedValue.ToString(), Int32.Parse(ddlWorkGroup.SelectedValue.ToString()), UserProcess);
                }
            }
            
            grvWork.DataBind();
            if (grvWork.DataSource == null)
            {
                lblThongBao.Text = "Không có công việc nào";
            }
            string str = lblThongBao.Text;
        }       

        protected void btnDung_Click(object sender, EventArgs e)
        {
            BWork obj = new BWork();
            foreach (GridViewRow row in grvWork.Rows)
            {
                CheckBox checkbox = (CheckBox)row.FindControl("MyCheckBox");

                if (checkbox.Checked == true)
                {
                    int Id = Convert.ToInt32(grvWork.DataKeys[row.RowIndex].Value);
                    if (obj.GetWork(Id).First().Status != "CHUA_GIAO")
                    {
                        obj.Update(Id, "DUNG_XU_LY",1);
                    }
                }
            }
            grvWork_Load();
        }

        protected void btnTiepTuc_Click(object sender, EventArgs e)
        {
            BWork obj = new BWork();
            foreach (GridViewRow row in grvWork.Rows)
            {
                CheckBox checkbox = (CheckBox)row.FindControl("MyCheckBox");

                if (checkbox.Checked == true)
                {
                    int Id = Convert.ToInt32(grvWork.DataKeys[row.RowIndex].Value);
                    if (obj.GetWork(Id).First().Status == "DUNG_XU_LY")
                    {
                        obj.Update(Id, "DANG_THUC_HIEN", 1);
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
            BWork obj = new BWork();
            foreach (GridViewRow row in grvWork.Rows)
            {
                CheckBox checkbox = (CheckBox)row.FindControl("MyCheckBox");

                if (checkbox.Checked == true)
                {
                    int Id = Convert.ToInt32(grvWork.DataKeys[row.RowIndex].Value);
                    if (obj.GetWork(Id).First().Status == "CHUA_GIAO")
                    {
                        obj.Update(Id, "DANG_THUC_HIEN", 1);
                    }
                }
            }
            grvWork_Load();
        }
    }
}
