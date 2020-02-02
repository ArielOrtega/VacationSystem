using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;

namespace Vacations.Controllers
{
    public class ServeRequestController
    {
        Request request = new Request();


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

                entitiesVacations.Entry(request).State = System.Data.Entity.EntityState.Modified;
                entitiesVacations.SaveChanges();


                var personData = new PersonController();
                var person = new Person();


                person = personData.GetPersonById(request.createdBy);
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
                message.From = new MailAddress("cuentaACrear");
                message.To.Add(new MailAddress("receptor"));
                message.Subject = "Respuesta de Solcitud de Vacaciones";
                message.Body = request.description;
                smtp.Port = 587;
                smtp.Host = "smtp.gmail.com";
                smtp.EnableSsl = true;
                smtp.UseDefaultCredentials = false;
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.Credentials = new System.Net.NetworkCredential("cuentaACrear", "cuentaACrearPass");
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