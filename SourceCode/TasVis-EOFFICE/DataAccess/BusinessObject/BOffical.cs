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
    public class BOffical:Common.CDBase
    {
        public bool Add(OOffical obj)
        {
            SqlParameter[] sqlPara = new SqlParameter[7];
            sqlPara[0] = new SqlParameter("@Name", SqlDbType.NVarChar);
            sqlPara[0].Value = obj.Name;
            sqlPara[1] = new SqlParameter("@Description", SqlDbType.NVarChar);
            sqlPara[1].Value = obj.Description;
            sqlPara[2] = new SqlParameter("@Address", SqlDbType.NVarChar);
            sqlPara[2].Value = obj.Address;
            sqlPara[3] = new SqlParameter("@Tel", SqlDbType.VarChar);
            sqlPara[3].Value = obj.Tel;
            sqlPara[4] = new SqlParameter("@Fax", SqlDbType.VarChar);
            sqlPara[4].Value = obj.Fax;
            sqlPara[5] = new SqlParameter("@Email", SqlDbType.VarChar);
            sqlPara[5].Value = obj.Email;
            sqlPara[6] = new SqlParameter("@OfficalParent", SqlDbType.Int);
            sqlPara[6].Value = obj.OfficalParent;


            return RunProcudure("sp_tblOffical_add", sqlPara);
        }

        public bool Update(int OfficalID,string Name,string Description,string Address,string Tel,string Fax,string Email,int OfficalParent)
        {
            SqlParameter[] sqlPara = new SqlParameter[8];
            sqlPara[0] = new SqlParameter("@OfficalID", SqlDbType.Int);
            sqlPara[0].Value = OfficalID;
            sqlPara[1] = new SqlParameter("@Name", SqlDbType.NVarChar);
            sqlPara[1].Value = Name;
            sqlPara[2] = new SqlParameter("@Description", SqlDbType.NVarChar);
            sqlPara[2].Value = Description;
            sqlPara[3] = new SqlParameter("@Address", SqlDbType.NVarChar);
            sqlPara[3].Value = Address;
            sqlPara[4] = new SqlParameter("@Tel", SqlDbType.VarChar);
            sqlPara[4].Value = Tel;
            sqlPara[5] = new SqlParameter("@Fax", SqlDbType.VarChar);
            sqlPara[5].Value = Fax;
            sqlPara[6] = new SqlParameter("@Email", SqlDbType.VarChar);
            sqlPara[6].Value = Email;
            sqlPara[7] = new SqlParameter("@OfficalParent", SqlDbType.VarChar);
            sqlPara[7].Value = OfficalParent;

            return RunProcudure("sp_tblOffical_update", sqlPara);
        }

        public bool Delete(int OfficalID)
        {
            SqlParameter[] sqlPara = new SqlParameter[1];
            sqlPara[0] = new SqlParameter("@OfficalID", SqlDbType.Int);
            sqlPara[0].Value = OfficalID;

            return RunProcudure("sp_tblOffical_delete", sqlPara);
        }

        public IList<OOffical> Get(int OfficalID)
        {
            SqlParameter[] sqlPara = new SqlParameter[1];
            sqlPara[0] = new SqlParameter("@OfficalID", SqlDbType.Int);
            sqlPara[0].Value = OfficalID;
            DataTable tbl = RunProcedureGet("sp_tblOffical_get", sqlPara);
            IList<OOffical> list = new List<OOffical>();
            list = Common.Common.ConvertTo<OOffical>(tbl);
            return list;
        }

        public IList<OOffical> Get(string Name)
        {
            SqlParameter[] sqlPara = new SqlParameter[1];
            sqlPara[0] = new SqlParameter("@Name", SqlDbType.NVarChar);
            sqlPara[0].Value = Name;
            DataTable tbl = RunProcedureGet("sp_tblOffical_get", sqlPara);
            IList<OOffical> list = new List<OOffical>();
            list = Common.Common.ConvertTo<OOffical>(tbl);
            return list;
        }
    }
}
