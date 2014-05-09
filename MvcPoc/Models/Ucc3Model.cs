using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcPoc.Web.Models
{
    public class Ucc3Model
    {
        public Ucc3Model(string stateCode, string filingtype)
            {
                StateCode = stateCode;
                FilingType = filingtype;
            }

            public string StateCode { get; private set; }
            public string FilingType { get; private set; }        
    }
}