using System;
using EmployeeContacts.Domain.Entities.Human;
using EmployeeContacts.Domain.Interfaces;
using EmployeeContacts.Infrastructure.Persistence.Data;
using Microsoft.EntityFrameworkCore;

namespace EmployeeContacts.Infrastructure.Persistence.Repositories
{
    public class ContactsRepository : GenericRepository<Contact>, IContactsRepository
    {
        private readonly EmployeeContactsDbContext _context;

        public ContactsRepository(EmployeeContactsDbContext context) : base(context)
        {
            this._context = context;
        }

        public async Task<List<Contact>> GetAllContactsByEmployeeIdAsync(int id)
        {
            var result = await _context.Contacts.Include(q => q.Addresses).Include(q => q.Telephones).Where(q => q.EmployeeId == id).ToListAsync();
            return result;
        }

        public async Task<Contact> GetPrimaryContactByEmployeeId(int id)
        {
            var result = await _context.Contacts.Where(q => q.EmployeeId == id && q.PrimaryContact == true).FirstOrDefaultAsync();
            return result;
        }

        public async Task<bool> HasContactsAsync(int id)
        {
            var result = await GetAllContactsByEmployeeIdAsync(id);
            return result != null;
        }
    }
}

