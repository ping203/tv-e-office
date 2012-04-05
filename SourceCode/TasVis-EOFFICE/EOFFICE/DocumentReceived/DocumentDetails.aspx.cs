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
using DataAccess.Common;
using DataAccess.BusinessObject;
using DataAccess.DataObject;
using System.IO;
using System.Collections.Generic;

namespace EOFFICE
{

    public partial class ReceivedDocumentDetails : System.Web.UI.Page
    {
        #region "Property"
        /// <summary>
        /// Lưu mã  Công văn đến
        /// </summary>
        public string DocumentId
        {
            get
            {
                if (Request.QueryString["DocumentId"] != null)
                {
                    return Request.QueryString["DocumentId"];
                }
                else
                {
                    return "";
                }
            }
        }
        #endregion
        #region "Common Function"
        private void InitData()
        {
            if (DocumentId != "")
            {
                BDocument ctl = new BDocument();
                if (ctl.Get(DocumentId, int.Parse(EOFFICE.Common.DocumentType.DocumentReceived.ToString("D"))) != null)
                {
                    ODocument obj = ctl.Get(DocumentId, int.Parse(EOFFICE.Common.DocumentType.DocumentReceived.ToString("D")))[0];
                    if (obj != null)
                    {
                        lblName.Text = obj.Name;
                        lblSubContent.Text = obj.Excerpt;
                        lblUserDrap.Text = obj.IDUserCreate.ToString();
                        try
                        {
                            lblUserDrap.Text = (new BUser()).Get(obj.IDUserCreate).First().UserName;
                        }
                        catch (Exception ex)
                        {

                        }
                        //lblAttach.Text = obj.Attachs;
                        
                        BComment BobjComment = new BComment();
                        rptComment.DataSource= BobjComment.Get("", DocumentId,0);
                        rptComment.DataBind();
                        List<OAttach> listAttach = new List<OAttach>();
                        foreach (OComment objI in BobjComment.Get("", DocumentId, 0))
                        {
                            listAttach = listAttach.Union(BobjComment.GetAttachs(objI.CommentID)).ToList();
                        }
                        rptFileAttachs.DataSource = listAttach;
                        rptFileAttachs.DataBind();

                        rptFiles.DataSource = (new BAttach()).GetAttachs(obj.Attachs);
                        rptFiles.DataBind();
                    }
                }
            }
        }


        #endregion

        #region "Events"

