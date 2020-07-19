using System;
using Domain.Models.Interface;

namespace CookBook.Models
{
    public class BaseEntity : IEntity
    {
        public Guid Id {get; set; }
        public DateTime CreatedAt { get; set; }

    }
}