using System.ComponentModel.DataAnnotations;

namespace PerfectInstadee.Models
{
    public class Contact
    {
        [Key]
        [Required]
        public string Id { get; set; }
        public string FullName { get; set; }
        [Required]  
        public string Email { get; set; }
        [Required]
        public List<int> PhoneNumbers { get; set; }
        public User User { get; set; }
    }
}
