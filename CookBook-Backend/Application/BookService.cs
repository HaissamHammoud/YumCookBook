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
            var number = Random.Equals(0,100);
            number.ToString();
            var name = "Random Name" + number.ToString();
            var book = Book.CreateBook(name, true, name);
            await _bookRepository.Add(book);
            return book;
        }

        public async Task<Book> CreateBook(string name, bool isFree, string internalName)
        {
            var book = Book.CreateBook(name, isFree, internalName);
            await _bookRepository.Add(book);
            return book;
        }
    }
}