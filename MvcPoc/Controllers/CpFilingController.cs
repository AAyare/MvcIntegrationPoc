using System;
using System.Web.Mvc;
using MvcPoc.Web.Models;
using MvcPoc.Web.Models.Debtor;

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
        public ActionResult Ucc1(Ucc1Model model)
        {
            if (TryUpdateModel(model))
            {
                RedirectToAction("Index", model);
            }

            return View(model);
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
