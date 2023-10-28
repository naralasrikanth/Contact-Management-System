using System.ComponentModel.DataAnnotations;

namespace backendContacts.Models
{
    public class Communication
    {
        [Key]
        public int communication_id { get; set; }
        public int contact_id { get; set; }
        public int contact_number_id { get; set; }
        public DateOnly communication_date { get; set; }
        public string mode_of_communication { get; set; }
        public string content { get; set; }
    }
}
