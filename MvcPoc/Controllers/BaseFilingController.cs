using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcPoc.Web.Models.Debtor;

namespace MvcPoc.Web.Controllers
{
    public class BaseFilingController : Controller
    {
        //
        // GET: /BaseFiling/
        public JsonResult getFavoriteDebtor(int id)
        {
            var model = new Dictionary<int, Ucc1DebtorModel>
                {
                    {
                        1,
                        new Ucc1DebtorModel("SD", "Ucc1")
                            {
                                FirstName = "Test 1",
                                MiddleName = "Test 1 Middle Name",
                                LastName = "Test 1 Last Name",
                                Suffix = "Debtor"
                            }
                    },
                    {
                        2,
                        new Ucc1DebtorModel("SD", "Ucc1")
                            {
                                FirstName = "Test 2",
                                MiddleName = "Test 2 Middle Name",
                                LastName = "Test 2 Last Name",
                                Suffix = "Debtor"
                            }
                    },
                    {
                        3,
                        new Ucc1DebtorModel("SD", "Ucc1")
                            {
                                FirstName = "Test 3",
                                MiddleName = "Test 3 Middle Name",
                                LastName = "Test 3 Last Name",
                                Suffix = "Debtor"
                            }
                    },
                    {
                        4,
                        new Ucc1DebtorModel("SD", "Ucc1")
                            {
                                FirstName = "Test 4",
                                MiddleName = "Test 4 Middle Name",
                                LastName = "Test 4 Last Name",
                                Suffix = "Debtor"
                            }
                    },
                    {
                        5,
                        new Ucc1DebtorModel("SD", "Ucc1")
                            {
                                OrganizationName = "Organization 5",
                                FirstName = "Test 5",
                                MiddleName = "Test 5 Middle Name",
                                LastName = "Test 5 Last Name",
                                Suffix = "Debtor"
                            }
                    }
                };

            return Json(model.First(k => k.Key.Equals(id)).Value, JsonRequestBehavior.AllowGet);
        }

        public JsonResult getFavoriteParty(int id)
        {
            var model = new Dictionary<int, Ucc1DebtorModel>
                {
                    {
                        1,
                        new Ucc1DebtorModel("SD", "Ucc1")
                            {
                                OrganizationName = "Organization 1",
                                FirstName = "Test 1",
                                MiddleName = "Test 1 Middle Name",
                                LastName = "Test 1 Last Name",
                                Suffix = "Debtor"
                            }
                    },
                    {
                        2,
                        new Ucc1DebtorModel("SD","Ucc1")
                            {
                                OrganizationName = "Organization 2",
                                FirstName = "Test 2",
                                MiddleName = "Test 2 Middle Name",
                                LastName = "Test 2 Last Name",
                                Suffix = "Debtor"
                            }
                    },
                    {
                        3,
                        new Ucc1DebtorModel("SD","Ucc1")
                            {
                                OrganizationName = "Organization 3",
                                FirstName = "Test 3",
                                MiddleName = "Test 3 Middle Name",
                                LastName = "Test 3 Last Name",
                                Suffix = "Debtor"
                            }
                    },
                    {
                        4,
                        new Ucc1DebtorModel("SD","Ucc1")
                            {
                                OrganizationName = "Organization 4",
                                FirstName = "Test 4",
                                MiddleName = "Test 4 Middle Name",
                                LastName = "Test 4 Last Name",
                                Suffix = "Debtor"
                            }
                    },
                    {
                        5,
                        new Ucc1DebtorModel("SD","Ucc1")
                            {
                                OrganizationName = "Organization 5",
                                FirstName = "Test 5",
                                MiddleName = "Test 5 Middle Name",
                                LastName = "Test 5 Last Name",
                                Suffix = "Debtor"
                            }
                    }
                };

            return Json(model.First(k => k.Key.Equals(id)).Value, JsonRequestBehavior.AllowGet);
        }
    }
}
