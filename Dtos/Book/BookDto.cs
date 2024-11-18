namespace books_api.Dtos.Book
{
    public class BookDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        public string Review { get; set; } = string.Empty;
        public string UserId { get; set; }
    }
}
