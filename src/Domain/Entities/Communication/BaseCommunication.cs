using System;
using System.ComponentModel.DataAnnotations.Schema;
using EmployeeContacts.Domain.Entities.Human;

namespace EmployeeContacts.Domain.Entities.Communication
{
    public class BaseCommunication
    {
        public int Id { get; set; }

        public string Type { get; set; }

        [ForeignKey(nameof(EmployeeId))]
        public int? EmployeeId { get; set; }

        public Employee? Employee { get; set; }

        [ForeignKey(nameof(ContactId))]
        public int? ContactId { get; set; }

        public Contact? Contact { get; set; }
    }
}

