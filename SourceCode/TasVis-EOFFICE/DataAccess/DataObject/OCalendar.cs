using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.DataObject
{
    public class OCalendar
    {
        private int _CalendarID;

        public int CalendarID
        {
            get { return _CalendarID; }
            set { _CalendarID = value; }
        }
        private string _Name;

        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }
        private string _Content;

        public string Content
        {
            get { return _Content; }
            set { _Content = value; }
        }
        private DateTime _StartDate;

        public DateTime StartDate
        {
            get { return _StartDate; }
            set { _StartDate = value; }
        }
        private DateTime _EndDate;

        public DateTime EndDate
        {
            get { return _EndDate; }
            set { _EndDate = value; }
        }
        private string _UserJoin;

        public string UserJoin
        {
            get { return _UserJoin; }
            set { _UserJoin = value; }
        }
        private string _Address;

        public string Address
        {
            get { return _Address; }
            set { _Address = value; }
        }

    }
}
