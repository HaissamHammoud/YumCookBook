using System;
using Cook.Domain.Models.Common;
using Cook.Domain.Models.Users;
using CookBook.Models;

namespace Cook.Domain.Models.Users
{
    public class User : BaseEntity
    {
        public string Document {get; set;}
        public string Email {get; set;}
        public string Loggin {get; set;}
        public string Password {get; set;}
        public string FirstName {get; set;}
        public string LastName {get; set;} 

        public User (string document, string email, string password, string firstName, string lastName)
        {
            if(String.IsNullOrEmpty(document))
            {
                throw new Exception("Não foram preenchidas todas as informações");
            }
            if(String.IsNullOrEmpty(email))
            {
                throw new Exception("Não foram preenchidas todas as informações");
            }
            if(String.IsNullOrEmpty(password))
            {
                throw new Exception("Não foram preenchidas todas as informações");
            }
            if(String.IsNullOrEmpty(firstName ))
            {
                throw new Exception("Não foram preenchidas todas as informações");
            }
            if(String.IsNullOrEmpty(lastName))
            {
                throw new Exception("Não foram preenchidas todas as informações");
            }

            Document = document;
            Email = email;
            FirstName = firstName;
            LastName = lastName;
            Password = password;
            Loggin = email;
            var userCreatedDomainEvent = new UserCreatedDomainEvent(this, document, email,
            Loggin, Password, FirstName, LastName);
            this.AddDomainEvent(userCreatedDomainEvent);
        }
    }
}