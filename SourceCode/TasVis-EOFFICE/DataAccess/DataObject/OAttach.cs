using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.DataObject
{
    public class OAttach
    {
        private int _AttackID;

        public int AttackID
        {
            get { return _AttackID; }
            set { _AttackID = value; }
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
        private string _Path;

        public string Path
        {
            get { return _Path; }
            set { _Path = value; }
        }
    }
}
