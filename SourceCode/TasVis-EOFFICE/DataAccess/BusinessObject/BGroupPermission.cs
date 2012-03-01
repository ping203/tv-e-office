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
    public class BGroupPermission: Common.CDBase
    {
        public bool Add(OGroupPermission obj)
        {
            SqlParameter[] sqlPara = new SqlParameter[2];
            sqlPara[0] = new SqlParameter("@GroupId", SqlDbType.Int);
            sqlPara[0].Value = obj.GroupId;
            sqlPara[1] = new SqlParameter("@PermissionDefinitionId", SqlDbType.Int);
            sqlPara[1].Value = obj.PermissionDefinitionId;
            return RunProcudure("sp_tblGroupPermission_add", sqlPara);
        }

        public bool Delete(OGroupPermission obj)
        {
            SqlParameter[] sqlPara = new SqlParameter[3];
            sqlPara[0] = new SqlParameter("@ID", SqlDbType.Int);
            sqlPara[0].Value = obj.ID;
            sqlPara[1] = new SqlParameter("@GroupId", SqlDbType.Int);
            sqlPara[1].Value = obj.GroupId;
            sqlPara[2] = new SqlParameter("@PermissionDefinitionId", SqlDbType.Int);
            sqlPara[2].Value = obj.PermissionDefinitionId;
            return RunProcudure("sp_tblGroupPermission_add", sqlPara);
        }
        public IList<OGroupPermission> Get(OGroupPermission obj)
        {
            SqlParameter[] sqlPara = new SqlParameter[3];
            sqlPara[0] = new SqlParameter("@ID", SqlDbType.Int);
            sqlPara[0].Value = obj.ID;
            sqlPara[1] = new SqlParameter("@GroupId", SqlDbType.Int);
            sqlPara[1].Value = obj.GroupId;
            sqlPara[2] = new SqlParameter("@PermissionDefinitionId", SqlDbType.Int);
            sqlPara[2].Value = obj.PermissionDefinitionId;
            DataTable tbl = RunProcedureGet("sp_tblGroupPermission_get", sqlPara);
            IList<OGroupPermission> list = new List<OGroupPermission>();
            list = Common.Common.ConvertTo<OGroupPermission>(tbl);
            return list;
        }
    }
}
