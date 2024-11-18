using System.ComponentModel.DataAnnotations;

namespace books_api.Dtos.Book
{
    public class UpdateBookRequestDto
    {
        [Required]
        public string Title { get; set; } = string.Empty;
        [Required]
        public string Author { get; set; } = string.Empty;
        [MaxLength(280, ErrorMessage = "Review cannot be over 280 characters")]
        public string Review { get; set; } = string.Empty;
    }
}
