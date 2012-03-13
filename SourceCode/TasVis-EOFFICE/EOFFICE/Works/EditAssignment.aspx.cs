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
using System.IO;
using System.Globalization;
using EOFFICE.Common;

namespace EOFFICE.Works
{
    public partial class EditAssignment : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                InitData();
                //-- Kiểm tra quyền giao việc
                BUser ctl = new BUser();
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

        protected void InitData()
        {
            ddlWorkGroup_Load();
            BindDepartment();

            BWork _BWork = new BWork();
            OWork _OWork = new OWork();
            int WorkID = int.Parse(Request.QueryString["WorkID"].ToString());

            _OWork = _BWork.GetWork(WorkID).First();
            ddlWorkGroup.SelectedValue = _OWork.IDWorkGroup.ToString();
            txtWorkName.Text = _OWork.Name;
            txtContent.Text = _OWork.Content;
            txtDescription.Text = _OWork.Description;
            txtStartDate.Text = _OWork.StartProcess.ToString("dd/MM/yyyy");
            txtEndDate.Text = _OWork.EndProcess.ToString("dd/MM/yyyy");

            //Lấy file Attachs
            string list = _OWork.Attachs.ToString();
            string[] item;
            item = list.Split(',');

            rptFiles.DataSource = _BWork.GetAttachs(WorkID);
            rptFiles.DataBind();

            if (_OWork.Attachs == "" || _OWork.Attachs == ",")
            {
                lblThongBao.Text = "Không có file đính kèm!";
            }

            hdfUserJoin.Value = _OWork.IDUserProcess;
        }

