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

namespace EOFFICE.Works
{
    public partial class Default : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ddlWorkGroup_Load();
                rptUserProcess_Load();
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

        protected void btnSave_Click(object sender, EventArgs e)
        {
            CultureInfo culture = new CultureInfo("fr-FR", true);
            
            OWork objWork = new OWork();
            objWork.Name = txtWorkName.Text;
            objWork.Description = txtDescription.Text;
            objWork.Content = txtContent.Text;
            //--Lấy IDUserCreate sau
            objWork.IDUserCreate = 1;
            objWork.IDWorkGroup =int.Parse(ddlWorkGroup.SelectedValue);
            objWork.StartProcess = DateTime.Parse(txtStartDate.Text, culture, DateTimeStyles.NoCurrentDateDefault);
            objWork.EndProcess = DateTime.Parse(txtEndDate.Text, culture, DateTimeStyles.NoCurrentDateDefault);

            //Upload File
            DateTime CurrentTime = DateTime.Now;
            string day = CurrentTime.Day.ToString();
            string month = CurrentTime.Month.ToString();
            string year = CurrentTime.Year.ToString();
            string hour = CurrentTime.Hour.ToString();
            string minute = CurrentTime.Minute.ToString();
            string millisecond = CurrentTime.Millisecond.ToString();
            string str = " " + day + "-" + month + "-" + year + "-" + "-" + hour + "-" + minute + "-" + millisecond;
            BAttach Bobj = new BAttach();
            try
            {
                // Get the HttpFileCollection
                HttpFileCollection hfc = Request.Files;
                for (int i = 0; i < hfc.Count; i++)
                {
                    HttpPostedFile hpf = hfc[i];
                    if (hpf.ContentLength > 0)
                    {
                        hpf.SaveAs(Server.MapPath("/MyFiles") + "/" + System.IO.Path.GetFileNameWithoutExtension(hpf.FileName) + str + System.IO.Path.GetExtension(hpf.FileName));
                        OAttach obj = new OAttach();
                        obj.Name = System.IO.Path.GetFileName(hpf.FileName);
                        obj.Path = "~/MyFiles" + "/" + System.IO.Path.GetFileNameWithoutExtension(hpf.FileName) + str + System.IO.Path.GetExtension(hpf.FileName);
                        obj.Description = "";
                        Bobj.Add(obj);
                    }
                }
            }
            catch (Exception ex)
            {

            }

            //Lấy danh sách Người thực hiện công việc
            foreach (RepeaterItem oItem in rptUserProcess.Items)
            {
                CheckBox chkBoxSelected = oItem.FindControl("cbxCheck") as CheckBox;
                if (chkBoxSelected.Checked)
                {
                    //int Id = Convert.ToInt32(rptUserProcess.);
                    
                }
            }

        }

        private void rptUserProcess_Load()
        {
            BUser obj = new BUser();
            string username = string.Empty;
            rptUserProcess.DataSource = obj.Get(username);
            rptUserProcess.DataBind();
        }

        
    }
}
