using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.DataObject
{
    public class ODepartment
    {
        private int _DepartmentID;
        public int DepartmentID
        {
            get { return _DepartmentID; }
            set { _DepartmentID = value; }
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
