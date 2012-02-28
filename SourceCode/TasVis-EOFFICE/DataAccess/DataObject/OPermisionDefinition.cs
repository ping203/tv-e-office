using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.DataObject
{
    public class OPermisionDefinition
    {
        private int _ID;

        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }
        private string _Code;

        public string Code
        {
            get { return _Code; }
            set { _Code = value; }
        }

        private string _Name;

        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }

        private Int64 _TotalResult;

        public Int64 TotalResult
        {
            get { return _TotalResult; }
            set { _TotalResult = value; }
        }

    }
}
