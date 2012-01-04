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
using System.Collections.Generic;
using System.Text;
using DataAccess.DataObject;
using System.Reflection;
using System.ComponentModel;
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


            //sqlParameter[0] = new SqlParameter("@Name", SqlDbType.NVarChar);
            //sqlParameter[0].Value = "hung";
            //sqlParameter[1] = new SqlParameter("@DepartmentParent", SqlDbType.Int);
            //sqlParameter[1].Value = 2;
            //sqlParameter[2] = new SqlParameter("@Description", SqlDbType.NVarChar);
            //sqlParameter[2].Value = "asdasghfg";
            //cdBase.RunProcudure("sp_tblDepartment_add", sqlParameter);
            
            //sqlPara[0] = new SqlParameter("@DepartmentID", SqlDbType.Int);
            //sqlPara[0].Value = 0;
            //DataTable tb= new DataTable();
            
            //tb = cdBase.RunProcedureGet("sp_tblDepartment_get", sqlPara);
            //BDepartment bd = new BDepartment();
            //grvTest.DataSource = bd.Get(0);
            //grvTest.DataBind();
        }
    }
}
