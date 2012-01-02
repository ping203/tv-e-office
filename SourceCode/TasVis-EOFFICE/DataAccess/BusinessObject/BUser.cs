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
        /// Lấy về User theo tên User tương ứng
        /// </summary>
        /// <param name="UserName">Tên User</param>

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

         public void Add(string UserName, string Password, string FullName, string Email,string PhoneNumber,string Tel, string Gender,DateTime Birthday,string Address,string Position,string Status,int IDDepartment,int IDGroup)
         {
             SqlParameter[] sqlPara = new SqlParameter[13];
             sqlPara[0] = new SqlParameter("@UserName",SqlDbType.VarChar);
             sqlPara[0].Value = UserName;
             sqlPara[1] = new SqlParameter("@Password", SqlDbType.VarChar);
             sqlPara[1].Value = Password;
             sqlPara[2] = new SqlParameter("@FullName", SqlDbType.NVarChar);
             sqlPara[2].Value = FullName;
             sqlPara[3] = new SqlParameter("@Email", SqlDbType.VarChar);
             sqlPara[3].Value = Email;
             sqlPara[4] = new SqlParameter("@PhoneNumber", SqlDbType.VarChar);
             sqlPara[4].Value = PhoneNumber;
             sqlPara[5] = new SqlParameter("@Tel", SqlDbType.VarChar);
             sqlPara[5].Value = Tel;
             sqlPara[6] = new SqlParameter("@Gender", SqlDbType.VarChar);
             sqlPara[6].Value = Gender;
             sqlPara[7] = new SqlParameter("@BirthDay", SqlDbType.DateTime);
             sqlPara[7].Value = Birthday;
             sqlPara[8] = new SqlParameter("@Address", SqlDbType.NVarChar);
             sqlPara[8].Value = Address;
             sqlPara[9] = new SqlParameter("@Position", SqlDbType.NVarChar);
             sqlPara[9].Value = Position;
             sqlPara[10] = new SqlParameter("@Status", SqlDbType.VarChar);
             sqlPara[10].Value = Status;
             sqlPara[11] = new SqlParameter("@IDDepartment", SqlDbType.Int);
             sqlPara[11].Value = IDDepartment;
             sqlPara[12] = new SqlParameter("@IDGroup", SqlDbType.Int);
             sqlPara[12].Value = IDGroup;

             RunProcudure("sp_tblUser_add",sqlPara);
         }
    }
}
