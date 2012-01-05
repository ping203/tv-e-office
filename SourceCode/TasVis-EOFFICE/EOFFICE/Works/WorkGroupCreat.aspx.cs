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

namespace EOFFICE.Works
{
    public partial class WorkGroupCreat : System.Web.UI.Page
    {
        static string prevPage = String.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                grvWorkGroup_Load();
                prevPage = Request.UrlReferrer.ToString();
            }
        }

        protected void grvWorkGroup_Load()
        {            
            BWorkGroup objWorkGroup = new BWorkGroup();
            grvWorkGroup.DataSource= objWorkGroup.Get(0);
            grvWorkGroup.DataBind();
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect(prevPage);
        }

        protected void btnBack2_Click(object sender, EventArgs e)
        {
            Response.Redirect(prevPage);
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            OWorkGroup obj = new OWorkGroup();
            obj.Name = txtWorkGroupName.Text;
            obj.Description = txtContent.Text;

            BWorkGroup ọbjB = new BWorkGroup();
            ọbjB.Add(obj);
            grvWorkGroup_Load();
            
        }

        protected void grvWorkGroup_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowState == DataControlRowState.Normal)
                e.Row.CssClass = "normal";
            if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowState == DataControlRowState.Alternate)
                e.Row.CssClass = "altenate";
        }
        

        private void ToggleCheckState(bool checkState)
        {
            
            foreach (GridViewRow row in grvWorkGroup.Rows)
            {
                // Access the CheckBox
                CheckBox cb = (CheckBox)row.FindControl("MyCheckBox");
                if (cb != null)
                    cb.Checked = checkState;
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            BWorkGroup obj = new BWorkGroup();
            foreach (GridViewRow row in grvWorkGroup.Rows)
            {
                CheckBox checkbox = (CheckBox)row.FindControl("MyCheckBox");

                if (checkbox.Checked == true)
                {
                    int Id =Convert.ToInt32(grvWorkGroup.DataKeys[row.RowIndex].Value);
                    
                    obj.Delete(Id);
                }

            }
            grvWorkGroup_Load();
        }

        protected void grvWorkGroup_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {

                //adding an attribute for onclick event on the check box in the header

                //and passing the ClientID of the Select All checkbox

                ((CheckBox)e.Row.FindControl("CheckAll")).Attributes.Add("onclick", "javascript:SelectAll('" + ((CheckBox)e.Row.FindControl("CheckAll")).ClientID + "')");

            }
        }

        protected void grvWorkGroup_RowEditing(object sender, GridViewEditEventArgs e)
        {
            grvWorkGroup.EditIndex = e.NewEditIndex;
            grvWorkGroup_Load();
        }

        protected void grvWorkGroup_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int Id =Convert.ToInt32(grvWorkGroup.DataKeys[e.RowIndex].Value);
            TextBox Name = (TextBox)grvWorkGroup.Rows[e.RowIndex].FindControl("txtName");
            TextBox Description = (TextBox)grvWorkGroup.Rows[e.RowIndex].FindControl("txtDescription");

            BWorkGroup obj = new BWorkGroup();
            obj.Update(Id, "abcd", "abcd",0);
            grvWorkGroup.EditIndex = -1;
            grvWorkGroup_Load();
        }

        protected void grvWorkGroup_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            grvWorkGroup.EditIndex = -1;
            grvWorkGroup_Load();
        }

        
    }
}
