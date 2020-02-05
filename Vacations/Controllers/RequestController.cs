using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Vacations;
using Vacations.Models;

namespace Vacations.Controllers
{
    public class RequestController : Controller
    {
        private EntitiesVacation db = new EntitiesVacation();

        public ActionResult Serve()
        {
            return View();
        }

        public ActionResult Details()
        {
            return View();
        }
        public ActionResult Create()
        {
            ViewBag.PersonpersonaId = new SelectList(db.Person1, "personaId", "name");
            List<HoliDays> holiDays = db.HoliDays.ToList();
            List<DateTime> holidates = new List<DateTime>();
            for (int i = 0; i < holiDays.Count; i++)
            {
                holidates.Add(holiDays.ElementAt(i).date);
            }
            ViewData["holidaysDate"] = holiDays;
            ViewBag.holidaysDate = holiDays;
            ViewBag.holidates = holidates;
            return View();
        }

        // POST: Requests/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "requestId,state,description,daysRequestedCount,midDaysCount,PersonpersonaId,createdAt,updatedAt,createdBy,updatedBy")] Request request, String days)
        {
            //FALTA CONTROL DE ERRORES
            if (ModelState.IsValid)
            {
                List<DateModel> daysRequested = StringToList(days);
                db.Request.Add(request);
                db.SaveChanges();
                TempData["days"] = daysRequested.ToList();

            }
            return RedirectToAction("Check");
        }

        public List<DateModel> StringToList(string days)
        {
            days = days.Replace(" ", "");
            string[] parts = days.Split(',');
            List<DateModel> StringToList = new List<DateModel>();
            DateModel date;

            for (int i = 0; i < parts.Count(); i++)
            {
                date = new DateModel();
                DateTime oDate = DateTime.ParseExact(parts[i], "dd/MM/yyyy", null);
                date.date = oDate;
                StringToList.Add(date);
            };

            return StringToList;
        }

        //GET
        public ActionResult Check()
        {
            List<DateModel> model = TempData["days"] as List<DateModel>;

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Check(List<DateModel> model)
        {
            //FALTA CONTROL DE ERRORES, VALIDACIONES
            List<DateTime> mornings = new List<DateTime>();
            List<DateTime> afternoons = new List<DateTime>();
            List<DateTime> fulldays = new List<DateTime>();
            DateModel dateModel;
            List<Turn> turn;

            for (int index = 0; index < model.Count; index++)
            {
                dateModel = new DateModel();
                turn = new List<Turn>();
                dateModel = model.ElementAt(index);
                turn = dateModel.turn;

                if (turn.ElementAt(0).isChecked && turn.ElementAt(1).isChecked)
                {
                    fulldays.Add(dateModel.date);
                }
                else if (turn.ElementAt(0).isChecked && !turn.ElementAt(1).isChecked)
                {
                    mornings.Add(dateModel.date);
                }
                else if (!turn.ElementAt(0).isChecked && turn.ElementAt(1).isChecked)
                {
                    afternoons.Add(dateModel.date);
                }
                else
                {
                    return View();
                }

            };
            //if (ModelState.IsValid)
            //{
            //db.Request.Add(request);
            //db.SaveChanges();
            //TempData["days"] = daysRequested.ToList();
            //}
            //return View(request);
            return null;

        }
    }
}