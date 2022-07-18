using System;
using EmployeeContacts.Domain.Entities.Communication;
using EmployeeContacts.Domain.Entities.Human;
using Microsoft.EntityFrameworkCore;


namespace EmployeeContacts.Infrastructure.Persistence.Data

{
    public class EmployeeContactsDbContext : DbContext
    {
        public EmployeeContactsDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Telephone> Telephones { get; set; }
    }
}

