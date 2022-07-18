using System;
using System.ComponentModel.DataAnnotations;
using EmployeeContacts.Domain.DTOs.Address;
using EmployeeContacts.Domain.DTOs.Telephone;

namespace EmployeeContacts.Domain.DTOs.Employee
{
    public abstract class BaseEmployeeDTO
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        public string Email { get; set; }

        public int DateOfBirth { get; set; }

        public int SocialSecurityNumber { get; set; }

        public List<AddressDTO>? Addresses { get; set; }
        public List<TelephoneDTO>? Telephones { get; set; }

    }
}

