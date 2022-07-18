using System;
namespace EmployeeContacts.Domain.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> GetByIdAsync(int? id);

        Task<T> AddAsync(T entity);

        Task DeleteAsync(int id);

        Task UpdateAsync(T entity);
    }
}
