﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Vacations.Controllers
{
   // [Authorize]
    public class ProfileController : Controller
    {
        // GET: Profile
        public ActionResult Profile()
        {
            return View();
        }
    }
}