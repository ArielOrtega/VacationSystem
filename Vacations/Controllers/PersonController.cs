using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Vacations.Controllers
{
    public class PersonController
    {

        Person1 person = new Person1();

        public PersonController()
        {
        }
        
        public Person1 GetPersonById(int personId)
        {
            using (EntitiesVacation entitiesVacations = new EntitiesVacation())
            {
                person = entitiesVacations.Person1.Where
                 (id => id.identification == personId).FirstOrDefault();
            } 

            return person;
        }


    }
}