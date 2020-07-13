using System;
using CookBook_Backend.Domain.Models.Common;

namespace CookBook_Backend.Domain.Models.User
{
    public class User
    {
        public Guid Id { get;  set; }
        public Email Email { get; set; }
        public string Name {get; set;}
        public string Loggin {get; set; }
        public string Password{get; set; }
        public DateTime CreatedAt {get; set; }
        public DateTime UpdatedAt {get; set; }

        public User()
        {
            Id = Guid.NewGuid();
        }

        public static User CreateNewUser(Email email, string name, string password)
        {
            if(!String.IsNullOrEmpty(name) || !String.IsNullOrEmpty(name))
            {
                throw new Exception("Invalid user informations");
            }
            var user = new User();
            user.Email = email;
            user.Loggin = email.Address;
            user.Name = name;
            user.Password = password;
            user.CreatedAt = DateTime.Now;
            user.UpdatedAt = DateTime.Now;

            return user;
        }

        
    }
}