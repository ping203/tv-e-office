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
using DataAccess.DataObject;
using DataAccess.Common;
using System.Globalization;
using System.Collections.Generic;
using EOFFICE.Common;

namespace EOFFICE.Works
{
    public partial class Default : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ddlWorkGroup_Load();
                
                BindDepartment();
                BUser ctl = new BUser();
                //-- Kiểm tra quyền giao việc
                if (ctl.HasPermission(Global.UserInfo.UserID, PermissionCode.WorkAssignment.ToString()) || Global.IsAdmin())
                {
                    trUser.Visible = true;
                }
                else
                {
                    trUser.Visible = false;
                }
            }
        }

        protected void ddlWorkGroup_Load()
        {
            ddlWorkGroup.Items.Clear();
            BWorkGroup bwg = new BWorkGroup();
            ddlWorkGroup.DataSource = bwg.Get(0);
            ddlWorkGroup.DataTextField = "Name";
            ddlWorkGroup.DataValueField = "WorkGroupID";
            ddlWorkGroup.DataBind();
        }

        public void BindDepartment()
        {
            BDepartment BobjDepartment = new BDepartment();
            rptDepartment.DataSource= BobjDepartment.Get(0);
            rptDepartment.DataBind();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            CultureInfo culture = new CultureInfo("fr-FR", true);
            
            //Upload File
            DateTime CurrentTime = DateTime.Now;
            string day = CurrentTime.Day.ToString();
            string month = CurrentTime.Month.ToString();
            string year = CurrentTime.Year.ToString();
            string hour = CurrentTime.Hour.ToString();
            string minute = CurrentTime.Minute.ToString();
            string millisecond = CurrentTime.Millisecond.ToString();
            string str = "-" + day + "-" + month + "-" + year + "-" + "-" + hour + "-" + minute + "-" + millisecond;

            //Lấy danh sách file Attach
            BAttach Bobj = new BAttach();
            HttpFileCollection hfc = Request.Files;
            int n = hfc.Count;
            string listFile = ",";
            try
            {
                // Get the HttpFileCollection
                
                for (int i = 0; i < hfc.Count; i++)
                {
                    HttpPostedFile hpf = hfc[i];
                    if (hpf.ContentLength > 0)
                    {
                        hpf.SaveAs(Server.MapPath("/MyFiles") + "/" + System.IO.Path.GetFileNameWithoutExtension(hpf.FileName).Replace(" ","_") + str + System.IO.Path.GetExtension(hpf.FileName));
                        OAttach obj = new OAttach();
                        obj.Name = System.IO.Path.GetFileName(hpf.FileName);
                        obj.Path = "~/MyFiles" + "/" + System.IO.Path.GetFileNameWithoutExtension(hpf.FileName).Replace(" ","_") + str + System.IO.Path.GetExtension(hpf.FileName);
                        obj.Description = "";
                        Bobj.Add(obj);
                        listFile += Bobj.GetLast().FirstOrDefault().AttachID.ToString() + ",";
                    }
                }
            }
            catch (Exception ex)
            {

            }
            
            
            //Lấy danh sách người thực hiện công việc

            string UserJoin = hdfUsers.Value;
            if (UserJoin == ",")
            {
                UserJoin = "";
            }
            else
            {
                UserJoin = "," + UserJoin;
            }
            //Lấy mức độ ưu tiên
            string Priority = string.Empty;
            if (rdoPrior1.Checked == true)
            {
                Priority = "RAT_QUAN_TRONG";
            }
            else if (rdoPrior2.Checked == true)
            {
                Priority = "QUAN_TRONG";
            }
            else
            {
                Priority = "BINH_THUONG";
            }

            //Lưu công việc mới
            OWork objWork = new OWork();
            objWork.Name = txtWorkName.Text;
            objWork.Description = txtDescription.Text;
            objWork.Content = txtContent.Text;
            objWork.Attachs = listFile;
            objWork.IDUserCreate = Global.UserInfo.UserID;
            BUser ctl = new BUser();
            //-- Kiểm tra quyền giao việc
            if (ctl.HasPermission(Global.UserInfo.UserID, PermissionCode.WorkAssignment.ToString()) || Global.IsAdmin())
            {
                objWork.IDUserProcess = UserJoin;
            }
            else
            {
                objWork.IDUserProcess = "," + Global.UserInfo.UserName + ",";
            }
            
            objWork.IDWorkGroup = int.Parse(ddlWorkGroup.SelectedValue);
            objWork.CreateDate = CurrentTime;
            objWork.Status = "CHUA_GIAO";
            objWork.Priority = Priority;
            objWork.StartProcess = DateTime.Parse(txtStartDate.Text, culture, DateTimeStyles.NoCurrentDateDefault);
            objWork.EndProcess = DateTime.Parse(txtEndDate.Text, culture, DateTimeStyles.NoCurrentDateDefault);

            BWork BobjWork = new BWork();
            BobjWork.Add(objWork);
            Response.Redirect("WorkAssignment.aspx");
        }

        

        protected void btnForward_Click(object sender, EventArgs e)
        {
            //Gửi thông báo tới người thực hiện công việc
                      

            //Upload File
            CultureInfo culture = new CultureInfo("fr-FR", true);

            //Upload File
            DateTime CurrentTime = DateTime.Now;
            string day = CurrentTime.Day.ToString();
            string month = CurrentTime.Month.ToString();
            string year = CurrentTime.Year.ToString();
            string hour = CurrentTime.Hour.ToString();
            string minute = CurrentTime.Minute.ToString();
            string millisecond = CurrentTime.Millisecond.ToString();
            string str = "-" + day + "-" + month + "-" + year + "-" + "-" + hour + "-" + minute + "-" + millisecond;

            //Lấy danh sách file Attach
            BAttach Bobj = new BAttach();
            HttpFileCollection hfc = Request.Files;
            int n = hfc.Count;
            string listFile = ",";
            try
            {
                // Get the HttpFileCollection

                for (int i = 0; i < hfc.Count; i++)
                {
                    HttpPostedFile hpf = hfc[i];
                    if (hpf.ContentLength > 0)
                    {
                        hpf.SaveAs(Server.MapPath("/MyFiles") + "/" + System.IO.Path.GetFileNameWithoutExtension(hpf.FileName).Replace(" ", "_") + str + System.IO.Path.GetExtension(hpf.FileName));
                        OAttach obj = new OAttach();
                        obj.Name = System.IO.Path.GetFileName(hpf.FileName);
                        obj.Path = "~/MyFiles" + "/" + System.IO.Path.GetFileNameWithoutExtension(hpf.FileName).Replace(" ", "_") + str + System.IO.Path.GetExtension(hpf.FileName);
                        obj.Description = "";
                        Bobj.Add(obj);
                        listFile += Bobj.GetLast().FirstOrDefault().AttachID.ToString() + ",";
                    }
                }
            }
            catch (Exception ex)
            {

            }


            //Lấy danh sách người thực hiện công việc

            string UserJoin = hdfUsers.Value;
            if (UserJoin == ",")
            {
                UserJoin = "";
            }
            else
            {
                UserJoin = "," + UserJoin;
            }
            //Lấy mức độ ưu tiên
            string Priority = string.Empty;
            if (rdoPrior1.Checked == true)
            {
                Priority = "RAT_QUAN_TRONG";
            }
            else if (rdoPrior2.Checked == true)
            {
                Priority = "QUAN_TRONG";
            }
            else
            {
                Priority = "BINH_THUONG";
            }

            //Lưu công việc mới
            OWork objWork = new OWork();
            objWork.Name = txtWorkName.Text;
            objWork.Description = txtDescription.Text;
            objWork.Content = txtContent.Text;
            objWork.Attachs = listFile;
            objWork.IDUserCreate = Global.UserInfo.UserID;   //--Lấy IDUserCreate sau
            objWork.IDUserProcess = UserJoin;
            objWork.IDWorkGroup = int.Parse(ddlWorkGroup.SelectedValue);
            objWork.CreateDate = CurrentTime;
            objWork.Status = "DANG_THUC_HIEN";
            objWork.Priority = Priority;
            objWork.StartProcess = DateTime.Parse(txtStartDate.Text, culture, DateTimeStyles.NoCurrentDateDefault);
            objWork.EndProcess = DateTime.Parse(txtEndDate.Text, culture, DateTimeStyles.NoCurrentDateDefault);

            BWork BobjWork = new BWork();
            BobjWork.Add(objWork);

            //Reset Field
            ResetField();            
            RegisterClientScriptBlock("NOTE", "<script>alert('Công việc đã được giao !');</script>");
        }

        protected void ResetField()
        {
            txtContent.Text = "";
            txtDescription.Text = "";
            txtEndDate.Text = "";
            txtStartDate.Text = "";
            txtWorkName.Text = "";
        }
    }
}
