using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Validation;
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
                // db.Request.Add(request);
                //db.SaveChanges();
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
            DateModel dateModel;
            List<TurnModel> turn;

            List<Day> daysRequested = new List<Day>();
            Day day = new Day();
            int fullDaysCount = 0;
            int midDaysCount = 0;

            for (int index = 0; index < model.Count; index++)
            {
                dateModel = new DateModel();
                turn = new List<TurnModel>();
                dateModel = model.ElementAt(index);
                turn = dateModel.turn;

                day = new Day();

                if (turn.ElementAt(0).isChecked && turn.ElementAt(1).isChecked && turn.ElementAt(2).isChecked)
                {
                    day.turn = 1;
                    fullDaysCount++;

                }
                else if (turn.ElementAt(0).isChecked && !turn.ElementAt(1).isChecked && !turn.ElementAt(2).isChecked)
                {
                    day.turn = 2;
                    midDaysCount++;

                }
                else if (!turn.ElementAt(0).isChecked && turn.ElementAt(1).isChecked && !turn.ElementAt(2).isChecked)
                {
                    day.turn = 3;
                    midDaysCount++;
                }
                else if (!turn.ElementAt(0).isChecked && !turn.ElementAt(1).isChecked && turn.ElementAt(2).isChecked)
                {
                    day.turn = 4;
                    midDaysCount++;
                }


                //OBTENER LA SESIÓN DEL EMPLEADO
                day.day1 = dateModel.date;
                day.RequestrequestId = (int)Session["idUser"];
                day.createdAt = DateTime.Now;
                day.updatedAt = DateTime.Now;
                day.createdBy = (int)Session["identification"];
                day.updatedBy = (int)Session["identification"];


                System.Diagnostics.Debug.WriteLine(day.day1);
                System.Diagnostics.Debug.WriteLine(day.RequestrequestId);
                System.Diagnostics.Debug.WriteLine(day.turn);
                daysRequested.Add(day);


                db.Day.Add(day);

            };

            //Request request = new Request("sent", "TESTING", fullDaysCount, midDaysCount, (int)Session["idUser"], DateTime.Now, DateTime.Now, (int)Session["identification"], (int)Session["identification"], daysRequested);
           
            //try
            //{
            //    db.Request.Add(request);
            //    db.SaveChanges();
            //}
            //catch (DbEntityValidationException e)
            //{
            //    foreach (var eve in e.EntityValidationErrors)
            //    {
            //        System.Diagnostics.Debug.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
            //            eve.Entry.Entity.GetType().Name, eve.Entry.State);
            //        foreach (var ve in eve.ValidationErrors)
            //        {
            //            System.Diagnostics.Debug.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
            //                ve.PropertyName, ve.ErrorMessage);
            //        }
            //    }
            //    throw;
            //}

            ////TempData["days"] = daysRequested.ToList();
            ////}
            ////return View(request);
            return null;

        }
    }
}