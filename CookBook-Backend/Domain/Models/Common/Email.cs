using System;

namespace CookBook_Backend.Domain.Models.Common
{
    public class Email
    {
        public string Address {get; set;}

        public Email(string address)
        {
            if(!address.Contains("@"))
            {
                throw new Exception("Invalid Email");
            }
            if(!address.Contains("."))
            {
                throw new Exception("Invalid Email");
            }
        }
    }
}