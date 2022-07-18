using System;
using EmployeeContacts.Domain.Entities.Human;

namespace EmployeeContacts.Domain.Interfaces
{
    public interface IEmployeesRepository : IGenericRepository<Employee>
    {

        Task<List<Employee>> GetAllAsync();

        Task<Employee> GetByEmailAsync(string? email);

        Task<Employee> GetDetailsByIdAsync(int id);

        Task<bool> ExistsAsync(int id);

        

        
    }
}

