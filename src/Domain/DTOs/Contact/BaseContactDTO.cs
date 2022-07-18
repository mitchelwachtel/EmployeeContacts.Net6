using System;
using System.ComponentModel.DataAnnotations;
using EmployeeContacts.Domain.DTOs.Address;
using EmployeeContacts.Domain.DTOs.Telephone;

namespace EmployeeContacts.Domain.DTOs.Contact
{
    public abstract class BaseContactDTO
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        public string Email { get; set; }

        public bool PrimaryContact { get; set; }

        [Required]
        public int EmployeeId { get; set; }

        public List<AddressDTO>? Addresses { get; set; }
        public List<TelephoneDTO>? Telephones { get; set; }
    }
}

