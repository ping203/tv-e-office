using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DataAccess.DataObject;


namespace DataAccess.BusinessObject
{
    public class BUser:Common.CDBase
    {
        /// <summary>
        /// Lấy về User theo tên User tương ứng
        /// </summary>
        /// <param name="UserName">Tên User</param>

         public OUser Get(string UserName)
         {
             List<OUser> lstUser = new List<OUser>();
             SqlParameter[] sqlPara = new SqlParameter[1];
             sqlPara[0] = new SqlParameter("@UserName", SqlDbType.NVarChar);
             sqlPara[0].Value = UserName;

             DataTable tb = RunProcedureGet("sp_tblUser_get",sqlPara);
             OUser objUser = new OUser();
             lstUser.Add(objUser);
             return objUser;
         }
         public List<OUser> Get(string FullName, string Order, string OrderBy)
         {
             List<OUser> lstUser = new List<OUser>();
             return lstUser;
         }
        
    }
}
