using System;
using System.Collections.Generic;
using System.Web.Mvc;
using MvcPoc.Web.Models;
using MvcPoc.Web.Models.Collateral;
using MvcPoc.Web.Models.Debtor;
using MvcPoc.Web.Models.SecuredParty;
using MvcPoc.Web.Utils.CustomActionNames;

namespace MvcPoc.Web.Controllers
{
    public class CpFilingController : BaseFilingController
    {
        //
        // GET: /CpFiling/

        public ActionResult Index(Ucc1Model ucc1)
        {
            return View(ucc1);
        }

        public ActionResult Ucc1(string stateCode)
        {
            var model = new Ucc1Model(stateCode)
                            {
                                Ucc1Debtors =
                                    (new List<Ucc1DebtorModel>()
                                         {
                                             new Ucc1DebtorModel(stateCode) {}
                                         }).ToArray()
                            };
            return View(model);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        [MultiButton(MatchFormKey = "action", MatchFormValue = "Create Filing")]
        public ActionResult Ucc1(Ucc1Model model)
        {
            if (TryUpdateModel(model))
            {
                RedirectToAction("Index", model);
            }

            return View(model);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        [MultiButton(MatchFormKey = "action", MatchFormValue = "Add Additional Debtor")]
        public ActionResult AddDebtor(Ucc1Model viewModel)
        {
            try
            {
                List<Ucc1DebtorModel> lst = new List<Ucc1DebtorModel>();
                lst.AddRange(viewModel.Ucc1Debtors);
                lst.Add(new Ucc1DebtorModel(viewModel.Ucc1Debtors[0].StateCode) { });
                viewModel.Ucc1Debtors = lst.ToArray();
                return View("Ucc1", viewModel);
            }
            catch
            {
                return View("Ucc1",viewModel);
            }
        }

        [ChildActionOnly]
        public ActionResult RenderDebtor(string stateCode)
        {
            var debtor = new Ucc1DebtorModel(stateCode);
            return PartialView("DebtorSection/_EditDebtorSection", debtor);
        }

        [ChildActionOnly]
        public ActionResult RenderSecuredPartySection(string statecode)
        {
            var securedPartyModel = new Ucc1SecuredPartySectionModel(statecode);
            securedPartyModel.AddSecuredPartyToSet(new Ucc1SecuredPartyModel());
            return PartialView("SecuredPartySection/_SecuredPartySection", securedPartyModel);
        }

        [ChildActionOnly]
        public ActionResult RenderCollateralSection(string statecode)
        {
            var collateralModel = new Ucc1CollateralModel();
            return PartialView("CollateralSection/_Collateral", collateralModel);
        }
    }
}
