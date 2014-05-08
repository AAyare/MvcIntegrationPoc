﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcPoc.Web.Models.Miscellaneous
{
    
    public class Ucc1MiscellaneousModel
    {

        private string _optionalFileReference;
        private string _stateCode;
        private string _FilingType;
        private string _optionalFileReferencetextarea;

        public Ucc1MiscellaneousModel(string stateCode, string filingtype)
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
        public Filedinrealestate FiledinRealEstate { get; set; }
        public enum Filedinrealestate
        {
            Yes = 0,
            No = 1
        }
        [Display(Name = "Optional Filer Ref")]
        public string OptionalFileReference
        {
            get { return _optionalFileReference; }
            set { _optionalFileReference = value; }
        }

        public string OptionalFileReferencetextarea
        {
            get { return _optionalFileReferencetextarea; }
            set { _optionalFileReferencetextarea = value; }
        }

        public Miscellaneous MiscellaneousType
        { get; set; }

        public enum Miscellaneous
        {
            None = 0,
            [Display(Name = "Lessee/Lessor")]
            Lessee_Lessor = 1,
            [Display(Name = "Consignee/Consignor")]
            Consignee_Consignor = 2,
            [Display(Name = "Bailee/Bailor")]
            Bailee_Bailor = 3,
            [Display(Name = "Seller/Buyer")]
            Seller_Buyer = 4,
            [Display(Name = "AG Lien")]
            AG_Lien = 5,
            [Display(Name = "Non-UCC Filing")]
            Non_UCC_Filing = 6
        }

        [Display(Name = "Alternate Filing Type")]
        public AlternateFilingType AlternatefilingType
        { get; set; }

        public enum AlternateFilingType
        {
            None = 0,
            [Display(Name = "Public-Finance Transaction")]
            Public_Finance_Transaction = 1,
            [Display(Name = "Manufactured-Home Transaction")]
            Manufactured_Home_Transaction = 2,
            [Display(Name = "A Debtor is a Transmitting Utility")]
            A_Debtor_is_a_Transmitting_Utility = 3           
        }
        public Alternate alternate
        { get; set; }

        public enum Alternate
        {
            None = 0,
            [Display(Name = "Agricultural Lien")]
            Agricultural_Lien = 1,
            [Display(Name = "Non-UCC Filing")]
            Non_UCC_Filing = 2
        }
        [Display(Name = "Alternative Designation")]
        public AlternativeDesignation Alternativedesignation
        { get; set; }

        public enum AlternativeDesignation
        {
            [Display(Name = "Lessee/Lessor")]
            Lessee_Lessor = 0,
            [Display(Name = "Consignee/Consignor")]
            Consignee_Consignor = 1,
            [Display(Name = "Bailee/Bailor")]
            Bailee_Bailor = 2,
            [Display(Name = "Seller/Buyer")]
            Seller_Buyer = 3,
            [Display(Name = "Licensee/Licensor")]
            Licensee_Licensor = 4
        }

    }
}