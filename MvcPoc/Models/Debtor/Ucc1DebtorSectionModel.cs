using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MvcPoc.Web.Utils.CustomAttributes;

namespace MvcPoc.Web.Models.Debtor
{
    public class Ucc1DebtorSectionModel
    {

        public Ucc1DebtorSectionModel(string stateCode, List<Ucc1DebtorModel> debtors)
        {
            _stateCode = stateCode;
            _debtors = debtors;
        }

        private string _stateCode;
        private string _account;
        private List<Ucc1DebtorModel> _debtors;

        public string Account
        {
            get { return _account; }
            set { _account = value; }
        }

        public List<Ucc1DebtorModel> Debtors
        {
            get { return _debtors; }
            set { _debtors = value; }
        }

        public string StateCode
        {
            get { return _stateCode; }
            private set { _stateCode = value; }
        }
    }
}