﻿using System;
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

        /// <summary>
        /// Update trạng thái công việc
        /// </summary>
        /// <param name="WorkID"></param>
        /// <param name="Status"></param>
        /// <returns></returns>
        public bool Update(int WorkID, string Status, int IDUserCreate)
        {
            SqlParameter[] sqlPara = new SqlParameter[3];
            sqlPara[0] = new SqlParameter("@WorkID", SqlDbType.Int);
            sqlPara[0].Value = WorkID;

            sqlPara[1] = new SqlParameter("@Status", SqlDbType.VarChar);
            sqlPara[1].Value = Status;

            sqlPara[2] = new SqlParameter("@IDUserCreate", SqlDbType.Int);
            sqlPara[2].Value = IDUserCreate;

            return RunProcudure("sp_tblWork_update", sqlPara);
        }

        public bool Delete(int WorkID)
        {
            SqlParameter[] sqlPara = new SqlParameter[1];
            sqlPara[0] = new SqlParameter("@WorkID", SqlDbType.Int);
            sqlPara[0].Value = WorkID;

            return RunProcudure("sp_tblWork_delete", sqlPara);
        }

        public IList<OWork> GetWork(int WorkID)
        {
            SqlParameter[] sqlPara = new SqlParameter[1];
            sqlPara[0] = new SqlParameter("@WorkID", SqlDbType.Int);
            sqlPara[0].Value = WorkID;
            DataTable tbl = RunProcedureGet("sp_tblWork_get", sqlPara);
            IList<OWork> list = new List<OWork>();
            list = Common.Common.ConvertTo<OWork>(tbl);
            return list;
        }

        public IList<OWork> Get(int IDUserCreate)
        {
            SqlParameter[] sqlPara = new SqlParameter[1];
            sqlPara[0] = new SqlParameter("@IDUserCreate", SqlDbType.Int);
            sqlPara[0].Value = IDUserCreate;
            DataTable tbl = RunProcedureGet("sp_tblWork_get", sqlPara);
            IList<OWork> list = new List<OWork>();
            list = Common.Common.ConvertTo<OWork>(tbl);
            return list;
        }

        /// <summary>
        /// Hàm lấy ra danh sách công việc tương ứng với người tạo và trạng thái công việc giao
        /// </summary>
        /// <param name="IDUserCreate"></param>
        /// <param name="Status"></param>
        /// <returns></returns>
        public IList<OWork> Get(int IDUserCreate,string Status)
        {
            SqlParameter[] sqlPara = new SqlParameter[2];
            sqlPara[0] = new SqlParameter("@IDUserCreate", SqlDbType.Int);
            sqlPara[0].Value = IDUserCreate;
            sqlPara[1] = new SqlParameter("@Status", SqlDbType.VarChar);
            sqlPara[1].Value = Status;
            DataTable tbl = RunProcedureGet("sp_tblWork_get", sqlPara);
            IList<OWork> list = new List<OWork>();
            list = Common.Common.ConvertTo<OWork>(tbl);
            return list;
        }

        /// <summary>
        /// Trả lại danh sách công việc tương ứng với người tạo, tên công việc
        /// Trạng thái công việc giao, nhóm công việc và người thực hiện
        /// </summary>
        /// <param name="IDUserCreate"></param>
        /// <param name="Name"></param>
        /// <param name="Status"></param>
        /// <param name="IDWorkGroup"></param>
        /// <param name="IDUserProcess"></param>
        /// <returns></returns>
        public IList<OWork> Get(int IDUserCreate,string Name, string Status, int IDWorkGroup,string IDUserProcess)
        {
            SqlParameter[] sqlPara = new SqlParameter[5];
            sqlPara[0] = new SqlParameter("@IDUserCreate", SqlDbType.Int);
            sqlPara[0].Value = IDUserCreate;
            sqlPara[1] = new SqlParameter("@Name", SqlDbType.NVarChar);
            sqlPara[1].Value = Name;
            sqlPara[2] = new SqlParameter("@Status", SqlDbType.VarChar);
            sqlPara[2].Value = Status;
            sqlPara[3] = new SqlParameter("@IDWorkGroup", SqlDbType.Int);
            sqlPara[3].Value = IDWorkGroup;
            sqlPara[4] = new SqlParameter("@IDUserProcess", SqlDbType.VarChar);
            sqlPara[4].Value = IDUserProcess;
            DataTable tbl = RunProcedureGet("sp_tblWork_get", sqlPara);
            IList<OWork> list = new List<OWork>();
            list = Common.Common.ConvertTo<OWork>(tbl);
            return list;
        }

        /// <summary>
        /// Trả lại danh sách công việc tương ứng với người tạo, tên công việc
        /// Trạng thái công việc giao, và người thực hiện
        /// </summary>
        /// <param name="IDUserCreate"></param>
        /// <param name="Name"></param>
        /// <param name="Status"></param>
        /// <param name="IDWorkGroup"></param>
        /// <param name="IDUserProcess"></param>
        /// <returns></returns>
        public IList<OWork> Get(int IDUserCreate, string Name, string Status, string IDUserProcess)
        {
            SqlParameter[] sqlPara = new SqlParameter[4];
            sqlPara[0] = new SqlParameter("@IDUserCreate", SqlDbType.Int);
            sqlPara[0].Value = IDUserCreate;
            sqlPara[1] = new SqlParameter("@Name", SqlDbType.NVarChar);
            sqlPara[1].Value = Name;
            sqlPara[2] = new SqlParameter("@Status", SqlDbType.VarChar);
            sqlPara[2].Value = Status;
            sqlPara[3] = new SqlParameter("@IDUserProcess", SqlDbType.VarChar);
            sqlPara[3].Value = IDUserProcess;
            DataTable tbl = RunProcedureGet("sp_tblWork_get", sqlPara);
            IList<OWork> list = new List<OWork>();
            list = Common.Common.ConvertTo<OWork>(tbl);
            return list;
        }

        /// <summary>
        /// Trả lại danh sách công việc mà người dùng phải thực hiện
        /// </summary>
        /// <param name="IDUserProcess"></param>
        /// <returns></returns>
        public IList<OWork> Get(string IDUserProcess)
        {
            SqlParameter[] sqlPara = new SqlParameter[1];
            
            sqlPara[0] = new SqlParameter("@IDUserProcess", SqlDbType.VarChar);
            sqlPara[0].Value = IDUserProcess;
            DataTable tbl = RunProcedureGet("sp_tblWork_get", sqlPara);
            IList<OWork> list = new List<OWork>();
            list = Common.Common.ConvertTo<OWork>(tbl);
            return list;
        }
       
    }
}
