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
using System.Web.UI.MobileControls;
using Telerik.Web.UI;
using System.Collections.Generic;

namespace EOFFICE.Works
{
    public partial class WorkReceivedDetail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Infomation_Load();
                BindDepartment();
                
            }
        }

        public void BindDepartment()
        {
            BDepartment BobjDepartment = new BDepartment();
            rptDepartment.DataSource = BobjDepartment.Get(0);
            rptDepartment.DataBind();
        }
        
        protected void Infomation_Load()
        {
            int WorkID = int.Parse(Request.QueryString["WorkID"].ToString());

            BWork Bobj = new BWork();
            OWork obj = new OWork();
            obj = Bobj.GetWork(WorkID).First();
            BUser BobjUser = new BUser();
            OUser objUser = BobjUser.Get(int.Parse(obj.IDUserCreate.ToString())).First();
            lblName.Text = obj.Name;
            lblNgayTao.Text = obj.CreateDate.ToString("dd/MM/yyyy");
            lblNgayBatDau.Text = obj.StartProcess.ToString("dd/MM/yyyy");
            lblNgayKetThuc.Text = obj.EndProcess.ToString("dd/MM/yyyy");
            lblYeuCau.Text = obj.Description;
            lblUserCreate.Text = objUser.FullName;
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
            
            //Load ListUserProcess
            rptListUser.DataSource = Bobj.GetUserProcess(WorkID);
            rptListUser.DataBind();

            hdfUserJoin.Value = Bobj.GetWork(WorkID).First().IDUserProcess;
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
        }

        protected void btnCapNhat_Click(object sender, EventArgs e)
        {
            BWork BobjWork = new BWork();
            //Lấy IDWWork
            int WorkID = int.Parse(Request.QueryString["WorkID"].ToString());
            //Lấy IDUserCreate
            string IDUserCreate=Global.UserInfo.UserName;//Lấy lại sau
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
            //Lấy danh sách người chuyển tiếp
            string UserJoin = hdfUsers.Value;            
            if (UserJoin == ",")
            {
                UserJoin = "";
            }
            
            //////////////////////////////////////////////
            //Tạo Comment mới
            BComment BobjComment = new BComment();
            OComment objComment = new OComment();
            objComment.CommentID = WorkID.ToString() + "" +CurrentTime.ToString();
            objComment.Title = "Xử lý công việc: "+BobjWork.GetWork(WorkID).First().Name;
            objComment.Content = Content;
            objComment.IDUserCreate = IDUserCreate;
            objComment.IDDocument = "";
            objComment.IDWork = WorkID;
            objComment.Attachs = listFile;
            objComment.CreateDate = CurrentTime;
            
            BobjComment.Add(objComment);                     

                //Thêm danh sách người chuyển tiếp nếu có chuyển tiếp

                if (UserJoin != "")
                {
                    OWork objWork = new OWork();
                    objWork = BobjWork.GetWork(WorkID).First();
                    //Xử lý người chuyển tiếp trùng lặp
                    string CurrentList = objWork.IDUserProcess;

                    string[] divUser = UserJoin.Split(',');
                    
                    for (int i = 0; i < divUser.Count(); i++)
                    {
                        divUser[i] = ","+divUser[i]+",";
                        CurrentList=CurrentList.Replace(divUser[i], ",");
                    }
                    string newlistUserProcess = CurrentList + UserJoin;
                    BobjWork.UpdateUserProcess(WorkID, newlistUserProcess,objWork.IDUserCreate);//Lấy IDUserCreate sau
                }

                Page.Response.Redirect(HttpContext.Current.Request.Url.ToString(), true);
               
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
                    rptComment.DataSource = BobjComment.GetCreate(hdfID.Value, WorkID);
                    rptComment.DataBind();
                    
                    rptFileAttachs.DataSource = BobjComment.GetAttachs(objComment.CommentID);
                    rptFileAttachs.DataBind();
                }
            }
        }

        protected string BindTime(string CommentID)
        {
            BComment Bcomment = new BComment();
            string CreateDate = Bcomment.Get(CommentID).First().CreateDate.ToString("dd/MM/yyyy hh:mm:ss");
            return CreateDate;
        }

        protected void rptFileAttachs_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
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
        }        

        protected void rptDepartment_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            BUser BobjUser = new BUser();
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                CheckBoxList cblUser = (CheckBoxList)e.Item.FindControl("cblUser");
                HiddenField hdfID = (HiddenField)e.Item.FindControl("hdfID");
                cblUser.DataSource = BobjUser.GetByDepartment(int.Parse(hdfID.Value));
                cblUser.DataBind();
            }
        }
        
    }
}
