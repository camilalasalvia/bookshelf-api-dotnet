namespace books_api.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        public string Review { get; set; } = string.Empty;
        public string UserId { get; set; }
        public User User { get; set; }
    }
}
