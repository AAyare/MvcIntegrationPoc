using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace MvcPoc.Web.Models
{
    public class Page1Model
    {
        [DisplayName("Please enter a valid State Code")]
        public string JurisdictionStateCode { get; set; }


        public string FileFor { get; set; }
        public string BillTo { get; set; }
        public bool Rush { get; set; }

        [DisplayName("Enter Ucc1 or Ucc3")]
        public string UccType { get; set; }

        [DisplayName("Enter Amendment/Continuation/Assignment/Termination if UCC3")]
        public string UccSubType { get; set; }
    }
}