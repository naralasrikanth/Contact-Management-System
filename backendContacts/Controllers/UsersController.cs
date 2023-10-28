using backendContacts.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace backendContacts.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly ContactsDbContext _users;
        public UsersController(ContactsDbContext Users)
        {
            _users = Users;  
        }
        [HttpGet]
        public IActionResult Get()
        {
            var result = _users.Users;
            return Ok(result);
        }
        [HttpPost]
      public IActionResult Post([FromBody] Users Model)
        {
            var result = _users.Users.Any(u => u.user_id == Model.user_id);
            if(result == true)
            {
                return Ok(new { message = " user already exist" });
            }
            _users.Users.Add(Model);
            _users.SaveChanges();
            return Ok(new {message =" user created"});
        }
        [HttpPut]
        public IActionResult Put([FromBody] Users Model)
        {
            _users.Users.Attach(Model);
            _users.Entry(Model).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _users.SaveChanges();
            return Ok(new { message = " user updated" });
        }
        [HttpDelete("{user_id}")]
        public IActionResult Delete(int user_id) 
        {
            var result = _users.Users.Find(user_id);
            if (result == null)
            {
                _users.Users.Remove(result);
            }
            _users.SaveChanges();
            return Ok(new { message = "use deleted" });
        
        }


    }
}
