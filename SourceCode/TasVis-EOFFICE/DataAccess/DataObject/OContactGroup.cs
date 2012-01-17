using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.DataObject
{
    public class OContactGroup
    {
        private int _ContactGroupID;

        public int ContactGroupID
        {
            get { return _ContactGroupID; }
            set { _ContactGroupID = value; }
        }
        private string _GroupName;

        public string GroupName
        {
            get { return _GroupName; }
            set { _GroupName = value; }
        }
        private string _Description;

        public string Description
        {
            get { return _Description; }
            set { _Description = value; }
        }
        private int _IDUser;

        public int IDUser
        {
            get { return _IDUser; }
            set { _IDUser = value; }
        }
    }
}
