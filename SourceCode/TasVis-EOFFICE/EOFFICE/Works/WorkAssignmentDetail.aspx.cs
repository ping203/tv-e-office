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
using System.Net;
using System.IO;

namespace EOFFICE.Works
{
    public partial class WorkAssignmentDetail : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            Infomation_Load();
            if (!Page.IsPostBack)
            {

            }
        }

        protected void Infomation_Load()
        {
            int WorkID = int.Parse(Request.QueryString["WorkID"].ToString());

            BWork Bobj = new BWork();
            OWork obj = new OWork();
            obj = Bobj.GetWork(WorkID).First();

            lblName.Text = obj.Name;
            lblNgayTao.Text = obj.CreateDate.ToString("dd/MM/yyyy");
            lblNgayBatDau.Text = obj.StartProcess.ToString("dd/MM/yyyy");
            lblNgayKetThuc.Text = obj.EndProcess.ToString("dd/MM/yyyy");
            lblYeuCau.Text = obj.Description;

            //Lấy file Attachs
            string list = obj.Attachs.ToString();
            string[] item;
            item = list.Split(',');

            rptFiles.DataSource = Bobj.GetAttachs(WorkID);
            rptFiles.DataBind();

            if (obj.Attachs == "" || obj.Attachs == ",")
            {
                lblThongBao.Text = "Không có file đính kèm!";
            }
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
                int IDUserCreate=int.Parse(objWork.IDUserCreate.ToString());
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
                        string newListAttach = listAttach.Replace(","+ AttachId + ",", ",");
                        BobjWork.UpdateAttach(WorkID, newListAttach,IDUserCreate);
                        Infomation_Load();
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
    }
}
