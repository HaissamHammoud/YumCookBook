using System;

namespace CookBook.Models
{
    public class BookDTO
    {
        public Guid Id {get; set; }
        public string Name {get; set; }
        public bool IsFree {get; set; }
    }
}