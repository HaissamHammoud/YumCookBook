using Cook.Domain.Models;
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
        public DbSet<Customer> Customers {get; set;}

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<User>().ToTable("Users")
                .HasOne(u => u.Customer)
                .WithOne(c => c.User);
            builder.Entity<Book>().ToTable("Books");
            builder.Entity<Customer>().ToTable("Customers")
                .HasMany(a => a.OwnedBooks)
                .WithOne(b => b.Owner);
            builder.Entity<Customer>().ToTable("Customer")
                .HasMany(c => c.BuyedBooks)
                .WithOne(b => b.Customer);
            builder.Entity<Customer>()
                .HasOne(c => c.User)
                .WithOne(u => u.Customer);
            builder.Entity<BuyedBook>().ToTable("buyed_book")
                .HasOne(b => b.Customer)
                .WithMany(c => c.BuyedBooks);
            builder.Entity<BuyedBook>()
                .HasOne(b => b.Book)
                .WithMany(c => c.BuyedBy);
            base.OnModelCreating(builder);
        }
    }

}