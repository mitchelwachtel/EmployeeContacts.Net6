using System;
namespace EmployeeContacts.Domain.Entities.Human
{
    public abstract class BaseHuman
    {
        public int Id { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string? Email { get; set; }
    }
}

