using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DataAccess.DataObject;


namespace DataAccess.BusinessObject
{
    public class BUser:Common.CDBase
    {
        /// <summary>
        /// Lấy ra danh sách người dùng theo UserName
        /// </summary>
        /// <param name="UserName"></param>
        /// <returns></returns>
         public IList<OUser> Get(string UserName)
         {
             SqlParameter[] sqlPara = new SqlParameter[1];
             sqlPara[0] = new SqlParameter("@UserName", SqlDbType.VarChar);
             sqlPara[0].Value = UserName;
             DataTable tbl = RunProcedureGet("sp_tblUser_get", sqlPara);
             IList<OUser> list = new List<OUser>();
             list = Common.Common.ConvertTo<OUser>(tbl);
             return list;
         }

        /// <summary>
        /// Lấy ra người dùng theo ID
        /// </summary>
        /// <param name="UserID"></param>
        /// <returns></returns>
         public IList<OUser> Get(int UserID)
         {
             SqlParameter[] sqlPara = new SqlParameter[1];
             sqlPara[0] = new SqlParameter("@UserID", SqlDbType.Int);
             sqlPara[0].Value = UserID;
             DataTable tbl = RunProcedureGet("sp_tblUser_get", sqlPara);
             IList<OUser> list = new List<OUser>();
             list = Common.Common.ConvertTo<OUser>(tbl);
             return list;
         }

         public IList<OUser> Get(string FullName, string Order, string OrderBy)
         {
             SqlParameter[] sqlPara = new SqlParameter[3];
             sqlPara[0] = new SqlParameter("@FullName", SqlDbType.NVarChar);
             sqlPara[0].Value = FullName;
             sqlPara[1] = new SqlParameter("@Order",SqlDbType.VarChar);
             sqlPara[1].Value = Order;
             sqlPara[2] = new SqlParameter("@OrderBy", SqlDbType.VarChar);
             sqlPara[2].Value = OrderBy;
             DataTable tbl = RunProcedureGet("sp_tblUser_get", sqlPara);
             IList<OUser> list = new List<OUser>();
             list = Common.Common.ConvertTo<OUser>(tbl);
             
             return list;
         }

         public bool Add(OUser obj)
         {
             SqlParameter[] sqlPara = new SqlParameter[13];
             sqlPara[0] = new SqlParameter("@UserName",SqlDbType.VarChar);
             sqlPara[0].Value = obj.UserName;
             sqlPara[1] = new SqlParameter("@Password", SqlDbType.VarChar);
             sqlPara[1].Value = obj.Password;
             sqlPara[2] = new SqlParameter("@FullName", SqlDbType.NVarChar);
             sqlPara[2].Value = obj.FullName;
             sqlPara[3] = new SqlParameter("@Email", SqlDbType.VarChar);
             sqlPara[3].Value = obj.Email;
             sqlPara[4] = new SqlParameter("@PhoneNumber", SqlDbType.VarChar);
             sqlPara[4].Value = obj.PhoneNumber;
             sqlPara[5] = new SqlParameter("@Tel", SqlDbType.VarChar);
             sqlPara[5].Value = obj.Tel;
             sqlPara[6] = new SqlParameter("@Gender", SqlDbType.VarChar);
             sqlPara[6].Value = obj.Gender;
             sqlPara[7] = new SqlParameter("@BirthDay", SqlDbType.DateTime);
             sqlPara[7].Value = obj.Birthday;
             sqlPara[8] = new SqlParameter("@Address", SqlDbType.NVarChar);
             sqlPara[8].Value = obj.Address;
             sqlPara[9] = new SqlParameter("@Position", SqlDbType.NVarChar);
             sqlPara[9].Value = obj.Position;
             sqlPara[10] = new SqlParameter("@Status", SqlDbType.VarChar);
             sqlPara[10].Value = obj.Status;
             sqlPara[11] = new SqlParameter("@IDDepartment", SqlDbType.Int);
             sqlPara[11].Value = obj.IDDepartment;
             sqlPara[12] = new SqlParameter("@IDGroup", SqlDbType.Int);
             sqlPara[12].Value = obj.IDGroup;

             return RunProcudure("sp_tblUser_add",sqlPara);
         }
         public bool Delete(string UserName)
         {
             SqlParameter[] sqlPara = new SqlParameter[1];
             sqlPara[0] = new SqlParameter("@UserName", SqlDbType.VarChar);
             sqlPara[0].Value = UserName;

             return RunProcudure("sp_tblUser_delete", sqlPara);
         }

         public bool Update(string UserName, string Password)
         {
             SqlParameter[] sqlPara = new SqlParameter[2];
             sqlPara[0] = new SqlParameter("@UserName", SqlDbType.VarChar);
             sqlPara[0].Value = UserName;
             sqlPara[1] = new SqlParameter("@Password", SqlDbType.VarChar);
             sqlPara[1].Value = UserName;

             return RunProcudure("sp_tblUser_update", sqlPara);
         }
         public bool Update(string UserName, string FullName, string Email, string PhoneNumber, string Tel, string Gender, DateTime Birthday, string Address, string Position, string Status, int IDDepartment, int IDGroup)
         {
             SqlParameter[] sqlPara = new SqlParameter[12];
             sqlPara[0] = new SqlParameter("@UserName", SqlDbType.VarChar);
             sqlPara[0].Value = UserName;
             sqlPara[1] = new SqlParameter("@FullName", SqlDbType.NVarChar);
             sqlPara[1].Value = FullName;
             sqlPara[2] = new SqlParameter("@Email", SqlDbType.VarChar);
             sqlPara[2].Value = Email;
             sqlPara[3] = new SqlParameter("@PhoneNumber", SqlDbType.VarChar);
             sqlPara[3].Value = PhoneNumber;
             sqlPara[4] = new SqlParameter("@Tel", SqlDbType.VarChar);
             sqlPara[4].Value = Tel;
             sqlPara[5] = new SqlParameter("@Gender", SqlDbType.VarChar);
             sqlPara[5].Value = Gender;
             sqlPara[6] = new SqlParameter("@BirthDay", SqlDbType.DateTime);
             sqlPara[6].Value = Birthday;
             sqlPara[7] = new SqlParameter("@Address", SqlDbType.NVarChar);
             sqlPara[7].Value = Address;
             sqlPara[8] = new SqlParameter("@Position", SqlDbType.NVarChar);
             sqlPara[8].Value = Position;
             sqlPara[9] = new SqlParameter("@Status", SqlDbType.VarChar);
             sqlPara[9].Value = Status;
             sqlPara[10] = new SqlParameter("@IDDepartment", SqlDbType.Int);
             sqlPara[10].Value = IDDepartment;
             sqlPara[11] = new SqlParameter("@IDGroup", SqlDbType.Int);
             sqlPara[11].Value = IDGroup;

             return RunProcudure("sp_tblUser_update", sqlPara);
         }
    }
}
