using PerfectInstadee.Models;

namespace PerfectInstadee.Data.DTOs
{
    public class ContactCreateDTO
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public List<PhoneNumber> PhoneNumbers { get; set; }
    }
}
