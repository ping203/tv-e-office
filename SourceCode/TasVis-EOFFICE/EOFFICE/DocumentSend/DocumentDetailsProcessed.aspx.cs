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

    public partial class SendDocumentDetailsProcessed : System.Web.UI.Page
    {
        #region "Property"
        /// <summary>
        /// Lưu mã  Công văn đi
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
            //BUser ctlUP = new BUser();
            ////-- Kiểm tra quyền dự thảo
            //if (ctlUP.HasPermission(Global.UserInfo.UserID, Common.PermissionCode.DocumentDrap.ToString()))
            //    Response.Redirect("/");
            BUser ctlUP = new BUser();
            //-- Kiểm tra quyền dự thảo
            if (!ctlUP.HasPermission(Global.UserInfo.UserID, Common.PermissionCode.DocumentDrap.ToString()) && !Global.IsAdmin())
                Response.Redirect("/permission-fail.aspx");

            if (DocumentId != "")
            {
                BDocument ctl = new BDocument();
                if (ctl.Get(DocumentId, int.Parse(EOFFICE.Common.DocumentType.DocumentSend.ToString("D"))) != null)
                {
                    ODocument obj = ctl.Get(DocumentId, int.Parse(EOFFICE.Common.DocumentType.DocumentSend.ToString("D")))[0];
                    if (obj != null)
                    {
                        lblName.Text = obj.Name;
                        lblSubContent.Text = obj.Excerpt;
                        lblUserDrap.Text = obj.IDUserCreate.ToString();
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
                    obj = ctl.Get(DocumentId, int.Parse(EOFFICE.Common.DocumentType.DocumentSend.ToString("D")))[0];
                    if (obj != null)
                    {
                        ctl.UpdatePublish(DocumentId, "", EOFFICE.Common.DocumentStatus.Published.ToString("D"),DateTime.Now.ToString("MM/dd/yyyy"));
                        Response.Redirect("/DocumentSend/DocumentProcess.aspx");
                    }
                }
                catch (Exception ex) { }
            }
            else
            {
   
            }

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
        /// Quay về trang quản trị Công văn đi
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lnkReturn_Click(object sender, EventArgs e)
        {
            Response.Redirect("/DocumentSend/DocumentProcess.aspx");
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
                    obj = ctl.Get(DocumentId, int.Parse(EOFFICE.Common.DocumentType.DocumentSend.ToString("D")))[0];
                    if (obj != null)
                    {
                        string listFile = ",";

                        try
                        {
                            obj = ctl.Get(DocumentId, int.Parse(EOFFICE.Common.DocumentType.DocumentSend.ToString("D")))[0];

                            
                            if (obj != null)
                            {
                                ctl.UpdatePublish(DocumentId, "", EOFFICE.Common.DocumentStatus.Published.ToString("D"), DateTime.Now.ToString("MM/dd/yyyy"));
                                Response.Redirect("/DocumentSend/DocumentProcess.aspx");
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

        }

        /// <summary>
        /// Xoa file tren server
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void cmdDeleteFile_Click(object sender, EventArgs e)
        {
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
                OAttach objAttach = new OAttach();
                BAttach BobjAttach = new BAttach();
                BDocument Bdocument = new BDocument();
                ODocument obj = Bdocument.Get(DocumentId, int.Parse(EOFFICE.Common.DocumentType.DocumentSend.ToString("D"))).First();
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
                        obj = ctl.Get(DocumentId, int.Parse(EOFFICE.Common.DocumentType.DocumentSend.ToString("D")))[0];


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
                  "attachment; filename=" + System.IO.Path.GetFileName(Server.MapPath("DocumentFiles/" + usn + "/" + lblAttach.Text)));
                HttpContext.Current.Response.Clear();
                HttpContext.Current.Response.WriteFile(Server.MapPath("DocumentFiles/" + usn + "/" + lblAttach.Text));
                HttpContext.Current.Response.End();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }




    }
}
