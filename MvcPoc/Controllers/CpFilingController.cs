using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcPoc.Web.Controllers
{
    public class CpFilingController : BaseFilingController
    {
        //
        // GET: /CpFiling/

        public ActionResult Ucc1()
        {
            return View();
        }

    }
}
