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
using Telerik.Web.UI;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Globalization;
using EOFFICE.Common;

namespace EOFFICE.Calender
{
    public partial class Calendar : System.Web.UI.Page
    {
        

        Label lblUserJoin;
        string Status = string.Empty;
        string SelectTime=string.Empty;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {                
                //Hiển thị lịch công tác
                RadScheduler_Load();
            }
        }

        private void RadScheduler_Load()
        {
            string UserName = Global.UserInfo.UserName;
            BCalendar BobjCalendar = new BCalendar();
            List<OCalendar> listJoin = BobjCalendar.Get(0, ","+UserName+",").ToList();
            
            List<OCalendar> listCreate = BobjCalendar.GetCreate(0, UserName).ToList();
            var list1 = from x in listJoin
                        where x.UserCreate != UserName
                        select x;
            List<OCalendar> list = list1.Union(listCreate).ToList();
            
            RadScheduler1.DataSource = list;
            RadScheduler1.DataBind();
            
        }

        protected void RadScheduler1_FormCreated(object sender, Telerik.Web.UI.SchedulerFormCreatedEventArgs e)
        {
            if (e.Container.Mode == SchedulerFormMode.Insert)
            {
                Status = "Insert";
            }
            if(e.Container.Mode == SchedulerFormMode.AdvancedInsert)
            {
                Status = "AdvancedInsert";
                RadDateTimePicker startInput = (RadDateTimePicker)e.Container.FindControl("StartInput");
                //startInput.SelectedDate = DateTime.Parse(hdf.Value);                
                RadDateTimePicker endInput = (RadDateTimePicker)e.Container.FindControl("EndInput");
                //endInput.SelectedDate = DateTime.Parse(hdf.Value);
                //-- Kiểm tra quyền tạo việc
                BUser ctl = new BUser();
                Panel panelUser = (Panel)e.Container.FindControl("panelUser");
                if (ctl.HasPermission(Global.UserInfo.UserID, PermissionCode.CalendarCreate.ToString()) || Global.IsAdmin())
                {
                    panelUser.Visible = true;
                }
                else
                {
                    panelUser.Visible = false;
                }
            }
            if (e.Container.Mode == SchedulerFormMode.AdvancedEdit)
            {
                HiddenField hdfID = ((HiddenField)e.Container.FindControl("hdfID"));
                hdfID.Value = e.Appointment.ID.ToString();
                TextBox subjectBox = (TextBox)e.Container.FindControl("SubjectTextBox");
                subjectBox.Text = e.Appointment.Subject;
                RadDateTimePicker startInput = (RadDateTimePicker)e.Container.FindControl("StartInput");
                //startInput. = RadScheduler1.EditFormDateFormat + " " + RadScheduler1.EditFormTimeFormat;
                startInput.SelectedDate = RadScheduler1.DisplayToUtc(e.Appointment.Start);
                RadDateTimePicker endInput = (RadDateTimePicker)e.Container.FindControl("EndInput");
                //endInput.DateFormat = RadScheduler1.EditFormDateFormat + " " + RadScheduler1.EditFormTimeFormat;
                endInput.SelectedDate = RadScheduler1.DisplayToUtc(e.Appointment.End);
                TextBox txtDescription = (TextBox)e.Container.FindControl("txtDescription");
                txtDescription.Text = e.Appointment.Description;
                TextBox txtAddress =(TextBox) e.Container.FindControl("txtAddress");
                
                BCalendar BCaledarobj = new BCalendar();
                OCalendar objCalendar = new OCalendar();
                objCalendar = BCaledarobj.Get(int.Parse(e.Appointment.ID.ToString())).First();
                //Lấy danh sách người tham gia
                BUser BobjUser = new BUser();
                OUser objUser = new OUser();
                string[] listUser;
                
                string mesage = string.Empty;
                string UserJoin = objCalendar.UserJoin;
                listUser = UserJoin.Split(',');
                for (int i = 1; i < listUser.Count() - 1; i++)
                {
                    
                    mesage += "- "+BobjUser.Get(listUser[i]).First().FullName + "<br/>";
                }
                HiddenField hdfUserJoin = (HiddenField)e.Container.FindControl("hdfUserJoin");
                hdfUserJoin.Value = UserJoin;
                lblUserJoin = (Label)e.Container.FindControl("lblUserJoin");
                lblUserJoin.Text = mesage;

                //Lấy địa chỉ họp
                txtAddress.Text = objCalendar.Address;

                Panel panelUser = (Panel)e.Container.FindControl("panelUser");
                //-- Kiểm tra quyền tạo việc
                BUser ctl = new BUser();
                if (ctl.HasPermission(Global.UserInfo.UserID, PermissionCode.CalendarCreate.ToString()) || Global.IsAdmin())
                {
                    panelUser.Visible = true;
                }
                else
                {
                    panelUser.Visible = false;
                }
            }
        }

        

        public List<ODepartment> BindDepartment()
        {
            BDepartment BobjDepartment = new BDepartment();
            return BobjDepartment.Get(0).ToList();
        }

       

