using System;
using EmployeeContacts.Domain.Interfaces;
using EmployeeContacts.Infrastructure.Persistence.Data;
using Microsoft.EntityFrameworkCore;

namespace EmployeeContacts.Infrastructure.Persistence.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly EmployeeContactsDbContext _context;

        public GenericRepository(EmployeeContactsDbContext context)
        {
            this._context = context;
        }

        public async Task<T> GetByIdAsync(int? id)
        {
            if (id is null)
            {
                return null;
            }

            var result = await _context.Set<T>().FindAsync(id);
            return result;
        }

        public async Task<T> AddAsync(T entity)
        {
            await _context.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await GetByIdAsync(id);
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();
        }

    }
}

