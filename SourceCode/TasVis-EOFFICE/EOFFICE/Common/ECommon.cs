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
        public static string ReplaceUnicode(string textContent)
        {
            string reStr = textContent.ToLower();
            string[] arrKeyReplate = {
		"à",
		"á",
		"ả",
		"ã",
		"ạ",
		"ă",
		"ằ",
		"ắ",
		"ẳ",
		"ẵ",
		"ặ",
		"â",
		"ầ",
		"ấ",
		"ẩ",
		"ẫ",
		"ậ",
		"đ",
		"è",
		"é",
		"ẻ",
		"ẽ",
		"ẹ",
		"ê",
		"ề",
		"ế",
		"ể",
		"ễ",
		"ệ",
		"ì",
		"í",
		"ỉ",
		"ĩ",
		"ị",
		"ỳ",
		"ý",
		"ỷ",
		"ỹ",
		"ỵ",
		"ò",
		"ó",
		"ỏ",
		"õ",
		"ọ",
		"ô",
		"ồ",
		"ố",
		"ổ",
		"ỗ",
		"ộ",
		"ơ",
		"ờ",
		"ớ",
		"ở",
		"ỡ",
		"ợ",
		"ù",
		"ú",
		"ủ",
		"ũ",
		"ụ",
		"ư",
		"ừ",
		"ứ",
		"ử",
		"ữ",
		"ự"
	};
            string[] arrValueReplate = {
		"a",
		"a",
		"a",
		"a",
		"a",
		"a",
		"a",
		"a",
		"a",
		"a",
		"a",
		"a",
		"a",
		"a",
		"a",
		"a",
		"a",
		"d",
		"e",
		"e",
		"e",
		"e",
		"e",
		"e",
		"e",
		"e",
		"e",
		"e",
		"e",
		"i",
		"i",
		"i",
		"i",
		"i",
		"y",
		"y",
		"y",
		"y",
		"y",
		"o",
		"o",
		"o",
		"o",
		"o",
		"o",
		"o",
		"o",
		"o",
		"o",
		"o",
		"o",
		"o",
		"o",
		"o",
		"o",
		"o",
		"u",
		"u",
		"u",
		"u",
		"u",
		"u",
		"u",
		"u",
		"u",
		"u",
		"u"
	};

            for (int i = 0; i <= arrKeyReplate.Length - 1; i++)
            {
                reStr = reStr.Replace(arrKeyReplate[i], arrValueReplate[i]);
            }            
            return reStr;
        }
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

        //-----------------Công việc------------------
        ///<summary>
        ///Quyền giao việc
        ///</summary>
        WorkAssignment,
        ///<summary>
        ///Quyền chuyển việc
        ///</summary>
        WorkForward,
        //-------------Lịch họp -------------------
        ///<summary>
        ///Quyền tạo lịch họp
        ///</summary>
        CalendarCreate,
    };    
    /// <summary>
    /// Loại văn bản
    /// </summary>
    public enum DocumentType
    { 
        /// <summary>
        /// Công văn dự thảo
        /// </summary>
        DocumentDrap=1,
        /// <summary>
        /// Công văn đi
        /// </summary>
        DocumentSend=2,
        /// <summary>
        /// Công văn đến
        /// </summary>
        DocumentReceived=3
    }

}
