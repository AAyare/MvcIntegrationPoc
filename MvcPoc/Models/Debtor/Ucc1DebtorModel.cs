using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web.Mvc;
using MvcPoc.Web.Utils.CustomAttributes;

namespace MvcPoc.Web.Models.Debtor
{
    public class Ucc1DebtorModel
    {
        public Ucc1DebtorModel(string stateCode)
        {
            StateCode = stateCode;
        }

        private int _id;
        private string _suffix;
        private string _title;
        private string _firstName;
        private string _middleName;
        private string _lastName;
        private string _seeInstructions;
        private string _stateCode;
        private bool _isRemoved;
        private bool _canHideRemoveDebtor;
        private readonly List<DebtorFavorite> _debtorFavorites = new List<DebtorFavorite>
            {
                new DebtorFavorite
                    {
                        FavoriteId = 1,
                        Name = "Fav 1"
                    },
                new DebtorFavorite
                    {
                        FavoriteId = 2,
                        Name = "Fav 2"
                    },
                new DebtorFavorite
                    {
                        FavoriteId = 3,
                        Name = "Fav 3"
                    },
                new DebtorFavorite
                    {
                        FavoriteId = 4,
                        Name = "Fav 4"
                    },
                new DebtorFavorite
                    {
                        FavoriteId = 5,
                        Name = "Fav 5"
                    }
            };

        public int SelectedDebtorFavoriteId { get; set; }

        public IEnumerable<SelectListItem> DebtorFavoriteItems
        {
            get
            {
                var favorites = _debtorFavorites.Select(d => new SelectListItem
                    {
                        Value = d.FavoriteId.ToString(),
                        Text = d.Name
                    });
                return favorites;
            }
        }

        public int Id
        {
            get { return _id; }
            set { _id = value; }
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

        //[NotEqualTo("Suffix", ErrorMessage = "Middle Name cannot be equal to Suffix.")]
        [Display(Name = "Middle Name")]
        public string MiddleName
        {
            get { return _middleName; }
            set { _middleName = value; }
        }

        //[NotEqualTo("FirstName", ErrorMessage = "Last Name cannot be equal to First Name.")]
        [Display(Name = "Last Name")]
        public string LastName
        {
            get { return _lastName; }
            set { _lastName = value; }
        }

        [DataType(DataType.MultilineText)]
        [RequiredIfStateCodeIs("StateCode", "SD,NY", ErrorMessage = "See instructions is required for this jurisdiction.")]
        [Display(Name = "See Instructions")]
        public string SeeInstructions
        {
            get { return _seeInstructions; }
            set { _seeInstructions = value; }
        }

        public string StateCode
        {
            get { return _stateCode; }
            private set { _stateCode = value; }
        }

        public bool IsRemoved
        {
            get { return _isRemoved; }
            set { _isRemoved = value; }
        }

        public bool CanShowRemoveDebtor
        {
            get { return _canHideRemoveDebtor; }
            set { _canHideRemoveDebtor = value; }
        }
    }
}