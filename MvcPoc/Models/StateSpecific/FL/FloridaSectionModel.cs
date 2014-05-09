using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcPoc.Web.Models.StateSpecific.FL
{
    public class FloridaSectionModel
    {
        public DocumentStampTaxModel DocumentStampTax { get; set; }
        public DocumentaryStampTaxCalculationModel DocumentaryStampTaxCalculation { get; set; }
    }
}