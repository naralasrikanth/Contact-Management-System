using backendContacts.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace backendContacts.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommunicationController : ControllerBase
    {
        private readonly ContactsDbContext _Communication;
        public CommunicationController(ContactsDbContext Communication)
        {
            _Communication = Communication;
        }
        [HttpGet]
        public IActionResult Get()
        {
            var result = _Communication.Communication;
            return Ok(result);
        }
        [HttpPost]
        public IActionResult Post([FromBody] Communication Model)
        {
            var result = _Communication.Communication.Any(u => u.communication_id == Model.communication_id);
            if (result == true)
            {
                return Ok(new { message = " communication already exist" });
            }
            _Communication.Communication.Add(Model);
            _Communication.SaveChanges();
            return Ok(new { message = " communication created" });
        }
        [HttpPut]
        public IActionResult Put([FromBody] Communication Model)
        {
            _Communication.Communication.Attach(Model);
            _Communication.Entry(Model).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _Communication.SaveChanges();
            return Ok(new { message = " communication updated" });
        }
        [HttpDelete("{communication_id}")]
        public IActionResult Delete(int communication_id)
        {
            var result = _Communication.Communication.Find(communication_id);
            if (result == null)
            {
                _Communication.Communication.Remove(result);
            }
            _Communication.SaveChanges();
            return Ok(new { message = "Communication of contacts are deleted" });

        }


    }
}

    

