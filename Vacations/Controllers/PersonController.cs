using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Vacations.Controllers
{
    public class PersonController
    {

        Person person = new Person();

        public PersonController()
        {
        }
        
        public Person GetPersonById(int personId)
        {
            using (EntitiesVacation entitiesVacations = new EntitiesVacation())
            {
                person = entitiesVacations.Person.Where
                 (id => id.identification == personId).FirstOrDefault();
            } 

            return person;
        }


    }
}