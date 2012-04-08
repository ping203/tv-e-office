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
    public class BDocumentKind:Common.CDBase
    {
        public bool Add(ODocumentKind obj)
        {
            SqlParameter[] sqlPara = new SqlParameter[3];
            sqlPara[0] = new SqlParameter("@Name", SqlDbType.NVarChar);
            sqlPara[0].Value = obj.Name;
            sqlPara[1] = new SqlParameter("@Description", SqlDbType.NVarChar);
            sqlPara[1].Value = obj.Description;
            sqlPara[2] = new SqlParameter("@DocumentKindParent", SqlDbType.Int);
            sqlPara[2].Value = obj.DocumentKindParent;

            return RunProcudure("sp_tblDocumentKind_add", sqlPara);
        }

        public bool Update(int DocumentKindID, string Name, string Description, int DocumentKindParent)
        {
            SqlParameter[] sqlPara = new SqlParameter[4];
            sqlPara[0] = new SqlParameter("@DocumentKindID", SqlDbType.Int);
            sqlPara[0].Value = DocumentKindID;
            sqlPara[1] = new SqlParameter("@Name", SqlDbType.NVarChar);
            sqlPara[1].Value = Name;
            sqlPara[2] = new SqlParameter("@Description", SqlDbType.NVarChar);
            sqlPara[2].Value = Description;
            sqlPara[3] = new SqlParameter("@DocumentKindParent", SqlDbType.Int);
            sqlPara[3].Value = DocumentKindParent;
            return RunProcudure("sp_tblDocumentKind_update", sqlPara);
        }

        public bool Delete(int DocumentKindID)
        {
            SqlParameter[] sqlPara = new SqlParameter[1];
            sqlPara[0] = new SqlParameter("@DocumentKindID", SqlDbType.Int);
            sqlPara[0].Value = DocumentKindID;

            return RunProcudure("sp_tblDocumentKind_delete", sqlPara);
        }

        public IList<ODocumentKind> Get(int DocumentKindID)
        {
            SqlParameter[] sqlPara = new SqlParameter[1];
            sqlPara[0] = new SqlParameter("@DocumentKindID", SqlDbType.Int);
            sqlPara[0].Value = DocumentKindID;
            DataTable tbl = RunProcedureGet("sp_tblDocumentKind_get", sqlPara);
            IList<ODocumentKind> list = new List<ODocumentKind>();
            list = Common.Common.ConvertTo<ODocumentKind>(tbl);
            return list;
        }
    }
}
