using LearningAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace LearningAPI.Context
{
    public class ContactBookContext : DbContext
    {
        public ContactBookContext(DbContextOptions<ContactBookContext> options) : base(options)
        {
            
        }

        public DbSet<Contact> Contacts { get; set; }
    }
}