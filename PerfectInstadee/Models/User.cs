using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace PerfectInstadee.Models
{
    public class User
    {
        [Key]
        [Required]
        public string Id { get; set; }
        public string FullName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]      
        public int PhoneNumber { get; set; }
        [Required]      
        public List<Contact> Contacts { get; set; }
    }
}
