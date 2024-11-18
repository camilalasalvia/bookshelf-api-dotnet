using books_api.Data;
using books_api.Dtos.Book;
using books_api.Helpers;
using books_api.Interfaces;
using books_api.Models;
using Microsoft.EntityFrameworkCore;

namespace books_api.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly ApplicationDBContext _context;
        public BookRepository(ApplicationDBContext context)
        {
            this._context = context;
        }
        public async Task<List<Book>> GetBooksAsync(string userId, QueryObject query)
        {
            var books = _context.Books.AsQueryable().Where(b => b.UserId == userId);

            if (!string.IsNullOrWhiteSpace(query.Title))
            {
                books = books.Where(b => b.Title.Contains(query.Title));
            }

            if (!string.IsNullOrWhiteSpace(query.Author))
            {
                books = books.Where(b => b.Title.Contains(query.Author));
            }

            return await books.ToListAsync();
        }
        public async Task<Book?> GetBookByIdAsync(int id, string userId)
        {
            return await _context.Books.FirstOrDefaultAsync(b => b.Id == id && b.UserId == userId);
        }

        public async Task<Book> CreateBookAsync(Book book)
        {
            await _context.Books.AddAsync(book);
            await _context.SaveChangesAsync();

            return book;
        }

        public async Task<Book?> UpdateBookAsync(int id, Book bookModel, string userId)
        {
            var book = await _context.Books.FirstOrDefaultAsync(b => b.Id == id && b.UserId == userId);

            if (book == null)
            {
                return null;
            }

            book.Title = bookModel.Title;
            book.Author = bookModel.Author;
            book.Review = bookModel.Review;

            await _context.SaveChangesAsync();
            return book;
        }

        public async Task<Book?> DeleteBookAsync(int id, string userId)
        {
            var book = await _context.Books.FirstOrDefaultAsync(b => b.Id == id && b.UserId == userId);

            if (book == null)
            {
                return null;
            }

            _context.Books.Remove(book);
            await _context.SaveChangesAsync();

            return book;
        }
    }
}
