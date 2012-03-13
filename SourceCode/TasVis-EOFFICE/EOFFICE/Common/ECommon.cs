using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using DataAccess.DataObject;
using System.Collections.Generic;
namespace EOFFICE.Common
{
    public class ECommon
    {

        ///// <summary>
        ///// Lấy về danh sách module
        ///// </summary>
        ///// <returns></returns>
        //public static List<OModule> GetListModule()
        //{
        //    List<OModule> lst = new List<OModule>();
        //    lst.Add(new OModule("MD01", "Quản trị người dùng"));
        //    lst.Add(new OModule("MD02", "Quản trị nhóm người dùng"));
        //    return lst;
        //}
    }
    public enum DocumentStatus
    {
        /// <summary>
        /// Lưu bản thảo
        /// </summary>
        SaveDrap = 1,
        /// <summary>
        /// Gửi bản thảo
        /// </summary>
        SendDrap = 2,
        /// <summary>
        /// Chờ xuất bản
        /// </summary>
        WaitPublish = 3,
        /// <summary>
        /// Đã xuất bản
        /// </summary>
        Published = 4,
        /// <summary>
        /// Đã xử lý
        /// </summary>
        Processed = 5,
        /// <summary>
        /// Đang xử lý
        /// </summary>
        Processing = 6,
        /// <summary>
        /// Bị trả lại
        /// </summary>
        SendAgain = 7
    };

    /// <summary>
    /// Danh sách các quyền hệ thống
    /// </summary>
    public enum PermissionCode
    {
        /// <summary>
        /// Xử lý dự thảo
        /// </summary>
        DocumentDrap,
        /// <summary>
        /// Duyệt văn bản
        /// </summary>
        DocumentProcess,
        /// <summary>
        /// Phát hành văn bản
        /// </summary>
        DocumentPublish,

        //------------------Gửi tin nhắn--------------
        /// <summary>
        /// Quyền gửi tin nhắn nhắc
        /// </summary>
        SendSMS,

        /// <summary>
        /// Quản trị người dùng
        /// </summary>
        UserManagement,


    };

}