        /// <summary>
        /// Sự kiện
        /// Load data
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                InitData();
            }

        }
        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lnkSave_Click(object sender, EventArgs e)
        {
            ODocument obj;
            BDocument ctl = new BDocument();
            if (DocumentId != "")
            {
                string listFile = ",";

                try
                {
                    obj = ctl.Get(DocumentId, int.Parse(EOFFICE.Common.DocumentType.DocumentReceived.ToString("D")))[0];

                    try {
                        if (FileUpload1.PostedFile == null)
                            return;
                        if (!Directory.Exists(Server.MapPath("DocumentFiles")))
                        {
                            Directory.CreateDirectory(Server.MapPath("DocumentFiles"));
                        }
                        if (!Directory.Exists(Server.MapPath("DocumentFiles/" + Global.UserInfo.UserName)))
                        {
                            Directory.CreateDirectory(Server.MapPath("DocumentFiles/" + Global.UserInfo.UserName));
                        }

                        BAttach Bobj = new BAttach();
                        HttpFileCollection hfc = Request.Files;
                        int n = hfc.Count;
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
                                        hpf.SaveAs(Server.MapPath("DocumentFiles/" + Global.UserInfo.UserName) + "/" + hpf.FileName);
                                        OAttach objA = new OAttach();
                                        objA.Name = System.IO.Path.GetFileName(hpf.FileName);
                                        objA.Path = Server.MapPath("DocumentFiles/" + Global.UserInfo.UserName) + "/" + hpf.FileName;
                                        objA.Description = "";
                                        Bobj.Add(objA);
                                        listFile += Bobj.GetLast().FirstOrDefault().AttachID.ToString() + ",";
                                    }
                                }
                            }
                            catch (Exception ex)
                            {

                            }
                        }
                        //FileUpload1.SaveAs(Server.MapPath("DocumentFiles/" + Global.UserInfo.UserName + "/" + FileUpload1.FileName));
                    }
                    catch (Exception ex)
                    { }
                    if (obj != null)
                    {
                        //Tạo Comment mới
                        BComment BobjComment = new BComment();
                        OComment objComment = new OComment();
                        objComment.CommentID = DocumentId+DateTime.Now.ToString("dd_MM_yyyy_hh_mm_ss");
                        objComment.Title = "Xử lý Công văn đến: " + lblName.Text;
                        objComment.Content = txtContent.Text;
                        objComment.IDUserCreate = Global.UserInfo.UserName;
                        objComment.IDDocument = DocumentId;
                        objComment.IDWork = 0;
                        objComment.Attachs =listFile;
                        objComment.CreateDate = DateTime.Now;
                        BobjComment.Add(objComment);
                        ctl.Update(DocumentId, "", EOFFICE.Common.DocumentStatus.Processed.ToString("D"));
                    }
                }
                catch (Exception ex) { }
            }
            else
            {
   
            }
            Response.Redirect("/DocumentSend/DocumentProcess.aspx");
        }

        /// <summary>
        /// Tìm kiếm usẻ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSearchUserProcess_Click(object sender, EventArgs e)
        {
           
        }
        /// <summary>
        /// Download file
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        protected void rptFileAttachs_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Download")
            {
                try
                {
                    HttpContext.Current.Response.ContentType =
                                "application/octet-stream";
                    HttpContext.Current.Response.AddHeader("Content-Disposition",
                      "attachment; filename=" + System.IO.Path.GetFileName(e.CommandArgument.ToString()));
                    HttpContext.Current.Response.Clear();
                    HttpContext.Current.Response.WriteFile(e.CommandArgument.ToString());
                    HttpContext.Current.Response.End();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
        /// <summary>
        /// Chọn phòng ban
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ddlDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        /// <summary>
        /// Chọn User
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lnkAddUserProcess_Click(object sender, EventArgs e)
        {
           
          
        }

        protected void cmdDeleteUser_Click(object sender, EventArgs e)
        {
            
        }

        /// <summary>
        /// Quay về trang quản trị Công văn đến
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lnkReturn_Click(object sender, EventArgs e)
        {
            Response.Redirect("/DocumentSend/Default.aspx");
            
            
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
                      "attachment; filename=" + System.IO.Path.GetFileName(e.CommandArgument.ToString()));
                    HttpContext.Current.Response.Clear();
                    HttpContext.Current.Response.WriteFile(e.CommandArgument.ToString());
                    HttpContext.Current.Response.End();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            if (e.CommandName == "Delete")
            {
                OAttach objAttach = new OAttach();
                BAttach BobjAttach = new BAttach();
                BDocument Bdocument = new BDocument();
                ODocument obj = Bdocument.Get(DocumentId, int.Parse(EOFFICE.Common.DocumentType.DocumentReceived.ToString("D"))).First();
                //int IDUserCreate = int.Parse(objWork.IDUserCreate.ToString());
                string listAttach = obj.Attachs.ToString();
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
                        obj.Attachs = newListAttach;
                        Bdocument.Update(obj.DocumentID, "", obj.Name, obj.Excerpt, obj.Content, "", obj.PublishOffical, obj.Attachs, obj.IDDocumentKind, "", obj.UserProcess, "", obj.StartProcess.ToString("MM/dd/yyyy"), obj.EndProcess.ToString("MM/dd/yyyy"), DateTime.Now.ToString("MM/dd/yyyy"), "", obj.SendOfficals, obj.Priority, obj.Status);
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


        /// <summary>
        /// Updaload file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void cmđUpload_Click(object sender, EventArgs e)
        {
            
        }

        /// <summary>
        /// Gửi bản thảo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lnkSendDrap_Click(object sender, EventArgs e)
        {
            ODocument obj;
            BDocument ctl = new BDocument();
            if (DocumentId != "")
            {
                try
                {
                    obj = ctl.Get(DocumentId, int.Parse(EOFFICE.Common.DocumentType.DocumentReceived.ToString("D")))[0];


                    if (obj != null)
                    {

                        string listFile = ",";

                        try
                        {
                            obj = ctl.Get(DocumentId, int.Parse(EOFFICE.Common.DocumentType.DocumentReceived.ToString("D")))[0];

                            try
                            {
                                if (FileUpload1.PostedFile == null)
                                    return;
                                if (!Directory.Exists(Server.MapPath("DocumentFiles")))
                                {
                                    Directory.CreateDirectory(Server.MapPath("DocumentFiles"));
                                }
                                if (!Directory.Exists(Server.MapPath("DocumentFiles/" + Global.UserInfo.UserName)))
                                {
                                    Directory.CreateDirectory(Server.MapPath("DocumentFiles/" + Global.UserInfo.UserName));
                                }

                                BAttach Bobj = new BAttach();
                                HttpFileCollection hfc = Request.Files;
                                int n = hfc.Count;
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
                                                hpf.SaveAs(Server.MapPath("DocumentFiles/" + Global.UserInfo.UserName) + "/" + hpf.FileName);
                                                OAttach objA = new OAttach();
                                                objA.Name = System.IO.Path.GetFileName(hpf.FileName);
                                                objA.Path = Server.MapPath("DocumentFiles/" + Global.UserInfo.UserName) + "/" + hpf.FileName;
                                                objA.Description = "";
                                                Bobj.Add(objA);
                                                listFile += Bobj.GetLast().FirstOrDefault().AttachID.ToString() + ",";
                                            }
                                        }
                                    }
                                    catch (Exception ex)
                                    {

                                    }
                                }
                                //FileUpload1.SaveAs(Server.MapPath("DocumentFiles/" + Global.UserInfo.UserName + "/" + FileUpload1.FileName));
                            }
                            catch (Exception ex)
                            { }
                            if (obj != null)
                            {
                                //Tạo Comment mới
                                BComment BobjComment = new BComment();
                                OComment objComment = new OComment();
                                objComment.CommentID = DocumentId + DateTime.Now.ToString("dd_MM_yyyy_hh_mm_ss");
                                objComment.Title = "Xử lý Công văn đến: " + lblName.Text;
                                objComment.Content = txtContent.Text;
                                objComment.IDUserCreate = Global.UserInfo.UserName;
                                objComment.IDDocument = DocumentId;
                                objComment.IDWork = 0;
                                objComment.Attachs = listFile;
                                objComment.CreateDate = DateTime.Now;
                                BobjComment.Add(objComment);
                                ctl.Update(DocumentId,"", DateTime.Now.ToString(""), EOFFICE.Common.DocumentStatus.SendAgain.ToString("D"));
                            }
                        }
                        catch (Exception ex) { }
                    }
                }
                catch (Exception ex) { }
            }
            else
            {
            }
            Response.Redirect("/DocumentSend/DocumentProcess.aspx");
        }

        /// <summary>
        /// Xoa file tren server
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void cmdDeleteFile_Click(object sender, EventArgs e)
        {
        }

        protected void cmdDownAttachs_Click(object sender, EventArgs e)
        {
            try
            {
                string usn = "";
                ODocument obj;
                BDocument ctl = new BDocument();
                if (DocumentId != "")
                {
                    try
                    {
                        obj = ctl.Get(DocumentId, int.Parse(EOFFICE.Common.DocumentType.DocumentReceived.ToString("D")))[0];


                        if (obj != null)
                        {
                            BUser ctlU = new BUser();
                            OUser objU = ctlU.Get(obj.IDUserCreate)[0];
                            if (objU != null)
                                usn = objU.UserName;
                        }
                    }
                    catch (Exception ex) { }
                }
                else
                {

                }
                HttpContext.Current.Response.ContentType =
                            "application/octet-stream";
                HttpContext.Current.Response.AddHeader("Content-Disposition",
                  "attachment; filename=" + System.IO.Path.GetFileName("DocumentFiles/" + usn + "/" + lblAttach.Text));
                HttpContext.Current.Response.Clear();
                HttpContext.Current.Response.WriteFile("DocumentFiles/" + usn + "/" + lblAttach.Text);
                HttpContext.Current.Response.End();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }




    }
}
