using CookBook.Models;
using Xunit;

namespace Cook.Tests.Books
{
    public class BookTest
    {
        [Fact]
        public void CreateNewBook()
        {
            Book book = Book.CreateBook("NewBook",true,"BookInternal");
            Assert.NotEmpty(book.Id.ToString());
            Assert.Equal("NewBook",book.Name);
            Assert.True(book.IsFree);
            Assert.Equal("BookInternal", book.InternalName);

        }
        
    }
}