using System;

namespace Cook.Domain.Models.Users
{
    public class User : BaseEntity
    {
        public Document Document {get; set;}
        public Email Email {get; set;}
        public string loggin {get; set;}
        public string password {get; set;}
        public string FirstName {get; set;}
        public string LastName {get; set;} 

        public User (string document, string email, string passoword, string firstName, string lastName)
        {
            if(String.IsNullOrEmpty(document || email || passoword || firstName || LastName))
            {
                throw new Exception("Não foram preenchidas todas as informações");
            }

            var newEmail = new Email(email);
            var newDocument = new Document(document, "cpf");
            Document = newDocument;
            Email = newEmail;
            FirstName = firstName;
            LastName = lastName;
        }
    }
}