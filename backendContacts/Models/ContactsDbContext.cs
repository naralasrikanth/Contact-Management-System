using Microsoft.EntityFrameworkCore;

namespace backendContacts.Models
{
    public class ContactsDbContext : DbContext
    {
        public ContactsDbContext(DbContextOptions<ContactsDbContext> Options) : base(Options) 
        {
            
        }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<Contacts> Contacts { get; set; }
        public virtual DbSet<ContactNumbers> ContactNumbers { get; set; }
        public virtual DbSet<Communication> Communication { get; set; }

    }
}
