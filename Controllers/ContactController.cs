using LearningAPI.Context;
using LearningAPI.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LearningAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ContactController : ControllerBase
    {
        private readonly ContactBookContext _context;
        public ContactController(ContactBookContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllContactsAsync()
        {
            var contacts = await _context.Contacts.ToListAsync();
            
            return Ok(contacts);
        }

        [HttpPost]
        public async Task<IActionResult> CreateContactAsync([FromBody] Contact contact)
        {
            await _context.Contacts.AddAsync(contact);
            await _context.SaveChangesAsync();

            return Ok(contact);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetContactByIdAsync(int id)
        {
            var contact = await _context.Contacts.FindAsync(id);

            if (contact == null)
                return NotFound();
            
            return Ok(contact);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateContactAsync(int id, Contact contact)
        {
            var contactToUpdate = await _context.Contacts.FindAsync(id);

            if (contactToUpdate == null)
                return NotFound();
            
            contactToUpdate.Active = contact.Active;
            contactToUpdate.Name = contact.Name;
            contactToUpdate.Phone = contact.Phone;

            _context.Contacts.Update(contactToUpdate);
            await _context.SaveChangesAsync();

            return Ok(contact);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteContactByIdAsync(int id)
        {
            var contact = await _context.Contacts.FindAsync(id);

            if (contact == null)
                return NotFound();
            
            _context.Contacts.Remove(contact);
            await _context.SaveChangesAsync();
            
            return NoContent();
        }
    }
}