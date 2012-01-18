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
    public class BContactGroup:Common.CDBase
    {
        public bool Add(OContactGroup obj)
        {
            SqlParameter[] sqlPara = new SqlParameter[3];
            sqlPara[0] = new SqlParameter("@GroupName", SqlDbType.NVarChar);
            sqlPara[0].Value = obj.GroupName;
            sqlPara[1] = new SqlParameter("@Description", SqlDbType.NVarChar);
            sqlPara[1].Value = obj.Description;
            sqlPara[2] = new SqlParameter("@IDUser", SqlDbType.Int);
            sqlPara[2].Value = obj.IDUser;


            return RunProcudure("sp_tblContactGroup_add", sqlPara);
        }

        public bool Delete(int ContactGroupID)
        {
            SqlParameter[] sqlPara = new SqlParameter[1];
            sqlPara[0] = new SqlParameter("@ContactGroupID", SqlDbType.Int);
            sqlPara[0].Value = ContactGroupID;

            return RunProcudure("sp_tblContactGroup_delete", sqlPara);
        }

        public bool Update(int ContactGroupID,string GroupName,string Description)
        {
            SqlParameter[] sqlPara = new SqlParameter[3];
            sqlPara[0] = new SqlParameter("@ContactGroupID", SqlDbType.Int);
            sqlPara[0].Value = ContactGroupID;
            sqlPara[1] = new SqlParameter("@GroupName", SqlDbType.NVarChar);
            sqlPara[1].Value = GroupName;
            sqlPara[2] = new SqlParameter("@Description", SqlDbType.NVarChar);
            sqlPara[2].Value = Description;

            return RunProcudure("sp_tblContactGroup_update", sqlPara);
        }


        /// <summary>
        /// Lấy ContactGroup theo ID
        /// </summary>
        /// <param name="ContactGroupID"></param>
        /// <returns></returns>
        public IList<OContactGroup> Get(int ContactGroupID)
        {
            SqlParameter[] sqlPara = new SqlParameter[1];
            sqlPara[0] = new SqlParameter("@ContactGroupID", SqlDbType.Int);
            sqlPara[0].Value = ContactGroupID;
            DataTable tbl = RunProcedureGet("sp_tblContactGroup_get", sqlPara);
            IList<OContactGroup> list = new List<OContactGroup>();
            list = Common.Common.ConvertTo<OContactGroup>(tbl);
            return list;
        }


        /// <summary>
        /// Lấy ContactGroup theo người tạo
        /// </summary>
        /// <param name="IDUser"></param>
        /// <returns></returns>
        public IList<OContactGroup> GetByUser(int IDUser)
        {
            SqlParameter[] sqlPara = new SqlParameter[1];
            sqlPara[0] = new SqlParameter("@IDUser", SqlDbType.Int);
            sqlPara[0].Value = IDUser;
            DataTable tbl = RunProcedureGet("sp_tblContactGroup_get", sqlPara);
            IList<OContactGroup> list = new List<OContactGroup>();
            list = Common.Common.ConvertTo<OContactGroup>(tbl);
            return list;
        }
    }
}
