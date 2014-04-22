using System.ComponentModel.DataAnnotations;
using MvcPoc.Web.Utils.CustomAttributes;

namespace MvcPoc.Web.Models
{
    public class CustomValidationModel
    {
        public string Property { get; set; }

        [Required, NotEqualTo("Property", ErrorMessage = "These fields cannot match.")]
        public string DifferentProperty { get; set; }
    }
}