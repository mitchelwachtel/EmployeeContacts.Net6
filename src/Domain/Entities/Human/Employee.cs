using System;
using EmployeeContacts.Domain.Entities.Communication;

namespace EmployeeContacts.Domain.Entities.Human
{

    public class Employee : BaseHuman
    {
        public int DateOfBirth { get; set; }

        public int SocialSecurityNumber { get; set; }


        public virtual IList<Contact> Contacts { get; set; }

        public virtual IList<Address> Addresses { get; set; }

        public virtual IList<Telephone> Telephones { get; set; }
    }
}

