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
    public class BWorkGroup:Common.CDBase
    {
        public bool Add(OWorkGroup obj)
        {
            SqlParameter[] sqlPara = new SqlParameter[3];
            sqlPara[0] = new SqlParameter("@Name", SqlDbType.NVarChar);
            sqlPara[0].Value = obj.Name;
            sqlPara[1] = new SqlParameter("@Description", SqlDbType.NVarChar);
            sqlPara[1].Value = obj.Description;
            sqlPara[2] = new SqlParameter("@WorkGroupParent", SqlDbType.Int);
            sqlPara[2].Value = obj.WorkGroupParent;

            return RunProcudure("sp_tblWorkGroup_add", sqlPara);
        }

        public bool Update(int WorkGroupID, string Name, string Description,int WorkGroupParent)
        {
            SqlParameter[] sqlPara = new SqlParameter[4];
            sqlPara[0] = new SqlParameter("@WorkGroupID", SqlDbType.Int);
            sqlPara[0].Value = WorkGroupID;
            sqlPara[1] = new SqlParameter("@Name", SqlDbType.NVarChar);
            sqlPara[1].Value = Name;
            sqlPara[2] = new SqlParameter("@Description", SqlDbType.NVarChar);
            sqlPara[2].Value = Description;
            sqlPara[3] = new SqlParameter("@WorkGroupParent", SqlDbType.Int);
            sqlPara[3].Value = WorkGroupParent;

            return RunProcudure("sp_tblWorkGroup_update", sqlPara);
        }

        public bool Delete(int WorkGroupID)
        {
            SqlParameter[] sqlPara = new SqlParameter[1];
            sqlPara[0] = new SqlParameter("@WorkGroupID", SqlDbType.Int);
            sqlPara[0].Value = WorkGroupID;

            return RunProcudure("sp_tblWorkGroup_delete", sqlPara);
        }

        public IList<OWorkGroup> Get(int WorkGroupID)
        {
            SqlParameter[] sqlPara = new SqlParameter[1];
            sqlPara[0] = new SqlParameter("@WorkGroupID", SqlDbType.Int);
            sqlPara[0].Value = WorkGroupID;
            DataTable tbl = RunProcedureGet("sp_tblWorkGroup_get", sqlPara);
            IList<OWorkGroup> list = new List<OWorkGroup>();
            list = Common.Common.ConvertTo<OWorkGroup>(tbl);
            return list;
        }
    }
}
