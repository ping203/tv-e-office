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
            
            if (!Page.IsPostBack)
            {
                Infomation_Load();
            }
        }

        protected void rptListUser_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            int WorkID = int.Parse(Request.QueryString["WorkID"].ToString());
            if (e.CommandName == "trigger")
            {
                LinkButton btn = e.CommandSource as LinkButton;

                if (btn != null)
                {
                    RepeaterItem ri = e.Item;
                    HiddenField hdfID = (HiddenField)ri.FindControl("hdfID");

                    BComment BobjComment = new BComment();
                    OComment objComment = new OComment();
                    objComment = BobjComment.GetCreate(hdfID.Value, WorkID).First();

                    txtContentComment.Text = objComment.Content;
                    rptFileAttachs.DataSource = BobjComment.GetAttachs(objComment.CommentID);
                    rptFileAttachs.DataBind();
                }
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

            rptListUser.DataSource = Bobj.GetUserProcess(WorkID);
            rptListUser.DataBind();

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

        protected void btnThemXuLy_Click(object sender, EventArgs e)
        {
            BWork BobjWork = new BWork();
            //Lấy IDWWork
            int WorkID = int.Parse(Request.QueryString["WorkID"].ToString());
            //Lấy IDUserCreate
            string IDUserCreate = Global.UserInfo.UserName;//Lấy lại sau
            //Lấy nội dung xử lý
            string Content = txtContent.Text;
            //Upload File
            DateTime CurrentTime = DateTime.Now;
            string day = CurrentTime.Day.ToString();
            string month = CurrentTime.Month.ToString();
            string year = CurrentTime.Year.ToString();
            string hour = CurrentTime.Hour.ToString();
            string minute = CurrentTime.Minute.ToString();
            string millisecond = CurrentTime.Millisecond.ToString();
            string str = "-" + day + "-" + month + "-" + year + "-" + "-" + hour + "-" + minute + "-" + millisecond;
            //Lấy danh sách file đính kèm
            BAttach Bobj = new BAttach();
            HttpFileCollection hfc = Request.Files;
            int n = hfc.Count;
            string listFile = ",";
            if (n > 0)
            {

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
            }

            //////////////////////////////////////////////
            //Tạo Comment mới
            BComment BobjComment = new BComment();
            OComment objComment = new OComment();
            objComment.CommentID = WorkID.ToString() + "" + CurrentTime.ToString();
            objComment.Title = "Xử lý công việc: " + BobjWork.GetWork(WorkID).First().Name;
            objComment.Content = Content;
            objComment.IDUserCreate = IDUserCreate;
            objComment.IDDocument = "";
            objComment.IDWork = WorkID;
            objComment.Attachs = listFile;
            objComment.CreateDate = CurrentTime;

            BobjComment.Add(objComment);
            Page.Response.Redirect(HttpContext.Current.Request.Url.ToString(), true);
        }

        protected void btnCapNhat_Click(object sender, EventArgs e)
        {
            
            BWork BobjWork = new BWork();
            string Status = string.Empty;
            if(rdoTiepTuc.Checked)
            {
                Status = "DANG_THUC_HIEN";
            }
            if(rdoTamDung.Checked)
            {
                Status = "DUNG_XU_LY";
            }
            if (rdoHoanThanh.Checked)
            {
                Status = "CONG_VIEC_DA_XU_LY";
            }
            int WorkID = int.Parse(Request.QueryString["WorkID"].ToString());
            int IDUserCreate = BobjWork.Get(WorkID).First().IDUserCreate;//Lấy sau
            
            BobjWork.Update(WorkID, Status, IDUserCreate);
        }
    }
}
