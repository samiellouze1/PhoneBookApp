using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using PerfectInstadee.Data.AppDb;
using PerfectInstadee.Models;

namespace PerfectInstadee.Data.Repository
{
    public class RepositoryService : IRepositoryService
    {
        private readonly AppDbContext _context;
        public RepositoryService(AppDbContext context)
        {
            _context = context;
        }
        public async Task AddContactAsync(Contact contact)
        {
            await _context.Set<Contact>().AddAsync(contact);
            await SaveChangesAsync();
        }

        public async Task DeleteContactAsync(int id)
        {
            var contact = await _context.Set<Contact>().FirstOrDefaultAsync(n => n.Id == id);
            EntityEntry contactEntry = _context.Entry<Contact>(contact);
            contactEntry.State = EntityState.Deleted;
            await SaveChangesAsync();
        }

        public async Task<List<Contact>> GetAllContactsByIdAsync(int id)
        {
            var user = await _context.Set<User>().Include(u => u.Contacts).FirstOrDefaultAsync(u => u.Id == id);
            if (user != null)
            {
                var contacts = user.Contacts.ToList();
                return contacts;
            }
            else
            {
                return new List<Contact>();
            }
        }

        public async Task<Contact> GetContactByIdAsync(int id)
        {
            var contact = await _context.Set<Contact>().FirstOrDefaultAsync(c => c.Id == id);
            if (contact != null)
            {
                return contact;
            }
            else
            {
                return null;
            }
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            var user = await _context.Set<User>().FirstOrDefaultAsync(u => u.Id == id);
            if (user != null)
            {
                return user;
            }
            else
            {
                return new User();
            }
        }
        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
