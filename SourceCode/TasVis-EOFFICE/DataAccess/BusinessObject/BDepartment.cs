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

        public IList<ODepartment> Get(string Name)
        {
            SqlParameter[] sqlPara = new SqlParameter[1];
            sqlPara[0] = new SqlParameter("@Name", SqlDbType.NVarChar);
            sqlPara[0].Value = Name;
            DataTable tbl = RunProcedureGet("sp_tblDepartment_get", sqlPara);
            IList<ODepartment> list = new List<ODepartment>();
            list = Common.Common.ConvertTo<ODepartment>(tbl);
            return list;
        }

        public bool Add(ODepartment obj)
        {
            SqlParameter[] sqlPara = new SqlParameter[3];
            sqlPara[0] = new SqlParameter("@Name", SqlDbType.NVarChar);
            sqlPara[0].Value = obj.Name;
            sqlPara[1] = new SqlParameter("@DepartmentParent", SqlDbType.Int);
            sqlPara[1].Value = obj.DepartmentParent;
            sqlPara[2] = new SqlParameter("@Description", SqlDbType.NVarChar);
            sqlPara[2].Value = obj.Description;

            return RunProcudure("sp_tblDepartment_add", sqlPara);
        }

        public bool Update(int DepartmentID,string Name,int DepartmentParent,string Description)
        {
            SqlParameter[] sqlPara = new SqlParameter[4];
            sqlPara[0] = new SqlParameter("@DepartmentID", SqlDbType.Int);
            sqlPara[0].Value = DepartmentID;
            sqlPara[1] = new SqlParameter("@Name", SqlDbType.NVarChar);
            sqlPara[1].Value = Name;
            sqlPara[2] = new SqlParameter("@DepartmentParent", SqlDbType.Int);
            sqlPara[2].Value = DepartmentParent;
            sqlPara[3] = new SqlParameter("@Description", SqlDbType.NVarChar);
            sqlPara[3].Value = Description;


            return RunProcudure("sp_tblDepartment_update", sqlPara);
        }

        public bool Delete(int DepartmentID)
        {
            SqlParameter[] sqlPara = new SqlParameter[1];
            sqlPara[0] = new SqlParameter("@DepartmentID", SqlDbType.Int);
            sqlPara[0].Value = DepartmentID;
            

            return RunProcudure("sp_tblDepartment_delete", sqlPara);
        }
    }
}
