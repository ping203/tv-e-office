using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.DataObject
{
    public class ODocumentKind
    {
        private int _DocumentKindID;

        public int DocumentKindID
        {
            get { return _DocumentKindID; }
            set { _DocumentKindID = value; }
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
        private int _DocumentKindParent;

        public int DocumentKindParent
        {
            get { return _DocumentKindParent; }
            set { _DocumentKindParent = value; }
        }
    }
}
