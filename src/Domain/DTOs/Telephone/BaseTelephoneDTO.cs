using System;
namespace EmployeeContacts.Domain.DTOs.Telephone
{
    public abstract class BaseTelephoneDTO
    {
        public int? EmployeeId { get; set; }

        public int? ContactId { get; set; }

        public int CountryCode { get; set; }

        public int PhoneNumber { get; set; }

        public string Type { get; set; }
    }
}

