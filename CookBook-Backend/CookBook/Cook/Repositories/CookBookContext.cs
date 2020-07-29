using Cook.Domain.Models.Users;
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
        public DbSet<User> Users {get; set;}

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<User>().ToTable("Users");
            builder.Entity<Book>().ToTable("Books");
            base.OnModelCreating(builder);
        }
    }

}