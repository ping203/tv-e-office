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
            sqlParam[0].Value = objUserGroup.IDUser;
            sqlParam[1].Value = objUserGroup.IDGroup;
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
            sqlParam[0].Value = objUserGroup.IDUser;
            sqlParam[1].Value = objUserGroup.IDGroup;
            return RunProcudure("sp_tblUser_Group_delete", sqlParam);
        }
        /// <summary>
        /// Cập nhật user vào group
        /// </summary>
        /// <param name="objUserGroupOld"></param>
        /// <param name="objUserGroupNew"></param>
        /// <returns></returns>
        public bool Update(OUserGroup objUserGroupOld,OUserGroup objUserGroupNew)
        {
            if (this.Delete(objUserGroupOld)) {
                return this.Add(objUserGroupNew);
            }            
            return false;
        }
        public List<OUserGroup> Get(OUserGroup objUserGroup)
        {
            SqlParameter[] sqlParam = { new SqlParameter("@IDUser",SqlDbType.Int),
                                        new SqlParameter("@IDGroup",SqlDbType.Int) 
                                      };
            sqlParam[0].Value = objUserGroup.IDUser;
            sqlParam[1].Value = objUserGroup.IDGroup;
            return RunProcudure("sp_tblUser_Group_get", sqlParam);
        }
    }
}
