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
using System.Security.Cryptography;
using System.Text;
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
        public static string GetMd5String(string src)
        {
            using (MD5 _md5 = MD5.Create())
            {
                string hash = GetMd5Hash(_md5, src);
                return hash;
            }
            return "";
        }

        static string GetMd5Hash(MD5 md5Hash, string input)
        {

            // Convert the input string to a byte array and compute the hash.
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            StringBuilder sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data 
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string.
            return sBuilder.ToString();
        }

        // Verify a hash against a string.
        static bool VerifyMd5Hash(MD5 md5Hash, string input, string hash)
        {
            // Hash the input.
            string hashOfInput = GetMd5Hash(md5Hash, input);

            // Create a StringComparer an compare the hashes.
            StringComparer comparer = StringComparer.OrdinalIgnoreCase;

            if (0 == comparer.Compare(hashOfInput, hash))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

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
        /// Xử lý công văn đến
        /// </summary>
        DocumentReceivedDrap,
        /// <summary>
        /// Duyệt công văn đến
        /// </summary>
        DocumentReceivedProcess,
        /// <summary>
        /// Phát hành công văn đến
        /// </summary>
        DocumentReceivedPublish,
        /// <summary>
        /// Xử lý công văn đi
        /// </summary>
        DocumentSendDrap,
        /// <summary>
        /// Duyệt công văn đi
        /// </summary>
        DocumentSendProcess,
        /// <summary>
        /// Phát hành công văn đi
        /// </summary>
        DocumentSendPublish,

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
