using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess.DataObject;
using DataAccess.Common;
using System.Data;
using System.Data.SqlClient;

namespace DataAccess.BusinessObject
{
    public class BAttach:Common.CDBase
    {
        public bool Delete(int AttachID)
        {
            SqlParameter[] sqlPara = new SqlParameter[1];
            sqlPara[0] = new SqlParameter("@AttachID", SqlDbType.Int);
            sqlPara[0].Value = AttachID;

            return RunProcudure("sp_tblAttach_delete", sqlPara);
        }

        public bool Add(OAttach obj)
        {
            SqlParameter[] sqlPara = new SqlParameter[3];
            sqlPara[0] = new SqlParameter("@Name", SqlDbType.NVarChar);
            sqlPara[0].Value = obj.Name;
            sqlPara[1] = new SqlParameter("@Description", SqlDbType.NVarChar);
            sqlPara[1].Value = obj.Description;
            sqlPara[2] = new SqlParameter("@Path", SqlDbType.NVarChar);
            sqlPara[2].Value = obj.Path;

            return RunProcudure("sp_tblAttach_add", sqlPara);
        }

        public bool Update(int AttachID,string Name,string Description,string Path)
        {
            SqlParameter[] sqlPara = new SqlParameter[4];
            sqlPara[0] = new SqlParameter("@AttachID", SqlDbType.Int);
            sqlPara[0].Value = AttachID;
            sqlPara[1] = new SqlParameter("@Name", SqlDbType.NVarChar);
            sqlPara[1].Value = Name;
            sqlPara[2] = new SqlParameter("@Description", SqlDbType.NVarChar);
            sqlPara[3].Value = Description;
            sqlPara[3] = new SqlParameter("@Path", SqlDbType.NVarChar);
            sqlPara[3].Value = Path;

            return RunProcudure("sp_tblAttach_update", sqlPara);
        }

        public IList<OAttach> Get(int AttachID)
        {
            SqlParameter[] sqlPara = new SqlParameter[1];
            sqlPara[0] = new SqlParameter("@AttachID", SqlDbType.Int);
            sqlPara[0].Value = AttachID;
            DataTable tbl = RunProcedureGet("sp_tblAttach_get", sqlPara);
            IList<OAttach> list = new List<OAttach>();
            list = Common.Common.ConvertTo<OAttach>(tbl);
            return list;
        }

        public IList<OAttach> GetLast()
        {
            
            DataTable tbl = RunProcedureGet("sp_tblAttach_getlast");

            IList<OAttach> list = new List<OAttach>();
            list = Common.Common.ConvertTo<OAttach>(tbl);
            return list;
        }

        /// <summary>
        /// Lấy danh sách file Attach
        /// </summary>
        /// <param name="strAttachID"></param>
        /// <returns></returns>
        public List<OAttach> GetAttachs(string strAttachID)
        {
            if ((strAttachID == "") || (strAttachID == ","))
            {
                return null;
            }
            else
            {
                String[] arrattachs = strAttachID.Split(',');
                List<OAttach> lstAttachs = new List<OAttach>();
                BAttach objBAttach = new BAttach();
                if (arrattachs.Count() > 1)
                {
                    for (int i = 1; i < arrattachs.Count() - 1; i++)
                    {
                        OAttach objAttach = objBAttach.Get(int.Parse(arrattachs[i])).First();
                        lstAttachs.Add(objAttach);
                    }
                }
                return lstAttachs;
            }
        }

    }
}
