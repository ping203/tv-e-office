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

    public partial class DocumentDetailsPublished : System.Web.UI.Page
    {
        #region "Property"
        /// <summary>
        /// Lưu mã  văn bản
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
                if (ctl.Get(DocumentId, int.Parse(EOFFICE.Common.DocumentType.DocumentDrap.ToString("D"))) != null)
                {
                    ODocument obj = ctl.Get(DocumentId, int.Parse(EOFFICE.Common.DocumentType.DocumentDrap.ToString("D")))[0];
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
                        lblAttach.Text = obj.Attachs;
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
                    obj = ctl.Get(DocumentId, int.Parse(EOFFICE.Common.DocumentType.DocumentDrap.ToString("D")))[0];
                    if (obj != null)
                    {
                        ctl.UpdatePublish(DocumentId, "", EOFFICE.Common.DocumentStatus.Published.ToString("D"),DateTime.Now.ToString("MM/dd/yyyy"));
                        Response.Redirect("/Document/DocumentProcessProcessed.aspx");
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
        /// Quay về trang quản trị văn bản
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lnkReturn_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Document/DocumentProcessProcessed.aspx");
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
                    obj = ctl.Get(DocumentId, int.Parse(EOFFICE.Common.DocumentType.DocumentDrap.ToString("D")))[0];
                    if (obj != null)
                    {
                        string listFile = ",";

                        try
                        {
                            obj = ctl.Get(DocumentId, int.Parse(EOFFICE.Common.DocumentType.DocumentDrap.ToString("D")))[0];

                            
                            if (obj != null)
                            {
                                ctl.UpdatePublish(DocumentId, "", EOFFICE.Common.DocumentStatus.Published.ToString("D"), DateTime.Now.ToString("MM/dd/yyyy"));
                                Response.Redirect("/Document/DocumentProcess.aspx");
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
                        obj = ctl.Get(DocumentId, int.Parse(EOFFICE.Common.DocumentType.DocumentDrap.ToString("D")))[0];


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
