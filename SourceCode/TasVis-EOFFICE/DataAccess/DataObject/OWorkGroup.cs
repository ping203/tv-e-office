using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.DataObject
{
    public class OWorkGroup
    {
        private int _WorkGroupID;

        public int WorkGroupID
        {
            get { return _WorkGroupID; }
            set { _WorkGroupID = value; }
        }
        private string _Name;

        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }
        private string _Description;

        public string Description
        {
            get { return _Description; }
            set { _Description = value; }
        }
        private string _WorkGroupParent;

        public string WorkGroupParent
        {
            get { return _WorkGroupParent; }
            set { _WorkGroupParent = value; }
        }

    }
}
