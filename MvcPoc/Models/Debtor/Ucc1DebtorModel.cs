using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web.Mvc;
using MvcPoc.Web.Utils.CustomAttributes;

namespace MvcPoc.Web.Models.Debtor
{
    public class Ucc1DebtorModel
    {
        public Ucc1DebtorModel(string stateCode, string filingtype)
        {
            StateCode = stateCode;
            FilingType = filingtype;
        }

        private int _id;
        private string _suffix;
        private string _title;
        private string _firstName;
        private string _middleName;
        private string _lastName;
        private string _seeInstructions;
        private string _stateCode;
        private string _filingtype;
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

        [DisplayName("Select a Debtor")]
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

        [DisplayName("Party Type")]
        public PartyType PartyType { get; set; }

        public string Suffix
        {
            get { return _suffix; }
            set { _suffix = value; }
        }

        [DisplayName("Organization Name")]
        public string OrganizationName { get; set; }

        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }

        [Display(Name = "First Name")]
        public string FirstName
        {
            get { return _firstName; }
            set { _firstName = value; }
        }

        [Display(Name = "Middle Name")]
        public string MiddleName
        {
            get { return _middleName; }
            set { _middleName = value; }
        }

        [Display(Name = "Last Name")]
        public string LastName
        {
            get { return _lastName; }
            set { _lastName = value; }
        }

        [DisplayName("Mailing Address")]
        public string MailingAddress { get; set; }

        [DisplayName("City")]
        public string City { get; set; }

        [DisplayName("Postal Code")]
        public string PostalCode { get; set; }

        [DisplayName("Country")]
        public string Country { get; set; }

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

        public string FilingType
        {
            get { return _filingtype; }
            private set { _filingtype = value; }
        }
    }
}