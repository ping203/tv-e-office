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
    public class BPermisionDefinition : Common.CDBase
    {
        public bool Add(OPermisionDefinition obj)
        {
            SqlParameter[] sqlPara = new SqlParameter[2];
            sqlPara[0] = new SqlParameter("@Code", SqlDbType.NVarChar);
            sqlPara[0].Value = obj.Code;
            sqlPara[1] = new SqlParameter("@Name", SqlDbType.NVarChar);
            sqlPara[1].Value = obj.Name;

            return RunProcudure("sp_tblPermisionDefinition_add", sqlPara);
        }

        public bool Update(int ID, string Code, string Name)
        {
            SqlParameter[] sqlPara = new SqlParameter[3];
            sqlPara[0] = new SqlParameter("@ID", SqlDbType.Int);
            sqlPara[0].Value = ID;
            sqlPara[1] = new SqlParameter("@Code", SqlDbType.NVarChar);
            sqlPara[1].Value = Code;
            sqlPara[2] = new SqlParameter("@Name", SqlDbType.NVarChar);
            sqlPara[2].Value = Name;


            return RunProcudure("sp_tblPermisionDefinition_update", sqlPara);
        }

        public bool Delete(int ID)
        {
            SqlParameter[] sqlPara = new SqlParameter[1];
            sqlPara[0] = new SqlParameter("@ID", SqlDbType.Int);
            sqlPara[0].Value = ID;

            return RunProcudure("sp_tblPermisionDefinition_delete", sqlPara);
        }


        public IList<OPermisionDefinition> Get(int ID,string Code,string Name)
        {
            SqlParameter[] sqlPara = new SqlParameter[3];
            sqlPara[0] = new SqlParameter("@ID", SqlDbType.Int);
            sqlPara[0].Value = ID;
            sqlPara[1] = new SqlParameter("@Code", SqlDbType.NVarChar);
            sqlPara[1].Value = Code;
            sqlPara[2] = new SqlParameter("@Name", SqlDbType.NVarChar);
            sqlPara[2].Value = Name;
            DataTable tbl = RunProcedureGet("sp_tblPermisionDefinition_get", sqlPara);
            IList<OPermisionDefinition> list = new List<OPermisionDefinition>();
            list = Common.Common.ConvertTo<OPermisionDefinition>(tbl);
            return list;
        }
    }
}
