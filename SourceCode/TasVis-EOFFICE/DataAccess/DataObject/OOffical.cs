using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.DataObject
{
    public class OOffical
    {
        private int _OfficalID;

        public int OfficalID
        {
            get { return _OfficalID; }
            set { _OfficalID = value; }
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
        private string _Address;

        public string Address
        {
            get { return _Address; }
            set { _Address = value; }
        }
        private string _Tel;

        public string Tel
        {
            get { return _Tel; }
            set { _Tel = value; }
        }
        private string _Fax;

        public string Fax
        {
            get { return _Fax; }
            set { _Fax = value; }
        }
        private string _Email;

        public string Email
        {
            get { return _Email; }
            set { _Email = value; }
        }
        private int _OfficalParent;

        public int OfficalParent
        {
            get { return _OfficalParent; }
            set { _OfficalParent = value; }
        }
    }
}
