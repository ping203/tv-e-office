using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.ObjectData
{
    class ODepartment
    {
        private int _DeparmentID;

        public int DeparmentID
        {
            get { return _DeparmentID; }
            set { _DeparmentID = value; }
        }

        private string _Name;

        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }
        private int _DepartmentParent;

        public int DepartmentParent
        {
            get { return _DepartmentParent; }
            set { _DepartmentParent = value; }
        }
        private string _Description;

        public string Description
        {
            get { return _Description; }
            set { _Description = value; }
        }

        
    }
}
