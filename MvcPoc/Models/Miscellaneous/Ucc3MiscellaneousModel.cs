using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MvcPoc.Web.Models.Miscellaneous
{
    public class Ucc3MiscellaneousModel
    {
        private bool _filedinrealestate;
        private string _optionalFileReference;
        private string _optionalFileReferencetextarea;
        private string _addinfo;
        private string _stateCode;
        private string _FilingType;

         public Ucc3MiscellaneousModel(string stateCode, string filingtype)
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
        public bool FiledinRealestate 
        { 
            get {return _filedinrealestate;}
            set {_filedinrealestate = value;}            
        }
         [Display(Name = "Optional Filer Reference Data")]
        public string OptionalFileReference
        {
            get { return _optionalFileReference; }
            set { _optionalFileReference = value; }
        }
         [DataType(DataType.MultilineText)]
        public string OptionalFileReferencetextarea
        {
            get { return _optionalFileReferencetextarea; }
            set { _optionalFileReferencetextarea = value; }
        }
        [Display(Name = "Use This Space For Additional Information")]
        public string AddInfo 
        {
            get { return _addinfo; }
            set { _addinfo = value; }
        }
    }
}