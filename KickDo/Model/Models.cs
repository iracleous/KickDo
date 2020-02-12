using System;
using System.Collections.Generic;
using System.Text;

namespace KickDo.Models
{
    public class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public DateTime Dob { get; set; }
        public List<Company> Companies { get; set; }
        public List<Funding> Fundings { get; set; }

    }


    public class Funding
    {
        public int Id { get; set; }
        public Person Person { get; set; }
        public Company Company { get; set; }
        public decimal Deposit { get; set; }
        public DateTime DepositDate { get; set; }
        public string BankName { get; set; }
    }

    public class Company
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Address { get; set; }
        public string VatNumber { get; set; }
        public decimal Budget { get; set; }
        public string Description { get; set; }
        public Person Person { get; set; }
    }








}
