using System.ComponentModel.DataAnnotations;

namespace backendContacts.Models
{
    public class Contacts
    {
        [Key]
        public int contact_id { get; set; }
        public int user_id { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string email { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string country { get; set; }
    }
}
