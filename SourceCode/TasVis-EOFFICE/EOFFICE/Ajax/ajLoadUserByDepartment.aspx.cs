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
using System.Collections.Generic;
namespace EOFFICE.Ajax
{
    public partial class ajLoadUserByDepartment : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string html = "";
            int DepartmentID=int.Parse(Request.Params["DepartmentID"].ToString());
            html += "<table width='800px'>";
            
            BUser BobjUser = new BUser();
            List<OUser> listUser = new List<OUser>();
            listUser = BobjUser.GetByDepartment(DepartmentID).ToList();
            int count = 0;
            foreach (OUser obj in listUser)
            {
                if (count % 4 == 0)
                {
                    html += "<tr>";
                }
                html += "<td width='25%'>";
                html += "<input id='ckxUser' class='cbxUser' name='ckxUser' type='checkbox' value='"+obj.UserName+"' title='"+obj.FullName+"' />";
                html += "&nbsp";
                html += ""+obj.FullName+"";
                html += "</td>";
                count++;
                if (count % 4 == 0)
                {
                    html += "</tr>";
                }
            }
            if (count % 4 != 0)
            {
                html += "</tr>";
            }
            html += "</table>";           
            Response.Write(html);
        }
    }
}
