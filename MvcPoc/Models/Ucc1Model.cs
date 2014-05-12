using MvcPoc.Web.Models.Addendum;
using MvcPoc.Web.Models.Collateral;
using MvcPoc.Web.Models.Debtor;
using System.Collections.Generic;
using MvcPoc.Web.Models.Miscellaneous;
using MvcPoc.Web.Models.SecuredParty;
using MvcPoc.Web.Models.StateSpecific.FL;

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
        public Ucc1SecuredPartySectionModel Ucc1SecuredPartySection { get; set; }
        public Ucc1CollateralModel Ucc1Collateral { get; set; }
        public FloridaSectionModel FloridaSection { get; set; }
        public Ucc1MiscellaneousModel Ucc1Miscellaneous { get; set; }
        public Ucc1AddendumModel Ucc1Addendum { get; set; }
    }
}