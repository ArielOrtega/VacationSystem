using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Vacations.Controllers
{
    public class RequestController : Controller
    {
        public ActionResult Serve()
        {
            return View();
        }

        public ActionResult Details()
        {
            return View();
        }
    }
}