using System;
using CookBook.Models;
using Xunit;

namespace Cook.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            Book book = new Book();
            book.Name = "blabla";
            Assert.Equal("blabla", book.Name);
        }
    }
}
