using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.DataObject
{
    public class ODocument
    {
        private string _DocumentID;       

        public string DocumentID
        {
            get { return _DocumentID; }
            set { _DocumentID = value; }
        }
        private string _DocumentNumber;

        public string DocumentNumber
        {
            get { return _DocumentNumber; }
            set { _DocumentNumber = value; }
        }
        private string _Name;

        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }
        private string _Excerpt;

        public string Excerpt
        {
            get { return _Excerpt; }
            set { _Excerpt = value; }
        }
        private string _Content;

        public string Content
        {
            get { return _Content; }
            set { _Content = value; }
        }
        private DateTime _PublishDate;

        public DateTime PublishDate
        {
            get { return _PublishDate; }
            set { _PublishDate = value; }
        }
        private int _PublishOffical;

        public int PublishOffical
        {
            get { return _PublishOffical; }
            set { _PublishOffical = value; }
        }
        private string _Attachs;

        public string Attachs
        {
            get { return _Attachs; }
            set { _Attachs = value; }
        }
        private int _IDDocumentKind;

        public int IDDocumentKind
        {
            get { return _IDDocumentKind; }
            set { _IDDocumentKind = value; }
        }
        private DateTime _CreateDate;

        public DateTime CreateDate
        {
            get { return _CreateDate; }
            set { _CreateDate = value; }
        }
        private int _IDUserCreate;

        public int IDUserCreate
        {
            get { return _IDUserCreate; }
            set { _IDUserCreate = value; }
        }
        private string _UserProcess;

        public string UserProcess
        {
            get { return _UserProcess; }
            set { _UserProcess = value; }
        }
        private string _UserComments;

        public string UserComments
        {
            get { return _UserComments; }
            set { _UserComments = value; }
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
        private DateTime _SendDate;

        public DateTime SendDate
        {
            get { return _SendDate; }
            set { _SendDate = value; }
        }
        private DateTime _ReceiveDate;

        public DateTime ReceiveDate
        {
            get { return _ReceiveDate; }
            set { _ReceiveDate = value; }
        }
        private string _SendOfficals;

        public string SendOfficals
        {
            get { return _SendOfficals; }
            set { _SendOfficals = value; }
        }
        private string _Priority;

        public string Priority
        {
            get { return _Priority; }
            set { _Priority = value; }
        }
        private string _Status;

        public string Status
        {
            get { return _Status; }
            set { _Status = value; }
        }
        private Int64 _TotalResult;

        public Int64 TotalResult
        {
            get { return _TotalResult; }
            set { _TotalResult = value; }
        }
    }
}
