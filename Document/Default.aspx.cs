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
using DataAccess.Common;
namespace EOFFICE.Contacts
{
    public partial class Default : System.Web.UI.Page
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

        private void InitData()
        {
            //--Pagesize
            if (Request.QueryString["pagesize"] != null)
            {
                try
                {
                    ddlPageSize.Items.FindByValue(Request.QueryString["pagesize"]).Selected = true;
                }
                catch (Exception ex) { }
            }
            //--Nhóm liên hệ
            if (Request.QueryString["group"] != null)
            {
                try
                {
                    ddlContactGroup.Items.FindByValue(Request.QueryString["group"]).Selected = true;
                }
                catch (Exception ex) { }
            }
            //--Giới tính
            if (Request.QueryString["gender"] != null)
            {
                try
                {
                    ddlGender.SelectedValue = Request.QueryString["gender"].ToString();
                    ddlGender.DataBind();
                }
                catch (Exception ex) { }
            }
            //--Tiêu chí tìm kiếm
            if (Request.QueryString["type"] != null)
            {
                try
                {
                    ddlTieuChi.Items.FindByValue(Request.QueryString["type"]).Selected = true;
                }
                catch (Exception ex) { }
            }
        }

        public string GenParamRedirect()
        {
            string strParam = "";
            strParam += "pagesize=" + ddlPageSize.SelectedValue;
            strParam += "&group=" + ddlContactGroup.SelectedValue;
            strParam += "&gender=" + ddlGender.SelectedValue;
            strParam += "&type=" + ddlTieuChi.SelectedValue;
            if (txtKeyWord.Text.Trim().Length > 0)
            {
                strParam += "&key=" + Server.UrlEncode(txtKeyWord.Text.Trim());
            }
            //--Pagesize
            if (Request.QueryString["currentpage"] != null)
            {
                try
                {
                    strParam += "&currentpage=" + Request.QueryString["currentpage"];
                }
                catch (Exception ex) { }
            }

            return strParam;
        }

        /// <summary>
        /// Tạo các parmater phục vụ phân trang
        /// </summary>
        /// <returns></returns>
        private string GenarateParam()
        {
            string strParam = "";
            strParam += "pagesize=" + ddlPageSize.SelectedValue;
            strParam += "&group=" + ddlContactGroup.SelectedValue;
            strParam += "&gender=" + ddlGender.SelectedValue;
            strParam += "&type=" + ddlTieuChi.SelectedValue;
            if (txtKeyWord.Text.Trim().Length > 0)
            {
                strParam += "&type=" + Server.UrlEncode(txtKeyWord.Text.Trim());
            }
            return strParam;
        }

