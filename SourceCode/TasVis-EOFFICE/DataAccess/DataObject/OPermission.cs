using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.DataObject
{
    public class OPermission
    {
        private int _PermissionID;

        public int PermissionID
        {
            get { return _PermissionID; }
            set { _PermissionID = value; }
        }
        private string _IDModule;

        public string IDModule
        {
            get { return _IDModule; }
            set { _IDModule = value; }
        }
        private int _IDGroup;

        public int IDGroup
        {
            get { return _IDGroup; }
            set { _IDGroup = value; }
        }
        private string _Roles;

        public string Roles
        {
            get { return _Roles; }
            set { _Roles = value; }
        }
    }
}
