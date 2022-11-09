using System.ComponentModel.DataAnnotations;

namespace DAL
{
    public class AdminInfo
    {
        [Key]
        [EmailAddress]
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }


    }
}