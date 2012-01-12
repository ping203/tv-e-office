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

namespace EOFFICE.Works
{
    public partial class WorkReceived : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ddlWorkGroup_Load();
                ddlWork_Load();
                grvWork_Load();
            }
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
            ListItem[] lit = new ListItem[3];
            lit[0] = new ListItem("Tất cả", "0");
            lit[1] = new ListItem("Công việc cần xử lý", "DANG_THUC_HIEN");
            lit[2] = new ListItem(str1, "CONG_VIEC_DA_XU_LY");
            ddlWork.Items.Add(lit[0]);
            ddlWork.Items.Add(lit[1]);
            ddlWork.Items.Add(lit[2]);
        }


        protected void grvWork_Load()
        {
            BWork objWork = new BWork();
            grvWork.DataSource = objWork.Get(",admin,", "DANG_THUC_HIEN").Union(objWork.Get(",admin,", "CONG_VIEC_DA_XU_LY"));
            grvWork.DataBind();
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
            for (int i = 1; i < listUser.Count() - 1; i++)
            {
                list += obj.Get(listUser[i]).First().FullName + "; ";
            }
            list = list.Remove(list.Length - 2);
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
            BWork objWork = new BWork();
            BUser objUser = new BUser();
            string name = txtWorkName.Text;
            string UserCreate = txtUserCreate.Text;
            int IDUserCreate;
            
            if (UserCreate.Trim() == "")
            {
                
                    if (ddlWorkGroup.SelectedValue == "0")
                    {
                        if (ddlWork.SelectedValue == "0")
                        {
                            grvWork.DataSource = objWork.Get(name, "DANG_THUC_HIEN", ",admin,").Union(objWork.Get( name, "CONG_VIEC_DA_XU_LY", ",admin,"));

                        }
                        else
                        {
                            grvWork.DataSource = objWork.Get( name, ddlWork.SelectedValue.ToString(), ",admin,");
                        }
                    }
                    else
                    {
                        if (ddlWork.SelectedValue == "0")
                        {
                            grvWork.DataSource = objWork.Get( name, "DANG_THUC_HIEN", Int32.Parse(ddlWorkGroup.SelectedValue.ToString()), ",admin,").Union(objWork.Get( name, "CONG_VIEC_DA_XU_LY", Int32.Parse(ddlWorkGroup.SelectedValue.ToString()), ",admin,"));
                        }
                        else
                        {
                            grvWork.DataSource = objWork.Get(name, ddlWork.SelectedValue.ToString(), Int32.Parse(ddlWorkGroup.SelectedValue.ToString()), ",admin,");
                        }
                    }
            }
            else
            {
                if (objUser.Get(UserCreate).Count > 0)
                {
                    IDUserCreate = objUser.Get(UserCreate).First().UserID;
                    if (ddlWorkGroup.SelectedValue == "0")
                    {
                        if (ddlWork.SelectedValue == "0")
                        {
                            grvWork.DataSource = objWork.Get(IDUserCreate, name, "DANG_THUC_HIEN", ",admin,").Union(objWork.Get(IDUserCreate, name, "CONG_VIEC_DA_XU_LY", ",admin,"));

                        }
                        else
                        {
                            grvWork.DataSource = objWork.Get(IDUserCreate, name, ddlWork.SelectedValue.ToString(), ",admin,");
                        }
                    }
                    else
                    {
                        if (ddlWork.SelectedValue == "0")
                        {
                            grvWork.DataSource = objWork.Get(IDUserCreate, name, "DANG_THUC_HIEN", Int32.Parse(ddlWorkGroup.SelectedValue.ToString()), ",admin,").Union(objWork.Get(IDUserCreate, name, "CONG_VIEC_DA_XU_LY", Int32.Parse(ddlWorkGroup.SelectedValue.ToString()), ",admin,"));
                        }
                        else
                        {
                            grvWork.DataSource = objWork.Get(IDUserCreate, name, ddlWork.SelectedValue.ToString(), Int32.Parse(ddlWorkGroup.SelectedValue.ToString()), ",admin,");
                        }
                    }
                }
            }
            

            grvWork.DataBind();
        }
    }
}
