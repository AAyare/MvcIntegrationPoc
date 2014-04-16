using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcPoc.Web.Models.Debtor
{
    public class Ucc1DebtorModel
    {
        public string Suffix
        {
            get { return _suffix; }
            set { _suffix = value; }
        }

        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }

        public string FirstName
        {
            get { return _firstName; }
            set { _firstName = value; }
        }

        public string MiddleName
        {
            get { return _middleName; }
            set { _middleName = value; }
        }

        public string LastName
        {
            get { return _lastName; }
            set { _lastName = value; }
        }

        private string _suffix;
        private string _title;
        private string _firstName;
        private string _middleName;
        private string _lastName;
    }
}