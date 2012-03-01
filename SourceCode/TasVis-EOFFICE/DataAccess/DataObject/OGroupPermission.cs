using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.DataObject
{
    public class OGroupPermission
    {
        private int _ID;

        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }
        private int _GroupId;

        public int GroupId
        {
            get { return _GroupId; }
            set { _GroupId = value; }
        }
        private int _PermissionDefinitionId;

        public int PermissionDefinitionId
        {
            get { return _PermissionDefinitionId; }
            set { _PermissionDefinitionId = value; }
        }
    }
}
