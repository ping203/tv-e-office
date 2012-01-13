using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.DataObject
{
    public class OUserGroup
    {
        private int _IDUser;

        public int IDUser
        {
            get { return _IDUser; }
            set { _IDUser = value; }
        }
        private int _IDGroup;

        public int IDGroup
        {
            get { return _IDGroup; }
            set { _IDGroup = value; }
        }
    }
}
