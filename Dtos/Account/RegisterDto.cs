using System.ComponentModel.DataAnnotations;

namespace books_api.Dtos.User
{
    public class RegisterDto
    {
        [Required]
        [MaxLength(80, ErrorMessage = "Name cannot be over 80 characters")]
        public string? Name { get; set; }
        [Required]
        public string? Username { get; set; }
        [Required]
        [EmailAddress]
        public string? Email { get; set; }
        [Required]
        public string? Password { get; set; }
    }
}
