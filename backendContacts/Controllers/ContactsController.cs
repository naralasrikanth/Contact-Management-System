using backendContacts.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace backendContacts.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly ContactsDbContext _contacts;
        public ContactsController(ContactsDbContext context)
        {
            _contacts = context;
        }
        [HttpGet]
        public IActionResult Get()
        {
            var contacts = _contacts.Contacts;   
            return Ok(contacts);
        }
        [HttpPost]
        public IActionResult Post([FromBody] Contacts Model)
        {
            var result = _contacts.Contacts.Any(u => u.contact_id == Model.contact_id);
            if (result == true)
            {
                return Ok(new { message = " Contact already exist" });
            }
            _contacts.Contacts.Add(Model);
            _contacts.SaveChanges();

            return Ok(new { message = " Contact created" });
        }
        [HttpPut]
        public IActionResult Put([FromBody] Contacts Model)
        {
            _contacts.Contacts.Attach(Model);
            _contacts.Entry(Model).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

            _contacts.SaveChanges();
            return Ok(new { message = " Contact updated" });
        }
        [HttpDelete("{contact_id}")]
        public IActionResult Delete(int contact_id)
        {
            var result = _contacts.Contacts.Find(contact_id);
            if (result == null)
            {
                _contacts.Contacts.Remove(result);
            }
            _contacts.SaveChanges();
            return Ok(new { message = "use deleted" });

        }


    }
}

    

