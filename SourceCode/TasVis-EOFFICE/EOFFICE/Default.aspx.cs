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
using System.Data;
using System.Data.SqlClient;

namespace EOFFICE
{
    public partial class _Default : System.Web.UI.Page
    {
        //SqlParameter[] sqlParameter;
        SqlParameter[] sqlPara = new SqlParameter[1];
        SqlParameter[] sqlParameter = new SqlParameter[3];
        CDBase cdBase = new CDBase();
        protected void Page_Load(object sender, EventArgs e)
        {
            sqlPara[0] = new SqlParameter("@DepartmentID", SqlDbType.Int);
            sqlPara[0].Value = 0;
            grvTest.DataSource = cdBase.RunProcedureGet("sp_tblDepartment_get", sqlPara);          
            grvTest.DataBind();

            sqlParameter[0] = new SqlParameter("@Name",SqlDbType.NVarChar);
            sqlParameter[0].Value = "hung";
            sqlParameter[1] = new SqlParameter("@DepartmentParent", SqlDbType.Int);
            sqlParameter[1].Value = 1;
            sqlParameter[2] = new SqlParameter("@Description", SqlDbType.NVarChar);
            sqlParameter[2].Value = "asdasghfg";
            cdBase.RunProcudure("sp_tblDepartment",sqlParameter);
        }
    }
}
