using CookBook.Models;
using Microsoft.EntityFrameworkCore;

namespace CookBook.Repositories
{
    public class CookBookContext : DbContext
    {

        public CookBookContext(DbContextOptions<CookBookContext> options) : base(options)
        {
        }

        public DbSet<Book> Books {get; set;}
    }

}