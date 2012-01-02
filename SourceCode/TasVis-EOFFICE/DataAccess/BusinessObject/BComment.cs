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
    public class BComment:Common.CDBase
    {
        public bool Add(OComment obj)
        {
            SqlParameter[] sqlPara = new SqlParameter[8];
            sqlPara[0] = new SqlParameter("@CommentID", SqlDbType.VarChar);
            sqlPara[0].Value = obj.CommentID;
            sqlPara[1] = new SqlParameter("@Title", SqlDbType.NVarChar);
            sqlPara[1].Value = obj.Title;
            sqlPara[2] = new SqlParameter("@Content", SqlDbType.NVarChar);
            sqlPara[2].Value = obj.Content;
            sqlPara[3] = new SqlParameter("@IDUserCreate", SqlDbType.Int);
            sqlPara[3].Value = obj.IDUserCreate;
            sqlPara[4] = new SqlParameter("@IDDocument", SqlDbType.VarChar);
            sqlPara[4].Value = obj.IDDocument;
            sqlPara[5] = new SqlParameter("@IDWork", SqlDbType.Int);
            sqlPara[5].Value = obj.IDWork;
            sqlPara[6] = new SqlParameter("@Attachs", SqlDbType.VarChar);
            sqlPara[6].Value = obj.Attachs;
            sqlPara[7] = new SqlParameter("@CreateDate", SqlDbType.DateTime);
            sqlPara[7].Value = obj.CreateDate;

            return RunProcudure("sp_tblComment_add", sqlPara);
        }

        public bool Update(string CommentID,string Title,string Content,int IDUserCreate,string IDDocument,int IDWork,string Attachs,DateTime CreateDate)
        {
            SqlParameter[] sqlPara = new SqlParameter[8];
            sqlPara[0] = new SqlParameter("@CommentID", SqlDbType.VarChar);
            sqlPara[0].Value = CommentID;
            sqlPara[1] = new SqlParameter("@Title", SqlDbType.NVarChar);
            sqlPara[1].Value = Title;
            sqlPara[2] = new SqlParameter("@Content", SqlDbType.NVarChar);
            sqlPara[2].Value = Content;
            sqlPara[3] = new SqlParameter("@IDUserCreate", SqlDbType.Int);
            sqlPara[3].Value = IDUserCreate;
            sqlPara[4] = new SqlParameter("@IDDocument", SqlDbType.VarChar);
            sqlPara[4].Value = IDDocument;
            sqlPara[5] = new SqlParameter("@IDWork", SqlDbType.Int);
            sqlPara[5].Value = IDWork;
            sqlPara[6] = new SqlParameter("@Attachs", SqlDbType.VarChar);
            sqlPara[6].Value = Attachs;
            sqlPara[7] = new SqlParameter("@CreateDate", SqlDbType.DateTime);
            sqlPara[7].Value = CreateDate;

            return RunProcudure("sp_tblComment_update", sqlPara);
        }

        public bool Delete(string CommentID)
        {
            SqlParameter[] sqlPara = new SqlParameter[1];
            sqlPara[0] = new SqlParameter("@CommentID", SqlDbType.VarChar);
            sqlPara[0].Value = CommentID;

            return RunProcudure("sp_tblComment_delete", sqlPara);
        }

        public IList<OComment> Get(string CommentID)
        {
            SqlParameter[] sqlPara = new SqlParameter[1];
            sqlPara[0] = new SqlParameter("@CommentID", SqlDbType.VarChar);
            sqlPara[0].Value = CommentID;
            DataTable tbl = RunProcedureGet("sp_tblComment_get", sqlPara);
            IList<OComment> list = new List<OComment>();
            list = Common.Common.ConvertTo<OComment>(tbl);
            return list;
        }

        public IList<OComment> Get(string CommentID,string Title)
        {
            SqlParameter[] sqlPara = new SqlParameter[2];
            sqlPara[0] = new SqlParameter("@CommentID", SqlDbType.VarChar);
            sqlPara[0].Value = CommentID;
            sqlPara[1] = new SqlParameter("@Title", SqlDbType.NVarChar);
            sqlPara[1].Value = Title;
            DataTable tbl = RunProcedureGet("sp_tblComment_get", sqlPara);
            IList<OComment> list = new List<OComment>();
            list = Common.Common.ConvertTo<OComment>(tbl);
            return list;
        }

        public IList<OComment> Get(int IDUserCreate)
        {
            SqlParameter[] sqlPara = new SqlParameter[1];
            sqlPara[0] = new SqlParameter("@IDUserCreate", SqlDbType.Int);
            sqlPara[0].Value = IDUserCreate;
            DataTable tbl = RunProcedureGet("sp_tblComment_get", sqlPara);
            IList<OComment> list = new List<OComment>();
            list = Common.Common.ConvertTo<OComment>(tbl);
            return list;
        }

        public IList<OComment> Get(string Title,string IDDocument, string IDWork)
        {
            SqlParameter[] sqlPara = new SqlParameter[3];
            sqlPara[0] = new SqlParameter("@Title", SqlDbType.NVarChar);
            sqlPara[0].Value = Title;
            sqlPara[1] = new SqlParameter("@IDDocument", SqlDbType.VarChar);
            sqlPara[1].Value = IDDocument;
            sqlPara[2] = new SqlParameter("@IDWork", SqlDbType.Int);
            sqlPara[2].Value = IDWork;
            DataTable tbl = RunProcedureGet("sp_tblComment_get", sqlPara);
            IList<OComment> list = new List<OComment>();
            list = Common.Common.ConvertTo<OComment>(tbl);
            return list;
        }        

        public IList<OComment> Get(string Title,int IDUserCreate)
        {
            SqlParameter[] sqlPara = new SqlParameter[2];
            sqlPara[0] = new SqlParameter("@Title", SqlDbType.NVarChar);
            sqlPara[0].Value = Title;
            sqlPara[0] = new SqlParameter("@IDUserCreate", SqlDbType.Int);
            sqlPara[0].Value = IDUserCreate;
            DataTable tbl = RunProcedureGet("sp_tblComment_get", sqlPara);
            IList<OComment> list = new List<OComment>();
            list = Common.Common.ConvertTo<OComment>(tbl);
            return list;
        }
    }
}
