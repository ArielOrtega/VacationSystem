using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Vacations.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(string message = "")
        {
            ViewBag.Message = message;
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        [HttpPost]
        public ActionResult Login(string user, string pass)
        {
            Person1 person = new Person1();


            using (var context = new EntitiesVacation())
            {
                person = context.Person1
                    .Where(personItem => personItem.password == pass && personItem.name == user).FirstOrDefault();
            }
           
            if (person != null)
            {
                FormsAuthentication.SetAuthCookie(person.name, true);
                return RedirectToAction("Index", "Profile");
            }
            else
            {
                return RedirectToAction("Index", new { message = "User not found" });
            }


            return View();
        }

        [Authorize]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index");
        }

    }
}