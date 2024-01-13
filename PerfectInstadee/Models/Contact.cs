using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PerfectInstadee.Models
{
    public class Contact
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string FullName { get; set; }
        [Required]  
        public string Email { get; set; }
        public List<PhoneNumber> PhoneNumbers { get; set; }
        public User User { get; set; }
    }
}
