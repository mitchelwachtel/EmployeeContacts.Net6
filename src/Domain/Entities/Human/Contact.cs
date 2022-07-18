using System;
using System.ComponentModel.DataAnnotations.Schema;
using EmployeeContacts.Domain.Entities.Communication;

namespace EmployeeContacts.Domain.Entities.Human
{
    public class Contact : BaseHuman
    {
        public bool? PrimaryContact { get; set; }

        [ForeignKey(nameof(EmployeeId))]
        public int EmployeeId { get; set; }

        public Employee Employee { get; set; }


        public virtual IList<Address> Addresses { get; set; }

        public virtual IList<Telephone> Telephones { get; set; }
    }
}

