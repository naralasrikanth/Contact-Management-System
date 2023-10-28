using System.ComponentModel.DataAnnotations;

namespace backendContacts.Models
{
    public class ContactNumbers
    {
        [Key]
        public int contact_number_id { get; set; }
        public int contact_id { get; set; }
        public string phone_number { get; set; }
        public string phone_type { get; set; }
      
    }
}
