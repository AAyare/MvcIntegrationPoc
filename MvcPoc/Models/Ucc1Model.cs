using MvcPoc.Web.Models.Debtor;
using System.Collections.Generic;

namespace MvcPoc.Web.Models
{
    public class Ucc1Model
    {
        public Ucc1Model(string stateCode, string filingtype)
        {
            StateCode = stateCode;
            FilingType = filingtype;
        }

        public bool ShowFloridaSection
        {
            get { return StateCode.ToLower().Equals("fl") || StateCode.ToLower().Equals("florida"); }
        }

        public string StateCode { get; private set; }
        public string FilingType { get; private set; }

        public Ucc1DebtorModel[] Ucc1Debtors { get; set; }
    }
}