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
    public class BDocument:Common.CDBase
    {
        public bool Add(ODocument obj)
        {
            SqlParameter[] sqlPara = new SqlParameter[20];
            sqlPara[0] = new SqlParameter("@DocumentID", SqlDbType.VarChar);
            sqlPara[0].Value = obj.DocumentID;
            sqlPara[1] = new SqlParameter("@DocumentNumber", SqlDbType.NVarChar);
            sqlPara[1].Value = obj.DocumentNumber;
            sqlPara[2] = new SqlParameter("@Name", SqlDbType.NVarChar);
            sqlPara[2].Value = obj.Name;
            sqlPara[3] = new SqlParameter("@Excerpt", SqlDbType.NVarChar);
            sqlPara[3].Value = obj.Excerpt;
            sqlPara[4] = new SqlParameter("@Content", SqlDbType.NVarChar);
            sqlPara[4].Value = obj.Content;
            sqlPara[5] = new SqlParameter("@PublishDate", SqlDbType.DateTime);
            sqlPara[5].Value = obj.PublishDate;
            sqlPara[6] = new SqlParameter("@PublishOffical", SqlDbType.Int);
            sqlPara[6].Value = obj.PublishOffical;
            sqlPara[7] = new SqlParameter("@Attachs", SqlDbType.VarChar);
            sqlPara[7].Value = obj.Attachs;
            sqlPara[8] = new SqlParameter("@IDDocumentKind", SqlDbType.Int);
            sqlPara[8].Value = obj.IDDocumentKind;
            sqlPara[9] = new SqlParameter("@CreateDate", SqlDbType.DateTime);
            sqlPara[9].Value = obj.CreateDate;
            sqlPara[10] = new SqlParameter("@IDUserCreate", SqlDbType.Int);
            sqlPara[10].Value = obj.IDUserCreate;
            sqlPara[11] = new SqlParameter("@UserProcess", SqlDbType.VarChar);
            sqlPara[11].Value = obj.UserProcess;
            sqlPara[12] = new SqlParameter("@UserComments", SqlDbType.VarChar);
            sqlPara[12].Value = obj.UserComments;
            sqlPara[13] = new SqlParameter("@StartProcess", SqlDbType.DateTime);
            sqlPara[13].Value = obj.StartProcess;
            sqlPara[14] = new SqlParameter("@EndProcess", SqlDbType.DateTime);
            sqlPara[14].Value = obj.EndProcess;
            sqlPara[15] = new SqlParameter("@SendDate", SqlDbType.DateTime);
            sqlPara[15].Value = obj.SendDate;
            sqlPara[16] = new SqlParameter("@ReceiveDate", SqlDbType.DateTime);
            sqlPara[16].Value = obj.ReceiveDate;
            sqlPara[17] = new SqlParameter("@SendOfficals", SqlDbType.VarChar);
            sqlPara[17].Value = obj.SendOfficals;
            sqlPara[18] = new SqlParameter("@Priority", SqlDbType.VarChar);
            sqlPara[18].Value = obj.Priority;
            sqlPara[19] = new SqlParameter("@Status", SqlDbType.VarChar);
            sqlPara[19].Value = obj.Status;

            return RunProcudure("sp_tblDocument_add", sqlPara);
        }

        public bool Update(string DocumentID,string DocumentNumber,string Name,string Excerpt,string Content,DateTime PublishDate,int PublishOffical,string Attachs,int IDDocumentKind,DateTime CreateDate,string UserProcess,string UserComments,DateTime StartProcess,DateTime EndProcess,DateTime SendDate,DateTime ReceiveDate,string SendOfficals,string Priority,string Status)
        {
            SqlParameter[] sqlPara = new SqlParameter[19];
            sqlPara[0] = new SqlParameter("@DocumentID", SqlDbType.VarChar);
            sqlPara[0].Value = DocumentID;
            sqlPara[1] = new SqlParameter("@DocumentNumber", SqlDbType.NVarChar);
            sqlPara[1].Value = DocumentNumber;
            sqlPara[2] = new SqlParameter("@Name", SqlDbType.NVarChar);
            sqlPara[2].Value = Name;
            sqlPara[3] = new SqlParameter("@Excerpt", SqlDbType.NVarChar);
            sqlPara[3].Value = Excerpt;
            sqlPara[4] = new SqlParameter("@Content", SqlDbType.NVarChar);
            sqlPara[4].Value = Content;
            sqlPara[5] = new SqlParameter("@PublishDate", SqlDbType.DateTime);
            sqlPara[5].Value = PublishDate;
            sqlPara[6] = new SqlParameter("@PublishOffical", SqlDbType.Int);
            sqlPara[6].Value = PublishOffical;
            sqlPara[7] = new SqlParameter("@Attachs", SqlDbType.VarChar);
            sqlPara[7].Value = Attachs;
            sqlPara[8] = new SqlParameter("@IDDocumentKind", SqlDbType.Int);
            sqlPara[8].Value = IDDocumentKind;
            sqlPara[9] = new SqlParameter("@CreateDate", SqlDbType.DateTime);
            sqlPara[9].Value = CreateDate;            
            sqlPara[10] = new SqlParameter("@UserProcess", SqlDbType.VarChar);
            sqlPara[10].Value = UserProcess;
            sqlPara[11] = new SqlParameter("@UserComments", SqlDbType.VarChar);
            sqlPara[11].Value = UserComments;
            sqlPara[12] = new SqlParameter("@StartProcess", SqlDbType.DateTime);
            sqlPara[12].Value = StartProcess;
            sqlPara[13] = new SqlParameter("@EndProcess", SqlDbType.DateTime);
            sqlPara[13].Value = EndProcess;
            sqlPara[14] = new SqlParameter("@SendDate", SqlDbType.DateTime);
            sqlPara[14].Value = SendDate;
            sqlPara[15] = new SqlParameter("@ReceiveDate", SqlDbType.DateTime);
            sqlPara[15].Value = ReceiveDate;
            sqlPara[16] = new SqlParameter("@SendOfficals", SqlDbType.VarChar);
            sqlPara[16].Value = SendOfficals;
            sqlPara[17] = new SqlParameter("@Priority", SqlDbType.VarChar);
            sqlPara[17].Value = Priority;
            sqlPara[18] = new SqlParameter("@Status", SqlDbType.VarChar);
            sqlPara[18].Value = Status;

            return RunProcudure("sp_tblDocument_update", sqlPara);
        }

        public bool Delete(string DocumentID)
        {
            SqlParameter[] sqlPara = new SqlParameter[1];
            sqlPara[0] = new SqlParameter("@DocumentID", SqlDbType.VarChar);
            sqlPara[0].Value = DocumentID;

            return RunProcudure("sp_tblDocument_delete", sqlPara);
        }

        public IList<ODocument> Get(string DocumentID)
        {
            SqlParameter[] sqlPara = new SqlParameter[1];
            sqlPara[0] = new SqlParameter("@DocumentID", SqlDbType.VarChar);
            sqlPara[0].Value = DocumentID;
            DataTable tbl = RunProcedureGet("sp_tblDocument_get", sqlPara);
            IList<ODocument> list = new List<ODocument>();
            list = Common.Common.ConvertTo<ODocument>(tbl);
            return list;
        }

        public IList<ODocument> Get(string Name)
        {
            SqlParameter[] sqlPara = new SqlParameter[1];
            sqlPara[0] = new SqlParameter("@Name", SqlDbType.NVarChar);
            sqlPara[0].Value = Name;
            DataTable tbl = RunProcedureGet("sp_tblDocument_get", sqlPara);
            IList<ODocument> list = new List<ODocument>();
            list = Common.Common.ConvertTo<ODocument>(tbl);
            return list;
        }
    }
}
