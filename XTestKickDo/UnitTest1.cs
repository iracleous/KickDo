using KickDo.Models;
using KickDo.Options;
using KickDo.Services;
using System;
using Xunit;

namespace XTestKickDo
{
    public class UnitTest1
    {
        //create instances
        private PersonRegistrationOption regPersnull;

        private PersonRegistrationOption regPers = new
            PersonRegistrationOption
        {
            FirstName = "Dimitris",
            LastName = "Dimitriou",
            DobYear = 2002,
            DobMonth = 7,
            DobDay = 23,
            Address = "Athens",
        };

        private PersonRegistrationOption regPers2 = new
           PersonRegistrationOption
        {
            FirstName = "Georgios",
            LastName = "Dimitriou",
            DobYear = 2002,
            DobMonth = 7,
            DobDay = 23,
            Address = "Athens",
        };
        private PersonRegistrationOption regPersNoFirstName = new
           PersonRegistrationOption
        {
           
            LastName = "Dimitriou",
            DobYear = 2002,
            DobMonth = 7,
            DobDay = 23,
            Address = "Athens",
        };


        RegistrationServices regServ = new RegistrationServices();


        [Fact]
        public void PersonRegistrationTestHappyPath()
        
        {          
            //call of testing method
            Person person = regServ.RegistrationPerson(regPers);

            //assert
            Assert.NotNull(person);
            Assert.Equal(regPers.FirstName, person.FirstName);
            Assert.NotEqual(0, person.Id);
        }

        [Fact]
        public void PersRegUnhappy()
        {
            //call of testing method
            Person person = regServ.RegistrationPerson(regPersnull);

            //assert
            Assert.Null(person);

        }

        [Fact]
        public void PersRegUnhappy2()
        {
           
            //call of testing method
            Person person = regServ.RegistrationPerson(regPersNoFirstName);

            //assert
            Assert.Null(person);

        }

        [Fact]
        public void SearchTeastUnHappyPath() {

            var persons=regServ.Search(regPers2);

            Assert.Empty(persons);

        }
    }
}
