using PerfectInstadee.Models;

namespace PerfectInstadee.Data.Repository
{
    public interface IRepositoryService
    {
        Task AddContactAsync(Contact contact);
        Task DeleteContactAsync(string id);
        Task<List<Contact>> GetAllContactsByIdAsync(string id);
        Task SaveChangesAsync();
    }
}
