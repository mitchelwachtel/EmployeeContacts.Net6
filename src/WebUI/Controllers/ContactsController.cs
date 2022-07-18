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
using EmployeeContacts.Domain.DTOs.Contact;

namespace EmployeeContactsWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {

        private readonly IMapper _mapper;
        private readonly IContactsRepository _contactsRepository;

        public ContactsController(IMapper mapper, IContactsRepository contactsRepository)
        {

            this._mapper = mapper;
            this._contactsRepository = contactsRepository;
        }

        // GET: api/Contacts/{id}
        [HttpGet("{id:int}")]
        public async Task<ActionResult<IEnumerable<ContactDTO>>> GetContactsByEmployeeId(int id)
        {
            var contacts = await _contactsRepository.GetAllContactsByEmployeeIdAsync(id);

            if (contacts == null)
            {
                return NotFound();
            }

            var records = _mapper.Map<List<ContactDTO>>(contacts);

            return Ok(records);
        }

        // GET: api/Contacts/Primary/{id}
        [HttpGet("/primary/{id:int}")]
        public async Task<ActionResult<ContactDTO>> GetPrimaryContactById(int id)
        {
            var contact = await _contactsRepository.GetPrimaryContactByEmployeeId(id);

            if (contact == null)
            {
                return NotFound();
            }

            var record = _mapper.Map<ContactDTO>(contact);

            return Ok(record);
        }

        //GET: api/Contacts/Exists/{id}
        [HttpGet("exists/{id:int}")]
        public async Task<bool> EmployeeHasContacts(int id)
        {
            return await _contactsRepository.HasContactsAsync(id);
        }

        // PUT: api/Contacts/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> PutContact(int id, UpdateContactDTO updateContactDto)
        {
            if (id != updateContactDto.Id)
            {
                return BadRequest("Invalid Record Id");
            }

            var contact = await _contactsRepository.GetByIdAsync(id);

            if (contact == null)
            {
                return NotFound();
            }

            _mapper.Map(updateContactDto, contact);


            try
            {
                await _contactsRepository.UpdateAsync(contact);
                return Accepted();
            }
            catch
            {
                return Problem();
            }

        }

        // POST: api/Contacts
        [HttpPost]
        public async Task<ActionResult<Contact>> PostContact(CreateContactDTO createContactDto)
        {

            var contact = _mapper.Map<Contact>(createContactDto);

            try
            {
                await _contactsRepository.AddAsync(contact);
                return Accepted();
            }
            catch
            {
                return Problem();
            }

        }

        // DELETE: api/Contacts/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteContact(int id)
        {
            var contact = await _contactsRepository.GetByIdAsync(id);
            if (contact == null)
            {
                return NotFound();
            }

            try
            {
                await _contactsRepository.DeleteAsync(id);
                return Accepted();
            }
            catch
            {
                return Problem();
            }


        }
    }
}



