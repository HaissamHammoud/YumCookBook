using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CookBook.Models;
using CookBook.Application;
using CookBook.Interface;
using CookBook.Repositories;
using CookBook_Backend.Application.Interface;

namespace CookBook.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly CookBookContext _context;
        private readonly IBookService _bookService;
        public BookController(CookBookContext context,IBookService bookService)
        {
            _context = context;
            _bookService = bookService;
        }

        // GET: api/Book
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookDTO>>> GetBooks()
        {
            return await _context.Books
            .Select(x => ItemToDTO(x))
            .ToListAsync();
        }

        // GET: api/Book/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BookDTO>> GetBook(Guid id)
        {
            var book = await _context.Books.FindAsync(id);
            var Dto = ItemToDTO(book);
            if (book == null)
            {
                return NotFound();
            }

            return Dto;
        }

        // PUT: api/Book/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBook(Guid id, Book book)
        {
            if (id != book.Id)
            {
                return BadRequest();
            }

            _context.Entry(book).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Book
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Book>> PostBook(Book book)
        {
            _context.Books.Add(book);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetBook), new { id = book.Id }, book);
        }

        [HttpPost("{random}")]
        public async Task<ActionResult<Book>> PostRandomBookAsync(Book book)
        {
            var book2 = await _bookService.MadeRandomBook();

            return CreatedAtAction(nameof(GetBook), new { id = book2.Id }, book2);
        }

        // DELETE: api/Book/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Book>> DeleteBook(Guid id)
        {
            var book = await _context.Books.FindAsync(id);
            if (book == null)
            {
                return NotFound();
            }

            _context.Books.Remove(book);
            await _context.SaveChangesAsync();

            return book;
        }

        private bool BookExists(Guid id)
        {
            return _context.Books.Any(e => e.Id == id);
        }

        private static BookDTO ItemToDTO(Book book) =>
        new BookDTO
        {
            Id = book.Id,
            Name = book.Name,
            IsFree = book.IsFree
        };   
    }
}
