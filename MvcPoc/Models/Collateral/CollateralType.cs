using System.ComponentModel;

namespace MvcPoc.Web.Models.Collateral
{
	public enum CollateralType
	{
        [Description("None")]
        None = 0,

        [Description("Held in Trust")]
        HeldInTrust = 1,

        [Description("Being administered by a Decedent's Personal Representative")]
        BeingAdministeredByADecedentsPersonalRepresentative = 2
	}
}