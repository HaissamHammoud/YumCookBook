using MediatR;

namespace Cook.Domain.Models.Users
{
    public class UserCreatedDomainEvent : INotification
    {
        public User User { get; set; }
        public string DocumentNumber {get; set;}
        public string Email {get; set;}
        public string Loggin {get; set;}
        public string Password {get; set;}
        public string FirstName {get; set;}
        public string LastName {get; set;} 

        public UserCreatedDomainEvent(User user, string documentNumber,string email,
            string loggin, string password, string firstName, string lastName)
        {
            User = user;
            DocumentNumber = documentNumber;
            Email = email;
            Loggin = loggin;
            Password = password;
            FirstName = firstName;
            LastName = lastName;
        }
    }
}