        protected void RadScheduler1_AppointmentCommand(object sender, AppointmentCommandEventArgs e)
        {
            string UserName = Global.UserInfo.UserName;
            if (e.CommandName == "Update")
            {
                string CalendarID = ((HiddenField)e.Container.FindControl("hdfID")).Value;
                string Name = ((TextBox)e.Container.FindControl("SubjectTextBox")).Text;
                string Description = ((TextBox)e.Container.FindControl("txtDescription")).Text;
                RadDateTimePicker RadStartDate = (RadDateTimePicker)e.Container.FindControl("StartInput");
                DateTime StartDate = DateTime.Parse(RadStartDate.DateInput.SelectedDate.ToString());
                RadDateTimePicker RadEndDate = (RadDateTimePicker)e.Container.FindControl("EndInput");
                DateTime EndDate = DateTime.Parse(RadStartDate.DateInput.SelectedDate.ToString());
                string Address = ((TextBox)e.Container.FindControl("txtAddress")).Text;
                //Kiểm tra quyền tạo lịch
                BUser ctl = new BUser();
                string UserJoin = "";

                if (ctl.HasPermission(Global.UserInfo.UserID, PermissionCode.CalendarCreate.ToString()) || Global.IsAdmin())
                {
                    if (Request.Form["ckxUser"] != "")
                    { 
                        UserJoin = "," + Request.Form["ckxUser"] + ",";
                    }
                        
                }
                else
                {
                    UserJoin = "";
                }                
                BCalendar BobjCalendar = new BCalendar();
                BobjCalendar.Update(int.Parse(CalendarID), Name, Description, StartDate, EndDate, UserJoin, Address);
                RadScheduler_Load();
                
            }
            if (e.CommandName == "Insert")
            {
                if (Status == "Insert")
                {
                    //CultureInfo culture = new CultureInfo("fr-FR", true);
                    RadTextBox txtName = (RadTextBox)e.Container.FindControl("txtName");

                    BCalendar BobjCalendar = new BCalendar();
                    OCalendar objCalendar = new OCalendar();
                    objCalendar.Name = txtName.Text;
                    objCalendar.StartDate = DateTime.Parse(hdf.Value);
                    objCalendar.EndDate = DateTime.Parse(hdf.Value);
                    objCalendar.Address = string.Empty;
                    objCalendar.Content = string.Empty;
                    objCalendar.UserJoin = string.Empty;
                    objCalendar.UserCreate = UserName;
                    BobjCalendar.Add(objCalendar);
                    RadScheduler_Load();
                    
                }
                if (Status == "AdvancedInsert")
                {
                    string Name = ((TextBox)e.Container.FindControl("SubjectTextBox")).Text;

                    string Description = ((TextBox)e.Container.FindControl("txtDescription")).Text;

                    RadDateTimePicker RadStartDate = (RadDateTimePicker)e.Container.FindControl("StartInput");
                    DateTime StartDate = DateTime.Parse(RadStartDate.DateInput.SelectedDate.ToString());

                    RadDateTimePicker RadEndDate = (RadDateTimePicker)e.Container.FindControl("EndInput");
                    DateTime EndDate = DateTime.Parse(RadStartDate.DateInput.SelectedDate.ToString());

                    string Address = ((TextBox)e.Container.FindControl("txtAddress")).Text;

                    //Kiểm tra quyền tạo lịch
                    BUser ctl = new BUser();
                    string UserJoin="";

                    if (ctl.HasPermission(Global.UserInfo.UserID, PermissionCode.CalendarCreate.ToString()) || Global.IsAdmin())
                    {
                        if (Request.Form["ckxUser"] != "")
                        {
                            UserJoin = "," + Request.Form["ckxUser"] + ",";
                        }
                    }
                    else
                    {
                        UserJoin = "";
                    }
                    
                    BCalendar BobjCalendar = new BCalendar();
                    OCalendar objCalendar = new OCalendar();

                    objCalendar.Name = Name;
                    objCalendar.Content = Description;
                    objCalendar.StartDate = StartDate;
                    objCalendar.EndDate = EndDate;
                    objCalendar.Address = Address;
                    objCalendar.UserJoin = UserJoin;
                    objCalendar.UserCreate = UserName;
                    BobjCalendar.Add(objCalendar);
                    RadScheduler_Load();
                }
            }
            
        }

        protected void RadScheduler1_AppointmentDelete(object sender, AppointmentDeleteEventArgs e)
        {
            int CalendarID = int.Parse(e.Appointment.ID.ToString());
            BCalendar BobjCalendar = new BCalendar();
            BobjCalendar.Delete(CalendarID);
        }

        protected void RadScheduler1_AppointmentCreated(object sender, AppointmentCreatedEventArgs e)
        {
            string UserName = Global.UserInfo.UserName;
            int CalendarID = int.Parse(e.Appointment.ID.ToString());
            BCalendar BobjCalendar = new BCalendar();
            OCalendar objCalendar = new OCalendar();
            objCalendar = BobjCalendar.Get(CalendarID).First();
            if (objCalendar.UserCreate == UserName)
            {
                e.Appointment.AllowEdit = true;
                e.Appointment.AllowDelete = true;
            }
            else
            {
                e.Appointment.AllowEdit = false;
                e.Appointment.AllowDelete = false;
            }
        }           
    }
}
