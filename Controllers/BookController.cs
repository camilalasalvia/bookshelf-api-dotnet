using books_api.Data;
using books_api.Dtos.Book;
using books_api.Helpers;
using books_api.Interfaces;
using books_api.Mappers;
using books_api.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace books_api.Controllers
{
    [Route("api/books")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookRepository _repository;
        private readonly UserManager<User> _userManager;
        public BookController(IBookRepository repository, UserManager<User> userManager)
        {
            this._repository = repository;
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> GetBooks([FromQuery] QueryObject query)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return Unauthorized("User not authenticated");
            }

            var books = await _repository.GetBooksAsync(user.Id, query);

            var booksDto = books.Select(b => b.ToBookDto());

            return Ok(booksDto);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetBookById([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return Unauthorized("User not authenticated");
            }

            var book = await _repository.GetBookByIdAsync(id, user.Id);

            if(book == null)
            {
                return NotFound();
            }

            return Ok(book.ToBookDto());
        }

        [HttpPost]
        public async Task<IActionResult> CreateBook([FromBody] CreateBookRequestDto bookDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return Unauthorized("User not authenticated");
            }

            var book = bookDto.ToBookModelFromCreate(user.Id);
            await _repository.CreateBookAsync(book);

            return CreatedAtAction(nameof(GetBookById), new { id = book.Id }, book.ToBookDto());
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> UpdateBook([FromRoute] int id, [FromBody] UpdateBookRequestDto bookDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return Unauthorized("User not authenticated");
            }

            var book = await _repository.UpdateBookAsync(id, bookDto.ToBookModelFromUpdate(), user.Id);

            if(book == null)
            {
                return NotFound("Book not found");
            }

            return Ok(book.ToBookDto());
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> DeleteBook([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return Unauthorized("User not authenticated");
            }

            var book = await _repository.DeleteBookAsync(id, user.Id);

            if (book == null)
            {
                return NotFound("Book does not exist");
            }

            return NoContent();
        }
    }
}
