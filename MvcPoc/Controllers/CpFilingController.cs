using System;
using System.Collections.Generic;
using System.Web.Mvc;
using MvcPoc.Web.Models;
using MvcPoc.Web.Models.Collateral;
using MvcPoc.Web.Models.Debtor;
using MvcPoc.Web.Models.SecuredParty;
using MvcPoc.Web.Utils.CustomActionNames;
using MvcPoc.Web.Models.Miscellaneous;
using MvcPoc.Web.Models.Addendum;
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
            var ucc1Model = new Ucc1Model(model.JurisdictionStateCode, model.UccType);
            ucc1Model.Ucc1Debtors = new List<Ucc1DebtorModel>()
                                         {
                                             new Ucc1DebtorModel(model.JurisdictionStateCode, model.UccType) {Id=0}
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
                lst.Add(new Ucc1DebtorModel(viewModel.Ucc1Debtors[0].StateCode,viewModel.Ucc1Debtors[0].FilingType) { Id = viewModel.Ucc1Debtors.Length, CanShowRemoveDebtor = true });
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
            var debtor = new Ucc1DebtorModel(stateCode, "UCC1");
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
        [ChildActionOnly]
        public ActionResult RenderMiscellaneous(string state, string FilingType)
        {
            if (FilingType.ToLower().Equals("ucc1"))
            {
                var miscellaneous = new Ucc1MiscellaneousModel(state, FilingType);
                return PartialView("MiscellaneousSection/_EditMiscellaneousSectionUcc1", miscellaneous);
            }
            else
            {
                return Content("");
            }
        }


        [ChildActionOnly]
        public ActionResult RenderMiscellaneousUcc1NonRA9(string state, string FilingType)
        {
            if (state.ToLower().Equals("az") && FilingType.ToLower().Equals("ucc1"))
            {
                var miscellaneous = new Ucc1MiscellaneousModel(state, FilingType);
                return PartialView("MiscellaneousSection/_EditMiscUcc1NonRA9", miscellaneous);
            }
            else
            {
                return Content("");
            }
        }


        [ChildActionOnly]
        public ActionResult RenderMiscellaneousUcc1NonRA9misctype(string state, string FilingType)
        {
            if (state.ToLower().Equals("az") && FilingType.ToLower().Equals("ucc1"))
            {
                var miscellaneous = new Ucc1MiscellaneousModel(state, FilingType);
                return PartialView("MiscellaneousSection/_EditMiscUcc1NonRA9misctype", miscellaneous);
            }
            else
            {
                return Content("");
            }
        }

        [ChildActionOnly]
        public ActionResult RenderMiscellaneousUcc1RA9(string state, string FilingType)
        {
            if (state.ToLower().Equals("sd") && FilingType.ToLower().Equals("ucc1"))
            {
                var miscellaneous = new Ucc1MiscellaneousModel(state, FilingType);
                return PartialView("MiscellaneousSection/_EditMiscUcc1RA9", miscellaneous);
            }
            else
            {
                return Content("");
            }
        }

        [ChildActionOnly]
        public ActionResult RenderMiscellaneousUcc3(string state, string FilingType)
        {
            if (FilingType.ToLower().Equals("ucc3"))
            {
                var miscellaneous = new Ucc3MiscellaneousModel(state, FilingType);
                return PartialView("MiscellaneousSection/_EditMiscellaneousSectionUcc3", miscellaneous);
            }
            else
            {
                return Content("");
            }
        }

        [ChildActionOnly]
        public ActionResult RenderMiscellaneousUcc3RA9(string state, string FilingType)
        {
            if (FilingType.ToLower().Equals("ucc3"))
            {
                var miscellaneous = new Ucc3MiscellaneousModel(state, FilingType);
                return PartialView("MiscellaneousSection/_EditMiscUcc3RA9", miscellaneous);
            }
            else
            {
                return Content("");
            }
        }

        [ChildActionOnly]
        public ActionResult RenderMiscellaneousUcc3NonRA9(string state, string FilingType)
        {
            if (state.ToLower().Equals("az") && FilingType.ToLower().Equals("ucc3"))
            {
                var miscellaneous = new Ucc3MiscellaneousModel(state, FilingType);
                return PartialView("MiscellaneousSection/_EditMiscUcc3NonRA9", miscellaneous);
            }
            else
            {
                return Content("");
            }
        }

        [ChildActionOnly]
        public ActionResult RenderAddendumUcc1(string state, string FilingType)
        {
            if (FilingType.ToLower().Equals("ucc1"))
            {
                if (state.ToLower().Equals("sd"))
                {
                    var addendum = new Ucc1AddendumModel(state, FilingType);
                    return PartialView("AddendumSection/_EditAddendumSectionUcc1RA9", addendum);
                }
                else if (state.ToLower().Equals("az"))
                {
                    var addendum = new Ucc1AddendumModel(state, FilingType);
                    return PartialView("AddendumSection/_EditAddendumSectionUcc1NonRA9", addendum);
                }
                else
                {
                    return Content("");
                }
            }
            else
            {
                return Content("");
            }
        }

        [ChildActionOnly]
        public ActionResult RenderAddendumUcc3RA9(string state, string FilingType)
        {
            if (FilingType.ToLower().Equals("ucc3") && state.ToLower().Equals("sd"))
            {
                var addendum = new Ucc3AddendumModel(state, FilingType);
                return PartialView("AddendumSection/_EditAddendumSectionUcc3RA9", addendum);
            }
            else
            {
                return Content("");
            }
        }

        public ActionResult Ucc3Amendment(Page1Model model)
        {
            var ucc3Model = new Ucc3Model(model.JurisdictionStateCode, model.UccType);
            return View("Ucc3",ucc3Model);
        }

        public ActionResult Ucc3Continuation(Page1Model model)
        {
            var ucc3Model = new Ucc3Model(model.JurisdictionStateCode, model.UccType);
            return View("Ucc3", ucc3Model);
        }

        public ActionResult Ucc3Assignment(Page1Model model)
        {
            var ucc3Model = new Ucc3Model(model.JurisdictionStateCode, model.UccType);
            return View("Ucc3", ucc3Model);
        }

        public ActionResult Ucc3Termination(Page1Model model)
        {
            var ucc3Model = new Ucc3Model(model.JurisdictionStateCode, model.UccType);
            return View("Ucc3", ucc3Model);
        }
    }
}
