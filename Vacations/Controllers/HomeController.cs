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
        public ActionResult Login(string email, string pass)
        {
            Person1 person = new Person1();
            string rol;


            using (var context = new EntitiesVacation())
            {
                person = context.Person1
                    .Where(personItem => personItem.password == pass && personItem.email == email).FirstOrDefault();
                    //rol = person.Rol.FirstOrDefault().name;
            }


            if (person != null)
            {
                Session["userName"] = person.name;
                Session["idUser"] = person.personaId;
                Session["identification"] = person.identification;
                Session["rolUsuario"] = "Administrator";

                FormsAuthentication.SetAuthCookie(person.name, true);
                return RedirectToAction("Profile", "Profile");
            }
            else
            {
                return RedirectToAction("Index", new { message = "Correo o contraseña incorrecta" });
            }

        }

        public ActionResult Logout()
        {
            this.Session.Clear();
            return RedirectToAction("Index");
        }

    }
}