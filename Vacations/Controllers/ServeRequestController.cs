using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using Vacations.Models;
using MimeKit;
using MailKit.Net.Smtp;

namespace Vacations.Controllers
{
    public class ServeRequestController : Controller
    {

        PersonController personController = new PersonController();

        public ActionResult Details(int requestId)
        {
            RequestDTO requestToFind = new RequestDTO();
            
            requestToFind = getRequestDetails(requestId);

            ViewData.Model = requestToFind;

            return View();
        }

        public ActionResult Serve()
        {
            List<RequestDTO> requestToList = new List<RequestDTO>();
            int idPerson = (int) this.Session["idUser"];
            requestToList = GetIncomingRequest(idPerson);


            ViewData.Model = requestToList;

            return View();
        }

        public ActionResult SendRequestAnswer(int requestIdToServe, string description, string state)
        {
            NotifyEmail (requestIdToServe,  description,  state);

            return View();
        }


        public RequestDTO getRequestDetails(int requestId)
        {
            RequestDTO requestToFind = new RequestDTO();
            List<DayDTO> requestDay = new List<DayDTO>();

            using (EntitiesVacation entitiesVacation = new EntitiesVacation())
            {
          

                requestDay = (from day in entitiesVacation.Day
                              where day.RequestrequestId == requestId
                              select new DayDTO
                              {
                                  dayId = day.dayId,
                                  day1 = day.day1,
                                  turn = day.turn

                              }).ToList();



                requestToFind = (from d in entitiesVacation.Departament
                                 from person in d.Person1
                                 join request in entitiesVacation.Request on person.personaId equals request.PersonpersonaId
                                 where request.requestId == requestId
                                 select new RequestDTO
                                 {
                                     requestId = request.requestId,
                                     state = request.state,
                                     description = request.description,
                                     daysRequestedCount = request.daysRequestedCount,
                                     midDaysCount = request.midDaysCount,
                                     PersonpersonaId = request.PersonpersonaId,
                                     createdAt = request.createdAt,
                                     updatedAt = request.updatedAt,
                                     createdBy = request.createdBy,
                                     updatedBy = request.updatedBy,
                                     personName = person.name + " " + person.lastName,
                                     departmentName = d.name
                                 }).FirstOrDefault();

                requestToFind.requestDays = GetTurnName(requestDay);

            }

            return requestToFind;
        }

        public List<DayDTO> GetTurnName (List<DayDTO> requestDay)
        {

            for (int i = 0; i < requestDay.Count; i++)
            {
                int turn = requestDay.ElementAt(i).turn;
            
            switch (turn)
            {
                case 1:
                     requestDay.ElementAt(i).turnName = "mañana";
                        break;

                case 2:
                        requestDay.ElementAt(i).turnName = "tarde";
                        break;

                    case 3:
                        requestDay.ElementAt(i).turnName = "noche";
                        break;

                    default:
                        requestDay.ElementAt(i).turnName = "día completo";
                        break;

                }

            }

            return requestDay;
        }

        public ActionResult DaysDetails(int requestId)
        {
            RequestDTO requestToFind = new RequestDTO();

            requestToFind = getRequestDetails(requestId);

            ViewData.Model = requestToFind;
            return View();
        }


        public List<RequestDTO> GetIncomingRequest(int personId)
        {

            List<RequestDTO> requestList = new List<RequestDTO>();
            Departament department = new Departament();
            Person1 personSession = new Person1();


            using (EntitiesVacation entitiesVacation = new EntitiesVacation())
            {
                personSession = entitiesVacation.Person1
                                .Where(per => per.personaId == personId).FirstOrDefault();

                if (personSession.RolrolId == 8)
                {
                    requestList = (from d in entitiesVacation.Departament
                                   from person in d.Person1
                                   join request in entitiesVacation.Request on person.personaId equals request.PersonpersonaId
                                   where person.RolrolId == 9 
                                   select new RequestDTO
                                   {
                                       requestId = request.requestId,
                                       state = request.state,
                                       description = request.description,
                                       daysRequestedCount = request.daysRequestedCount,
                                       midDaysCount = request.midDaysCount,
                                       PersonpersonaId = request.PersonpersonaId,
                                       createdAt = request.createdAt,
                                       updatedAt = request.updatedAt,
                                       createdBy = request.createdBy,
                                       updatedBy = request.updatedBy,
                                       personName = person.name + " " + person.lastName,
                                   }).ToList();
                }
                else
                {

                    department = entitiesVacation.Departament
                                 .Where(dep => dep.PersonpersonaId == personId).FirstOrDefault();

                    int idDepartamento = department.departamentId;

                    if (department != null)
                    {
                        requestList = (from d in entitiesVacation.Departament
                                       from person in d.Person1
                                       join request in entitiesVacation.Request on person.personaId equals request.PersonpersonaId
                                       where d.departamentId == idDepartamento
                                       select new RequestDTO
                                       {
                                           requestId = request.requestId,
                                           state = request.state,
                                           description = request.description,
                                           daysRequestedCount = request.daysRequestedCount,
                                           midDaysCount = request.midDaysCount,
                                           PersonpersonaId = request.PersonpersonaId,
                                           createdAt = request.createdAt,
                                           updatedAt = request.updatedAt,
                                           createdBy = request.createdBy,
                                           updatedBy = request.updatedBy,
                                           personName = person.name + " " + person.lastName,
                                       }).ToList();
                    }
                }
            }

            return requestList;

        }
        
        [HttpPost]
        public ActionResult NotifyEmail(int requestIdToServe, string description, string state)
        {
            var now = DateTime.Now;
            var updateDate = new DateTime(now.Year, now.Month, now.Day,
                                          now.Hour, now.Minute, now.Second);
            
            using (EntitiesVacation entitiesVacations = new EntitiesVacation())
            {
                Request request = entitiesVacations.Request.Where
                    (id => id.requestId == requestIdToServe).FirstOrDefault();

                request.description = description;
                request.state = state;
                request.updatedAt = updateDate;

                entitiesVacations.Entry(request).State = EntityState.Modified;
                entitiesVacations.SaveChanges();

                var person = personController.GetPersonById(request.PersonpersonaId);
                string name = person.name + " " + person.lastName;

                SendEmail(name, person.email, "Respuesta a la Solicitud de Vacaciones", request.description);
                
            }

            return View("Serve");
        }


        public void SendEmail(string receiverName, string receiverEmail, string subject, string body)
        {

            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("Sistema de vacaciones", "OnVacationSys@gmail.com"));
            message.To.Add(new MailboxAddress(receiverName, receiverEmail));
            message.Subject = subject;
            message.Body = new TextPart("plain")
            {
                Text = body
            };

            try
            {
                using (var client = new SmtpClient())
                {
                    client.Connect("smtp.gmail.com", 587);
                    client.Authenticate("OnVacationSys@gmail.com", "Vacation12345.");
                    client.Send(message);
                    client.Disconnect(true);
                }
            }
            catch (Exception ex) {
                Console.Write(ex.Message);
            }
        }

    }
}

