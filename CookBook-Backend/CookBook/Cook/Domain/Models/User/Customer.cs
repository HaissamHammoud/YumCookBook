using System;
using System.Collections.Generic;
using Cook.Domain.Models.User.Book;
using CookBook.Models;

namespace Cook.Domain.Models.Users
{
    public class Customer : BaseEntity 
    {
        public User User {get; set;}
        public Guid UserId {get; set;}
        public string NickName {get; set;}
        public DateTime BirthDate {get; set;}
        public List<Book> OwnedBooks {get; set;}
        public List<Receipt> Receipts {get; set;}
        public string Picture {get; set;}
        public List<Publication> Publications {get; set;}
        public List<BuyedBook> BuyedBooks {get; set;}
        public List<Page> Pages {get; set;}

        public Customer(string nickName, DateTime birthDate,string picture = null) 
        {
            if(String.IsNullOrEmpty(nickName))
            {
                throw new Exception("É Preciso informar o NickName");
            }
            if(String.IsNullOrEmpty(picture))
            {
                Picture = "Url Foto Padrão";
            }
            else
            {
                Picture = picture;
            }
            OwnedBooks = new List<Book>();
            BuyedBooks = new List<BuyedBook>();
            Pages = new List<Page>();
            Publications = new List<Publication>();
            BirthDate = birthDate;
        }   
    }
}