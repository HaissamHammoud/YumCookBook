using System;
using System.Collections.Generic;
using Domain.Models.Interface;
using MediatR;

namespace CookBook.Models
{
    public abstract class BaseEntity : IEntity
    {
        public Guid Id {get; set; }
        public DateTime CreatedAt { get; set; }

        private List<INotification> _domainEvents;
        public List<INotification> DomainEvents => _domainEvents;

        public void AddDomainEvent(INotification eventItem)
        {
            _domainEvents = _domainEvents?? new List<INotification>();
            _domainEvents.Add(eventItem);
        }

        public void RemoveDomainEvent(INotification eventItem)
        {
            _domainEvents?.Remove(eventItem);
        }
    }
}