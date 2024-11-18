using books_api.Dtos.Book;
using books_api.Models;

namespace books_api.Mappers
{
    public static class BookMappers
    {
        public static BookDto ToBookDto(this Book book)
        {
            return new BookDto
            {
                Id = book.Id,
                Title = book.Title,
                Author = book.Author,
                Review = book.Review,
                UserId = book.UserId
            };
        }
        public static Book ToBookModelFromCreate(this CreateBookRequestDto book, string userId)
        {
            return new Book
            {
                Title = book.Title,
                Author = book.Author,
                Review = book.Review,
                UserId = userId
            };
        }

        public static Book ToBookModelFromUpdate(this UpdateBookRequestDto book)
        {
            return new Book
            {
                Title = book.Title,
                Author = book.Author,
                Review = book.Review
            };
        }
    }
}
