using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcPoc.Web.DAL.Security;
using MvcPoc.Web.DAL;
namespace MvcPoc.Web.Controllers
{
    public class BaseController : Controller
    {
        protected virtual new CustomPrincipal User
        {
            get { return HttpContext.User as CustomPrincipal;  }
        }
    }
}