        protected void ddlPageSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            grvContact_Load();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ddlContactGroup_Load();
                BindGender();
                InitData();
                grvContact_Load();
            }
        }

        private void BindGender()
        {
            ddlGender.Items.Clear();
            ddlGender.Items.Add(new ListItem("--Tất cả--",""));
            ddlGender.Items.Add(new ListItem("Nam", Gender.Male.ToString("D")));
            ddlGender.Items.Add(new ListItem("Nữ", Gender.Female.ToString("D")));
            ddlGender.Items.Add(new ListItem("Khác", Gender.Other.ToString("D")));
            ddlGender.DataBind();
        }

        protected void btnDanhSach_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }

        protected void btnNhom_Click(object sender, EventArgs e)
        {
            Response.Redirect("ContactGroup.aspx");
        }

        protected void btnThem_Click(object sender, EventArgs e)
        {
            Response.Redirect("ContactCreate.aspx");
        }

        protected void grvContact_Load()
        {
            int IdUser = Global.UserInfo.UserID;

            BContact BobjContact = new BContact();
            int ContactGroupID = int.Parse(ddlContactGroup.SelectedValue);
            string Gender = ddlGender.SelectedValue;
            string Name = "";
            string Phone = "";
            string Email = "";
            string Address = "";
            
            //--Set key tìm kiếm
            if (txtKeyWord.Text.Trim().Length > 0)
            {
                switch (ddlTieuChi.SelectedValue)
                {                    
                    case "Name":
                        Name = txtKeyWord.Text.Trim();
                        break;
                    case "Phone":
                        Phone = txtKeyWord.Text.Trim();
                        break;
                    case "Email":
                        Email = txtKeyWord.Text.Trim();
                        break;
                    case "Address":
                        Address = txtKeyWord.Text.Trim();
                        break;
                }
            }

            ctlPagging.PageSize = int.Parse(ddlPageSize.SelectedValue);
            int count = BobjContact.Get(0,Name,IdUser,Gender,ContactGroupID,Email,Phone,Address,"ASC","FullName").Count;
            spResultCount.InnerHtml = "Tìm thấy <b>" + count.ToString() + "</b> kết quả";
            if (count > ctlPagging.PageSize)
            {
                ctlPagging.Visible = true;
            }
            else
            {
                ctlPagging.Visible = false;
            }
            grvContact.DataSource = BobjContact.Get(0,Name,IdUser,Gender,ContactGroupID,Email,Phone,Address,"ASC","FullName", CurrentPage, ctlPagging.PageSize);
            grvContact.DataBind();
            ctlPagging.CurrentIndex = CurrentPage;
            ctlPagging.ItemCount = count;
            ctlPagging.QueryStringParameterName = GenarateParam();
        }

        protected void ddlContactGroup_Load()
        {
            BContactGroup Bobj = new BContactGroup();
            ddlContactGroup.DataSource = Bobj.GetByUser(1);
            ddlContactGroup.DataTextField = "GroupName";
            ddlContactGroup.DataValueField = "ContactGroupID";            
            ddlContactGroup.DataBind();
            ListItem lit = new ListItem("-- Tất cả --", "0");
            ddlContactGroup.Items.Insert(0, lit);
        }

        protected void grvContact_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowState == DataControlRowState.Normal)
                e.Row.CssClass = "normal";
            if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowState == DataControlRowState.Alternate)
                e.Row.CssClass = "altenate";
        }

        protected void grvContact_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {

                //adding an attribute for onclick event on the check box in the header

                //and passing the ClientID of the Select All checkbox

                ((CheckBox)e.Row.FindControl("CheckAll")).Attributes.Add("onclick", "javascript:SelectAll('" + ((CheckBox)e.Row.FindControl("CheckAll")).ClientID + "')");
            }
        }

        protected void grvContact_RowEditing(object sender, GridViewEditEventArgs e)
        {
            grvContact.EditIndex = e.NewEditIndex;
            grvContact_Load();
        }

        protected void grvContact_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            grvContact.EditIndex = -1;
            grvContact_Load();
        }

        protected void grvContact_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int Id = Convert.ToInt32(grvContact.DataKeys[e.RowIndex].Value);
            BContact obj = new BContact();
            if (obj.Delete(Id))
            {
                lblThongBao2.Text = "BẠN ĐÃ XÓA THÀNH CÔNG DANH BẠ!";
            }
            grvContact_Load();
        }

        protected void btnXoa_Click(object sender, EventArgs e)
        {
            BContact obj = new BContact();
            foreach (GridViewRow row in grvContact.Rows)
            {
                CheckBox checkbox = (CheckBox)row.FindControl("MyCheckBox");

                if (checkbox.Checked == true)
                {
                    int Id = Convert.ToInt32(grvContact.DataKeys[row.RowIndex].Value);
                    obj.Delete(Id);
                    lblThongBao2.Text = "BẠN ĐÃ XÓA THÀNH CÔNG DANH BẠ!";
                }

            }
            grvContact_Load();
        }

        protected void grvContact_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int UserID = Global.UserInfo.UserID;
            int Id = Convert.ToInt32(grvContact.DataKeys[e.RowIndex].Value);
            string textName = ((TextBox)grvContact.Rows[e.RowIndex].Cells[2].Controls[0]).Text;
            string textPhone = ((TextBox)grvContact.Rows[e.RowIndex].Cells[3].Controls[0]).Text;
            string textTel = ((TextBox)grvContact.Rows[e.RowIndex].Cells[4].Controls[0]).Text;
            string textEmail = ((TextBox)grvContact.Rows[e.RowIndex].Cells[5].Controls[0]).Text;
            string textAddress = ((TextBox)grvContact.Rows[e.RowIndex].Cells[6].Controls[0]).Text;
            BContact obj = new BContact();
            if (obj.Update(Id, textName, textPhone, textTel, textAddress, textEmail, UserID)) //Lấy IDUSer sau
            {
                lblThongBao2.Text = "BẠN ĐÃ CẬP NHẬT THÀNH CÔNG DANH BẠ!";
            }
            grvContact.EditIndex = -1;
            grvContact_Load();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            grvContact_Load();
        }
    }
}