        public void rptItemCommand(object sender, RepeaterCommandEventArgs e)
        {
            //Response.Write(e.CommandName);
            //Response.Write(e.CommandArgument);
            if (e.CommandName == "Download")
            {
                try
                {
                    HttpContext.Current.Response.ContentType =
                                "application/octet-stream";
                    HttpContext.Current.Response.AddHeader("Content-Disposition",
                      "attachment; filename=" + System.IO.Path.GetFileName(Server.MapPath(e.CommandArgument.ToString())));
                    HttpContext.Current.Response.Clear();
                    HttpContext.Current.Response.WriteFile(Server.MapPath(e.CommandArgument.ToString()));
                    HttpContext.Current.Response.End();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            if (e.CommandName == "Delete")
            {
                int WorkID = int.Parse(Request.QueryString["WorkID"].ToString());
                OAttach objAttach = new OAttach();
                BAttach BobjAttach = new BAttach();
                BWork BobjWork = new BWork();
                OWork objWork = BobjWork.GetWork(WorkID).First();
                int IDUserCreate = int.Parse(objWork.IDUserCreate.ToString());
                string listAttach = objWork.Attachs.ToString();
                objAttach = BobjAttach.Get(int.Parse(e.CommandArgument.ToString())).First();
                string AttachId = objAttach.AttachID.ToString();
                try
                {
                    FileInfo TheFile = new FileInfo(Server.MapPath(objAttach.Path));
                    if (TheFile.Exists)
                    {
                        File.Delete(Server.MapPath(objAttach.Path));//Xóa file Attach
                        BobjAttach.Delete(objAttach.AttachID);//Xóa file Attach trong CSDL
                        string newListAttach = listAttach.Replace("," + AttachId + ",", ",");
                        BobjWork.UpdateAttach(WorkID, newListAttach, IDUserCreate);
                        InitData();
                    }
                    else
                    {
                        throw new FileNotFoundException();
                    }
                }
                catch (Exception ex)
                {
                    //throw new FileNotFoundException();
                }
            }
        }

        public void BindDepartment()
        {
            BDepartment BobjDepartment = new BDepartment();
            rptDepartment.DataSource = BobjDepartment.Get(0);
            rptDepartment.DataBind();
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

        protected void btnSave_Click(object sender, EventArgs e)
        {
            int WorkID = int.Parse(Request.QueryString["WorkID"].ToString());
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

            // Cập nhật công việc
            OWork objWork = new OWork();
            BWork _BWork = new BWork();
            objWork = _BWork.GetWork(WorkID).First();

            string Name = txtWorkName.Text;
            string Description = txtDescription.Text;
            string Content = txtContent.Text;
            string Attachs=objWork.Attachs;
            if (listFile != ",")
            {
                Attachs = Attachs.Remove(Attachs.Length - 1, 1) + listFile;
            }
            int IDUserCreate = objWork.IDUserCreate;
            string IDUserProcess = "";
            //-- Kiểm tra quyền giao việc
            BUser ctl = new BUser();
            if (ctl.HasPermission(Global.UserInfo.UserID, PermissionCode.WorkAssignment.ToString()) || Global.IsAdmin())
            {
                IDUserProcess = UserJoin;
            }
            else
            {
                IDUserProcess = ","+Global.UserInfo.UserName+",";
            }
           
            
            int IDWorkGroup = int.Parse(ddlWorkGroup.SelectedValue);
            DateTime CreateDate = objWork.CreateDate;
            string Status = "CHUA_GIAO";
            // Priority = Priority;
            DateTime StartProcess = DateTime.Parse(txtStartDate.Text, culture, DateTimeStyles.NoCurrentDateDefault);
            DateTime EndProcess = DateTime.Parse(txtEndDate.Text, culture, DateTimeStyles.NoCurrentDateDefault);

            BWork BobjWork = new BWork();
            if (BobjWork.Update(WorkID, Name, Description, Content, Attachs, IDUserCreate, IDUserProcess, CreateDate, StartProcess, EndProcess, Status, Priority, IDWorkGroup))
            {
                RegisterClientScriptBlock("NOTE", "<script>alert('Cập nhật thành công');</script>");
            }
            else
            {
                RegisterClientScriptBlock("NOTE", "<script>alert('Công việc chưa được cập nhật');</script>");
            }
            Response.Redirect(Request.Url.AbsoluteUri);
            
        }

        protected void btnForward_Click(object sender, EventArgs e)
        {
            int WorkID = int.Parse(Request.QueryString["WorkID"].ToString());
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

            // Cập nhật công việc
            OWork objWork = new OWork();
            BWork _BWork = new BWork();
            objWork = _BWork.GetWork(WorkID).First();

            string Name = txtWorkName.Text;
            string Description = txtDescription.Text;
            string Content = txtContent.Text;
            string Attachs = objWork.Attachs;
            if (listFile != ",")
            {
                Attachs = Attachs.Remove(Attachs.Length - 1, 1) + listFile;
            }
            int IDUserCreate = objWork.IDUserCreate;
            string IDUserProcess = "";
            //-- Kiểm tra quyền giao việc
            BUser ctl = new BUser();
            if (ctl.HasPermission(Global.UserInfo.UserID, PermissionCode.WorkAssignment.ToString()) || Global.IsAdmin())
            {
                IDUserProcess = UserJoin;
            }
            else
            {
                IDUserProcess = "," + Global.UserInfo.UserName + ",";
            }
            int IDWorkGroup = int.Parse(ddlWorkGroup.SelectedValue);
            DateTime CreateDate = objWork.CreateDate;
            string Status = "DANG_THUC_HIEN";
            // Priority = Priority;
            DateTime StartProcess = DateTime.Parse(txtStartDate.Text, culture, DateTimeStyles.NoCurrentDateDefault);
            DateTime EndProcess = DateTime.Parse(txtEndDate.Text, culture, DateTimeStyles.NoCurrentDateDefault);

            BWork BobjWork = new BWork();
            if (BobjWork.Update(WorkID, Name, Description, Content, Attachs, IDUserCreate, IDUserProcess, CreateDate, StartProcess, EndProcess, Status, Priority, IDWorkGroup))
            {
                Response.Redirect("WorkAssignment.aspx");
            }
            else
            {
                RegisterClientScriptBlock("NOTE", "<script>alert('Giao việc không thành công');</script>");
            }
            
        }
    }
}
