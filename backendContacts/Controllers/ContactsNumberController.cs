using backendContacts.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace backendContacts.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsNumberController : ControllerBase
    {
        private readonly ContactsDbContext _contactsNumber;
        public ContactsNumberController(ContactsDbContext ContactsNumber)
        {
            _contactsNumber = ContactsNumber;   
        }
        [HttpGet]
        public IActionResult Get()
        {
            var contacts = _contactsNumber.ContactNumbers;
            return Ok(contacts);
        }
        [HttpPost]
        public IActionResult Post([FromBody] ContactNumbers Model)
        {
            var result = _contactsNumber.ContactNumbers.Any(u => u.contact_number_id == Model.contact_number_id);
            if (result == true)
            {
                return Ok(new { message = " Contact already exist" });
            }
            _contactsNumber.ContactNumbers.Add(Model);
            _contactsNumber.SaveChanges();

            return Ok(new { message = " Contact created" });
        }
        [HttpPut]
        public IActionResult Put([FromBody] ContactNumbers Model)
        {
            _contactsNumber.ContactNumbers.Attach(Model);
            _contactsNumber.Entry(Model).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

            _contactsNumber.SaveChanges();
            return Ok(new { message = " Contact updated" });
        }
        [HttpDelete("{contact_number_id}")]
        public IActionResult Delete(int contact_number_id)
        {
            var result = _contactsNumber.ContactNumbers.Find(contact_number_id);
            if (result == null)
            {
                _contactsNumber.ContactNumbers.Remove(result);
            }
            _contactsNumber.SaveChanges();
            return Ok(new { message = "use deleted" });

        }


    }
}

    


    

