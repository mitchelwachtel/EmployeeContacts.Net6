using System;


namespace EmployeeContacts.Domain.Entities.Communication
{
    public class Telephone : BaseCommunication
    {
       

        public int CountryCode { get; set; }

        public int PhoneNumber { get; set; }

        

    }
}

