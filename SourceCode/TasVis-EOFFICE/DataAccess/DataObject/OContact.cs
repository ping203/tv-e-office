using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.DataObject
{
    public class OContact
    {
        private int _ContactID;

        public int ContactID
        {
            get { return _ContactID; }
            set { _ContactID = value; }
        }
        private string _ContactName;

        public string ContactName
        {
            get { return _ContactName; }
            set { _ContactName = value; }
        }
        private string _TitleName;

        public string TitleName
        {
            get { return _TitleName; }
            set { _TitleName = value; }
        }
        private string _FullName;

        public string FullName
        {
            get { return _FullName; }
            set { _FullName = value; }
        }
        private string _Phone;

        public string Phone
        {
            get { return _Phone; }
            set { _Phone = value; }
        }
        private string _Tel;

        public string Tel
        {
            get { return _Tel; }
            set { _Tel = value; }
        }
        private string _Email;

        public string Email
        {
            get { return _Email; }
            set { _Email = value; }
        }
        private DateTime _BirthDay;

        public DateTime BirthDay
        {
            get { return _BirthDay; }
            set { _BirthDay = value; }
        }
        private string _Gender;

        public string Gender
        {
            get { return _Gender; }
            set { _Gender = value; }
        }
        private string _Job;

        public string Job
        {
            get { return _Job; }
            set { _Job = value; }
        }
        private string _Address;

        public string Address
        {
            get { return _Address; }
            set { _Address = value; }
        }
        private string _Other;

        public string Other
        {
            get { return _Other; }
            set { _Other = value; }
        }
        private int _IDContactGroup;

        public int IDContactGroup
        {
            get { return _IDContactGroup; }
            set { _IDContactGroup = value; }
        }
        private int _IDUser;

        public int IDUser
        {
            get { return _IDUser; }
            set { _IDUser = value; }
        }
    }
}
