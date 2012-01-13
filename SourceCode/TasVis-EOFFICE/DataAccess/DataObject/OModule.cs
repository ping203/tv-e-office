using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.DataObject
{
    public class OModule
    {
        private int _Code;

        /// <summary>
        /// Mã module
        /// </summary>
        public int Code
        {
            get { return _Code; }
            set { _Code = value; }
        }
        private string _Description;
        /// <summary>
        /// Mô tả về module
        /// </summary>
        public string Description
        {
            get { return _Description; }
            set { _Description = value; }
        }

        /// <summary>
        /// Khởi tạo module
        /// </summary>
        /// <param name="Code">Mã module</param>
        /// <param name="Description">Mô tả</param>
        public OModule(int Code, string Description)
        {
            this._Code = Code;
            this._Description = Description;
        }
    }
}
