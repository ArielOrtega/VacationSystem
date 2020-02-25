using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using Vacations.Models;

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
         

        public List<RequestDTO> GetIncomingRequest(int personId)
        {

            List<RequestDTO> requestList = new List<RequestDTO>();
            Departament department = new Departament();

            using (EntitiesVacation entitiesVacation = new EntitiesVacation())
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

            return requestList;

        }
        

        public Request NotifyEmail(int requestIdToServe, string description, string state)
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

                var person = personController.GetPersonById(request.createdBy);
                sendNotifyEmail(request, person.email);

                return request;
            }

        }

        public String sendNotifyEmail(Request request, string recieverEmail)
        {
            try
            {
                MailMessage message = new MailMessage();
                SmtpClient smtp = new SmtpClient();
                message.From = new MailAddress("OnVacationSys@gmail.com");
                message.To.Add(new MailAddress(recieverEmail));
                message.Subject = "Respuesta de Solcitud de Vacaciones";
                message.Body = request.description;
                smtp.Port = 587;
                smtp.Host = "smtp.gmail.com";
                smtp.EnableSsl = true;
                smtp.UseDefaultCredentials = false;
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.Credentials = new System.Net.NetworkCredential("OnVacationSys@gmail.com", "Vacation12345.");
                smtp.Send(message);
                return "exito";
            }
            catch (Exception ex)
            {

                return ex.Message;
            }
        }

    }
}

