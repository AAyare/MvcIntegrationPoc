using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace MvcPoc.Web.Models.Addendum
{
    public class Ucc1AddendumModel
    {
        private bool _filedinrealestate;
        private string _NameAddressofrecordowner;
        private string _DescriptionofRealEstate;
        private string _AddAttachment;
        private string _AttachmentDescription;
        private string _Miscellaneous;
        private string _stateCode;
        private string _FilingType;
        private string _UploadDesc;
        private string _UploadAttachment;

        public Ucc1AddendumModel(string stateCode, string filingtype)
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

         [Display(Name = "Filed in Real Estate Records")]
        public bool FiledinRealEstate { get; set; }
        public bool FiledinRealestate
        {
            get { return _filedinrealestate; }
            set { _filedinrealestate = value; }
        }
         
        public AddendumFinancingStatement AddendumFinancingstatement
        { get; set; }

        public enum AddendumFinancingStatement
        {            
            None=0,
            [Description("Timber to be cut")]
            Timber_to_be_cut = 1,
            [Description("As-extracted collateral")]
            As_extracted_collateral = 2,
            [Description("Fixture Filing")]
            Fixture_Filing = 3
        }

        [Display(Name = "Financing Statement")]
        public AddendumFinancingstmt Addendumfinancingstmt
        { get; set; }
        public enum AddendumFinancingstmt
        {
            [Description("Covers Timber to be cut")]
            Covers_Timber_to_be_cut = 0,
            [Description("Covers As-extracted collateral")]
            Covers_As_extracted_collateral = 1,
            [Description("Fixture Filing")]
            Fixture_Filing = 2
        }
        [DataType(DataType.MultilineText)]
        [Display(Name = "Name and Address of Record Owner")]
        public string NameAddressofrecordowner
        {
            get { return _NameAddressofrecordowner; }
            set { _NameAddressofrecordowner = value; }
        }

        [DataType(DataType.MultilineText)]
         [Display(Name = "Description Of Real Estate")]
        public string DescriptionofRealEstate
        {
            get { return _DescriptionofRealEstate; }
            set { _DescriptionofRealEstate = value; }
        }

        
         [Display(Name = "Add Attachment")]
        public string AddAttachment
        {
            get { return _AddAttachment; }
            set { _AddAttachment = value; }
        }

         [Display(Name = "Attachment Description")]
        public string AttachmentDescription
        {
            get { return _AttachmentDescription; }
            set { _AttachmentDescription = value; }
        }
        [DataType(DataType.MultilineText)]
        public string Miscellaneous
        {
            get { return _Miscellaneous; }
            set { _Miscellaneous = value; }
        }

         [Display(Name = "Debtor is a")]
        public Debtor Debtoris
        { get; set; }

        public enum Debtor
        {
            None=0,
            Trust=1,
            Trustee =2,
            [Description("Decedent's Estate")]
            Decedents_Estate = 3
        }

         [Display(Name = "Alternate Filing Type")]
        public AddendumAlternateFilingType Addendumalternatefilingtype
        { get; set; }

        public enum AddendumAlternateFilingType
        {
            None = 0,
            [Description("Debtor is a Transmitting Utility")]
            A_Debtor_is_a_Transmitting_Utility = 1,
            [Description("Manufactured Home Transaction")]
            Manufactured_Home_Transaction = 2,
            [Description("Public Finance Transaction")]
            Public_Finance_Transaction = 3
        }

        [Display(Name = "Upload Property")]
        public string UploadAttachment
        {
            get { return _UploadAttachment; }
            set { _UploadAttachment = value; }
        }

        [Display(Name = "Upload Description")]
        public string UploadDesc
        {
            get { return _UploadDesc; }
            set { _UploadDesc = value; }
        }
        
    }
}