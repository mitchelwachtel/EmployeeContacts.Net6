using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using EmployeeContacts.Domain.Interfaces;
using EmployeeContacts.Domain.DTOs.Employee;
using Microsoft.EntityFrameworkCore;
using EmployeeContacts.Domain.Entities.Human;

namespace EmployeeContactsWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {

        private readonly IMapper _mapper;
        private readonly IEmployeesRepository _employeesRepository;

        public EmployeesController(IMapper mapper, IEmployeesRepository employeesRepository)
        {

            this._mapper = mapper;
            this._employeesRepository = employeesRepository;
        }

        // GET: api/Employees
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmployeeDTO>>> GetEmployees()
        {
            var employees = await _employeesRepository.GetAllAsync();
            var records = _mapper.Map<List<EmployeeDTO>>(employees);
            return Ok(records);
        }

        // GET: api/Employees/{id}
        [HttpGet("{id:int}")]
        public async Task<ActionResult<EmployeeDTO>> GetEmployeeById(int id)
        {
            var employee = await _employeesRepository.GetDetailsByIdAsync(id);

            if (employee == null)
            {
                return NotFound();
            }

            var record = _mapper.Map<EmployeeDTO>(employee);

            return Ok(record);
        }

        // GET: api/Employees/{email}
        [HttpGet("{email:string}")]
        public async Task<ActionResult<EmployeeDTO>> GetEmployeeByEmail(string email)
        {
            var employee = await _employeesRepository.GetByEmailAsync(email);

            if (employee == null)
            {
                return NotFound();
            }

            var record = _mapper.Map<EmployeeDTO>(employee);

            return Ok(record);
        }

        //GET: api/Employees/Exists/{id}
        [HttpGet("exists/{id:int}")]
        public async Task<bool> EmployeeExists(int id)
        {
            return await _employeesRepository.ExistsAsync(id);
        }

        // PUT: api/Employees/{id}
        [HttpPut("{id:int}")]
        public async Task<IActionResult> PutEmployee(int id, UpdateEmployeeDTO updateEmployeeDto)
        {
            if (id != updateEmployeeDto.Id)
            {
                return BadRequest("Invalid Record Id");
            }

            var employee = await _employeesRepository.GetByIdAsync(id);

            if (employee == null)
            {
                return NotFound();
            }

            _mapper.Map(updateEmployeeDto, employee);


            try
            {
                await _employeesRepository.UpdateAsync(employee);
                return Accepted();
            }
            catch
            {
                return Problem();
            }

        }

        // POST: api/Employees
        [HttpPost]
        public async Task<ActionResult<Employee>> PostEmployee(CreateEmployeeDTO createEmployeeDto)
        {

            var employee = _mapper.Map<Employee>(createEmployeeDto);

            try
            {
                await _employeesRepository.AddAsync(employee);
                return Accepted();
            }
            catch
            {
                return Problem();
            }

        }

        // DELETE: api/Employees/{id}
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            var employee = await _employeesRepository.GetByIdAsync(id);
            if (employee == null)
            {
                return NotFound();
            }

            try
            {
                await _employeesRepository.DeleteAsync(id);
                return Accepted();
            }
            catch
            {
                return Problem();
            }


        }

        
    }
}

