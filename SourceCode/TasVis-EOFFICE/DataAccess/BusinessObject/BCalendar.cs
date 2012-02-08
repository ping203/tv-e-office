using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess.Common;
using DataAccess.DataObject;
using System.Data;
using System.Data.SqlClient;
namespace DataAccess.BusinessObject
{
    public class BCalendar:Common.CDBase
    {
        public bool Add(OCalendar obj)
        {
            SqlParameter[] sqlPara = new SqlParameter[7];
            sqlPara[0] = new SqlParameter("@Name", SqlDbType.NVarChar);
            sqlPara[0].Value = obj.Name;
            sqlPara[1] = new SqlParameter("@Content", SqlDbType.NVarChar);
            sqlPara[1].Value = obj.Content;
            sqlPara[2] = new SqlParameter("@StartDate", SqlDbType.DateTime);
            sqlPara[2].Value = obj.StartDate;
            sqlPara[3] = new SqlParameter("@EndDate", SqlDbType.DateTime);
            sqlPara[3].Value = obj.EndDate;
            sqlPara[4] = new SqlParameter("@UserJoin", SqlDbType.VarChar);
            sqlPara[4].Value = obj.UserJoin;
            sqlPara[5] = new SqlParameter("@Address", SqlDbType.NVarChar);
            sqlPara[5].Value = obj.Address;
            sqlPara[6] = new SqlParameter("@UserCreate", SqlDbType.Int);
            sqlPara[6].Value = obj.UserCreate;
            return RunProcudure("sp_tblCalendar_add", sqlPara);
        }

        public bool Update(int CalenderID, string Name, string Content, DateTime StartDate, DateTime EndDate, string UserJoin, string Address)
        {
            SqlParameter[] sqlPara = new SqlParameter[7];
            sqlPara[0] = new SqlParameter("@CalendarID", SqlDbType.Int);
            sqlPara[0].Value = CalenderID;
            sqlPara[1] = new SqlParameter("@Name", SqlDbType.NVarChar);
            sqlPara[1].Value = Name;
            sqlPara[2] = new SqlParameter("@Content", SqlDbType.NVarChar);
            sqlPara[2].Value = Content;
            sqlPara[3] = new SqlParameter("@StartDate", SqlDbType.DateTime);
            sqlPara[3].Value = StartDate;
            sqlPara[4] = new SqlParameter("@EndDate", SqlDbType.DateTime);
            sqlPara[4].Value = EndDate;
            sqlPara[5] = new SqlParameter("@UserJoin", SqlDbType.VarChar);
            sqlPara[5].Value = UserJoin;
            sqlPara[6] = new SqlParameter("@Address", SqlDbType.NVarChar);
            sqlPara[6].Value = Address;

            return RunProcudure("sp_tblCalendar_update", sqlPara);
        }

        public bool Delete(int CalenderID)
        {
            SqlParameter[] sqlPara = new SqlParameter[1];
            sqlPara[0] = new SqlParameter("@CalendarID", SqlDbType.Int);
            sqlPara[0].Value = CalenderID;

            return RunProcudure("sp_tblCalendar_delete", sqlPara);
        }

        public IList<OCalendar> Get(int CalenderID)
        {
            SqlParameter[] sqlPara = new SqlParameter[1];
            sqlPara[0] = new SqlParameter("@CalendarID", SqlDbType.Int);
            sqlPara[0].Value = CalenderID;
            DataTable tbl = RunProcedureGet("sp_tblCalendar_get", sqlPara);
            IList<OCalendar> list = new List<OCalendar>();
            list = Common.Common.ConvertTo<OCalendar>(tbl);
            return list;
        }

        public IList<OCalendar> Get(int CalenderID,string UserJoin)
        {
            SqlParameter[] sqlPara = new SqlParameter[2];
            sqlPara[0] = new SqlParameter("@CalendarID", SqlDbType.Int);
            sqlPara[0].Value = CalenderID;
            sqlPara[1] = new SqlParameter("@UserJoin", SqlDbType.VarChar);
            sqlPara[1].Value = UserJoin;
            DataTable tbl = RunProcedureGet("sp_tblCalendar_get", sqlPara);
            IList<OCalendar> list = new List<OCalendar>();
            list = Common.Common.ConvertTo<OCalendar>(tbl);
            return list;
        }

        public IList<OCalendar> GetCreate(int CalenderID, int UserCreate)
        {
            SqlParameter[] sqlPara = new SqlParameter[2];
            sqlPara[0] = new SqlParameter("@CalendarID", SqlDbType.Int);
            sqlPara[0].Value = CalenderID;
            sqlPara[1] = new SqlParameter("@UserCreate", SqlDbType.Int);
            sqlPara[1].Value = UserCreate;
            DataTable tbl = RunProcedureGet("sp_tblCalendar_get", sqlPara);
            IList<OCalendar> list = new List<OCalendar>();
            list = Common.Common.ConvertTo<OCalendar>(tbl);
            return list;
        }       
    }
}
