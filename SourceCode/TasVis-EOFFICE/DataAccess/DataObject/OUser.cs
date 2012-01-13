using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.DataObject
{
    public class OUser
    {
        private int _UserID;

        public int UserID
        {
            get { return _UserID; }
            set { _UserID = value; }
        }
        private string _UserName;

        public string UserName
        {
            get { return _UserName; }
            set { _UserName = value; }
        }
        private string _Password;

        public string Password
        {
            get { return _Password; }
            set { _Password = value; }
        }
        private string _FullName;

        public string FullName
        {
            get { return _FullName; }
            set { _FullName = value; }
        }
        private string _Email;

        public string Email
        {
            get { return _Email; }
            set { _Email = value; }
        }
        private string _PhoneNumber;

        public string PhoneNumber
        {
            get { return _PhoneNumber; }
            set { _PhoneNumber = value; }
        }
        private string _Tel;

        public string Tel
        {
            get { return _Tel; }
            set { _Tel = value; }
        }
        private string _Gender;

        public string Gender
        {
            get { return _Gender; }
            set { _Gender = value; }
        }
        private DateTime _Birthday;

        public DateTime BirthDay
        {
            get { return _Birthday; }
            set { _Birthday = value; }
        }
        private string _Address;

        public string Address
        {
            get { return _Address; }
            set { _Address = value; }
        }
        private string _Position;

        public string Position
        {
            get { return _Position; }
            set { _Position = value; }
        }
        private string _Status;

        public string Status
        {
            get { return _Status; }
            set { _Status = value; }
        }
        private int _IDDepartment;

        public int IDDepartment
        {
            get { return _IDDepartment; }
            set { _IDDepartment = value; }
        }
        private int _IDGroup;

        public int IDGroup
        {
            get { return _IDGroup; }
            set { _IDGroup = value; }
        }
    }
}
