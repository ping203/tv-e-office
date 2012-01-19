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

namespace EOFFICE.Contacts
{
    public partial class ContactGroup : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                grvContactGroup_Load();
            }
            lblThongBao.Text = string.Empty;
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

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            BContactGroup BobjContactGroup = new BContactGroup();
            OContactGroup objContactGroup = new OContactGroup();
            objContactGroup.GroupName = txtWorkGroupName.Text;
            objContactGroup.Description = txtContent.Text;
            objContactGroup.IDUser = 1;//Sau này thay bằng IDUser đăng nhập
            if (BobjContactGroup.Add(objContactGroup))
            {
                lblThongBao.Text = "Bạn đã thêm thành công nhóm danh bạ!";
            }
            grvContactGroup_Load();
            txtContent.Text = string.Empty;
            txtWorkGroupName.Text = string.Empty;
        }

        protected void grvContactGroup_Load()
        {
            BContactGroup BobjCG = new BContactGroup();
            if (BobjCG.GetByUser(1).Count == 0)
            {
                lblThongBao2.Text = "BẠN CHƯA TẠO NHÓM DANH BẠ NÀO!";
            }
            else
            {
                grvContactGroup.DataSource = BobjCG.GetByUser(1);
                grvContactGroup.DataBind();
            }
            
        }

        protected void grvContactGroup_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowState == DataControlRowState.Normal)
                e.Row.CssClass = "normal";
            if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowState == DataControlRowState.Alternate)
                e.Row.CssClass = "altenate";
        }

        protected void grvContactGroup_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {

                //adding an attribute for onclick event on the check box in the header

                //and passing the ClientID of the Select All checkbox

                ((CheckBox)e.Row.FindControl("CheckAll")).Attributes.Add("onclick", "javascript:SelectAll('" + ((CheckBox)e.Row.FindControl("CheckAll")).ClientID + "')");
            }
        }

        protected void grvContactGroup_RowEditing(object sender, GridViewEditEventArgs e)
        {
            grvContactGroup.EditIndex = e.NewEditIndex;
            grvContactGroup_Load();
        }

        protected void grvContactGroup_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            grvContactGroup.EditIndex = -1;
            grvContactGroup_Load();
        }

        protected void grvContactGroup_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int Id = Convert.ToInt32(grvContactGroup.DataKeys[e.RowIndex].Value);
            string textName = ((TextBox)grvContactGroup.Rows[e.RowIndex].Cells[2].Controls[0]).Text;
            string textDescription = ((TextBox)grvContactGroup.Rows[e.RowIndex].Cells[3].Controls[0]).Text;

            BContactGroup obj = new BContactGroup();
            obj.Update(Id, textName, textDescription);
            grvContactGroup.EditIndex = -1;
            grvContactGroup_Load();

        }

        protected void grvContactGroup_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int Id = Convert.ToInt32(grvContactGroup.DataKeys[e.RowIndex].Value);
            BContactGroup obj = new BContactGroup();
            if (obj.Delete(Id))
            {
                lblThongBao2.Text = "BẠN ĐÃ XÓA THÀNH CÔNG NHÓM DANH BẠ!";
            }
            grvContactGroup_Load();
        }

        protected void btnXoa_Click(object sender, EventArgs e)
        {
            BContactGroup obj = new BContactGroup();
            foreach (GridViewRow row in grvContactGroup.Rows)
            {
                CheckBox checkbox = (CheckBox)row.FindControl("MyCheckBox");

                if (checkbox.Checked == true)
                {
                    int Id = Convert.ToInt32(grvContactGroup.DataKeys[row.RowIndex].Value);
                    obj.Delete(Id);
                    lblThongBao2.Text = "BẠN ĐÃ XÓA THÀNH CÔNG NHÓM DANH BẠ!";
                }

            }
            grvContactGroup_Load();
        }
    }
}
