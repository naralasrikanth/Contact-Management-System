using System.ComponentModel.DataAnnotations;

namespace backendContacts.Models
{
    public class Users
    {
        [Key]
        public int user_id { get; set; }
        public string user_name { get; set; }
        public string password { get; set; }
        public string email { get; set; }
        public string role { get; set; }

    }
}
