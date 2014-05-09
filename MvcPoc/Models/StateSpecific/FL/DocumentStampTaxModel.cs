using System.ComponentModel;

namespace MvcPoc.Web.Models.StateSpecific.FL
{
    public class DocumentStampTaxModel
    {
        [DisplayName("Documentary Stamp Tax")]
        public DocumentStampTaxType StampTaxType { get; set; }
    }
}