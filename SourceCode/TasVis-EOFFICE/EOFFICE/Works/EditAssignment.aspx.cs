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

namespace EOFFICE.Works
{
    public partial class EditAssignment : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                InitData();
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

        }

        protected void btnForward_Click(object sender, EventArgs e)
        {

        }
    }
}
