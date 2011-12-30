using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DataAccess.DataObject;
namespace DataAccess.BusinessObject
{
    class BDepartment:Common.CDBase 
    {
        /// <summary>
        /// Lấy về phòng ban theo mã tương ứng
        /// </summary>
        /// <param name="DepartmentId">Mã phòng ban</param>
        private ODepartment Get(int DepartmentId)
        {
            SqlParameter[] sqlPara = new SqlParameter[1];
            sqlPara[0] = new SqlParameter("@DepartmentID", SqlDbType.Int);
            sqlPara[0].Value = DepartmentId;
            DataTable tbl = RunProcedureGet("sp_tblDepartment_get", sqlPara);
            if (tbl.Rows.Count > 0)
            {
                //---doing 
                return (new ODepartment());
            }
            else
                return (new ODepartment());
        }
    }
}
