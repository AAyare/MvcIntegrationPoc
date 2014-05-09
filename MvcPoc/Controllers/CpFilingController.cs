using System;
using System.Collections.Generic;
using System.Web.Mvc;
using MvcPoc.Web.Models;
using MvcPoc.Web.Models.Collateral;
using MvcPoc.Web.Models.Debtor;
using MvcPoc.Web.Models.SecuredParty;
using MvcPoc.Web.Models.StateSpecific.FL;
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

        public ActionResult Ucc1(Page1Model model)
        {
            var ucc1Model = new Ucc1Model(model.JurisdictionStateCode);
            ucc1Model.Ucc1Debtors = new List<Ucc1DebtorModel>()
                                         {
                                             new Ucc1DebtorModel(model.JurisdictionStateCode) {Id=0}
                                         }.ToArray();

            return View(ucc1Model);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        [FormPostByFieldName]
        public ActionResult Ucc1(Ucc1Model model)
        {
            if (TryUpdateModel(model))
            {
                return View("Ucc1", model);
            }

            return View("Ucc1", model);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        [FormPostByFieldName]
        public ActionResult AddDebtor(Ucc1Model viewModel)
        {
            try
            {
                List<Ucc1DebtorModel> lst = new List<Ucc1DebtorModel>();
                lst.AddRange(viewModel.Ucc1Debtors);
                lst.Add(new Ucc1DebtorModel(viewModel.Ucc1Debtors[0].StateCode) { Id = viewModel.Ucc1Debtors.Length, CanShowRemoveDebtor = true });
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

        public ActionResult RenderFloridaSection()
        {
            var floridaSectionModel = new FloridaSectionModel();
            floridaSectionModel.DocumentStampTax = new DocumentStampTaxModel();
            floridaSectionModel.DocumentaryStampTaxCalculation = new DocumentaryStampTaxCalculationModel();
            return PartialView("StateSpecific/_FloridaSection", floridaSectionModel);
        }
    }
}
