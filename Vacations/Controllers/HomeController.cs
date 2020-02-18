using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

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

        public String Sha256Encription(String data) // encriptar contraseña
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // ComputeHash - returns byte array  
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(data));

                // Convert byte array to a string   
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
        private Boolean ValidateEmail(String email)//validar email mediante expresion regular
        {
            String expresion;
            expresion = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
            if (Regex.IsMatch(email, expresion))
            {
                if (Regex.Replace(email, expresion, String.Empty).Length == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        [HttpPost]
        public ActionResult Login(string email, string pass)
        {
            if (ValidateEmail(email))
            {
                Person1 person = new Person1();
                pass = Sha256Encription(pass);

                using (var context = new EntitiesVacation())
                {
                    person = context.Person1
                        .Where(personItem => personItem.password == pass && personItem.email == email).FirstOrDefault();
                
                    if (person != null) {
                        Session["userName"] = person.name;
                        Session["idUser"] = person.personaId;
                        Session["identification"] = person.identification;
                        Session["rolUsuario"] = person.Rol.name;
                        Session["payrollId"] = person.PayrollRolId;

                        FormsAuthentication.SetAuthCookie(person.name, true);
                        return RedirectToAction("Profile", "Profile");
                    }
                    else
                    {
                        return RedirectToAction("Index", new { message = "Correo o contraseña incorrectos" });
                    }
                }
            }
            else
            {
                return RedirectToAction("Index", new { message = "Debe ingresar una direccion de correo válida" });
            }
        }

        public ActionResult Logout()
        {
            this.Session.Clear();
            return RedirectToAction("Index");
        }

    }
}