using System.Threading.Tasks;
using CookBook.Models;

namespace CookBook_Backend.Application.Interface
{
    public interface IBookService
    {
        Task<Book> MadeRandomBook();
    }
}