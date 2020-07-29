using System;
using System.Collections.Generic;
using Cook.Domain.Models;
using Cook.Domain.Models.Users;
using CookBook.Models;

namespace CookBook.Models
{
    public class Book : BaseEntity
    {
        public string Name {get; set; }
        public Customer Owner {get; set; }
        public List<BuyedBook> BuyedBy {get; set; }
        public bool IsFree {get; set; }
        public string InternalName {get; set; }

        public Book()
        {
            Id = Guid.NewGuid();
        }

        public static Book CreateBook(string name, bool isFree, string internalName)
        {
            if(String.IsNullOrEmpty(name))
            {
                throw new Exception("name must be especified");
            }
            var book = new Book()
            {
                Name = name,
                IsFree = isFree,
                InternalName = internalName
            };
            return book;
        }
    }
}