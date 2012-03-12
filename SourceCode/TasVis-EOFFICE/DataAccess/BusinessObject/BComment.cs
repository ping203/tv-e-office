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
            sqlPara[3] = new SqlParameter("@IDUserCreate", SqlDbType.VarChar);
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

        public bool Update(string CommentID,string Title,string Content,string IDUserCreate,string IDDocument,int IDWork,string Attachs,DateTime CreateDate)
        {
            SqlParameter[] sqlPara = new SqlParameter[8];
            sqlPara[0] = new SqlParameter("@CommentID", SqlDbType.VarChar);
            sqlPara[0].Value = CommentID;
            sqlPara[1] = new SqlParameter("@Title", SqlDbType.NVarChar);
            sqlPara[1].Value = Title;
            sqlPara[2] = new SqlParameter("@Content", SqlDbType.NVarChar);
            sqlPara[2].Value = Content;
            sqlPara[3] = new SqlParameter("@IDUserCreate", SqlDbType.VarChar);
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

        public IList<OComment> GetCreate(string IDUserCreate)
        {
            SqlParameter[] sqlPara = new SqlParameter[1];
            sqlPara[0] = new SqlParameter("@IDUserCreate", SqlDbType.VarChar);
            sqlPara[0].Value = IDUserCreate;
            DataTable tbl = RunProcedureGet("sp_tblComment_get", sqlPara);
            IList<OComment> list = new List<OComment>();
            list = Common.Common.ConvertTo<OComment>(tbl);
            return list;
        }

        public IList<OComment> GetCreate(string IDUserCreate,int IDWork)
        {
            SqlParameter[] sqlPara = new SqlParameter[2];
            sqlPara[0] = new SqlParameter("@IDUserCreate", SqlDbType.VarChar);
            sqlPara[0].Value = IDUserCreate;
            sqlPara[1] = new SqlParameter("@IDWork", SqlDbType.Int);
            sqlPara[1].Value = IDWork;
            DataTable tbl = RunProcedureGet("sp_tblComment_get", sqlPara);
            IList<OComment> list = new List<OComment>();
            list = Common.Common.ConvertTo<OComment>(tbl);
            return list;
        }


        public IList<OComment> Get(string Title,string IDDocument, int IDWork)
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

        public List<OAttach> GetAttachs(string CommentID)
        {
            IList<OComment> lstComment = this.Get(CommentID);
            string strAttachID = lstComment[0].Attachs;
            if ((strAttachID == "") || (strAttachID == ",")||(strAttachID==",,"))
            {
                return new List<OAttach>();
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
                        //OAttach objAttach = objBAttach.Get(int.Parse(arrattachs[i])).First();
                        foreach (OAttach obj in objBAttach.Get(int.Parse(arrattachs[i])))
                        {
                            lstAttachs.Add(obj);
                        }
                        //lstAttachs.Add(objAttach);
                    }
                }
                return lstAttachs;
            }
            
        }
    }
}
