using System;
namespace EmployeeContacts.Domain.DTOs.Address
{
    public abstract class BaseAddressDTO
    {
        public int? EmployeeId { get; set; }

        public int? ContactId { get; set; }

        public string Street { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public int PostalCode { get; set; }

        public string Type { get; set; }
    }
}

