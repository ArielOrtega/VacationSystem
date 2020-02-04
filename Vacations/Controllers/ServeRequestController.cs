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
            Request requestToFind = new Request();

            if (ModelState.IsValid)
            {
                requestToFind = getRequestDetails(requestId);
            }


            return View(requestToFind);
        }

        public ActionResult Serve()
        {
            List<RequestDTO> requestToList = new List<RequestDTO>();
            requestToList = getIncomingRequest(305150456);


            ViewData.Model = requestToList;

            return View();
        }


        public Request getRequestDetails(int requestId)
        {
            Request requestToFind = new Request();

            using (EntitiesVacation entitiesVacation = new EntitiesVacation())
            {
                requestToFind = entitiesVacation.Request.Where(request => request.requestId == requestId).FirstOrDefault();
            }

            return requestToFind;
        }

        public List<RequestDTO> getIncomingRequest(int personId)
        {

            List<RequestDTO> requestList = new List<RequestDTO>();
            Departament department = new Departament();

            using (EntitiesVacation entitiesVacation = new EntitiesVacation())
            {
                department = entitiesVacation.Departament
                              .Where(dep => dep.PersonpersonaId == personId).FirstOrDefault();

                if (department != null)
                {
                    requestList = (from request in entitiesVacation.Request
                                   from person in entitiesVacation.Person1
                                   from d in entitiesVacation.Departament
                                   where d.departamentId == department.departamentId
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
                                       updatedBy = request.updatedBy
                                   }).ToList();
                }

            }

            return requestList;

        }


        public Request notifyEmail(Request requestToServe)
        {
            var now = DateTime.Now;
            var updateDate = new DateTime(now.Year, now.Month, now.Day,
                                          now.Hour, now.Minute, now.Second);

            using (EntitiesVacation entitiesVacations = new EntitiesVacation())
            {
                Request request = entitiesVacations.Request.Where
                    (id => id.requestId == requestToServe.requestId).FirstOrDefault();

                request.description = requestToServe.description;
                request.state = requestToServe.state;
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

