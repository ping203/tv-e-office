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


namespace EOFFICE.Calender
{
    public partial class Calendar : System.Web.UI.Page
    {
        public class friend
        {
            string name;
        }

        Label lblUserJoin;
        string Status = string.Empty;
        string SelectTime=string.Empty;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            
            friend a = new friend();
            friend b = new friend();
            friend c = new friend();
            List<friend> list1 = new List<friend>();
            List<friend> list2 = new List<friend>();
            List<friend> list3 = new List<friend>();
            list1.Add(a);
            list1.Add(b);
            list2.Add(a);
            list2.Add(c);
            list3 = list1.Union(list2).ToList();
            lblThongBao.Text = list3.Count.ToString();
            if (!Page.IsPostBack)
            {
                //Hiển thị lịch công tác
                RadScheduler_Load();
            }
        }

        private void RadScheduler_Load()
        {
            BCalendar BobjCalendar = new BCalendar();

            RadScheduler1.DataSource = BobjCalendar.Get(0,",vanhung,");//UserName lấy sau
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
                
                lblUserJoin = (Label)e.Container.FindControl("lblUserJoin");
                lblUserJoin.Text = mesage;

                //Lấy địa chỉ họp
                txtAddress.Text = objCalendar.Address;
                
            }
        }

        

        public List<ODepartment> BindDepartment()
        {
            BDepartment BobjDepartment = new BDepartment();
            return BobjDepartment.Get(0).ToList();
        }

        protected void RadScheduler1_AppointmentUpdate(object sender, AppointmentUpdateEventArgs e)
        {            
            ControlCollection ccControl = RadScheduler1.Controls;
            if (ccControl.Count>0)
            {
                ControlCollection ccControlWeb=ccControl[0].Controls;
                
                string Name=((TextBox)ccControlWeb[0].FindControl("SubjectTextBox")).Text;

                string Description = ((TextBox)ccControlWeb[0].FindControl("txtDescription")).Text;
                
                RadDateTimePicker RadStartDate = (RadDateTimePicker)ccControlWeb[0].FindControl("StartInput");
                DateTime StartDate = DateTime.Parse(RadStartDate.DateInput.SelectedDate.ToString());

                RadDateTimePicker RadEndDate = (RadDateTimePicker)ccControlWeb[0].FindControl("EndInput");
                DateTime EndDate = DateTime.Parse(RadStartDate.DateInput.SelectedDate.ToString());

                string Address = ((TextBox)ccControlWeb[0].FindControl("txtAddress")).Text;

                string UserJoin = "," + Request.Form["ckxUser"] +",";
                
                BCalendar BobjCalendar = new BCalendar();

                BobjCalendar.Update(int.Parse(e.Appointment.ID.ToString()), Name, Description, StartDate, EndDate, UserJoin, Address);
                RadScheduler_Load();
            }
                              
        }

        protected void RadScheduler1_AppointmentInsert(object sender, AppointmentInsertEventArgs e)
        {
            if (Status == "AdvancedInsert")
            {
                ControlCollection ccControl = RadScheduler1.Controls;
                if (ccControl.Count > 0)
                {
                    ControlCollection ccControlWeb = ccControl[0].Controls;

                    string Name = ((TextBox)ccControlWeb[0].FindControl("SubjectTextBox")).Text;

                    string Description = ((TextBox)ccControlWeb[0].FindControl("txtDescription")).Text;

                    RadDateTimePicker RadStartDate = (RadDateTimePicker)ccControlWeb[0].FindControl("StartInput");
                    DateTime StartDate = DateTime.Parse(RadStartDate.DateInput.SelectedDate.ToString());

                    RadDateTimePicker RadEndDate = (RadDateTimePicker)ccControlWeb[0].FindControl("EndInput");
                    DateTime EndDate = DateTime.Parse(RadStartDate.DateInput.SelectedDate.ToString());

                    string Address = ((TextBox)ccControlWeb[0].FindControl("txtAddress")).Text;

                    string UserJoin = "," + Request.Form["ckxUser"] + ",";

                    BCalendar BobjCalendar = new BCalendar();
                    OCalendar objCalendar = new OCalendar();

                    objCalendar.Name = Name;
                    objCalendar.Content = Description;
                    objCalendar.StartDate = StartDate;
                    objCalendar.EndDate = EndDate;
                    objCalendar.Address = Address;
                    objCalendar.UserJoin = UserJoin;

                    BobjCalendar.Add(objCalendar);
                    RadScheduler_Load();
                }
            }

            if (Status == "Insert")
            {
                string Name = HiddenField1.Value;
                lblThongBao.Text = Request.Form["txtName"];
                
            }
        }

        protected void RadScheduler1_AppointmentCommand(object sender, AppointmentCommandEventArgs e)
        {
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

                string UserJoin = "," + Request.Form["ckxUser"] + ",";
                BCalendar BobjCalendar = new BCalendar();
                BobjCalendar.Update(int.Parse(CalendarID), Name, Description, StartDate, EndDate, UserJoin, Address);
                RadScheduler_Load();
            }
            if (e.CommandName == "Insert")
            {
                if (Status == "Insert")
                {
                    RadTextBox txtName = (RadTextBox)e.Container.FindControl("txtName");

                    //HiddenField hdfTime = (HiddenField)e.Container.FindControl("hdfTime");
                    //lblThongBao.Text = hdfTime.Value;
                }
            }
        }        
    }
}
