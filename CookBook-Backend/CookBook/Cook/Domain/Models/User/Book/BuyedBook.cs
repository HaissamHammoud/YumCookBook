using System;
using Cook.Domain.Models;
using Cook.Domain.Models.Users;
using CookBook.Models;

namespace Cook.Domain.Models
{
    public class BuyedBook : BaseEntity
    {
        public Customer Customer {get; set;}
        public Book Book {get;set;}
    }
}