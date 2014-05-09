using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace MvcPoc.Web.Models.StateSpecific.FL
{
    public class DocumentaryStampTaxCalculationModel
    {
        [DisplayName("Indebtedness Amount of Collateral")]
        public int IndebtednessAmountOfCollateral { get; set; }

        [DisplayName("Tax Rate")]
        public string TaxRate { get { return "$0.35 per $100.00"; } }

        [DisplayName("Total Tax Amount Due")]
        public int TotalTaxAmountDue { get; set; }
    }
}