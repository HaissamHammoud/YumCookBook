using System;
using CookBook.Models;

namespace CookBook.Models
{
    public class Book : BaseEntity
    {
        public string Name {get; set; }
        public bool IsFree {get; set; }
        public string internalName {get; set; }

        public Book()
        {
            Id = Guid.NewGuid();
        }
    }
}