using System.ComponentModel;

namespace MvcPoc.Web.Models.StateSpecific.FL
{
    public enum DocumentStampTaxType
    {
        [Description("Not Applicable")]
        NotApplicable = 0,

        [Description("Paid by Secured Party")]
        PaidBySecuredParty = 1,

        [Description("Paid by CSC")]
        PaidByCsc = 2
    }
}