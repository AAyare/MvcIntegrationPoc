﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcPoc.Web.DAL.Security;
namespace MvcPoc.Web.Controllers
{
[CustomAuthorize(Roles= "User")]
    public class UserController : BaseController
    {
        //
        // GET: /User/
        public ActionResult Index()
        {
            return View();
        }

    }
}

