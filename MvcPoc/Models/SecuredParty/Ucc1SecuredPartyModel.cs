using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web.Mvc;

namespace MvcPoc.Web.Models.SecuredParty
{
    public class Ucc1SecuredPartyModel
    {
        private int _id;
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }
        [DisplayName("Party Type")]
        public PartyType PartyType { get; set; }

        [DisplayName("Organization Name")]
        public string OrganizationName { get; set; }

        [DisplayName("First Name")]
        public string FirstName { get; set; }

        [DisplayName("Middle Name")]
        public string MiddleName { get; set; }

        [DisplayName("Last Name")]
        public string LastName { get; set; }

        [DisplayName("Suffix")]
        public string Suffix { get; set; }

        [DisplayName("Mailing Address")]
        public string MailingAddress { get; set; }

        [DisplayName("City")]
        public string City { get; set; }

        [DisplayName("State")]
        public string StateCode { get; set; }

        [DisplayName("Postal Code")]
        public string PostalCode { get; set; }

        [DisplayName("Country")]
        public string Country { get; set; }

        public bool CanShowRemoveParty { get; set; }

        public bool IsRemoved { get; set; }

        private readonly List<PartyFavorite> _partyFavorites = new List<PartyFavorite>
            {
                new PartyFavorite
                    {
                        FavoriteId = 1,
                        Name = "Fav 1"
                    },
                new PartyFavorite
                    {
                        FavoriteId = 2,
                        Name = "Fav 2"
                    },
                new PartyFavorite
                    {
                        FavoriteId = 3,
                        Name = "Fav 3"
                    },
                new PartyFavorite
                    {
                        FavoriteId = 4,
                        Name = "Fav 4"
                    },
                new PartyFavorite
                    {
                        FavoriteId = 5,
                        Name = "Fav 5"
                    }
            };

        [DisplayName("Select a Secured Party")]
        public int SelectedPartyFavoriteId { get; set; }

        public IEnumerable<SelectListItem> PartyFavoriteItems
        {
            get
            {
                var favorites = _partyFavorites.Select(d => new SelectListItem
                {
                    Value = d.FavoriteId.ToString(),
                    Text = d.Name
                });
                return favorites;
            }
        }

    }
}