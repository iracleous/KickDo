using KickDo.Data;
using KickDo.Models;
using KickDo.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KickDo.Services
{
    //public class FundingServices
    //{


    //}

    public class RegistrationServices
    {
        public Person RegistrationPerson
            (PersonRegistrationOption perOptions)
        {
            //validation
            if (
                perOptions == null||
                string.IsNullOrWhiteSpace(perOptions.FirstName) ||
                string.IsNullOrWhiteSpace(perOptions.LastName) ||
                string.IsNullOrWhiteSpace(perOptions.Address) ||
                    !perOptions.DobYear.HasValue ||
                    !perOptions.DobMonth.HasValue||
                    !perOptions.DobDay.HasValue

              )
            return null;

            //object instantiation
            Person person = new Person
            {
                FirstName = perOptions.FirstName,
                LastName = perOptions.LastName,
                Address = perOptions.Address,
                Dob =
                new DateTime(perOptions.DobYear.Value,
                perOptions.DobMonth.Value, perOptions.DobDay.Value)


            };


            using KickDoDB db = new KickDoDB();
            db.Set<Person>().Add(person);
            db.SaveChanges();


            return person;

        }

        public List<Person> Search( PersonRegistrationOption options) {

            if (options == null)
            {
                return null;
            }           

            using KickDoDB db = new KickDoDB();

            var persons=db.Set<Person>().Where(
                person => person.FirstName.Equals(
                    options.FirstName)).ToList();

            return persons;

        }
    }
}
