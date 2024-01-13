using PerfectInstadee.Models;

namespace PerfectInstadee.Data.Repository
{
    public interface IRepositoryService
    {
        Task<User> GetUserByIdAsync(int id);
        Task<Contact> GetContactByIdAsync(int id);
        Task AddContactAsync(Contact contact);
        Task DeleteContactAsync(int id);
        Task<List<Contact>> GetAllContactsByIdAsync(int id);
        Task SaveChangesAsync();
    }
}
