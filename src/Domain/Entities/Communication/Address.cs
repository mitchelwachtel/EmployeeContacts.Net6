using System;
namespace EmployeeContacts.Domain.Entities.Communication
{
    public class Address : BaseCommunication
    {
        

        public string Street { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public int PostalCode { get; set; }

        
    }
}

