using Microsoft.AspNetCore.Identity;

namespace books_api.Models
{
    public class User : IdentityUser
    {
        public string Name { get; set; } = string.Empty;
        public List<Book>? Books { get; set; }
    }
}
