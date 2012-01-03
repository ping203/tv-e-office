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
    public class BPermission:Common.CDBase
    {
        public bool Add(OPermission obj)
        {
            SqlParameter[] sqlPara = new SqlParameter[3];
            sqlPara[0] = new SqlParameter("@IDModule", SqlDbType.VarChar);
            sqlPara[0].Value = obj.IDModule;
            sqlPara[1] = new SqlParameter("@IDGroup", SqlDbType.Int);
            sqlPara[1].Value = obj.IDGroup;
            sqlPara[2] = new SqlParameter("@Roles", SqlDbType.VarChar);
            sqlPara[2].Value = obj.Roles;

            return RunProcudure("sp_tblPermission_add", sqlPara);
        }

        public bool Update(string IDModule, int IDGroup, string Roles)
        {
            SqlParameter[] sqlPara = new SqlParameter[3];
            sqlPara[0] = new SqlParameter("@IDModule", SqlDbType.VarChar);
            sqlPara[0].Value = IDModule;
            sqlPara[1] = new SqlParameter("@IDGroup", SqlDbType.Int);
            sqlPara[1].Value = IDGroup;
            sqlPara[2] = new SqlParameter("@Roles", SqlDbType.VarChar);
            sqlPara[2].Value = Roles;
            

            return RunProcudure("sp_tblPermission_update", sqlPara);
        }

        public bool Delete(string IDModule)
        {
            SqlParameter[] sqlPara = new SqlParameter[1];
            sqlPara[0] = new SqlParameter("@IDModule", SqlDbType.VarChar);
            sqlPara[0].Value = IDModule;

            return RunProcudure("sp_tblPermission_delete", sqlPara);
        }

        public bool Delete(int IDGroup)
        {
            SqlParameter[] sqlPara = new SqlParameter[1];
            sqlPara[0] = new SqlParameter("@IDGroup", SqlDbType.Int);
            sqlPara[0].Value = IDGroup;

            return RunProcudure("sp_tblPermission_delete", sqlPara);
        }

        public bool Delete(string IDModule, int IDGroup)
        {
            SqlParameter[] sqlPara = new SqlParameter[2];
            sqlPara[0] = new SqlParameter("@IDModule", SqlDbType.VarChar);
            sqlPara[0].Value = IDModule;
            sqlPara[1] = new SqlParameter("@IDGroup", SqlDbType.Int);
            sqlPara[1].Value = IDGroup;

            return RunProcudure("sp_tblPermission_delete", sqlPara);
        }

        public IList<OPermission> Get(int IDGroup)
        {
            SqlParameter[] sqlPara = new SqlParameter[1];
            sqlPara[0] = new SqlParameter("@IDGroup", SqlDbType.Int);
            sqlPara[0].Value = IDGroup;
            DataTable tbl = RunProcedureGet("sp_tblPermission_get", sqlPara);
            IList<OPermission> list = new List<OPermission>();
            list = Common.Common.ConvertTo<OPermission>(tbl);
            return list;
        }
    }
}
