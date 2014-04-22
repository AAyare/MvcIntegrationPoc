using MvcPoc.Web.Models.Debtor;

namespace MvcPoc.Web.Models
{
    public class Ucc1Model
    {
        public Ucc1Model(string stateCode)
        {
            StateCode = stateCode;
        }

        public string StateCode { get; private set; }

        public Ucc1DebtorModel Ucc1Debtor { get; set; }
    }
}