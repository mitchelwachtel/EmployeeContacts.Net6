using System;
using EmployeeContacts.Domain.DTOs.Contact;

namespace EmployeeContacts.Domain.DTOs.Employee
{
    public class EmployeeDTO : BaseEmployeeDTO
    {
        public int Id { get; set; }

        public List<ContactDTO>? Contacts { get; set; }
        
    }
}

