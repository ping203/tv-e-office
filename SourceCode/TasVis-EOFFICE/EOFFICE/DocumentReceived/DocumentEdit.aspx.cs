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

namespace EOFFICE
{

    public partial class ReceivedDocumentEdit : System.Web.UI.Page
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
                    ODocument obj = ctl.Get(DocumentId,int.Parse(EOFFICE.Common.DocumentType.DocumentReceived.ToString("D")))[0];
                    if (obj != null)
                    {
                        txtName.Text = obj.Name;
                        txtContent.Text = obj.Content;
                        txtEndDate.Text = obj.EndProcess.ToString("dd/MM/yyyy");
                        txtStartDate.Text = obj.StartProcess.ToString("dd/MM/yyyy");
                        txtSubContent.Text = obj.Excerpt;
                        //lblLink.Text = obj.Attachs;
                        try { ddlLevel.Items.FindByValue(obj.Priority).Selected = true; }
                        catch (Exception ex) { }
                        try { ddlOffical.Items.FindByValue(obj.PublishOffical.ToString()).Selected = true; }
                        catch (Exception ex) { }
                        try { ddlType.Items.FindByValue(obj.IDDocumentKind.ToString()).Selected = true; }
                        catch (Exception ex) { }
                        BindUserProcess(obj.UserProcess);

                        rptFiles.DataSource = (new BAttach()).GetAttachs(obj.Attachs);
                        rptFiles.DataBind();

                        if (obj.Attachs == "" || obj.Attachs == ",")
                        {
                            lblThongBao.Text = "Không có file đính kèm!";
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Load danh sahcs nguoi xu ly
        /// </summary>
        /// <param name="str"></param>
        private void BindUserProcess(string str)
        {
            BUser ctl = new BUser();
            foreach (string i in str.Split(','))
            {
                try
                {
                    OUser obj = ctl.Get(int.Parse(i))[0];
                    if (obj != null)
                    {
                        lsbUserProcess.Items.Add(new ListItem(obj.FullName, obj.UserID.ToString()));
                    }
                }
                catch (Exception ex) { }
            }
        }

        /// <summary>
        /// Load ra danh sách loại tài liệu
        /// </summary>
        private void BindDocumentType()
        {
            BDocumentKind ctl = new BDocumentKind();
            ddlType.ClearSelection();
            ddlType.DataSource = ctl.Get(0);
            ddlType.DataBind();
            //ddlType.Items.Insert(0, new ListItem("Tất cả", ""));
        }

        /// <summary>
        /// Load ra danh sách văn phòng
        /// </summary>
        private void BindOffical()
        {
            BOffical ctl = new BOffical();
            ddlOffical.ClearSelection();
            ddlOffical.DataSource = ctl.Get(0);
            ddlOffical.DataBind();
            //ddlOffical.Items.Insert(0, new ListItem("Tất cả", ""));
        }


        /// <summary>
        /// Load danh sách phòng ban
        /// </summary>
        private void BindDepartment()
        {
            ddlDepartment.Items.Clear();
            BDepartment ctl = new BDepartment();
            ddlDepartment.DataSource = ctl.Get(0);
            ddlDepartment.DataBind();
            ddlDepartment.Items.Insert(0, new ListItem("Tất cả", "0"));
        }

        /// <summary>
        /// Lấy về danh sách các người sử lý
        /// </summary>
        /// <returns></returns>
        private string GetUserProcess()
        {
            string str = "";
            for (int i = 0; i < lsbUserProcess.Items.Count; i++)
            {
                if (str == "")
                    str = str + lsbUserProcess.Items[i].Value;
                else
                    str = str + "," + lsbUserProcess.Items[i].Value;
            }
            return str;
        }

        /// <summary>
        /// Bind dannh sách  Công văn đến
        /// </summary>
        private void BindDataUser()
        {
            BUser ctl = new BUser();
            string _fullname = "";
            string _username = "";
            string _email = "";
            string _status = UserStatus.Approve.ToString("D");
            int _departmentid = int.Parse(ddlDepartment.SelectedValue);
            //--Set key tìm kiếm
            if (txtKeySearch.Text.Trim().Length > 0)
            {
                _username = txtKeySearch.Text.Trim();
                _fullname = txtKeySearch.Text.Trim();
                _email = txtKeySearch.Text.Trim();
            }

            int count = ctl.GetCount(_fullname, _username, _email, _departmentid, _status, "", "");
            if (count > 0)
            {
                lbsUserSearch.Visible = true;
                lbsUserSearch.DataSource = ctl.Get(_fullname, _username, _email, _departmentid, _status, "DESC", "UserId", 1, 100);
                lbsUserSearch.DataBind();
            }
            else
            {
                lbsUserSearch.Visible = false;
            }
        }

        /// <summary>
        /// Upload file
        /// </summary>
        /// <returns></returns>
        private string Upload()
        {
            string listFile = ",";
            try
            {
                if (fuDrap.PostedFile == null)
                    return "";
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
            return listFile;
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
                if (!Global.IsAdmin())
                    lnkAddCategory.Visible = false;
                else
                    lnkAddCategory.Visible = true;
                BindDocumentType();
                BindOffical();
                BindDepartment();
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
                try
                {
                    obj = ctl.Get(DocumentId, int.Parse(EOFFICE.Common.DocumentType.DocumentReceived.ToString("D")))[0];


                    if (obj != null)
                    {
                        obj.Content = txtContent.Text;
                        //obj.CreateDate = DateTime.Now;
                        obj.SendDate = DateTime.Now;
                        obj.ReceiveDate = DateTime.Now;
                        obj.PublishDate = DateTime.Now;
                        obj.StartProcess = DateTime.ParseExact(txtStartDate.Text, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                        obj.EndProcess = DateTime.ParseExact(txtEndDate.Text, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                        //obj.IDUserCreate = Global.UserInfo.UserID;
                        obj.Name = txtName.Text;
                        string strFile = Upload();
                        string Attachs = obj.Attachs;
                        if (strFile != ",")
                        {
                            Attachs = Attachs.Remove(Attachs.Length - 1, 1) + strFile;
                        }
                        obj.Attachs = Attachs;
                        obj.Priority = ddlLevel.SelectedValue;
                        obj.PublishOffical = int.Parse(ddlOffical.SelectedValue);
                        obj.UserProcess = GetUserProcess();
                        obj.IDDocumentKind = int.Parse(ddlType.SelectedValue);
                        obj.Excerpt = txtSubContent.Text;
                        obj.Status = EOFFICE.Common.DocumentStatus.SaveDrap.ToString("D");
                        ctl.Update(obj.DocumentID, "", obj.Name, obj.Excerpt, obj.Content, "", obj.PublishOffical, obj.Attachs, obj.IDDocumentKind, "", obj.UserProcess, "", obj.StartProcess.ToString("MM/dd/yyyy"), obj.EndProcess.ToString("MM/dd/yyyy"), "", "", obj.SendOfficals, obj.Priority, obj.Status);
                        Response.Redirect("/DocumentSend/Default.aspx");
                    }
                }
                catch (Exception ex) { }
            }
            else
            {
                obj = new ODocument();
                obj.Content = txtContent.Text;
                obj.CreateDate = DateTime.Now;
                obj.SendDate = DateTime.Now;
                obj.ReceiveDate = DateTime.Now;
                obj.PublishDate = DateTime.Now;
                obj.StartProcess = DateTime.ParseExact(txtStartDate.Text, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                obj.EndProcess = DateTime.ParseExact(txtEndDate.Text, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                obj.IDUserCreate = Global.UserInfo.UserID;
                obj.Name = txtName.Text;
                obj.Priority = ddlLevel.SelectedValue;
                obj.Attachs = Upload();
                obj.PublishOffical = int.Parse(ddlOffical.SelectedValue);
                obj.UserProcess = GetUserProcess();
                obj.IDDocumentKind = int.Parse(ddlType.SelectedValue);
                obj.Excerpt = txtSubContent.Text;
                obj.Status = EOFFICE.Common.DocumentStatus.SaveDrap.ToString("D");
                obj.Type = int.Parse( EOFFICE.Common.DocumentType.DocumentReceived.ToString("D"));
                ctl.Add(obj);
                Response.Redirect("/DocumentSend/Default.aspx");
            }

        }

        /// <summary>
        /// Tìm kiếm usẻ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSearchUserProcess_Click(object sender, EventArgs e)
        {
            BindDataUser();
        }

        /// <summary>
        /// Chọn phòng ban
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ddlDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindDataUser();
        }

        /// <summary>
        /// Chọn User
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lnkAddUserProcess_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < lbsUserSearch.Items.Count; i++)
            {
                if (lbsUserSearch.Items[i].Selected == true)
                {
                    if (lsbUserProcess.Items.FindByValue(lbsUserSearch.Items[i].Value) == null)
                    {
                        lsbUserProcess.Items.Add(lbsUserSearch.Items[i]);
                    }

                }
            }
        }

        protected void cmdDeleteUser_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < lsbUserProcess.Items.Count; i++)
            {
                if (lsbUserProcess.Items[i].Selected == true)
                {
                    lsbUserProcess.Items.RemoveAt(i);
                }
            }
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

        /// <summary>
        /// Updaload file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void cmđUpload_Click(object sender, EventArgs e)
        {
            if (fuDrap.PostedFile == null)
                return;
            if (!Directory.Exists(Server.MapPath("DocumentFiles")))
            {
                Directory.CreateDirectory(Server.MapPath("DocumentFiles"));
            }
            if (!Directory.Exists(Server.MapPath("DocumentFiles/" + Global.UserInfo.UserName)))
            {
                Directory.CreateDirectory(Server.MapPath("DocumentFiles/" + Global.UserInfo.UserName));
            }
            fuDrap.SaveAs(Server.MapPath("DocumentFiles/" + Global.UserInfo.UserName + "/" + fuDrap.FileName));
            lblLink.Text =fuDrap.FileName;
            cmdDeleteFile.Visible = true;
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
                        obj.Content = txtContent.Text;
                        //obj.CreateDate = DateTime.Now;
                        obj.SendDate = DateTime.Now;
                        obj.ReceiveDate = DateTime.Now;
                        obj.PublishDate = DateTime.Now;
                        obj.StartProcess = DateTime.ParseExact(txtStartDate.Text, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                        obj.EndProcess = DateTime.ParseExact(txtEndDate.Text, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                        //obj.IDUserCreate = Global.UserInfo.UserID;
                        string strFile = Upload();
                        string Attachs = obj.Attachs;
                        if (strFile != ",")
                        {
                            Attachs = Attachs.Remove(Attachs.Length - 1, 1) + strFile;
                        }
                        obj.Attachs = Attachs;
                        obj.Name = txtName.Text;
                        obj.Priority = ddlLevel.SelectedValue;
                        obj.PublishOffical = int.Parse(ddlOffical.SelectedValue);
                        obj.UserProcess = GetUserProcess();
                        obj.IDDocumentKind = int.Parse(ddlType.SelectedValue );
                        obj.Excerpt = txtSubContent.Text;
                        obj.Status = EOFFICE.Common.DocumentStatus.SendDrap.ToString("D");
                        ctl.Update(obj.DocumentID, "", obj.Name, obj.Excerpt, obj.Content, "", obj.PublishOffical, obj.Attachs, obj.IDDocumentKind, "", obj.UserProcess, "", obj.StartProcess.ToString("MM/dd/yyyy"), obj.EndProcess.ToString("MM/dd/yyyy"), DateTime.Now.ToString("MM/dd/yyyy"), "", obj.SendOfficals, obj.Priority, obj.Status);
                        Response.Redirect("/DocumentSend/Default.aspx");
                    }
                }
                catch (Exception ex) { }
            }
            else
            {
                obj = new ODocument();
                obj.Content = txtContent.Text;
                obj.CreateDate = DateTime.Now;
                obj.SendDate = DateTime.Now;
                obj.ReceiveDate = DateTime.Now;
                obj.PublishDate = DateTime.Now;
                obj.StartProcess = DateTime.ParseExact(txtStartDate.Text, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                obj.EndProcess = DateTime.ParseExact(txtEndDate.Text, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                obj.IDUserCreate = Global.UserInfo.UserID;
                obj.Name = txtName.Text;
                obj.Priority = ddlLevel.SelectedValue;
                obj.PublishOffical = int.Parse(ddlOffical.SelectedValue);
                obj.UserProcess = GetUserProcess();
                obj.IDDocumentKind = int.Parse(ddlType.SelectedValue);
                obj.Excerpt = txtSubContent.Text;
                obj.Attachs = Upload();
                obj.Status = EOFFICE.Common.DocumentStatus.SendDrap.ToString("D");
                obj.Type = int.Parse( EOFFICE.Common.DocumentType.DocumentReceived.ToString("D"));
                ctl.Add(obj);
                Response.Redirect("/DocumentSend/Default.aspx");
            }

        }

        /// <summary>
        /// Xoa file tren server
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void cmdDeleteFile_Click(object sender, EventArgs e)
        {
            if (File.Exists(Server.MapPath("DocumentFiles/" + Global.UserInfo.UserName+"/"+lblLink.Text.Trim())))
            {
                File.Delete(Server.MapPath("DocumentFiles/" + Global.UserInfo.UserName + "/" + lblLink.Text.Trim()));
            }
            lblLink.Text = "";
        }




    }
}
