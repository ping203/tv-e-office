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
    public class BWork:Common.CDBase
    {
        public bool Add(OWork obj)
        {
            SqlParameter[] sqlPara = new SqlParameter[12];
            sqlPara[0] = new SqlParameter("@Name", SqlDbType.NVarChar);
            sqlPara[0].Value = obj.Name;
            sqlPara[1] = new SqlParameter("@Description", SqlDbType.NVarChar);
            sqlPara[1].Value = obj.Description;
            sqlPara[2] = new SqlParameter("@Content", SqlDbType.NVarChar);
            sqlPara[2].Value = obj.Content;
            sqlPara[3] = new SqlParameter("@Attachs", SqlDbType.VarChar);
            sqlPara[3].Value = obj.Attachs;
            sqlPara[4] = new SqlParameter("@IDUserCreate", SqlDbType.Int);
            sqlPara[4].Value = obj.IDUserCreate;
            sqlPara[5] = new SqlParameter("@IDUserProcess", SqlDbType.VarChar);
            sqlPara[5].Value = obj.IDUserProcess;
            sqlPara[6] = new SqlParameter("@CreateDate", SqlDbType.DateTime);
            sqlPara[6].Value = obj.CreateDate;
            sqlPara[7] = new SqlParameter("@StartProcess", SqlDbType.DateTime);
            sqlPara[7].Value = obj.StartProcess;
            sqlPara[8] = new SqlParameter("@EndProcess", SqlDbType.DateTime);
            sqlPara[8].Value = obj.EndProcess;
            sqlPara[9] = new SqlParameter("@Status", SqlDbType.VarChar);
            sqlPara[9].Value = obj.Status;
            sqlPara[10] = new SqlParameter("@Priority", SqlDbType.VarChar);
            sqlPara[10].Value = obj.Priority;
            sqlPara[11] = new SqlParameter("@IDWorkGroup",SqlDbType.Int);
            sqlPara[11].Value = obj.IDWorkGroup;


            return RunProcudure("sp_tblWork_add", sqlPara);
        }

        public bool Update(int WorkID, string Name, string Description, string Content, string Attachs, int IDUserCreate, string IDUserProcess, DateTime CreateDate, DateTime StartProcess, DateTime EndProcess, string Status, string Priority, int IDWorkGroup)
        {
            SqlParameter[] sqlPara = new SqlParameter[13];
            sqlPara[0] = new SqlParameter("@WorkID", SqlDbType.Int);
            sqlPara[0].Value = WorkID;
            sqlPara[1] = new SqlParameter("@Name", SqlDbType.NVarChar);
            sqlPara[1].Value = Name;
            sqlPara[2] = new SqlParameter("@Description", SqlDbType.NVarChar);
            sqlPara[2].Value = Description;
            sqlPara[3] = new SqlParameter("@Content", SqlDbType.NVarChar);
            sqlPara[3].Value = Content;
            sqlPara[4] = new SqlParameter("@Attachs", SqlDbType.VarChar);
            sqlPara[4].Value = Attachs;
            sqlPara[5] = new SqlParameter("@IDUserCreate", SqlDbType.Int);
            sqlPara[5].Value = IDUserCreate;
            sqlPara[6] = new SqlParameter("@IDUserProcess", SqlDbType.VarChar);
            sqlPara[6].Value = IDUserProcess;
            sqlPara[7] = new SqlParameter("@CreateDate", SqlDbType.DateTime);
            sqlPara[7].Value = CreateDate;
            sqlPara[8] = new SqlParameter("@StartProcess", SqlDbType.DateTime);
            sqlPara[8].Value = StartProcess;
            sqlPara[9] = new SqlParameter("@EndProcess", SqlDbType.DateTime);
            sqlPara[9].Value = EndProcess;
            sqlPara[10] = new SqlParameter("@Status", SqlDbType.VarChar);
            sqlPara[10].Value =Status;
            sqlPara[11] = new SqlParameter("@Priority", SqlDbType.VarChar);
            sqlPara[11].Value = Priority;
            sqlPara[12] = new SqlParameter("@IDWorkGroup", SqlDbType.Int);
            sqlPara[12].Value = IDWorkGroup;

            return RunProcudure("sp_tblWork_update", sqlPara);
        }

        public bool Update(int WorkID, string Name, string Description, string Content, string Attachs)
        {
            SqlParameter[] sqlPara = new SqlParameter[5];
            sqlPara[0] = new SqlParameter("@WorkID", SqlDbType.Int);
            sqlPara[0].Value = WorkID;
            sqlPara[1] = new SqlParameter("@Name", SqlDbType.NVarChar);
            sqlPara[1].Value = Name;
            sqlPara[2] = new SqlParameter("@Description", SqlDbType.NVarChar);
            sqlPara[2].Value = Description;
            sqlPara[3] = new SqlParameter("@Content", SqlDbType.NVarChar);
            sqlPara[3].Value = Content;
            sqlPara[4] = new SqlParameter("@Attachs", SqlDbType.VarChar);
            sqlPara[4].Value = Attachs;
            

            return RunProcudure("sp_tblWork_update", sqlPara);
        }

        public bool Update(int WorkID,int IDUserCreate)
        {
            SqlParameter[] sqlPara = new SqlParameter[2];
            sqlPara[0] = new SqlParameter("@WorkID", SqlDbType.Int);
            sqlPara[0].Value = WorkID;
            
            sqlPara[1] = new SqlParameter("@IDUserCreate", SqlDbType.Int);
            sqlPara[1].Value = IDUserCreate;
            

            return RunProcudure("sp_tblWork_update", sqlPara);
        }

        public bool Delete(int WorkID)
        {
            SqlParameter[] sqlPara = new SqlParameter[1];
            sqlPara[0] = new SqlParameter("@WorkID", SqlDbType.Int);
            sqlPara[0].Value = WorkID;

            return RunProcudure("sp_tblWork_delete", sqlPara);
        }

        public IList<OWork> Get(int WorkID)
        {
            SqlParameter[] sqlPara = new SqlParameter[1];
            sqlPara[0] = new SqlParameter("@WorkID", SqlDbType.Int);
            sqlPara[0].Value = WorkID;
            DataTable tbl = RunProcedureGet("sp_tblWork_get", sqlPara);
            IList<OWork> list = new List<OWork>();
            list = Common.Common.ConvertTo<OWork>(tbl);
            return list;
        }

        public IList<OWork> Get(int WorkID,string Name)
        {
            SqlParameter[] sqlPara = new SqlParameter[2];
            sqlPara[0] = new SqlParameter("@WorkID", SqlDbType.Int);
            sqlPara[0].Value = WorkID;
            sqlPara[1] = new SqlParameter("@Name", SqlDbType.NVarChar);
            sqlPara[1].Value = Name;
            DataTable tbl = RunProcedureGet("sp_tblWork_get", sqlPara);
            IList<OWork> list = new List<OWork>();
            list = Common.Common.ConvertTo<OWork>(tbl);
            return list;
        }

    }
}
