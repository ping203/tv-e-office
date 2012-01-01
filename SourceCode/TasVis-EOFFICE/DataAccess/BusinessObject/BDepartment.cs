using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DataAccess.DataObject;
using DataAccess.Common;
namespace DataAccess.BusinessObject
{
    public class BDepartment:Common.CDBase 
    {
        /// <summary>
        /// Lấy về phòng ban theo mã tương ứng
        /// </summary>
        /// <param name="DepartmentId">Mã phòng ban</param>
        /// 
        
        public IList<ODepartment> Get(int DepartmentId)
        {
            SqlParameter[] sqlPara = new SqlParameter[1];
            sqlPara[0] = new SqlParameter("@DepartmentID", SqlDbType.Int);
            sqlPara[0].Value = DepartmentId;
            DataTable tbl = RunProcedureGet("sp_tblDepartment_get", sqlPara);
            IList<ODepartment> list = new List<ODepartment>();
            list = Common.Common.ConvertTo<ODepartment>(tbl);
            return list;
        }
    }
}
