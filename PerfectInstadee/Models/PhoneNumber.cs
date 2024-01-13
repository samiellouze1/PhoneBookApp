using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PerfectInstadee.Models
{
    public class PhoneNumber
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public int Number { get; set; }
        public Contact? Contact { get; set; }
    }
}
