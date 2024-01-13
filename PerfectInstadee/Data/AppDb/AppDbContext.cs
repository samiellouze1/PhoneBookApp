using Microsoft.EntityFrameworkCore;
using PerfectInstadee.Models;

namespace PerfectInstadee.Data.AppDb
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Contact>().HasOne(c => c.User).WithMany(u => u.Contacts).OnDelete(DeleteBehavior.Cascade);
            builder.Entity<PhoneNumber>().HasOne(pn=>pn.Contact).WithMany(c=>c.PhoneNumbers).OnDelete(DeleteBehavior.Cascade);
            base.OnModelCreating(builder);
        }
    }
}
