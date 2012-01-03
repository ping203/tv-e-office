using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DataAccess.Common;
using DataAccess.DataObject;

namespace DataAccess.BusinessObject
{
    public class BGroup:Common.CDBase
    {
        public bool Add(OGroup obj)
        {
            SqlParameter[] sqlPara = new SqlParameter[2];
            sqlPara[0] = new SqlParameter("@Name", SqlDbType.NVarChar);
            sqlPara[0].Value = obj.Name;
            sqlPara[1] = new SqlParameter("@Description", SqlDbType.NVarChar);
            sqlPara[1].Value = obj.Description;


            return RunProcudure("sp_tblGroup_add", sqlPara);
        }

        public bool Update(int GroupID,string Name,string Description)
        {
            SqlParameter[] sqlPara = new SqlParameter[3];
            sqlPara[0] = new SqlParameter("@GroupID", SqlDbType.Int);
            sqlPara[0].Value = GroupID;
            sqlPara[1] = new SqlParameter("@Name", SqlDbType.NVarChar);
            sqlPara[1].Value = Name;
            sqlPara[2] = new SqlParameter("@Description", SqlDbType.NVarChar);
            sqlPara[2].Value = Description;

            return RunProcudure("sp_tblGroup_update", sqlPara);
        }

        public bool Delete(int GroupID)
        {
            SqlParameter[] sqlPara = new SqlParameter[1];
            sqlPara[0] = new SqlParameter("@GroupID", SqlDbType.Int);
            sqlPara[0].Value = GroupID;

            return RunProcudure("sp_tblGroup_delete", sqlPara);
        }

        public IList<OGroup> Get(int GroupID)
        {
            SqlParameter[] sqlPara = new SqlParameter[1];
            sqlPara[0] = new SqlParameter("@GroupID", SqlDbType.Int);
            sqlPara[0].Value = GroupID;

            DataTable tbl = RunProcedureGet("sp_tblGroup_get", sqlPara);
            IList<OGroup> list = new List<OGroup>();
            list = Common.Common.ConvertTo<OGroup>(tbl);
            return list;
        }

        public IList<OGroup> Get(string Name, string Order, string OrderBy)
        {
            SqlParameter[] sqlPara = new SqlParameter[3];
            sqlPara[0] = new SqlParameter("@Name", SqlDbType.NVarChar);
            sqlPara[0].Value = Name;
            sqlPara[0] = new SqlParameter("@Order", SqlDbType.VarChar);
            sqlPara[0].Value = Order;
            sqlPara[0] = new SqlParameter("@OrderBy", SqlDbType.VarChar);
            sqlPara[0].Value = OrderBy;

            DataTable tbl = RunProcedureGet("sp_tblGroup_get", sqlPara);
            IList<OGroup> list = new List<OGroup>();
            list = Common.Common.ConvertTo<OGroup>(tbl);
            return list;
        }
    }
}
