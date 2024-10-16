using System.ComponentModel.DataAnnotations;

namespace ContactManagement.Models
{
    public class Contact
    {
        [Key]
        public int Id { get; set; }  // Auto-incrementing primary key

        [Required]
        [StringLength(100)]
        public string FirstName { get; set; }  // First name is required

        [Required]
        [StringLength(100)]
        public string LastName { get; set; }   // Last name is required

        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
