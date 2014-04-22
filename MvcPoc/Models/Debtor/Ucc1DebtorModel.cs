using System.ComponentModel.DataAnnotations;
using MvcPoc.Web.Utils.CustomAttributes;

namespace MvcPoc.Web.Models.Debtor
{
    public class Ucc1DebtorModel
    {
        public Ucc1DebtorModel(string stateCode)
        {
            StateCode = stateCode;
        }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Suffix is required.")]
        public string Suffix
        {
            get { return _suffix; }
            set { _suffix = value; }
        }
        
        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }

        [Required(AllowEmptyStrings = false, ErrorMessage = "First name is required.")]
        [Display(Name = "First Name")]
        public string FirstName
        {
            get { return _firstName; }
            set { _firstName = value; }
        }

        [NotEqualTo("Suffix", ErrorMessage = "Middle Name cannot be equal to Suffix.")]
        [Display(Name = "Middle Name")]
        public string MiddleName
        {
            get { return _middleName; }
            set { _middleName = value; }
        }

        [NotEqualTo("FirstName", ErrorMessage = "Last Name cannot be equal to First Name.")]
        [Display(Name = "Last Name")]
        public string LastName
        {
            get { return _lastName; }
            set { _lastName = value; }
        }

        [DataType(DataType.MultilineText)]
        [RequiredIfStateCodeIs("StateCode", "SD,NY")]
        [Display(Name = "See Instructions")]
        public string SeeInstructions
        {
            get { return _seeInstructions; }
            set { _seeInstructions = value; }
        }

        private string _suffix;
        private string _title;
        private string _firstName;
        private string _middleName;
        private string _lastName;
        private string _seeInstructions;
        private string _stateCode;

        public string StateCode
        {
            get { return _stateCode; }
            private set { _stateCode = value; }
        }
    }
}