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
    public partial class DocumentOffical : System.Web.UI.Page
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
            BOffical ctl = new BOffical();
            ddlParent.DataSource = ctl.Get(0);
            ddlParent.DataBind();
            ddlParent.Items.Insert(0, new ListItem("Không có cha", ""));
        }
        /// <summary>
        /// Load danh sách chuyên mục
        /// </summary>
        private void BindData()
        {
            BOffical ctl = new BOffical();
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
            BOffical ctl = new BOffical();
            try{
                return ctl.Get(int.Parse(id.ToString()))[0].Name;
            }catch(Exception ex)
            {
                return "";
            }
           
        }

        /// <summary>
        /// Reset các form
        /// </summary>
        private void ResetForm()
        {
            txtAddress.Text = "";
            txtDescription.Text = "";
            txtEmail.Text = "";
            txtFax.Text = "";
            txtName.Text = "";
            txtTel.Text = "";
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
            BOffical ctl = new BOffical();
            if (!string.IsNullOrEmpty(txtName.Text))
            {
                OOffical obj = new OOffical();
                
                 if (hdfId.Value != "0")
                {
                    try
                    {
                        obj = ctl.Get(int.Parse(hdfId.Value))[0];
                    }
                    catch (Exception ex)
                    {
                        obj = new OOffical();
                    }
                }
                obj.Name = txtName.Text;
                obj.Description = txtDescription.Text;
                obj.Address = txtAddress.Text;
                obj.Email = txtEmail.Text;
                obj.Fax = txtFax.Text;
                obj.Tel = txtTel.Text;
                try {
                    obj.OfficalParent = int.Parse(ddlParent.SelectedValue);
                }
                catch (Exception ea)
                { obj.OfficalParent = 0; }
                if (hdfId.Value != "0")
                {
                   ctl.Update(obj.OfficalID, obj.Name, obj.Description, obj.Address, obj.Tel, obj.Fax, obj.Email, obj.OfficalParent);
                   hdfId.Value = "0";
                }
                else
                {
                    ctl.Add(obj);
                    BindData();
                }
                ResetForm();
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
                //BOffical ctl = new BOffical();
                //ctl.Delete(int.Parse(e.CommandArgument.ToString()));
                hdfId.Value = e.CommandArgument.ToString();
                BOffical ctl = new BOffical();
                try
                {
                   OOffical obj = ctl.Get(int.Parse(hdfId.Value))[0];
                   txtAddress.Text = obj.Address;
                   txtDescription.Text = obj.Description;
                   txtEmail.Text = obj.Email;
                   txtFax.Text = obj.Fax;
                   txtName.Text = obj.Name;
                   txtTel.Text = obj.Tel;
                   try {
                       ddlParent.Items.FindByValue(obj.OfficalParent.ToString()).Selected = true;
                   }
                   catch (Exception ex)
                   { }
                }
                catch (Exception ex)
                {
                    
                }
               
            }
            else if (e.CommandName.Equals("cmdDelete", StringComparison.OrdinalIgnoreCase))
            {
                BOffical ctl = new BOffical();
                ctl.Delete(int.Parse(e.CommandArgument.ToString()));
                BindData();
            }

        }




    }
}
