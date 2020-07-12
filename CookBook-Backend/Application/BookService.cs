using System;
using CookBook.Interface;
using CookBook.Models;
using CookBook.Repositories;

namespace CookBook.Application
{
    public class BookService
    {   
        private readonly IAsyncRepository<Book> _bookRepository;
        private readonly CookBookContext _cookBookContext;
        public BookService(IAsyncRepository<Book> bookRepository,CookBookContext cookBookContext)
        {
            _bookRepository = bookRepository;
            _cookBookContext = cookBookContext;
        }

        public Book MadeRandomBook()
        {
            var book = new Book()
            {
                Name = "randomname",
                IsFree = true,
                internalName = "ineternal Random Name"
            };
            _bookRepository.Add(book);
            return book;
        }
    }
}