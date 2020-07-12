using System;
using System.Threading.Tasks;
using CookBook.Interface;
using CookBook.Models;
using CookBook.Repositories;
using CookBook_Backend.Application.Interface;

namespace CookBook.Application
{
    public class BookService : IBookService
    {   
        private readonly IAsyncRepository<Book> _bookRepository;
        public BookService(IAsyncRepository<Book> bookRepository,CookBookContext cookBookContext)
        {
            _bookRepository = bookRepository;
        }

        public async Task<Book> MadeRandomBook()
        {
            var book = new Book()
            {
                Name = "randomname",
                IsFree = true,
                internalName = "ineternal Random Name"
            };
            await _bookRepository.Add(book);
            return book;
        }
    }
}