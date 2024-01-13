using PerfectInstadee.Models;
using System.ComponentModel.DataAnnotations;

namespace PerfectInstadee.Data.DTOs
{
    public class ContactReadDTO
    {
        public string Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public List<PhoneNumber> PhoneNumbers { get; set; }
        public User User { get; set; }
    }
}
