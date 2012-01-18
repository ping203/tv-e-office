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

namespace EOFFICE.Works
{
    public partial class WorkReceivedDetail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Infomation_Load();
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

            //Load CheckBoxListUser
            
            string username = string.Empty;

            cbxListUserProcess.DataSource = BobjUser.Get(username);
            cbxListUserProcess.DataBind();

            //CheckBoxBind.DataSource = BobjUser.Get(username);
            //CheckBoxBind.DataBind();

            rptUserProcess.DataSource = BobjUser.Get(username); ;
            rptUserProcess.DataBind();

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
            int IDUserCreate=1;
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
            int count = 0;//biến đếm số người được chuyển tiếp
            string ListUserProcess = ",";

            foreach (ListItem item in cbxListUserProcess.Items)

            //foreach (ListItem item in CheckBoxBind.Items)
            //{

            //    if (item.Selected)
            //    {
            //        count += 1;
            //        ListUserProcess += item.Value.ToString() + ",";
            //    }
            //}

            //for (int i = 0; i < CheckBoxBind.Items.Count; i++)
            //{
            //    if (CheckBoxBind.Items[i].Selected)
            //    {
            //        count += 1;
            //        ListUserProcess += CheckBoxBind.Items[i].Value.ToString() + ",";
            //    }
            //}
            for (int i = 0; i < rptUserProcess.Items.Count; i++)

            {
                CheckBox cb = (CheckBox)rptUserProcess.Items[i].FindControl("cbUser");
                if (cb.Checked == true)
                {
                    count += 1;
                    ListUserProcess += cb.Text.ToString() + ",";
                }
            }

            //////////////////////////////////////////////
            //Tạo Comment mới
            BComment BobjComment = new BComment();
            OComment objComment = new OComment();
            objComment.CommentID = WorkID.ToString() + "_" +CurrentTime.ToString();
            objComment.Title = "Xử lý công việc: "+BobjWork.GetWork(WorkID).First().Name;
            objComment.Content = Content;
            objComment.IDUserCreate = IDUserCreate;
            objComment.IDDocument = "";
            objComment.IDWork = WorkID;
            objComment.Attachs = listFile;
            objComment.CreateDate = CurrentTime;

            BobjComment.Add(objComment);

            
            //Thêm danh sách người chuyển tiếp nếu có chuyển tiếp
            if (count > 0)
            {
                OWork objWork = new OWork();
                objWork = BobjWork.GetWork(WorkID).First();
                string newlistUserProcess = objWork.IDUserProcess + ListUserProcess;
                BobjWork.UpdateUserProcess(WorkID, newlistUserProcess,1);
            }
        }
    }
}
