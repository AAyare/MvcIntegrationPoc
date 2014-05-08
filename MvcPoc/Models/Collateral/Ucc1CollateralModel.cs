using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MvcPoc.Web.Models.Collateral
{
	public class Ucc1CollateralModel
	{
        [DisplayName("Append Collateral")]
        public bool AppendCollateral { get; set; }

        [DisplayName("Collateral")]
        [DataType(DataType.MultilineText)]
        public string Collateral { get; set; }

        [DisplayName("Collateral is")]
        public CollateralType CollateralType { get; set; }
	}
}