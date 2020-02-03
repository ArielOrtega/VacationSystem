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


<<<<<<< Updated upstream
        public Request notifyEmail(Request requestToServe)
=======

        public List<Request> GetIncomingRequest(int department, int personId)
        {
            using (EntitiesVacation entitiesVacations = new EntitiesVacation())
            {

                var departamento = entitiesVacations.Departament
                    .Where(id => id.PersonpersonaId == personId).FirstOrDefault();


                /*List<Request> request = entitiesVacations.Request
                    .Join(entitiesVacations.Person,
                          dep => dep.departamentId == departamento.departamentId,
                          per => per.personaId,
                    (dep,per)=> new {dep,per});
                
          
                var query = from article in db.Articles
                            where article.Categories.Any(c => c.Category_ID == cat_id)
                            select article
                            */



            }


        }


        public Request NotifyEmail(Request requestToServe)
>>>>>>> Stashed changes
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
<<<<<<< Updated upstream
=======
                request.updatedBy = requestToServe.createdBy;
>>>>>>> Stashed changes

                entitiesVacations.Entry(request).State = System.Data.Entity.EntityState.Modified;
                entitiesVacations.SaveChanges();


                var personData = new PersonController();
                var person = new Person();


                person = personData.GetPersonById(request.createdBy);


                SendNotifyEmail(request, person.email);


                return request;
            }
        }



        public String SendNotifyEmail(Request request, string recieverEmail)

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