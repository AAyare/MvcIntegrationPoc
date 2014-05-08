using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MvcPoc.Web.Models.Addendum
{
    public class Ucc3AddendumModel
    {
        private string _stateCode;
        private string _FilingType;
        private string _SelectaDebtor;
        private string _PartyType;
        private string _OrganizationName;
        private string _AddInfo;
        private string _FinStmtAmendment;
        private string _NameAddofRecOwner;
        private string _DescofRealEstate;
        private string _Miscellaneous;

        public Ucc3AddendumModel(string stateCode, string filingtype)
        {
            StateCode = stateCode;
            FilingType = filingtype;
        }
        public string StateCode
        {
            get { return _stateCode; }
            set { _stateCode = value; }
        }

        public string FilingType
        {
            get { return _FilingType; }
            set { _FilingType = value; }
        }
        [Display(Name = "Select a Debtor")]
        public string SelectaDebtor
        {
            get { return _SelectaDebtor; }
            set { _SelectaDebtor = value; }
        }       

        [Display(Name = "Party Type")]
        public AddendumPartyType Addendumpartytype
        { get; set; }

        public enum AddendumPartyType
        {
           Business=0,
           Individual =1
        }
        [Display(Name = "Organization Name")]
        public string OrganizationName
        {
            get { return _OrganizationName; }
            set { _OrganizationName = value; }
        }
        [DataType(DataType.MultilineText)]
        [Display(Name = "Additional Information(Box 14)")]
        public string AddInfo
        {
            get { return _AddInfo; }
            set { _AddInfo = value; }
        }

        [Display(Name = "Financing Statement Amendment")]
        public FinancingstatementUcc3 financingstatementUcc3
        { get; set; }

        public enum FinancingstatementUcc3
        {
            [Display(Name = "Covers Timber to be cut")]
            Covers_Timber_to_be_cut = 0,
            [Display(Name = "Covers As-extracted collateral")]
            Covers_As_extracted_collateral = 1,
            [Display(Name = "Fixture Filing")]
            Fixture_Filing = 2
        }

        [DataType(DataType.MultilineText)]
        [Display(Name = "Name and Address of a Record Owner")]
        public string NameAddofRecOwner
        {
            get { return _NameAddofRecOwner; }
            set { _NameAddofRecOwner = value; }
        }

        [DataType(DataType.MultilineText)]
        [Display(Name = "Description of Real Estate")]
        public string DescofRealEstate
        {
            get { return _DescofRealEstate; }
            set { _DescofRealEstate = value; }
        }

        [DataType(DataType.MultilineText)]
        [Display(Name = "Miscellaneous")]
        public string Miscellaneous
        {
            get { return _Miscellaneous; }
            set { _Miscellaneous = value; }
        }
    }
}