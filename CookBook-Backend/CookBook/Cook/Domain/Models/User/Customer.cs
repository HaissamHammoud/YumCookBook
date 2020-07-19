using System;
namespace Cook.Domain.Models.Users
{
    public class Customer : User
    {
        public string NickName {get; set;}
        public DateTime BirthDate {get; set;}
        public List<Book> OwnedBooks {get; set;}
        public List<Receipt> Receipts {get; set;}
        public string Picture {get; set;}
        public List<Publication> Publications {get; set;}
        public List<Book> BuyedBooks {get; set;}
        public List<Page> Pages {get; set;}

        public Customer(string nickName, DateTime birthDate, string? picture)
        {
            if(String.IsNullOrEmpty(nickName))
            {
                throw new Exception("É Preciso informar o NickName");
            }
            if(birthDate = null)
            {
                throw new Exception("É Preciso informar a data de nascimento");
            }
            if(String.IsNullOrEmpty(picture))
            {
                Picture = "Url Foto Padrão";
            }
            OwnedBooks = new List<Book>();
            BuyedBooks = new List<Book>();
            Pages = new List<Page>();
            Publication = new List<Publication>();
        }   
    }
}