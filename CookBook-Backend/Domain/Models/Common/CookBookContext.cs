using Microsoft.EntityFrameworkCore;

namespace CookBook.Models.Common
{
    public class CookBookContext : DbContext
    {

        public CookBookContext(DbContextOptions<CookBookContext> options) : base(options)
        {
        }

        public DbSet<Book> Books {get; set;}
    }

}