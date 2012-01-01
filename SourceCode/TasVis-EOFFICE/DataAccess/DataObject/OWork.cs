using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.DataObject
{
    public class OWork
    {
        private int _WorkID;

        public int WorkID
        {
            get { return _WorkID; }
            set { _WorkID = value; }
        }
        private string _Name;

        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }
        private string _Decription;

        public string Decription
        {
            get { return _Decription; }
            set { _Decription = value; }
        }
        private string _Content;

        public string Content
        {
            get { return _Content; }
            set { _Content = value; }
        }
        private string _Attachs;

        public string Attachs
        {
            get { return _Attachs; }
            set { _Attachs = value; }
        }
        private int _IDUserCreate;

        public int IDUserCreate
        {
            get { return _IDUserCreate; }
            set { _IDUserCreate = value; }
        }
        private string _IDUserProcess;

        public string IDUserProcess
        {
            get { return _IDUserProcess; }
            set { _IDUserProcess = value; }
        }
        private DateTime _CreateDate;

        public DateTime CreateDate
        {
            get { return _CreateDate; }
            set { _CreateDate = value; }
        }
        private DateTime _StartProcess;

        public DateTime StartProcess
        {
            get { return _StartProcess; }
            set { _StartProcess = value; }
        }
        private DateTime _EndProcess;

        public DateTime EndProcess
        {
            get { return _EndProcess; }
            set { _EndProcess = value; }
        }
        private string _Status;

        public string Status
        {
            get { return _Status; }
            set { _Status = value; }
        }
        private string _Priotity;

        public string Priotity
        {
            get { return _Priotity; }
            set { _Priotity = value; }
        }
        
    }
}
