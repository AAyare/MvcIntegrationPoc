using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MvcPoc.Web.Utils.CustomAttributes;

namespace MvcPoc.Web.Models.Debtor
{
    public class Ucc1DebtorSectionModel
    {

        public Ucc1DebtorSectionModel()
        {
            _debtors = new List<Ucc1DebtorModel>();
        }

        private string _stateCode;
        private string _account;
        private List<Ucc1DebtorModel> _debtors;

        public List<Ucc1DebtorModel> Debtors
        {
            get { return _debtors; }
            set { _debtors = value; }
        }

        public string StateCode
        {
            get { return _stateCode; }
            set { _stateCode = value; }
        }
    }
}