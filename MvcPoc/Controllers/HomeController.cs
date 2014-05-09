using System.Web.Mvc;
using MvcPoc.Web.Models;

namespace MvcPoc.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "This is a hypothetical page 1 of Synergy.";

            return View();
        }

        [HttpPost]
        public ActionResult Index(Page1Model model)
        {
            var filingRouteValues =
                new
                    {
                        @JurisdictionStateCode = model.JurisdictionStateCode,
                        @BillTo = model.BillTo,
                        @FileFor = model.FileFor,
                        @UccType = model.UccType
                    };

            if (model.UccType.ToLower().Equals("ucc1"))
                return RedirectToAction("Ucc1", "CpFiling", filingRouteValues);
            
            if (model.UccType.ToLower().Equals("ucc3"))
            {
                if (model.UccSubType.ToLower().Equals("amendment"))
                  return RedirectToAction("Ucc3Amendment", "CpFiling", filingRouteValues);

                if (model.UccSubType.ToLower().Equals("continuation"))
                    return RedirectToAction("Ucc3Continuation", "CpFiling", filingRouteValues);

                if (model.UccSubType.ToLower().Equals("assignment"))
                    return RedirectToAction("Ucc3Assignment", "CpFiling", filingRouteValues);

                if (model.UccSubType.ToLower().Equals("termination"))
                    return RedirectToAction("Ucc3Termination", "CpFiling", filingRouteValues);

            }

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
