using books_api.Dtos.Book;
using books_api.Helpers;
using books_api.Models;
using Microsoft.AspNetCore.Mvc;

namespace books_api.Interfaces
{
    public interface IBookRepository
    {
        Task<List<Book>> GetBooksAsync(string userId, QueryObject query);
        Task<Book?> GetBookByIdAsync(int id, string userId);
        Task<Book> CreateBookAsync(Book book);
        Task<Book?> UpdateBookAsync(int id, Book bookModel, string userId);
        Task<Book?> DeleteBookAsync(int id, string userId);
    }
}
