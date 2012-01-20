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

namespace EOFFICE.Contacts
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ddlContactGroup_Load();
                grvContact_Load();
            }
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
            BContact BobjContact = new BContact();
            grvContact.DataSource = BobjContact.Get(0,1);//Lấy IDUSer sau
            grvContact.DataBind();
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
            int Id = Convert.ToInt32(grvContact.DataKeys[e.RowIndex].Value);
            string textName = ((TextBox)grvContact.Rows[e.RowIndex].Cells[2].Controls[0]).Text;
            string textPhone = ((TextBox)grvContact.Rows[e.RowIndex].Cells[3].Controls[0]).Text;
            string textTel = ((TextBox)grvContact.Rows[e.RowIndex].Cells[4].Controls[0]).Text;
            string textEmail = ((TextBox)grvContact.Rows[e.RowIndex].Cells[5].Controls[0]).Text;
            string textAddress = ((TextBox)grvContact.Rows[e.RowIndex].Cells[6].Controls[0]).Text;
            BContact obj = new BContact();
            if (obj.Update(Id, textName, textPhone, textTel, textAddress, textEmail, 1)) //Lấy IDUSer sau
            {
                lblThongBao2.Text = "BẠN ĐÃ CẬP NHẬT THÀNH CÔNG DANH BẠ!";
            }
            grvContact.EditIndex = -1;
            grvContact_Load();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            BContact BobjContact = new BContact();
            string KeyWord= txtKeyWord.Text;
            if (ddlContactGroup.SelectedValue == "0")
            {
                if (ddlGender.SelectedValue == "0")
                {
                    switch (ddlTieuChi.SelectedValue.ToString())
                    {
                        case "0":
                            grvContact.DataSource = BobjContact.Get(0, 1);
                            break;
                        case "1":
                            grvContact.DataSource = BobjContact.GetFullName(0, 1, KeyWord);
                            break;
                        case "2":
                            grvContact.DataSource = BobjContact.GetPhone(0, 1, KeyWord);
                            break;
                        case "3":
                            grvContact.DataSource = BobjContact.GetEmail(0, 1, KeyWord);
                            break;
                        case "4":
                            grvContact.DataSource = BobjContact.GetAddress(0, 1, KeyWord);
                            break;
                    }
                }
                else
                {
                    switch (ddlTieuChi.SelectedValue.ToString())
                    {
                        case "0":
                            grvContact.DataSource = BobjContact.Get(0, 1, ddlGender.SelectedValue.ToString());
                            break;
                        case "1":
                            grvContact.DataSource = BobjContact.GetFullName(0, 1, KeyWord, ddlGender.SelectedValue.ToString());
                            break;
                        case "2":
                            grvContact.DataSource = BobjContact.GetPhone(0, 1, KeyWord, ddlGender.SelectedValue.ToString());
                            break;
                        case "3":
                            grvContact.DataSource = BobjContact.GetEmail(0, 1, KeyWord, ddlGender.SelectedValue.ToString());
                            break;
                        case "4":
                            grvContact.DataSource = BobjContact.GetAddress(0, 1, KeyWord, ddlGender.SelectedValue.ToString());
                            break;
                    }
                }
            }
            else
            {
                int IDContactGroup =int.Parse( ddlContactGroup.SelectedValue.ToString());
                if (ddlGender.SelectedValue == "0")
                {
                    switch (ddlTieuChi.SelectedValue.ToString())
                    {
                        case "0":
                            grvContact.DataSource = BobjContact.Get(0, 1,IDContactGroup);
                            break;
                        case "1":
                            grvContact.DataSource = BobjContact.GetFullName(0, 1, KeyWord, IDContactGroup);
                            break;
                        case "2":
                            grvContact.DataSource = BobjContact.GetPhone(0, 1, KeyWord, IDContactGroup);
                            break;
                        case "3":
                            grvContact.DataSource = BobjContact.GetEmail(0, 1, KeyWord, IDContactGroup);
                            break;
                        case "4":
                            grvContact.DataSource = BobjContact.GetAddress(0, 1, KeyWord, IDContactGroup);
                            break;
                    }
                }
                else
                {
                    switch (ddlTieuChi.SelectedValue.ToString())
                    {
                        case "0":
                            grvContact.DataSource = BobjContact.Get(0, 1, ddlGender.SelectedValue.ToString(), IDContactGroup);
                            break;
                        case "1":
                            grvContact.DataSource = BobjContact.GetFullName(0, 1, KeyWord, ddlGender.SelectedValue.ToString(), IDContactGroup);
                            break;
                        case "2":
                            grvContact.DataSource = BobjContact.GetPhone(0, 1, KeyWord, ddlGender.SelectedValue.ToString(), IDContactGroup);
                            break;
                        case "3":
                            grvContact.DataSource = BobjContact.GetEmail(0, 1, KeyWord, ddlGender.SelectedValue.ToString(), IDContactGroup);
                            break;
                        case "4":
                            grvContact.DataSource = BobjContact.GetAddress(0, 1, KeyWord, ddlGender.SelectedValue.ToString(), IDContactGroup);
                            break;
                    }
                }
            }
            grvContact.DataBind();
        }
    }
}
