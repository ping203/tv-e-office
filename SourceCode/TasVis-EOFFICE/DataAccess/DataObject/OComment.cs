using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.DataObject
{
    public class OComment
    {
        private string _CommentID;

        public string CommentID
        {
            get { return _CommentID; }
            set { _CommentID = value; }
        }
        private string _Title;

        public string Title
        {
            get { return _Title; }
            set { _Title = value; }
        }
        private string _Content;

        public string Content
        {
            get { return _Content; }
            set { _Content = value; }
        }
        private string _IDUserCreate;

        public string IDUserCreate
        {
            get { return _IDUserCreate; }
            set { _IDUserCreate = value; }
        }
        private string _IDDocument;

        public string IDDocument
        {
            get { return _IDDocument; }
            set { _IDDocument = value; }
        }
        private int _IDWork;

        public int IDWork
        {
            get { return _IDWork; }
            set { _IDWork = value; }
        }
        private string _Attachs;

        public string Attachs
        {
            get { return _Attachs; }
            set { _Attachs = value; }
        }
        private DateTime _CreateDate;

        public DateTime CreateDate
        {
            get { return _CreateDate; }
            set { _CreateDate = value; }
        }
    }
}
