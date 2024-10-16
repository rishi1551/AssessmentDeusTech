using ContactManagement.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ContactManagement.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private static List<Contact> contacts = new List<Contact>
    {
        new Contact { Id = 0, FirstName = "Alex", LastName = "BlaBla", Email = "alex.blabla@aol.at" },
        new Contact { Id = 1, FirstName = "Otto", LastName = "Blubb", Email = "otto.blubb@dsl.de" },
        new Contact { Id = 2, FirstName = "Peter", LastName = "Pan", Email = "peter.pan@neverland.com" }
    };
        [HttpGet]
        public ActionResult<List<Contact>> GetContacts()
        {
            return Ok(contacts);
        }
        [HttpGet("{id}")]
        public ActionResult<Contact> GetContact(int id)
        {
            var contact = contacts.FirstOrDefault(c => c.Id == id);
            if (contact == null)
            {
                return NotFound();
            }
            return Ok(contact);
        }
        [HttpPost]
        public ActionResult AddContact([FromBody] Contact newContact)
        {
            newContact.Id = contacts.Max(c => c.Id) + 1;
            contacts.Add(newContact);
            return Ok(newContact);
        }
        [HttpPut("{id}")]
        public ActionResult UpdateContact(int id, [FromBody] Contact updatedContact)
        {
            var contact = contacts.FirstOrDefault(c => c.Id == id);
            if (contact == null)
            {
                return NotFound();
            }
            contact.FirstName = updatedContact.FirstName;
            contact.LastName = updatedContact.LastName;
            contact.Email = updatedContact.Email;
            return Ok(contact);
        }
        [HttpDelete("{id}")]
        public ActionResult DeleteContact(int id)
        {
            var contact = contacts.FirstOrDefault(c => c.Id == id);
            if (contact == null)
            {
                return NotFound();
            }
            contacts.Remove(contact);
            return Ok();
        }
    }
}
