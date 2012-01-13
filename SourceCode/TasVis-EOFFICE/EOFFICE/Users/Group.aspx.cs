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

namespace EOFFICE.Users
{
    public partial class Group : System.Web.UI.Page
    {
        #region "Common Function"

        /// <summary>
        /// Bind danh sách nhóm người dùng
        /// </summary>
        private void BindData()
        {
            BGroup ctl = new BGroup();
            grvListGroups.DataSource = ctl.Get(0);
            grvListGroups.DataBind();
        }

        #endregion

        #region "Events"


        /// <summary>
        /// Load data
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            BindData();
        }


        /// <summary>
        /// Thực hiện thao tác
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lnkAccept_Click(object sender, EventArgs e)
        {
            BGroup ctl = new BGroup();
            switch (drdAction.SelectedValue)
            {
                //-- Xóa
                case "Delete":
                    foreach (GridViewRow r in grvListGroups.Rows)
                    {
                        HtmlInputCheckBox chk = (HtmlInputCheckBox)r.FindControl("chkCheckGroup");
                        if (chk.Checked)
                        {
                            //-- THực hiện xóa người dùng
                            ctl.Delete(int.Parse( grvListGroups.DataKeys[r.RowIndex].Value.ToString()));
                        }
                    }
                    //-- Load lại người dùng
                    BindData();
                    break;
            }
        }

        /// <summary>
        /// Sự kiện xảy ra khi thực hiện các thao tác trên danh sách người dùng
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void grvListGroups_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            //-- Xóa nhóm người dùng
            if (e.CommandName.Equals("cmdDelete", StringComparison.OrdinalIgnoreCase))
            {
                BGroup ctl = new BGroup();
                try
                {
                    //-- THực hiện xóa nhóm người dùng
                    ctl.Delete(int.Parse((e.CommandArgument.ToString())));
                    //--Load lại danh sách nhóm người dùng
                    BindData();
                }
                catch (Exception ex)
                {
                    //--Load lại danh sách nhóm người dùng
                    BindData();
                }
            }
            //--Cập nhật nhóm người dùng
            else if (e.CommandName.Equals("cmdEdit", StringComparison.OrdinalIgnoreCase))
            {
                Response.Redirect("EditGroup.aspx?GroupId="+e.CommandArgument.ToString());
            }

        }
        #endregion


    }
}
