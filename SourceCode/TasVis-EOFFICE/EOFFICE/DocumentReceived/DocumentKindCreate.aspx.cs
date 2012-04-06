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
using DataAccess.DataObject;
using DataAccess.BusinessObject;

namespace EOFFICE
{
    public partial class ReceivedDocumentKindCreate : System.Web.UI.Page
    {
        #region "Propertys"
        /// <summary>
        /// Trang hiện tại
        /// </summary>
        public int CurrentPage
        {

            get
            {
                if (Request.QueryString["currentpage"] != null)
                {
                    try
                    {

                        return int.Parse(Request.QueryString["currentpage"]);
                    }
                    catch (Exception ex)
                    {
                        return 1;
                    }
                }
                else
                {
                    return 1;
                }
            }
        }
        #endregion

        #region "Common Function"
        private void BindParent()
        {
            BDocumentKind ctl = new BDocumentKind();
            ddlParent.DataSource = ctl.Get(0);
            ddlParent.DataBind();
            ddlParent.Items.Insert(0, new ListItem("Không có cha", ""));
        }
        /// <summary>
        /// Load danh sách chuyên mục
        /// </summary>
        private void BindData()
        {
            //-- Kiểm tra quyền dự thảo
            if (!Global.IsAdmin())
                Response.Redirect("/");
            BDocumentKind ctl = new BDocumentKind();
            grvDocumentKind.DataSource = ctl.Get(0);
            grvDocumentKind.DataBind();
        }

        /// <summary>
        /// Lấy về tên lại công văn
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string GetName(object  id)
        {
            BDocumentKind ctl = new BDocumentKind();
            try{
                return ctl.Get(int.Parse(id.ToString()))[0].Name;
            }catch(Exception ex)
            {
                return "";
            }
           
        }
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BindData();
                BindParent();
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            BDocumentKind ctl = new BDocumentKind();
            if (!string.IsNullOrEmpty(txtName.Text))
            {
                ODocumentKind obj = new ODocumentKind();
                obj.Name = txtName.Text;
                obj.Description = txtDescription.Text;
                try {
                    obj.DocumentKindParent = int.Parse(ddlParent.SelectedValue);
                }
                catch (Exception ea)
                { obj.DocumentKindParent = 0; }
                if (hdfId.Value != "")
                {
                    obj.DocumentKindID = int.Parse(hdfId.Value);
                    ctl.Update(obj.DocumentKindID, obj.Name, obj.Description, obj.DocumentKindParent);
                    hdfId.Value = ""; 
                }
                else
                {
                    ctl.Add(obj);
                }
                txtName.Text = "";
                txtDescription.Text = "";
                BindData();
            }
        }
        /// <summary>
        /// Các thao tác trên danh sách
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void grvDocumentKind_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("cmdEdit", StringComparison.OrdinalIgnoreCase))
            {
                BDocumentKind ctl = new BDocumentKind();
                ODocumentKind obj = ctl.Get(int.Parse(e.CommandArgument.ToString())).First();
                if (obj != null)
                {
                    txtDescription.Text = obj.Description;
                    txtName.Text = obj.Name;
                    hdfId.Value = obj.DocumentKindID.ToString();
                    try {
                        ddlParent.Items.FindByValue(obj.DocumentKindParent.ToString()).Selected = true;
                    }
                    catch (Exception ex) { }
                }
                //ctl.Delete(int.Parse(e.CommandArgument.ToString()));
               
            }
            else if (e.CommandName.Equals("cmdDelete", StringComparison.OrdinalIgnoreCase))
            {
                BDocumentKind ctl = new BDocumentKind();
                if(ctl.Delete(int.Parse(e.CommandArgument.ToString())))
                    BindData();
                else
                    RegisterClientScriptBlock("Notification", "<script language='javascript'>alert('Đã tồn tại Công văn đến trong loại này!');</script>");
                
            }

        }




    }
}
