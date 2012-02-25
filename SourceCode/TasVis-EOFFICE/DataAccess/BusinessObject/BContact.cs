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
    public class BContact:Common.CDBase
    {

        /// <summary>
        /// Thêm đối tượng Contact
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool Add(OContact obj)
        {
            SqlParameter[] sqlPara = new SqlParameter[13];
            sqlPara[0] = new SqlParameter("@ContactName", SqlDbType.NVarChar);
            sqlPara[0].Value = obj.ContactName;
            sqlPara[1] = new SqlParameter("@FullName", SqlDbType.NVarChar);
            sqlPara[1].Value = obj.FullName;
            sqlPara[2] = new SqlParameter("@Phone", SqlDbType.VarChar);
            sqlPara[2].Value = obj.Phone;
            sqlPara[3] = new SqlParameter("@Tel", SqlDbType.VarChar);
            sqlPara[3].Value = obj.Tel;
            sqlPara[4] = new SqlParameter("@BirthDay", SqlDbType.DateTime);
            sqlPara[4].Value = obj.BirthDay;
            sqlPara[5] = new SqlParameter("@Gender", SqlDbType.NVarChar);
            sqlPara[5].Value = obj.Gender;
            sqlPara[6] = new SqlParameter("@Job", SqlDbType.NVarChar);
            sqlPara[6].Value = obj.Job;
            sqlPara[7] = new SqlParameter("@Address", SqlDbType.NVarChar);
            sqlPara[7].Value = obj.Address;
            sqlPara[8] = new SqlParameter("@IDContactGroup", SqlDbType.Int);
            sqlPara[8].Value = obj.IDContactGroup;
            sqlPara[9] = new SqlParameter("@IDUser", SqlDbType.Int);
            sqlPara[9].Value = obj.IDUser;
            sqlPara[10] = new SqlParameter("@TitleName", SqlDbType.NVarChar);
            sqlPara[10].Value = obj.TitleName;
            sqlPara[11] = new SqlParameter("@Email", SqlDbType.VarChar);
            sqlPara[11].Value = obj.Email;
            sqlPara[12] = new SqlParameter("@Other", SqlDbType.NVarChar);
            sqlPara[12].Value = obj.Other;
            return RunProcudure("sp_tblContact_add", sqlPara);
        }

        /// <summary>
        /// Xóa 1 Contact
        /// </summary>
        /// <param name="ContactID"></param>
        /// <returns></returns>
        public bool Delete(int ContactID)
        {
            SqlParameter[] sqlPara = new SqlParameter[1];
            sqlPara[0] = new SqlParameter("@ContactID", SqlDbType.Int);
            sqlPara[0].Value = ContactID;

            return RunProcudure("sp_tblContact_delete", sqlPara);
        }

        /// <summary>
        /// Cập nhật Contact
        /// </summary>
        /// <param name="ContactID"></param>
        /// <param name="ContactName"></param>
        /// <param name="FullName"></param>
        /// <param name="Phone"></param>
        /// <param name="Tel"></param>
        /// <param name="BirthDay"></param>
        /// <param name="Gender"></param>
        /// <param name="Job"></param>
        /// <param name="Address"></param>
        /// <param name="IDContactGroup"></param>
        /// <param name="IDUser"></param>
        /// <returns></returns>
        public bool Update(int ContactID,string ContactName,string FullName,string Phone,string Tel,DateTime BirthDay,string Gender,string Job,string Address,int IDContactGroup,int IDUser)
        {
            SqlParameter[] sqlPara = new SqlParameter[11];
            sqlPara[0] = new SqlParameter("@ContactID", SqlDbType.Int);
            sqlPara[0].Value = ContactID;
            sqlPara[1] = new SqlParameter("@ContactName", SqlDbType.NVarChar);
            sqlPara[1].Value = ContactName;
            sqlPara[2] = new SqlParameter("@FullName", SqlDbType.NVarChar);
            sqlPara[2].Value = FullName;
            sqlPara[3] = new SqlParameter("@Phone", SqlDbType.VarChar);
            sqlPara[3].Value = Phone;
            sqlPara[4] = new SqlParameter("@Tel", SqlDbType.VarChar);
            sqlPara[4].Value = Tel;
            sqlPara[5] = new SqlParameter("@BirthDay", SqlDbType.DateTime);
            sqlPara[5].Value = BirthDay;
            sqlPara[6] = new SqlParameter("@Gender", SqlDbType.NVarChar);
            sqlPara[6].Value = Gender;
            sqlPara[7] = new SqlParameter("@Job", SqlDbType.NVarChar);
            sqlPara[7].Value = Job;
            sqlPara[8] = new SqlParameter("@Address", SqlDbType.NVarChar);
            sqlPara[8].Value = Address;
            sqlPara[9] = new SqlParameter("@IDContactGroup", SqlDbType.Int);
            sqlPara[9].Value = IDContactGroup;
            sqlPara[10] = new SqlParameter("@IDUser", SqlDbType.Int);
            sqlPara[10].Value = IDUser;

            return RunProcudure("sp_tblContact_update", sqlPara);
        }

        public bool Update(int ContactID,string FullName, string Phone, string Tel, string Address,string Email, int IDUser)
        {
            SqlParameter[] sqlPara = new SqlParameter[7];
            sqlPara[0] = new SqlParameter("@ContactID", SqlDbType.Int);
            sqlPara[0].Value = ContactID;            
            sqlPara[1] = new SqlParameter("@FullName", SqlDbType.NVarChar);
            sqlPara[1].Value = FullName;
            sqlPara[2] = new SqlParameter("@Phone", SqlDbType.VarChar);
            sqlPara[2].Value = Phone;
            sqlPara[3] = new SqlParameter("@Tel", SqlDbType.VarChar);
            sqlPara[3].Value = Tel;            
            sqlPara[4] = new SqlParameter("@Address", SqlDbType.NVarChar);
            sqlPara[4].Value = Address;
            sqlPara[5] = new SqlParameter("@Email", SqlDbType.VarChar);
            sqlPara[5].Value = Email;
            sqlPara[6] = new SqlParameter("@IDUser", SqlDbType.Int);
            sqlPara[6].Value = IDUser;

            return RunProcudure("sp_tblContact_update", sqlPara);
        }

        /// <summary>
        /// Get Contact theo ID
        /// </summary>
        /// <param name="ContactID"></param>
        /// <returns></returns>
        public IList<OContact> Get(int ContactID,int IDUser)
        {
            SqlParameter[] sqlPara = new SqlParameter[2];
            sqlPara[0] = new SqlParameter("@ContactID", SqlDbType.Int);
            sqlPara[0].Value = ContactID;
            sqlPara[1] = new SqlParameter("@IDUser", SqlDbType.Int);
            sqlPara[1].Value = IDUser;

            DataTable tbl = RunProcedureGet("sp_tblContact_get", sqlPara);
            IList<OContact> list = new List<OContact>();
            list = Common.Common.ConvertTo<OContact>(tbl);
            return list;
        }

        public IList<OContact> Get(int ContactID, int IDUser,string Gender)
        {
            SqlParameter[] sqlPara = new SqlParameter[3];
            sqlPara[0] = new SqlParameter("@ContactID", SqlDbType.Int);
            sqlPara[0].Value = ContactID;
            sqlPara[1] = new SqlParameter("@IDUser", SqlDbType.Int);
            sqlPara[1].Value = IDUser;
            sqlPara[2] = new SqlParameter("@Gender", SqlDbType.NVarChar);
            sqlPara[2].Value = Gender;

            DataTable tbl = RunProcedureGet("sp_tblContact_get", sqlPara);
            IList<OContact> list = new List<OContact>();
            list = Common.Common.ConvertTo<OContact>(tbl);
            return list;
        }

        public IList<OContact> Get(int ContactID, int IDUser,int IDContactGroup)
        {
            SqlParameter[] sqlPara = new SqlParameter[3];
            sqlPara[0] = new SqlParameter("@ContactID", SqlDbType.Int);
            sqlPara[0].Value = ContactID;
            sqlPara[1] = new SqlParameter("@IDUser", SqlDbType.Int);
            sqlPara[1].Value = IDUser;
            sqlPara[2] = new SqlParameter("@IDContactGroup", SqlDbType.Int);
            sqlPara[2].Value = IDContactGroup;
            DataTable tbl = RunProcedureGet("sp_tblContact_get", sqlPara);
            IList<OContact> list = new List<OContact>();
            list = Common.Common.ConvertTo<OContact>(tbl);
            return list;
        }

        public IList<OContact> Get(int ContactID, int IDUser, string Gender, int IDContactGroup)
        {
            SqlParameter[] sqlPara = new SqlParameter[4];
            sqlPara[0] = new SqlParameter("@ContactID", SqlDbType.Int);
            sqlPara[0].Value = ContactID;
            sqlPara[1] = new SqlParameter("@IDUser", SqlDbType.Int);
            sqlPara[1].Value = IDUser;
            sqlPara[2] = new SqlParameter("@Gender", SqlDbType.NVarChar);
            sqlPara[2].Value = Gender;
            sqlPara[3] = new SqlParameter("@IDContactGroup", SqlDbType.Int);
            sqlPara[3].Value = IDContactGroup;
            DataTable tbl = RunProcedureGet("sp_tblContact_get", sqlPara);
            IList<OContact> list = new List<OContact>();
            list = Common.Common.ConvertTo<OContact>(tbl);
            return list;
        }

        public IList<OContact> Get(int ContactID,string FullName, int IDUser, string Gender, int IDContactGroup, string Email, string Phone, string Address, string Order, string OrderBy, int PageIndex,int PageSize)
        {
            SqlParameter[] sqlPara = new SqlParameter[12];
            sqlPara[0] = new SqlParameter("@FullName", SqlDbType.NVarChar);
            sqlPara[0].Value = FullName;
            sqlPara[1] = new SqlParameter("@IDUser", SqlDbType.Int);
            sqlPara[1].Value = IDUser;
            sqlPara[2] = new SqlParameter("@Gender", SqlDbType.NVarChar);
            sqlPara[2].Value = Gender;
            sqlPara[3] = new SqlParameter("@IDContactGroup", SqlDbType.Int);
            sqlPara[3].Value = IDContactGroup;
            sqlPara[4] = new SqlParameter("@Email", SqlDbType.VarChar);
            sqlPara[4].Value = Email;
            sqlPara[5] = new SqlParameter("@Phone", SqlDbType.VarChar);
            sqlPara[5].Value = Phone;
            sqlPara[6] = new SqlParameter("@Address", SqlDbType.NVarChar);
            sqlPara[6].Value = Address;
            sqlPara[7] = new SqlParameter("@Order", SqlDbType.VarChar);
            sqlPara[7].Value = Order;
            sqlPara[8] = new SqlParameter("@OrderBy", SqlDbType.VarChar);
            sqlPara[8].Value = OrderBy;
            sqlPara[9] = new SqlParameter("@PageIndex", SqlDbType.Int);
            sqlPara[9].Value = PageIndex;
            sqlPara[10] = new SqlParameter("@PageSize", SqlDbType.Int);
            sqlPara[10].Value = PageSize;
            sqlPara[11] = new SqlParameter("@ContactID", SqlDbType.Int);
            sqlPara[11].Value = ContactID;

            DataTable tbl = RunProcedureGet("sp_tblContact_get", sqlPara);
            IList<OContact> list = new List<OContact>();
            list = Common.Common.ConvertTo<OContact>(tbl);
            return list;
        }

        public IList<OContact> Get(int ContactID,string FullName, int IDUser, string Gender, int IDContactGroup, string Email, string Phone, string Address, string Order, string OrderBy)
        {
            SqlParameter[] sqlPara = new SqlParameter[10];
            sqlPara[0] = new SqlParameter("@FullName", SqlDbType.NVarChar);
            sqlPara[0].Value = FullName;
            sqlPara[1] = new SqlParameter("@IDUser", SqlDbType.Int);
            sqlPara[1].Value = IDUser;
            sqlPara[2] = new SqlParameter("@Gender", SqlDbType.NVarChar);
            sqlPara[2].Value = Gender;
            sqlPara[3] = new SqlParameter("@IDContactGroup", SqlDbType.Int);
            sqlPara[3].Value = IDContactGroup;
            sqlPara[4] = new SqlParameter("@Email", SqlDbType.VarChar);
            sqlPara[4].Value = Email;
            sqlPara[5] = new SqlParameter("@Phone", SqlDbType.VarChar);
            sqlPara[5].Value = Phone;
            sqlPara[6] = new SqlParameter("@Address", SqlDbType.NVarChar);
            sqlPara[6].Value = Address;
            sqlPara[7] = new SqlParameter("@Order", SqlDbType.VarChar);
            sqlPara[7].Value = Order;
            sqlPara[8] = new SqlParameter("@OrderBy", SqlDbType.VarChar);
            sqlPara[8].Value = OrderBy;
            sqlPara[9] = new SqlParameter("@ContactID", SqlDbType.Int);
            sqlPara[9].Value = ContactID;
            

            DataTable tbl = RunProcedureGet("sp_tblContact_get", sqlPara);
            IList<OContact> list = new List<OContact>();
            list = Common.Common.ConvertTo<OContact>(tbl);
            return list;
        }

        /// <summary>
        /// Get Contact theo FullName
        /// </summary>
        /// <param name="ContactID"></param>
        /// <param name="IDUser"></param>
        /// <param name="FullName"></param>
        /// <returns></returns>
        public IList<OContact> GetFullName(int ContactID, int IDUser,string FullName)
        {
            SqlParameter[] sqlPara = new SqlParameter[3];
            sqlPara[0] = new SqlParameter("@ContactID", SqlDbType.Int);
            sqlPara[0].Value = ContactID;
            sqlPara[1] = new SqlParameter("@IDUser", SqlDbType.Int);
            sqlPara[1].Value = IDUser;
            sqlPara[2] = new SqlParameter("@FullName", SqlDbType.NVarChar);
            sqlPara[2].Value = FullName;

            DataTable tbl = RunProcedureGet("sp_tblContact_get", sqlPara);
            IList<OContact> list = new List<OContact>();
            list = Common.Common.ConvertTo<OContact>(tbl);
            return list;
        }

        public IList<OContact> GetFullName(int ContactID, int IDUser, string FullName,string Gender)
        {
            SqlParameter[] sqlPara = new SqlParameter[4];
            sqlPara[0] = new SqlParameter("@ContactID", SqlDbType.Int);
            sqlPara[0].Value = ContactID;
            sqlPara[1] = new SqlParameter("@IDUser", SqlDbType.Int);
            sqlPara[1].Value = IDUser;
            sqlPara[2] = new SqlParameter("@FullName", SqlDbType.NVarChar);
            sqlPara[2].Value = FullName;
            sqlPara[3] = new SqlParameter("@Gender", SqlDbType.NVarChar);
            sqlPara[3].Value = Gender;
            DataTable tbl = RunProcedureGet("sp_tblContact_get", sqlPara);
            IList<OContact> list = new List<OContact>();
            list = Common.Common.ConvertTo<OContact>(tbl);
            return list;
        }

        public IList<OContact> GetFullName(int ContactID, int IDUser, string FullName,int IDContactGroup)
        {
            SqlParameter[] sqlPara = new SqlParameter[4];
            sqlPara[0] = new SqlParameter("@ContactID", SqlDbType.Int);
            sqlPara[0].Value = ContactID;
            sqlPara[1] = new SqlParameter("@IDUser", SqlDbType.Int);
            sqlPara[1].Value = IDUser;
            sqlPara[2] = new SqlParameter("@FullName", SqlDbType.NVarChar);
            sqlPara[2].Value = FullName;
            sqlPara[3] = new SqlParameter("@IDContactGroup", SqlDbType.Int);
            sqlPara[3].Value = IDContactGroup;
            DataTable tbl = RunProcedureGet("sp_tblContact_get", sqlPara);
            IList<OContact> list = new List<OContact>();
            list = Common.Common.ConvertTo<OContact>(tbl);
            return list;
        }

        public IList<OContact> GetFullName(int ContactID, int IDUser, string FullName, string Gender, int IDContactGroup)
        {
            SqlParameter[] sqlPara = new SqlParameter[5];
            sqlPara[0] = new SqlParameter("@ContactID", SqlDbType.Int);
            sqlPara[0].Value = ContactID;
            sqlPara[1] = new SqlParameter("@IDUser", SqlDbType.Int);
            sqlPara[1].Value = IDUser;
            sqlPara[2] = new SqlParameter("@FullName", SqlDbType.NVarChar);
            sqlPara[2].Value = FullName;
            sqlPara[3] = new SqlParameter("@Gender", SqlDbType.NVarChar);
            sqlPara[3].Value = Gender;
            sqlPara[4] = new SqlParameter("@IDContactGroup", SqlDbType.Int);
            sqlPara[4].Value = IDContactGroup;
            DataTable tbl = RunProcedureGet("sp_tblContact_get", sqlPara);
            IList<OContact> list = new List<OContact>();
            list = Common.Common.ConvertTo<OContact>(tbl);
            return list;
        }


        /// <summary>
        /// get Contact theo Phone
        /// </summary>
        /// <param name="ContactID"></param>
        /// <param name="IDUser"></param>
        /// <param name="Phone"></param>
        /// <returns></returns>
        public IList<OContact> GetPhone(int ContactID, int IDUser, string Phone)
        {
            SqlParameter[] sqlPara = new SqlParameter[3];
            sqlPara[0] = new SqlParameter("@ContactID", SqlDbType.Int);
            sqlPara[0].Value = ContactID;
            sqlPara[1] = new SqlParameter("@IDUser", SqlDbType.Int);
            sqlPara[1].Value = IDUser;
            sqlPara[2] = new SqlParameter("@Phone", SqlDbType.VarChar);
            sqlPara[2].Value = Phone;

            DataTable tbl = RunProcedureGet("sp_tblContact_get", sqlPara);
            IList<OContact> list = new List<OContact>();
            list = Common.Common.ConvertTo<OContact>(tbl);
            return list;
        }

        public IList<OContact> GetPhone(int ContactID, int IDUser, string Phone,string Gender)
        {
            SqlParameter[] sqlPara = new SqlParameter[4];
            sqlPara[0] = new SqlParameter("@ContactID", SqlDbType.Int);
            sqlPara[0].Value = ContactID;
            sqlPara[1] = new SqlParameter("@IDUser", SqlDbType.Int);
            sqlPara[1].Value = IDUser;
            sqlPara[2] = new SqlParameter("@Phone", SqlDbType.VarChar);
            sqlPara[2].Value = Phone;
            sqlPara[3] = new SqlParameter("@Gender", SqlDbType.NVarChar);
            sqlPara[3].Value = Gender;
            DataTable tbl = RunProcedureGet("sp_tblContact_get", sqlPara);
            IList<OContact> list = new List<OContact>();
            list = Common.Common.ConvertTo<OContact>(tbl);
            return list;
        }

        public IList<OContact> GetPhone(int ContactID, int IDUser, string Phone,int IDContactGroup)
        {
            SqlParameter[] sqlPara = new SqlParameter[4];
            sqlPara[0] = new SqlParameter("@ContactID", SqlDbType.Int);
            sqlPara[0].Value = ContactID;
            sqlPara[1] = new SqlParameter("@IDUser", SqlDbType.Int);
            sqlPara[1].Value = IDUser;
            sqlPara[2] = new SqlParameter("@Phone", SqlDbType.VarChar);
            sqlPara[2].Value = Phone;
            sqlPara[3] = new SqlParameter("@IDContactGroup", SqlDbType.Int);
            sqlPara[3].Value = IDContactGroup;
            DataTable tbl = RunProcedureGet("sp_tblContact_get", sqlPara);
            IList<OContact> list = new List<OContact>();
            list = Common.Common.ConvertTo<OContact>(tbl);
            return list;
        }

        public IList<OContact> GetPhone(int ContactID, int IDUser, string Phone, string Gender,int IDContactGroup)
        {
            SqlParameter[] sqlPara = new SqlParameter[5];
            sqlPara[0] = new SqlParameter("@ContactID", SqlDbType.Int);
            sqlPara[0].Value = ContactID;
            sqlPara[1] = new SqlParameter("@IDUser", SqlDbType.Int);
            sqlPara[1].Value = IDUser;
            sqlPara[2] = new SqlParameter("@Phone", SqlDbType.VarChar);
            sqlPara[2].Value = Phone;
            sqlPara[3] = new SqlParameter("@Gender", SqlDbType.NVarChar);
            sqlPara[3].Value = Gender;
            sqlPara[4] = new SqlParameter("@IDContactGroup", SqlDbType.Int);
            sqlPara[4].Value = IDContactGroup;
            DataTable tbl = RunProcedureGet("sp_tblContact_get", sqlPara);
            IList<OContact> list = new List<OContact>();
            list = Common.Common.ConvertTo<OContact>(tbl);
            return list;
        }

        public IList<OContact> GetEmail(int ContactID, int IDUser, string Email)
        {
            SqlParameter[] sqlPara = new SqlParameter[3];
            sqlPara[0] = new SqlParameter("@ContactID", SqlDbType.Int);
            sqlPara[0].Value = ContactID;
            sqlPara[1] = new SqlParameter("@IDUser", SqlDbType.Int);
            sqlPara[1].Value = IDUser;
            sqlPara[2] = new SqlParameter("@Email", SqlDbType.VarChar);
            sqlPara[2].Value = Email;

            DataTable tbl = RunProcedureGet("sp_tblContact_get", sqlPara);
            IList<OContact> list = new List<OContact>();
            list = Common.Common.ConvertTo<OContact>(tbl);
            return list;
        }

        public IList<OContact> GetEmail(int ContactID, int IDUser, string Email,string Gender)
        {
            SqlParameter[] sqlPara = new SqlParameter[4];
            sqlPara[0] = new SqlParameter("@ContactID", SqlDbType.Int);
            sqlPara[0].Value = ContactID;
            sqlPara[1] = new SqlParameter("@IDUser", SqlDbType.Int);
            sqlPara[1].Value = IDUser;
            sqlPara[2] = new SqlParameter("@Email", SqlDbType.VarChar);
            sqlPara[2].Value = Email;
            sqlPara[3] = new SqlParameter("@Gender", SqlDbType.NVarChar);
            sqlPara[3].Value = Gender;
            DataTable tbl = RunProcedureGet("sp_tblContact_get", sqlPara);
            IList<OContact> list = new List<OContact>();
            list = Common.Common.ConvertTo<OContact>(tbl);
            return list;
        }

        public IList<OContact> GetEmail(int ContactID, int IDUser, string Email,int IDContactGroup)
        {
            SqlParameter[] sqlPara = new SqlParameter[4];
            sqlPara[0] = new SqlParameter("@ContactID", SqlDbType.Int);
            sqlPara[0].Value = ContactID;
            sqlPara[1] = new SqlParameter("@IDUser", SqlDbType.Int);
            sqlPara[1].Value = IDUser;
            sqlPara[2] = new SqlParameter("@Email", SqlDbType.VarChar);
            sqlPara[2].Value = Email;
            sqlPara[3] = new SqlParameter("@IDContactGroup", SqlDbType.Int);
            sqlPara[3].Value = IDContactGroup;
            DataTable tbl = RunProcedureGet("sp_tblContact_get", sqlPara);
            IList<OContact> list = new List<OContact>();
            list = Common.Common.ConvertTo<OContact>(tbl);
            return list;
        }

        public IList<OContact> GetEmail(int ContactID, int IDUser, string Email, string Gender, int IDContactGroup)
        {
            SqlParameter[] sqlPara = new SqlParameter[5];
            sqlPara[0] = new SqlParameter("@ContactID", SqlDbType.Int);
            sqlPara[0].Value = ContactID;
            sqlPara[1] = new SqlParameter("@IDUser", SqlDbType.Int);
            sqlPara[1].Value = IDUser;
            sqlPara[2] = new SqlParameter("@Email", SqlDbType.VarChar);
            sqlPara[2].Value = Email;
            sqlPara[3] = new SqlParameter("@Gender", SqlDbType.NVarChar);
            sqlPara[3].Value = Gender;
            sqlPara[4] = new SqlParameter("@IDContactGroup", SqlDbType.Int);
            sqlPara[4].Value = IDContactGroup;
            DataTable tbl = RunProcedureGet("sp_tblContact_get", sqlPara);
            IList<OContact> list = new List<OContact>();
            list = Common.Common.ConvertTo<OContact>(tbl);
            return list;
        }

        public IList<OContact> GetAddress(int ContactID, int IDUser, string Address)
        {
            SqlParameter[] sqlPara = new SqlParameter[3];
            sqlPara[0] = new SqlParameter("@ContactID", SqlDbType.Int);
            sqlPara[0].Value = ContactID;
            sqlPara[1] = new SqlParameter("@IDUser", SqlDbType.Int);
            sqlPara[1].Value = IDUser;
            sqlPara[2] = new SqlParameter("@Address", SqlDbType.NVarChar);
            sqlPara[2].Value = Address;

            DataTable tbl = RunProcedureGet("sp_tblContact_get", sqlPara);
            IList<OContact> list = new List<OContact>();
            list = Common.Common.ConvertTo<OContact>(tbl);
            return list;
        }

        public IList<OContact> GetAddress(int ContactID, int IDUser, string Address,string Gender)
        {
            SqlParameter[] sqlPara = new SqlParameter[4];
            sqlPara[0] = new SqlParameter("@ContactID", SqlDbType.Int);
            sqlPara[0].Value = ContactID;
            sqlPara[1] = new SqlParameter("@IDUser", SqlDbType.Int);
            sqlPara[1].Value = IDUser;
            sqlPara[2] = new SqlParameter("@Address", SqlDbType.NVarChar);
            sqlPara[2].Value = Address;
            sqlPara[3] = new SqlParameter("@Gender", SqlDbType.NVarChar);
            sqlPara[3].Value = Gender;
            DataTable tbl = RunProcedureGet("sp_tblContact_get", sqlPara);
            IList<OContact> list = new List<OContact>();
            list = Common.Common.ConvertTo<OContact>(tbl);
            return list;
        }

        public IList<OContact> GetAddress(int ContactID, int IDUser, string Address,int IDContactGroup)
        {
            SqlParameter[] sqlPara = new SqlParameter[4];
            sqlPara[0] = new SqlParameter("@ContactID", SqlDbType.Int);
            sqlPara[0].Value = ContactID;
            sqlPara[1] = new SqlParameter("@IDUser", SqlDbType.Int);
            sqlPara[1].Value = IDUser;
            sqlPara[2] = new SqlParameter("@Address", SqlDbType.NVarChar);
            sqlPara[2].Value = Address;
            sqlPara[3] = new SqlParameter("@IDContactGroup", SqlDbType.Int);
            sqlPara[3].Value = IDContactGroup;
            DataTable tbl = RunProcedureGet("sp_tblContact_get", sqlPara);
            IList<OContact> list = new List<OContact>();
            list = Common.Common.ConvertTo<OContact>(tbl);
            return list;
        }

        public IList<OContact> GetAddress(int ContactID, int IDUser, string Address, string Gender, int IDContactGroup)
        {
            SqlParameter[] sqlPara = new SqlParameter[5];
            sqlPara[0] = new SqlParameter("@ContactID", SqlDbType.Int);
            sqlPara[0].Value = ContactID;
            sqlPara[1] = new SqlParameter("@IDUser", SqlDbType.Int);
            sqlPara[1].Value = IDUser;
            sqlPara[2] = new SqlParameter("@Address", SqlDbType.NVarChar);
            sqlPara[2].Value = Address;
            sqlPara[3] = new SqlParameter("@Gender", SqlDbType.NVarChar);
            sqlPara[3].Value = Gender;
            sqlPara[4] = new SqlParameter("@IDContactGroup", SqlDbType.Int);
            sqlPara[4].Value = IDContactGroup;
            DataTable tbl = RunProcedureGet("sp_tblContact_get", sqlPara);
            IList<OContact> list = new List<OContact>();
            list = Common.Common.ConvertTo<OContact>(tbl);
            return list;
        }
    }
}
