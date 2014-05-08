using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcPoc.Web.Models.SecuredParty
{
	public class Ucc1SecuredPartySectionModel
	{
	    private string _stateCode;
	    private List<Ucc1SecuredPartyModel> _securedPartySet;

        public Ucc1SecuredPartySectionModel(string stateCode)
        {
            _stateCode = stateCode;
            _securedPartySet = new List<Ucc1SecuredPartyModel>();
        }

        public string StateCode{get { return _stateCode; }}
        public List<Ucc1SecuredPartyModel> SecuredpartySet { get { return _securedPartySet; } }

	    public void AddSecuredPartyToSet(Ucc1SecuredPartyModel ucc1SecuredPartyModel)
	    {
	        _securedPartySet.Add(ucc1SecuredPartyModel);
	    }
	}
}