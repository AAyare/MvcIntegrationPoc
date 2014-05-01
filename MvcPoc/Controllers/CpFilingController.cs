using System;
using System.Collections.Generic;
using System.Web.Mvc;
using MvcPoc.Web.Models;
using MvcPoc.Web.Models.Debtor;
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
            return View(ucc1Model);
        }

       [HttpPost]
       [MultiButton(MatchFormKey = "action", MatchFormValue = "Create Filing")] 
        public ActionResult Ucc1(Ucc1Model model,string stateCode)
        {
            if (TryUpdateModel(model))
            {
                RedirectToAction("Index", model);
            }

            return View(model);
        }
       
        [MultiButton(MatchFormKey = "action", MatchFormValue = "Add Debtor")]
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult AddDebtor(Ucc1Model viewModel)
        {
            try
            {
                viewModel.Ucc1Debtors.Add(new Ucc1DebtorModel(viewModel.Ucc1Debtors[0].StateCode){});
                return View("Ucc1", viewModel);
            }
            catch
            {
                return View("Ucc1");
            }
        }

        public ActionResult Try()
        {
            var model = new CustomValidationModel();
            return View(model);
        }

        [ChildActionOnly]
        public ActionResult RenderDebtor(string stateCode)
        {
            var debtor = new Ucc1DebtorModel(stateCode);
            return PartialView("DebtorSection/_EditDebtorSection", debtor);
        }

        [ChildActionOnly]
        public ActionResult RenderDebtorDisplay(string stateCode)
        {
            var debtor = new Ucc1DebtorModel(stateCode);
            return PartialView("DebtorSection/_ViewDebtorSection", debtor);
        }
    }
}
