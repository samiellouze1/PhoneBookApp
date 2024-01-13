using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PerfectInstadee.Data.DTOs;
using PerfectInstadee.Data.Repository;
using PerfectInstadee.Models;

namespace PerfectInstadee.Controllers
{
    [Route("api/")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IRepositoryService _repo;
        private readonly IMapper _mapper;
        public UserController(IRepositoryService repo, IMapper mapper)
        {
            _mapper = mapper;
            _repo = repo;
        }
        [HttpGet("contact/{id}")]
        public async Task<ActionResult<ContactReadDTO>> GetContactById(int id)
        {
            var contact = await _repo.GetContactByIdAsync(id);
            return Ok(contact);
        }
        [HttpGet("{id}",Name ="GetContactsByUserId")]
        public async Task<ActionResult<IEnumerable<ContactReadDTO>>> GetContactsByUserId(int id)
        {
            var contactitems = await _repo.GetAllContactsByIdAsync(id);
            return Ok(_mapper.Map<IEnumerable<ContactReadDTO>>(contactitems));
        }
        [HttpPost("{id}",Name ="CreateContact")]
        public async Task<ActionResult<ContactCreateDTO>> CreateContact(int id,ContactCreateDTO contactCreateDTO)
        {
            var contactModel = _mapper.Map<Contact>(contactCreateDTO);


            var user = await _repo.GetUserByIdAsync(id);

            contactModel.User = user;

            //if (contactCreateDTO.PhoneNumbers != null)
            //{
            //    foreach (var phoneNumber in contactCreateDTO.PhoneNumbers)
            //    {
            //        contactModel.PhoneNumbers.Add(new PhoneNumber { Number = phoneNumber.Number });
            //    }
            //}

            await _repo.AddContactAsync(contactModel);

            var contactRead = _mapper.Map<ContactReadDTO>(contactModel);

            return CreatedAtAction(nameof(GetContactById), new { Id = contactRead.Id }, contactRead);
        }
        [HttpDelete("{id}",Name ="DeleteContact")]
        public async Task<ActionResult> DeleteContact(int id, [FromQuery] int contactid)
        {
            var contact = await _repo.GetContactByIdAsync(contactid);
            if (contact == null)
            {
                return NotFound();
            }
            var user = await _repo.GetUserByIdAsync(id);
            if (contact.User!=user)
            {
                return BadRequest("You dont have the right to delete this contact");
            }
            await _repo.DeleteContactAsync(contactid);
            return Ok($"Deleted contact with id {contactid}");
        }
    }
}
