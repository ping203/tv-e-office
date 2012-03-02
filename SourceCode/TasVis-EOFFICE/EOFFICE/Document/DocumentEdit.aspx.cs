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

namespace EOFFICE
{

    public partial class DocumentEdit : System.Web.UI.Page
    {
        #region "Common Function"
        /// <summary>
        /// Load ra danh sách loại tài liệu
        /// </summary>
        private void BindDocumentType()
        {
            BDocumentKind ctl = new BDocumentKind();
            ddlType.ClearSelection();
            ddlType.DataSource = ctl.Get(0);
            ddlType.DataBind();
            ddlParent.Items.Insert(0, new ListItem("Tất cả", ""));
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
                BindDocumentType();
            }
           
        }
        #endregion




    }
}
