using CookBook.Models;
using Microsoft.EntityFrameworkCore;

namespace CookBook.Repositories
{
    public class CookBookContext : DbContext
    {
        public CookBookContext()
        {
        }

        public CookBookContext(DbContextOptions<CookBookContext> options) : base(options)
        {
        }

        public DbSet<Book> Books {get; set;}

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }

}