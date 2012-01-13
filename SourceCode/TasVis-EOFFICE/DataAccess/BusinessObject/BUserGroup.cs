using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess.DataObject;
using System.Data;
using System.Data.SqlClient;

namespace DataAccess.BusinessObject
{
    public class BUserGroup:Common.CDBase
    {
        /// <summary>
        /// Thêm mới người dùng thuộc group
        /// </summary>
        /// <param name="objUserGroup"></param>
        /// <returns>bool</returns>
        public bool Add(OUserGroup objUserGroup)
        {
            SqlParameter[] sqlParam = { new SqlParameter("@IDUser",SqlDbType.Int),
                                        new SqlParameter("@IDGroup",SqlDbType.Int) 
                                      };
            return RunProcudure("sp_tblUser_Group_add", sqlParam);                        
        }
        /// <summary>
        /// Xóa người dùng khỏi group
        /// </summary>
        /// <param name="objUserGroup"></param>
        /// <returns></returns>
        public bool Delete(OUserGroup objUserGroup)
        {
            SqlParameter[] sqlParam = { new SqlParameter("@IDUser",SqlDbType.Int),
                                        new SqlParameter("@IDGroup",SqlDbType.Int) 
                                      };
            return RunProcudure("sp_tblUser_Group_delete", sqlParam);
        }

        public bool Update(OUserGroup objUserGroupOld,OUserGroup objUserGroupNew)
        {
            if (this.Delete(objUserGroupOld)) {
                return this.Add(objUserGroupNew);
            }
            return false;
        }
    }
}
